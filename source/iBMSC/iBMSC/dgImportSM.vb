Imports System.Windows.Forms

Public Class dgImportSM

    Public iResult As Integer = -1

    Public Sub New(ByVal sDiff() As String)
        InitializeComponent()

        LDiff.Items.AddRange(sDiff)
        LDiff.SelectedIndex = 0
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        iResult = LDiff.SelectedIndex
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgImportSM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim xS() As String = Form1.lpimpSM

        Me.Font = Form1.Font

        Me.Text = Locale.fImportSM.Title
        Label7.Text = Locale.fImportSM.Difficulty
        Label5.Text = Locale.fImportSM.Note
        OK_Button.Text = Locale.OK
        Cancel_Button.Text = Locale.Cancel
    End Sub
End Class
