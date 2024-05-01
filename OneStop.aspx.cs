using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OneStop : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if token and form ID are present
            if (!string.IsNullOrEmpty(Label13.Text) && !string.IsNullOrEmpty(Label2.Text))
            {
                string tokenId = Label13.Text.Split(':')[1].Trim();

                // Update Time Tracking card with start time, estimated time, FYP time, and Finance Time
                UpdateTimeTrackingCard(tokenId);

                // Display degree form information
                DisplayDegreeFormInfo(tokenId);

                // Display complaint form information
                DisplayComplaintFormInfoForStudent(tokenId);
            }
            else
            {
                // Fetch and populate degree forms
                PopulateDegreeForms();

                // Fetch and populate student names
                PopulateStudentNames();
            }
        }
    }


    protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedFormId = ddlStudents.SelectedValue;

        OneStopController controller = OneStopController.GetInstance();
        OneStopController.DegreeForm degreeForm = controller.GetDegreeFormByFormId(selectedFormId);

        if (degreeForm != null)
        {
            Label1.Text = "Name: " + degreeForm.Name;
            Label2.Text = "Form ID: " + degreeForm.FormID;
            Label3.Text = "Student ID: " + degreeForm.UserID;
            Label4.Text = "Submission Date: " + degreeForm.SubmissionDate.ToString("yyyy-MM-dd");

            DisplayTokenInfo(degreeForm.TokenID);

            // Display complaint form information for the selected student
            DisplayComplaintFormInfoForStudent(degreeForm.UserID);

            // Display feedback form information for the selected student
            DisplayFeedbackFormInfoForStudent(degreeForm.UserID);
        }
        else
        {
            string tokenId = controller.GenerateUniqueToken(selectedFormId);
            Label1.Text = "Name: " + ddlStudents.SelectedItem.Text;
            Label3.Text = "Student ID: " + selectedFormId; // Display FormID as Student ID
            Label13.Text = "Token: " + tokenId;
            DisplayDefaultTimeTrackingInfo();
        }
    }

    private void DisplayFeedbackFormInfoForStudent(string studentId)
    {
        OneStopController controller = OneStopController.GetInstance();
        string[] feedbackInfo = controller.DisplayFeedbackFormInfoForStudent(studentId);

        if (feedbackInfo != null && feedbackInfo.Length >= 4)
        {
            // Update placeholders with feedback form data
            feedbackIdPlaceholder.InnerText = feedbackInfo[0];
            degreeTokenIdPlaceholder.InnerText = feedbackInfo[1];
            feedbackCommentPlaceholder.InnerText = feedbackInfo[2];
            feedbackUserIdPlaceholder.InnerText = feedbackInfo[3];
            TokenUserIdPlaceholder.InnerText = feedbackInfo[4];
        }
        else
        {
            // Handle case where feedback information is not found
            feedbackIdPlaceholder.InnerText = "Not available";
            degreeTokenIdPlaceholder.InnerText = "Not available";
            feedbackCommentPlaceholder.InnerText = "Not available";
            feedbackUserIdPlaceholder.InnerText = "Not available";
            TokenUserIdPlaceholder.InnerText = "Not available";
        }
    }

    private void DisplayComplaintFormInfoForStudent(string studentId)
    {
        OneStopController controller = OneStopController.GetInstance();
        string[] complaintInfo = controller.DisplayComplaintFormInfoForStudent(studentId);

        if (complaintInfo != null && complaintInfo.Length >= 4)
        {
            // Update placeholders with complaint form data
            complaintFormIdPlaceholder.InnerText = complaintInfo[0];
            complaintDescriptionPlaceholder.InnerText = complaintInfo[1];
            complaintSubmissionDatePlaceholder.InnerText = complaintInfo[2];
            complaintUserIdPlaceholder.InnerText = complaintInfo[3];
        }
        else
        {
            // Handle case where complaint information is not found
            complaintFormIdPlaceholder.InnerText = "Not available";
            complaintDescriptionPlaceholder.InnerText = "Not available";
            complaintSubmissionDatePlaceholder.InnerText = "Not available";
            complaintUserIdPlaceholder.InnerText = "Not available";
        }
    }





    private void PopulateDegreeForms()
    {
        OneStopController controller = OneStopController.GetInstance();
        List<OneStopController.DegreeForm> forms = controller.GetDegreeForms();

        if (forms.Count > 0)
        {
            OneStopController.DegreeForm latestForm = forms[0]; // Assuming the latest form is at index 0
            Label1.Text = "Name: " + latestForm.Name;
            Label2.Text = "Form ID: " + latestForm.FormID;
            Label3.Text = "User ID: " + latestForm.UserID;
            Label4.Text = "Submission Date: " + latestForm.SubmissionDate.ToString("yyyy-MM-dd");
            // Add other fields as needed
        }
    }

    private void PopulateStudentNames()
    {
        OneStopController controller = OneStopController.GetInstance();
        List<OneStopController.DegreeForm> studentForms = controller.GetDegreeForms();

        foreach (OneStopController.DegreeForm form in studentForms)
        {
            // Check if the UserID starts with "STU_"
            if (form.UserID.StartsWith("STU_"))
            {
                // Add the UserID as the text and FormID as the value for each dropdown item
                ddlStudents.Items.Add(new ListItem(form.UserID, form.FormID));
            }
        }
    }

    protected void generateDegree_Click(object sender, EventArgs e)
    {
        OneStopController controller = OneStopController.GetInstance();
        string formId = Label2.Text.Split(':')[1].Trim();
        string tokenId = controller.GenerateTokenAndInsert(formId);
        UpdateTimeTrackingCard(tokenId);
        Label13.Text = "Token: " + tokenId;
    }

    private void UpdateTimeTrackingCard(string tokenId)
    {
        OneStopController controller = OneStopController.GetInstance();
        string[] timeInfo = controller.GetTokenTimeInfo(tokenId);
        DateTime currentTime = DateTime.Now;
        DateTime estimatedTime = currentTime.AddMinutes(15);
        DateTime fypTime = currentTime.AddMinutes(5);
        DateTime financeTime = currentTime.AddMinutes(10);
        Label5.Text = currentTime.ToString("hh:mm tt");
        Label6.Text = estimatedTime.ToString("hh:mm tt");
        Label7.Text = fypTime.ToString("hh:mm tt");
        Label8.Text = financeTime.ToString("hh:mm tt");

        // Update time info in database
        controller.UpdateTokenTimeInfo(tokenId, currentTime, estimatedTime, fypTime, financeTime);

        string[] statusInfo = controller.GetTokenStatusInfo(tokenId);
        Label9.Text = statusInfo[0];
        Label11.Text = statusInfo[1];
        Label10.Text = statusInfo[2];
        Label12.Text = statusInfo[3];
    }

    private void DisplayDegreeFormInfo(string tokenId)
    {
        OneStopController controller = OneStopController.GetInstance();
        string[] statusInfo = controller.DisplayDegreeFormInfo(tokenId);
        Label7.Text = "FYP Decision: " + statusInfo[0];
        Label8.Text = "FYP Comment: " + statusInfo[1];
        Label9.Text = "Finance Decision: " + statusInfo[2];
        Label10.Text = "Finance Comment: " + statusInfo[3];
        Label5.Text = "Start Time: " + statusInfo[4];
        Label6.Text = "Estimated Time: " + statusInfo[5];
        Label11.Text = "FYP Time: " + statusInfo[6];
        Label12.Text = "Finance Time: " + statusInfo[7];
    }
    private void DisplayDefaultTimeTrackingInfo()
    {
        DateTime currentTime = DateTime.Now;
        DateTime estimatedTime = currentTime.AddMinutes(15);
        DateTime fypTime = currentTime.AddMinutes(5);
        DateTime financeTime = currentTime.AddMinutes(10);
        Label5.Text = currentTime.ToString("hh:mm tt");
        Label6.Text = estimatedTime.ToString("hh:mm tt");
        Label7.Text = fypTime.ToString("hh:mm tt");
        Label8.Text = financeTime.ToString("hh:mm tt");
        Label9.Text = "";
        Label10.Text = "";
        Label11.Text = "";
        Label12.Text = "";
    }

    private void DisplayTokenInfo(string tokenId)
    {
        if (!string.IsNullOrEmpty(tokenId))
        {
            OneStopController controller = OneStopController.GetInstance();
            string[] timeInfo = controller.GetTokenTimeInfo(tokenId);
            string[] statusInfo = controller.GetTokenStatusInfo(tokenId);
            Label5.Text = timeInfo[0];
            Label6.Text = timeInfo[1];
            Label7.Text = timeInfo[2];
            Label8.Text = timeInfo[3];
            Label9.Text = statusInfo[0];
            Label10.Text = statusInfo[1];
            Label11.Text = statusInfo[2];
            Label12.Text = statusInfo[3];
        }
    }
}
