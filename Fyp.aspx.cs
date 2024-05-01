using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

public partial class Fyp : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load dashboard data when the page loads for the first time
            dashboardButtonClick();
            PopulateTokenDropdown();
        }
    }

    // Function to load dashboard data


    // {tokenDeg.Token_id}    {tokenDeg.form_id}         {tokenDeg.fyp_decision}        {tokenDeg.fyp_comment}

    protected void dashboardButtonClick()
    {
        // Access the controller class instance and fetch TokenDeg data
        var controller = FypController.GetInstance();
        var tokenDegList = controller.GetTokenDegList();

        if (tokenDegList.Count > 0)
        {
            // Get the first TokenDeg object from the list
            var tokenDeg = tokenDegList[0];

            // Update the labels with TokenDeg details
            Label1.Text = tokenDeg.Token_id;
            Label2.Text = tokenDeg.form_id;
            Label3.Text = tokenDeg.fyp_decision;
            TextBox1.Text = tokenDeg.fyp_comment;
        }
        else
        {
            // If no pending requests, display a message
            CardPlaceholder.Controls.Add(new LiteralControl("<p>No Degree Issuance Pending Requests.</p>"));
        }
    }

    protected void PopulateTokenDropdown()
    {
        var controller = FypController.GetInstance();
        var tokenDegList = controller.GetTokenDegList();

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

    protected void tokenDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedTokenID = tokenDropdown.SelectedValue;

        // Fetch token details based on the selectedTokenID
        var controller = FypController.GetInstance();
        var tokenDetails = controller.GetTokenDetails(selectedTokenID);

        // Update UI with fetched token details
        if (tokenDetails != null)
        {
            // Update UI controls with token details
            Label1.Text = tokenDetails.Token_id;
            Label2.Text = tokenDetails.form_id;
            Label3.Text = tokenDetails.fyp_decision;
            TextBox1.Text = tokenDetails.fyp_comment;

            // Show the card with fetched details
            CardPlaceholder.Visible = true;
        }
        else
        {
            // If no token details found, hide the card
            CardPlaceholder.Visible = false;
        }
    }

    protected void AcceptButton_Click(object sender, EventArgs e)
    {
        // Get the token ID associated with the clicked button
        var tokenID = Label1.Text;

        // Get the comment from the corresponding text box
        var comment = TextBox1.Text;

        // Update the database with the new comment and decision
        var controller = FypController.GetInstance();
        controller.UpdateTokenDegDecision(tokenID, "accepted", comment);

        // Refresh the token dropdown to reflect the changes
        PopulateTokenDropdown();
    }

    protected void RejectButton_Click(object sender, EventArgs e)
    {
        // Get the token ID associated with the clicked button
        var tokenID = Label1.Text;

        // Get the comment from the corresponding text box
        var comment = TextBox1.Text;

        // Update the database with the new comment and decision
        var controller = FypController.GetInstance();
        controller.UpdateTokenDegDecision(tokenID, "rejected", comment);

        // Refresh the token dropdown to reflect the changes
        PopulateTokenDropdown();
    }
}


