namespace Library.Domain;

public class BookSubscriptionHandler : IBookSubscriptionHandler
{
	
	// internal storage for subscriber - book conection
	public void SubscribeToBook(string title, string idIsban)
	{
		//add to internal storage book subscription dependency handling
	}

	public bool IsBookAvailable(string title, string idIsban)
	{
		//check if book have ppl who are watching for it, implement queue of book subscibers?
		//logic why book may be not available to subscribe to it
		return false;
	}

	public void NotifyBookAvailable(string title, string idIsban)
	{
		//get user who is first in queue of subscribers and use NotifyBookAvailable(string userId, string message) from IReaderNotifier interface
	}
}