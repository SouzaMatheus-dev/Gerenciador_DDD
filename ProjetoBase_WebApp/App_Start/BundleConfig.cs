using System.Web;
using System.Web.Optimization;

namespace ProjetoBase_WebApp
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/app.min.js",
                      "~/Scripts/default.min.js",
                      "~/Scripts/HoldOn.min.js",
                      "~/Scripts/pnotify.js",
                      "~/Scripts/sweetalert.min.js",
                      "~/Scripts/Vue/vue.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/app.min.css"));
        }
    }
}
