<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="PetShop.Controls.Categories" %>

<% foreach (var cat in GetCategories())
    {
        Response.Write(CreateLink(cat));
    }
     %>