using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem.View
{
    public partial class DashBoard : Form
    {
        public int user_id = 0;
        public DashBoard()
        {
            InitializeComponent();
        }


        private void openFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer ac = new AddCustomer(null);
            ac.id = this.user_id;
            ac.Show();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            txttotalcustomer.ReadOnly = true;
            textBox1.ReadOnly = true;
            try
            {
                string query = "select count(*) as 'Count' from [tbl_customer]";
                SQLConnection db = new SQLConnection();
                DataTable dt = db.GetData(query);
                string a = Convert.ToString(dt.Rows[0]["Count"]);

                txttotalcustomer.Text = a;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string q = "select count(*) as 'dueleft' from [tbl_payment]";
                SQLConnection con = new SQLConnection();
                DataTable dt = con.GetData(q);
                string b = Convert.ToString(dt.Rows[0]["dueleft"]);
                textBox1.Text = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            try
            {
                string query1 = "select c_name,c_email,c_address,dob,assigned_trainer from [tbl_customer] ";
                SQLConnection con = new SQLConnection();
                DataTable dtt = con.GetData(query1);
                if (dtt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtt;
                }  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string q2 = "select * from [tbl_trainer]";
                SQLConnection con = new SQLConnection();
                DataTable dt = con.GetData(q2);
                cmbttrainer.ValueMember = "id";
                cmbttrainer.DisplayMember = "trainer_name";
                cmbttrainer.DataSource = dt;
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            }
        

       
        private void openFormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PaymentForm pf = new PaymentForm();
            pf.Show();
        }

        private void openFormToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddTrainer at = new AddTrainer(null);
            at.id = this.user_id;
            at.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ViewCustomerDetails vcd = new ViewCustomerDetails();
            vcd.id = this.user_id;
            vcd.Show();
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewPaymentDetails vpd = new ViewPaymentDetails();
            vpd.Show();
        }

        private void viewTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTrainerDetails vtd = new ViewTrainerDetails();
            vtd.id = this.user_id;
            vtd.Show();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUserDetails vud = new ViewUserDetails();
            vud.id = this.user_id;
            vud.Show();
        }

        private void oPENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Show();
        }
    }
}
