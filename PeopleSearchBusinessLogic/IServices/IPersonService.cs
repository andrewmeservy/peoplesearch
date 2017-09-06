using PeopleSearchBusinessLogic.DataAccessObjects;
using PeopleSearchDataAccessLayer.Entities;
using System.Collections.Generic;

namespace PeopleSearchBusinessLogic.IServices
{
	public interface IPersonService : IBaseService<Person, PersonDao>
	{
		IEnumerable<PersonDao> GetByName(string name);
	}
}
