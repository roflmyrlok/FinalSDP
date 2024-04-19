namespace Library.Domain;

public abstract class SimpleLibraryUser
{
	public int ItemsAllowed = 0;
	public string FullName { get; set; }
	public Dictionary<LibraryItem, DateTime> LibraryItemsBorrowedDeadlineDictionary { get; set; }
	
	public SimpleLibraryUser(string fullName)
	{
		FullName = fullName;
		LibraryItemsBorrowedDeadlineDictionary = new Dictionary<LibraryItem, DateTime>();
	}

	public virtual bool UserBorrowItem(LibraryItem libraryItem)
	{
		BorrowItemPolicy(libraryItem);
		return true;
	}

	public virtual bool UserReturnItem(LibraryItem libraryItem)
	{
		OnReturnPolicy(libraryItem);
		return true;
	}

	protected abstract bool OnReturnPolicy(LibraryItem libraryItem);

	protected abstract bool BorrowItemPolicy(LibraryItem libraryItem);
	protected bool BorrowItemLimitPolicy()
	{
		if (LibraryItemsBorrowedDeadlineDictionary.Keys.Count >= ItemsAllowed)
		{
			return false;
		}
		return true;
	}
	
	protected virtual bool NoExpandedItemsPolicy()
	{
		foreach (var item in LibraryItemsBorrowedDeadlineDictionary)
		{
			if (item.Value >= DateTime.Now)
			{
				return false;
			}
		}

		return true;
	}
}
	
