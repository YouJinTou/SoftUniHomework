<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>News</h1>
    <h2>Most Popular News</h2>

    <asp:Repeater ID="repeaterArticle" ItemType="Models.Article" SelectMethod="repeaterArticle_GetData" runat="server">
        <ItemTemplate>
            <h4>
                <a href="ViewArticle.aspx?id=<%# Item.Id %>"><%#: Item.Title %></a>
                <small><%#: Item.Category.Name %></small>
            </h4>
            <p><%#: Item.Content %></p>
            <p>Likes: <%#: Item.Likes %></p>
            <div>
                Created on: <i><%#: Item.DateCreated %></i> by <i><%#: Item.Author.UserName %></i>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ListView ID="lvCategories" ItemType="Models.Category" SelectMethod="lvCategories_GetData" runat="server">
        <LayoutTemplate>
            <h2>All Categories</h2>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView ID="lvCategoryArticles" ItemType="Models.Article" DataSource="<%# lvCategoryArticles_GetData(Item.Name) %>" runat="server">
                    <LayoutTemplate>
                        <ul id="itemPlaceholder" runat="server">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="ViewArticle.aspx?id=<%# Item.Id %>">
                                <strong><%#: Item.Title %></strong>
                                <i>by <%#: Item.Author.UserName %></i>
                            </a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <span>No articles</span>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
