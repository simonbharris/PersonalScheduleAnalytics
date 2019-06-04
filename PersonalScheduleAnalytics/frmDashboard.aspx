<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>

<asp:Content ID="DashboardPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="DashboardPageBody" ContentPlaceHolderID="DashboardPageBody" runat="server">
    <div class="container-fluid mt-5">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <p>
                    Dashboard Page
                </p>
                <div class="container">
                    
                    <div class="col-lg-6 pl-5">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <p>Current User Information Here!</p>
                          <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdateUsers" OnClick="LnkBtnUpdateUsers_Click" Text="Update Users" type="submit" class="btn btn-info btn-block" runat="server" PostBackUrl="~/frmUpdateUsers.aspx"> </asp:LinkButton>
                          </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                        <p>Current Category Information Here!</p>
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdateCategories" OnClick="LnkBtnUpdateCategories_Click" Text="Add or Modify Categories" type="submit" class="btn btn-success btn-block" runat="server" PostBackUrl="~/frmUpdateCategories.aspx"> </asp:LinkButton>
                            </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                        <p>Current Time Card Information Here!</p>
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdateTimeSheets" class="btn btn-success btn-block" runat="server" OnClick="LnkBtnUpdateTimeSheets_Click" Text="Add or Update Time Cards" PostBackUrl="~/frmUpdateTimeSheets.aspx"> </asp:LinkButton>
                            </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnExitApp" class="btn btn-danger btn-block" runat="server" OnClick="LnkBtnExitApp_Click" Text="Exit"> </asp:LinkButton>
                            </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>