<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="frmAddCategory.aspx.cs" Inherits="frmAddCategories" %>

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
                    Add a new category
                </p>
                <div class="container">
                    
                    <div class="col-lg-6 pl-5">
                        <p>Category Name<asp:TextBox ID="txbxCatName" runat="server"></asp:TextBox>
                        </p>
                        <p>Category Description<asp:TextBox ID="txbxCatDesc" runat="server" Height="135px" Width="325px"></asp:TextBox>
                        </p>
                          <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnUpdate" class="btn btn-info btn-block" runat="server" OnClick="LnkBtnAdd_Click" Text="Add Category"></asp:LinkButton>
                          </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                            <div class=" w-50 form-group ">
                                <asp:LinkButton ID="lnkBtnCancel" class="btn btn-danger btn-block" runat="server" OnClick="LnkBtnCancel_Click" Text="Cancel" PostBackUrl="~/frmEditCategories.aspx"></asp:LinkButton>
                            </div>
                    </div>

                    <div class="col-lg-6 pl-5">
                            <div class=" w-50 form-group ">
                            </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>