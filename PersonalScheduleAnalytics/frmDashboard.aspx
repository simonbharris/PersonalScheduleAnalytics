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
                            <asp:DropDownList AutoPostBack="false" CausesValidation="false" ID="dropdownCategoryTypes" runat="server" class="form-control col-8 my-1"></asp:DropDownList>
                            <label class="col-4 my-1">Start Date:</label>
                            <asp:TextBox runat="server" ID="catStartDate" type="date" class="form-control col-8 my-1" value="2019-06-01"></asp:TextBox>
                            <label class="col-4 my-1">Start Time</label>
                            <asp:TextBox runat="server" ID="catStartTime" type="time" class="form-control col-8 my-1"></asp:TextBox>
                            <label class="col-4 my-1">End Date:</label>
                            <asp:TextBox runat="server" ID="catEndDate" type="date" class="form-control col-8 my-1" value="2019-06-01"></asp:TextBox>
                            <label class="col-4 my-1">End Time</label>
                            <asp:TextBox runat="server" type="time" ID="catEndTime" class="form-control col-8 my-1"></asp:TextBox>
                            <asp:Button runat="server" ID="submitCategoryTimeButton" Text="Submit" class="btn btn-info mx-auto mt-2 btn-block" OnClick="submitNewCategoryTime" />
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
                            <asp:LinkButton class="list-group-item list-group-item-action list-group-item-primary" OnClick="LnkBtnUpdateUsers_Click" runat="server" ID="lnkBtnUpdateUsers" PostBackUrl="~/frmUpdateUsers.aspx" data-toggle="tooltip" data-placement="right" title="Update Your User Information Here">Update User</asp:LinkButton>

                            <asp:LinkButton runat="server" ID="lnkBtnUpdateCategories" OnClick="LnkBtnUpdateCategories_Click" PostBackUrl="~/frmUpdateCategory.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Update or Add Category Items">Add or Modify Categories</asp:LinkButton>

                            <asp:LinkButton runat="server" ID="lnkBtnUpdateTimeSheets" PostBackUrl="~/frmUpdateTimeSheets.aspx" class="list-group-item list-group-item-action list-group-item-primary" data-toggle="tooltip" data-placement="right" title="Update Your Time Card Data">Add or Update Time Cards</asp:LinkButton>

                            <asp:LinkButton runat="server" OnClick="LnkBtnExitApp_Click" PostBackUrl="~/frmLoginPage.aspx" class="list-group-item list-group-item-action list-group-item-secondary" data-toggle="tooltip" data-placement="right" title="Securely Logout Here">Exit</asp:LinkButton>
                            <div class="list-group-item list-group-item-action list-group-item-primary">
                                <div class="form-group row">
                                    <label class="col-6">Chart Date</label>
                                    <asp:TextBox runat="server" id="chartDateTextBox" type="date" class="form-control col-6" />
                                    <asp:Button runat="server" ID="chartDateButton" Text="Get Analytics" class="btn btn-info mx-auto mt-2 btn-block " OnClick="GetDayChartData" AutoPostBack="false" />
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
                        <label id="statsLabel" runat="server">Stats for the </label>
                        <asp:Chart ID="Chart1" runat="server">
                            <Series>
                                <asp:Series Name="Series1">
                                    <Points>
                                    </Points>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisX>
                                    </AxisX>
                                    <AxisY></AxisY>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <div class="btn-group " id="chartButtonGroup" runat="server">
                            <asp:Button class="btn btn-secondary" runat="server" OnClick="GetDayChartData" Text="Day Chart" />
                            <asp:Button class="btn btn-secondary" runat="server" OnClick="GetWeekChartData" Text="Week Chart" />
                            <asp:Button class="btn btn-secondary" runat="server" Text="Month Chart" OnClick="GetMonthChartData" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
