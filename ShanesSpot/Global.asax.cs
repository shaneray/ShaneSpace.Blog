using Raven.Client.Document;
using Raven.Client.Indexes;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShanesSpot
{

    public class MvcApplication : System.Web.HttpApplication
    {
        // Blog DB Document Store
        public static DocumentStore BlogDocumentStore;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Init Blog DB
            BlogDocumentStore = new DocumentStore { ConnectionStringName = "ShanesSpotRavenDatabase" };
            BlogDocumentStore.Initialize();

            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), BlogDocumentStore);
        }
    }
}
