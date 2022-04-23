<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"  CodeBehind="Donors.aspx.vb" Inherits="Donation_final_project.Donors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table_container">
         <asp:GridView CssClass="table_formated"  ID="gvDonors" runat="server" AutoGenerateColumns="False" Width="570px">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" ReadOnly="True"/>
            <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                    <asp:TextBox ID="txtName" DataField="Name" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone Number">
                 <ItemTemplate>
                    <asp:TextBox ID="txtPhoneNumber" DataField="PhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                 <ItemTemplate>
                    <asp:TextBox ID="txtAddress" DataField="Address" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                 <ItemTemplate>
                    <asp:TextBox ID="txtEmail" DataField="email" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
                 <ItemTemplate>
                    <asp:TextBox ID="txtType" DataField="type" runat="server" Text='<%# Eval("type") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="bntUpdate" runat="server" CommandName="update_row" CssClass="edit-button" Text="Update" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
         </Columns>
        </asp:GridView>
        <asp:Label CssClass="col-sm-12 error-message"  Visible="False" ID="lblErrorMessage" runat="server" Text=""></asp:Label>
        <div id="displayMessage" class="displayMessage" runat="server">
            <p>Updated Donor information.</p>
            <asp:Button  CssClass="btn btn-primary button-shadow" ID="bntOk" runat="server" Text="Ok" />
        </div>
    </div>

</asp:Content>
