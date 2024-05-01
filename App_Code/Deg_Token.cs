using Microsoft.SqlServer.Server;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Token
/// </summary>
public class Deg_Token
{

    private string Token_id;
    private string form_id;
    private string fyp_decision;
    private string finance_decision;
    private string fyp_comment;
    private string finance_comment;

    private string starting_time;
    private string estimated_time;
    private string generation_date;
    private string fyp_time;
    private string finance_time;
    

    public Deg_Token()
    {


      Token_id= "";
      form_id = "";
     fyp_decision= "";
     finance_decision = "";
     fyp_comment = "";
     finance_comment = "";

     starting_time = "";
     estimated_time = "";
     generation_date = "";
     fyp_time = "";
     finance_time = "";  

}



public int update_main_bar()  // this function is to update the main activity bar 
    {
        int row_count = 0;
        this.checktoken_existance();
        
        if (this.Token_id == "")
        {
            row_count = 1;
        }
        else
        {
            if (this.fyp_decision == "pending" || this.finance_decision == "pending")
            {
                row_count = 2;
            }
            else if (this.fyp_decision == "accepted" && this.finance_decision == "accepted")
            {
                row_count = 3;
            }
        }


        return row_count;


    }


    public int update_fyp_bar()  // this function is to update the main activity bar 
    {
        int row_count = 0;
        this.checktoken_existance();

        if (this.Token_id == "")
        {
            row_count = 1;
        }
        else
        {
            if (this.fyp_decision == "pending" )
            {
                row_count = 2;
            }
            else if (this.fyp_decision == "accepted" )
            {
                row_count = 3;
            }
        }


        return row_count;


    }


    public int update_finance_bar()  // this function is to update the main activity bar 
    {
        int row_count = 0;
        this.checktoken_existance();

        if (this.Token_id == "")
        {
            row_count = 1;
        }
        else
        {
            if (this.finance_decision == "pending")
            {
                row_count = 2;
            }
            else if (this.finance_decision == "accepted")
            {
                row_count = 3;
            }
        }


        return row_count;


    }

    public void checktoken_existance()
    {
       
            string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
            string query = @"SELECT * FROM TokenDeg WHERE form_id = @FormId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FormId", this.form_id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                    this.Token_id = reader["Token_id"].ToString();
                    this.form_id = reader["form_id"].ToString();
                    this.fyp_decision = reader["fyp_decision"].ToString();
                    this.finance_decision = reader["finance_decision"].ToString();
                    this.fyp_comment = reader["fyp_comment"].ToString();
                    this.finance_comment = reader["finance_comment"].ToString();
                    }
                }

                reader.Close();
            }

            
        }

    public void setformid(string id)
    {
        this.form_id = id;
    }



    public string TokenId
    {
        get { return Token_id; }
        set { Token_id = value; }
    }

    public string FormId
    {
        get { return form_id; }
        set { form_id = value; }
    }

    public string FypDecision
    {
        get { return fyp_decision; }
        set { fyp_decision = value; }
    }

    public string FinanceDecision
    {
        get { return finance_decision; }
        set { finance_decision = value; }
    }

    public string FypComment
    {
        get { return fyp_comment; }
        set { fyp_comment = value; }
    }

    public string FinanceComment
    {
        get { return finance_comment; }
        set { finance_comment = value; }
    }








    public Tuple<string, string> CalculateAverageTimes()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        TimeSpan fypTotal = TimeSpan.Zero;
        TimeSpan financeTotal = TimeSpan.Zero;
        TimeSpan starting_Time = TimeSpan.Zero;
        int count = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT starting_time, fyp_time, finance_time FROM Token_DateTime";
            
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Get FYP time and finance time from the database
                    TimeSpan fypTime = (TimeSpan)reader["fyp_time"];
                    TimeSpan financeTime = (TimeSpan)reader["finance_time"];
                    starting_Time = (TimeSpan)reader["starting_time"];
                    // Calculate running total of FYP time and finance time
                    fypTime -= starting_Time;
                    financeTime -= starting_Time;

                    fypTotal += fypTime;
                    financeTotal += financeTime;
                    count++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while calculating average times: " + ex.Message);
            }
        }

        if (count > 0)
        {
            TimeSpan fypAverage = TimeSpan.FromMinutes(fypTotal.TotalMinutes / count);
            TimeSpan financeAverage = TimeSpan.FromMinutes(financeTotal.TotalMinutes / count);

            // Convert average TimeSpan values to readable format
            string fypAverageString = FormatTimeSpan(fypAverage);
            string financeAverageString = FormatTimeSpan(financeAverage);

            return Tuple.Create(fypAverageString, financeAverageString);
        }
        else
        {
            
            return Tuple.Create("0 minutes", "0 minutes");
        }


    }


    private string FormatTimeSpan(TimeSpan timeSpan)
    {
        
        int totalMinutes = (int)Math.Round(timeSpan.TotalMinutes);

          if (totalMinutes < 0)
        {
            totalMinutes *= -1;
        }
        string formattedTime = totalMinutes + " min";

        return formattedTime;
    }


}


