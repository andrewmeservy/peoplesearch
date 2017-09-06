using PeopleSearchDataAccessLayer.Entities;
using PeopleSearchDataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PeopleSearchDataAccessLayer.Repositories
{
	public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
	{
		protected readonly DbContext context;

		public BaseRepository(IPeopleSearchDbContext context)
		{
			this.context = context as DbContext;
		}

		public Entity Create(Entity entity)
		{
			Entity newEntity = context.Set<Entity>().Add(entity);
			context.SaveChanges();
			return newEntity;
		}

		public IEnumerable<Entity> Create(IEnumerable<Entity> entities)
		{
			IEnumerable<Entity> newEntities = context.Set<Entity>().AddRange(entities);
			context.SaveChanges();
			return newEntities;
		}

		public IEnumerable<Entity> Get() => context.Set<Entity>().AsEnumerable();

		public Entity Get(int id) => context.Set<Entity>().Find(id);

		public IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate) => context.Set<Entity>().Where(predicate);

		public void Update(Entity entity)
		{
			context.Set<Entity>().Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}

		public void Update(IEnumerable<Entity> entities) => entities.ToList().ForEach(Update);

		public void Delete(int id) => Delete(Get(id));

		public void Delete(Entity entity)
		{
			context.Set<Entity>().Attach(entity);
			context.Set<Entity>().Remove(entity);
			context.SaveChanges();
		}

		public void Delete(IEnumerable<int> ids) => ids.ToList().ForEach(id => Delete(id));

		public void Delete(IEnumerable<Entity> entities) => context.Set<Entity>().RemoveRange(entities);
	}
}
