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
    public partial class ViewCustomerDetails : Form
    {
        //public DataGridView dgv {get; set;}
        public int id = 0;
        public ViewCustomerDetails()
        {
            InitializeComponent();
        }

        private void ViewCustomerDetails_Load(object sender, EventArgs e)
        {
           
            AddCustomerController acc = new AddCustomerController();
            acc.showcustomer(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (command.ToLower() == "delete")
            {
                try
                {
                    string deletequery = "delete from [tbl_customer] where cust_id=" + id;
                    SQLConnection con = new SQLConnection();
                    con.Executequery(deletequery);
                    MessageBox.Show("successfully Deleted");
                    AddCustomerController acc = new AddCustomerController();
                    acc.showcustomer(dataGridView1);
                   
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
                    string query = "select * from[tbl_customer] where cust_id=" + id;
                    SQLConnection con = new SQLConnection();
                    DataTable dt = con.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        Customer c = new Customer();
                        c.cust_id = (int)(dt.Rows[0]["cust_id"]);
                        c.cname = (string)dt.Rows[0]["c_name"];
                        c.cemail = (string)dt.Rows[0]["c_email"];
                        c.cphone = (string)dt.Rows[0]["c_phone"];
                        c.address = (string)dt.Rows[0]["c_address"];
                        c.dob = (DateTime)dt.Rows[0]["dob"];
                        c.assigned_trainer = (string)dt.Rows[0]["assigned_trainer"];

                        AddCustomer ad = new AddCustomer(c);
                        ad.id = this.id;
                        ad.Show();
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

