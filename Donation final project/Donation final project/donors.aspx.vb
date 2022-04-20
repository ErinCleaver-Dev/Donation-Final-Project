Imports System.Windows

Public Class Donors
    Inherits System.Web.UI.Page
    Dim donorsQuries As New DonorQueries

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If donorsQuries.receivedData() = False Then
            lblErrorMessage.Text = donorsQuries.getErrorMessage
            lblErrorMessage.Visible = True
        Else
            lblErrorMessage.Visible = False
            gvDonors.DataSource = donorsQuries.getDonors()
            gvDonors.DataBind()
        End If

    End Sub

    Protected Sub gvDonors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDonors.SelectedIndexChanged





    End Sub
End Class