Imports System.Windows

Public Class New_Donor
    Inherits System.Web.UI.Page
    Dim donorQueries As New DonorQueries
    Dim validation As New Validation


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub bntAddDonor_Click(sender As Object, e As EventArgs) Handles bntAddDonor.Click

        ' Will test to make sure that values are entered into the first and last name fields.  
        If Not validation.ValidateString(txtName.Text) Then
            'Displays the error message for first name or last name if the fields are empty.  These are requied fields.  
            txtName.Style.Add("border-color", "red")

            'Changes the text field to visable 
            lblerrorName.Visible = txtName.Text = ""
        Else
            'Sets the error message to not be visible
            lblerrorName.Visible = False

            'Used to update the boarder color of the css
            txtName.Style.Add("border-color", "black")

            'Creates a new donor to be added into the database
            Dim donor As New Donor(txtName.Text.Trim(),
                                   txtPhoneNumber.Text.Trim(),
                                   txtAddress.Text.Trim(),
                                   txtEmail.Text.Trim(),
                                   seletType.SelectedValue.Trim())
            'Sends the data to the database
            donorQueries.Add(donor.GetDonor())
            If donorQueries.displayError Then
                lblFailedToSubmit.Text = donorQueries.getErrorMessage
                lblFailedToSubmit.Visible = True
            Else
                displayMessage.Style.Add("display", "flex")
                lblFailedToSubmit.Visible = False
            End If


        End If

    End Sub

    Protected Sub bntYes_Click(sender As Object, e As EventArgs) Handles bntYes.Click

        'Resets the form to default values.
        txtName.Text = ""
        txtPhoneNumber.Text = ""
        txtAddress.Text = ""
        txtEmail.Text = ""
        seletType.SelectedIndex = 0


        'Used to not display the message box
        displayMessage.Style.Add("display", "none")
    End Sub

    Protected Sub bntNo_Click(sender As Object, e As EventArgs) Handles bntNo.Click
        'Used to not display the message box
        displayMessage.Style.Add("display", "none")
    End Sub
End Class