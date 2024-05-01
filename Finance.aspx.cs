using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Linq;

public partial class Finance : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load dashboard data when the page loads for the first time
            //DashboardButtonClick();
            // Populate the dropdown menu
            PopulateTokenDropdown();
        }
    }

    // Function to load dashboard data
    protected void DashboardButtonClick()
    {
        // Access the controller class instance and fetch TokenDeg data
        var controller = FinanceController.GetFinanceInstance(); // Changed to FinanceController
        var tokenDegList = controller.GetFinanceTokenDegList();

        if (tokenDegList.Count > 0)
        {
            // Get the first TokenDeg object from the list
            var tokenDeg = tokenDegList[0];

            // Update the labels with TokenDeg details
            Label1.Text = tokenDeg.Token_id;
            Label2.Text = tokenDeg.form_id;
            Label3.Text = tokenDeg.finance_decision; // Updated to finance_decision
            TextBox1.Text = tokenDeg.finance_comment; // Updated to finance_comment
        }
        else
        {
            // If no pending requests, display a message
            CardPlaceholder.Controls.Add(new LiteralControl("<p>No Degree Issuance Pending Requests.</p>"));
        }

        // Fetch token details based on selected token ID when the page loads
        fetchTokenDetails(null, EventArgs.Empty); // Provide null and EventArgs.Empty as parameters
    }




    protected void PopulateTokenDropdown()
    {
        var controller = FinanceController.GetFinanceInstance();
        var tokenDegList = controller.GetFinanceTokenDegList();

        // Clear existing items from the dropdown menu
        tokenDropdown.Items.Clear();

        // Add a default option
        tokenDropdown.Items.Add(new ListItem("Select Token", ""));

        // Add tokens from the database to the dropdown menu
        foreach (var tokenDeg in tokenDegList)
        {
            tokenDropdown.Items.Add(new ListItem(tokenDeg.Token_id, tokenDeg.Token_id));
        }
    }



    protected void fetchTokenDetails(object sender, EventArgs e)
    {
        string selectedTokenID = tokenDropdown.SelectedValue;

        // Fetch token details based on the selectedTokenID
        var controller = FinanceController.GetFinanceInstance();
        var tokenDetails = controller.GetTokenDetails(selectedTokenID);

        // Update UI with fetched token details
        if (tokenDetails != null)
        {
            // Update UI controls with token details
            Label1.Text = tokenDetails.Token_id;
            Label2.Text = tokenDetails.form_id;
            Label3.Text = tokenDetails.finance_decision;
            TextBox1.Text = tokenDetails.finance_comment;

            // Clear payment labels
            ClearPaymentLabels();

            // Fetch and display payment details based on the selected token ID
            var Fincontroller = FinanceController.GetFinancePaymentInstance();
            var FinancePaymentList = Fincontroller.GetFinancePaymentList(selectedTokenID);

            foreach (var FinancePayment in FinancePaymentList)
            {
                if (FinancePayment.type == "Processing Fee")
                {
                    // Assign values for Processing Fee type
                    Label4.Text = FinancePayment.Pay_id;
                    Label7.Text = FinancePayment.type;
                    Label8.Text = FinancePayment.Total_Amount.ToString();
                    Label9.Text = FinancePayment.Paid_Amount.ToString();
                    Label10.Text = FinancePayment.status;
                }
                else if (FinancePayment.type == "Degree Fee")
                {
                    // Assign values for Degree Fee type
                    Label16.Text = FinancePayment.Pay_id;
                    Label12.Text = FinancePayment.type;
                    Label13.Text = FinancePayment.Total_Amount.ToString();
                    Label14.Text = FinancePayment.Paid_Amount.ToString();
                    Label15.Text = FinancePayment.status;
                }
            }
        }
        else
        {
            // Handle case where no token details are found for the selected ID
            // You can clear the UI controls or display a message
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            TextBox1.Text = "";

            // Clear payment labels
            ClearPaymentLabels();
        }
    }

    // Function to clear payment labels
    protected void ClearPaymentLabels()
    {
        Label4.Text = "";
        Label7.Text = "";
        Label8.Text = "";
        Label9.Text = "";
        Label10.Text = "";
        Label16.Text = "";
        Label12.Text = "";
        Label13.Text = "";
        Label14.Text = "";
        Label15.Text = "";
    }



    protected void AcceptButton_Click(object sender, EventArgs e)
    {
        // Access the controller class instance and fetch FinancePaymentList
        var Fincontroller = FinanceController.GetFinancePaymentInstance();
        string selectedTokenID = Label1.Text; // Assuming Label1 contains the selected token ID
        var FinancePaymentList = Fincontroller.GetFinancePaymentList(selectedTokenID);

        // Check if any payment has a status of 'Unpaid'
        bool hasUnpaidPayment = FinancePaymentList.Any(payment => payment.status == "Unpaid");

        if (hasUnpaidPayment)
        {
            // Display an alert message
            ScriptManager.RegisterStartupScript(this, GetType(), "UnpaidAlert", "alert('Cannot accept while there are unpaid fees.');", true);
            return;
        }

        // Get the comment from the corresponding text box
        var comment = TextBox1.Text;

        // Update the database with the new comment and decision
        var controller = FinanceController.GetFinanceInstance(); // Changed to FinanceController
        controller.UpdateFinanceTokenDegDecision(selectedTokenID, "accepted", comment);

        // Refresh the dashboard
        DashboardButtonClick();
    }

    protected void RejectButton_Click(object sender, EventArgs e)
    {
        // Get the token ID associated with the clicked button
        var tokenID = Label1.Text;

        // Get the comment from the corresponding text box
        var comment = TextBox1.Text;

        // Update the database with the new comment and decision
        var controller = FinanceController.GetFinanceInstance(); // Changed to FinanceController
        controller.UpdateFinanceTokenDegDecision(tokenID, "rejected", comment);

        // Refresh the dashboard
        DashboardButtonClick();
    }

    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {

    }
}