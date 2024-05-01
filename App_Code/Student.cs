using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    private DegForm form_obj;
    private CompForm form_comp;
    private Feedback feedback_form;
    private Deg_Token degree_token;
    private string user_id ;
    private string password;
    private string name;
 

    public Student()
    {
        form_obj = null;
        form_comp = null;
        degree_token = null;
    }

    public void create_form_degree()  // creates a degree issuance form 
    {
        if (form_obj == null)
        {

            form_obj = new DegForm();
            form_obj.SetUserId(this.user_id);


        }

    }

    public void create_form_complaint()  // creates a complaint issuance form 
    {
        if (form_comp == null)
        {

            form_comp = new CompForm();
            form_comp.SetUserId(this.user_id);


        }
        form_comp.assign_ID();
    }


    public void create_form_feedback()  // creates a feedback form 
    {
        if (feedback_form == null)
        {

            feedback_form = new Feedback();
            feedback_form.set_userid(this.user_id);


        }
        feedback_form.assign_ID();
    }



    public bool SubmitForm()
    {
        string form_id =  form_obj.check_already_inserted();
        bool already_inserted = false;

        if (form_id == "")
            already_inserted = false;
        else
            already_inserted = true;

        if (already_inserted)
        {
            return false;  // the user has already inserted in the table 
        }
        else
        {

            form_obj.insert_form_db();
            return true;
        }


      
    }


    public DegForm getdegform()
    {
        return form_obj;
    }

    public CompForm getcompform()
    {
        return form_comp;
    }

    public Feedback getfeedbackform()
    {
        return feedback_form;
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
                        this.name= reader["name"].ToString();
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

    public string getuserid()
    {
        return user_id;
    }

    public string getname()
    {
        return name;
    }

    public void create_tokdeg()
    {
        if (degree_token == null)
        {
            degree_token = new Deg_Token();
        }
    }


    public Deg_Token get_tokdeg()
    { 
        return degree_token ;  
    }
}