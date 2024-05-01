<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finance.aspx.cs" Inherits="Finance" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Finance MENU</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
    <link href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" rel="stylesheet">
    <style>
        * {
            margin: 0;
            padding: 0;
            text-decoration: none;
        }

        :root {
            --accent-color: #fff;
            --gradient-color: #FBFBFB;
        }

        body {
            width: 100vw;
            height: 100vh;
            background-image: linear-gradient(-45deg, #e3eefe 0%, #2fa144 100%);
            position: relative;
            top: 0px;
            left: -8px;
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
            left: 10px; /* Adjusted position */
            top: 10px; /* Adjusted position */
            cursor: pointer;
            color: #1b7318;
            border-radius: 5px;
            margin: 0; /* Removed margin */
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

        .frame {
            width: 50%;
            height: 30%;
            margin: auto;
            text-align: center;
        }

        h2 {
            position: relative;
            text-align: center;
            color: #353535;
            font-size: 60px;
            font-family: 'Lato', sans-serif;
            margin: 0;
            color: #1b7318;
        }

        p {
            font-family: 'Lato', sans-serif;
            font-weight: 300;
            text-align: center;
            font-size: 30px;
            color: #1b7318;
            margin: 0;
        }

.centered-card {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 1; /* Ensure the card is above the sidebar */
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.card {
    width: 300px;
    max-width: 600px;
    background-color: #ffffff;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    transition: 0.3s;
    /* Center the card */
    margin-top: 114px;
    padding: 40px;
    border-radius: 10px;
    height: 751px;
    background-color: mediumseagreen;
    display: none;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: auto;
        }

.card.active {
    display: block; /* Show the card when active class is applied */
}


        .card:hover {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
        }

        .card-header {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .card-row {
            justify-content: space-between;
            margin-bottom: 10px;
            width: 312px;
        }

        .card-label {
            font-weight: bold;
            flex: 1;
            width: 308px;
        }

        .card-data {
            flex: 2;
        }

       .action-buttons {
    display: flex;
    justify-content: center;
    margin-top: 50px;
}

.action-button {
    margin: 0 10px;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s, color 0.3s; /* Added color transition */
    font-size: 20px;
}

.action-button.accept {
    background-color: seagreen; /* Darker color for Accept button */
    color: white;
}

.action-button.reject {
    background-color: #f44336;
    color: white;
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
            <header>FINANCE Menu</header>
            <button class="active">
                <i class="fas fa-qrcode"></i>
                <span>Dashboard</span>
            </button>
            <button onclick="logout()">
                <!-- Add the onclick event handler for logout -->
                <i class="fas fa-sign-out-alt"></i>
                <span>LogOut</span>
            </button>
        </div>



        <asp:PlaceHolder ID="CardPlaceholder" runat="server"></asp:PlaceHolder>
        <div class="centered-card">
            <div class="card active" id="Card">
                <div class="card-header">Token Details</div>
                <asp:DropDownList ID="tokenDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="fetchTokenDetails"></asp:DropDownList>

                <div class="card-row">
                    <div class="card-label">
                        Token ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                    <!-- Placeholder for Token ID -->
                </div>
                <div class="card-row">
                    <div class="card-label">
                        Form ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                    <!-- Placeholder for Form ID -->
                </div>
                <div class="card-row">
                    <!-- Placeholder for FYP Decision -->
                    <div class="card-label">
                        Finance Decision:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        _______________________________<br />

                        Pay ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        TYPE:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                        <br />
                        Total Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                        &nbsp;
                <br />
                        Paid Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                        &nbsp;<br />
                        Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        _______________________________<br />
                        <div class="card-row">
                            Pay ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            TYPE:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                            <br />
                            Total Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                            <br />
                            Paid Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                            <br />
                            Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                            <br />
                            <!-- Placeholder for FYP Decision -->
                        </div>
                    </div>
                </div>
                <div class="card-row">
                    <div class="card-label">
                        Finance Comment:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Height="92px" OnTextChanged="TextBox1_TextChanged1" Width="267px"></asp:TextBox>
                        <div class="action-buttons">
                            <asp:Button ID="AcceptButton" runat="server" Text="Accept" OnClick="AcceptButton_Click" CssClass="action-button accept" />
                            <asp:Button ID="RejectButton" runat="server" Text="Reject" OnClick="RejectButton_Click" CssClass="action-button reject" />
                        </div>
                    </div>
                </div>
            </div>
        </div>




        <script>
            // Function to handle logout
            function logout() {
                // Redirect the user to the logout page
                window.location.href = "Login.aspx"; // Change "Login.aspx" to your actual logout page URL
            }
        </script>




        <p>
            &nbsp;
        </p>

        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>

    </form>

</body>
</html>
