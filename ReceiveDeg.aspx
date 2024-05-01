<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveDeg.aspx.cs" Inherits="ReceiveDeg" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Responsive Sidebar</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" rel="stylesheet">
    <style>


        * {
            padding: 0;
            text-decoration: none;
            margin-left: 0;
            margin-right: 0;
            margin-top: 0;
        }

        :root {
            --accent-color: #fff;
            --gradient-color: #FBFBFB;
        }

        body {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            width: 100vw;
            height: 100vh;
            background-image: linear-gradient(-45deg, #e3eefe 0%, #2fa144 100%);
        }

        .sidebar {
          

            
            position: fixed;
            width: 240px;
            height: 100%; 
            top: 0; 
            left: -240px;
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

        .sidebar .button {
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

        .button.active, .button:hover {
            border-left: 5px solid var(--accent-color);
            color: #fff;
            background: linear-gradient(to left, var(--accent-color), var(--gradient-color));
        }

        .sidebar .button i {
            font-size: 23px;
            margin-right: 16px;
        }

        .sidebar .button span {
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

        .sidebar .button:hover {
            background-color: #e6ffe6;
        }

        .sidebar .button:hover span {
            opacity: 1;
            visibility: visible;
        }

        .sidebar > .button.active, .sidebar > .button:hover:nth-child(even) {
            --accent-color: rgb(31, 108, 34);
            --gradient-color: #1b7318;
        }

        .sidebar .button.active, .sidebar > .button:hover:nth-child(odd) {
            --accent-color: #1b7318;
            --gradient-color: #1b7318;
        }

        .frame {
            width: 50%;
            height: 30%;
            margin: auto;
            text-align: center;
        }

       

        p {
               font-family: 'Lato', sans-serif;
    font-weight: 300;
    text-align: center;
    font-size: 20px;
    color: #03040385;
    margin: 0;

        }

        





         .card {
            background-color: #fff;
            border-radius: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 600px;
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

        .crdbutton {
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

    .crdbutton:hover {
        background-color: rgb(22, 78, 20);
    }

        .card:nth-child(1), .card:nth-child(2), .card:nth-child(3) {
            margin-bottom: 20px; /* Added margin between the first three cards */
        }

        .card:nth-child(4) {
            margin-top: 20px; /* Added margin to separate the "Generate Token" card */
        }

        .card h3 {
                font-size: 30px;
          color: green;
        font-weight: 300;
        font-family: cursive;
        }



       





       


    </style>
</head>
<body>
     <form id="form1" runat="server">
    <input type="checkbox" id="check" checked>
    <label for="check">
        <i class="fas fa-bars" id="btn"></i>
        <i class="fas fa-times" id="cancel"></i>
    </label>

    <div class="sidebar">
        <header>Menu</header>
  
        <asp:LinkButton  ID="Button2" runat="server" CssClass=" button" OnClick="StudentInfoButton_Click">
        <i class="fas fa-qrcode"></i>
        <span>Information</span>
    </asp:LinkButton>

    <asp:LinkButton class=" button" ID="Button3" runat="server" OnClick="DegreeIssuanceButton_Click">
        <i class="fas fa-link"></i>
        <span>Degree Form</span>
    </asp:LinkButton>

    <asp:LinkButton class="button" ID="Button4" runat="server" OnClick="ComplaintFormButton_Click">
        <i class="fas fa-stream"></i>
        <span>Complaint Form</span>
    </asp:LinkButton>

    

    <asp:LinkButton class="active button" ID="Button6" runat="server" OnClick="ReceiveDegButton_Click">
        <i class="fas fa-sliders-h"></i>
        <span>Receive Degree</span>
    </asp:LinkButton>

    <asp:LinkButton class="button" ID="Button7" runat="server" OnClick="FeedbackButton_Click">
        <i class="far fa-envelope"></i>
        <span>Give Feedback</span>
    </asp:LinkButton>


         <asp:LinkButton class="button" ID="Button8" runat="server" OnClick="LogoutButton_Click">
        <i class="fas fa-sign-out-alt"></i>
        <span>Logout</span>
    </asp:LinkButton>

    </div>

         <div class="card">
    <h3>Congratulations on this well-deserved honor!</h3>
    <p>We are thrilled to extend our heartfelt congratulations to you on receiving your degree! This is a significant milestone that reflects
        your dedication, perseverance, and commitment to excellence.</p>
  
  <div class="button-container">
    <asp:Button ID="leftButton" runat="server" CssClass="crdbutton" Text="Online Receival" OnClick="leftButton_Click" />
    <asp:Button ID="rightButton" runat="server" CssClass="crdbutton" Text="In Person Receival" OnClick="rightButton_Click" />
</div>



         </div>


    <script>

        function showAlert(message) {
            alert(message);
        }

        // 1. Add click event listener to buttons
        const buttons = document.querySelectorAll('.sidebar .button');
        buttons.forEach(button => {
            button.addEventListener('click', () => {
                // Remove active class from all buttons
                buttons.forEach(b => b.classList.remove('active'));
                // Add active class to the clicked button
                button.classList.add('active');
            });
        });

        // 2. Add smooth scroll to anchor links
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function (e) {
                e.preventDefault();
                document.querySelector(this.getAttribute('href')).scrollIntoView({
                    behavior: 'smooth'
                });
            });
        });
    </script>
         </form>
</body>
</html>
