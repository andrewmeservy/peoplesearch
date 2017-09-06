using PeopleSearchDataAccessLayer.Entities;
using System.Data.Entity;

namespace PeopleSearchDataAccessLayer
{
    public class PeopleSearchDbContext : DbContext, IPeopleSearchDbContext
    {
		public PeopleSearchDbContext() : base("PeopleSearch")
		{
			Database.SetInitializer(new PeopleSearchDbInitializer());
		}

		public DbSet<Person> People { get; set; }
	}
}
