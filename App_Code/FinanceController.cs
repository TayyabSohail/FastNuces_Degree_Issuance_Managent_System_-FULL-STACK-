using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class FinanceTokenDeg
{
    public string Token_id { get; set; }
    public string form_id { get; set; }
    public string fyp_decision { get; set; }
    public string finance_decision { get; set; }
    public string fyp_comment { get; set; }
    public string finance_comment { get; set; }
}
//Pay_id, user_id, status, type, Total_Amount, Paid_Amount
public class FinancePayment
{
    public string Pay_id { get; set; }
    public string user_id { get; set; }
    public string status { get; set; }
    public string type { get; set; }
    public string Total_Amount { get; set; }
    public string Paid_Amount { get; set; }
}

public class FinanceTrackTime
{
    public string Token_id { get; set; }
    public DateTime Starting_time { get; set; }
    public DateTime Estimated_time { get; set; }
    public DateTime Generation_date { get; set; }
    public DateTime Fyp_time { get; set; }
}

public class FinanceController
{
    private static readonly FinanceController instance = new FinanceController();
    private readonly string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

    private FinanceController() { }

    public static FinanceController GetFinanceInstance()
    {
        return instance;
    }

    

    public static FinanceController GetFinancePaymentInstance()
    {
        return instance;
    }

    

    public List<TokenDeg> GetFinanceTokenDegList()
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



    public List<FinancePayment> GetFinancePaymentList(string selectedTokenID)
    {
        List<FinancePayment> FinancePaymentList = new List<FinancePayment>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Payment WHERE user_id IN (SELECT user_id FROM TokenDeg WHERE Token_id = @selectedTokenID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@selectedTokenID", selectedTokenID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FinancePayment FinancePayment = new FinancePayment
                    {
                        Pay_id = reader["Pay_id"].ToString(),
                        user_id = reader["user_id"].ToString(),
                        status = reader["status"].ToString(),
                        type = reader["type"].ToString(),
                        Total_Amount = reader["Total_Amount"].ToString(),
                        Paid_Amount = reader["Paid_Amount"].ToString()
                    };
                    FinancePaymentList.Add(FinancePayment);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching FinancePayment data: " + ex.Message);
            }
        }

        // Print statement to check if FinancePayment data is fetched
        Console.WriteLine("FinancePayment data fetched successfully.");

        return FinancePaymentList;
    }

    public FinanceTokenDeg GetTokenDetails(string tokenID)
    {
        FinanceTokenDeg tokenDetails = null;

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
                    tokenDetails = new FinanceTokenDeg
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









    public void UpdateFinanceTokenDegDecision(string tokenID, string decision, string comment)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE TokenDeg SET finance_decision = @decision, finance_comment = @comment WHERE Token_id = @tokenID";

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
