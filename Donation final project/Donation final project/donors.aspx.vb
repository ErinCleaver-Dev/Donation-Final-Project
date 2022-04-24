Imports System.Windows

Public Class Donors
    Inherits System.Web.UI.Page
    Dim donorsQuries As New DonorQueries

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvDonors.DataSource = donorsQuries.GetData()
            If donorsQuries.displayError() = False Then
                lblErrorMessage.Text = donorsQuries.getErrorMessage
                lblErrorMessage.Visible = True
            Else
                lblErrorMessage.Visible = False
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
                'Gets the the items in the row with find control function 
                Dim id As Label = gvDonors.Rows(index).FindControl("lblID")
                Dim txtName As TextBox = gvDonors.Rows(index).FindControl("txtName")
                Dim txtPhone As TextBox = gvDonors.Rows(index).FindControl("txtPhoneNumber")
                Dim txtAddress As TextBox = gvDonors.Rows(index).FindControl("txtAddress")
                Dim txtEmail As TextBox = gvDonors.Rows(index).FindControl("txtEmail")
                Dim txtType As TextBox = gvDonors.Rows(index).FindControl("txtType")

                'Create a new donor to update the infomration in the database 
                Dim donor As New Donor(txtName.Text.Trim(),
                                       txtPhone.Text.Trim(),
                                       txtAddress.Text.Trim(),
                                       txtEmail.Text.Trim(),
                                       txtType.Text.Trim())

                'Updates the Speific Row in the database
                'The fuction accepts an id and a dictionary 
                donorsQuries.updateRow(id.Text, donor.GetDonor())
                'displays a message if the donor was added to the database
                displayMessage.Style.Add("display", "flex")
                If Not donorsQuries.displayError Then
                    'turns on the error message and sets it to visble
                    lblErrorMessage.Visible = True
                    'Gets an error message from donorsQuries
                    lblErrorMessage.Text = donorsQuries.getErrorMessage
                Else
                    'Sets the error message label to not be visible
                    lblErrorMessage.Visible = False
                End If
            End If

            'lblErrorMessage.Visible = False
        Catch ex As Exception
            'Sets the error message label to not be visible
            lblErrorMessage.Visible = True
            'Updates the error message with an exemption
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub

End Class