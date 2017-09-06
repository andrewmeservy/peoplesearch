using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearchDataAccessLayer.Repositories
{
	public class PersonRepository : BaseRepository<Person>, IPersonRepository
	{
		public PersonRepository(IPeopleSearchDbContext context) : base(context) { }

		public IEnumerable<Person> GetByName(string name) => context.Set<Person>().Where(person => person.Name.ToLower().Contains(name.ToLower())).AsEnumerable();
	}
}
