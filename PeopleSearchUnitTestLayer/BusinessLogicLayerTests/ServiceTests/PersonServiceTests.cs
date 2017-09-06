using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchBusinessLogic.DataAccessObjects;
using PeopleSearchBusinessLogic.Logic;
using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.IRepositories;
using PeopleSearchDataAccessLayer.Repositories;
using System.Linq;

namespace PeopleSearchUnitTestLayer.BusinessLogicLayerTests.ServiceTests
{
	[TestClass]
	public class PersonServiceTests
	{
		private static TestDbContext context;
		private static AutoMock mock;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			MockProvider.Initialize(testContext);
			context = MockProvider.Context;
			mock = MockProvider.Mock;

			var repository = mock.Create<PersonRepository>();
			mock.Provide<IPersonRepository>(repository);
		}

		[ClassCleanup]
		public static void Cleanup()
		{
			MockProvider.Cleanup();
		}

		[TestMethod]
		public void Create()
		{
			//Arrange
			var sut = mock.Create<PersonService>();

			var dao = new PersonDao()
			{
				Name = "Pickle Rick",
				Address = "123 Street",
				Age = 60,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes",
				Picture = "rick.jpg"
			};

			//Act
			var result = sut.Create(dao);

			//Assert
			Assert.IsTrue(context.Set<Person>().Any(x => x.Name == "Pickle Rick"));
			Assert.AreEqual(result.Name, dao.Name);
			Assert.AreEqual(result.Address, dao.Address);
			Assert.AreEqual(result.Age, dao.Age);
			Assert.AreEqual(result.Interests, dao.Interests);
			Assert.AreEqual(result.Picture, dao.Picture);
		}

		[TestMethod]
		public void GetByName()
		{
			//Arrange
			var sut = mock.Create<PersonService>();

			var dao = new PersonDao()
			{
				Name = "Rick",
				Address = "123 Street",
				Age = 60,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes",
				Picture = "rick.jpg"
			};

			//Act
			var result = sut.GetByName("Rick");

			//Assert
			Assert.AreEqual(result.First().Name, dao.Name);
			Assert.AreEqual(result.First().Address, dao.Address);
			Assert.AreEqual(result.First().Age, dao.Age);
			Assert.AreEqual(result.First().Interests, dao.Interests);
			Assert.AreEqual(result.First().Picture, dao.Picture);
		}

		[TestMethod]
		public void Get()
		{
			//Arrange
			var sut = mock.Create<PersonService>();

			var dao = new PersonDao()
			{
				Name = "Rick",
				Address = "123 Street",
				Age = 60,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes",
				Picture = "rick.jpg"
			};

			//Act
			var result = sut.Get(1);

			//Assert
			Assert.AreEqual(result.Name, dao.Name);
			Assert.AreEqual(result.Address, dao.Address);
			Assert.AreEqual(result.Age, dao.Age);
			Assert.AreEqual(result.Interests, dao.Interests);
			Assert.AreEqual(result.Picture, dao.Picture);
		}

		[TestMethod]
		public void Update()
		{
			//Arrange
			var sut = mock.Create<PersonService>();

			var dao = new PersonDao()
			{
				Id = 3,
				Name = "Rick 2",
				Address = "123 Street 2",
				Age = 61,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes 2",
				Picture = "rick.jpg"
			};

			//Act
			sut.Update(dao);

			//Assert
			Assert.IsTrue(context.Set<Person>().Any(x => x.Name == "Rick 2"));
		}

		[TestMethod]
		public void Delete()
		{
			//Arrange
			var sut = mock.Create<PersonService>();

			//Act
			sut.Delete(2);

			//Assert
			Assert.IsFalse(context.Set<Person>().Any(x => x.Id == 2));
		}
	}
}
