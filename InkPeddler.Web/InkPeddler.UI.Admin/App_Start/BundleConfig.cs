using System.Web.Optimization;

namespace InkPeddler.UI.Admin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/core_scripts").Include(
            //            "~/Content/plugins/jquery/jquery.min.js",
            //            "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
            //            "~/Content/plugins/datatables/jquery.dataTables.js",
            //            "~/Content/plugins/datatables/dataTables.bootstrap4.js",
            //            "~/Content/js/sb-admin.min.js",
            //            "~/Content/js/sb-admin-datatables.min.js",
            //            "~/Content/plugins/notify/notify.min.js",
            //            "~/Content/plugins/knockout/knockout.3.4.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/view_models").Include("~/ViewModels/*.js"));

            //bundles.Add(new StyleBundle("~/Content/core_styles").Include(
            //            "~/Content/plugins/bootstrap/css/bootstrap.min.css",
            //            "~/Content/plugins/bootstrap/css/bootstrap-grid.min.css",
            //            "~/Content/plugins/font-awesome/css/font-awesome.min.css",
            //            "~/Content/plugins/datatables/dataTables.bootstrap4.css",
            //            "~/Content/css/sb-admin.css",
            //            "~/Content/css/paged-list.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}