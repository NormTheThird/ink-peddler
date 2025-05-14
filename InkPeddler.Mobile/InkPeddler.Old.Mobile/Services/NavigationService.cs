using InkPeddler.Mobile.PageModels.Base;
using InkPeddler.Mobile.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InkPeddler.Mobile.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModelBase>(object navigateData = null, bool setRoot = false);
        Task GoBackAsync();
    }

    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync<TPageModelBase>(object navigateData = null, bool setRoot = false)
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));

            if (setRoot)
                App.Current.MainPage = new NavigationPage(page);
            else if (App.Current.MainPage is NavigationPage navPage)
                await navPage.PushAsync(page);
            else
                App.Current.MainPage = new NavigationPage(page);

            if (page.BindingContext is PageModelBase baseViewModel)
                await baseViewModel.InitializeAsync(navigateData);
        }

        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
    }
}