using PeopleSearchDataAccessLayer.Entities;
using System.Data.Entity;

namespace PeopleSearchDataAccessLayer
{
	public interface IPeopleSearchDbContext
	{
		DbSet<Person> People { get; set; }
	}
}
