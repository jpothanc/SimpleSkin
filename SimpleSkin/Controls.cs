using System.Collections.Generic;

namespace SimpleSkin
{
    partial class Controls : IControls
    {
        Dictionary<string,ControlColor> _controls = new Dictionary<string,ControlColor>();

        Skin _theme = Skin.None;
        public Controls(Skin theme)
        {
            _theme = theme;
        }
        public void AddControl(string controlName, ControlColor simpleControlColor)
        {
            if (!_controls.ContainsKey(controlName))
            {
                _controls.Add(controlName, simpleControlColor);
            }
        }

        public ControlColor GetControl(string controlName)
        {
            _controls.TryGetValue(controlName, out ControlColor simpleControlColor);
            return simpleControlColor;
        }

        public Skin GetTheme()
        {
            return _theme;
        }
    }
}
