using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DegForm
/// </summary>
public class DegForm : Forms
{

   
    private string father_name;
    private string present_address;
    private string permanent_address;
    private string CNIC;
    private string email;
    private string phone_no;
      private int bank_challan_no;


    public DegForm()
    {
        this.assign_ID();
    }


    public bool ValidateForm()
    {

        if (string.IsNullOrWhiteSpace(this.form_id) || string.IsNullOrWhiteSpace(user_id) ||
            string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(father_name) ||
            string.IsNullOrWhiteSpace(present_address) || string.IsNullOrWhiteSpace(permanent_address) ||
            string.IsNullOrWhiteSpace(CNIC) || string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phone_no) || string.IsNullOrWhiteSpace(this.submission_date) ||
            bank_challan_no == 0)
        {
            return false;
        }


        if (!IsNumeric(CNIC))
        {
            return false;
        }

        if (!email.Contains("@") || !email.Contains(".com"))
        {
            return false;
        }


        if (!IsNumeric(phone_no))
        {
            return false;
        }

        // Check if bank challan number contains only numbers
        if (!IsNumeric(bank_challan_no.ToString()))
        {
            return false;
        }

        // Check if date is in correct format
        if (!DateTime.TryParseExact(this.submission_date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return false;
        }

        return true;
    }


    private bool IsNumeric(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    public void assign_ID()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM Degree_form";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int rowCount = (int)command.ExecuteScalar();

                if (rowCount == 0)
                {
                    // If there are no entries in the table, assign form_id as "DEG_01"
                    this.form_id = "DEG_01";
                }
                else
                {
                    // If there are entries in the table, retrieve the latest form_id and generate the next one
                    query = "SELECT TOP 1 form_id FROM Degree_form ORDER BY form_id DESC";
                    command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string latestFormId = reader.GetString(0);
                        string separator = latestFormId.Substring(4);
                        int uniqueNum = int.Parse(separator) + 1;
                        this.form_id = (uniqueNum <= 9) ? "DEG_0" + uniqueNum : "DEG_" + uniqueNum;
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



    public bool insert_form_db()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = @"INSERT INTO Degree_form 
                        (form_id, user_id, name, father_name, present_address, permanent_address, CNIC, email, phone_no, submission_date, bank_challan_no) 
                        VALUES 
                        (@FormId, @UserId, @Name, @FatherName, @PresentAddress, @PermanentAddress, @CNIC, @Email, @PhoneNo, @SubmissionDate, @BankChallanNo)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Assign values to parameters
            command.Parameters.AddWithValue("@FormId", this.form_id);
            command.Parameters.AddWithValue("@UserId", this.user_id);
            command.Parameters.AddWithValue("@Name", this.name);
            command.Parameters.AddWithValue("@FatherName", this.father_name);
            command.Parameters.AddWithValue("@PresentAddress", this.present_address);
            command.Parameters.AddWithValue("@PermanentAddress", this.permanent_address);
            command.Parameters.AddWithValue("@CNIC", this.CNIC);
            command.Parameters.AddWithValue("@Email", this.email);
            command.Parameters.AddWithValue("@PhoneNo", this.phone_no);
            command.Parameters.AddWithValue("@SubmissionDate", this.submission_date);
            command.Parameters.AddWithValue("@BankChallanNo", this.bank_challan_no);

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


    public string check_already_inserted()
    {
        string connectionString = "Data Source=DESKTOP-DH5VMPH\\SQLEXPRESS;Initial Catalog=final_se;Integrated Security=True;";
        string query = @"SELECT form_id FROM Degree_form WHERE user_id = @UserId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Assign value to parameter
            command.Parameters.AddWithValue("@UserId", this.user_id);

            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null) // If a form already exists
            {
                return result.ToString(); // Return the form ID
            }
            else
            {
                return ""; // Return empty string if the form is not inserted
            }
        }
    }




    public string getName()
    {
        return name;
    }

    public string getFatherName()
    {
        return father_name;
    }

    public string getPresentAddress()
    {
        return present_address;
    }

    public string getPermanentAddress()
    {
        return permanent_address;
    }

    public string getCnic()
    {
        return CNIC;
    }

    public string getEmail()
    {
        return email;
    }

    public string getPhoneNo()
    {
        return phone_no;
    }

    public string getDate()
    {
        return this.submission_date;
    }

    public int getBankChallanNo()
    {
        return bank_challan_no;
    }



    public void SetName(string value)
    {
        name = value;
    }


    public void SetFatherName(string value)
    {
        father_name = value;
    }


    public void SetPresentAddress(string value)
    {
        present_address = value;
    }


    public void SetPermanentAddress(string value)
    {
        permanent_address = value;
    }


    public void SetCNIC(string value)
    {
        CNIC = value;
    }

    public void SetEmail(string value)
    {
        email = value;
    }

    public void SetPhoneNo(string value)
    {
        phone_no = value;
    }
   


    public void SetBankChallanNo(int value)
    {
        bank_challan_no = value;
    }

}