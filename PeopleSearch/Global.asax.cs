using Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PeopleSearchBusinessLogic.Logic;
using PeopleSearchBusinessLogic.IServices;
using Autofac.Integration.Mvc;
using PeopleSearchDataAccessLayer.Repositories;
using PeopleSearchDataAccessLayer.IRepositories;
using PeopleSearchDataAccessLayer;
using System.Data.Entity;

namespace PeopleSearch
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private static IContainer container { get; set; }

		protected void Application_Start()
		{
			RegisterAutofac();

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		private void RegisterAutofac()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			builder.RegisterType<PeopleSearchDbContext>().As<IPeopleSearchDbContext>().InstancePerRequest();

			builder.RegisterType<PersonService>().As<IPersonService>();

			builder.RegisterType<PersonRepository>().As<IPersonRepository>();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}
