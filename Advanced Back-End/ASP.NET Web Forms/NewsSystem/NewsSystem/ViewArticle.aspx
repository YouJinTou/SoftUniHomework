<%@ Page Title="Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystem.ViewArticle" %>

<asp:Content ID="ViewArticleContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="fvArticle" ItemType="Models.Article" SelectMethod="fvArticle_GetData" runat="server">
        <ItemTemplate>
            <div>
                <div class="like-control col-md-1">
                    <div>Likes</div>
                    <div>
                        <a class="btn btn-default glyphicon glyphicon-chevron-up" href="#"></a>
                            <span class="like-value"><%# Item.Likes %></span>
                        <a class="btn btn-default glyphicon glyphicon-chevron-down" href="#"></a>
                    </div>
                </div>
            </div>
            <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
            <p><%#: Item.Content %></p>
            <p>
                <span>Author: <strong><%#: Item.Author.UserName %></strong></span>
                <span class="pull-right"><%#: Item.DateCreated %></span>
            </p>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
