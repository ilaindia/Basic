using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace School
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/Plugins/modernizr/modernizr-2.8.3.js"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "modernizr",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/modernizr/modernizr-2.8.3.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/respond/respond.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/jQuery/jquery-2.1.4.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery_migrate",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/jquery_migrate/jquery-migrate-1.2.1.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery_cookies",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/jquery_cookie/jquery.cookie.js"

                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery_ui",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/jquery_ui/jquery-ui-1.11.2.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "gsap",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/gsap/main-gsap.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "bootstrap",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/bootstrap/js/bootstrap.min.js"
                });

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "Guru",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Guru.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "Validator",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/validators.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "Dropzone",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/Plugins/dropzone/dropzone.js"
                });

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/Plugins/modernizr/modernizr-2.6.2-respond-1.1.0.min.js",
                            "~/Scripts/Plugins/jQuery/jquery-2.1.4.min.js",
                            "~/Scripts/Plugins/jQuery_Cookie/jQuery.Cookie.js",
                            "~/Scripts/Plugins/jQuery_migrate/jquery-migrate-1.2.1.min.js",
                            "~/Scripts/Plugins/jQuery_ui/jquery-ui-1.11.2.min.js",
                            "~/Scripts/Plugins/bootstrap/bootstrap.min.js"));


            //bundles.Add(new ScriptBundle("~/bundles/Plugins").Include(
            //                //"~/Scripts/plugins/bootstrap_datepicker/bootstrap_datepicker.min.js",
            //                "~/Scripts/plugins/jquery-block-ui/jquery.blockUI.min.js",
            //                "~/Scripts/plugins/mcustom_scrollbar/jquery.mcustomscrollbar.concat.min.js",
            //                "~/Scripts/plugins/bootstrap_dropdown/bootstrap_hover_dropdown.js",
            //                "~/Scripts/plugins/select2/select2.min.js",
            //                "~/Scripts/plugins/backstretch/backstretch.min.js",
            //                "~/Scripts/plugins/bootstrap_progressbar/bootstrap_progressbar.min.js",
            //                "~/Scripts/application.js",
            //                "~/Scripts/plugins.js",
            //                "~/Scripts/plugins/datatables/jquery.datatables.min.js",
            //                "~/Scripts/Plugins/autoNumeric/autoNumeric-1.9.25.js",
            //                //"~/Scripts/plugins/sweet_alert/sweetalert_dev.js",
            //                "~/Scripts/plugins/sweet_alert/sweetalert.min.js",
            //                "~/Scripts/Plugins/noty/jquery.noty.packaged.min.js",
            //                "~/Scripts/Plugins/icheck/icheck.min.js"
            //                //"~/Scripts/validators.js",
            //                //"~/Scripts/Guru.js"
            //                ));

            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                            "~/Scripts/plugins/gsap/main-gsap.min.js",
                            "~/Scripts/plugins/backstretch/backstretch.min.js",
                            "~/Scripts/plugins/bootstrap_loading/lada.min.js",
                            "~/Scripts/plugins/select2/select2.min.js",
                            "~/Scripts/plugins/sweet_alert/sweetalert.min.js",
                            //"~/Scripts/plugins/sweet_alert/sweetalert_dev.js",
                            "~/Scripts/login-v1.js"
                            ));
        }
    }
}