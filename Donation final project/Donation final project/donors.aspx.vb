Imports System.Windows

Public Class Donors
    Inherits System.Web.UI.Page
    Dim donorsQuries As New DonorQueries

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If donorsQuries.displayError() = False Then
                lblErrorMessage.Text = donorsQuries.getErrorMessage
                lblErrorMessage.Visible = True
            Else
                lblErrorMessage.Visible = False
                gvDonors.DataSource = donorsQuries.getDonors()
                gvDonors.DataBind()
            End If
        End If
    End Sub



    Protected Sub bntOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bntOk.Click
        displayMessage.Style.Add("display", "none")
    End Sub
    Protected Sub gvDonors_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvDonors.RowCommand

        Try
            If e.CommandName.Equals("update_row") Then

                Dim index As Integer = e.CommandArgument.ToString()
                Dim txtName As TextBox = gvDonors.Rows(index).FindControl("txtName")

                MessageBox.Show(txtName.Text)

                displayMessage.Style.Add("display", "flex")

            End If

            'lblErrorMessage.Visible = False
        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try


    End Sub



End Class