using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Ts3.pl.App_Start.BootstrapBundleConfig), "RegisterBundles")]

namespace Ts3.pl.App_Start
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles()
        {
            // Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
            // For Bootstrap theme add @Styles.Render("~/Content/bootstrap-theme") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery-3.1.0.js"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/css/forum/styleSheets.css")
                .Include("~/Content/css/forum/style.css")
                .Include("~/Content/css/style.css")
                .Include("~/Content/css/forumStyle.css")
                .Include("~/Content/css/customs.css")
                .Include("~/Content/bootstrap.css")
                );
        }
    }
}
