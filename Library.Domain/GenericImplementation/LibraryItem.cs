using System.ComponentModel.DataAnnotations;

namespace Library.Domain;


public class LibraryItem
{
	[Key]
	[Required]
	public Guid Id { get; set; } = Guid.NewGuid();

	public DateTime DateCreated { get; set; } = DateTime.Today;

	public DateTime DateUpdated { get; set; } = DateTime.Today;
}

