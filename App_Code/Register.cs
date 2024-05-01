using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Register
/// </summary>
public class Register
{
    public Register()
    {
        
    }



    public bool check_login(string username , string password)
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = "SELECT COUNT(*) FROM users WHERE user_id = @Username AND password = @Password";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                int  count = (int)command.ExecuteScalar();
                 if (count >0)
                {
                    return true;
                }
                 else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}