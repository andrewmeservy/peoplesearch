using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleSearchDataAccessLayer.Entities
{
	public abstract class BaseEntity
	{
		public BaseEntity()
		{
			CreationDate = DateTime.Now;
		}

		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime CreationDate { get; set; }
	}
}
