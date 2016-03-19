<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="NewsSystem.Logged_In.Categories" %>

<asp:Content ID="CategoriesContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvCategories" 
        DataKeyNames="Id"
        ItemType="Models.Category" 
        SelectMethod="gvCategories_GetData" 
        AutoGenerateColumns="false" 
        AllowPaging="true" 
        PageSize="5"
        AllowSorting="true"
        UpdateMethod="gvCategories_UpdateItem" 
        DeleteMethod="gvCategories_DeleteItem"
        runat="server">   
        <Columns>
            <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="Category" />
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />             
        </Columns>
    </asp:GridView>

    <asp:TextBox ID="tbInsertCategory" runat="server"></asp:TextBox>
    <asp:Button ID="btnInsert" Text="Insert" OnClick="btnInsert_Click" CssClass="btn btn-info" runat="server" />
    <asp:Button ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" runat="server" />
    <%--<asp:RequiredFieldValidator ErrorMessage="Category name is required" ControlToValidate="tbInsertCategory" runat="server" />--%>
</asp:Content>
