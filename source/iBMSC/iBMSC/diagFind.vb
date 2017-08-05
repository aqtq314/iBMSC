Imports System.Windows.Forms

Public Class diagFind
    Dim bCol As Integer = 46
    Dim msg1 As String = "Error"
    Dim msg2 As String = "Invalid label."

    Public Sub New(ByVal xbCol As Integer, ByVal xmsg1 As String, ByVal xmsg2 As String)
        InitializeComponent()
        bCol = xbCol
        msg1 = xmsg1
        msg2 = xmsg2
    End Sub

    Private Sub CloseDialog(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBClose.Click
        Me.Close()
    End Sub

    Private Sub BSAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSAll.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = True
        Next
    End Sub
    Private Sub BSInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSInv.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = Not xCB.Checked
        Next
    End Sub
    Private Sub BSNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSNone.Click
        For Each xCB As CheckBox In Panel1.Controls
            xCB.Checked = False
        Next
    End Sub

    Private Sub diagFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = Form1.Font
        Dim xBold As New Font(Me.Font, FontStyle.Bold)

        TBSelect.Font = xBold
        Label8.Font = xBold
        Label9.Font = xBold

        'Dim xS() As String = Form1.lpfdr
        Me.Text = Form1.TBFind.Text

        Label1.Text = Locale.fFind.NoteRange
        Label2.Text = Locale.fFind.MeasureRange
        Label3.Text = Locale.fFind.LabelRange
        Label4.Text = Locale.fFind.ValueRange
        Label5.Text = Locale.fFind.to_
        Label6.Text = Locale.fFind.to_
        Label7.Text = Locale.fFind.to_

        cbx1.Text = Locale.fFind.Selected
        cbx2.Text = Locale.fFind.UnSelected
        cbx3.Text = Locale.fFind.ShortNote
        cbx4.Text = Locale.fFind.LongNote
        cbx5.Text = Locale.fFind.Hidden
        cbx6.Text = Locale.fFind.Visible

        Label8.Text = Locale.fFind.Column
        BSAll.Text = Locale.fFind.SelectAll
        BSInv.Text = Locale.fFind.SelectInverse
        BSNone.Text = Locale.fFind.UnselectAll

        Label9.Text = Locale.fFind.Operation
        TBrl.Text = Locale.fFind.ReplaceWithLabel
        TBrv.Text = Locale.fFind.ReplaceWithValue
        TBSelect.Text = Locale.fFind.Select_
        TBUnselect.Text = Locale.fFind.Unselect_
        TBDelete.Text = Locale.fFind.Delete_
        TBClose.Text = Locale.fFind.Close_

        For xI1 As Integer = 27 To bCol
            Dim xCB As New CheckBox
            With xCB
                .Appearance = Appearance.Button
                .Checked = True
                .FlatStyle = FlatStyle.System
                .Location = New Point(((xI1 - 26) Mod 8) * 35 + 3, ((xI1 - 26) \ 8) * 25 + 103)
                .Size = New Size(35, 25)
                .Tag = xI1
                .Text = "B" & (xI1 - 25).ToString
                .TextAlign = ContentAlignment.MiddleCenter
                .UseVisualStyleBackColor = True
            End With
            Panel1.Controls.Add(xCB)
        Next

        AddHandler lr1.KeyDown, AddressOf lblKeyDown
        AddHandler lr2.KeyDown, AddressOf lblKeyDown
        AddHandler Ttl.KeyDown, AddressOf lblKeyDown
    End Sub

    Private Function ValidLabel(ByVal xStr As String) As Boolean
        xStr = UCase(Trim(xStr))

        If Len(xStr) = 0 Then Return False
        If xStr = "00" Or xStr = "0" Then Return False
        If Not Len(xStr) = 1 And Not Len(xStr) = 2 Then Return False

        Dim xI3 As Integer = Asc(Mid(xStr, 1, 1))
        If Not ((xI3 >= 48 And xI3 <= 57) Or (xI3 >= 65 And xI3 <= 90)) Then Return False
        If Len(xStr) = 2 Then
            Dim xI4 As Integer = Asc(Mid(xStr, 2, 1))
            If Not ((xI4 >= 48 And xI4 <= 57) Or (xI4 >= 65 And xI4 <= 90)) Then Return False
        End If
        Return True
        MsgBox(msg2, MsgBoxStyle.Critical, msg1)
    End Function

    Private Sub lblKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not e.KeyCode = Keys.Enter Then Exit Sub
        ValidateLabel(sender)
    End Sub

    Private Function ValidateLabel(ByVal sender As Object) As Boolean
        Dim xBool As Boolean = ValidLabel(sender.Text)
        If Not xBool Then
            MsgBox(msg2, MsgBoxStyle.Critical, msg1)
            sender.Focus()
            sender.SelectAll()
        End If
        ValidateLabel = xBool
    End Function

    Private Sub TBSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSelect.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange As Integer = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        Form1.fdrSelect(xRange, _
                        mr1.Value, mr2.Value, _
                        lr1.Text, lr2.Text, _
                        vr1.Value * 10000, vr2.Value * 10000, _
                        xCol)
    End Sub

    Private Sub TBUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUnselect.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange As Integer = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        Form1.fdrUnselect(xRange, _
                          mr1.Value, mr2.Value, _
                          lr1.Text, lr2.Text, _
                          vr1.Value * 10000, vr2.Value * 10000, _
                          xCol)
    End Sub

    Private Sub TBDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBDelete.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange As Integer = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        Form1.fdrDelete(xRange, _
                        mr1.Value, mr2.Value, _
                        lr1.Text, lr2.Text, _
                        vr1.Value * 10000, vr2.Value * 10000, _
                        xCol)
    End Sub

    Private Sub TBrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBrl.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub
        If Not ValidateLabel(Ttl) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange As Integer = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        Form1.fdrReplaceL(xRange, _
                          mr1.Value, mr2.Value, _
                          lr1.Text, lr2.Text, _
                          vr1.Value * 10000, vr2.Value * 10000, _
                          xCol, Ttl.Text)
    End Sub

    Private Sub TBrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBrv.Click
        If Not ValidateLabel(lr1) Then Exit Sub
        If Not ValidateLabel(lr2) Then Exit Sub

        Dim xCol() As Integer = {}
        For Each xCB As CheckBox In Panel1.Controls
            If xCB.Checked Then
                ReDim Preserve xCol(UBound(xCol) + 1)
                xCol(UBound(xCol)) = xCB.Tag
            End If
        Next

        Dim xRange As Integer = 1
        If cbx1.Checked Then xRange *= 2
        If cbx2.Checked Then xRange *= 3
        If cbx3.Checked Then xRange *= 5
        If cbx4.Checked Then xRange *= 7
        If cbx5.Checked Then xRange *= 11
        If cbx6.Checked Then xRange *= 13

        Form1.fdrReplaceV(xRange, _
                          mr1.Value, mr2.Value, _
                          lr1.Text, lr2.Text, _
                          vr1.Value * 10000, vr2.Value * 10000, _
                          xCol, Ttv.Value * 10000)
    End Sub
End Class
