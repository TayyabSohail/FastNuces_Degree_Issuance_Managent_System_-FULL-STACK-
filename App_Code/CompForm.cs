using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for CompForm
/// </summary>
public class CompForm : Forms
{

 
    private string complaint;
  
  
  
    public CompForm()
    {
        this.assign_ID();
    }


    public bool registercomplaint(string name,string  date, string complaint)
    {
        this.submission_date= date;
        this.complaint = complaint;
        this.name = name;
        bool valid = validation();
        bool success = false;
        if (valid)
        {
             success = this.insert_comp_db();
              if (success)
              {
                return true;
              }
            else
             {
                return false;
                 
             }
        }
        else
        {
            return false;
        }

       
    }

    private bool validation()
    {

            if (string.IsNullOrWhiteSpace(this.form_id) || string.IsNullOrWhiteSpace(this.user_id) ||
                string.IsNullOrWhiteSpace(this.name) || string.IsNullOrWhiteSpace(this.complaint) 
               )
            {
                return false;
            }

        if (!DateTime.TryParseExact(this.submission_date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return false;
        }

        return true;
        
    }
    public void assign_ID()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM complaint_form";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int rowCount = (int)command.ExecuteScalar();

                if (rowCount == 0)
                {
                    // If there are no entries in the table, assign form_id as "DEG_01"
                    this.form_id = "COM_01";
                }
                else
                {
                    // If there are entries in the table, retrieve the latest form_id and generate the next one
                    query = "SELECT TOP 1 form_id FROM complaint_form ORDER BY form_id DESC";
                    command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string latestFormId = reader.GetString(0);
                        string separator = latestFormId.Substring(4);
                        int uniqueNum = int.Parse(separator) + 1;
                        this.form_id = (uniqueNum <= 9) ? "COM_0" + uniqueNum : "COM_" + uniqueNum;
                    }
                    reader.Close();
                }

                Console.WriteLine($"Form id: {this.form_id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while assigning the form id: " + ex.Message);
            }
        }
    }

    private bool insert_comp_db()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = @"INSERT INTO complaint_form 
                (form_id, [name], [description], submission_date, [user_id]) 
                VALUES 
                (@FormId, @Name, @Description, @SubmissionDate, @UserId)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

          
            command.Parameters.AddWithValue("@FormId", this.form_id);
            command.Parameters.AddWithValue("@Name", this.name);
            command.Parameters.AddWithValue("@Description", this.complaint);
            command.Parameters.AddWithValue("@SubmissionDate", this.submission_date);
            command.Parameters.AddWithValue("@UserId", this.user_id);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
             
                return false;
            }
        }

    }
}