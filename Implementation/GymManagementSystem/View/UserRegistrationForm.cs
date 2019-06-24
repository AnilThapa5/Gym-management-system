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
using GymManagementSystem.Model;


namespace GymManagementSystem.View
{
    public partial class UserRegistrationForm : Form
    {
       
        User u = new User();
        public UserRegistrationForm(User us)
        {
            u = us;
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            string fname = txtfname.Text;
            string lname = txtlname.Text;
            string email = txtemail.Text;
            string usname = txtuname.Text;
            string pass = txtpass.Text;
            
            RegisterControll rc = new RegisterControll();
            rc.registercontrol(fname, email, usname, pass, lname,u);

      

        }

        public void button2_Click(object sender, EventArgs e)
        {
             txtfname.Clear();
             txtemail.Clear();
             txtuname.Clear();
             txtpass.Clear();
             txtlname.Clear();
            
        }

        private void UserRegistrationForm_Load(object sender, EventArgs e)
        {
            if (u !=null)
            {
                txtfname.Text = u.firstname;
                txtlname.Text = u.lastname;
                txtemail.Text = u.email;
                txtuname.Text = u.username;
                txtpass.Text = u.password;
               

            }
        }
    }
}
