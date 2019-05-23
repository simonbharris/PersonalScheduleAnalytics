<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="CreateUserAccount.aspx.cs" Inherits="CreateUserAccount" %>

<asp:Content ID="LoginPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        Sign up today!
    </p>
</asp:Content>
<asp:Content ID="CreateUserAccountBody" ContentPlaceHolderID="CreateUserAcct" runat="server">
    <div class="container">
        <div class="form-group w-50 mx-auto">
            <div class="row">
                <label id="lblNewUserName" class="col-sm-4">
                    User Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtNewUserID" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label id="lblNewPassword" class="col-sm-4">
                    Password: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtNewUserPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label id="lblVerifyNewPassword" class="col-sm-4">
                    Verify Password: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtVerifyNewUserPassword" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="row">
                <label id="lblNewUserEmail" class="col-sm-4">
                    Email: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtNewUserEmail" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblNewUserFirstName" class="col-sm-4">
                    First Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtNewUserFirstName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label id="lblNewUserLastName" class="col-sm-4">
                    Last Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" ID="txtNewUserLastName" runat="server"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnUserAccountCreate" OnClick="BtnUserAccountCreate_Click" Text="Create Account" type="submit" class="btn btn-info btn-block" runat="server" />
        </div>
    </div>
</asp:Content>
