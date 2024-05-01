using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        label2.Text = StuController.getInstance().getStudent().getuserid();


        label4.Text = StuController.getInstance().getStudent().getname();

        // Add code here that you want to execute when the page loads
        int row_count1;
        int row_count2;
        int row_count3;
        StuController.getInstance().getStudent().create_form_degree();

        string form_id = StuController.getInstance().getStudent().getdegform().check_already_inserted();

        StuController.getInstance().getStudent().create_tokdeg();

        if (form_id != "")
        {
            StuController.getInstance().getStudent().get_tokdeg().setformid(form_id);
            row_count1 = StuController.getInstance().getStudent().get_tokdeg().update_main_bar();
            row_count2 = StuController.getInstance().getStudent().get_tokdeg().update_fyp_bar();
            row_count3 = StuController.getInstance().getStudent().get_tokdeg().update_finance_bar();
        }
        else
        { 
            row_count1 = 1;
            row_count2 = 1;
            row_count3 = 1;

        }

        StringBuilder combinedScript = new StringBuilder();

        combinedScript.AppendLine("updateFrameContent_mainbar('cont1', " + row_count1 + ");");
        combinedScript.AppendLine("updateFrameContent_mainbar('cont2', " + row_count2 + ");");
        combinedScript.AppendLine("updateFrameContent_mainbar('cont3', " + row_count3 + ");");

        ClientScript.RegisterStartupScript(this.GetType(), "CombinedUpdateScripts", combinedScript.ToString(), true);




    }
    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
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





}