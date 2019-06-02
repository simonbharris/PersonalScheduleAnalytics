<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmUpdateCategories.aspx.cs" Inherits="frmUpdateCategories" %>

<asp:Content ID="UpdateCategoriesPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        The first step in optimizing your schedule is knowing how you spend
          your time. That's where we come in. Start tracking your time today.
    </p>
</asp:Content>

<asp:Content ID="UpdateCategoriesPageBody" ContentPlaceHolderID="UpdateCategoriesPageBody" runat="server">
    <div class="container-fluid mt-5">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <p>
                    Add or Update Categories Page
                </p>
                <div class="container">
                    
                    <div class="col-lg-6 pl-5">
                        <p>Category Lables and Text Boxes Here!</p>
                          <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdate" class="btn btn-info btn-block" runat="server" OnClick="LnkBtnUpdate_Click" Text="Update" PostBackUrl="~/frmDashboard.aspx"> </asp:LinkButton>
                          </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnAdd" class="btn btn-success btn-block" runat="server" OnClick="LnkBtnAdd_Click" Text="Add" PostBackUrl="~/frmDashboard.aspx"> </asp:LinkButton>
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