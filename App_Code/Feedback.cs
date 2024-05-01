
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{

    private string feed_ID;
    private string deg_Tokenid;
    private string comment;
    private string user_ID;
    private string submission_date;

    public Feedback()
    {
        feed_ID = "";
        deg_Tokenid = "";
        comment = "";
        user_ID = "";
        submission_date = "";


        
    }

    public void set_userid(string value)
    {
           this.user_ID = value;
    }

    public void set_comment(string value)
    {
        this.comment = value;
    }

    public void set_submission_date(string value)
    {
        this.submission_date = value;
    }

    public void set_token_id(string value)
    {
        this.deg_Tokenid= value;
    }

    public string get_tokenid()
    {
        return this.deg_Tokenid;
    }


    public string get_userid()
    {
        return this.user_ID;
    }

    public string get_comment()
    {
        return this.comment;
    }

    public string get_submission_date()
    {
        return this.submission_date;
    }

    public bool register_feedback_form(string date, string comment)
    {
        this.submission_date = date;
        this.comment = comment;
        
        bool valid = validation();
        bool success = false;
        if (valid)
        {
            success = this.insert_feedback_db();
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

        if (string.IsNullOrWhiteSpace(this.feed_ID) || string.IsNullOrWhiteSpace(this.user_ID) ||
             string.IsNullOrWhiteSpace(this.comment)
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
            string query = "SELECT COUNT(*) FROM feedback";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int rowCount = (int)command.ExecuteScalar();

                if (rowCount == 0)
                {
                    // If there are no entries in the table, assign form_id as "DEG_01"
                    this.feed_ID = "FEE_01";
                }
                else
                {
                    // If there are entries in the table, retrieve the latest form_id and generate the next one
                    query = "SELECT TOP 1 Feed_ID FROM feedback ORDER BY Feed_ID DESC";
                    command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string latestFormId = reader.GetString(0);
                        string separator = latestFormId.Substring(4);
                        int uniqueNum = int.Parse(separator) + 1;
                        this.feed_ID = (uniqueNum <= 9) ? "FEE_0" + uniqueNum : "FEE_" + uniqueNum;
                    }
                    reader.Close();
                }

                Console.WriteLine($"Form id: {this.feed_ID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while assigning the feedback id: " + ex.Message);
            }
        }
    }

    private bool insert_feedback_db()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = @"INSERT INTO feedback 
                    (Feed_ID, Deg_Tokenid, comment, user_id) 
                    VALUES 
                    (@FeedID, @DegTokenID, @Comment, @UserID)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Assuming you have private variables for Feed_ID, Deg_Tokenid, comment, and user_id
            command.Parameters.AddWithValue("@FeedID", this.feed_ID);
            command.Parameters.AddWithValue("@DegTokenID", this.deg_Tokenid);
            command.Parameters.AddWithValue("@Comment", this.comment);
            command.Parameters.AddWithValue("@UserID", this.user_ID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false;
            }
        }
    }

 }