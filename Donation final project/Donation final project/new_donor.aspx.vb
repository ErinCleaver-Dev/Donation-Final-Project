Imports System.Windows

Public Class New_Donor
    Inherits System.Web.UI.Page
    Dim donor As New Donor



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bntAddDonor_Click(sender As Object, e As EventArgs) Handles bntAddDonor.Click

        ' Will test to make sure that values are entered into the first and last name fields.  
        If txtFirstName.Text = "" Or txtLastName.Text = "" Then
            lblerrorFirstName.Visible = txtFirstName.Text = ""
            lblerrorLastName.Visible = txtLastName.Text = ""
        Else
            lblerrorFirstName.Visible = False
            lblerrorLastName.Visible = False

            donor.AddDonor(txtFirstName.Text,
                           txtLastName.Text)


        End If

    End Sub
End Class