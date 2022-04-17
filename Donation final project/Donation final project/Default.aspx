<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Donation Application
    </h1>
    <div class="container">
        <div class="rows">
            <div class="col-sm-4">
                <a  href="/New_donor.aspx" class="card_formated" >
                    Add New Donor
                </a>
            </div>
            <div class="col-sm-4">
                <a href="/Donors.aspx" class="card_formated">
                    Access Existing Donors
                </a>
            </div>
            <div class="col-sm-4">
                <a href="/New_donation.aspx" class="card_formated">
                    Create New Donation
                </a>
            </div>
        </div>
         <div class="rows">
            <div class="col-sm-4">
                <a href="/Donations.aspx" class="card_formated">
                    Update Donations
                </a>
            </div>
            <div class="col-sm-4">
                <a href="/Reports.aspx" class="card_formated">
                    Create Reports
                </a>
            </div>

        </div>
    </div>

</asp:Content>
