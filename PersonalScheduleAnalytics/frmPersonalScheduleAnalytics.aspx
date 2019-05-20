<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmPersonalScheduleAnalytics.aspx.cs" Inherits="frmPersonalScheduleAnalytics" %>


<asp:Content ID="LoginPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="LoginPageBody" ContentPlaceHolderID="LoginPageBody" runat="server">
    <div class="container-fluid mt-5">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <p>
                    Have an account? Log in here
                </p>
                <div class="container">
                    <div class=" w-50 form-group ">
                        <div class="row">
                            <label id="lblUserName" class="col-sm-4">
                                User Name: 
                            </label>
                            <div class="col-sm-8">
                                <asp:TextBox class="form-control my-1" ID="txtUserID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <label id="lblPassword" class="col-sm-4">
                                Password: 
                            </label>
                            <div class="col-sm-8">
                                <asp:TextBox class="form-control my-1" runat="server"></asp:TextBox>
                            </div>

                        </div>

                        <asp:Button ID="btnUserLogin" OnClick="btnUserLogin_Click" Text="User Login" type="submit" class="btn btn-info btn-block" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-lg-6 pl-5">
                <p>New? Sign up here</p>
                <div>
                    <div class=" w-50 form-group ">
                        <asp:Button ID="btnUserCreate" class="btn btn-success btn-block" runat="server" OnClick="btnUserCreate_Click" Text="Register" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%--User ID&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPasswordID" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnUserLogin" runat="server" OnClick="btnUserLogin_Click" Text="User Login" />
<asp:Button ID="btnUserCreate" runat="server" OnClick="btnUserCreate_Click" Text="Register" />
<br />--%>