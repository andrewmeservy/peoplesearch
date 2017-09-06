using PeopleSearchBusinessLogic.DataAccessObjects;
using PeopleSearchBusinessLogic.IServices;
using PeopleSearchBusinessLogic.Services;
using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PeopleSearchBusinessLogic.Logic
{
	public class PersonService : BaseService<Person, PersonDao>, IPersonService
	{
		protected readonly new IPersonRepository repository;

		public PersonService(IPersonRepository repository) : base(repository)
		{
			this.repository = repository;
		}

		public override IEnumerable<PersonDao> ToDao(IEnumerable<Person> entities) => entities.Select(ToDao);

		public override PersonDao ToDao(Person entity)
		{
			return new PersonDao()
			{
				Id = entity.Id,
				Name = entity.Name,
				Address = entity.Address,
				Age = entity.Age,
				Interests = entity.Interests,
				Picture = entity.Picture
			};
		}

		public override IEnumerable<Person> ToEntity(IEnumerable<PersonDao> daos) => daos.Select(ToEntity);

		public override Person ToEntity(PersonDao dao)
		{
			return new Person()
			{
				Id = dao.Id,
				Name = dao.Name,
				Address = dao.Address,
				Age = dao.Age,
				Interests = dao.Interests,
				Picture = dao.Picture
			};
		}

		public IEnumerable<PersonDao> GetByName(string name)
		{
			SimulateSlowness();
			return ToDao(repository.GetByName(name));
		}

		private void SimulateSlowness()
		{
			Thread.Sleep(5000);
		}
	}
}
