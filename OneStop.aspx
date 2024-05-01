<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneStop.aspx.cs" Inherits="OneStop" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>One Stop Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" rel="stylesheet">
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Lato', sans-serif;
            background-image: linear-gradient(-45deg, #e3eefe 0%, #2fa144 100%);
            display: flex;
            flex-direction: column; /* Ensure children stack vertically */
            align-items: center; /* Center content horizontally */
            min-height: 100vh;
        }

        h1 {
            text-align: end;
            color: #fff;
            font-size: 30px;
            margin-bottom: 20px; /* Adjusted from 500px to 20px */
        }

        .sidebar {
            position: fixed;
            width: 240px;
            left: -240px;
            height: 100%;
            background-color: #fff;
            transition: all .5s ease;
        }

        .sidebar header {
            font-size: 28px;
            color: #353535;
            line-height: 70px;
            text-align: center;
            background-color: #fff;
            user-select: none;
            font-family: 'Lato', sans-serif;
        }

        .sidebar button {
            display: block;
            height: 65px;
            width: 100%;
            color: #353535;
            line-height: 65px;
            padding-left: 30px;
            box-sizing: border-box;
            border-left: 5px solid transparent;
            font-family: 'Lato', sans-serif;
            transition: all .5s ease;
            border: none;
            background: none;
            cursor: pointer;
            text-align: left;
        }

        button.active, button:hover {
            border-left: 5px solid var(--accent-color);
            color: #fff;
            background: linear-gradient(to left, var(--accent-color), var(--gradient-color));
        }

        .sidebar button i {
            font-size: 23px;
            margin-right: 16px;
        }

        .sidebar button span {
            letter-spacing: 1px;
            text-transform: uppercase;
        }

        #check {
            display: none;
        }

        label #btn, label #cancel {
            position: absolute;
            left: 5px;
            cursor: pointer;
            color: #1b7318;
            border-radius: 5px;
            margin: 15px 30px;
            font-size: 29px;
            background-color: #e8d1ff;
            box-shadow: inset 2px 2px 2px 0px rgba(255, 255, 255, .5), inset -7px -7px 10px 0px rgba(0, 0, 0, .1), 3.5px 3.5px 20px 0px rgba(0, 0, 0, .1), 2px 2px 5px 0px rgba(0, 0, 0, .1);
            height: 45px;
            width: 45px;
            text-align: center;
            text-shadow: 2px 2px 3px rgba(255, 255, 255, 0.5);
            line-height: 45px;
            transition: all .5s ease;
        }

        label #cancel {
            opacity: 0;
            visibility: hidden;
        }

        #check:checked ~ .sidebar {
            left: 0;
        }

        #check:checked ~ label #btn {
            margin-left: 245px;
            opacity: 0;
            visibility: hidden;
        }

        #check:checked ~ label #cancel {
            margin-left: 245px;
            opacity: 1;
            visibility: visible;
        }

        .sidebar button:hover {
            background-color: #e6ffe6;
        }

        .sidebar button:hover span {
            opacity: 1;
            visibility: visible;
        }

        .sidebar > button.active, .sidebar > button:hover:nth-child(even) {
            --accent-color: rgb(31, 108, 34);
            --gradient-color: #1b7318;
        }

        .sidebar button.active, .sidebar > button:hover:nth-child(odd) {
            --accent-color: #1b7318;
            --gradient-color: #1b7318;
        }

.dashboard {
    display: flex;
    justify-content: center; /* Center the cards horizontally */
    gap: 20px;
    margin-top: 20px; /* Added margin to separate from the heading */
    margin-bottom: 20px; /* Added margin at the bottom */
}


        #complaintForm.dashboard .card,
        #feedbackForm.dashboard .card {
    width: 350px; /* Adjusted width to make the card broader */
    height: 300px; /* Adjusted height to make the card longer */
        }


        #dashboard.dashboard {
            margin-left: 80px; /* Adjust the left margin to move the cards more to the left */
        }

        .card {
            background-color: #fff;
            border-radius: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 300px;
            padding: 20px;
            text-align: center;
            display: flex;
            flex-direction: column;
            align-items: center;
            transition: all 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            margin-top: 20px;
            border: none;
            border-radius: 5px;
            background-color: #1b7318;
            color: #fff;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .button:hover {
            background-color: #155e14;
        }

        .card:nth-child(1), .card:nth-child(2), .card:nth-child(3) {
            margin-bottom: 20px; /* Added margin between the first three cards */
        }

        .card:nth-child(4) {
            margin-top: 20px; /* Added margin to separate the "Generate Token" card */
        }

        .card h3 {
            color: #1b7318;
            font-size: 24px;
            margin-bottom: 10px;
        }

        .label {
            color: #555;
            font-size: 16px;
            margin-bottom: 5px;
        }

        .feedback {
            color: #888;
            font-size: 14px;
        }
    </style>
</head>
<body>

    <h1 id="pageTitle">ONE STOP DEGREE ISSUANCE DASHBOARD</h1>

    <input type="checkbox" id="check" checked>
    <label for="check">
        <i class="fas fa-bars" id="btn"></i>
        <i class="fas fa-times" id="cancel"></i>
    </label>

    <div class="sidebar">
        <header>OneStop Menu</header>
        <button id="degreeIssuanceBtn" onclick="degreeIssuanceButtonClick()">
            <i class="fas fa-qrcode"></i>
            <span>Degree Issuance</span>
        </button>
        <button id="complaintFormBtn" onclick="complaintFormButtonClick()">
            <i class="fas fa-exclamation-triangle"></i>
            <span>Complaint Form</span>
        </button>
        <button id="feedbackFormBtn" onclick="feedbackFormButtonClick()">
            <i class="far fa-comment-dots"></i>
            <span>Feedback Form</span>
        </button>
        <button onclick="logoutButtonClick()">
            <i class="fas fa-sign-out-alt"></i>
            <span>Logout</span>
        </button>
    </div>

    <div class="dashboard" id="dashboard">
        <form id="form1" runat="server">
            <div class="dashboard" id="dashboard">

                <div class="card">
                    <h3>Forms Received</h3>
                    <asp:DropDownList ID="ddlStudents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudents_SelectedIndexChanged">
                    </asp:DropDownList>
                    <p>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </p>
                    <p>Type: Degree Issuance</p>
                    <p>
                        <asp:Button ID="generateDegreeButton" runat="server" Text="Generate Token" OnClick="generateDegree_Click" CssClass="button" />
                        <br>
                        <asp:Label ID="Label13" runat="server"></asp:Label>
                    </p>
                </div>

                <div class="card">
                    <h3>Time Tracking</h3>
                    <p class="label">
                        Start Time:
                <asp:Label ID="Label5" runat="server"></asp:Label>
                    </p>
                    <p class="label">
                        Estimated Time:
                <asp:Label ID="Label6" runat="server"></asp:Label>
                    </p>
                    <p class="label">
                        FYP Time:
                <asp:Label ID="Label7" runat="server"></asp:Label>
                    </p>
                    <p class="label">
                        Finance Time:
                <asp:Label ID="Label8" runat="server"></asp:Label>
                    </p>
                </div>

                <div class="card">
                    <h3>Department Status</h3>
                    <p class="label">
                        FYP Status:
                <asp:Label ID="Label9" runat="server"></asp:Label>
                    </p>
                    <p class="label">
                        Finance Status:
                <asp:Label ID="Label10" runat="server"></asp:Label>
                    </p>
                    <p class="feedback">
                        FYP Feedback:
                <asp:Label ID="Label11" runat="server"></asp:Label>
                    </p>
                    <p class="feedback">
                        Finance Feedback:
                <asp:Label ID="Label12" runat="server"></asp:Label>
                    </p>
                </div>
            </div>

            <!-- Separate division for "Generate Degree" card -->
            <div class="dashboard" id="dashboard">
                <div class="card">
                    <h3>Generate Degree</h3>
                    <button class="button" onclick="generateDegree()">Generate Degree</button>
                    <p id="tokenLabel" style="display: none;"></p>
                    <p id="token" style="display: none;"></p>
                </div>
            </div>
        </form>

    </div>

    <div class="dashboard" id="complaintForm" style="display: none;">
        <!-- Complaint Form Cards -->
        <div class="card">
            <h3>Complaint Form</h3>
            <br />
            <p>Form ID: <span id="complaintFormIdPlaceholder" runat="server"></span></p>
            <br />
            <p>Description: <span id="complaintDescriptionPlaceholder" runat="server"></span></p>
            <br />
            <p>Submission Date: <span id="complaintSubmissionDatePlaceholder" runat="server"></span></p>
            <br />
            <p>User ID: <span id="complaintUserIdPlaceholder" runat="server"></span></p>
        </div>
    </div>


    <div class="dashboard" id="feedbackForm" style="display: none;">
        <!-- Feedback Form Cards -->
        <div class="card">
            <h3>Feedback Form</h3> 
            <br />
            <p>Feed ID: <span id="feedbackIdPlaceholder" runat="server">></span></p>
            <br />
            <p>Degree Token ID: <span id="degreeTokenIdPlaceholder" runat="server">></span></p>
            <br />
            <p>Comment: <span id="feedbackCommentPlaceholder" runat="server">></span></p>
            <br />
            <p>User ID: <span id="feedbackUserIdPlaceholder" runat="server">></span></p>
            <br />
            <p>Token ID: <span id="TokenUserIdPlaceholder" runat="server">></span></p>
            <br />
        </div>
    </div>



    <script>


        function onSuccess(token) {
            // Display generated token
            document.getElementById("tokenLabel").style.display = "block";
            document.getElementById("token").style.display = "block";
            document.getElementById("token").innerText = "Token: " + token;
        }


        function degreeIssuanceButtonClick() {
            document.getElementById("dashboard").style.display = "flex";
            document.getElementById("complaintForm").style.display = "none";
            document.getElementById("feedbackForm").style.display = "none";
            // Update heading text
            document.getElementById("pageTitle").innerText = "ONE STOP DEGREE ISSUANCE DASHBOARD";
            // Add 'active' class to Degree Issuance button and remove from others
            document.getElementById("degreeIssuanceBtn").classList.add("active");
            document.getElementById("complaintFormBtn").classList.remove("active");
            document.getElementById("feedbackFormBtn").classList.remove("active");
        }

        function complaintFormButtonClick() {
            document.getElementById("dashboard").style.display = "none";
            document.getElementById("complaintForm").style.display = "flex";
            document.getElementById("feedbackForm").style.display = "none";
            // Update heading text
            document.getElementById("pageTitle").innerText = "ONE STOP COMPLAINT FORM DASHBOARD";
            // Add 'active' class to Complaint Form button and remove from others
            document.getElementById("degreeIssuanceBtn").classList.remove("active");
            document.getElementById("complaintFormBtn").classList.add("active");
            document.getElementById("feedbackFormBtn").classList.remove("active");
        }

        function feedbackFormButtonClick() {
            document.getElementById("dashboard").style.display = "none";
            document.getElementById("complaintForm").style.display = "none";
            document.getElementById("feedbackForm").style.display = "flex";
            // Update heading text
            document.getElementById("pageTitle").innerText = "ONE STOP FEEDBACK FORM DASHBOARD";
            // Add 'active' class to Feedback Form button and remove from others
            document.getElementById("degreeIssuanceBtn").classList.remove("active");
            document.getElementById("complaintFormBtn").classList.remove("active");
            document.getElementById("feedbackFormBtn").classList.add("active");
        }

        function logoutButtonClick() {
            window.location.href = "Login.aspx";
        }

        function generateDegree() {
            alert("DEGREE ISSUED");
        }
    </script>
</body>
</html>
