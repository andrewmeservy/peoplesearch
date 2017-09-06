using PeopleSearch.Models;
using PeopleSearchBusinessLogic.DataAccessObjects;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PeopleSearch.Converters
{
	public static class PersonConverter
	{
		public static PersonModel ToModel(PersonDao dao)
		{
			return new PersonModel()
			{
				Name = dao.Name,
				Address = dao.Address,
				Age = dao.Age,
				Interests = dao.Interests,
				Picture = dao.Picture
			};
		}

		public static IEnumerable<PersonModel> ToModel(IEnumerable<PersonDao> daos) => daos.Select(ToModel);

		public static PersonDao ToDao(PersonModel model)
		{
			return new PersonDao()
			{
				Name = model.Name,
				Address = model.Address,
				Age = model.Age,
				Interests = model.Interests,
				Picture = model.Picture
			};
		}

		public static IEnumerable<PersonDao> ToDao(IEnumerable<PersonModel> models) => models.Select(ToDao);
	}
}