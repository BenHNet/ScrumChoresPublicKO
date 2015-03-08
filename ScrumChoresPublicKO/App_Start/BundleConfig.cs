using System.Web;
using System.Web.Optimization;

namespace ScrumChoresPublicKO
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.11.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.3.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrumchorescommon").Include(
                        "~/Scripts/ScrumChores/Common/NameSpace.js",
                        "~/Scripts/ScrumChores/Common/DateHelper.js",
                        "~/Scripts/ScrumChores/Common/Models/Sprint.js"));

            bundles.Add(new ScriptBundle("~/bundles/chorelist").Include(
                        "~/Scripts/ScrumChores/ViewModels/ChoreListVM.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/themes/base/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/style.css",
                      "~/Content/blue.css"));
        }
    }
}
