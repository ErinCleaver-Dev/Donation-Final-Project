<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="New_donation.aspx.vb" Inherits="Donation_final_project.New_donation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form_container">

            <div class="form">
                <h1 class="text-center">
                    Create A New Donation
                </h1>
                <div class="row pb-2">
                    <asp:Label CssClass="col-sm-3 col-form-label" ID="lblDate" runat="server" Text="Date:"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox type="text" CssClass="form-control textbox" ID="txtDate" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblerrorName" runat="server" Text="Please enter their full name, organization  name, fondation name, or business name"></asp:Label>
                </div>
                <asp:Label CssClass="col-form-label pb-2 text-center" ID="lblName" runat="server" Text="Name"></asp:Label>
                <asp:DropDownList class="form-control item_list pb-2" ID="dlNames" runat="server">
                </asp:DropDownList>
                <div class="row mx-2">
                    <asp:Label CssClass="col-sm-3 col-form-label" ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox CssClass="form-control textbox" ID="txtDescription" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:Label CssClass="col-form-label pb-2 text-center" ID="Label9" runat="server" Text="Dontation Type"></asp:Label>
                <asp:DropDownList class="form-control item_list pb-2" ID="seletType" runat="server">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>Credit</asp:ListItem>
                    <asp:ListItem>Debit</asp:ListItem>
                    <asp:ListItem>Stocks</asp:ListItem>
                    <asp:ListItem>Noncash</asp:ListItem>
                </asp:DropDownList>
                <div class="row mx-2">
                    <asp:Label CssClass="col-sm-3 col-form-label" ID="Label8" runat="server" Text="Value:"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox CssClass="form-control textbox align-currency" ID="txtValue" value="0.00" runat="server"></asp:TextBox>
                    </div>
                     <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblValueErrorMessage" runat="server" Text="Testing button"></asp:Label>

                </div>
                <div class="center-button">
                    <asp:Button CssClass="btn btn-primary mt-2 submit_button" ID="bntAddDonor" runat="server" Text="Add Donation"/>
                </div>
                <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblErrorMessage" runat="server" Text="Testing button"></asp:Label>
            </div>
            <div id="displayMessage" class="displayMessage" runat="server">
                <p>Sucessfully added dontaiton to data base.</p>
                <p>Would you like to add another donation?</p>
                <asp:Button CssClass="btn btn-primary button-shadow" ID="bntYes" runat="server" Text="Yes" />
                <asp:Button CssClass="btn btn-outline-primary mt-2 button-shadow" ID="bntNo" runat="server" Text="No" />
            </div>
        </div>
</asp:Content>
