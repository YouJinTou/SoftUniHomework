<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Articles.aspx.cs" Inherits="NewsSystem.Auth.Articles" %>

<asp:Content ID="ArticlesContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="lvArticles"
        ItemType="Models.Article"
        SelectMethod="lvArticles_GetData"
        DataKeyNames="Id"
        UpdateMethod="lvArticles_UpdateItem"
        DeleteMethod="lvArticles_DeleteItem"
        InsertMethod="lvArticles_InsertItem"
        InsertItemPosition="None"
        runat="server">
        <LayoutTemplate>
            <%-- A dictionary is to be preferred --%>
            <asp:HyperLink NavigateUrl="?orderBy=Title" Text="Sort by Title" CssClass="btn btn-default btn-md-2" runat="server" />
            <asp:HyperLink NavigateUrl="?orderBy=DateCreated" Text="Sort by Date" CssClass="btn btn-default btn-md-2" runat="server" />
            <asp:HyperLink NavigateUrl="?orderBy=Category.Name" Text="Sort by Category" CssClass="btn btn-default btn-md-2" runat="server" />
            <asp:HyperLink NavigateUrl="?orderBy=Likes" Text="Sort by Likes" CssClass="btn btn-default btn-md-2" runat="server" />
            <div id="itemPlaceholder" runat="server"></div>
            <div>
                <asp:DataPager PageSize="2" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ShowPreviousPageButton="true" ShowNextPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" />
                    </Fields>
                </asp:DataPager>
            </div>
            <asp:Button ID="btnInsertArticle" Text="Insert Article" CssClass="btn btn-info pull-right" OnClick="btnInsertArticle_Click" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <h3>
                <%#: Item.Title %>
                <asp:Button Text="Edit" CommandName="Edit" CssClass="btn btn-info" runat="server" />
                <asp:Button Text="Delete" CommandName="Delete" CssClass="btn btn-danger" runat="server" />
            </h3>
            <h4>
                <small>Category: <%#: Item.Category.Name %></small>
            </h4>
            <p><%#: Item.Content.Length > 300 ? Item.Content.Substring(0, 300) + "..." : Item.Content %></p>
            <p>
                <strong>Likes: <%#: Item.Likes %></strong>
            </p>
            <div>
                Created on: <i><%#: Item.DateCreated %></i> by <i><%#: Item.Author.UserName %></i>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <h3>
                <asp:TextBox ID="tbEditTitle" Text="<%#: BindItem.Title %>" runat="server" />
                <asp:Button ID="btnSave" Text="Save" CommandName="Update" CssClass="btn btn-success" runat="server" />
                <asp:Button ID="btnCancel" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" runat="server" />
            </h3>
            <h4>
                <small>Category:
                    <asp:DropDownList ID="ddlCategories"
                        DataValueField="Id"
                        DataTextField="Name"
                        ItemType="Models.Category"
                        SelectMethod="ddlCategories_GetData"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        runat="server">
                    </asp:DropDownList>
                </small>
            </h4>
            <asp:TextBox ID="tbEditContent" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Rows="6" Width="100%" runat="server"></asp:TextBox>
            <div>
                Created on: <i><%#: Item.DateCreated %></i> by <i><%#: Item.Author.UserName %></i>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <hr />
            <h3>Title:
                <asp:TextBox ID="tbInsertTitle" Text="<%#: BindItem.Title %>" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Title is mandatory" ControlToValidate="tbInsertTitle" runat="server" />
            </h3>
            <h4>Category:
                    <asp:DropDownList ID="ddlInsertCategories"
                        DataValueField="Id"
                        DataTextField="Name"
                        ItemType="Models.Category"
                        SelectMethod="ddlCategories_GetData"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        runat="server">
                    </asp:DropDownList>
                </>
            </h4>
            <p>
                <h4>Content</h4>
                <asp:TextBox ID="tbInsertContent" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Rows="6" Width="40%" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="btnInsert" Text="Insert" CommandName="Insert" CssClass="btn btn-success" runat="server" />
            <asp:Button ID="btnCancelInsert" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" runat="server" />
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
