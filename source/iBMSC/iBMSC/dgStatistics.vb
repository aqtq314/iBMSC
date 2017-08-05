Imports System.Windows.Forms

Public Class dgStatistics

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgStatistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = Form1.Font

        Me.Text = Locale.fStatistics.Title
        Label6.Text = Locale.fStatistics.lBPM
        Label7.Text = Locale.fStatistics.lSTOP
        Label8.Text = Locale.fStatistics.lA
        Label9.Text = Locale.fStatistics.lD
        Label10.Text = Locale.fStatistics.lBGM
        Label1.Text = Locale.fStatistics.lTotal
        Label11.Text = Locale.fStatistics.lShort
        Label12.Text = Locale.fStatistics.lLong
        Label13.Text = Locale.fStatistics.lLnObj
        Label14.Text = Locale.fStatistics.lHidden
        Label15.Text = Locale.fStatistics.lErrors
        Label2.Text = Locale.fStatistics.lTotal
        OK_Button.Text = Locale.OK
    End Sub

    Public Sub New(ByVal data(,) As Integer)
        InitializeComponent()

        For row As Integer = 0 To 5
            For col As Integer = 0 To 5
                Dim xLabel As New Label
                xLabel.Dock = DockStyle.Fill
                xLabel.TextAlign = ContentAlignment.MiddleCenter
                xLabel.Margin = New Padding(0)
                xLabel.Font = New Font(Me.Font, FontStyle.Bold)
                If data(row, col) <> 0 Then xLabel.Text = data(row, col)
                If row Mod 2 = 0 Then xLabel.BackColor = Color.FromArgb(&H10000000)
                TableLayoutPanel1.Controls.Add(xLabel, col + 1, row + 1)
            Next
        Next
    End Sub
End Class
