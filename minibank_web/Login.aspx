﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="minibank_web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link rel="stylesheet" href="~/Content/loginstyle.css" />
 <title></title>
</head>
 
<body>
<div class="login">
  <h1>Login to Minibank</h1>
 
  <form method="post" enctype="multipart/form-data" asp-controller="Home" asp-action="Index" runat="server">
    <p><input type="text" name="username" value="" placeholder="Username or Email" required="required"/></p>     
    <p><input type="password" name="passcode" value="" placeholder="Password" required="required"/></p>     
    <p class="remember_me">
      <label>
        <input type="checkbox" name="remember_me" id="remember_me"/>
        Remember me on this computer
      </label>
    </p>
    <p class="submit"><input type="submit" name="commit" value="Login"/></p>
    <hr/>  
  </form>
</div> 
</body>
</html>