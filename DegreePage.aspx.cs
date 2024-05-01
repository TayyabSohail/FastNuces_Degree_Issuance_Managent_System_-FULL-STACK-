using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DegreePage : System.Web.UI.Page
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

    protected void  LogoutButton_Click(object sender , EventArgs e)
    {
        Response.Redirect("Login.aspx");
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





    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
    }

    

    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox10_TextChanged(object sender, EventArgs e)
    {
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

        StuController.getInstance().getStudent().create_form_degree();
      

        StuController.getInstance().getStudent().getdegform().SetName(TextBox1.Text);
        StuController.getInstance().getStudent().getdegform().SetFatherName(TextBox2.Text);
        StuController.getInstance().getStudent().getdegform().SetPresentAddress(TextBox3.Text);
        StuController.getInstance().getStudent().getdegform().SetPermanentAddress(TextBox4.Text);
        StuController.getInstance().getStudent().getdegform().SetCNIC(TextBox5.Text);
        StuController.getInstance().getStudent().getdegform().SetEmail(TextBox6.Text);
        StuController.getInstance().getStudent().getdegform().SetPhoneNo(TextBox9.Text);
        int dummy = 0; // a variable to parse the integer 
        int.TryParse(TextBox10.Text, out dummy);
        StuController.getInstance().getStudent().getdegform().SetBankChallanNo(dummy);
        StuController.getInstance().getStudent().getdegform().SetDate(TextBox11.Text);


        bool valid = StuController.getInstance().getStudent().getdegform().ValidateForm();

        
        string message = "";
          
        
        if (valid)
        {
               bool flag =  StuController.getInstance().getStudent().SubmitForm();

            if (flag)
            {


                // Prompt for successful insertion in the database
                message = "Your Form has been submitted Successfully";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                // Prompt to show that a form has been created already
                message = "You have already submitted a degree issuance form";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InfoMessage", script, true);
            }
        }
        else
        {

            // Prompt to check the values of fields
            message = "Please ensure that you have entered the correct data in fields then try again";
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", script, true);

            
        }

        
    }


        protected void TextBox11_TextChanged(object sender, EventArgs e)
    {

    }
}