using PeopleSearchDataAccessLayer.Entities;
using System.Collections.Generic;

namespace PeopleSearchDataAccessLayer.IRepositories
{
	public interface IPersonRepository : IBaseRepository<Person>
	{
		IEnumerable<Person> GetByName(string name);
	}
}
