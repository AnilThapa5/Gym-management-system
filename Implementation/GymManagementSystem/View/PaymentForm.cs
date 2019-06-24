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
    public partial class PaymentForm : Form
    {
        PaymentC pa = new PaymentC();
        public PaymentForm(/*PaymentC p*/)
        {
            pa = p;
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            int price =Convert.ToInt32( txtprice.Text);
            string duration = cmbduration.Text;
            string dueamt =chkdueamt.Text;
            DateTime payment_date = dateTimePicker1.Value;
            int cid = Convert.ToInt32(cmbcid.Text);
            
            PaymentController pc = new PaymentController();
            pc.pay(email, price, duration, dueamt, payment_date, cid,pa);

            if (pa != null)
            {
               this.Close();
               PaymentForm p = new PaymentForm(pa);
               p.Show();
            }


        }
        private void Payment_Load(object sender, EventArgs e)
        {
            if(pa!=null)
            {
                txtemail.Text = pa.email;
                txtprice.Text = Convert.ToString(pa.price);
                cmbduration.Text = pa.duration;
                chkdueamt.Text = pa.dueamt;
                dateTimePicker1.Text =Convert.ToString(pa.payment_date);
                cmbcid.Text =Convert.ToString(pa.cust_id);
            }

            try
            {
                string qury = "select max(cust_id) as 'max_id' from [tbl_customer]";
                SQLConnection db = new SQLConnection();
                DataTable dt = db.GetData(qury);
                cmbcid.ValueMember = "id";
                cmbcid.DisplayMember = "max_id";
                cmbcid.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtemail.Clear();
            txtprice.Clear();
            chkdueamt.ClearSelected();
            
        }
    }
}
