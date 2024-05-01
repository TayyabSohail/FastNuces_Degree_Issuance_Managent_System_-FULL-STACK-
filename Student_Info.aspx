<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Info.aspx.cs" Inherits="Student_Info" %>

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

        





form {
    
    width: 300px;
    margin: 0 auto;
    display: grid;
    grid-template-columns: 1fr 2fr;
    grid-gap: 10px;
}

label {
    grid-column: 1;
    align-self: center;
}


input[type="text"] {
    grid-column: 2; 
    align-self: center; 
}



/*styling of the progress bar starts here*/

 .container_pro {
      
       position: absolute;
    
      transform: translate(-50%, -50%); 
    }

 #cont1{
       top: 40%; 
      left: 30%; 
 }

 #cont2{
       top: 65%; 
      left: 30%; 
 }

  #cont3{
       top: 85%; 
      left: 30%; 
 }

    .container_progress_bar {
      width: 180%;
    }

    .progressbar {
      counter-reset: step;
    }

    .progressbar li {
      list-style: none;
      display: inline-block;
      width: 24%; 
      position: relative;
      text-align: center;
      cursor: pointer;
         
    }

    

    .progressbar li:before {
      content: counter(step);
      counter-increment: step;
          width: 40px;
         height: 40px;
      line-height: 30px;
      border: 2px solid #ddd;
      border-radius: 100%;
      display: block;
      text-align: center;
      margin: 0 auto 10px auto;
      background-color: #fff;
      color:black;
    }

    .progressbar li:after {
      content: "";
      position: absolute;
      width: 100%;
      height: 1px;
      background-color: #ddd;
      top: 15px;
      left: -50%;
      z-index: -1;
          border-bottom: 2px solid;
    }

    .progressbar li:first-child:after {
      content: none;
    }

    .progressbar li.active {
      color:  #3d7d3d;
    }

    .progressbar li.active:before {
      border-color: green;
    }

    .progressbar li.active + li:after {
      background-color: green;
    }


        .progress_label {
            color: #fff; /* White color */
            font-family: 'Segoe UI', Arial, sans-serif; /* Segoe UI font */
            text-align: center; /* Center alignment */
            margin-top: 10px; /* Adjust spacing */
        }

    
        

    .avglabel {
            color: white;
            font-family: 'Sans-serif', Tahoma, Geneva, Verdana, sans-serif;
            position: fixed;
            font-size:large;
           
            top: 70px; 
 
    z-index: 1000;
        }

        .label1 {
    
            left: 320px; 
        }

        .label2 {
            
            left: 430px; 
        }

        .label3 {
          
             left: 850px;

        }

       

        .label4 {
            left: 990px; 
        }


        .container_complaint {
                      

                       font-family: 'Segoe UI', Helvetica, Arial, sans-serif;

                      font-weight: 100;
                      font-size: 12px;
                      line-height: 30px;
                      color: #777;
                    }

          #contact {
                      background: #F9F9F9;
                      padding: 25px;
                      width : 550px;
                      height : 400px;
                          left : 400px;
                          position: fixed;
                          top : -20px;
                      margin: 150px 0;
                      box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
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
  
        <asp:LinkButton  ID="Button2" runat="server" CssClass="active button" OnClick="StudentInfoButton_Click">
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

   

    <asp:LinkButton class="button" ID="Button6" runat="server" OnClick="ReceiveDegButton_Click">
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

 <div class="frame">
      <div class ="container_complaint" >
           <div id="contact">
     <div id="cont1" class="container_pro">
    <div class="container_progress_bar">
      <ul id="prog1" class="progressbar">
        <li class="">No Token</li>
        <li class="">Pending</li>
        <li class="" >Req Complete</li>
      </ul>
        
    </div>
  </div>


      <div id="cont2" class="container_pro">
    <div class="container_progress_bar">
      <ul class="progressbar">
        <li class="">No Token </li>
        <li class="">FYP Pending</li>
        <li class="">FYP Accepted</li>
      
      
      </ul>
        
    </div>
  </div>


      <div id="cont3" class="container_pro">
     
    <div class="container_progress_bar">
             
      <ul class="progressbar">
        <li class="">No Token </li>
        <li class="">Finance Pending</li>
        <li class="">Finance Accepted</li>
       
      </ul>
       
    </div>
  </div>
               </div>


       
</div>
     </div>

          <div class="label-container">
        <asp:Label ID="label1" runat="server" CssClass="avglabel label1" Text="Student ID:-"></asp:Label>
        <asp:Label ID="label2" runat="server" CssClass="avglabel label2" Text="0:0"></asp:Label>
        <asp:Label ID="label3" runat="server" CssClass="avglabel label3" Text="Student Name:-"></asp:Label>
        <asp:Label ID="label4" runat="server" CssClass="avglabel label4" Text="0:0"></asp:Label>
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


     
        function updateFrameContent_mainbar(id, row_count) {
           
            var listItems = document.querySelectorAll('#' + id + ' .progressbar li');

          
            for (var i = 0; i < listItems.length; i++) {
                if (i < row_count) {
                    listItems[i].classList.add('active');
                } else {
                    listItems[i].classList.remove('active');
                }
            }
        }

    </script>
         </form>
</body>
</html>
