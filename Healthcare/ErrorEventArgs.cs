namespace Healthcare;

public class ErrorEventArgs
{
    public ErrorEventArgs(string text)
    {
        Text = text;
    }

    public string Text { get; }
}