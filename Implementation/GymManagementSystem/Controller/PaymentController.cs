using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagementSystem.View;
using System.Data;
using GymManagementSystem.Model;

namespace GymManagementSystem.Controller
{
    public class PaymentController
    {
        public void pay(string email,int price,string duration,string dueamt,DateTime payment_date,int cid,PaymentC pa)
        {
            try
            {
                if (email == "")
                {
                    MessageBox.Show("email cannot be blank ");
                }
                else if(!GYMValidations.checkcemail(email) && pa!=null)
                {
                    MessageBox.Show("Email can be matched with Customer Email paying Bill");
                }
                else if (duration == "")
                {
                    MessageBox.Show("Please fill the Duration");
                }
                else if (dueamt == "")
                {
                    MessageBox.Show("Please tick the Due YES or NO");
                }
                else if(pa!=null)
                {

                    string query = "update [tbl_payment] set price='" + price + "',duration='" + duration
                            + "',due_amt='" + dueamt + "',cust_id='" + cid + "',payment_date='" + payment_date
                            + "',email='" + email + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("Updated Successfully");
                }
                else
                {
                    string query = "insert into [tbl_payment] values('" + price + "','" + duration + "','" + dueamt
                        + "','" + cid + "','" + payment_date + "','" + email + "')";
                    SQLConnection db = new SQLConnection();
                    db.Executequery(query);
                    MessageBox.Show("Payment inserted successfully");
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void showpayment(DataGridView dgv)
        {
            try
            {
                string query = "select * from [tbl_payment]";
                SQLConnection con = new SQLConnection();
                DataTable dt = con.GetData(query);
                dgv.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
