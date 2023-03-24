using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleSkin
{
    public class SimpleControlManager : ISimpleControlManager
    {
        Dictionary<Theme, ISimpleControlTheme> _themes = new Dictionary<Theme, ISimpleControlTheme>();
        Theme _currentTheme = Theme.None;
        ISimpleControlTheme _currentSimpleControlTheme = null;
        HashSet<string> _controlExcludes;
        public SimpleControlManager(Theme theme, string controlExcludes = "")
        {
            LoadThemes();
            _currentTheme = theme;
            _controlExcludes = new HashSet<string>(controlExcludes.Split(','));
        }
        private void LoadThemes()
        {
            ISimpleControlTheme darkTheme = new SimpleControlTheme(Theme.Dark);
            SimpleControlColor defaultControl = new SimpleControlColor(Color.FromArgb(55, 55, 55), Color.WhiteSmoke);
            darkTheme.AddControl("default", defaultControl);
            darkTheme.AddControl("Button", new SimpleControlColor(Color.FromArgb(0, 128, 255), Color.White));
            darkTheme.AddControl("TextBox", new SimpleControlColor(Color.WhiteSmoke, Color.Black));
            _themes.Add(Theme.Dark, darkTheme);
            _currentSimpleControlTheme = darkTheme;
        }
        public void ApplyTheme(Control c, Theme theme = Theme.Dark)
        {
            var controlName = c.GetType().Name;
            if (!_themes.ContainsKey(theme) || _currentTheme == Theme.None || _controlExcludes.Contains(controlName))
                return;

            var currentSimpleControlTheme  = _currentSimpleControlTheme.GetControl(controlName) ?? _currentSimpleControlTheme.GetControl("default");
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

        public Theme GetTheme()
        {
            return _currentTheme;
        }

        public void ApplyThemeAll(Control parentControl, Theme theme = Theme.Dark)
        {
            ApplyTheme(parentControl);

            foreach (Control control in parentControl.Controls)
            {
                ApplyTheme(control);
                ApplyThemeAll(control);
            }
        }
    }
}
