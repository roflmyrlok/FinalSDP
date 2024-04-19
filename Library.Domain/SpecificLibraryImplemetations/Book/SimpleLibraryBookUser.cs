namespace Library.Domain;

public class SimpleLibraryBookUser : SimpleLibraryUser
{

	public int BooksBorrowLimit = 0;
	public LibraryUserRank UserRank;
	
	public SimpleLibraryBookUser(string fullName, LibraryUserRank userRank) : base(fullName)
	{
		switch (userRank)
		{
			case LibraryUserRank.Guest: BooksBorrowLimit = 5; break;
			case LibraryUserRank.Student: BooksBorrowLimit = 10; break;
			case LibraryUserRank.Employee: BooksBorrowLimit = 10; break;
			case LibraryUserRank.Teacher: BooksBorrowLimit = 25; break;
		}
	}

	protected override bool OnReturnPolicy(LibraryItem libraryItem) 
	{
		if (LibraryItemsBorrowedDeadlineDictionary[libraryItem] >= DateTime.Now)
		{
			BooksBorrowLimit = 0;
			ItemsAllowed = 0;
		}
		switch (UserRank)
		{
			case LibraryUserRank.Employee:
			case LibraryUserRank.Student:
				if (BooksBorrowLimit < 15)
				{
					BooksBorrowLimit += 1;
				}
				break;
			case LibraryUserRank.Teacher:
				break;
			case LibraryUserRank.Guest:
				if (BooksBorrowLimit < 15)
				{
					BooksBorrowLimit += 1;
				}
				break;
			break;
		}

		return true;
	}

	protected override bool BorrowItemPolicy(LibraryItem libraryItem)
	{
		if (!base.BorrowItemLimitPolicy())
		{
			return false;
		}
		if (!base.NoExpandedItemsPolicy())
		{
			return false;
		}
		int counter = 0;
		foreach (var item in LibraryItemsBorrowedDeadlineDictionary.Keys)
		{
			if (item is SimpleLibraryBook)
			{
				counter++;
			}
		}
		return BooksBorrowLimit < counter;
	}

	public bool TryExtendBookBorrow(LibraryItem book)
	{
		if (book is not SimpleLibraryBook lb)
		{
			return false;
		}

		if (lb.IsExtendable())
		{
			var newDate = this.LibraryItemsBorrowedDeadlineDictionary[lb].Date.AddDays(7);
			this.LibraryItemsBorrowedDeadlineDictionary[lb] = newDate;
			return true;
		}

		return false;
	}
	
	public bool TrySubscribeToBook(LibraryItem book)
	{
		return book is SimpleLibraryBook libraryBook && libraryBook.TrySubscribe();
	}
}