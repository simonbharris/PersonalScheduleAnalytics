<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="CreateUserAccount.aspx.cs" Inherits="CreateUserAccount" %>
<asp:Content ID="CreateUserAccountPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        Sign up today!
    </p>
 </asp:Content>
<asp:Content ID="CreateUserAccountBody" ContentPlaceHolderID="CreateUserAcct" runat="server">
    <div class="container">
        <div class="form-group w-50 mx-auto">
            <div class="row">
                <label id="lblNewUserName" class="col-sm-4">
                    User ID: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtNewUserID" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblNewPassword" class="col-sm-4">
                    Password: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="password" ID="txtNewUserPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label id="lblVerifyNewPassword" class="col-sm-4">
                    Verify Password:
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="password" ID="txtVerifyNewUserPassword" runat="server"></asp:TextBox>
                </div>

            </div>
            
            <div class="row">
                <label id="lblNewUserFirstName" class="col-sm-4">
                    First Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtNewUserFirstName" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblNewUserLastName" class="col-sm-4">
                    Last Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtNewUserLastName" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblNewUserEmail" class="col-sm-4">
                    Email: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="email" ID="txtNewUserEmail" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblNewUserPic" class="col-sm-4" runat="server" >
                    Picture: 
                </label>
                <div class="custom-file, col-sm-8" id="customFile" lang="es">
                    <asp:FileUpload type="file" ID="imgNewUserPic" runat="server" class="custom-file-input" aria-describedby="fileHelp"/>
                    <label class="custom-file-label" for="imgNewUserPic" >Choose file...</label>
                </div>
            </div>

            <br />
            <asp:Button ID="btnUserAccountCreate" OnClick="BtnUserAccountCreate_Click" Text="Create Account" type="submit" class="btn btn-info btn-block" runat="server" />
            <br />
            <asp:Label ID="lblError" runat="server" class="col-sm-4"></asp:Label>
        </div>
    </div>
</asp:Content>

