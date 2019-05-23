<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmUpdateUsers.aspx.cs" Inherits="frmUpdateUsers" %>

<asp:Content ID="UpdateUsersPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="UpdateUsersPageBody" ContentPlaceHolderID="UpdateUsersPageBody" runat="server">
    <div class="container-fluid mt-5">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <p>
                    Update Users Page
                </p>
                <div class="container">
                    
                    <div class="col-lg-6 pl-5">
                        <p>Current Category Information Here!</p>
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdate" class="btn btn-success btn-block" runat="server" OnClick="LnkBtnUpdate_Click" Text="Save" PostBackUrl="~/frmDashboard.aspx"> </asp:LinkButton>
                            </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnCancel" class="btn btn-danger btn-block" runat="server" OnClick="LnkBtnCancel_Click" Text="Cancel" PostBackUrl="~/frmDashboard.aspx"> </asp:LinkButton>
                            </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>