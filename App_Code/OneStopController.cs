using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class OneStopController
{
    private static OneStopController uniqueController;
    private static SqlConnection connection;

    // Singleton pattern to ensure only one instance of the controller
    public static OneStopController GetInstance()
    {
        if (uniqueController == null)
        {
            uniqueController = new OneStopController();
        }
        return uniqueController;
    }

    // Constructor
    private OneStopController()
    {
        // Initialize database connection
        string connectionString= "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

        connection = new SqlConnection(connectionString);
    }

    // Method to reset the unique controller instance
    public static void ResetUniqueController()
    {
        uniqueController = null;
    }

    public List<DegreeForm> GetDegreeForms()
    {
        List<DegreeForm> forms = new List<DegreeForm>();
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch degree forms
            string query = "SELECT name, form_id, user_id, submission_date FROM Degree_form";

            SqlCommand command = new SqlCommand(query, connection);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Create DegreeForm object and populate data
                DegreeForm form = new DegreeForm();
                form.Name = reader["name"].ToString();
                form.FormID = reader["form_id"].ToString();
                form.UserID = reader["user_id"].ToString();
                form.SubmissionDate = Convert.ToDateTime(reader["submission_date"]);
                forms.Add(form);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching degree forms: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return forms;
    }

    public List<string> GetStudentNames()
    {
        List<string> studentNames = new List<string>();
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch student names and IDs from the users table
            string query = "SELECT user_id FROM users WHERE user_id LIKE 'STU_%'"; // Filter by user_id pattern

            SqlCommand command = new SqlCommand(query, connection);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Add student user ID to the list
                studentNames.Add(reader["user_id"].ToString());
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching student names: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return studentNames;
    }

    public string[] DisplayDegreeFormInfo(string tokenId)
    {
        string[] degreeInfo = new string[8]; // Update the array size to accommodate all fields
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch degree form information
            string query = @"SELECT TokenDeg.fyp_decision AS FYPDecision, TokenDeg.fyp_comment AS FYPComment, 
                        TokenDeg.finance_decision AS FinanceDecision, TokenDeg.finance_comment AS FinanceComment,
                        Token_DateTime.starting_time AS StartTime, Token_DateTime.estimated_time AS EstimatedTime,
                        Token_DateTime.fyp_time AS FYPTime, Token_DateTime.finance_time AS FinanceTime
                 FROM TokenDeg
                 INNER JOIN Token_DateTime ON TokenDeg.Token_id = Token_DateTime.Token_id
                 WHERE TokenDeg.Token_id = @TokenId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TokenId", tokenId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Populate degree form information into the array
                degreeInfo[0] = reader["FYPDecision"].ToString();
                degreeInfo[1] = reader["FYPComment"].ToString();
                degreeInfo[2] = reader["FinanceDecision"].ToString();
                degreeInfo[3] = reader["FinanceComment"].ToString();
                degreeInfo[4] = reader["StartTime"].ToString(); // Add start time
                degreeInfo[5] = reader["EstimatedTime"].ToString(); // Add estimated time
                degreeInfo[6] = reader["FYPTime"].ToString(); // Add FYP time
                degreeInfo[7] = reader["FinanceTime"].ToString(); // Add finance time
            }
            else
            {
                Console.WriteLine("No information found for the specified token ID.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching degree form information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return degreeInfo;
    }

    public string GenerateUniqueToken(string studentId)
    {
        string tokenId = ""; // Initialize token ID
        try
        {
            connection.Open();
            // Generate and insert new token for the student into the database
            // Implementation goes here...
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error generating token and inserting into database: " + ex.Message);
        }
        finally
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return tokenId;
    }

    public OneStopController.DegreeForm GetDegreeFormByFormId(string formId)
    {
        OneStopController.DegreeForm degreeForm = null;
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch degree form by form ID
            string query = "SELECT name, form_id, user_id, submission_date FROM Degree_form WHERE form_id = @FormId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FormId", formId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Populate degree form information
                degreeForm = new OneStopController.DegreeForm();
                degreeForm.Name = reader["name"].ToString();
                degreeForm.FormID = reader["form_id"].ToString();
                degreeForm.UserID = reader["user_id"].ToString();
                degreeForm.SubmissionDate = Convert.ToDateTime(reader["submission_date"]);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching degree form by form ID: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return degreeForm;
    }

    public OneStopController.DegreeForm GetDegreeFormByStudentId(string studentId)
    {
        OneStopController.DegreeForm degreeForm = null;
        try
        {
            connection.Open();
            // Fetch degree form by student ID from the database
            // Implementation goes here...
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching degree form by student ID: " + ex.Message);
        }
        finally
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return degreeForm;
    }

    public string GenerateTokenAndInsert(string formId)
    {
        string tokenId = ""; // Initialize token ID
        try
        {
            // Open connection
            connection.Open();

            // Extract the student ID from the form ID
            string studentId = formId.Substring(4, 2); // Assuming the student ID is always at index 4 and has a length of 2

            // Generate the token ID based on student ID
            tokenId = $"TOK_{studentId}";

            // Prepare query to insert token into TokenDeg table
            string insertQuery = "INSERT INTO TokenDeg (Token_id, form_id, fyp_decision, finance_decision, fyp_comment, finance_comment) " +
                                 "VALUES (@TokenId, @FormId, 'pending', 'pending', 'The decision is still pending', 'The decision is still pending')";

            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@TokenId", tokenId);
            insertCommand.Parameters.AddWithValue("@FormId", formId);

            // Execute insert query
            insertCommand.ExecuteNonQuery();

            // Insert token start time and estimated time into Token_DateTime table
            string insertDateTimeQuery = "INSERT INTO Token_DateTime (Token_id, starting_time, estimated_time, generation_date) " +
                                         "VALUES (@TokenId, @StartTime, @EstimatedTime, @GenerationDate)";

            SqlCommand insertDateTimeCommand = new SqlCommand(insertDateTimeQuery, connection);
            insertDateTimeCommand.Parameters.AddWithValue("@TokenId", tokenId);
            insertDateTimeCommand.Parameters.AddWithValue("@StartTime", DateTime.Now.TimeOfDay);
            insertDateTimeCommand.Parameters.AddWithValue("@EstimatedTime", DateTime.Now.AddMinutes(5).TimeOfDay);
            insertDateTimeCommand.Parameters.AddWithValue("@GenerationDate", DateTime.Now.Date);

            // Execute insert datetime query
            insertDateTimeCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error generating token and inserting into database: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return tokenId;
    }




    public void UpdateFYPFinanceTime(string tokenId, string status, DateTime updateTime)
    {
        string columnName = ""; // Initialize column name for the status being updated
        if (status.Equals("FYPStatus"))
        {
            columnName = "fyp_time";
        }
        else if (status.Equals("FinanceStatus"))
        {
            columnName = "finance_time";
        }

        try
        {
            // Open connection
            connection.Open();

            // Prepare query to update FYP or Finance time
            string query = $"UPDATE Token_DateTime SET {columnName} = @UpdateTime WHERE Token_id = @TokenId";

            SqlCommand command = new SqlCommand(query, connection);

            // Set parameters
            command.Parameters.AddWithValue("@UpdateTime", updateTime);
            command.Parameters.AddWithValue("@TokenId", tokenId);

            // Execute query
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"Error updating {columnName}: {ex.Message}");
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }

    public string[] DisplayFeedbackFormInfoForStudent(string userId)
    {
        string[] feedbackInfo = new string[6]; // Array to store feedback form information

        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch feedback form information based on user ID
            string query = "SELECT f.Feed_ID, f.Deg_Tokenid, f.comment, f.user_id, d.Token_id " +
                           "FROM feedback f " +
                           "INNER JOIN TokenDeg d ON f.Deg_Tokenid = d.Token_id " +
                           "WHERE f.user_id = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Populate feedback form information into the array
                feedbackInfo[0] = reader["Feed_ID"].ToString();
                feedbackInfo[1] = reader["Deg_Tokenid"].ToString();
                feedbackInfo[2] = reader["comment"].ToString();
                feedbackInfo[3] = reader["user_id"].ToString();
                feedbackInfo[4] = reader["Token_id"].ToString(); // Token ID from TokenDeg
            }
            else
            {
                Console.WriteLine("No feedback form found for the specified user ID.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching feedback form information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        return feedbackInfo;
    }


    public string[] DisplayComplaintFormInfoForStudent(string userId)
    {
        string[] complaintInfo = new string[4]; // Array to store complaint form information

        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch complaint form information based on user ID
            string query = "SELECT form_id, description, submission_date FROM complaint_form WHERE user_id = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Populate complaint form information into the array
                complaintInfo[0] = reader["form_id"].ToString();
                complaintInfo[1] = reader["description"].ToString();
                complaintInfo[2] = reader["submission_date"].ToString();
                complaintInfo[3] = userId; // Add user ID to the array
            }
            else
            {
                Console.WriteLine("No complaint form found for the specified user ID.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching complaint form information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return complaintInfo;
    }

    public string[] GetTokenTimeInfo(string tokenId)
    {
        string[] timeInfo = new string[2];
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch start time and estimated time from Token_DateTime table
            string query = "SELECT starting_time, estimated_time FROM Token_DateTime WHERE Token_id = @TokenId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TokenId", tokenId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Get start time and estimated time
                timeInfo[0] = reader["starting_time"].ToString();
                timeInfo[1] = reader["estimated_time"].ToString();
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching token time information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return timeInfo;
    }

    public string[] GetTokenStatusInfo(string tokenId)
    {
        string[] statusInfo = new string[4];
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to fetch status information from TokenDeg table
            string query = "SELECT fyp_decision, fyp_comment, finance_decision, finance_comment FROM TokenDeg WHERE Token_id = @TokenId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TokenId", tokenId);

            // Execute query
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Get status information
                statusInfo[0] = reader["fyp_decision"].ToString();
                statusInfo[1] = reader["fyp_comment"].ToString();
                statusInfo[2] = reader["finance_decision"].ToString();
                statusInfo[3] = reader["finance_comment"].ToString();
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error fetching status information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return statusInfo;
    }

    // Class to represent a degree form
    public void UpdateTokenTimeInfo(string tokenId, DateTime startTime, DateTime estimatedTime, DateTime fypTime, DateTime financeTime)
    {
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to update token time information
            string query = "UPDATE Token_DateTime SET starting_time = @StartTime, estimated_time = @EstimatedTime, fyp_time = @FYPTime, finance_time = @FinanceTime WHERE Token_id = @TokenId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartTime", startTime);
            command.Parameters.AddWithValue("@EstimatedTime", estimatedTime);
            command.Parameters.AddWithValue("@FYPTime", fypTime);
            command.Parameters.AddWithValue("@FinanceTime", financeTime);
            command.Parameters.AddWithValue("@TokenId", tokenId);

            // Execute query
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error updating token time information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }


    public void InsertTokenTimeInfo(string tokenId, DateTime startTime, DateTime estimatedTime, DateTime fypTime, DateTime financeTime)
    {
        try
        {
            // Open connection
            connection.Open();

            // Prepare query to insert token time information into the Token_DateTime table
            string query = "INSERT INTO Token_DateTime (Token_id, starting_time, estimated_time, fyp_time, finance_time, generation_date) " +
                           "VALUES (@TokenId, CONVERT(time, @StartTime), CONVERT(time, @EstimatedTime), CONVERT(time, @FYPTime), CONVERT(time, @FinanceTime), @GenerationDate)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TokenId", tokenId);
            command.Parameters.AddWithValue("@StartTime", startTime.ToString("HH:mm:ss")); // Format time as hours:minutes:seconds
            command.Parameters.AddWithValue("@EstimatedTime", estimatedTime.ToString("HH:mm:ss")); // Format time as hours:minutes:seconds
            command.Parameters.AddWithValue("@FYPTime", fypTime.ToString("HH:mm:ss")); // Format time as hours:minutes:seconds
            command.Parameters.AddWithValue("@FinanceTime", financeTime.ToString("HH:mm:ss")); // Format time as hours:minutes:seconds
            command.Parameters.AddWithValue("@GenerationDate", DateTime.Now.Date); // Include generation date

            // Execute query
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error inserting token time information: " + ex.Message);
        }
        finally
        {
            // Close connection
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }

    public bool TokenExists(string studentId)
    {
        bool tokenExists = false;
        try
        {
            connection.Open();
            // Check if token exists for the student in the database
            // Implementation goes here...
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error checking token existence: " + ex.Message);
        }
        finally
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return tokenExists;
    }

    public string GenerateToken(string studentId)
    {
        string tokenId = "";
        try
        {
            connection.Open();
            // Generate and insert new token for the student into the database
            // Implementation goes here...
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error generating token and inserting into database: " + ex.Message);
        }
        finally
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        return tokenId;
    }

    public class DegreeForm
    {
        public string Name { get; set; }
        public string FormID { get; set; }
        public string UserID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string TokenID { get; set; } // Added property for token
    }
}
