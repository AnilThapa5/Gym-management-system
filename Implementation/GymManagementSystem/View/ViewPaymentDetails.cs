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
    public partial class ViewPaymentDetails : Form
    {
        public ViewPaymentDetails()
        {
            InitializeComponent();
        }

        private void ViewPaymentDetails_Load(object sender, EventArgs e)
        {
            PaymentController Pc = new PaymentController();
            Pc.showpayment(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (command.ToLower() == "delete")
            {
                try
                {

                    string query = "delete from [tbl_payment] where id='" + id + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("successfully Deleted");
                    PaymentController Pc = new PaymentController();
                    Pc.showpayment(dataGridView1);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (command.ToLower() == "edit")
            {

                try
                {
                    string query = "select * from [tbl_payment] where id=" + id;
                    SQLConnection con = new SQLConnection();
                    DataTable dt = con.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        PaymentC p = new PaymentC();
                        p.id = (int)(dt.Rows[0]["id"]);
                        p.price = (int)dt.Rows[0]["price"];
                        p.duration = (string)dt.Rows[0]["duration"];
                        p.dueamt = (string)dt.Rows[0]["due_amt"];
                        p.payment_date = (DateTime)dt.Rows[0]["payment_date"];
                        //View.PaymentForm pf =new PaymentForm(p);
                        //pf.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
