using PeopleSearchDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PeopleSearchDataAccessLayer.IRepositories
{
	public interface IBaseRepository<Entity> where Entity : BaseEntity
	{
		Entity Create(Entity entity);

		IEnumerable<Entity> Create(IEnumerable<Entity> entities);

		IEnumerable<Entity> Get();

		Entity Get(int id);

		IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate);

		void Update(Entity entity);

		void Update(IEnumerable<Entity> entities);

		void Delete(int id);

		void Delete(Entity entity);

		void Delete(IEnumerable<int> ids);

		void Delete(IEnumerable<Entity> entities);
	}
}
