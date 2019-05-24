<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmUpdateUsers.aspx.cs" Inherits="frmUpdateUsers" %>

<asp:Content ID="UpdateUsersPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="UpdateUsersPageBody" ContentPlaceHolderID="UpdateUsersPageBody" runat="server">
    <div class="container">
        <div class="form-group w-50 mx-auto">
            
            <div class="row">
                <label id="lblUserID" class="col-sm-4" for="txtUserID">
                    User ID: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtUserID" runat="server" readonly></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblUserChangePassword" class="col-sm-4">
                    Change Password: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtUserChangePassword" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblUserVerifyPassword" class="col-sm-4">
                    Verify Password: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtUserVerifyPassword" runat="server"></asp:TextBox>
                </div>
            </div>


            <div class="row">
                <label id="lblUserFirstName" class="col-sm-4">
                    First Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtUserFirstName" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblUserLastName" class="col-sm-4">
                    Last Name: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="text" ID="txtUserLastName" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblUserEmail" class="col-sm-4">
                    Email: 
                </label>
                <div class="col-sm-8">
                    <asp:TextBox class="form-control my-1" type="email" ID="txtUserEmail" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <label id="lblUserPic" class="col-sm-4" runat="server" >
                    Picture: 
                </label>
                <div class="custom-file, col-sm-8" id="customFile" lang="es">
                    <asp:FileUpload type="file" ID="imgUserPic" runat="server" class="custom-file-input" aria-describedby="fileHelp"/>
                    <label class="custom-file-label" for="imgUserPic" >Choose file...</label>
                </div>
            </div>
            <br />
            <asp:Button ID="btnUserUpdate" OnClick="BtnUserUpdate_Click" Text="Save" type="submit" class="btn btn-info btn-block" runat="server" />
            <asp:Button ID="BtnCancel" OnClick="BtnCancel_Click" Text="Cancel" type="submit" class="btn btn-danger btn-block" runat="server" />
            <br />
            <asp:Label ID="lblError" runat="server" class="col-sm-4"></asp:Label>
        </div>
    </div>
</asp:Content>