using System.Windows.Forms;

namespace SimpleSkin
{
    public interface ISimpleControlManager
    {
        Theme GetTheme();
        void ApplyTheme(Control c, Theme theme = Theme.Dark);
        void ApplyThemeAll(Control c, Theme theme = Theme.Dark);
    }
}
