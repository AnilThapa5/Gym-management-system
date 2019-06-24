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
    public partial class AddCustomer : Form
    {
        public int id = 0;

        Customer c = new Customer();
        public AddCustomer(Customer cus)
        {
            c = cus;
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtcname.Clear();
            txtcphone.Clear();
            txtcemail.Clear();
            txtadd.Clear();
            
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            
            string cname = txtcname.Text;
            string cphone = txtcphone.Text;
            string email = txtcemail.Text;
            string address = txtadd.Text;
            string assign_trainer = cmbtrainer.Text;
            DateTime dob= Convert.ToDateTime(dateTimePicker1.Value);
            
            AddCustomerController acc = new AddCustomerController();
            acc.Addcustsave(cname,cphone,email,address,dob,id,assign_trainer,c);
            if(c!=null)
            {
                this.Close();
                AddCustomer ac = new AddCustomer(null);
                ac.Show();
            }

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {


            if (c != null)
            {
                txtcname.Text = c.cname;
                txtcemail.Text = c.cemail;
                txtcphone.Text = c.cphone;
                txtadd.Text = c.address;
                cmbtrainer.Text = (c.assigned_trainer);
                dateTimePicker1.Text = Convert.ToString(c.dob);

            }


            try
            {
                string query = "Select * from[tbl_trainer]";
                SQLConnection con = new SQLConnection();
                DataTable dt = con.GetData(query);
                cmbtrainer.ValueMember = "id";
                cmbtrainer.DisplayMember = "trainer_name";
                cmbtrainer.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           

        }
    }
}
