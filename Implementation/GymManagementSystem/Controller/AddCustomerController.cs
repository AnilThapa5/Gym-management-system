using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.View;
using System.Windows.Forms;
using GymManagementSystem.Model;
using System.Data;
namespace GymManagementSystem.Controller
{
    public class AddCustomerController
    {

        public void Addcustsave(string txtcname, string txtcphone, string email, string txtadd, DateTime dob,
            int id, string assign_trainer,Customer c)
        {
            try
            {


                if (txtcname == "")
                {
                    MessageBox.Show("Name cannot be Empty");
                }
                else if (email == "")
                {
                    MessageBox.Show("Email cannot be Empty");
                }
                else if (GYMValidations.checkduplicateemail(email)&& c==null)
                {
                    MessageBox.Show("Email already Exists");
                }
                else if (!GYMValidations.checkemail(email))
                {
                    MessageBox.Show(" Email must contain abc....@gmail.com");
                }
                else if (txtcphone == "")
                {
                    MessageBox.Show("Phone Number cannot be Empty");
                }
               

                else if (txtadd == "")
                {
                    MessageBox.Show("Address cannot be Empty");
                }

                else if (GYMValidations.checkdob(dob))
                {
                    MessageBox.Show("Date Of Birth is Today  ???");
                }

                else if (c != null)
                {
                    string query = "update [tbl_customer] set c_name='" + txtcname + "',c_email='" + email
                        + "',c_phone='" + txtcphone + "',c_address='" + txtadd + "',user_id='" + id
                        + "',dob='" + dob + "',assigned_trainer='" + assign_trainer + "' where cust_id='" + c.cust_id + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("Updated successfully");
                    
                }
                else
                {
                    string query = "insert into [tbl_customer] values('" + txtcname + "','" + email + "','" + txtcphone
                        + "','" + txtadd + "','" + id + "','" + dob + "','" + assign_trainer + "')";
                    SQLConnection db = new SQLConnection();
                    db.Executequery(query);
                    MessageBox.Show("Successfully Inserted");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            public void showcustomer(DataGridView dgv)
        {
            try
            {
                string query = "select * from [tbl_customer]";
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
    

