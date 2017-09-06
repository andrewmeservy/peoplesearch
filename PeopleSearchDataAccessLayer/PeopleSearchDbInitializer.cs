using PeopleSearchDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PeopleSearchDataAccessLayer
{
	public class PeopleSearchDbInitializer : DropCreateDatabaseIfModelChanges<PeopleSearchDbContext>
	{
		protected override void Seed(PeopleSearchDbContext context)
		{
			base.Seed(context);

			SeedPeople(context);
		}

		private void SeedPeople(PeopleSearchDbContext context)
		{
			List<Person> people = new List<Person>();
			people.Add(new Person() { Name = "Rick", CreationDate = DateTime.UtcNow, Address = "123 Street", Age = 60, Interests = "Going on Adventures. Drinking. Belching. Paradoxes", Picture = "rick.jpg" });
			people.Add(new Person() { Name = "Morty", CreationDate = DateTime.UtcNow, Address = "4576 Drive", Age = 14, Interests = "Going on Adventures with Rick. Likes Jessica.", Picture = "morty.jpg" });
			people.Add(new Person() { Name = "Beth", CreationDate = DateTime.UtcNow, Address = "567 Avenue", Age = 34, Interests = "Helping Rick, Drinking, and Horse Surgery", Picture = "beth.png" });
			people.Add(new Person() { Name = "Jerry", CreationDate = DateTime.UtcNow, Address = "123 Street", Age = 35, Interests = "Being Normal. Human Music", Picture = "jerry.png" });
			people.Add(new Person() { Name = "Summer", CreationDate = DateTime.UtcNow, Address = "7897 Fake Addres", Age = 17, Interests = "Texting and World Domination", Picture = "summer.jpg" });

			context.Set<Person>().AddRange(people);
		}
	}
}
