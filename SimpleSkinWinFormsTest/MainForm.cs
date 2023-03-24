using SimpleSkin;
using System;
using System.Windows.Forms;

namespace SimpleSkinWinFormsTest
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplySkin();
        }

        private void ApplySkin()
        {
            var simpleSkin = SimpleSkin.SimpleSkin.Create(x =>
            {
                x.Skin = Skin.Dark;
                x.ControlExcludes = "ComboBox";
            });

            simpleSkin.ApplyAll(this);
        }
    }
}
