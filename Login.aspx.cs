using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  
  

    protected void Button1_Click1(object sender, EventArgs e)
    {
        String u = TextBox1.Text;
        String p = TextBox2.Text;
        Register R = new Register();
       
        bool flag = R.check_login(u, p);

        string message = "";
        if (flag)
        {
            // Login Successful
            
                message = "You have been logged in successfully.";
                string script = "alert('" + message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);

           
            if (u[0] == 'S')
            {
                StuController.ResetUniqueController();
                StuController.getInstance().getStudent().fetch_info(u);
                Response.Redirect("Student_Info.aspx");
            }
            else if (u[0] == 'O')
            {
                // redirect to the one stop main page
                OneStopController.ResetUniqueController();
                StuController.getInstance().getStudent().fetch_info(u);
                Response.Redirect("OneStop.aspx");
            }
            else if (u[0] == 'D')
            {
                // redirect to the director main page
                DirectorController.ResetUniqueController();
                DirectorController.getInstance().getDirector().fetch_info(u);
                Response.Redirect("Director.aspx");
            }
            else if (u[0] == 'F' && u[1] == 'I')
            {
                // redirect to the finance officer main page
                
                StuController.getInstance().getStudent().fetch_info(u);
                Response.Redirect("Finance.aspx");
            }
            else if (u[0] == 'F' && u[1] == 'Y')
            {
                // redirect to the FYP officer main page
              
                StuController.getInstance().getStudent().fetch_info(u);
                Response.Redirect("FYP.aspx");
            }
        }
        else
        {
            // Login Failed
            message = "Username or Password Incorrect! Try again";
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessMessage", script, true);


        }
    
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}