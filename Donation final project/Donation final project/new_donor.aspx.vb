Imports System.Windows

Public Class New_Donor
    Inherits System.Web.UI.Page
    Dim donorQueries As New DonorQueries

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub bntAddDonor_Click(sender As Object, e As EventArgs) Handles bntAddDonor.Click

        ' Will test to make sure that values are entered into the first and last name fields.  
        If txtFirstName.Text = "" Or txtLastName.Text = "" Then
            'Displays the error message for first name or last name if the fields are empty.  These are requied fields.  
            lblerrorFirstName.Style.Add("border-color", "red")
            lblerrorFirstName.Style.Add("border-color", "red")

            lblerrorFirstName.Visible = txtFirstName.Text = ""
            lblerrorLastName.Visible = txtLastName.Text = ""
        Else
            'Sets the error message to not be visible
            lblerrorFirstName.Visible = False
            lblerrorLastName.Visible = False

            'Used to update the boarder color of the css
            lblerrorFirstName.Style.Add("border-color", "black")
            lblerrorFirstName.Style.Add("border-color", "black")


            'Creates a new donor to be added into the database
            Dim donor As New Donor(txtFirstName.Text,
                                   txtLastName.Text,
                                   txtBusinessName.Text,
                                   txtPhoneNumber.Text,
                                   txtAddress.Text,
                                   txtEmail.Text,
                                   seletType.SelectedValue
                                   )
            'Sends the data to the database
            donorQueries.AddDonor(donor.GetDonor())
            displayMessage.Style.Add("display", "flex")

        End If

    End Sub

    Protected Sub bntYes_Click(sender As Object, e As EventArgs) Handles bntYes.Click

        'Resets the form to default values.
        txtFirstName.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtBusinessName.Text = ""
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