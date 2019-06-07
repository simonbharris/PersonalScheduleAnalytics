<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="DashboardPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="DashboardPageBody" ContentPlaceHolderID="DashboardPageBody" runat="server">
    <div class="container-fluid">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <h1>Welcome <span  ID="usernameLabel" runat="server"></span></h1>
                <p>
                    Dashboard Page
                </p>
                <div class="container">
                    
                    <div class="col-lg-6 pl-5">
                        <p>Current User Information Here!</p>
                          <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdateUsers" OnClick="LnkBtnUpdateUsers_Click" Text="Update Users" type="submit" class="btn btn-info btn-block" runat="server"></asp:LinkButton>
                          </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                        <p>Current Category Information Here!</p>
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdateCategories" OnClick="LnkBtnUpdateCategories_Click" Text="Add or Modify Categories" type="submit" class="btn btn-success btn-block" runat="server" PostBackUrl="~/frmEditCategories.aspx"></asp:LinkButton>
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
                                <asp:LinkButton ID="lnkBtnExitApp" class="btn btn-danger btn-block" runat="server" OnClick="LnkBtnExitApp_Click" Text="Exit" PostBackUrl="~/frmLoginPage.aspx"> </asp:LinkButton>
                            </div>
                    </div>
            <div class="col-lg-6 pl-5 mx-auto mb-3">
                <h1 class="text-center">User Dashboard</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="list-group mt-5 w-75">
                    <label>Welcome <span id="usernameLabel" runat="server"></span></label>
                    <asp:LinkButton class="list-group-item list-group-item-action list-group-item-primary" OnClick="LnkBtnUpdateUsers_Click" runat="server" ID="lnkBtnUpdateUsers" PostBackUrl="~/frmUpdateUsers.aspx" data-toggle="tooltip" data-placement="right" title="Update Your User Information Here">Update User</asp:LinkButton>

                    <asp:LinkButton runat="server" ID="lnkBtnUpdateCategories" OnClick="LnkBtnUpdateCategories_Click" PostBackUrl="~/frmUpdateCategories.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Update or Add Category Items">Add or Modify Categories</asp:LinkButton>

                    <asp:LinkButton runat="server" ID="lnkBtnUpdateTimeSheets" PostBackUrl="~/frmUpdateTimeSheets.aspx" class="list-group-item list-group-item-action list-group-item-primary" data-toggle="tooltip" data-placement="right" title="Update Your Time Card Data">Add or Update Time Cards</asp:LinkButton>

                    <asp:LinkButton runat="server" OnClick="LnkBtnExitApp_Click" PostBackUrl="~/frmLoginPage.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Securely Logout Here">Exit</asp:LinkButton>
                </div>
            </div>
            
            <div class="col-6 mt-4">
                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1">
                            <Points>
                            </Points>
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Title="Task Name">
                            </AxisX>
                            <AxisY Title="Time Spent"></AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <div class="btn-group">
                    <asp:Button class="btn btn-danger" runat="server" OnClick="GetDayChartData" Text="Day Chart" />
                    <asp:Button class="btn btn-danger" runat="server" OnClick="GetWeekChartData" Text="Week Chart" />
                    <asp:Button class="btn btn-danger" runat="server" Text="Month Chart" />
                </div>

            </div>
        </div>


    </div>
</asp:Content>
