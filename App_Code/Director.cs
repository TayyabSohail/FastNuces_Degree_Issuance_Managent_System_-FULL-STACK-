using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

/// <summary>
/// Summary description for Director
/// </summary>
public class Director
{

    private string user_id;
    private string name;
    private string password;
    Deg_Token Token; 
    
    public Director()
    {
        
        Token = new Deg_Token();
    }

    public Deg_Token GetDeg_Token()
    {
        return Token;
    }
    public string GetPassword()
    {
        return password;
    }

    public void SetPassword(string value)
    {
        password = value;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string value)
    {
        name = value;
    }


    public string GetUserId()
    {
        return user_id;
    }

    public void SetUserId(string value)
    {
        user_id = value;
    }
    public void fetch_info(string u)
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = "SELECT * FROM users WHERE user_id = @userId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", u);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.user_id = reader["user_id"].ToString();
                        this.name = reader["name"].ToString();
                        this.password = reader["password"].ToString();


                    }
                }
                else
                {
                    // Console.WriteLine("No data found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }



    public List<Deg_Token> GetAllEntries()
    {
        List<Deg_Token> entries = new List<Deg_Token>();
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
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
                    Deg_Token entry = new Deg_Token();
                    {
                        entry.TokenId = reader["Token_id"].ToString();
                        entry.FormId = reader["form_id"].ToString();
                        entry.FypDecision = reader["fyp_decision"].ToString();
                        entry.FinanceDecision = reader["finance_decision"].ToString();
                        entry.FypComment = reader["fyp_comment"].ToString();
                        entry.FinanceComment = reader["finance_comment"].ToString();
                    };
                    entries.Add(entry);
                }

                reader.Close();

                // Check if entries list is empty
                if (entries.Count == 0)
                {
                    return null; // Return null if no entries found
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return entries;
    }



    public List<Deg_Token> ViewAllRequests()
    {
        List<Deg_Token> all_requests = this.GetAllEntries();

        return all_requests;
      

    }





    public List<Deg_Token> GetEntriesByGenerationDate(string generationDate)
    {
        List<Deg_Token> entries = new List<Deg_Token>();
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // First, retrieve TokenIds based on generation date
            string tokenIdQuery = "SELECT Token_id FROM Token_DateTime WHERE generation_date = @GenerationDate";
            SqlCommand tokenIdCommand = new SqlCommand(tokenIdQuery, connection);
            tokenIdCommand.Parameters.AddWithValue("@GenerationDate", DateTime.Parse(generationDate));

            try
            {
                connection.Open();
                SqlDataReader tokenIdReader = tokenIdCommand.ExecuteReader();

                // List to store retrieved TokenIds
                List<string> tokenIds = new List<string>();

                while (tokenIdReader.Read())
                {
                    string tokenId = tokenIdReader["Token_id"].ToString();
                    tokenIds.Add(tokenId);
                }

                tokenIdReader.Close();

                // If no TokenIds found for the given generation date, return null
                if (tokenIds.Count == 0)
                {
                    return null;
                }

                // Now fetch token information using retrieved TokenIds
                foreach (string tokenId in tokenIds)
                {
                    string query = "SELECT * FROM TokenDeg WHERE Token_id = @TokenId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TokenId", tokenId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Deg_Token entry = new Deg_Token();
                        {
                            entry.TokenId = reader["Token_id"].ToString();
                            entry.FormId = reader["form_id"].ToString();
                            entry.FypDecision = reader["fyp_decision"].ToString();
                            entry.FinanceDecision = reader["finance_decision"].ToString();
                            entry.FypComment = reader["fyp_comment"].ToString();
                            entry.FinanceComment = reader["finance_comment"].ToString();
                        };
                        entries.Add(entry);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return entries;
    }




}