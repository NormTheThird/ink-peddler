using InkPeddler.Mobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TinyIoC;
using InkPeddler.Mobile.Pages;

namespace InkPeddler.Mobile.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            // Register pages and view models
            Register<HomePageModel, HomePage>();
            Register<MainPageModel, MainPage>();
            Register<MapPageModel, MapPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SecurityPageModel, SecurityPage>();

            // Register services (services are registerd as a Singletons default)
            _container.Register<IAccountService, AccountService>();
            _container.Register<INavigationService, NavigationService>();
            // _container.Register<ISecurityService, SecurityService>();
            _container.Register<ISecurityService, SecurityServiceMock>();
        }

        public static T Resolve<T> () where T : class 
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        private static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}