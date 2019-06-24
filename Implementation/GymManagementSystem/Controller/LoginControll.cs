using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.View;
using System.Windows.Forms;
using System.Data;
namespace GymManagementSystem.Controller
{
     public class LoginControll
    {
        
        public void logctrl(string uname,string pass)
            {

            try
            {
                if (uname == "")
                {
                    MessageBox.Show("Please enter the UserName");
                   
                }

                else if (pass == "")
                {
                    MessageBox.Show("Please enter the Password");
                }
                else 
                { 
                    string query = "select * from [tbl_user] where username='" + uname + "' and password='" + pass + "'";
                    SQLConnection db = new SQLConnection();
                    DataTable dt = db.GetData(query);
                    if (dt.Rows.Count > 0)
                    {

                        LoginForm lf = new LoginForm();
                        lf.Close();
                        DashBoard dbs = new DashBoard();
                        dbs.user_id = Convert.ToInt32(dt.Rows[0]["user_id"]);
                        dbs.Show();

                    }
                    else
                    {
                        MessageBox.Show("Either UserName or Password Incorrect ???");
                    }
              
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            }
        public void sign(string signup)
        {
            UserRegistrationForm urf = new UserRegistrationForm(null);
            urf.Show();
        }

    }
}
