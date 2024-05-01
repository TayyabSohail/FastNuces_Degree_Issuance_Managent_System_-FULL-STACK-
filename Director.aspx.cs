using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Director : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Tuple<string, string> result = DirectorController.getInstance().getDirector().GetDeg_Token().CalculateAverageTimes();

      
        string fypAverage = result.Item1;

       
        string financeAverage = result.Item2;


        label2.Text = fypAverage;

        
        label4.Text = financeAverage;

    }


    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void AnalyticsButton_Click(object sender, EventArgs e)
    {
        // Add your code here for the the analytics button

        Response.Redirect("Director.aspx");
    }



    protected void AllRequestsButton_Click(object sender, EventArgs e)
    {
        // Your code for handling click on "All Requests" button
        List<Deg_Token> all_requests = DirectorController.getInstance().getDirector().ViewAllRequests();

        if (all_requests != null)
        {
            // Initialize a StringBuilder to build the script
            StringBuilder scriptBuilder = new StringBuilder();

            // Loop through each request and append its data to the script
            foreach (Deg_Token request in all_requests)
            {
                // Access the properties of each request and append them to the script
                string TokenId = request.TokenId;
                string FormId = request.FormId;
                string FypDecision = request.FypDecision;
                string FinanceDecision = request.FinanceDecision;

                // Append the JavaScript function call to update the table with the current request's data
                scriptBuilder.Append("updateTable('" + TokenId + "', '" + FormId + "', '" + FypDecision + "', '" + FinanceDecision + "');\n");
            }

            // Register the script to update the table once with all the data
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTableScript", "<script>" + scriptBuilder.ToString() + "</script>");
        }
    }

    protected void FYPPendingButton_Click(object sender, EventArgs e)
    {

        List<Deg_Token> all_requests = DirectorController.getInstance().getDirector().ViewAllRequests();

        if (all_requests != null)
        {
            // Initialize a StringBuilder to build the script
            StringBuilder scriptBuilder = new StringBuilder();

            // Loop through each request and append its data to the script
            foreach (Deg_Token request in all_requests)
            {
                // Access the properties of each request and append them to the script
                string TokenId = request.TokenId;
                string FormId = request.FormId;
                string FypDecision = request.FypDecision;
                string FinanceDecision = request.FinanceDecision;

                if (FypDecision == "pending")
                scriptBuilder.Append("updateTable('" + TokenId + "', '" + FormId + "', '" + FypDecision + "', '" + FinanceDecision + "');\n");
            
            }

            // Register the script to update the table once with all the data
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTableScript", "<script>" + scriptBuilder.ToString() + "</script>");
        }
    }

    protected void FinancePendingButton_Click(object sender, EventArgs e)
    {

        List<Deg_Token> all_requests = DirectorController.getInstance().getDirector().ViewAllRequests();

        if (all_requests != null)
        {
            // Initialize a StringBuilder to build the script
            StringBuilder scriptBuilder = new StringBuilder();

            // Loop through each request and append its data to the script
            foreach (Deg_Token request in all_requests)
            {
                // Access the properties of each request and append them to the script
                string TokenId = request.TokenId;
                string FormId = request.FormId;
                string FypDecision = request.FypDecision;
                string FinanceDecision = request.FinanceDecision;

                if (FinanceDecision == "pending")
                    scriptBuilder.Append("updateTable('" + TokenId + "', '" + FormId + "', '" + FypDecision + "', '" + FinanceDecision + "');\n");

            }

            // Register the script to update the table once with all the data
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTableScript", "<script>" + scriptBuilder.ToString() + "</script>");
        }
    }


    protected void ProcessedRequestsButton_Click(object sender, EventArgs e)
    {

        List<Deg_Token> all_requests = DirectorController.getInstance().getDirector().ViewAllRequests();

        if (all_requests != null)
        {
            // Initialize a StringBuilder to build the script
            StringBuilder scriptBuilder = new StringBuilder();

            // Loop through each request and append its data to the script
            foreach (Deg_Token request in all_requests)
            {
                // Access the properties of each request and append them to the script
                string TokenId = request.TokenId;
                string FormId = request.FormId;
                string FypDecision = request.FypDecision;
                string FinanceDecision = request.FinanceDecision;

                if (FinanceDecision == "accepted" && FypDecision == "accepted")
                    scriptBuilder.Append("updateTable('" + TokenId + "', '" + FormId + "', '" + FypDecision + "', '" + FinanceDecision + "');\n");

            }

            
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTableScript", "<script>" + scriptBuilder.ToString() + "</script>");
        }
    }



    

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        
        if (DateTime.TryParseExact(TextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            List<Deg_Token> all_requests = DirectorController.getInstance().getDirector().GetEntriesByGenerationDate(TextBox1.Text);


            StringBuilder scriptBuilder = new StringBuilder();

            // Loop through each request and append its data to the script
           if (all_requests != null)
            { 
            foreach (Deg_Token request in all_requests)
            {
                // Access the properties of each request and append them to the script
                string TokenId = request.TokenId;
                string FormId = request.FormId;
                string FypDecision = request.FypDecision;
                string FinanceDecision = request.FinanceDecision;

                
                    scriptBuilder.Append("updateTable('" + TokenId + "', '" + FormId + "', '" + FypDecision + "', '" + FinanceDecision + "');\n");

            }


            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTableScript", "<script>" + scriptBuilder.ToString() + "</script>");
        }
        }
    }
}