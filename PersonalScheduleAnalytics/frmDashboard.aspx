<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="DashboardPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        Welcome to your dashboard. From here you can manage your categories, access your time card, make a new time entry, and view your time analytics. 
    </p>
</asp:Content>

<asp:Content ID="DashboardPageBody" ContentPlaceHolderID="DashboardPageBody" runat="server">
    <div class="container-fluid">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 mx-auto">
                <h1 class="text-center">User Dashboard</h1>
            </div>
        </div>

        <div class="row mt-1">

            <div class="col-sm d-flex">
                <div class="card">
                    <div class="card-header text-white bg-secondary text-center">
                        Update Your Time
                    </div>
                    <div class="card-body bg-light flex-fill">
                        <div class="form-group row">
                            <label class="col-4 my-1">Category</label>
                            <asp:dropdownlist autopostback="false" causesvalidation="false" id="dropdownCategoryTypes" runat="server" class="form-control col-8 my-1"></asp:dropdownlist>
                            <label class="col-4 my-1">Start Date:</label>
                            <asp:textbox runat="server" id="catStartDate" type="date" class="form-control col-8 my-1" value="2019-06-01"></asp:textbox>
                            <label class="col-4 my-1">Start Time</label>
                            <asp:textbox runat="server" id="catStartTime" type="time" class="form-control col-8 my-1"></asp:textbox>
                            <label class="col-4 my-1">End Date:</label>
                            <asp:textbox runat="server" id="catEndDate" type="date" class="form-control col-8 my-1" value="2019-06-01"></asp:textbox>
                            <label class="col-4 my-1">End Time</label>
                            <asp:textbox runat="server" type="time" id="catEndTime" class="form-control col-8 my-1"></asp:textbox>
                            <asp:button runat="server" id="submitCategoryTimeButton" text="Submit" class="btn btn-info mx-auto mt-2 btn-block" onclick="submitNewCategoryTime" />
                            <p id="catMessageText" runat="server" class="mx-auto mt-3 text-danger font-weight-bolder"></p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm d-flex">
                <div class="card d-flex w-100 ">
                    <div class="card-header text-white bg-secondary text-center">
                        Welcome <span id="usernameLabel" runat="server"></span>
                    </div>
                    <div class="card-body bg-light flex-fill">
                        <div class="list-group mt-1">
                            <asp:linkbutton class="list-group-item list-group-item-action list-group-item-primary" onclick="LnkBtnUpdateUsers_Click" runat="server" id="lnkBtnUpdateUsers" postbackurl="~/frmUpdateUsers.aspx" data-toggle="tooltip" data-placement="right" title="Update Your User Information Here">Update User</asp:linkbutton>

                            <asp:linkbutton runat="server" id="lnkBtnUpdateCategories" onclick="LnkBtnUpdateCategories_Click" postbackurl="~/frmUpdateCategories.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Update or Add Category Items">Add or Modify Categories</asp:linkbutton>

                            <asp:linkbutton runat="server" id="lnkBtnUpdateTimeSheets" postbackurl="~/frmUpdateTimeSheets.aspx" class="list-group-item list-group-item-action list-group-item-primary" data-toggle="tooltip" data-placement="right" title="Update Your Time Card Data">Add or Update Time Cards</asp:linkbutton>

                            <asp:linkbutton runat="server" onclick="LnkBtnExitApp_Click" postbackurl="~/frmLoginPage.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Securely Logout Here">Exit</asp:linkbutton>
                            <div class="list-group-item list-group-item-action list-group-item-primary">
                                <div class="form-group row">
                                    <label class="col-6">Chart Date</label>
                                    <asp:textbox runat="server" id="Textbox1" type="date" class="form-control col-6" value="2019-06-01"></asp:textbox>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-sm d-flex ">
                <div class="card ">
                    <div class="card-header text-white bg-secondary text-center">
                        Your Time Analytics
                    </div>
                    <div class="card-body justify-content-center bg-light flex-fill">
                        <label>Stats for the day of Jun 9, 2019</label>
                        <asp:chart id="Chart1" runat="server">
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
                        </asp:chart>
                        <div class="btn-group ">
                            <asp:button class="btn btn-secondary" runat="server" onclick="GetDayChartData" text="Day Chart" />
                            <asp:button class="btn btn-secondary" runat="server" onclick="GetWeekChartData" text="Week Chart" />
                            <asp:button class="btn btn-secondary" runat="server" text="Month Chart" onclick="GetMonthChartData" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
