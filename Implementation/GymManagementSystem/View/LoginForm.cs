using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagementSystem.Controller;

namespace GymManagementSystem.View
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string uname = txtuname.Text;
            string pass = txtpass.Text;
            LoginControll lc = new LoginControll();
            lc.logctrl(uname, pass);
        }

        public void btnsignup_Click(object sender, EventArgs e)
        {
            string signup= btnsignup.Text;
            LoginControll lc = new LoginControll();
            lc.sign(signup);
        }
    }
}
