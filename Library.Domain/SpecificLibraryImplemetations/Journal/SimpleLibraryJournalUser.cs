namespace Library.Domain;

public class SimpleLibraryJournalUser : SimpleLibraryUser
{
	public int JournalBorrowLimit = 0;
	public LibraryUserRank UserRank;
	
	public SimpleLibraryJournalUser(string fullName, LibraryUserRank userRank) : base(fullName)
	{
		switch (userRank)
		{
			case LibraryUserRank.Guest: JournalBorrowLimit = 0; break;
			case LibraryUserRank.Student:
			case LibraryUserRank.Employee:
			case LibraryUserRank.Teacher: JournalBorrowLimit = 1; break;
		}
	}
	

	protected override bool OnReturnPolicy(LibraryItem libraryItem)
	{
		switch (UserRank)
		{
			case LibraryUserRank.Employee:
			case LibraryUserRank.Student:
				if (JournalBorrowLimit < 15)
				{
					JournalBorrowLimit += 1;
				}
				break;
			case LibraryUserRank.Teacher:
				break;
			case LibraryUserRank.Guest:
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
			if (item is SimpleLibraryJournal) 
			{
				counter++;
			}
		}
		return JournalBorrowLimit < counter;
	}
}