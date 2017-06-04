using System.Web;
using System.Web.Optimization;

namespace IMRWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { //Script Bundles

          
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/TemplateContent/login/js").Include(
                       "~/TemplateContent/plugins/jQuery/jquery-2.2.3.min.js",
                       "~/TemplateContent/bootstrap/js/bootstrap.min.js",
                       "~/TemplateContent/plugins/iCheck/icheck.min.js",
                       "~/Scripts/CustomScript/loader.js",
                       "~/Scripts/CustomScript/custom-validation.js"));

            bundles.Add(new ScriptBundle("~/TemplateContent/main/js").Include(
                     "~/TemplateContent/plugins/jQuery/jquery-2.2.3.min.js",
                     "~/TemplateContent/bootstrap/js/bootstrap.min.js",
                     "~/TemplateContent/plugins/morris/morris.min.js",
                     "~/TemplateContent/plugins/sparkline/jquery.sparkline.min.js",
                     "~/TemplateContent/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                     "~/TemplateContent/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                     "~/TemplateContent/plugins/knob/jquery.knob.js",
                     "~/TemplateCorner/plugins/daterangepicker/daterangepicker.js",
                     "~/TemplateContent/plugins/datepicker/bootstrap-datepicker.js",
                     "~/TemplateContent/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                     "~/TemplateContent/dist/js/app.min.js",
                     "~/TemplateContent/plugins/bs_pagination/jquery.bs_pagination.min.js",
                        "~/TemplateContent/plugins/bs_pagination/localization/en.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/CustomScript/login").Include(
                     "~/Scripts/CustomScript/login.js"));

            bundles.Add(new ScriptBundle("~/CustomScript/simplesearch").Include(
                          "~/Scripts/CustomScript/simplesearch.js",
                          "~/Scripts/CustomScript/searchcommon.js"));

            bundles.Add(new ScriptBundle("~/CustomScript/smartsearch").Include(
              "~/Scripts/CustomScript/smartsearch.js",
              "~/Scripts/CustomScript/searchcommon.js"));

            //Style Bundles

            bundles.Add(new StyleBundle("~/CustomCss/login").Include(
                     "~/Content/CustomCSS/login.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/TemplateContent/login/css").Include(
                      "~/TemplateContent/bootstrap/css/bootstrap.min.css",
                      "~/TemplateContent/dist/css/AdminLTE.min.css",
                      "~/TemplateContent/plugins/iCheck/square/blue.css"));

            bundles.Add(new StyleBundle("~/TemplateContent/main/css").Include(
                      "~/TemplateContent/bootstrap/css/bootstrap.min.css",
                      "~/TemplateContent/dist/css/AdminLTE.min.css",
                      "~/TemplateContent/dist/css/skins/_all-skins.min.css",
                      "~/TemplateContent/plugins/iCheck/flat/blue.css",
                      "~/TemplateContent/plugins/morris/morris.css",
                      "~/TemplateContent/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                      "~/TemplateContent/plugins/datepicker/datepicker3.css",
                      "~/TemplateContent/plugins/daterangepicker/daterangepicker.css",
                      "~/TemplateContent/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/TemplateContent/plugins/bs_pagination/jquery.bs_pagination.min.css"
                 ));
        }
    }
}
