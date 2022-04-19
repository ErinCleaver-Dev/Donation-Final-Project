<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="New_donor.aspx.vb" Inherits="Donation_final_project.New_Donor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form_container">

        <div class="form">
            <h1 class="text-center">
                Create New Donor
            </h1>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="lblName" runat="server" Text="Name:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox CssClass="form-control textbox" ID="txtName" runat="server"></asp:TextBox>
                </div>
                <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblerrorName" runat="server" Text="Please enter their full name, organization  name, fondation name, or business name"></asp:Label>
            </div>
            <div class="row pb-2">
                <asp:Label CssClass="col-sm-3 col-form-label" ID="Label5" runat="server" Text="Phone number:"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox type="phone" CssClass="form-control textbox" ID="txtPhoneNumber" runat="server"></asp:TextBox>
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
                    <asp:TextBox type="email" CssClass="form-control textbox" ID="txtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:Label CssClass="col-form-label pb-2 text-center" ID="Label9" runat="server" Text="Donor Type"></asp:Label>
            <asp:DropDownList class="form-control item_list pb-2" ID="seletType" runat="server">
                <asp:ListItem>Business</asp:ListItem>
                <asp:ListItem>Person</asp:ListItem>
                <asp:ListItem>Organization</asp:ListItem>
                <asp:ListItem>Foundation</asp:ListItem>
            </asp:DropDownList>
            <div class="center-button">
                <asp:Button CssClass="btn btn-primary mt-2 submit_button" ID="bntAddDonor" runat="server" Text="Add Donor"/>
            </div>
            <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblFailedToSubmit" runat="server" Text="Testing button"></asp:Label>
        </div>
        <div id="displayMessage" class="displayMessage" runat="server">
            <p>Donor Sucessfully Added to data base.</p>
            <p>Would you like to add anothe donor?</p>
            <asp:Button CssClass="btn btn-primary button-shadow" ID="bntYes" runat="server" Text="Yes" />
            <asp:Button CssClass="btn btn-outline-primary mt-2 button-shadow" ID="bntNo" runat="server" Text="No" />
        </div>
    </div>
</asp:Content>
