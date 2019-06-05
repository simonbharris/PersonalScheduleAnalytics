<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmUpdateTimeSheets.aspx.cs" Inherits="frmUpdateTimeSheets" %>

<asp:Content ID="UpdateTimeSheetsPageHeader" ContentPlaceHolderID="PageHeader" runat="server" >
    <p class="mx-auto text-monospace col-9 border-bottom border-right">
        Directions:  Each week each team is required to complete the attached time sheet and send it to the Project Team lead for verification.  Once verified the Project Team lead will post all the team's time sheets.
    </p>
    <h2 class="col-3 font-weight-bold border-top">TIMECARD</h2> 
</asp:Content>
<asp:Content ID="UpdateTimeSheetsPageBody" ContentPlaceHolderID="UpdateTimeSheetsPageBody" runat="server">
    <%--Team Member--%>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-8">
            <h4 class="col-sm-12 border-top border-bottom">Team Member</h4>
        </div>
        <div class="col-sm-4">
            <h4 class="col-sm-12 border-bottom border-right">Miscellaneous</h4>
        </div>
    </div>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-8">
            <div class="row col-sm-12">
                <asp:Label ID="lblUserName" runat="server" Text="Name" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:TextBox ID="txtUserName" runat="server" type="text" CssClass="col-sm-9 form-control my-1" readonly="true"></asp:TextBox>
           </div>
           <div class=" row col-sm-12">
                <asp:Label ID="lblProjectTeam" runat="server" Text="Project Team" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:TextBox ID="txtProjectTeam" runat="server" type="text" CssClass="col-sm-9 form-control my-1"></asp:TextBox>
            </div>
            <div class=" row col-sm-12">
                <asp:Label ID="lblTeamLead" runat="server" Text="Team Lead" CssClass="col-sm-3 my-1"></asp:Label>
                <asp:DropDownList ID="ddlTeamLead" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlTeamLead_SelectedIndexChanged" type="text" CssClass="col-sm-9 form-control my-1"></asp:DropDownList>
            </div>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txtSheetMisc" TextMode="MultiLine" type="text" rows="4" runat="server" CssClass="col-sm-12 form-control my-1"></asp:TextBox>
        </div>
    </div>
    <%--Development Week--%>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-8">
            <h4 class="col-sm-12 border-top border-bottom">Development Week</h4>
        </div>
        <div class="col-sm-4">
            <h4 class="col-sm-12 border-bottom border-right" >Approved By</h4>
        </div>
    </div>
     <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-8">
            <div class="row col-sm-12">
                <p Class="col-sm-1"></p>
                <asp:Label ID="lblFrom" runat="server" Text="From" CssClass="col-sm-2 my-1"></asp:Label>
                <asp:TextBox ID="txtSheetStartDt" runat="server" type="date" CssClass="col-sm-4 form-control my-1" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="txtSheetStartDt_SelectedIndexChanged"></asp:TextBox>
                <asp:Label ID="lblTo" runat="server" Text="To" CssClass="col-sm-1 my-1"></asp:Label>
                <asp:TextBox ID="txtSheetEndDt" runat="server" type="date" CssClass="col-sm-4 form-control my-1" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="txtSheetEndDt_SelectedIndexChanged"></asp:TextBox>
           </div>
        </div>

        <div class="col-sm-4">
            <asp:TextBox ID="txtApprovedBy" type="text" runat="server" CssClass="col-sm-12 form-control my-1"></asp:TextBox>
        </div>
    </div>
    <%--Work Description--%>
    <div class="row mx-auto text-monospace col-8">
        <asp:GridView ID="gridWorkDescription" runat="server" AllowPaging="true" PageSize="17" CssClass="table table-responsive table-hover">
            <HeaderStyle CssClass="thead-dark"/>
        </asp:GridView>
    </div>
    <%--Notes and Remarks--%>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-12">
            <h4 class="col-sm-12 border-bottom border-right" >Notes and Remarks</h4>
        </div>
    </div>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-sm-12">
            <asp:TextBox ID="txtSheetNote" TextMode="MultiLine" type="text" rows="3" runat="server" CssClass="col-sm-12 form-control my-1"></asp:TextBox>
        </div>
    </div>
    <%--Buttons--%>
    <div class="row mx-auto text-monospace col-9">
        <div class="col-lg-4 pl-5">
            <div class="form-group ">
                <asp:LinkButton ID="BtnUpdate" class="btn btn-info btn-block hidden-print" runat="server" OnClick="LnkBtnUpdate_Click" Text="Save"> </asp:LinkButton>
            </div>
        </div>
        <div class="col-lg-4 pl-5">
            <div class="form-group ">
                <asp:LinkButton ID="BtnPrint" class="btn btn-success btn-block hidden-print" runat="server" OnClientClick="javascript:window.print();" Text="Print"> </asp:LinkButton>
            </div>
        </div>
        <div class="col-lg-4 pl-5">
            <div class="form-group ">
                <asp:LinkButton ID="BtnCancel" class="btn btn-danger btn-block hidden-print" runat="server" OnClick="LnkBtnCancel_Click" Text="Cancel" PostBackUrl="~/frmDashboard.aspx"> </asp:LinkButton>
            </div>
        </div>
     </div>
</asp:Content>