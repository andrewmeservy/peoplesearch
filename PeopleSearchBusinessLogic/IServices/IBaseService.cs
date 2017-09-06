using PeopleSearchDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PeopleSearchBusinessLogic.IServices
{
	public interface IBaseService<Entity, Dao> where Entity : BaseEntity
	{
		IEnumerable<Dao> ToDao(IEnumerable<Entity> entities);

		Dao ToDao(Entity entity);

		IEnumerable<Entity> ToEntity(IEnumerable<Dao> daos);

		Entity ToEntity(Dao dao);

		Dao Create(Dao dao);

		IEnumerable<Dao> Create(IEnumerable<Dao> daos);

		IEnumerable<Dao> Get();

		Dao Get(int id);

		IEnumerable<Dao> Get(Expression<Func<Entity, bool>> predicate);

		void Update(Dao dao);

		void Update(IEnumerable<Dao> daos);

		void Delete(int id);

		void Delete(Dao dao);

		void Delete(IEnumerable<int> ids);

		void Delete(IEnumerable<Dao> daos);
	}
}
