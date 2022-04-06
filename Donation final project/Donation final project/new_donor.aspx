<%@ Page Title="New Donor" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form_container">

        <div class="form">
            <h1>
                Create New Donor
            </h1>
            <div class="row">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblErrorMessage" runat="server" Text="Please enter their First Name"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

