using System.ComponentModel.DataAnnotations;

namespace PeopleSearchDataAccessLayer.Entities
{
	public class Person : BaseEntity
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public string Interests { get; set; }

		[Required]
		public string Picture { get; set; }
	}
}
