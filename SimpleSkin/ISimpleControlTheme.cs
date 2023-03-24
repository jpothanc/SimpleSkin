namespace SimpleSkin
{
    public interface ISimpleControlTheme
    {
        Theme GetTheme();
        void AddControl(string controlName, SimpleControlColor simpleControlColor);
        SimpleControlColor GetControl(string controlName);

    }
}
