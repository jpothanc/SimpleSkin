using SimpleSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSkinWinFormsTest
{
    public partial class MainForm : Form
    {
        ISimpleControlManager _simpleControlManager = null;

        public MainForm()
        {
            InitializeComponent();
            _simpleControlManager = new SimpleControlManager(Theme.Dark);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            _simpleControlManager.ApplyThemeAll(this);
            //ApplyTheme(this);

        }

        private void ApplyTheme(Control parentControl)
        {
            
            _simpleControlManager.ApplyTheme(parentControl);

            foreach (Control control in parentControl.Controls)
            {
                _simpleControlManager.ApplyTheme(control);
                ApplyTheme(control);
            }
              
        }
    }
}
