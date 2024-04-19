using System.ComponentModel.DataAnnotations;

namespace Library.Domain;

public class SimpleLibraryBook : LibraryItem, IReaderNotifier
{
	[Required]
	public string Title { get; set; } = string.Empty;
	public string Author { get; set; } = null!;

	public string IdIsbn { get; set; } = string.Empty;

	public int PrintYear { get; set; } = 0;
	
	public int CopiesAvailable { get; set; } = 0;

	public IBookSubscriptionHandler BookSubscriptionHandler;

	public SimpleLibraryBook(IBookSubscriptionHandler bookSubscriptionHandler, int copiesAvailable, int printYear, string author, string title, string idIsbn)
	{
		BookSubscriptionHandler = bookSubscriptionHandler;
		CopiesAvailable = copiesAvailable;
		PrintYear = printYear;
		Author = author;
		Title = title;
		IdIsbn = idIsbn;
	}

	public void AddBook()
	{
		BookSubscriptionHandler.NotifyBookAvailable(this.Title, this.IdIsbn);
		CopiesAvailable++;
		BookSubscriptionHandler.SubscribeToBook(Title, IdIsbn);
	}

	public bool IsExtendable()
	{
		return BookSubscriptionHandler.IsBookAvailable(this.Title, this.IdIsbn);
	}
	
	public bool TrySubscribe()
	{
		if (this.CopiesAvailable == 0)
		{
			BookSubscriptionHandler.SubscribeToBook(this.Title, this.IdIsbn);
			return true;
		}
		return false;
	}

	public Task NotifyBookAvailable(string userId, string message)
	{
		//notify this user that book is available
		//tbd
		return null;
	}
}
