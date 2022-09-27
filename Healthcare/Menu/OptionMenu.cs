namespace Healthcare.Menu;

internal class OptionMenu
{
    public OptionMenu(Action act, string text)
    {
        GetAction = act;
        Text = text;
    }

    public Action GetAction { get; }
    public string Text { get; }
}