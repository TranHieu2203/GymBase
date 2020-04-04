using System.Web;
using System.Web.Optimization;

namespace GymApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;   //enable CDN support
            var dtDateCdnPath = "http://cdn.datatables.net/plug-ins/1.10.15/dataRender/datetime.js";
            bundles.Add(new ScriptBundle("~/bundles/dtDate",
                                    dtDateCdnPath));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/themes/bower_components/jquery/dist/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/anguarjs").Include(
                        "~/Scripts/angular.min.js",
                         "~/Scripts/app/app.js",
                          "~/Scripts/app/controller.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/themes/bower_components/jquery/dist/jquery.min.js",
                       "~/Content/themes/bower_components/popper.js/dist/umd/popper.min.js",
                        "~/Content/themes/bower_components/moment/moment.js",
                         "~/Content/themes/bower_components/chart.js/dist/Chart.min.js",
                          "~/Content/themes/bower_components/select2/dist/js/select2.full.min.js",
                           "~/Content/themes/bower_components/jquery-bar-rating/dist/jquery.barrating.min.js",
                            "~/Content/themes/bower_components/ckeditor/ckeditor.js",
                             "~/Content/themes/bower_components/bootstrap-validator/dist/validator.min.js",
                              "~/Content/themes/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                               "~/Content/themes/bower_components/ion.rangeSlider/js/ion.rangeSlider.min.js",
                                "~/Content/themes/bower_components/dropzone/dist/dropzone.js",
                                 "~/Content/themes/bower_components/editable-table/mindmup-editabletable.js",
                                  "~/Content/themes/bower_components/datatables.net/js/jquery.dataTables.min.js",
                                   "~/Content/themes/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                                    "~/Content/themes/bower_components/fullcalendar/dist/fullcalendar.min.js",
                                     "~/Content/themes/bower_components/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js",
                                      "~/Content/themes/bower_components/tether/dist/js/tether.min.js",
                                       "~/Content/themes/bower_components/slick-carousel/slick/slick.min.js",
                                        "~/Content/themes/bower_components/bootstrap/js/dist/util.js",
                                         "~/Content/themes/bower_components/bootstrap/js/dist/alert.js",
                                          "~/Content/themes/bower_components/bootstrap/js/dist/button.js",
                                           "~/Content/themes/bower_components/bootstrap/js/dist/carousel.js",
                                            "~/Content/themes/bower_components/bootstrap/js/dist/collapse.js",
                                             "~/Content/themes/bower_components/bootstrap/js/dist/dropdown.js",
                                              "~/Content/themes/bower_components/bootstrap/js/dist/modal.js",
                                                "~/Content/themes/bower_components/bootstrap/js/dist/tab.js",
                                                 "~/Content/themes/bower_components/bootstrap/js/dist/tooltip.js",
                                                   "~/Content/themes/bower_components/bootstrap/js/dist/popover.js",
                                                     "~/Content/themesjs/dataTables.bootstrap4.min.js",
                                                      "~/Content/themes/js/demo_customizer.js",
                                                       "~/Content/themes/js/main.js"
                                                     
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/themes/bower_components/select2/dist/css/select2.min.css",
                       "~/Content/themes/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                        "~/Content/themes/bower_components/dropzone/dist/dropzone.css",
                          "~/Content/themes/bower_components/fullcalendar/dist/fullcalendar.min.css",
                            "~/Content/themes/bower_components/perfect-scrollbar/css/perfect-scrollbar.min.css",
                             "~/Content/themes/bower_components/slick-carousel/slick/slick.css",
                              "~/Content/themes/css/main.css"));
        } 
    }
}
