namespace Library.Domain;

public interface IBookSubscriptionHandler
{
	void SubscribeToBook(string title, string idIsban);
	bool IsBookAvailable(string title, string idIsban);
	
	void NotifyBookAvailable(string title, string idIsban);
}