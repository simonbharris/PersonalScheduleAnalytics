<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmEditCategories.aspx.cs" Inherits="frmEditCategories" %>

<asp:Content ID="UpdateCategoriesPageHeader" ContentPlaceHolderID="PageHeader" runat="server">
    <p class="mx-auto text-monospace w-50">
        Personalize your time analytics by creating your own categories. Add or update your categories here.
    </p>
</asp:Content>

<asp:Content ID="UpdateCategoriesPageBody" ContentPlaceHolderID="UpdateCategoriesPageBody" runat="server">
    <div class="container-fluid mt-5">
        <div class="row mx-auto">
            <div class="col-lg-6 pl-5 ">
                <h1>Add or Update Categories
                </h1>
                <div class="col-lg-6 pl-5 mb-2">
                    <label>Your Categories</label><br />
                    <asp:listbox id="lstCategoryNames" runat="server"></asp:listbox>
                </div>

                <div class="col-lg-6 pl-5">
                    <div class=" w-50 form-group ">
                        <asp:linkbutton id="lnkBtnUpdate" class="btn btn-info btn-block rounded-1" runat="server" onclick="LnkBtnUpdate_Click" text="Update"></asp:linkbutton>
                    </div>
                </div>

                <div class="col-lg-6 pl-5">
                    <div class=" w-50 form-group ">
                        <asp:linkbutton id="lnkBtnAdd" class="btn btn-secondary btn-block  rounded-1" runat="server" onclick="LnkBtnAdd_Click" text="Add" postbackurl="~/frmAddCategory.aspx"></asp:linkbutton>
                    </div>
                </div>

                <div class="col-lg-6 pl-5">
                    <div class=" w-50 form-group ">
                        <asp:linkbutton id="lnkBtnDelete" class="btn btn-secondary btn-block shadow-sm rounded-1" runat="server" text="Remove" onclick="lnkBtnDelete_Click"></asp:linkbutton>
                    </div>
                </div>

                <div class="col-lg-6 pl-5">
                    <div class=" w-50 form-group ">
                        <asp:linkbutton id="lnkBtnCancel" class="btn btn-danger btn-block rounded-1" runat="server" onclick="LnkBtnCancel_Click" text="Cancel" postbackurl="~/frmDashboard.aspx"> </asp:linkbutton>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
