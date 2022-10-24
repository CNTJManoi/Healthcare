namespace Healthcare.Notification;

public interface IComponent
{
    TypeNotification TypeNotification { get; }
    public void Notify(string result);
}