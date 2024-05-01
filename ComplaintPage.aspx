<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintPage.aspx.cs" Inherits="ComplaintPage" %>

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
            margin: 5px 100px auto auto; 
            text-align: center;
        }

        h2 {
            position: relative;
            text-align: center;
           
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

        




                  
                    .container_complaint {
                      max-width: 800px;
                      width: 100%;
                      margin: 0 auto;
                      position: relative;

                       font-family: 'Segoe UI', Helvetica, Arial, sans-serif;

                      font-weight: 100;
                      font-size: 12px;
                      line-height: 30px;
                      color: #777;
                    }

                    #contact .txt,
                    #contact #btnSubmit {
                      font: 400 12px/16px "Roboto", Helvetica, Arial, sans-serif;
                    }

                    #contact {
                      background: #F9F9F9;
                      padding: 25px;
                      width : 550px;
                      margin: 150px 0;
                      box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
                    }

                    #contact h3 {
                      display: block;
                      font-size: 30px;
                      font-weight: 300;
                      margin-bottom: 10px;
                    }

                    #contact h4 {
                      margin: 5px 0 15px;
                      display: block;
                      font-size: 13px;
                      font-weight: 400;
                    }

                    fieldset {
                      border: medium none !important;
                      margin: 0 0 10px;
                      min-width: 100%;
                      padding: 0;
                      width: 100%;
                    }

                    #contact .txt,
                    #contact #texta {
                      width: 100%;
                      border: 1px solid #ccc;
                      background: #FFF;
                      margin: 0 0 5px;
                      padding: 10px;
            height: 37px;
        }

                    #contact .txt:hover,
                    #contact #texta:hover {
                      -webkit-transition: border-color 0.3s ease-in-out;
                      -moz-transition: border-color 0.3s ease-in-out;
                      transition: border-color 0.3s ease-in-out;
                      border: 1px solid #aaa;
                    }

                    #contact #txta {
                      height: 100px;
                      max-width: 100%;
                      resize: none;
                    }

                    #contact #btnSubmit {
                      cursor: pointer;
                      width: 100%;
                      border: none;
                      background: #16a085;
                      color: #FFF;
                      margin: 0 0 5px;
                      padding: 10px;
                      font-size: 15px;
                    }

                    #contact #btnSubmit:hover {
                      background: #0a7c60d7;
               
                    }

                    #contact #btnSubmit:active {
                      box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.5);
                    }

                 
                    

                    #contact input:focus,
                    #contact #texta:focus {
                      outline: 0;
                      border: 1px solid #aaa;
                    }

                    ::-webkit-input-placeholder {
                      color: #888;
                    }

                    :-moz-placeholder {
                      color: #888;
                    }

                    ::-moz-placeholder {
                      color: #888;
                    }

                    :-ms-input-placeholder {
                      color: #888;
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

    <asp:LinkButton CssClass=" button" ID="Button3" runat="server" OnClick="DegreeIssuanceButton_Click">
        <i class="fas fa-link"></i>
        <span>Degree Form</span>
    </asp:LinkButton>

    <asp:LinkButton CssClass="active button" ID="Button4" runat="server" OnClick="ComplaintFormButton_Click">
        <i class="fas fa-stream"></i>
        <span>Complaint Form</span>
    </asp:LinkButton>

    

    <asp:LinkButton Cssclass="button" ID="Button6" runat="server" OnClick="ReceiveDegButton_Click">
        <i class="fas fa-sliders-h"></i>
        <span>Receive Degree</span>
    </asp:LinkButton>

    <asp:LinkButton Cssclass="button" ID="Button7" runat="server" OnClick="FeedbackButton_Click">
        <i class="far fa-envelope"></i>
        <span>Give Feedback</span>
    </asp:LinkButton>

    </div>

 <div class="frame">
     <div class ="container_complaint" >
         <div id="contact">
        <h3>Complaint Form</h3>
        <h4>We are here to listen to you!</h4>
        <div>
           
            <asp:TextBox runat="server" class="txt" ID="TextBox1" placeholder="Your name" TabIndex="1" required="true" autofocus="true" OnTextChanged="name_text"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox runat="server" class="txt" ID='TextBox2' placeholder="Submission Date (YYYY-MM-DD)" TabIndex="2" required="true" OnTextChanged="date_text"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox runat="server" class="txt" ID="TextBox3" TextMode="MultiLine" placeholder="Type your concern here...." TabIndex="3" required="true" OnTextChanged="complaint_text"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btnSubmit" Text="Submit"  OnClick="btnSubmit_Click" />
        </div>
    
        </div>
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
