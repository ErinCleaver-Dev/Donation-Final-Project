<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Donors.aspx.vb" Inherits="Donation_final_project.Donors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table_container">
         <asp:GridView CssClass="table_formated"  ID="gvDonors" runat="server" AutoGenerateColumns="False" Width="570px">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" ReadOnly="True"/>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" ></asp:BoundField>
            <asp:BoundField HeaderText="Address" DataField="Address" ></asp:BoundField>
            <asp:BoundField HeaderText="Email" DataField="email" ></asp:BoundField>
            <asp:BoundField HeaderText="Type" DataField="type" ></asp:BoundField>
            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="edit-button" CommandName="Edit" Text="Edit" />
        </Columns>
        </asp:GridView>
        <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblErrorMessage" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
