using System.Collections.Generic;

namespace SimpleSkin
{
    public class SimpleControlTheme : ISimpleControlTheme
    {
        Dictionary<string,SimpleControlColor> _controls = new Dictionary<string,SimpleControlColor>();

        Theme _theme = Theme.None;
        public SimpleControlTheme(Theme theme)
        {
            _theme = theme;
        }
        public void AddControl(string controlName, SimpleControlColor simpleControlColor)
        {
            if (!_controls.ContainsKey(controlName))
            {
                _controls.Add(controlName, simpleControlColor);
            }
        }

        public SimpleControlColor GetControl(string controlName)
        {
            _controls.TryGetValue(controlName, out SimpleControlColor simpleControlColor);
            return simpleControlColor;
        }

        public Theme GetTheme()
        {
            return _theme;
        }
    }
}
