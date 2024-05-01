using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReceiveDeg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add code here that you want to execute when the page loads
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


    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }






    protected void leftButton_Click(object sender, EventArgs e)
    {
        StuController.getInstance().getStudent().get_tokdeg().checktoken_existance();
        string message = "";
        if (StuController.getInstance().getStudent().get_tokdeg().TokenId == "")
        {
            //Prompt No token Existance
            message = "Your Token has not been generated yet";
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
        }
        else
        {
            if (StuController.getInstance().getStudent().get_tokdeg().FypDecision == "accepted" && StuController.getInstance().getStudent().get_tokdeg().FinanceDecision == "accepted")
            {
                // give the degree 
                message = "Congratulations! Your degree has been downloaded";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
            }   
            else
            {
                // alert pending
                message = "Your Degee Decisions are Pending";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
            }
        }

    }

    protected void rightButton_Click(object sender, EventArgs e)
    {
        StuController.getInstance().getStudent().get_tokdeg().checktoken_existance();
        string message = "";
        if (StuController.getInstance().getStudent().get_tokdeg().TokenId == "")
        {
            
            //Prompt No token Existance
            message = "Your Token has not been generated yet";
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
        }
        else
        {
            if (StuController.getInstance().getStudent().get_tokdeg().FypDecision == "accepted" && StuController.getInstance().getStudent().get_tokdeg().FinanceDecision == "accepted")
            {
                // give degree alert
               
                message = "Congratulations! Your degree will be posted to your Permanent Address";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                // alert pending
                message = "Your Degree Decisions are pending";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
            }
        }
    }
}