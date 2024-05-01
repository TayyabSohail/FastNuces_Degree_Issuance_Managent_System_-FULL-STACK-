using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComplaintPage : System.Web.UI.Page
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


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;
        string submission_date = TextBox2.Text;
        string Complaint = TextBox3.Text;
        StuController.getInstance().getStudent().create_form_complaint();
        bool flag = StuController.getInstance().getStudent().getcompform().registercomplaint(name, submission_date, Complaint);
        string message = "";
       
        if (flag)
        {
            // messgae for successful registration
          
            message = "Your Complaint has been registered successfully.";
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

}