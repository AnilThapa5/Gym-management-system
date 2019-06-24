using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace GymManagementSystem
{
    public class SQLConnection
    {
            SqlConnection con;

            public SQLConnection()
            {
                con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=GymManagementSystem; Integrated Security=True;");
            }

            public int Executequery(string query)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }

            public DataTable GetData(string query)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables.Count > 0)
                        return ds.Tables[0];
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
             }
         }
       }
