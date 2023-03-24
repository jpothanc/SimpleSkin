namespace SimpleSkin
{
    partial interface IControls
    {
        Skin GetTheme();
        void AddControl(string controlName, ControlColor simpleControlColor);
        ControlColor GetControl(string controlName);

    }
}
