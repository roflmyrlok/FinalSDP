namespace Library.Domain;

//IReaderNotifier interface implemented by my colleague:

public interface IReaderNotifier
{
	Task NotifyBookAvailable(string userId, string message);
}