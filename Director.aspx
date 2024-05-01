<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Director.aspx.cs" Inherits="Director" %>

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



            --button-background: green ;
            --button-color: white;
  

            --dropdown-width: 160px;
         --dropdown-background: white;
          
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

        






        body {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            width: 100vw;
            height: 100vh;
            background-image: linear-gradient(-45deg, #e3eefe 0%, #2fa144 100%);
        }
        

/* Boring button styles */
a.listbutton {
  /* Frame */
  display: inline-block;
  padding: 11px 21px;
  border-radius: 12px;
  box-sizing: border-box;
  
  
  border: none;
  background: var(--button-background);
  color: var(--button-color);
  font-size: 24px;
  cursor: pointer;
}


.dropdown {
  position: absolute; 
  top : 10px; 
  right: 25px; 
  padding: 0;
  margin-right: 1em;
  border: none;
}


.dropdown summary {
  list-style: none;
  list-style-type: none;
}

.dropdown > summary::-webkit-details-marker {
  display: none;
}

.dropdown summary:focus {
  outline: none;

}



.dropdown ul {
  position: absolute;
  margin: 20px 0 0 0;
  padding: 20px 0;
  width: var(--dropdown-width);
  left: 50%;
  margin-left: calc((var(--dropdown-width) / 2)  * -1);
  box-sizing: border-box;
  z-index: 2;
  
  background: var(--dropdown-background);
  border-radius: 6px;
  list-style: none;
}

.dropdown ul li {
  padding: 0;
  margin: 0;
}



.dropdown-button {
    display: inline-block;
    padding: 10px 0.8rem;
    width: 100%;
    box-sizing: border-box;
    color: var(--dropdown-color);
    text-decoration: none;
}

.dropdown-button:hover {
    background-color: green;
    color: var(--dropdown-background);
}

.dropdown ul::before {
  content: ' ';
  position: absolute;
  width: 0;
  height: 0;
  top: -10px;
  left: 50%;
  margin-left: -10px;
  border-style: solid;
  border-width: 0 10px 10px 10px;
  border-color: transparent transparent var(--dropdown-background) transparent;
}



.dropdown > summary::before {
  display: none;
}

.dropdown[open] > summary::before {
    content: ' ';
    display: block;
    position: fixed;
    top: 0;
    right: 0;
    left: 0;
    bottom: 0;
    z-index: 1;
}

.listbutton:hover{
    background-color:#1b7318;
}


.avglabel {
            color: white;
            font-family: 'Sans-serif', Tahoma, Geneva, Verdana, sans-serif;
            position: fixed;
            font-size:large;
           
            top: 20px; 
 
    z-index: 1000;
        }

        .label1 {
    
            left: 250px; 
        }

        .label2 {
            
            left: 430px; 
        }

        .label3 {
          
            left: 600px;

        }

       

        .label4 {
            left: 830px; 
        }






        .container {
  max-width: 1500px;
  
  position: fixed;
    z-index: 1000;
    top: 60px;
    right: 400px;
   
}




        .responsive-table li {
  border-radius: 3px;
  padding: 25px 30px;
  display: flex;
  justify-content: space-between;
  margin-bottom: 25px;
}

.responsive-table .table-header {
  background-color: #16a085;
  font-size: medium;
  color: white;
  text-transform: uppercase;
  letter-spacing: 0.03em;
  font-family: 'Sans-serif', Tahoma, Geneva, Verdana, sans-serif;
}

.responsive-table .table-row {
  background-color: #ffffff;
  box-shadow: 0px 0px 9px 0px rgba(0, 0, 0, 0.1);
}

.responsive-table .col-1 {
  flex-basis: 10%; /* Adjusted width */
}

.responsive-table .col-2 {
  flex-basis: 15%; /* Adjusted width */
}

.responsive-table .col-3 {
  flex-basis: 15%; /* Adjusted width */
}

.responsive-table .col-4 {
  flex-basis: 20%; /* Adjusted width */
}


.calendar-container {
    position: absolute; 
    top: 150px; 
    right: 25px; 
    padding: 10px;
  
    
}


.calendar-container .calendar-textbox {
    padding: 8px; 
    border: 1px solid #ced4da; 
    border-radius: 5px; 
    font-family: 'Sans-serif', Tahoma, Geneva, Verdana, sans-serif; 
    font-size: 14px; 
    color: #495057; 
}

.calendar-container .calendar-textbox::placeholder {
    color: #6c757d; 
    font-style: italic; 
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
        <header>Director Menu</header>
  
        <asp:Linkbutton  ID="Button2" runat="server" class="active button" OnClick="AnalyticsButton_Click">
        <i class="fas fa-qrcode"></i>
        <span>Analytics</span>
        </asp:LinkButton>

         <asp:LinkButton class="button" ID="Button1" runat="server" OnClick="LogoutButton_Click">
        <i class="fas fa-sign-out-alt"></i>
        <span>Logout</span>
    </asp:LinkButton>

    </div>

          <div class="label-container">
        <asp:Label ID="label1" runat="server" CssClass="avglabel label1" Text="Avg FYP Proc. Time:-"></asp:Label>
        <asp:Label ID="label2" runat="server" CssClass="avglabel label2" Text="0:0"></asp:Label>
        <asp:Label ID="label3" runat="server" CssClass="avglabel label3" Text="Avg Finance Proc. Time:-"></asp:Label>
        <asp:Label ID="label4" runat="server" CssClass="avglabel label4" Text="0:0"></asp:Label>
    </div>


         <div class="container">
  
  <ul class="responsive-table">
    <li class="table-header">
      <div class="col col-1">Token ID</div>
      <div class="col col-2">Form ID</div>
      <div class="col col-3">FYP Decision</div>
      <div class="col col-4">Finance Decision</div> 
    </li>


    </ul>
</div>

        

         <details class="dropdown">
            <summary role="button">
              <a class="listbutton">Filter</a>
            </summary>
            <ul>
 <asp:LinkButton ID="AllRequestsButton" runat="server" CssClass="dropdown-button" OnClick="AllRequestsButton_Click">All Requests</asp:LinkButton>
<asp:LinkButton ID="FYPPendingButton" runat="server" CssClass="dropdown-button" OnClick="FYPPendingButton_Click">FYP Pending</asp:LinkButton>
<asp:LinkButton ID="FinancePendingButton" runat="server" CssClass="dropdown-button" OnClick="FinancePendingButton_Click">Finance Pending</asp:LinkButton>
<asp:LinkButton ID="ProcessedRequestsButton" runat="server" CssClass="dropdown-button" OnClick="ProcessedRequestsButton_Click">Processed Requests</asp:LinkButton>

          </ul>
        </details>

       <div class="calendar-container">
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" CssClass="calendar-textbox" placeholder="YYYY-MM-DD"></asp:TextBox>
</div>




    <script>

        function showAlert(message) {
            alert(message);
        }

        function updateTable(TokenId, FormId, FypDecision, FinanceDecision) {
            var list = document.querySelector('.responsive-table');

            // Create a single list item with the provided values
            var listItem = document.createElement('li');
            listItem.className = 'table-row';
            listItem.innerHTML = `
        <div class="col col-1" data-label="Token ID">${TokenId}</div>
        <div class="col col-2" data-label="Form ID">${FormId}</div>
        <div class="col col-3" data-label="FYP Decision">${FypDecision}</div>
        <div class="col col-4" data-label="Finance Decision">${FinanceDecision}</div>
    `;

            // Append the new list item to the list
            list.appendChild(listItem);
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
