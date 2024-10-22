<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBookShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Management System</title>
    <link href="../Assets/Lib/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">

        </div>
        <div class="row">
            <div class="col-md-4">
                
            </div>
            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div>
                        <h2 class="text-success text-center">Book Shop Management System</h2>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-8">
                                <img src="../Assets/Images/BSMS.jpg" width="90px" height="70px"/>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">User Name</label>
                        <input type="email" class="form-control" placeholder="Enter your email here" autocomplete="off" runat="server" id="uname" />
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">Password</label>
                        <input type="password" class="form-control" placeholder="Password" autocomplete="off" runat="server" id="password" />
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                        <asp:Button Text="Login" runat="server" Class="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click" />
                    </div>
                </form>
            </div>
            <div class="col-md-4">

            </div>
        </div>
    </div>
</body>
</html>
