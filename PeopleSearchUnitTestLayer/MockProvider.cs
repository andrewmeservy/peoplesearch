using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchDataAccessLayer;

namespace PeopleSearchUnitTestLayer
{
	public static class MockProvider
	{
		public static TestDbContext Context { get; set; }
		public static AutoMock Mock { get; set; }

		public static void Initialize(TestContext testContext)
		{
			Mock = AutoMock.GetLoose();

			Context = new TestDbContext();
			if (Context.Database.Exists())
			{
				Context.Database.Delete();
			}
			Context.Database.CreateIfNotExists();
			Context.Database.Initialize(true);

			Mock.Provide<IPeopleSearchDbContext>(Context);
		}

		public static void Cleanup()
		{
			Context.Database.Delete();
			Context.Dispose();
			Mock.Dispose();
		}
	}
}
