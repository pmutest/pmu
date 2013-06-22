<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PMU.Home"  MasterPageFile="~/PMUp.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Place Script and CSS here --%>
    <%--<script src="Scripts/Home.js" type="text/javascript"></script>--%>
    <script src="Scripts/HomePageValidation.js" type="text/javascript"></script>
    <link href="Styles/CommonStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .linkCreateResume
     {
         margin-right:8px;
     }
     .navbar-inner .container
     {
         width:918px;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="signUpAreaAndAddBox">
        <div class="container">
<%--            <div class="divSiteMessageArea pull-left">
                <h1>Welcome to bootstrap</h1>
                <p class="tagLine">Easy way to create and share your resume with the world.......It's completely free</p>
                <p>
                    <a class="linkCreateResume btn btn-primary btn-large"><i class="icon-file icon-white"></i>Let's Create test now </a><span></span>
                    <a class="btn btn-primary btn-large"><i class="icon-file icon-white"></i>Review your css </a>
                </p>s
            </div>--%>
            <ul class="signUpBox nav pull-right">
                <li><span class="spanSignUpUserNameErrMsg"></span></li>
                <li><asp:Label ID="userNameErrMsg" runat="Server"></asp:Label></li>
                <li><input type="text" runat="server" id="txtUserName" class="signUpUserName" placeholder="Pick a username" /></li>
                <li><span class="spanSignUpEmailAdd"></span></li>
                <li><input type="text" runat="server" id="txtEmailAdd" class="signUpEmailAdd"  placeholder="Your email" /></li>
                <li><span class="spanSignUpPaswd"></span></li>
                <li><input type="password" runat="server" id="txtSignUpPassword" class="signUpPaswd" placeholder="Create a password" /></li>
                <li><span class="spanSignUpConfPaswd"></span></li>
                <li><input type="password" runat="server" id="txtConfPassword" class="signUpConfPaswd" placeholder="Confirm your password" /></li>
                <li><asp:Button ID="btnSignUp" runat="server" CssClass="btnSignUp btn btn-success btn-large" OnClick="btnSignUp_Click"  OnClientClick="return signUpvalidate();" Text="Sign up for free" /></li>
                
            </ul>
        </div>
        
    </div>
    <%--    <span id="signinButton"><span class="g-signin" data-callback="signinCallback" data-clientid="633669750818.apps.googleusercontent.com"
        data-cookiepolicy="single_host_origin" data-requestvisibleactions="http://schemas.google.com/AddActivity"
        data-scope="https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile">
    </span></span><span id="revokeButton" style="display: none">Log out</span>--%>
</asp:Content>
