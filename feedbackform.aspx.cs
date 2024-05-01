using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedbackform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void StudentInfoButton_Click(object sender, EventArgs e)
    {
        // Add your code here for the Student Information button click event
        Response.Redirect("Student_Info.aspx");
    }

    protected void DegreeIssuanceButton_Click(object sender, EventArgs e)
    {
        // Add your code here for the Degree Issuance Form button click event
        Response.Redirect("DegreePage.aspx");
    }

    protected void ComplaintFormButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComplaintPage.aspx");
    }



    protected void ReceiveDegButton_Click(object sender, EventArgs e)
    {
        // Add your code here for the Receive Degree button click event
        Response.Redirect("ReceiveDeg.aspx");
    }

    protected void FeedbackButton_Click(object sender, EventArgs e)
    {
        // Add your code here for the Give Feedback button click event
        Response.Redirect("feedbackform.aspx");
    }



    protected void name_text(object sender, EventArgs e)
    {

    }

    protected void date_text(object sender, EventArgs e)
    {

    }

    protected void complaint_text(object sender, EventArgs e)
    {

    }

    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        string submission_date = TextBox2.Text;
        string comment = TextBox3.Text;
        StuController.getInstance().getStudent().create_form_feedback();
        string message = "";
        bool flag2 = false;
        bool flag = false;
        string token_id = StuController.getInstance().getStudent().get_tokdeg().TokenId; 
        if (token_id != "")
        {
            flag2 = true;
            StuController.getInstance().getStudent().getfeedbackform().set_token_id(token_id);
             flag = StuController.getInstance().getStudent().getfeedbackform().register_feedback_form(submission_date, comment);
        }

        if (flag2)
        { 
        
                  if (flag)
                    {
                        // messgae for successful registration

                        message = "Thank you for your feedback";
                        string script = "alert('" + message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);


                    }
                  else
                    {
                        //message for correct validation
                        message = "Please check the values in the fields and try again.";
                        string script = "alert('" + message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);

                    }

        }
        else
        {
            message = "No token exists for you to give feedback";
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);

        }


    }

}