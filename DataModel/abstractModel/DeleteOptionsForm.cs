using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WinForm_Dialogs
{
    public enum UserOption  {
        Option1 = 1,
        Option2 = 2,
        Cancel = 0
    };

    public partial class DeleteOptionsForm : Form
    {
        private UserOption option = UserOption.Cancel;

        

        public UserOption GetUserOption
        {
            get { return option; }
            set { option = value; }
        }

        public DeleteOptionsForm()
        {
            InitializeComponent();
        }

        public DeleteOptionsForm(String Title, string Option1, string Option2)
        {
            InitializeComponent();
            this.Text = Title;
            this.lbTitle.Text = Title;
            this.lbOption1.Text = Option1;
            this.lbOption2.Text = Option2;
        }


        private void btnChoose1_Click(object sender, EventArgs e)
        {
            option = UserOption.Option1;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            option = UserOption.Cancel;
            this.Close();
        }

        private void btnChoose2_Click(object sender, EventArgs e)
        {
            option = UserOption.Option2;
            this.Close();
        }

        private void DeleteOptionsForm_Load(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
        }
    }
}
