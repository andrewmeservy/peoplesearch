using PeopleSearchDataAccessLayer;
using PeopleSearchDataAccessLayer.Entities;
using System.Data.Entity;

namespace PeopleSearchUnitTestLayer
{
	public class TestDbContext : DbContext, IPeopleSearchDbContext
	{
		public TestDbContext() : base("PeopleSearch_UnitTesting")
		{
			Database.SetInitializer(new TestDbInitializer());
		}

		public DbSet<Person> People { get; set; }
	}
}
