using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.Model;
using GymManagementSystem.View;
using System.Windows.Forms;
using System.Data;


namespace GymManagementSystem.Controller
{ 
    public class RegisterControll
{

    public void registercontrol(string fname, string email, string usname, string pass, string lname,User u)
    {
        try
        {

            if (fname=="")
            {
                MessageBox.Show("Username is empty");
                   
            }

            else if (lname == "")
            {
                MessageBox.Show(" Last Name cannot be Empty");

            }
            else if(email=="")
                {
                    MessageBox.Show("Email cannot be Blank");
                }
            else if (!GYMValidations.checkemail(email))
            {
                MessageBox.Show(" Email must contain abc....@gmail.com");
            }
            else if(usname=="")
                {
                    MessageBox.Show("Username cannot be Blank");
                }
            else if (GYMValidations.CheckDuplicateUser(usname) && u==null )
                    {
                        MessageBox.Show(" UserName already Exist");
                    }
                else if (pass == "")
                {
                    MessageBox.Show("Password cannot be Blank");
                }
                else if (!GYMValidations.checkPasswordLength(pass))
                {
                    MessageBox.Show("Password length must be greater than 5");
                }
            //else if(GYMValidations.checkPassworduppercase(pass))
            //   {
            //        MessageBox.Show("Must contains Symbols");
            //    }



                else if (u != null)
                {

                    string query = "update [tbl_user] set name='" + fname + "',email='" + email
                        + "',username='" + usname + "',password='" + pass + "',last_name='" + lname
                        + "' where user_id='" + u.id + "'";
                    SQLConnection con = new SQLConnection();
                    con.Executequery(query);
                    MessageBox.Show("Updated successfully");

                }
                else
                {
                    string query = "insert into [tbl_user] values( '" + fname + "','" + email

                        + "', '" + usname + "', '" + pass + "', '" + lname + "')";
                    SQLConnection db = new SQLConnection();
                    db.Executequery(query);
                    MessageBox.Show("successfully Created");
                    UserRegistrationForm urf = new UserRegistrationForm(null);
                    urf.Close();
                    LoginForm lf = new LoginForm();
                    lf.Show();

                }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
       
        public void viewuserdetails(DataGridView dgv, int id)
        {
            try
            {
                string query = "select * from [tbl_user] where user_id='" + id + "' ";
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

