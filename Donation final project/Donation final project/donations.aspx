<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Donations.aspx.vb" Inherits="Donation_final_project.Donations1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="table_container">
         <asp:GridView CssClass="table_formated"  ID="gvDonations" runat="server" AutoGenerateColumns="False" Width="570px">
        <Columns>
           <asp:TemplateField HeaderText="ID">
                 <ItemTemplate>
                    <asp:Label ID="lblID" DataField="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                 <ItemTemplate>
                    <asp:Label ID="lblDate" DataField="Date" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Donor ID">
                 <ItemTemplate>
                    <asp:Label ID="lblDonor_ID" DataField="Donor_ID" runat="server" Text='<%# Eval("Donor_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                 <ItemTemplate>
                    <asp:TextBox ID="txtDescription" DataField="Description" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type of Donation">
                 <ItemTemplate>
                    <asp:TextBox ID="txtDonationType" DataField="Donation_Type" runat="server" Text='<%# Eval("Donation_Type") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Value">
                 <ItemTemplate>
                    <asp:TextBox ID="txtValue" CssClass="align-currency" DataField="value" runat="server" Text='<%# Eval("value") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="bntUpdate" runat="server" CommandName="update_row" CssClass="edit-button" Text="Update" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="bntDelete" runat="server" CommandName="delete_row" CssClass="edit-button" Text="Delete" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
         </Columns>
        </asp:GridView>
        <div id="displayMessage" class="displayMessage" runat="server">
            <p id="current_message" runat="server"></p>
            <asp:Button  CssClass="btn btn-primary button-shadow" ID="bntOk" runat="server" Text="Ok" />
        </div>
        <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblErrorMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
