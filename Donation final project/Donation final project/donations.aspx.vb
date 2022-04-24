Imports System.Windows

Public Class Donations1
    Inherits System.Web.UI.Page
    Dim donationQueries As New DonationQueries
    Dim validation As New Validation



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                gvDonations.DataSource = donationQueries.GetData()
                If donationQueries.displayError() Then
                    lblErrorMessage.Text = donationQueries.getErrorMessage
                    lblErrorMessage.Visible = True
                Else
                    lblErrorMessage.Visible = False
                    gvDonations.DataBind()
                End If
            End If
        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = donationQueries.getErrorMessage
        End Try
    End Sub



    Protected Sub bntOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bntOk.Click
        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        displayMessage.Style.Add("display", "none")
    End Sub
    Protected Sub gvDonations_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvDonations.RowCommand

        Try
            If e.CommandName.Equals("update_row") Then

                Dim index As Integer = e.CommandArgument.ToString()

                'Gets the the items in the row with find control function 
                Dim id As Label = gvDonations.Rows(index).FindControl("lblID")
                Dim txtDonationType As TextBox = gvDonations.Rows(index).FindControl("txtDonationType")
                Dim txtDescription As TextBox = gvDonations.Rows(index).FindControl("txtDescription")
                Dim txtValue As TextBox = gvDonations.Rows(index).FindControl("txtValue")



                If validation.ValidateNumber(CDec(txtValue.Text)) And validation.ValidateString(txtDonationType.Text) Then
                    'Updates the Speific Row in the donation table oof the database
                    donationQueries.UpdateRow(id.Text, txtDonationType.Text, txtValue.Text, txtDescription.Text)

                    'Updates the innter text of the p tag html element 
                    current_message.InnerText = "Donation updated."


                    If donationQueries.displayError Then
                        'turns on the error message and sets it to visble
                        lblErrorMessage.Visible = True
                        'Gets an error message from donorsQuries
                        lblErrorMessage.Text = donationQueries.getErrorMessage
                    Else
                        'Shows the current message
                        displayMessage.Style.Add("display", "flex")
                        'Sets the error message label to not be visible
                        lblErrorMessage.Visible = False
                    End If
                Else
                    lblErrorMessage.Visible = True
                    lblErrorMessage.Text = "Value cannot be less then or equal to 0 and the type of donation cannot be blank."
                End If
            ElseIf e.CommandName.Equals("delete_row") Then
                Dim id = e.CommandArgument.ToString()
                current_message.InnerText = "Delete Record, to recreate the record or add a new doation please go to the donations page."

                Try

                    donationQueries.DeleteDonation(id)
                    MessageBox.Show("Testing delete row")
                    If donationQueries.displayError Then
                        lblErrorMessage.Visible = True
                        lblErrorMessage.Text = donationQueries.getErrorMessage
                    Else
                        lblErrorMessage.Visible = False
                        displayMessage.Style.Add("display", "flex")
                    End If
                Catch ex As Exception
                    lblErrorMessage.Visible = True
                    lblErrorMessage.Text = "Error Message: " + ex.Message
                End Try
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