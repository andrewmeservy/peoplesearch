using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.Repositories;
using System;
using System.Linq;

namespace PeopleSearchUnitTestLayer.DataAccessLayerTests.RepositoryTests
{
	[TestClass]
	public class PersonRepositoryTests
	{
		private static TestDbContext context;
		private static AutoMock mock;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			MockProvider.Initialize(testContext);
			context = MockProvider.Context;
			mock = MockProvider.Mock;
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
			var sut = mock.Create<PersonRepository>();

			var entity = new Person()
			{
				Name = "Pickle Rick",
				CreationDate = DateTime.UtcNow,
				Address = "123 Street",
				Age = 60,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes",
				Picture = "rick.jpg"
			};

			//Act
			var result = sut.Create(entity);

			//Assert
			Assert.IsTrue(context.Set<Person>().Any(x => x.Name == "Pickle Rick"));
			Assert.AreEqual(result.Name, entity.Name);
			Assert.AreEqual(result.CreationDate, entity.CreationDate);
			Assert.AreEqual(result.Address, entity.Address);
			Assert.AreEqual(result.Age, entity.Age);
			Assert.AreEqual(result.Interests, entity.Interests);
			Assert.AreEqual(result.Picture, entity.Picture);
		}

		[TestMethod]
		public void Get()
		{
			//Arrange
			var sut = mock.Create<PersonRepository>();

			var entity = new Person()
			{
				Id = 1,
				Name = "Rick",
				CreationDate = new DateTime(2017, 5, 4),
				Address = "123 Street",
				Age = 60,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes",
				Picture = "rick.jpg"
			};

			//Act
			var result = sut.Get(1);

			//Assert
			Assert.AreEqual(result.Name, entity.Name);
			Assert.AreEqual(result.CreationDate, entity.CreationDate);
			Assert.AreEqual(result.Address, entity.Address);
			Assert.AreEqual(result.Age, entity.Age);
			Assert.AreEqual(result.Interests, entity.Interests);
			Assert.AreEqual(result.Picture, entity.Picture);
		}

		[TestMethod]
		public void Update()
		{
			//Arrange
			var sut = mock.Create<PersonRepository>();

			var entity = new Person()
			{
				Id = 3,
				Name = "Rick 2",
				CreationDate = new DateTime(2017, 5, 4),
				Address = "123 Street 2",
				Age = 61,
				Interests = "Going on Adventures. Drinking. Belching. Paradoxes 2",
				Picture = "rick.jpg"
			};

			//Act
			sut.Update(entity);

			//Assert
			Assert.IsTrue(context.Set<Person>().Any(x => x.Name == "Rick 2"));
		}

		[TestMethod]
		public void Delete()
		{
			//Arrange
			var sut = mock.Create<PersonRepository>();

			//Act
			sut.Delete(2);

			//Assert
			Assert.IsFalse(context.Set<Person>().Any(x => x.Id == 2));
		}
	}
}
