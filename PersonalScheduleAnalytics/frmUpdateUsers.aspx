<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmUpdateUsers.aspx.cs" Inherits="frmUpdateUsers" %>

<asp:Content ID="UpdateUsersPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace col-9 border-bottom border-right">
        Your User ID cannot be changed. For all other fields type in your updates, after passing some minor validation you can press the “Save” button to commit your changes. Note: To update your picture push the “Upload“ button after navigating to the new picture.
    </p>
    <h2 class="col-3 font-weight-bold border-top">User Information</h2>
</asp:Content>

<asp:Content ID="UpdateUsersPageBody" ContentPlaceHolderID="UpdateUsersPageBody" runat="server">
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-3">
            <asp:Image ID="imgDisplayUserPic" type="image" runat="server" CssClass="col-sm-12 form-control my-1"/>
        </div>
        <div class="col-sm-9">
            <div class="row col-sm-12">
                <asp:Label ID="lblUserID" runat="server" Text="User ID:" CssClass="col-sm-4 my-1"></asp:Label>
                <asp:TextBox ID="txtUserID" runat="server" type="text" CssClass="col-sm-8 form-control my-1" readonly="true"></asp:TextBox>
           </div>
           <div class=" row col-sm-12 border-top">
                <asp:Label ID="lblUserChangePassword" runat="server" Text="Change Password:" CssClass="col-sm-4 my-1"></asp:Label>
                <asp:TextBox ID="txtUserChangePassword" runat="server" type="password" CssClass="col-sm-8 form-control my-1"></asp:TextBox>
            </div>
            <div class=" row col-sm-12">
                <asp:Label ID="lblUserVerifyPassword" runat="server" Text="Verify Password:" CssClass="col-sm-4 my-1"></asp:Label>
                <asp:TextBox ID="txtUserVerifyPassword" runat="server" type="password" CssClass="col-sm-8 form-control my-1"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row mx-auto text-monospace col-9 border-top">
        <div class=" row col-sm-11">
                <asp:Label ID="lblBlank1" runat="server" CssClass="col-sm-1 my-1"></asp:Label>
                <asp:Label ID="lblUserFirstName" runat="server" Text="First Name:" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:TextBox ID="txtUserFirstName" runat="server" type="text" CssClass="col-sm-8 form-control my-1"></asp:TextBox>
        </div>
        <div class=" row col-sm-11">
                <asp:Label ID="lblBlank2" runat="server" CssClass="col-sm-1 my-1"></asp:Label>
                <asp:Label ID="lblUserLastName" runat="server" Text="LastName:" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:TextBox ID="txtUserLastName" runat="server" type="text" CssClass="col-sm-8 form-control my-1"></asp:TextBox>
        </div>
        <div class=" row col-sm-11">
                <asp:Label ID="lblBlank3" runat="server" CssClass="col-sm-1 my-1"></asp:Label>
                <asp:Label ID="lblUserEmail" runat="server" Text="Email:" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:TextBox ID="txtUserEmail" runat="server" type="text" CssClass="col-sm-8 form-control my-1"></asp:TextBox>
        </div>
    </div>
    <div class="row mx-auto text-monospace col-9">
        <div class=" row col-sm-11">
            <asp:Label ID="lblBlank4" runat="server" CssClass="col-sm-1 my-1"></asp:Label>
            <asp:Label ID="lblUserPic" runat="server" Text="Picture:" CssClass="col-sm-3 my-1"></asp:Label>

                <div class="input-group, col-sm-8" >
                    <div class="input-group-prepend">
                        <asp:Button class="btn btn-info input-group-text" id="btnUserPicUpdate" OnClick="BtnUserPicUpdate_Click" type="submit" runat="server" Text="Upload"/>
                        <div class="custom-file"id="customFile">
                            <asp:FileUpload type="file" ID="imgUserPic" runat="server" class="custom-file-input" aria-describedby="fileHelp"/>
                            <label class="custom-file-label" for="imgUserPic">Choose file...</label>
                        </div>
                    </div>
                </div>
        </div>
    </div>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-lg-6 pl-5">
            <div class="form-group ">
                <asp:LinkButton ID="btnUserUpdate" class="btn btn-info btn-block hidden-print" runat="server" OnClick="BtnUserUpdate_Click" Text="Save"> </asp:LinkButton>
            </div>
        </div>
        <div class="col-lg-6 pl-5">
            <div class="form-group ">
                <asp:LinkButton ID="BtnCancel" class="btn btn-danger btn-block hidden-print" runat="server" OnClick="BtnCancel_Click" Text="Cancel"> </asp:LinkButton>
            </div>
        </div>
     </div>
    <div class="row mx-auto text-monospace col-9">
        <div class=" row col-sm-11">
            <asp:Label ID="lblError" runat="server" class="col-sm-12"></asp:Label>
        </div>
    </div>
</asp:Content>