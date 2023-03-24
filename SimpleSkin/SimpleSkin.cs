using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleSkin
{

    public class SimpleSkin 
    {
        Dictionary<Skin, IControls> _skinControls = new Dictionary<Skin, IControls>();
        Skin _currentSkin = Skin.None;
        IControls _currentControlSkin = null;
        HashSet<string> _controlExcludes;

        private SimpleSkin(SimpleSkinOptions options)
        {
            _currentSkin = options.Skin;
            _controlExcludes = new HashSet<string>(options.ControlExcludes.Split(','));
            LoadThemes();
        }
        public static SimpleSkin Create(Action<SimpleSkinOptions> options)
        {
            SimpleSkinOptions skinOptions = new SimpleSkinOptions();
            options?.Invoke(skinOptions);
            return new SimpleSkin(skinOptions);
        }
        private void LoadThemes()
        {
            IControls darkSkinControls = new Controls(Skin.Dark);
            ControlColor defaultControl = new ControlColor(Color.FromArgb(55, 55, 55), Color.WhiteSmoke);
            darkSkinControls.AddControl("default", defaultControl);
            darkSkinControls.AddControl("Button", new ControlColor(Color.FromArgb(0, 128, 255), Color.White));
            darkSkinControls.AddControl("TextBox", new ControlColor(Color.WhiteSmoke, Color.Black));
            _skinControls.Add(Skin.Dark, darkSkinControls);

            _currentControlSkin = darkSkinControls;
        }
        public void Apply(Control c)
        {
            var controlName = c.GetType().Name;
            if (!_skinControls.ContainsKey(_currentSkin) || _currentSkin == Skin.None || _controlExcludes.Contains(controlName))
                return;

            var currentSimpleControlTheme  = _currentControlSkin.GetControl(controlName) ?? _currentControlSkin.GetControl("default");
            if (currentSimpleControlTheme == null)
                return;

            c.BackColor = currentSimpleControlTheme.BackColor;
            c.ForeColor = currentSimpleControlTheme.ForeColor;
            c.Font = currentSimpleControlTheme.Font;

            if (c is Button ctrl)
            {
                ctrl.FlatStyle = FlatStyle.Flat;
                ctrl.FlatAppearance.BorderColor = currentSimpleControlTheme.BackColor;
                ctrl.FlatAppearance.BorderSize = 0;
            }
        }

        public void ApplyAll(Control parentControl, Skin theme = Skin.Dark)
        {
            Apply(parentControl);

            foreach (Control control in parentControl.Controls)
            {
                Apply(control);
                ApplyAll(control);
            }
        }

        public Skin GetSkin()
        {
            return _currentSkin;
        }
    }
}
