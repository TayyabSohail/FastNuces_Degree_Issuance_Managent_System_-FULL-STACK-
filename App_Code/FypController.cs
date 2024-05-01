using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class TokenDeg
{
    public string Token_id { get; set; }
    public string form_id { get; set; }
    public string fyp_decision { get; set; }
    public string finance_decision { get; set; }
    public string fyp_comment { get; set; }
    public string finance_comment { get; set; }
}

public class TrackTime
{
    public string Token_id { get; set; }
    public DateTime Starting_time { get; set; }
    public DateTime Estimated_time { get; set; }
    public DateTime Generation_date { get; set; }
    public DateTime Fyp_time { get; set; }
}

public class FypController
{
    private static readonly FypController instance = new FypController();
    private readonly string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

    private FypController() { }

    
    public static FypController GetInstance()
    {
        return instance;
    }

    public List<TokenDeg> GetTokenDegList()
    {
        List<TokenDeg> tokenDegList = new List<TokenDeg>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM TokenDeg";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TokenDeg tokenDeg = new TokenDeg
                    {
                        Token_id = reader["Token_id"].ToString(),
                        form_id = reader["form_id"].ToString(),
                        fyp_decision = reader["fyp_decision"].ToString(),
                        finance_decision = reader["finance_decision"].ToString(),
                        fyp_comment = reader["fyp_comment"].ToString(),
                        finance_comment = reader["finance_comment"].ToString()
                    };

                    tokenDegList.Add(tokenDeg);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching TokenDeg data: " + ex.Message);
            }
        }

        // Print statement to check if TokenDeg data is fetched
        Console.WriteLine("TokenDeg data fetched successfully.");

        return tokenDegList;
    }

    public List<TrackTime> GetTrackTimeList()
    {
        List<TrackTime> trackTimeList = new List<TrackTime>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Token_id, Starting_time, Estimated_time, Generation_date, Fyp_time FROM TrackTime";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TrackTime trackTime = new TrackTime
                    {
                        Token_id = reader["Token_id"].ToString(),
                        Starting_time = Convert.ToDateTime(reader["Starting_time"]),
                        Estimated_time = Convert.ToDateTime(reader["Estimated_time"]),
                        Generation_date = Convert.ToDateTime(reader["Generation_date"]),
                        Fyp_time = Convert.ToDateTime(reader["Fyp_time"])
                    };

                    trackTimeList.Add(trackTime);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching TrackTime data: " + ex.Message);
            }
        }

        // Print statement to check if TrackTime data is fetched
        Console.WriteLine("TrackTime data fetched successfully.");

        return trackTimeList;
    }

    public TokenDeg GetTokenDetails(string tokenID)
    {
        TokenDeg tokenDetails = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM TokenDeg WHERE Token_id = @tokenID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tokenID", tokenID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    tokenDetails = new TokenDeg
                    {
                        Token_id = reader["Token_id"].ToString(),
                        form_id = reader["form_id"].ToString(),
                        fyp_decision = reader["fyp_decision"].ToString(),
                        finance_decision = reader["finance_decision"].ToString(),
                        fyp_comment = reader["fyp_comment"].ToString(),
                        finance_comment = reader["finance_comment"].ToString()
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching token details: " + ex.Message);
            }
        }

        return tokenDetails;
    }


    public void UpdateTokenDegDecision(string tokenID, string decision, string comment)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE TokenDeg SET fyp_decision = @decision, fyp_comment = @comment WHERE Token_id = @tokenID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@decision", SqlDbType.VarChar).Value = decision;
            command.Parameters.Add("@comment", SqlDbType.VarChar).Value = comment;
            command.Parameters.Add("@tokenID", SqlDbType.VarChar).Value = tokenID;

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Rows affected: " + rowsAffected);
                }
                else
                {
                    Console.WriteLine("No rows affected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating TokenDeg data: " + ex.Message);
            }
        }
    }


}
