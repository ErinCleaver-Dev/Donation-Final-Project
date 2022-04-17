<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="New_donor.aspx.vb" Inherits="Donation_final_project.New_Donor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form_container">

        <div class="form">
            <h1 class="text-center">
                Create New Donor
            </h1>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtFirstName" runat="server"></asp:TextBox>
                </div>
                <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblerrorFirstName" runat="server" Text="Please enter their First Name"></asp:Label>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label1" runat="server" Text="Last Name:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtLastName" runat="server"></asp:TextBox>
                </div>
                <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblerrorLastName" runat="server" Text="Please enter their Last Name Name"></asp:Label>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label3" runat="server" Text="Business Name:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtBusinessName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label5" runat="server" Text="Phone number:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label7" runat="server" Text="Address:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtAddress" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label8" runat="server" Text="Email:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:Label CssClass="col-form-label pb-2 text-center" ID="Label9" runat="server" Text="Donor Type"></asp:Label>
            <asp:DropDownList class="form-control item_list pb-2" ID="type" runat="server">
                <asp:ListItem>Business</asp:ListItem>
                <asp:ListItem>Person</asp:ListItem>
                <asp:ListItem>Organization</asp:ListItem>
                <asp:ListItem>Fundation</asp:ListItem>
            </asp:DropDownList>
            <div class="center-button">
                <asp:Button CssClass="btn btn-primary mt-2 submit_button" ID="bntAddDonor" runat="server" Text="Add Donor"/>
            </div>
            <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblFailedToSubmit" runat="server" Text="Testing button"></asp:Label>

        </div>
    </div>
</asp:Content>
