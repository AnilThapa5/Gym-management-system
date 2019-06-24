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
    public partial class AddTrainer : Form
    {
        public int id = 0;

        Trainer tt = new Trainer();

        
        public AddTrainer(Trainer trai)
        {
            tt = trai;
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string email = txtemail.Text;
            string phone = txtphone.Text;
            string add = txtadd.Text;
    
                
            TrainerController tc = new TrainerController();
            tc.trainercont(name, email, phone, add, id, tt);
            if(tt!=null)
            {

                this.Close();
                AddTrainer at = new AddTrainer(null);
                at.Show();
            }
        }

        private void AddTrainer_Load(object sender, EventArgs e)
        {
            

        }

        private void AddTrainer_Load_1(object sender, EventArgs e)
        {
            if (tt != null)
            {
                txtname.Text = tt.trainer_name;
                txtadd.Text = tt.trainer_address;
                txtphone.Text = tt.trainer_phone;

                txtemail.Text = tt.trainer_email;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtadd.Clear();
            txtphone.Clear();

            txtemail.Clear();
        }
    }
}
