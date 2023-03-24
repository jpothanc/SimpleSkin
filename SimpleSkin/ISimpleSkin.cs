using System.Windows.Forms;

namespace SimpleSkin
{
    public interface ISimpleSkin
    {
      //  ISimpleSkin Create();
        ISimpleSkin SetSkin(Skin skin);
        ISimpleSkin SetControlExcludes(string controlNames);
        void Apply(Control c, Skin skin = Skin.Dark);
        void ApplyAll(Control c, Skin skin = Skin.Dark);
        Skin GetSkin();

    }
}
