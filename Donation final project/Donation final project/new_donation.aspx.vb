Imports System.Windows
Imports System

Public Class New_donation
    Inherits System.Web.UI.Page
    Dim donorsQuries As New DonorQueries
    Dim names As New Dictionary(Of Integer, String)
    Dim validation As New Validation
    Dim donationQueries As New DonationQueries


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            names = donorsQuries.getNames()
            dlNames.DataSource = names
            dlNames.DataTextField = "Value"
            dlNames.DataValueField = "Key"
            dlNames.DataBind()

            txtDate.Text = DateTime.Now.ToShortDateString()

            If Not donorsQuries.displayError Then
                lblErrorMessage.Visible = True
                lblErrorMessage.Text = donorsQuries.getErrorMessage
            Else
                lblErrorMessage.Visible = False
            End If
        End If
    End Sub

    Protected Sub bntAddDonor_Click(sender As Object, e As EventArgs) Handles bntAddDonor.Click
        Try
            If validation.validateCashValue(txtValue.Text) Then
                'creates a new instance of the donation class and assigns values
                Dim donation As New Donation(txtDate.Text.Trim,
                                             dlNames.SelectedValue().Trim,
                                             txtValue.Text.Trim,
                                             seletType.SelectedValue().Trim,
                                             txtDescription.Text.Trim)

                'Adds a new donation to the database
                donationQueries.AddDonation(donation.GetDonation)

                MessageBox.Show(donationQueries.displayError)


                If donationQueries.displayError Then
                    MessageBox.Show("testing error message")

                    lblValueErrorMessage.Visible = True
                    lblValueErrorMessage.Text = "Test" + donationQueries.getErrorMessage
                Else
                    MessageBox.Show("testing else message ")

                    lblValueErrorMessage.Visible = False
                    txtValue.Style.Add("border-color", "black")
                    displayMessage.Style.Add("display", "flex")
                End If
            Else
                txtValue.Style.Add("border-color", "red")
                lblValueErrorMessage.Visible = True
                lblValueErrorMessage.Text = "Error Message: Please Enter a value greater then 0 and do not level the field blank."
            End If
        Catch ex As Exception
            txtValue.Style.Add("border-color", "red")
            lblValueErrorMessage.Visible = True
            lblValueErrorMessage.Text = "Error Message: " + ex.Message
        End Try

    End Sub

    Protected Sub bntYes_Click(sender As Object, e As EventArgs) Handles bntYes.Click

        'Resets the form to default values.
        txtValue.Text = ""
        txtDescription.Text = ""
        dlNames.SelectedIndex = 0
        seletType.SelectedIndex = 0

        'Used to not display the message box
        displayMessage.Style.Add("display", "none")
    End Sub

    Protected Sub bntNo_Click(sender As Object, e As EventArgs) Handles bntNo.Click
        'Used to not display the message box
        displayMessage.Style.Add("display", "none")
    End Sub
End Class