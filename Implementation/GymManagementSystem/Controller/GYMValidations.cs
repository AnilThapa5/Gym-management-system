using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GymManagementSystem.Controller;


namespace GymManagementSystem.Controller
{
    public class GYMValidations
    {
       // register validation

        public static bool CheckDuplicateUser(string usname)
        {
            string query = "Select * from [tbl_user] where UserName='" + usname + "'";
            SQLConnection sc = new SQLConnection();
            DataTable dtUser = sc.GetData(query);
            if (dtUser.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public static bool checkemail(string email)
        {
            if (email.Contains("@gmail.com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkPasswordLength(string pass)
        {
            if(pass.Length>5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool checkPassworduppercase(string pass)
        //{
        //    if (pass.Contains==uppercase['A-Z']) 
        //        return true;
        //    else
        //        return false;
        //}

        //end 


        //customer validation

        public static bool checkduplicateemail(string txtemail)
        {
            string query = "select * from [tbl_customer] where c_email='" + txtemail + "'";
            SQLConnection con = new SQLConnection();
            DataTable dt = con.GetData(query);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }



     

        public static bool checkdob(DateTime dob)
        {
            if (dob >=DateTime.Today)
                return true;
            else
                return false;
        }


        //end


        //payment validation 
        public static bool checkcemail(string email)
        {
            string query = "select * from [tbl_customer] where c_email='" + email + "'";
            SQLConnection con = new SQLConnection();
            DataTable dt = con.GetData(query);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }



        //end


        //trainer validation


        public static bool checkphonelength(string phone)
        {
            if (phone.Length>=11)
                return true;
            else
                return false;
        }

        public static bool checkduplicatephone(string phone)
        {
            string quer = "select * from[tbl_trainer] where trainer_phone='" + phone + "' ";
            SQLConnection con = new SQLConnection();
            DataTable dt = con.GetData(quer);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //public static bool checkcharacter(string phone)
        //{
        //    if (phone.Contains("numeric"))
        //        return true;
        //    else
        //        return false;
        //}


        //end
    }
}
