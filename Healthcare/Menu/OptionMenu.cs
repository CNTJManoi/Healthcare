namespace Healthcare.Menu;

internal class OptionMenu
{
    public OptionMenu(Action act)
    {
        GetAction = act;
    }

    public Action GetAction { get; }
}