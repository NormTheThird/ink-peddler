using React;
using System.Web;
using System.Web.Optimization;

namespace InkPeddler.UI.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //var babel = ReactEnvironment.Current.Babel;

            //var result = babel.Transform("~/Content/plugins/jquery/jquery-3.1.0.min.js");

            bundles.Add(new StyleBundle("~/css").Include("~/Content/css/*.css"));
            bundles.Add(new ScriptBundle("~/JS/plugins").Include(
                "~/Content/plugins/jquery/jquery-3.1.0.min.js",
                "~/Content/plugins/jquery-validate/jquery.validate.min.js",
                "~/Content/plugins/jquery-validate/additional-methods.min.js",
                "~/Content/plugins/jquery-colorbox/jquery.colorbox.min.js",
                "~/Content/plugins/jquery-isotope/jquery.isotope.min.js",
                "~/Content/plugins/bootstrap/bootstrap_3.3.2/js/bootstrap.min.js",
                "~/Content/scripts/script.js",
                "~/Content/scripts/imagesloaded.pkgd.min.js",
                "~/Content/scripts/masonry.pkgd.min.js",
                "~/Content/plugins/knockout/knockout.3.2.0.min.js",
                "~/Content/plugins/jquery-cookie/jquery.cookie.js",
                "~/Content/plugins/toastr/toastr.min.js"
                ));

            bundles.Add(new ScriptBundle("~/VM/Scripts").Include(
                "~/ViewModels/Scripts/_BaseViewModel.js",
                "~/ViewModels/Scripts/ArtistViewModel.js",
                "~/ViewModels/Scripts/HomeViewModel.js",
                "~/ViewModels/Scripts/UploadViewModel.js",
                "~/ViewModels/Scripts/SearchViewModel.js",
                "~/ViewModels/Scripts/ShopViewModel.js",
                "~/ViewModels/Scripts/TattooViewModel.js",
                //"~/ViewModels/Scripts/ViewModel.js",
                "~/ViewModels/Scripts/UserViewModel.js"
                ));
        }
    }
}