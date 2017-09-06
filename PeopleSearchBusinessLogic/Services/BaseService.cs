using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PeopleSearchBusinessLogic.IServices;
using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.IRepositories;
using System.Linq;

namespace PeopleSearchBusinessLogic.Services
{
	public abstract class BaseService<Entity, Dao> : IBaseService<Entity, Dao> where Entity : BaseEntity
	{
		protected readonly IBaseRepository<Entity> repository;

		public BaseService(IBaseRepository<Entity> repository)
		{
			this.repository = repository;
		}

		public abstract IEnumerable<Dao> ToDao(IEnumerable<Entity> entities);

		public abstract Dao ToDao(Entity entity);

		public abstract IEnumerable<Entity> ToEntity(IEnumerable<Dao> daos);

		public abstract Entity ToEntity(Dao dao);

		public Dao Create(Dao dao) => ToDao(repository.Create(ToEntity(dao)));

		public IEnumerable<Dao> Create(IEnumerable<Dao> daos) => daos.Select(Create);

		public IEnumerable<Dao> Get() => ToDao(repository.Get());

		public Dao Get(int id) => ToDao(repository.Get(id));

		public IEnumerable<Dao> Get(Expression<Func<Entity, bool>> predicate) => ToDao(repository.Get(predicate));

		public void Update(Dao dao) => repository.Update(ToEntity(dao));

		public void Update(IEnumerable<Dao> daos) => repository.Update(daos.Select(ToEntity));

		public void Delete(int id) => repository.Delete(id);

		public void Delete(Dao dao) => repository.Delete(ToEntity(dao));

		public void Delete(IEnumerable<int> ids) => repository.Delete(ids);

		public void Delete(IEnumerable<Dao> daos) => repository.Delete(ToEntity(daos));
	}
}
