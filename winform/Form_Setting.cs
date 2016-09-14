using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform
{
    public partial class Form_Setting : Form
    {
        Form_main NewMain;
        public Form_Setting(Form_main Main)
        {
            InitializeComponent();

            numericUpDown_Row.Value = Main.nROW;
            numericUpDown_Col.Value = Main.nCOL;
            numericUpDown_Mine.Value = Main.nMINE;
            NewMain = Main;

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            NewMain.nROW = Convert.ToInt32(numericUpDown_Row.Value);
            NewMain.nCOL = Convert.ToInt32(numericUpDown_Col.Value);
            NewMain.nMINE = Convert.ToInt32(numericUpDown_Mine.Value);
            this.Close();
        }
    }
}
