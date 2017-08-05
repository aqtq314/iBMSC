Public Class Form1

    Structure Note
        Public VPosition As Double
        Public ColumnIndex As Integer
        Public Value As Integer 'x10000
        Public LongNote As Boolean
        Public Hidden As Boolean
        Public Length As Double

        Public PairWithI As Integer
        Public Selected As Boolean
        Public HasError As Boolean

        'Public TempBoolean As Boolean
        Public TempSelected As Boolean
        Public TempMouseDown As Boolean
        Public TempIndex As Integer

        'Public TimeOffset As Double

        'Public Function equalsBMSE(ByVal n As Note) As Boolean
        '    Return VPosition = n.VPosition And _
        '           ColumnIndex = n.ColumnIndex And _
        '           Value = n.Value And _
        '           LongNote = n.LongNote And _
        '           Hidden = n.Hidden
        'End Function
        'Public Function equalsNT(ByVal n As Note) As Boolean
        '    Return VPosition = n.VPosition And _
        '           ColumnIndex = n.ColumnIndex And _
        '           Value = n.Value And _
        '           Hidden = n.Hidden And _
        '           Length = n.Length
        'End Function
        Public Function equalsBMSE(ByVal nColumnIndex As Integer, ByVal nVposition As Double, _
        ByVal nValue As Integer, ByVal nLongNote As Boolean, ByVal nHidden As Boolean) As Boolean
            Return VPosition = nVposition And _
                   ColumnIndex = nColumnIndex And _
                   Value = nValue And _
                   LongNote = nLongNote And _
                   Hidden = nHidden
        End Function
        Public Function equalsNT(ByVal nColumnIndex As Integer, ByVal nVposition As Double, _
        ByVal nValue As Integer, ByVal nLength As Double, ByVal nHidden As Boolean) As Boolean
            Return VPosition = nVposition And _
                   ColumnIndex = nColumnIndex And _
                   Value = nValue And _
                   Hidden = nHidden And _
                   Length = nLength
        End Function
        Public Sub New(ByVal nColumnIndex As Integer, ByVal nVposition As Double, _
        ByVal nValue As Integer, ByVal nLongNote As Double, ByVal nHidden As Boolean)
            VPosition = nVposition
            ColumnIndex = nColumnIndex
            Value = nValue
            LongNote = nLongNote
            Length = nLongNote
            Hidden = nHidden
        End Sub
        Public Sub New(ByVal nColumnIndex As Integer, ByVal nVposition As Double, _
        ByVal nValue As Integer, ByVal nLongNote As Double, ByVal nHidden As Boolean, ByVal nSelected As Boolean)
            VPosition = nVposition
            ColumnIndex = nColumnIndex
            Value = nValue
            LongNote = nLongNote
            Length = nLongNote
            Hidden = nHidden
            Selected = nSelected
        End Sub
    End Structure

    'Public Structure MARGINS
    '    Public Left As Integer
    '    Public Right As Integer
    '    Public Top As Integer
    '    Public Bottom As Integer
    'End Structure

    '<System.Runtime.InteropServices.DllImport("dwmapi.dll")> _
    'Public Shared Function DwmIsCompositionEnabled(ByRef en As Integer) As Integer
    'End Function
    '<System.Runtime.InteropServices.DllImport("dwmapi.dll")> _
    'Public Shared Function DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef margin As MARGINS) As Integer
    'End Function
    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public Declare Function ReleaseCapture Lib "user32.dll" Alias "ReleaseCapture" () As Integer

    'Private Declare Auto Function GetWindowLong Lib "user32" (ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    'Private Declare Auto Function SetWindowLong Lib "user32" (ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    'Private Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    '<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    'Private Shared Function SetWindowText(ByVal hwnd As IntPtr, ByVal lpString As String) As Boolean
    'End Function

    'Private Const GWL_STYLE As Integer = -16
    'Private Const WS_CAPTION As Integer = &HC00000
    'Private Const SWP_NOSIZE As Integer = &H1
    'Private Const SWP_NOMOVE As Integer = &H2
    'Private Const SWP_NOZORDER As Integer = &H4
    'Private Const SWP_NOACTIVATE As Integer = &H10
    'Private Const SWP_FRAMECHANGED As Integer = &H20
    'Private Const SWP_REFRESH As Integer = SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_NOACTIVATE Or SWP_FRAMECHANGED

    Public Const niMeasure As Integer = 0
    Public Const niBPM As Integer = 1
    Public Const niSTOP As Integer = 2
    Public Const niS1 As Integer = 3

    Public Const niA1 As Integer = 4
    Public Const niA2 As Integer = 5
    Public Const niA3 As Integer = 6
    Public Const niA4 As Integer = 7
    Public Const niA5 As Integer = 8
    Public Const niA6 As Integer = 9
    Public Const niA7 As Integer = 10
    Public Const niA8 As Integer = 11
    Public Const niS2 As Integer = 12

    Public Const niD1 As Integer = 13
    Public Const niD2 As Integer = 14
    Public Const niD3 As Integer = 15
    Public Const niD4 As Integer = 16
    Public Const niD5 As Integer = 17
    Public Const niD6 As Integer = 18
    Public Const niD7 As Integer = 19
    Public Const niD8 As Integer = 20
    Public Const niS3 As Integer = 21

    Public Const niBGA As Integer = 22
    Public Const niLAYER As Integer = 23
    Public Const niPOOR As Integer = 24
    Public Const niS4 As Integer = 25
    Public Const niB As Integer = 26

    Public Const idflBPM As Integer = 5
    Public Const idLong As Integer = 40
    Public Const idHidden As Integer = 20

    'Public kLeft() As Integer = {0, 50, 110, 160, 165, 207, 237, 279, 324, 366, 396, 438, 478, 483, 525, 555, 597, 642, 684, 714, 756, 796, 801, 841, 881, 921, 926}
    'Public kLength() As Integer = {50, 60, 50, 5, 42, 30, 42, 45, 42, 30, 42, 40, 5, 42, 30, 42, 45, 42, 30, 42, 40, 5, 40, 40, 40, 5, 40}

    '''' <summary>A user can put notes only if its visibility = 0.</summary>
    'Enum ColumnVisibility As Integer
    '    ''' <summary>A column is decorative if it is a seperator / Measure.</summary>
    '    Decorative = 1
    '    ''' <summary>This is for single / double player.</summary>
    '    Invisible = 2
    '    ''' <summary>Some columns are temporarily disabled for specific themes like ... POMU ...</summary>
    '    Zero_Width = 4
    'End Enum

    Structure Column
        Private _Width As Integer
        Private _isNoteCol As Boolean
        Private _isVisible As Boolean
        Private _isEnabledAfterAll As Boolean

        Public Property Width() As Integer
            Get
                Return _Width
            End Get
            Set(ByVal value As Integer)
                _Width = value
                _isEnabledAfterAll = _isVisible And _isNoteCol And (_Width <> 0)
            End Set
        End Property

        Public Property isVisible() As Boolean
            Get
                Return _isVisible
            End Get
            Set(ByVal value As Boolean)
                _isVisible = value
                _isEnabledAfterAll = _isVisible And _isNoteCol And (_Width <> 0)
            End Set
        End Property

        Public Property isNoteCol() As Boolean
            Get
                Return _isNoteCol
            End Get
            Set(ByVal value As Boolean)
                _isNoteCol = value
                _isEnabledAfterAll = _isVisible And _isNoteCol And (_Width <> 0)
            End Set
        End Property

        Public ReadOnly Property isEnabledAfterAll() As Boolean
            Get
                Return _isEnabledAfterAll
            End Get
        End Property

        'Private Visibility As ColumnVisibility
        'Public Property Visible() As Boolean
        '    Get
        '        Return Not (Visibility And ColumnVisibility.Invisible)
        '    End Get
        '    Set(ByVal value As Boolean)
        '        If value Then
        '            Visibility = Visibility Or ColumnVisibility.Invisible
        '        Else
        '            Visibility = Visibility And (ColumnVisibility.Decorative Or ColumnVisibility.Zero_Width)
        '        End If
        '    End Set
        'End Property

        Public Left As Integer
        Public Title As String
        Public isNumeric As Boolean
        Public Identifier As Integer

        Public cNote As Integer
        Public cText As Color
        Public cLNote As Integer
        Public cLText As Color
        Public cBG As Color

        Private cCacheB As Integer
        Private cCacheD As Integer
        Private cCacheLB As Integer
        Private cCacheLD As Integer

        Public Function getBright(ByVal opacity As Single) As Color
            Return Color.FromArgb((CInt(((cCacheB >> 24) And &HFF) * opacity) << 24) Or (cCacheB And &HFFFFFF))
        End Function
        Public Function getDark(ByVal opacity As Single) As Color
            Return Color.FromArgb((CInt(((cCacheD >> 24) And &HFF) * opacity) << 24) Or (cCacheD And &HFFFFFF))
        End Function
        Public Function getLongBright(ByVal opacity As Single) As Color
            Return Color.FromArgb((CInt(((cCacheLB >> 24) And &HFF) * opacity) << 24) Or (cCacheLB And &HFFFFFF))
        End Function
        Public Function getLongDark(ByVal opacity As Single) As Color
            Return Color.FromArgb((CInt(((cCacheLD >> 24) And &HFF) * opacity) << 24) Or (cCacheLD And &HFFFFFF))
        End Function

        Public Sub setNoteColor(ByVal c As Integer)
            cNote = c
            'cCacheB = (c And &HFF000000) Or &H808080 Or ((c And &HFFFFFF) >> 1)
            'cCacheD = (c And &HFF000000) Or ((c And &HFEFEFE) >> 1)
            cCacheB = AdjustBrightness(Color.FromArgb(c), 50, ((c >> 24) And &HFF) / 255).ToArgb
            cCacheD = AdjustBrightness(Color.FromArgb(c), -25, ((c >> 24) And &HFF) / 255).ToArgb
        End Sub
        Public Sub setLNoteColor(ByVal c As Integer)
            cLNote = c
            'cCacheLB = (c And &HFF000000) Or &H808080 Or ((c And &HFFFFFF) >> 1)
            'cCacheLD = (c And &HFF000000) Or ((c And &HFEFEFE) >> 1)
            cCacheLB = AdjustBrightness(Color.FromArgb(c), 50, ((c >> 24) And &HFF) / 255).ToArgb
            cCacheLD = AdjustBrightness(Color.FromArgb(c), -25, ((c >> 24) And &HFF) / 255).ToArgb
        End Sub

        Public Sub New(ByVal xLeft As Integer, ByVal xWidth As Integer, ByVal xTitle As String, _
        ByVal xNoteCol As Boolean, ByVal xisNumeric As Boolean, ByVal xVisible As Boolean, ByVal xIdentifier As Integer, _
        ByVal xcNote As Integer, ByVal xcText As Integer, ByVal xcLNote As Integer, ByVal xcLText As Integer, ByVal xcBG As Integer)
            Left = xLeft
            Title = xTitle
            isNumeric = xisNumeric
            Identifier = xIdentifier

            _Width = xWidth
            _isVisible = xVisible
            _isNoteCol = xNoteCol
            _isEnabledAfterAll = xVisible And xNoteCol And (xWidth <> 0)

            setNoteColor(xcNote)
            cText = Color.FromArgb(xcText)
            setLNoteColor(xcLNote)
            cLText = Color.FromArgb(xcLText)
            cBG = Color.FromArgb(xcBG)
        End Sub
    End Structure

    Public col() As Column = {New Column(0, 50, "Measure", False, True, True, 0, 0, &HFF00FFFF, 0, &HFF00FFFF, 0), _
                              New Column(50, 60, "BPM", True, True, True, 3, 0, &HFFFF0000, 0, &HFFFF0000, 0), _
                              New Column(110, 50, "STOP", True, True, False, 9, 0, &HFFFF0000, 0, &HFFFF0000, 0), _
                              New Column(110, 5, "", False, False, True, 0, 0, 0, 0, 0, 0), _
                              New Column(115, 42, "A1", True, False, True, 16, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(157, 30, "A2", True, False, True, 11, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
                              New Column(187, 42, "A3", True, False, True, 12, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(229, 45, "A4", True, False, True, 13, &HFFFFC862, &HFF000000, &HFFF7C66A, &HFF000000, &H16F38B0C), _
                              New Column(274, 42, "A5", True, False, True, 14, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(316, 30, "A6", True, False, True, 15, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
                              New Column(346, 42, "A7", True, False, True, 18, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(388, 40, "A8", True, False, True, 19, &HFF808080, &HFF000000, &HFF909090, &HFF000000, 0), _
                              New Column(388, 5, "", False, False, True, 0, 0, 0, 0, 0, 0), _
                              New Column(393, 42, "D1", True, False, False, 21, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(393, 30, "D2", True, False, False, 22, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
                              New Column(393, 42, "D3", True, False, False, 23, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(393, 45, "D4", True, False, False, 24, &HFFFFC862, &HFF000000, &HFFF7C66A, &HFF000000, &H16F38B0C), _
                              New Column(393, 42, "D5", True, False, False, 25, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(393, 30, "D6", True, False, False, 28, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
                              New Column(393, 42, "D7", True, False, False, 29, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
                              New Column(393, 40, "D8", True, False, False, 26, &HFF808080, &HFF000000, &HFF909090, &HFF000000, 0), _
                              New Column(393, 5, "", False, False, False, 0, 0, 0, 0, 0, 0), _
                              New Column(393, 40, "BGA", True, False, False, 4, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
                              New Column(393, 40, "LAYER", True, False, False, 7, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
                              New Column(393, 40, "POOR", True, False, False, 6, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
                              New Column(393, 5, "", False, False, False, 0, 0, 0, 0, 0, 0), _
                              New Column(393, 40, "B", True, False, True, 1, &HFFE18080, &HFF000000, &HFFDC8585, &HFF000000, 0)}

    'Public kLeft() As Integer = {0, 50, 110, 110, 115, 157, 187, 229, 274, 316, 346, 388, 388, 393, 393, 393, 393, 393, 393, 393, 393, 393, 393, 393, 393, 393, 393}
    'Public kLength() As Integer = {50, 60, 50, 5, 42, 30, 42, 45, 42, 30, 42, 40, 5, 42, 30, 42, 45, 42, 30, 42, 40, 5, 40, 40, 40, 5, 40}
    'Public kTitle() As String = {"Measure", "BPM", "STOP", "", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "", "BGA", "LAYER", "POOR", "", "B"}
    'Public kEnabled() As Boolean = {False, True, True, False, True, True, True, True, True, True, True, True, False, True, True, True, True, True, True, True, True, False, True, True, True, False, True}
    'Public kNumericLabel() As Boolean = {True, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    'Public kVisible() As Boolean = {True, True, False, True, True, True, True, True, True, True, True, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, True}
    'Public kIdentifier() As Integer = {0, 3, 9, 0, 16, 11, 12, 13, 14, 15, 18, 19, 0, 21, 22, 23, 24, 25, 28, 29, 26, 0, 4, 7, 6, 0, 1}
    'Public kColor() As Integer = {&H0, &H0, &H0, &H0, &HFFB0B0B0, &HFF62B0FF, &HFFB0B0B0, &HFFFFC862, &HFFB0B0B0, &HFF62B0FF, &HFFB0B0B0, &HFF808080, &H0, &HFFB0B0B0, &HFF62B0FF, &HFFB0B0B0, &HFFFFC862, &HFFB0B0B0, &HFF62B0FF, &HFFB0B0B0, &HFF808080, &H0, &HFF8CD78A, &HFF8CD78A, &HFF8CD78A, &H0, &HFFE18080}
    'Public kForeColor() As Integer = {&HFF00FFFF, &HFFFF0000, &HFFFF0000, &H0, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000}
    'Public kColorL() As Integer = {&H0, &H0, &H0, &H0, &HFFC0C0C0, &HFF6AB0F7, &HFFC0C0C0, &HFFF7C66A, &HFFC0C0C0, &HFF6AB0F7, &HFFC0C0C0, &HFF909090, &H0, &HFFC0C0C0, &HFF6AB0F7, &HFFC0C0C0, &HFFF7C66A, &HFFC0C0C0, &HFF6AB0F7, &HFFC0C0C0, &HFF909090, &H0, &HFF90D38E, &HFF90D38E, &HFF90D38E, &H0, &HFFDC8585}
    'Public kForeColorL() As Integer = {&HFF00FFFF, &HFFFF0000, &HFFFF0000, &H0, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000, &HFF000000, &HFF000000, &H0, &HFF000000}
    'Public kBgColor() As Integer = {&H0, &H0, &H0, &H0, &HFF141414, &HFF000414, &HFF141414, &HFF150C01, &HFF141414, &HFF000414, &HFF141414, &H0, &H0, &HFF141414, &HFF000414, &HFF141414, &HFF150C01, &HFF141414, &HFF000414, &HFF141414, &H0, &H0, &H0, &H0, &H0, &H0, &H0}

    Dim MeasureLength(999) As Double
    Dim MeasureBottom(999) As Double

    ''' <summary>
    ''' Send command to winmm.dll
    ''' </summary>
    ''' <param name="lpstrCommand">Command string. ||
    ''' open "{Filename}" (type WaveAudio|MPEGVideo) alias {Name} ||
    ''' play {Name} notify ||
    ''' close {Name}</param>
    ''' <param name="lpstrReturnString">Just put Nothing.</param>
    ''' <param name="uReturnLength">Just put 0.</param>
    ''' <param name="hwndCallback">Just put 0.</param>
    ''' <returns>0 = Successful, Else = Error Code</returns>

    <DllImport("winmm.dll")> Public Shared Function mciSendString(ByVal lpstrCommand As String, ByVal lpstrReturnString As System.Text.StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Long
    End Function
    <DllImport("winmm.dll")> Public Shared Function mciGetErrorString(ByVal dwError As Long, ByVal lpstrBuffer As String, ByVal uLength As Long) As Long
    End Function

    Dim K() As Note = {New Note(niBPM, -1, 1200000, 0, False)}
    Dim mColumn(999) As Integer  '0 = no column, 1 = 1 column, etc.
    Dim GreatestVPosition As Double    '+ 2000 = -VS.Minimum

    Dim VSValue As Integer = 0 'Store value before ValueChange event
    Dim HSValue As Integer = 0 'Store value before ValueChange event

    'Dim SortingMethod As Integer = 1
    Dim MiddleButtonMoveMethod As Integer = 0
    Dim TextEncoding As System.Text.Encoding = System.Text.Encoding.Default
    Dim DispLang As String = ""     'Display Language
    Dim Recent() As String = {"", "", "", "", ""}
    Dim NTInput As Boolean = True
    Dim ShowFileName As Boolean = False

    Dim BeepWhileSaved As Boolean = True
    Dim BPMx1296 As Boolean = False
    Dim STOPx1296 As Boolean = False

    Dim IsInitializing As Boolean = True
    Dim FirstMouseEnter As Boolean = True

    Dim WAVMultiSelect As Boolean = True
    Dim WAVChangeLabel As Boolean = True
    Dim BeatChangeMode As Integer = 0

    'Dim FloatTolerance As Double = 0.0001R
    Dim BMSGridLimit As Double = 1.0R

    Dim LnObj As Integer = 0    '0 for none, 1-1295 for 01-ZZ

    'IO
    Dim FileName As String = "Untitled.bms"
    'Dim TitlePath As New Drawing2D.GraphicsPath
    Dim InitPath As String = ""
    Dim IsSaved As Boolean = True

    'Variables for Drag/Drop
    Dim DDFileName() As String = {}
    Dim SupportedFileExtension() As String = {".bms", ".bme", ".bml", ".pms", ".txt", ".sm", ".ibmsc"}
    Dim SupportedAudioExtension() As String = {".wav", ".mp3", ".ogg"}

    'Variables for theme
    'Dim SaveTheme As Boolean = True

    'Variables for undo/redo
    Dim sUndo(99) As UndoRedo.LinkedURCmd
    Dim sRedo(99) As UndoRedo.LinkedURCmd
    Dim sI As Integer = 0

    'Variables for select tool
    Dim DisableVerticalMove As Boolean = False
    Dim KMouseOver As Integer = -1   'Mouse is on which note (for drawing green outline)
    Dim pMouseDown As PointF = New Point(-1, -1)          'Mouse is clicked on which point (location for display) (for selection box)
    Dim pMouseMove As PointF = New Point(-1, -1)          'Mouse is moved to which point   (location for display) (for selection box)
    'Dim KMouseDown As Integer = -1   'Mouse is clicked on which note (for moving)
    Dim deltaVPosition As Double = 0   'difference between mouse and VPosition of K
    Dim bAdjustLength As Boolean     'If adjusting note length instead of moving it
    Dim bAdjustUpper As Boolean      'true = Adjusting upper end, false = adjusting lower end
    Dim bAdjustSingle As Boolean     'true if there is only one note to be adjusted
    Dim tempY As Integer
    Dim tempV As Integer
    Dim tempX As Integer
    Dim tempH As Integer
    Dim MiddleButtonLocation As New Point(0, 0)
    Dim MiddleButtonClicked As Boolean = False
    Dim MouseMoveStatus As Point = New Point(0, 0)  'mouse is moved to which point (For Status Panel)
    'Dim uCol As Integer         'temp variables for undo, original enabled columnindex
    'Dim uVPos As Double         'temp variables for undo, original vposition
    'Dim uPairWithI As Double    'temp variables for undo, original note length
    Dim uAdded As Boolean       'temp variables for undo, if undo command is added
    'Dim uNote As Note           'temp variables for undo, original note
    Dim uNotes(-1) As Note        'temp notes for undo
    Dim ctrlPressed As Boolean = False          'Indicates if the CTRL key is pressed while mousedown
    Dim ctrlForDuplicate As Boolean = False     'Indicates if duplicate notes of select/unselect note

    'Variables for write tool
    Dim TempDraw As Boolean = False
    Dim TempColumn As Integer = -1
    Dim TempVPosition As Double = -1.0#
    Dim TempLength As Double = 0.0#

    'Variables for post effects tool
    Dim vSelStart As Double = 192.0#
    Dim vSelLength As Double = 0.0#
    Dim vSelHalf As Double = 0.0#
    Dim vSelMouseOverLine As Integer = 0  '0 = nothing, 1 = start, 2 = half, 3 = end
    Dim vSelAdjust As Boolean = False
    Dim vSelK() As Note = {}
    Dim vSelPStart As Double = 192.0#
    Dim vSelPLength As Double = 0.0#
    Dim vSelPHalf As Double = 0.0#

    'Variables for Full-Screen Mode
    Dim isFullScreen As Boolean = False
    Dim previousWindowState As FormWindowState = FormWindowState.Normal
    Dim previousWindowPosition As New Rectangle(0, 0, 0, 0)

    'Variables misc
    Dim menuVPosition As Double = 0.0#
    Dim tempResize As Integer = 0

    '----AutoSave Options
    Dim PreviousAutoSavedFileName As String = ""
    Dim AutoSaveInterval As Integer = 120000

    '----ErrorCheck Options
    Dim ErrorCheck As Boolean = True

    '----Header Options
    Dim hWAV(1295) As String
    Dim hBPM(1295) As Integer   'x10000
    Dim hSTOP(1295) As Integer

    '----Grid Options
    Dim gSnap As Boolean = True
    Dim gShow As Boolean = True 'Grid
    Dim gShowS As Boolean = True 'Sub
    Dim gShowBG As Boolean = True 'BG Color
    Dim gShowM As Boolean = True 'Measure Label
    Dim gShowV As Boolean = True 'Vertical
    Dim gShowMB As Boolean = True 'Measure Barline
    Dim gShowC As Boolean = True 'Column Caption
    Dim gDivide As Integer = 16
    Dim gSub As Integer = 4
    Dim gSlash As Integer = 192
    Dim gxHeight As Single = 1.0!
    Dim gxWidth As Single = 1.0!
    Dim gWheel As Integer = 96
    Dim gPgUpDn As Integer = 384

    Dim gBLP As Boolean = False
    Dim gSTOP As Boolean = False
    Dim gBPM As Boolean = True
    'Dim gA8 As Boolean = False
    Dim iPlayer As Integer = 0
    Dim gCol As Integer = 46

    '----Visual Options
    Structure visualSettings
        Public ColumnTitle As SolidBrush
        Public ColumnTitleFont As Font
        Public Bg As SolidBrush
        Public pGrid As Pen
        Public pSub As Pen
        Public pVLine As Pen
        Public pMLine As Pen
        Public pBGMWav As Pen

        Public SelBox As Pen
        Public PECursor As Pen
        Public PEHalf As Pen
        Public PEDeltaMouseOver As Integer
        Public PEMouseOver As Pen
        Public PESel As SolidBrush
        Public PEBPM As SolidBrush
        Public PEBPMFont As Font
        Public MiddleDeltaRelease As Integer

        Public kHeight As Integer
        Public kFont As Font
        Public kMFont As Font
        Public kLabelVShift As Integer
        Public kLabelHShift As Integer
        Public kLabelHShiftL As Integer
        Public kMouseOver As Pen
        Public kMouseOverE As Pen
        Public kSelected As Pen
        Public kOpacity As Single

        Public Sub New( _
        ByVal voTitle As SolidBrush, _
        ByVal voTitleFont As Font, _
        ByVal voBg As SolidBrush, _
        ByVal voGrid As Pen, _
        ByVal voSub As Pen, _
        ByVal voVLine As Pen, _
        ByVal voMLine As Pen, _
        ByVal voBGMWav As Pen, _
 _
        ByVal voSelBox As Pen, _
        ByVal voPECursor As Pen, _
        ByVal voPEHalf As Pen, _
        ByVal voPEDeltaMouseOver As Integer, _
        ByVal voPEMouseOver As Pen, _
        ByVal voPESel As SolidBrush, _
        ByVal voPEBPM As SolidBrush, _
        ByVal voPEBPMFont As Font, _
        ByVal xMiddleDeltaRelease As Integer, _
 _
        ByVal vKHeight As Integer, _
        ByVal vKFont As Font, _
        ByVal vKMFont As Font, _
        ByVal vKLabelVShift As Integer, _
        ByVal vKLabelHShift As Integer, _
        ByVal vKLabelHShiftL As Integer, _
        ByVal vKMouseOver As Pen, _
        ByVal vKMouseOverE As Pen, _
        ByVal vKSelected As Pen, _
        ByVal vKOpacity As Single)

            ColumnTitle = voTitle
            ColumnTitleFont = voTitleFont
            Bg = voBg
            pGrid = voGrid
            pSub = voSub
            pVLine = voVLine
            pMLine = voMLine
            pBGMWav = voBGMWav

            SelBox = voSelBox
            PECursor = voPECursor
            PEHalf = voPEHalf
            PEDeltaMouseOver = voPEDeltaMouseOver
            PEMouseOver = voPEMouseOver
            PESel = voPESel
            PEBPM = voPEBPM
            PEBPMFont = voPEBPMFont
            MiddleDeltaRelease = xMiddleDeltaRelease

            kHeight = vKHeight
            kFont = vKFont
            kMFont = vKMFont
            kLabelVShift = vKLabelVShift
            kLabelHShift = vKLabelHShift
            kLabelHShiftL = vKLabelHShiftL
            kMouseOver = vKMouseOver
            kMouseOverE = vKMouseOverE
            kSelected = vKSelected
            kOpacity = vKOpacity
        End Sub
    End Structure

    Dim vo As New visualSettings(New SolidBrush(Color.Lime), _
                                New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), _
                                New SolidBrush(Color.Black), _
                                New Pen(Color.FromArgb(893008442)), _
                                New Pen(Color.FromArgb(1530542650)), _
                                New Pen(Color.FromArgb(-13158601)), _
                                New Pen(Color.FromArgb(1599230546)), _
                                New Pen(Color.FromArgb(851493056)), _
                                New Pen(Color.FromArgb(-1056964609)), _
                                New Pen(Color.FromArgb(&HC0FF8080)), _
                                New Pen(Color.FromArgb(&H808080FF)), _
                                5, _
                                New Pen(Color.FromArgb(&H80FF8080)), _
                                New SolidBrush(Color.FromArgb(855605376)), _
                                New SolidBrush(Color.FromArgb(855605376)), _
                                New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel), _
                                10, _
                                10, _
                                New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel), _
                                New Font("Verdana", 12, FontStyle.Regular, GraphicsUnit.Pixel), _
                                -2, _
                                0, _
                                2, _
                                New Pen(Color.Lime), _
                                New Pen(Color.FromArgb(-16711681)), _
                                New Pen(Color.Red), _
                                0.5)

    Public Sub setVO(ByVal xvo As visualSettings)
        vo = xvo
    End Sub

    'Public voTitle As New SolidBrush(Color.Lime)
    'Public voTitleFont As New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel)
    'Public voBg As New SolidBrush(Color.Black)
    'Public voGrid As New Pen(Color.FromArgb(893008442))
    'Public voSub As New Pen(Color.FromArgb(1530542650))
    'Public voVLine As New Pen(Color.FromArgb(-13158601))
    'Public voMLine As New Pen(Color.FromArgb(1599230546))
    'Public voBGMWav As New Pen(Color.FromArgb(851493056))
    '
    'Public voSelBox As New Pen(Color.FromArgb(-1056964609))
    'Public voPECursor As New Pen(Color.FromArgb(&HC0FF8080))
    'Public voPEHalf As New Pen(Color.FromArgb(&H808080FF))
    'Public voPEDeltaMouseOver As Integer = 5
    'Public voPEMouseOver As New Pen(Color.FromArgb(&H80FF8080))
    'Public voPESel As New SolidBrush(Color.FromArgb(855605376))
    'Public voPEBPM As New SolidBrush(Color.FromArgb(855605376))
    'Public voPEBPMFont As New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel)
    '
    'Public vKHeight As Integer = 10
    'Public vKFont As New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel)
    'Public vKMFont As New Font("Verdana", 12, FontStyle.Regular, GraphicsUnit.Pixel)
    'Public vKLabelVShift As Integer = -2
    'Public vKLabelHShift As Integer = 0
    'Public vKLabelHShiftL As Integer = 2
    'Public vKMouseOver As New Pen(Color.Lime)
    'Public vKMouseOverE As New Pen(Color.FromArgb(-16711681))
    'Public vKSelected As New Pen(Color.Red)
    'Public vKHidTransparency As Single = 0.5

    '----WaveForm Options
    Dim wWavL() As Short
    Dim wWavR() As Short
    Dim wLock As Boolean = True
    Dim wBitsPerSample As Short
    Dim wSampleRate As Integer
    Dim wNumChannels As Short
    Dim wPosition As Double = 0
    Dim wLeft As Integer = 50
    Dim wWidth As Integer = 100
    Dim wPrecision As Integer = 1

    '----Preview Options
    Structure PlayerArguments
        Public Path As String
        Public aBegin As String
        Public aHere As String
        Public aStop As String
        Public Sub New(ByVal xPath As String, ByVal xBegin As String, ByVal xHere As String, ByVal xStop As String)
            Path = xPath
            aBegin = xBegin
            aHere = xHere
            aStop = xStop
        End Sub
    End Structure

    Public pArgs() As PlayerArguments = {New PlayerArguments("<apppath>\uBMplay.exe", _
                                                             "-P -N0 ""<filename>""", _
                                                             "-P -N<measure> ""<filename>""", _
                                                             "-S"), _
                                         New PlayerArguments("<apppath>\o2play.exe", _
                                                             "-P -N0 ""<filename>""", _
                                                             "-P -N<measure> ""<filename>""", _
                                                             "-S")}
    Public CurrentPlayer As Integer = 0
    Dim PreviewOnClick As Boolean = True
    Dim PreviewErrorCheck As Boolean = False
    Dim ClickStopPreview As Boolean = True
    Dim pTempFileNames() As String = {}

    '----Split Panel Options
    Dim spWidth() As Single = {0, 100, 0}
    Dim spH() As Integer = {0, 0, 0}
    Dim spV() As Integer = {0, 0, 0}
    Dim spLock() As Boolean = {False, False, False}
    Dim spDiff() As Integer = {0, 0, 0}
    Dim spFocus As Integer = 1 '0 = Left, 1 = Middle, 2 = Right
    Dim spMouseOver As Integer = 1

    Dim AutoFocusMouseEnter As Boolean = False
    Dim FirstClickDisabled As Boolean = True
    Dim tempFirstMouseDown As Boolean = False

    Dim spMain() As Panel = {}

    '----Find Delete Replace Options
    Dim fdriMesL As Integer
    Dim fdriMesU As Integer
    Dim fdriLblL As Integer
    Dim fdriLblU As Integer
    Dim fdriValL As Integer
    Dim fdriValU As Integer
    Dim fdriCol() As Integer

    '----Language Pack Strings
    'Dim lpLLength As String = "Length:"
    'Dim lpLLongNote As String = "LongNote:"
    'Dim lpPOWnone As String = "None"
    'Dim lpTempWriteBPM As String = "BPM"

    'Public lpstat() As String = {"Statistics", _
    '                             "Total Notes", _
    '                             "Short Notes", _
    '                             "Long Notes", _
    '                             "Errors", _
    '                             "B Notes", _
    '                             "OK"}
    'Public lpparg() As String = {"Player Arguments Options", _
    '                             "Path", _
    '                             "Browse", _
    '                             "Arguments", _
    '                             "Play from beginning", _
    '                             "Play from current measure", _
    '                             "Stop", _
    '                             "References (case-sensitive):", _
    '                             "Directory of the application", _
    '                             "Current measure", _
    '                             "File Name", _
    '                             "OK", _
    '                             "Cancel"}
    'Public lpvo() As String = {"Visual Options", _
    '                           "Note Options", _
    '                           "Other Options", _
    '                           "Measure", _
    '                           "BPM", _
    '                           "seperator", _
    '                           "A1", _
    '                           "A2", _
    '                           "A3", _
    '                           "A4", _
    '                           "A5", _
    '                           "A6", _
    '                           "A7", _
    '                           "B", _
    '                           "Width", _
    '                           "Caption", _
    '                           "IsNum", _
    '                           "Note", _
    '                           "Label", _
    '                           "Long Note", _
    '                           "Long Note Label", _
    '                           "Bg", _
    '                           "Column Caption", _
    '                           "Background", _
    '                           "Grid", _
    '                           "Sub", _
    '                           "Vertical Line", _
    '                           "Measure BarLine", _
    '                           "BGM Waveform", _
    '                           "Selection Box Border", _
    '                           "Time Selection Cursor", _
    '                           "Time Selection Area", _
    '                           "Time Selection BPM", _
    '                           "Note Height", _
    '                           "Note Label", _
    '                           "Measure Label", _
    '                           "Label Vertical Shift", _
    '                           "Label Horizontal Shift", _
    '                           "LongNote Label Horizontal Shift", _
    '                           "MouseOver Border", _
    '                           "Selected Border", _
    '                           "MouseOver Border (End Point)", _
    '                           "OK", _
    '                           "Cancel", _
    '                           "Hidden Note Transparency"}
    'Public lpgo() As String = {"General Options", _
    '                           "Mouse Wheel", _
    '                           "Text Encoding", _
    '                           "Sorting Method", _
    '                           "One-directional Bubble Sort", _
    '                           "Insertion Sort", _
    '                           "Quick Sort", _
    '                           "Quick Sort d3", _
    '                           "Heap Sort", _
    '                           "OK", _
    '                           "Cancel", _
    '                           "Associate Filetype", _
    '                           "Set", _
    '                           "Beep while saved", _
    '                           "Add #STAGEFILE code", _
    '                           "Extend number of multi-byte BPMs to 1296", _
    '                           "Extend number of STOPs to 1296", _
    '                           "Automatically set focus to editing panel on mouse enter", _
    '                           "Disable first click if the editing panel is not focused", _
    '                           "AutoSave", _
    '                           "minutes", _
    '                           "Stop preview if clicked on the editing panel", _
    '                           "Max Grid Partition in BMS"}
    'Public lpfdr() As String = {"Note Range", _
    '                            "Measure Range", _
    '                            "Label Range", _
    '                            "Value Range", _
    '                            "to", _
    '                            "Selected", _
    '                            "Unselected", _
    '                            "Short", _
    '                            "Long", _
    '                            "Hidden", _
    '                            "Visible", _
    '                            "Column", _
    '                            "Select All", _
    '                            "Select Inverse", _
    '                            "Unselect All", _
    '                            "Operation", _
    '                            "Replace with Label:", _
    '                            "Replace with Value:", _
    '                            "Select", _
    '                            "Unselect", _
    '                            "Delete", _
    '                            "Close"}
    'Public lpimpSM() As String = {"Import *.SM file", _
    '                              "Difficulty", _
    '                              "Please note that bg musics and STOP values will not be imported.", _
    '                              "OK", _
    '                              "Cancel"}
    'Public lpfa() As String = {"BMS Sequence File", _
    '                           "Open", _
    '                           "Preview", _
    '                           "View Code"}

    'Public Property ShowCaption() As Boolean
    '    Get
    '        Return (GetWindowLong(Me.Handle, GWL_STYLE) And WS_CAPTION) = WS_CAPTION
    '    End Get
    '
    '    Set(ByVal Value As Boolean)
    '        Dim lStyle As Integer
    '
    '        lStyle = GetWindowLong(Me.Handle, GWL_STYLE)
    '
    '        If Value Then
    '            lStyle = lStyle Or WS_CAPTION
    '        Else
    '            lStyle = lStyle And Not WS_CAPTION
    '        End If
    '
    '        SetWindowLong(Me.Handle, GWL_STYLE, lStyle)
    '
    '        SetWindowPos(Me.Handle, New IntPtr(0), 0, 0, 0, 0, SWP_REFRESH)
    '    End Set
    'End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    'Private Function NewMargin(ByVal xLeft As Integer, ByVal xRight As Integer, ByVal xTop As Integer, ByVal xBottom As Integer) As MARGINS
    '    NewMargin.Left = xLeft
    '    NewMargin.Right = xRight
    '    NewMargin.Top = xTop
    '    NewMargin.Bottom = xBottom
    'End Function

    Private Function Add3Zeros(ByVal xNum As Integer) As String
        Dim xStr1 As String = "000" & xNum
        Return Mid(xStr1, Len(xStr1) - 2)
    End Function

    Private Function Add2Zeros(ByVal xNum As Integer) As String
        Dim xStr1 As String = "00" & xNum
        Return Mid(xStr1, Len(xStr1) - 1)
    End Function

    Private Function C10to36S(ByVal xStart As Integer) As Char
        If xStart < 10 Then Return CChar(CStr(xStart)) Else Return Chr(xStart + 55)
    End Function
    Private Function C36to10S(ByVal xChar As Char) As Integer
        Dim xAsc As Integer = Asc(UCase(xChar))
        If xAsc >= 48 And xAsc <= 57 Then
            Return xAsc - 48
        ElseIf xAsc >= 65 And xAsc <= 90 Then
            Return xAsc - 55
        End If
        Return 0
    End Function
    Private Function C10to36(ByVal xStart As Integer) As String
        If xStart < 1 Then xStart = 1
        If xStart > 1295 Then xStart = 1295
        Return C10to36S(xStart \ 36) & C10to36S(xStart Mod 36)
    End Function
    Private Function C36to10(ByVal xStart As String) As Integer
        xStart = Mid("00" & xStart, Len(xStart) + 1)
        Return C36to10S(xStart.Chars(0)) * 36 + C36to10S(xStart.Chars(1))
    End Function

    ''' <summary>
    ''' Adjust the brightness of a color.
    ''' </summary>
    ''' <param name="cStart">Original Color.</param>
    ''' <param name="iPercent">(-100 to 100) Brightness.</param>
    ''' <param name="iTransparency">(0 - 1) Transparency.</param>
    Private Shared Function AdjustBrightness(ByVal cStart As Color, ByVal iPercent As Single, ByVal iTransparency As Single) As System.Drawing.Color
        If cStart.A = 0 Then
            Return Color.FromArgb(0)
        Else
            Return Color.FromArgb( _
                    cStart.A * iTransparency, _
                    cStart.R * (100 - Math.Abs(iPercent)) * 0.01 + Math.Abs(CInt(iPercent >= 0) * iPercent) * 2.55, _
                    cStart.G * (100 - Math.Abs(iPercent)) * 0.01 + Math.Abs(CInt(iPercent >= 0) * iPercent) * 2.55, _
                    cStart.B * (100 - Math.Abs(iPercent)) * 0.01 + Math.Abs(CInt(iPercent >= 0) * iPercent) * 2.55)
        End If
    End Function

    Private Function nLeft(ByVal iCol As Integer) As Integer
        If iCol < niB Then Return col(iCol).Left Else Return col(niB).Left + (iCol - niB) * col(niB).Width
    End Function
    Private Function nLength(ByVal iCol As Integer) As Integer
        If Not nCol(iCol).isVisible Then Return 0
        If iCol < niB Then Return col(iCol).Width Else Return col(niB).Width
    End Function
    Private Function nTitle(ByVal iCol As Integer) As String
        If iCol < niB Then Return col(iCol).Title Else Return col(niB).Title & (iCol - niB + 1).ToString
    End Function
    Private Function nEnabled(ByVal iCol As Integer) As Boolean
        'If iCol < niB Then Return col(iCol).Enabled And col(iCol).Visible Else Return col(niB).Enabled And col(niB).Visible
        If iCol < niB Then Return col(iCol).isEnabledAfterAll Else Return col(niB).isEnabledAfterAll
    End Function
    Private Function nNumericLabel(ByVal iCol As Integer) As Boolean
        If iCol < niB Then Return col(iCol).isNumeric Else Return col(niB).isNumeric
    End Function
    Private Function nIdentifier(ByVal iCol As Integer, ByVal xVal As Integer, ByVal xLong As Boolean, ByVal xHidden As Boolean) As String
        Dim xI As Integer = nCol(iCol).Identifier
        If iCol = niBPM AndAlso (xVal / 10000 <> xVal \ 10000 Or xVal >= 2560000) Then xI += idflBPM
        If (iCol >= niA1 And iCol <= niA8) Or (iCol >= niD1 And iCol <= niD8) Then
            If xLong Then xI += idLong
            If xHidden Then xI += idHidden
        End If
        Return Add2Zeros(xI)
    End Function

    'Private Function nColor(ByVal I As Integer) As Color
    '    Return Color.FromArgb(kColor(IIf(I < niB, I, niB)))
    'End Function
    'Private Function nColorL(ByVal I As Integer) As Color
    '    Return Color.FromArgb(kColorL(IIf(I < niB, I, niB)))
    'End Function
    'Private Function nForeColor(ByVal I As Integer) As Color
    '    Return Color.FromArgb(kForeColor(IIf(I < niB, I, niB)))
    'End Function
    'Private Function nForeColorL(ByVal I As Integer) As Color
    '    Return Color.FromArgb(kForeColorL(IIf(I < niB, I, niB)))
    'End Function
    'Private Function nBgColor(ByVal I As Integer) As Color
    '    Return Color.FromArgb(kBgColor(IIf(I < niB, I, niB)))
    'End Function

    Private Function nCol(ByVal iCol As Integer) As Column
        If iCol < niB Then Return col(iCol) Else Return col(niB)
    End Function

    Private Function IdentifiertoColumnIndex(ByVal I As String) As Integer
        Select Case I
            Case "01" : Return niB
            Case "03", "08" : Return niBPM
            Case "09" : Return niSTOP
            Case "04" : Return niBGA
            Case "07" : Return niLAYER
            Case "06" : Return niPOOR

            Case "16", "36", "56", "76" : Return niA1
            Case "11", "31", "51", "71" : Return niA2
            Case "12", "32", "52", "72" : Return niA3
            Case "13", "33", "53", "73" : Return niA4
            Case "14", "34", "54", "74" : Return niA5
            Case "15", "35", "55", "75" : Return niA6
            Case "18", "38", "58", "78" : Return niA7
            Case "19", "39", "59", "79" : Return niA8

            Case "21", "41", "61", "81" : Return niD1
            Case "22", "42", "62", "82" : Return niD2
            Case "23", "43", "63", "83" : Return niD3
            Case "24", "44", "64", "84" : Return niD4
            Case "25", "45", "65", "85" : Return niD5
            Case "28", "48", "68", "88" : Return niD6
            Case "29", "49", "69", "89" : Return niD7
            Case "26", "46", "66", "86" : Return niD8

            Case Else : Return 0
        End Select
    End Function
    Private Function IdentifiertoLongNote(ByVal I As String) As Boolean
        Dim xI As Integer = CInt(Val(I))
        Return xI >= 50 And xI < 90
    End Function
    Private Function IdentifiertoHidden(ByVal I As String) As Boolean
        Dim xI As Integer = CInt(Val(I))
        Return (xI >= 30 And xI < 50) Or (xI >= 70 And xI < 90)
    End Function

    'Private Function ColumnIndextoConstName(ByVal I As Integer) As String
    '    Select Case I
    '        Case niMeasure : Return "Measure"
    '        Case niBPM : Return "BPM"
    '        Case niSTOP : Return "STOP"
    '        Case niS1 : Return "S1"
    '        Case niA1 : Return "A1"
    '        Case niA2 : Return "A2"
    '        Case niA3 : Return "A3"
    '        Case niA4 : Return "A4"
    '        Case niA5 : Return "A5"
    '        Case niA6 : Return "A6"
    '        Case niA7 : Return "A7"
    '        Case niA8 : Return "A8"
    '        Case niS2 : Return "S2"
    '        Case niD1 : Return "D1"
    '        Case niD2 : Return "D2"
    '        Case niD3 : Return "D3"
    '        Case niD4 : Return "D4"
    '        Case niD5 : Return "D5"
    '        Case niD6 : Return "D6"
    '        Case niD7 : Return "D7"
    '        Case niD8 : Return "D8"
    '        Case niS3 : Return "S3"
    '        Case niBGA : Return "BGA"
    '        Case niLAYER : Return "LAYER"
    '        Case niPOOR : Return "POOR"
    '        Case niS4 : Return "S4"
    '        Case niB : Return "B"
    '    End Select
    'End Function

    'Private Function MeasureHeight() As Single
    '    Return 192 * gxHeight
    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xHPosition">Original horizontal position.</param>
    ''' <param name="xHSVal">HS.Value</param>


    Private Function HorizontalPositiontoDisplay(ByVal xHPosition As Integer, ByVal xHSVal As Long) As Integer
        Return CInt(xHPosition * gxWidth - xHSVal * gxWidth)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xVPosition">Original vertical position.</param>
    ''' <param name="xVSVal">VS.Value</param>
    ''' <param name="xTHeight">Height of the panel. (DisplayRectangle, but not ClipRectangle)</param>


    Private Function VerticalPositiontoDisplay(ByVal xVPosition As Double, ByVal xVSVal As Long, ByVal xTHeight As Integer) As Integer
        Return xTHeight - CInt((xVPosition + xVSVal) * gxHeight) - 1
    End Function

    Public Function InMeasure(ByVal xVPos As Double) As Integer
        'Return Math.Floor((xVPos + FloatTolerance) / 192)
        'Return Math.Floor(xVPos / 192)
        Dim xI1 As Integer
        For xI1 = 1 To 999
            If xVPos < MeasureBottom(xI1) Then Exit For
        Next
        Return xI1 - 1
    End Function

    Private Function VPosition1000() As Double
        Return MeasureBottom(999) + MeasureLength(999)
    End Function

    Private Function SnapToGrid(ByVal xVPos As Double) As Double
        Dim xOffset As Double = MeasureBottom(InMeasure(xVPos))
        Dim xRatio As Double = 192.0R / gDivide
        Return Math.Floor((xVPos - xOffset) / xRatio) * xRatio + xOffset
    End Function

    Private Sub CalculateGreatestVPosition()
        'If K Is Nothing Then Exit Sub
        Dim xI1 As Integer
        GreatestVPosition = 0

        If NTInput Then
            For xI1 = UBound(K) To 0 Step -1
                If K(xI1).VPosition + K(xI1).Length > GreatestVPosition Then GreatestVPosition = K(xI1).VPosition + K(xI1).Length
            Next
        Else
            For xI1 = UBound(K) To 0 Step -1
                If K(xI1).VPosition > GreatestVPosition Then GreatestVPosition = K(xI1).VPosition
            Next
        End If

        Dim xI2 As Integer = -CInt(IIf(GreatestVPosition + 2000 > VPosition1000(), VPosition1000, GreatestVPosition + 2000))
        VS.Minimum = xI2
        VSL.Minimum = xI2
        VSR.Minimum = xI2
    End Sub

    'Private Function dbleql(ByVal xN1 As Double, ByVal xN2 As Double) As Boolean
    '    Return Math.Abs(xN1 - xN2) <= FloatTolerance
    'End Function
    '
    'Private Function dblgtr(ByVal xN1 As Double, ByVal xN2 As Double) As Boolean
    '    Return xN1 - xN2 > FloatTolerance
    'End Function
    '
    'Private Function dblgtreql(ByVal xN1 As Double, ByVal xN2 As Double) As Boolean
    '    Return xN1 - xN2 >= -FloatTolerance
    'End Function
    '
    'Private Function dblsmr(ByVal xN1 As Double, ByVal xN2 As Double) As Boolean
    '    Return xN2 - xN1 > FloatTolerance
    'End Function
    '
    'Private Function dblsmreql(ByVal xN1 As Double, ByVal xN2 As Double) As Boolean
    '    Return xN2 - xN1 >= -FloatTolerance
    'End Function

    Private Function GCD(ByVal NumA As Double, ByVal NumB As Double) As Double
        Dim xNMax As Double = NumA
        Dim xNMin As Double = NumB
        If NumA < NumB Then
            xNMax = NumB
            xNMin = NumA
        End If
        Do While xNMin >= BMSGridLimit
            GCD = xNMax - Math.Floor(xNMax / xNMin) * xNMin
            xNMax = xNMin
            xNMin = GCD
        Loop
        GCD = xNMax
    End Function

    Private Function RandomFileName(ByVal extWithDot As String) As String
        Do
            Randomize()
            RandomFileName = Now.Ticks & Mid(Rnd(), 3) & extWithDot
        Loop While File.Exists(RandomFileName) Or Directory.Exists(RandomFileName)
    End Function

    'Private Sub SortByVPosition() 
    '    Select Case SortingMethod
    '        Case 0 : SortByVPositionBubble()
    '        Case 1 : SortByVPositionInsertion()
    '        Case 2 : SortByVPositionQuick(0, UBound(K))
    '        Case 3 : SortByVPositionQuick3(0, UBound(K))
    '        Case 4 : SortByVPositionHeap()
    '    End Select
    'End Sub

    Private Sub SortByVPositionBubble() 'One-directional Bubble Sort
        Dim xI1 As Integer = 1
        Dim xNote As Note
        Do While xI1 <= UBound(K)
            If K(xI1 - 1).VPosition > K(xI1).VPosition Then
                'Swap
                xNote = K(xI1 - 1)
                K(xI1 - 1) = K(xI1)
                K(xI1) = xNote
                'To previous
                If xI1 > 1 Then xI1 -= 2
            End If
            xI1 += 1
        Loop
    End Sub

    Private Sub SortByVPositionInsertion() 'Insertion Sort
        If UBound(K) <= 0 Then Exit Sub
        Dim xNote As Note
        Dim xI1 As Integer
        Dim xI2 As Integer
        For xI1 = 2 To UBound(K)
            xNote = K(xI1)
            For xI2 = xI1 - 1 To 1 Step -1
                If K(xI2).VPosition > xNote.VPosition Then
                    K(xI2 + 1) = K(xI2)
                    '                    If KMouseDown = xI2 Then KMouseDown += 1
                    If xI2 = 1 Then
                        K(xI2) = xNote
                        '                       If KMouseDown = xI1 Then KMouseDown = xI2
                        Exit For
                    End If
                Else
                    K(xI2 + 1) = xNote
                    '                    If KMouseDown = xI1 Then KMouseDown = xI2 + 1
                    Exit For
                End If
            Next
        Next

    End Sub

    Private Sub SortByVPositionQuick(ByVal xMin As Integer, ByVal xMax As Integer) 'Quick Sort
        Dim xNote As Note
        Dim iHi As Integer
        Dim iLo As Integer
        Dim xI1 As Integer

        ' If min >= max, the list contains 0 or 1 items so it is sorted.
        If xMin >= xMax Then Exit Sub

        ' Pick the dividing value.
        xI1 = CInt((xMax - xMin) / 2) + xMin
        xNote = K(xI1)

        ' Swap it to the front.
        K(xI1) = K(xMin)

        iLo = xMin
        iHi = xMax
        Do
            ' Look down from hi for a value < med_value.
            Do While K(iHi).VPosition >= xNote.VPosition
                iHi = iHi - 1
                If iHi <= iLo Then Exit Do
            Loop
            If iHi <= iLo Then
                K(iLo) = xNote
                Exit Do
            End If

            ' Swap the lo and hi values.
            K(iLo) = K(iHi)

            ' Look up from lo for a value >= med_value.
            iLo = iLo + 1
            Do While K(iLo).VPosition < xNote.VPosition
                iLo = iLo + 1
                If iLo >= iHi Then Exit Do
            Loop
            If iLo >= iHi Then
                iLo = iHi
                K(iHi) = xNote
                Exit Do
            End If

            ' Swap the lo and hi values.
            K(iHi) = K(iLo)
        Loop

        ' Sort the two sublists.
        SortByVPositionQuick(xMin, iLo - 1)
        SortByVPositionQuick(iLo + 1, xMax)
    End Sub

    Private Sub SortByVPositionQuick3(ByVal xMin As Integer, ByVal xMax As Integer)
        Dim xxMin As Integer
        Dim xxMax As Integer
        Dim xxMid As Integer
        Dim xNote As Note
        Dim xNoteMid As Note
        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer

        'If xMax = 0 Then
        '    xMin = LBound(K1)
        '    xMax = UBound(K1)
        'End If
        xxMin = xMin
        xxMax = xMax
        xxMid = xMax - xMin + 1
        xI1 = CInt(Int(xxMid * Rnd())) + xMin
        xI2 = CInt(Int(xxMid * Rnd())) + xMin
        xI3 = CInt(Int(xxMid * Rnd())) + xMin
        If K(xI1).VPosition <= K(xI2).VPosition And K(xI2).VPosition <= K(xI3).VPosition Then
            xxMid = xI2
        Else
            If K(xI2).VPosition <= K(xI1).VPosition And K(xI1).VPosition <= K(xI3).VPosition Then
                xxMid = xI1
            Else
                xxMid = xI3
            End If
        End If
        xNoteMid = K(xxMid)
        Do
            Do While K(xxMin).VPosition < xNoteMid.VPosition And xxMin < xMax
                xxMin = xxMin + 1
            Loop
            Do While xNoteMid.VPosition < K(xxMax).VPosition And xxMax > xMin
                xxMax = xxMax - 1
            Loop
            If xxMin <= xxMax Then
                xNote = K(xxMin)
                K(xxMin) = K(xxMax)
                K(xxMax) = xNote
                xxMin = xxMin + 1
                xxMax = xxMax - 1
            End If
        Loop Until xxMin > xxMax
        If xxMax - xMin < xMax - xxMin Then
            If xMin < xxMax Then SortByVPositionQuick3(xMin, xxMax)
            If xxMin < xMax Then SortByVPositionQuick3(xxMin, xMax)
        Else
            If xxMin < xMax Then SortByVPositionQuick3(xxMin, xMax)
            If xMin < xxMax Then SortByVPositionQuick3(xMin, xxMax)
        End If
    End Sub

    Private Sub SortByVPositionHeap()
        Dim xI1 As Integer
        Dim xMin As Integer
        Dim xMax As Integer
        Dim xNote As Note

        xMin = LBound(K)
        xMax = UBound(K)
        For xI1 = (xMax + xMin) \ 2 To xMin Step -1
            SortByVPositionHeapSink(xI1, xMin, xMax)
        Next xI1
        For xI1 = xMax To xMin + 1 Step -1
            xNote = K(xI1)
            K(xI1) = K(xMin)
            K(xMin) = xNote
            SortByVPositionHeapSink(xMin, xMin, xI1 - 1)
        Next xI1
    End Sub

    Private Sub SortByVPositionHeapSink(ByVal xIndex As Integer, ByVal xMin As Integer, ByVal xMax As Integer)
        Dim xI1 As Integer
        Dim xNote As Note

        Do
            xI1 = xIndex + xIndex - (xMin - 1)
            Select Case xI1
                Case Is > xMax : Exit Do
                Case Is < xMax : If K(xI1 + 1).VPosition > K(xI1).VPosition Then xI1 = xI1 + 1
            End Select
            If K(xIndex).VPosition > K(xI1).VPosition Then Exit Do
            xNote = K(xIndex)
            K(xIndex) = K(xI1)
            K(xI1) = xNote
            xIndex = xI1
        Loop
    End Sub

    Private Sub UpdateMeasureBottom()
        MeasureBottom(0) = 0.0#
        For xI1 As Integer = 0 To 998
            MeasureBottom(xI1 + 1) = MeasureBottom(xI1) + MeasureLength(xI1)
        Next
    End Sub

    'Private Function KInfo(ByVal I As Integer) As String
    '    Return "K(" & I & ").ColumnIndex = " & K(I).ColumnIndex & vbCrLf & _
    '           "K(" & I & ").LongNote = " & K(I).LongNote & vbCrLf & _
    '           "K(" & I & ").PairWithI = " & K(I).PairWithI & vbCrLf & _
    '           "K(" & I & ").Selected = " & K(I).Selected & vbCrLf & _
    '           "K(" & I & ").Value = " & K(I).Value & vbCrLf & _
    '           "K(" & I & ").VPosition = " & K(I).VPosition
    'End Function 

    Private Function PathIsValid(ByVal sPath As String) As Boolean
        Return File.Exists(sPath) Or Directory.Exists(sPath)
    End Function

    Public Function PrevCodeToReal(ByVal InitStr As String) As String
        Dim xFileName As String = IIf(Not PathIsValid(FileName), _
                                        IIf(InitPath = "", My.Application.Info.DirectoryPath, InitPath), _
                                        ExcludeFileName(FileName)) _
                                        & "\___TempBMS.bms"
        Dim xMeasure As Integer = InMeasure(Math.Abs(spV(spFocus)))
        Dim xS1 As String = Replace(InitStr, "<apppath>", My.Application.Info.DirectoryPath)
        Dim xS2 As String = Replace(xS1, "<measure>", xMeasure)
        Dim xS3 As String = Replace(xS2, "<filename>", xFileName)
        Return xS3
    End Function

    Private Sub SetFileName(ByVal xFileName As String)
        FileName = xFileName.Trim
        InitPath = ExcludeFileName(FileName)
        'Dim xVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & _
        '                     IIf(My.Application.Info.Version.Build = 0, "", "." & My.Application.Info.Version.Build)
        'Me.Text = getFileName(FileName)
        'TitlePath = New Drawing2D.GraphicsPath
        'TitlePath.AddString("iBMSC " & xVersion & " - " & FileName, New FontFamily("Segoe UI"), 0, 14, New Point(0, 0), StringFormat.GenericDefault)
        SetIsSaved(IsSaved)
    End Sub

    Private Sub SetIsSaved(ByVal xBool As Boolean)
        'pttl.Refresh()
        'pIsSaved.Visible = Not xBool
        Dim xVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & _
                             IIf(My.Application.Info.Version.Build = 0, "", "." & My.Application.Info.Version.Build)
        Me.Text = IIf(xBool, "", "*") & GetFileName(FileName) & " - iBMS BMS Creator Delta " & xVersion
        IsSaved = xBool
    End Sub

    Private Sub PreviewNote(ByVal xFileLocation As String, ByVal bStop As Boolean)
        If bStop Then
            mciSendString("close PREV", Nothing, 0, 0)
        Else
            Dim sType As String = ""
            If UCase(Path.GetExtension(xFileLocation)) = ".OGG" Then
                sType = "type MPEGVideo "
            End If

            Dim xL1 As Long = mciSendString("open """ & xFileLocation & """ " & sType & "alias PREV", Nothing, 0, 0)
            Dim xL2 As Long = mciSendString("play PREV notify", Nothing, 0, 0)
            'If PreviewErrorCheck AndAlso (xL1 <> 0 Or xL2 <> 0) Then MsgBox(IIf(xL1 <> 0, lpmsg(5) & " ", lpmsg(6) & " ") & xFileLocation, MsgBoxStyle.Exclamation, lpmsg(4))
        End If
    End Sub

    Private Sub AddNote(ByVal xVPosition As Double, _
                        ByVal xColumnIndex As Integer, _
                        ByVal xValue As Integer, _
                        ByVal xLongNote As Boolean, _
                        ByVal xHidden As Boolean, _
               Optional ByVal xSelected As Boolean = False, _
               Optional ByVal OverWrite As Boolean = True, _
               Optional ByVal SortAndUpdatePairing As Boolean = True)

        If xVPosition < 0 Or xVPosition >= VPosition1000() Then Exit Sub

        Dim xI1 As Integer = 1

        If OverWrite Then
            Do While xI1 <= UBound(K)
                If K(xI1).VPosition = xVPosition And K(xI1).ColumnIndex = xColumnIndex Then RemoveNote(xI1) Else xI1 += 1
            Loop
        End If

        ReDim Preserve K(UBound(K) + 1)
        With K(UBound(K))
            .VPosition = xVPosition
            .ColumnIndex = xColumnIndex
            .Value = xValue
            .LongNote = xLongNote
            .Hidden = xHidden
            .Selected = xSelected And nEnabled(xColumnIndex)
        End With

        If SortAndUpdatePairing Then SortByVPositionInsertion() : UpdatePairing()
        CalculateTotalNotes()
    End Sub

    Private Sub RemoveNote(ByVal I As Integer, Optional ByVal SortAndUpdatePairing As Boolean = True)
        KMouseOver = -1
        Dim xI2 As Integer
        For xI2 = I + 1 To UBound(K)
            K(xI2 - 1) = K(xI2)
        Next
        ReDim Preserve K(UBound(K) - 1)
        If SortAndUpdatePairing Then SortByVPositionInsertion() : UpdatePairing()
        'CalculateTotalNotes()
    End Sub

    Private Sub AddNotes(Optional ByVal xSelected As Boolean = True, Optional ByVal SortAndUpdatePairing As Boolean = True)
        Dim xStrLine() As String = Split(Clipboard.GetText, vbCrLf)

        Dim xI1 As Integer
        For xI1 = 0 To UBound(K)
            K(xI1).Selected = False
        Next

        Dim xVS As Long = spV(spFocus)
        Dim xTempVP As Double
        Dim xKbu() As Note = K

        If xStrLine(0) = "iBMSC Clipboard Data" Then
            If NTInput Then ReDim Preserve K(0)

            'paste
            Dim xStrSub() As String
            For xI1 = 1 To UBound(xStrLine)
                If xStrLine(xI1).Trim = "" Then Continue For
                xStrSub = Split(xStrLine(xI1), " ")
                xTempVP = Val(xStrSub(1)) + MeasureBottom(InMeasure(-xVS) + 1)
                If UBound(xStrSub) = 4 And xTempVP >= 0 And xTempVP < VPosition1000() Then
                    ReDim Preserve K(UBound(K) + 1)
                    With K(UBound(K))
                        .ColumnIndex = Val(xStrSub(0))
                        .VPosition = xTempVP
                        .Value = Val(xStrSub(2))
                        .LongNote = CBool(Val(xStrSub(3)))
                        .Hidden = CBool(Val(xStrSub(4)))
                        .Selected = xSelected
                    End With
                End If
            Next

            'convert
            If NTInput Then
                ConvertBMSE2NT()

                For xI1 = 1 To UBound(K)
                    K(xI1 - 1) = K(xI1)
                Next
                ReDim Preserve K(UBound(K) - 1)

                Dim xKn() As Note = K
                K = xKbu

                Dim xIStart As Integer = K.Length
                ReDim Preserve K(UBound(K) + xKn.Length)

                For xI1 = xIStart To UBound(K)
                    K(xI1) = xKn(xI1 - xIStart)
                Next
            End If

        ElseIf xStrLine(0) = "iBMSC Clipboard Data xNT" Then
            If Not NTInput Then ReDim Preserve K(0)

            'paste
            Dim xStrSub() As String
            For xI1 = 1 To UBound(xStrLine)
                If xStrLine(xI1).Trim = "" Then Continue For
                xStrSub = Split(xStrLine(xI1), " ")
                xTempVP = Val(xStrSub(1)) + MeasureBottom(InMeasure(-xVS) + 1)
                If UBound(xStrSub) = 4 And xTempVP >= 0 And xTempVP < VPosition1000() Then
                    ReDim Preserve K(UBound(K) + 1)
                    With K(UBound(K))
                        .ColumnIndex = Val(xStrSub(0))
                        .VPosition = xTempVP
                        .Value = Val(xStrSub(2))
                        .Length = Val(xStrSub(3))
                        .Hidden = CBool(Val(xStrSub(4)))
                        .Selected = xSelected
                    End With
                End If
            Next

            'convert
            If Not NTInput Then
                ConvertNT2BMSE()

                For xI1 = 1 To UBound(K)
                    K(xI1 - 1) = K(xI1)
                Next
                ReDim Preserve K(UBound(K) - 1)

                Dim xKn() As Note = K
                K = xKbu

                Dim xIStart As Integer = K.Length
                ReDim Preserve K(UBound(K) + xKn.Length)

                For xI1 = xIStart To UBound(K)
                    K(xI1) = xKn(xI1 - xIStart)
                Next
            End If

        ElseIf xStrLine(0) = "BMSE ClipBoard Object Data Format" Then
            If NTInput Then ReDim Preserve K(0)

            'paste
            For xI1 = 1 To UBound(xStrLine)
                xTempVP = Val(Mid(xStrLine(xI1), 5, 7)) + MeasureBottom(InMeasure(-xVS) + 1)
                If Len(xStrLine(xI1)) > 11 And IdentifiertoColumnIndex(Mid(xStrLine(xI1), 2, 2)) > 0 And xTempVP >= 0 And xTempVP < VPosition1000() Then
                    ReDim Preserve K(UBound(K) + 1)
                    With K(UBound(K))
                        .ColumnIndex = IdentifiertoColumnIndex(Mid(xStrLine(xI1), 2, 2))
                        .VPosition = xTempVP
                        .Value = Val(Mid(xStrLine(xI1), 12)) * 10000
                        .LongNote = Mid(xStrLine(xI1), 4, 1) = "2"
                        .Hidden = Mid(xStrLine(xI1), 4, 1) = "1"
                        .Selected = xSelected And nEnabled(.ColumnIndex)
                    End With
                End If
            Next

            'convert
            If NTInput Then
                ConvertBMSE2NT()

                For xI1 = 1 To UBound(K)
                    K(xI1 - 1) = K(xI1)
                Next
                ReDim Preserve K(UBound(K) - 1)

                Dim xKn() As Note = K
                K = xKbu

                Dim xIStart As Integer = K.Length
                ReDim Preserve K(UBound(K) + xKn.Length)

                For xI1 = xIStart To UBound(K)
                    K(xI1) = xKn(xI1 - xIStart)
                Next
            End If
        End If

        If SortAndUpdatePairing Then SortByVPositionInsertion() : UpdatePairing()
        CalculateTotalNotes()
    End Sub

    Private Sub CopyNotes(Optional ByVal Unselect As Boolean = True)
        Dim xStrAll As String = "iBMSC Clipboard Data" & IIf(NTInput, " xNT", "")
        Dim xI1 As Integer
        Dim MinMeasure As Double = 999

        For xI1 = 1 To UBound(K)
            If K(xI1).Selected And InMeasure(K(xI1).VPosition) < MinMeasure Then MinMeasure = InMeasure(K(xI1).VPosition)
        Next
        MinMeasure = MeasureBottom(MinMeasure)

        If Not NTInput Then
            For xI1 = 1 To UBound(K)
                If K(xI1).Selected Then
                    xStrAll &= vbCrLf & K(xI1).ColumnIndex.ToString & " " & _
                                       (K(xI1).VPosition - MinMeasure).ToString & " " & _
                                        K(xI1).Value.ToString & " " & _
                                   CInt(K(xI1).LongNote).ToString & " " & _
                                   CInt(K(xI1).Hidden).ToString
                    K(xI1).Selected = Not Unselect
                End If
            Next

        Else
            For xI1 = 1 To UBound(K)
                If K(xI1).Selected Then
                    xStrAll &= vbCrLf & K(xI1).ColumnIndex.ToString & " " & _
                                       (K(xI1).VPosition - MinMeasure).ToString & " " & _
                                        K(xI1).Value.ToString & " " & _
                                        K(xI1).Length.ToString & " " & _
                                   CInt(K(xI1).Hidden).ToString
                    K(xI1).Selected = Not Unselect
                End If
            Next
        End If

        Clipboard.SetText(xStrAll)
    End Sub

    Private Sub RemoveNotes(Optional ByVal SortAndUpdatePairing As Boolean = True)
        If UBound(K) = 0 Then Exit Sub

        KMouseOver = -1
        Dim xI1 As Integer = 1
        Dim xI2 As Integer
        Do
            If K(xI1).Selected Then
                For xI2 = xI1 + 1 To UBound(K)
                    K(xI2 - 1) = K(xI2)
                Next
                ReDim Preserve K(UBound(K) - 1)
                xI1 = 0
            End If
            xI1 += 1
        Loop While xI1 < UBound(K) + 1
        If SortAndUpdatePairing Then SortByVPositionInsertion() : UpdatePairing()
        CalculateTotalNotes()
    End Sub

    Private Function EnabledColumnToReal(ByVal cEnabled As Integer) As Integer
        Dim xI1 As Integer = 0
        Do
            If xI1 >= gCol Then Exit Do
            If Not nEnabled(xI1) Then cEnabled += 1
            If xI1 >= cEnabled Then Exit Do
            xI1 += 1
        Loop
        Return cEnabled
    End Function

    Private Function RealColumnToEnabled(ByVal cReal As Integer) As Integer
        Dim xI1 As Integer
        For xI1 = 0 To cReal - 1
            If Not nEnabled(xI1) Then cReal -= 1
        Next
        Return cReal
    End Function

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If pTempFileNames IsNot Nothing Then
            For Each xStr As String In pTempFileNames
                IO.File.Delete(xStr)
            Next
        End If
        If PreviousAutoSavedFileName <> "" Then IO.File.Delete(PreviousAutoSavedFileName)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsSaved Then
            Dim xStr As String = Locale.Messages.SaveOnExit
            If e.CloseReason = CloseReason.WindowsShutDown Then xStr = Locale.Messages.SaveOnExit1
            If e.CloseReason = CloseReason.TaskManagerClosing Then xStr = Locale.Messages.SaveOnExit2

            Dim xResult As MsgBoxResult = MsgBox(xStr, MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, Me.Text)

            If xResult = MsgBoxResult.Yes Then
                If ExcludeFileName(FileName) = "" Then
                    Dim xDSave As New SaveFileDialog
                    xDSave.Filter = Locale.FileType._bms & "|*.bms;*.bme;*.bml;*.pms;*.txt|" & _
                                    Locale.FileType.BMS & "|*.bms|" & _
                                    Locale.FileType.BME & "|*.bme|" & _
                                    Locale.FileType.BML & "|*.bml|" & _
                                    Locale.FileType.PMS & "|*.pms|" & _
                                    Locale.FileType.TXT & "|*.txt|" & _
                                    Locale.FileType._all & "|*.*"
                    xDSave.DefaultExt = "bms"
                    xDSave.InitialDirectory = InitPath

                    If xDSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then e.Cancel = True : Exit Sub
                    SetFileName(xDSave.FileName)
                End If
                Dim xStrAll As String = SaveBMS()
                My.Computer.FileSystem.WriteAllText(FileName, xStrAll, False, TextEncoding)
                NewRecent(FileName)
                If BeepWhileSaved Then Beep()
            End If

            If xResult = MsgBoxResult.Cancel Then e.Cancel = True
        End If

        If Not e.Cancel Then
            'If SaveTheme Then
            '    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Skin.cff", SaveSkinCFF, False, System.Text.Encoding.Unicode)
            'Else
            '    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Skin.cff", "", False, System.Text.Encoding.Unicode)
            'End If
            '
            'My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\PlayerArgs.cff", SavePlayerCFF, False, System.Text.Encoding.Unicode)
            'My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Config.cff", SaveCFF, False, System.Text.Encoding.Unicode)
            'My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\PreConfig.cff", "", False, System.Text.Encoding.Unicode)
            Me.SaveSettings(My.Application.Info.DirectoryPath & "\iBMSC.Settings.xml", False)
        End If
    End Sub

    Private Function FilterFileBySupported(ByVal xFile() As String, ByVal xFilter() As String) As String()
        Dim xPath(-1) As String
        For xI1 As Integer = 0 To UBound(xFile)
            If My.Computer.FileSystem.FileExists(xFile(xI1)) And Array.IndexOf(xFilter, Path.GetExtension(xFile(xI1))) <> -1 Then
                ReDim Preserve xPath(UBound(xPath) + 1)
                xPath(UBound(xPath)) = xFile(xI1)
            End If

            If My.Computer.FileSystem.DirectoryExists(xFile(xI1)) Then
                Dim xFileNames() As FileInfo = My.Computer.FileSystem.GetDirectoryInfo(xFile(xI1)).GetFiles()
                For Each xStr As FileInfo In xFileNames
                    If Array.IndexOf(xFilter, xStr.Extension) = -1 Then Continue For
                    ReDim Preserve xPath(UBound(xPath) + 1)
                    xPath(UBound(xPath)) = xStr.FullName
                Next
            End If
        Next

        Return xPath
    End Function

    Private Sub InitializeNewBMS()
        'ReDim K(0)
        'With K(0)
        ' .ColumnIndex = niBPM
        ' .VPosition = -1
        ' .LongNote = False
        ' .Selected = False
        ' .Value = 1200000
        'End With

        THTitle.Text = ""
        THArtist.Text = ""
        THGenre.Text = ""
        THBPM.Value = 120
        If CHPlayer.SelectedIndex = -1 Then CHPlayer.SelectedIndex = 0
        CHRank.SelectedIndex = 3
        THPlayLevel.Text = ""
        THSubTitle.Text = ""
        THSubArtist.Text = ""
        THStageFile.Text = ""
        THBanner.Text = ""
        THBackBMP.Text = ""
        CHDifficulty.SelectedIndex = 0
        THExRank.Text = ""
        THTotal.Text = ""
        THComment.Text = ""
        'THLnType.Text = "1"
        CHLnObj.SelectedIndex = 0

        TExpansion.Text = ""

        LBeat.Items.Clear()
        For xI1 As Integer = 0 To 999
            MeasureLength(xI1) = 192.0R
            MeasureBottom(xI1) = xI1 * 192.0R
            LBeat.Items.Add(Add3Zeros(xI1) & ": 1 ( 4 / 4 )")
        Next
    End Sub

    Private Sub InitializeOpenBMS()
        CHPlayer.SelectedIndex = 0
        'THLnType.Text = ""
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            DDFileName = FilterFileBySupported(CType(e.Data.GetData(DataFormats.FileDrop), String()), SupportedFileExtension)
        Else
            e.Effect = DragDropEffects.None
        End If
        RefreshPanelAll()
    End Sub

    Private Sub Form1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DragLeave
        ReDim DDFileName(-1)
        RefreshPanelAll()
    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragDrop
        ReDim DDFileName(-1)
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Return

        Dim xOrigPath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        Dim xPath() As String = FilterFileBySupported(xOrigPath, SupportedFileExtension)
        If xPath.Length > 0 Then
            Dim xProg As New fLoadFileProgress(xPath, IsSaved)
            xProg.ShowDialog(Me)
        End If

        RefreshPanelAll()
    End Sub

    Private Sub setFullScreen(ByVal value As Boolean)
        If value Then
            If Me.WindowState = FormWindowState.Minimized Then Exit Sub

            Me.SuspendLayout()
            previousWindowPosition.Location = Me.Location
            previousWindowPosition.Size = Me.Size
            previousWindowState = Me.WindowState

            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            ToolStripContainer1.TopToolStripPanelVisible = False

            Me.ResumeLayout()
            isFullScreen = True
        Else
            Me.SuspendLayout()
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            ToolStripContainer1.TopToolStripPanelVisible = True
            Me.WindowState = FormWindowState.Normal

            Me.WindowState = previousWindowState
            If Me.WindowState = FormWindowState.Normal Then
                Me.Location = previousWindowPosition.Location
                Me.Size = previousWindowPosition.Size
            End If

            Me.ResumeLayout()
            isFullScreen = False
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F4
                If Not My.Computer.Keyboard.AltKeyDown Then MsgBox(Locale.Messages.EraserObsolete, MsgBoxStyle.Information, "Eraser tool")
            Case Keys.F11
                setFullScreen(Not isFullScreen)
        End Select
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Friend Sub ReadFile(ByVal xPath As String)
        Select Case LCase(Path.GetExtension(xPath))
            Case ".bms", ".bme", ".bml", ".pms", ".txt"
                OpenBMS(My.Computer.FileSystem.ReadAllText(xPath, TextEncoding))
                ClearUndo()
                NewRecent(xPath)
                SetFileName(xPath)
                SetIsSaved(True)

            Case ".sm"
                If OpenSM(My.Computer.FileSystem.ReadAllText(xPath, TextEncoding)) Then Return
                InitPath = ExcludeFileName(xPath)
                ClearUndo()
                SetFileName("Untitled.bms")
                SetIsSaved(False)

            Case ".ibmsc"
                OpeniBMSC(xPath)
                InitPath = ExcludeFileName(xPath)
                NewRecent(xPath)
                SetFileName("Imported_" & GetFileName(xPath))
                SetIsSaved(False)

        End Select
    End Sub

    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.Style = cp.Style And Not WS_CAPTION
    '        Return cp
    '    End Get
    'End Property

    '    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '        Get
    '            Const WS_CHILDWINDOW As Int32 = &H40000000
    '            Const WS_CLIPCHILDREN As Int32 = &H2000000
    '            Const WS_CLIPSIBLINGS As Int32 = &H4000000
    '            Const WS_MINIMIZEBOX As Int32 = &H20000
    '            Const WS_MAXIMIZEBOX As Int32 = &H10000
    '            Const WS_THICKFRAME As Int32 = &H40000
    '            Const WS_SYSMENU As Int32 = &H80000
    '            Const CS_DBLCLKS As Integer = &H8
    '            Const CS_DROPSHADOW As Integer = &H20000
    '            Dim cp As CreateParams = MyBase.CreateParams
    '            cp.Style = WS_CLIPCHILDREN Or WS_CLIPSIBLINGS Or WS_MAXIMIZEBOX Or WS_MINIMIZEBOX Or WS_SYSMENU Or WS_THICKFRAME
    '
    '            If Me.DesignMode Then
    '                cp.Style = cp.Style Or WS_CHILDWINDOW
    '            End If
    '
    '        Dim ClassFlags As Integer = CS_DBLCLKS
    '        Dim OSVER As Integer = Environment.OSVersion.Version.Major * 10
    '        OSVER += Environment.OSVersion.Version.Minor
    '        If OSVER >= 51 Then ClassFlags = ClassFlags Or CS_DROPSHADOW
    '        cp.ClassStyle = ClassFlags
    '        Return cp
    '    End Get
    'End Property

    <DllImport("user32.dll")> Private Shared Function LoadCursorFromFile(ByVal fileName As String) As IntPtr
    End Function
    Public Shared Function ActuallyLoadCursor(ByVal path As String) As Cursor
        Return New Cursor(LoadCursorFromFile(path))
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Me.TopMost = True
        Me.SuspendLayout()
        Me.Visible = False

        'POBMP.Dispose()
        'POBGA.Dispose()

        'Me.MaximizedBounds = Screen.GetWorkingArea(Me)
        'Me.Visible = False
        SetFileName(FileName)
        'Me.ShowCaption = False
        'SetWindowText(Me.Handle.ToInt32, FileName)

        InitializeNewBMS()
        'nBeatD.SelectedIndex = 4

        Try
            Dim xTempFileName As String = RandomFileName(".cur")
            My.Computer.FileSystem.WriteAllBytes(xTempFileName, My.Resources.CursorResizeDown, False)
            Dim xDownCursor As Cursor = ActuallyLoadCursor(xTempFileName)
            My.Computer.FileSystem.WriteAllBytes(xtempfilename, My.Resources.CursorResizeLeft, False)
            Dim xLeftCursor As Cursor = ActuallyLoadCursor(xTempFileName)
            My.Computer.FileSystem.WriteAllBytes(xTempFileName, My.Resources.CursorResizeRight, False)
            Dim xRightCursor As Cursor = ActuallyLoadCursor(xTempFileName)
            System.IO.File.Delete(xTempFileName)

            POWAVResizer.Cursor = xDownCursor
            POBeatResizer.Cursor = xDownCursor
            POExpansionResizer.Cursor = xDownCursor

            POptionsResizer.Cursor = xLeftCursor

            SpL.Cursor = xRightCursor
            SpR.Cursor = xLeftCursor
        Catch ex As Exception

        End Try

        spMain = New Panel() {PMainInL, PMainIn, PMainInR}
        'spMain.Add(PMainInL)
        'spMain.Add(PMainIn)
        'spMain.Add(PMainInR)
        'AddHandler PMainIn.Click, AddressOf PMainInClick
        'AddHandler PMainIn.LostFocus, AddressOf PMainInLostFocus
        'AddHandler PMainIn.MouseDown, AddressOf PMainInMouseDown
        'AddHandler PMainIn.MouseEnter, AddressOf PMainInMouseEnter
        'AddHandler PMainIn.MouseLeave, AddressOf PMainInMouseLeave
        'AddHandler PMainIn.MouseMove, AddressOf PMainInMouseMove
        'AddHandler PMainIn.MouseUp, AddressOf PMainInMouseUp
        'AddHandler PMainIn.MouseWheel, AddressOf PMainInMouseWheel
        'AddHandler PMainIn.Paint, AddressOf PMainInPaint
        'AddHandler PMainIn.PreviewKeyDown, AddressOf PMainInPreviewKeyDown
        'AddHandler PMainIn.Resize, AddressOf PMainInResize
        'AddHandler PMainInL.Click, AddressOf PMainInClick
        'AddHandler PMainInL.LostFocus, AddressOf PMainInLostFocus
        'AddHandler PMainInL.MouseDown, AddressOf PMainInMouseDown
        'AddHandler PMainInL.MouseEnter, AddressOf PMainInMouseEnter
        'AddHandler PMainInL.MouseLeave, AddressOf PMainInMouseLeave
        'AddHandler PMainInL.MouseMove, AddressOf PMainInMouseMove
        'AddHandler PMainInL.MouseUp, AddressOf PMainInMouseUp
        'AddHandler PMainInL.MouseWheel, AddressOf PMainInMouseWheel
        'AddHandler PMainInL.Paint, AddressOf PMainInPaint
        'AddHandler PMainInL.PreviewKeyDown, AddressOf PMainInPreviewKeyDown
        'AddHandler PMainInL.Resize, AddressOf PMainInResize
        'AddHandler PMainInR.Click, AddressOf PMainInClick
        'AddHandler PMainInR.LostFocus, AddressOf PMainInLostFocus
        'AddHandler PMainInR.MouseDown, AddressOf PMainInMouseDown
        'AddHandler PMainInR.MouseEnter, AddressOf PMainInMouseEnter
        'AddHandler PMainInR.MouseLeave, AddressOf PMainInMouseLeave
        'AddHandler PMainInR.MouseMove, AddressOf PMainInMouseMove
        'AddHandler PMainInR.MouseUp, AddressOf PMainInMouseUp
        'AddHandler PMainInR.MouseWheel, AddressOf PMainInMouseWheel
        'AddHandler PMainInR.Paint, AddressOf PMainInPaint
        'AddHandler PMainInR.PreviewKeyDown, AddressOf PMainInPreviewKeyDown
        'AddHandler PMainInR.Resize, AddressOf PMainInResize

        'ReDim K(0)
        'ReDim mColumn(999)
        'ReDim hWAV(1295)
        'ReDim hBPM(1295)    'x10000
        'ReDim hSTOP(1295)
        Dim xI1 As Integer

        'ReDim sUndo(99)
        'ReDim sRedo(99)
        sUndo(0) = New UndoRedo.NoOperation
        sUndo(1) = New UndoRedo.NoOperation
        sRedo(0) = New UndoRedo.NoOperation
        sRedo(1) = New UndoRedo.NoOperation
        sI = 0

        'With K(0)
        '    .ColumnIndex = niBPM
        '    .VPosition = -1
        '    .LongNote = False
        '    .Selected = False
        '    .Value = 1200000
        'End With

        LWAV.Items.Clear()
        For xI1 = 1 To 1295
            LWAV.Items.Add(C10to36(xI1) & ":")
        Next
        LWAV.SelectedIndex = 0
        CHPlayer.SelectedIndex = 0

        CalculateGreatestVPosition()
        TBLangRefresh_Click(TBLangRefresh, Nothing)
        TBThemeRefresh_Click(TBThemeRefresh, Nothing)
        'Do
        ' Try
        ' TBLangRefresh_Click(TBLangRefresh, Nothing)
        ' TBThemeRefresh_Click(TBThemeRefresh, Nothing)
        ' Catch ex As Exception
        ' Continue Do
        ' End Try
        ' Exit Do
        ' Loop

        POHeaderPart2.Visible = False
        POGridPart2.Visible = False
        POWaveFormPart2.Visible = False

        'On Error Resume Next
        'LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\PreConfig.cff", System.Text.Encoding.Unicode))
        'LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Config.cff", System.Text.Encoding.Unicode))
        'LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\PlayerArgs.cff", System.Text.Encoding.Unicode))
        'LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Skin.cff", System.Text.Encoding.Unicode))
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\iBMSC.Settings.xml") Then
            LoadSettings(My.Application.Info.DirectoryPath & "\iBMSC.Settings.xml")
            'Else
            '---- Settings for first-time start-up ---------------------------------------------------------------------------
            'Me.LoadLocale(My.Application.Info.DirectoryPath & "\Data\chs.Lang.xml")
            '-----------------------------------------------------------------------------------------------------------------
        End If
        'On Error GoTo 0
        SetIsSaved(True)

        Dim xStr() As String = Environment.GetCommandLineArgs
        'Dim xStr() As String = {Application.ExecutablePath, "C:\Users\User\Desktop\yang run xuan\SoFtwArES\Games\O2Mania\music\SHOOT!\shoot! -NM-.bms"}

        If xStr.Length = 2 Then
            ReadFile(xStr(1))
            If LCase(Path.GetExtension(xStr(1))) = ".ibmsc" AndAlso GetFileName(xStr(1)).StartsWith("AutoSave_", True, Nothing) Then GoTo 1000
        End If

        'pIsSaved.Visible = Not IsSaved
        IsInitializing = False

        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then GoTo 1000
        Dim xFiles() As FileInfo = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).GetFiles("AutoSave_*.IBMSC")
        If xFiles Is Nothing OrElse xFiles.Length = 0 Then GoTo 1000

        'Me.TopMost = True
        If MsgBox(Replace(Locale.Messages.RestoreAutosavedFile, "{}", xFiles.Length), MsgBoxStyle.YesNo Or MsgBoxStyle.MsgBoxSetForeground) = MsgBoxResult.Yes Then
            For Each xF As FileInfo In xFiles
                'MsgBox(xF.FullName)
                System.Diagnostics.Process.Start(Application.ExecutablePath, """" & xF.FullName & """")
            Next
        End If

        For Each xF As FileInfo In xFiles
            ReDim Preserve pTempFileNames(UBound(pTempFileNames) + 1)
            pTempFileNames(UBound(pTempFileNames)) = xF.FullName
        Next

1000:
        IsInitializing = False
        POStatusRefresh()
        Me.ResumeLayout()

        tempResize = Me.WindowState
        Me.TopMost = False
        Me.WindowState = tempResize

        Me.Visible = True
    End Sub

    'Private Sub RefreshPanelLabel()
    '    'Dim currentContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
    '    Dim e1 As BufferedGraphics = BufferedGraphicsManager.Current.Allocate(PMainLabel.CreateGraphics, PMainLabel.DisplayRectangle)
    '    e1.Graphics.FillRectangle(vo.Bg, PMainLabel.DisplayRectangle)
    '
    '    Dim xI1 As Integer
    '    'Bg color + Vertical line
    '    For xI1 = 0 To 30
    '        If Not nBgColor(xI1).GetBrightness = 0 Then
    '            e1.Graphics.FillRectangle(New SolidBrush(nBgColor(xI1)), nLeft(xI1) * gxWidth - HS.Value * gxWidth + 1, 0, nLength(xI1) * gxWidth - 1, PMainIn.Height)
    '        End If
    '        e1.Graphics.DrawString(nTitle(xI1), voTitleFont, voTitle, nLeft(xI1) * gxWidth - HS.Value * gxWidth, 0)
    '        e1.Graphics.DrawLine(voVLine, nLeft(xI1) * gxWidth - HS.Value * gxWidth, 0, nLeft(xI1) * gxWidth - HS.Value * gxWidth, PMainLabel.Height)
    '    Next
    '
    '    e1.Render(PMainLabel.CreateGraphics)
    '    e1.Dispose()
    '    'currentContext.Dispose()
    'End Sub

    'Private Sub PMainInClick(ByVal sender As Object, ByVal e As System.EventArgs)

    'End Sub

    Private Sub PMainInLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PMainIn.LostFocus, PMainInL.LostFocus, PMainInR.LostFocus
        RefreshPanelAll()
    End Sub

    Private Sub PMainInMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PMainIn.MouseDown, PMainInL.MouseDown, PMainInR.MouseDown
        tempFirstMouseDown = FirstClickDisabled And Not sender.Focused

        spFocus = sender.Tag
        sender.Focus()
        pMouseDown = New Point(-1, -1)
        VSValue = spV(spFocus)

        If NTInput Then bAdjustUpper = False : bAdjustLength = False
        Me.ctrlPressed = False : Me.ctrlForDuplicate = False

        If MiddleButtonClicked Then MiddleButtonClicked = False : Exit Sub

        Dim xHS As Long = spH(spFocus)
        Dim xVS As Long = spV(spFocus)
        Dim xHeight As Integer = spMain(spFocus).Height

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                If tempFirstMouseDown And Not TBTimeSelect.Checked Then RefreshPanelAll() : Exit Select

                KMouseOver = -1
                'If K Is Nothing Then pMouseDown = e.Location : Exit Select

                'Find the clicked K
                Dim xI1 As Integer
                Dim xITemp As Integer = -1
                For xI1 = UBound(K) To 0 Step -1
                    'If mouse is clicking on a K
                    If e.X >= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex), xHS) + 1 And _
                       e.X <= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex) + nLength(K(xI1).ColumnIndex), xHS) - 1 And _
                       e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0), xVS, xHeight) - vo.kHeight And _
                       e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) Then
                        'var xITemp is the index
                        xITemp = xI1
                        deltaVPosition = IIf(NTInput, (xHeight - e.Y - gxHeight * xVS - 1) / gxHeight - K(xI1).VPosition, 0)

                        If NTInput And My.Computer.Keyboard.ShiftKeyDown Then
                            bAdjustUpper = e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition + K(xI1).Length, xVS, xHeight)
                            bAdjustLength = e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) - vo.kHeight Or bAdjustUpper
                        End If

                        Exit For

                    End If
                Next

                'Play wav
                If ClickStopPreview Then PreviewNote("", True)
                'My.Computer.Audio.Stop()
                If xITemp > 0 And PreviewOnClick AndAlso Not nNumericLabel(K(xITemp).ColumnIndex) Then
                    Dim xI2 As Integer = K(xITemp).Value \ 10000
                    If xI2 <= 0 Then xI2 = 1
                    If xI2 >= 1296 Then xI2 = 1295

                    If Not hWAV(xI2) = "" Then ' AndAlso Path.GetExtension(hWAV(xI2)).ToLower = ".wav" Then
                        Dim xFileLocation As String = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName)) & "\" & hWAV(xI2)
                        If Not ClickStopPreview Then PreviewNote("", True)
                        PreviewNote(xFileLocation, False)
                    End If
                End If

                For xI1 = 0 To UBound(K)
                    K(xI1).TempMouseDown = False
                Next

                If TBSelect.Checked Then

                    If xITemp >= 0 And e.Clicks = 2 Then
                        If nNumericLabel(K(xITemp).ColumnIndex) Then
                            Dim xMessage As String = Locale.Messages.PromptEnterNumeric
                            If K(xITemp).ColumnIndex = niBPM Then xMessage = Locale.Messages.PromptEnterBPM
                            If K(xITemp).ColumnIndex = niSTOP Then xMessage = Locale.Messages.PromptEnterSTOP

                            Dim xD1 As Double = Val(InputBox(xMessage, Me.Text)) * 10000
                            If Not xD1 = 0 Then
                                If xD1 <= 0 Then xD1 = 1
                                If xD1 > 655359999 Then xD1 = 655359999

                                Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                                Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                                Me.RedoRelabelNote(K(xITemp), xD1, xITemp, xUndo, xRedo)
                                K(xITemp).Value = xD1
                                If xITemp = 0 Then THBPM.Value = xD1 / 10000
                                AddUndo(xUndo, xRedo)
                                'With K(xITemp)
                                '    Dim tempValue As Integer = .Value
                                '    Dim xRedo As String = sCmdKC(.ColumnIndex, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, 0, 0, xD1, IIf(NTInput, .Length, .LongNote), .Hidden, False)
                                '
                                '    .Value = xD1
                                '    If xITemp = 0 Then THBPM.Value = xD1 / 10000
                                '
                                '    Dim xUndo As String = sCmdKC(.ColumnIndex, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, 0, 0, tempValue, IIf(NTInput, .Length, .LongNote), .Hidden, False)
                                '    AddUndo(xUndo, xRedo)
                                'End With
                            End If

                        Else
                            Dim xStr As String = UCase(Trim(InputBox(Locale.Messages.PromptEnter, Me.Text)))

                            If Len(xStr) = 0 Then GoTo Jump2
                            If xStr = "00" Or xStr = "0" Then GoTo Jump1

                            If Not Len(xStr) = 1 And Not Len(xStr) = 2 Then GoTo Jump1

                            Dim xI3 As Integer = Asc(Mid(xStr, 1, 1))
                            If Not ((xI3 >= 48 And xI3 <= 57) Or (xI3 >= 65 And xI3 <= 90)) Then GoTo Jump1

                            If Len(xStr) = 2 Then
                                Dim xI4 As Integer = Asc(Mid(xStr, 2, 1))
                                If Not ((xI4 >= 48 And xI4 <= 57) Or (xI4 >= 65 And xI4 <= 90)) Then GoTo Jump1
                            End If

                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                            Me.RedoRelabelNote(K(xITemp), C36to10(xStr) * 10000, True, xUndo, xRedo)
                            K(xITemp).Value = C36to10(xStr) * 10000
                            AddUndo(xUndo, xRedo)
                            'With K(xITemp)
                            '    Dim tempValue As Integer = .Value
                            '    Dim xRedo As String = sCmdKC(.ColumnIndex, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, _
                            '                                      0, 0, C36to10(xStr) * 10000, IIf(NTInput, .Length, .LongNote), .Hidden, False)
                            '
                            '    .Value = C36to10(xStr) * 10000
                            '
                            '    Dim xUndo As String = sCmdKC(.ColumnIndex, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, _
                            '                                                  0, 0, tempValue, IIf(NTInput, .Length, .LongNote), .Hidden, False)
                            '    AddUndo(xUndo, xRedo)
                            'End With

                            GoTo Jump2

Jump1:
                            MsgBox(Locale.Messages.InvalidLabel, MsgBoxStyle.Critical, Locale.Messages.Err)
Jump2:
                        End If

                    ElseIf xITemp > 0 Then
                        'KMouseDown = -1
                        ReDim uNotes(-1)

                        'KMouseDown = xITemp
                        K(xITemp).TempMouseDown = True

                        If My.Computer.Keyboard.CtrlKeyDown Then
                            'If Not K(xITemp).Selected Then K(xITemp).Selected = True
                            ctrlPressed = True

                        Else
                            If Not K(xITemp).Selected Then
                                For xI1 = 0 To UBound(K)
                                    If K(xI1).Selected Then K(xI1).Selected = False
                                Next
                                K(xITemp).Selected = True
                            End If

                            Dim xI2 As Integer = 0
                            For xI1 = 0 To UBound(K)
                                If K(xI1).Selected Then xI2 += 1
                            Next
                            bAdjustSingle = xI2 = 1

                            ReDim uNotes(xI2)
                            uNotes(0) = K(xITemp)
                            K(xITemp).TempIndex = 0
                            xI2 = 1

                            For xI1 = 1 To xITemp - 1
                                If K(xI1).Selected Then K(xI1).TempIndex = xI2 : uNotes(xI2) = K(xI1) : xI2 += 1
                            Next
                            For xI1 = xITemp + 1 To UBound(K)
                                If K(xI1).Selected Then K(xI1).TempIndex = xI2 : uNotes(xI2) = K(xI1) : xI2 += 1
                            Next

                            'uCol = RealColumnToEnabled(K(xITemp).ColumnIndex)
                            'uVPos = K(xITemp).VPosition
                            'uNote = K(xITemp)
                            uAdded = False

                        End If

                    Else
                        ReDim uNotes(-1)
                        pMouseDown = e.Location
                        If Not My.Computer.Keyboard.CtrlKeyDown Then
                            For xI1 = 0 To UBound(K)
                                K(xI1).Selected = False
                                K(xI1).TempSelected = False
                            Next
                        Else
                            For xI1 = 0 To UBound(K)
                                K(xI1).TempSelected = K(xI1).Selected
                            Next
                        End If
                    End If

                ElseIf NTInput And TBWrite.Checked Then
                    TempVPosition = -1
                    TempColumn = -1
                    TempDraw = False

                    Dim xVPosition As Double = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight 'VPosition of the mouse
                    If gSnap Then xVPosition = SnapToGrid(xVPosition)
                    If xVPosition < 0 Or xVPosition >= VPosition1000() Then Exit Select

                    xI1 = 0
                    Dim xColumn As Integer = 0
                    Dim mLeft As Integer = e.X / gxWidth + xHS 'horizontal position of the mouse
                    If mLeft >= 0 Then
                        Do
                            If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then xColumn = xI1 : Exit Do 'get the column where mouse is 
                            xI1 += 1
                        Loop
                    End If
                    xColumn = EnabledColumnToReal(RealColumnToEnabled(xColumn))  'get the enabled column where mouse is 

                    For xI2 As Integer = UBound(K) To 1 Step -1
                        If K(xI2).VPosition = xVPosition And K(xI2).ColumnIndex = xColumn Then xITemp = xI2 : Exit For
                    Next

                    If xITemp > 0 Then
                        ReDim uNotes(0)
                        uNotes(0) = K(xITemp)
                        K(xITemp).TempIndex = 0

                        'KMouseDown = xITemp
                        K(xITemp).TempMouseDown = True
                        K(xITemp).Length = xVPosition - K(xITemp).VPosition

                        'uVPos = K(xITemp).VPosition
                        bAdjustUpper = True

                        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                        Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                        Me.RedoLongNoteModify(uNotes(0), K(xITemp).VPosition, K(xITemp).Length, True, xUndo, xRedo)
                        AddUndo(xUndo, xRedo)
                        'With uNote
                        '    AddUndo(sCmdKL(.ColumnIndex, .VPosition, .Value, K(xITemp).Length, .Hidden, .Length, True, True), _
                        '            sCmdKL(.ColumnIndex, .VPosition, .Value, .Length, .Hidden, K(xITemp).Length, True, True))
                        'End With

                    ElseIf nNumericLabel(xColumn) Then
                        Dim xMessage As String = Locale.Messages.PromptEnterNumeric
                        If xColumn = niBPM Then xMessage = Locale.Messages.PromptEnterBPM
                        If xColumn = niSTOP Then xMessage = Locale.Messages.PromptEnterSTOP

                        Dim xBoolean2 As Boolean = My.Computer.Keyboard.CtrlKeyDown
                        Dim xD1 As Double = Val(InputBox(xMessage, Me.Text)) * 10000

                        If Not xD1 = 0 Then
                            If xD1 <= 0 Then xD1 = 1
                            If xD1 > 655359999 Then xD1 = 655359999

                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                            Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                            For xI1 = 1 To UBound(K)
                                If K(xI1).VPosition = xVPosition AndAlso K(xI1).ColumnIndex = xColumn Then _
                                    Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                            Next
                            Me.RedoAddNote(xColumn, xVPosition, xD1, 0, xBoolean2, True, xUndo, xRedo)

                            AddNote(xVPosition, xColumn, xD1, 0, xBoolean2)
                            AddUndo(xUndo, xBaseRedo.Next)
                        End If

                        TempDraw = True

                    Else
                        Dim xLbl As Integer = (LWAV.SelectedIndex + 1) * 10000
                        Dim xBoolean2 As Boolean = My.Computer.Keyboard.CtrlKeyDown

                        ReDim Preserve K(UBound(K) + 1)
                        With K(UBound(K))
                            .VPosition = xVPosition
                            .ColumnIndex = xColumn
                            .Value = xLbl
                            .Hidden = xBoolean2
                            .TempMouseDown = True
                        End With

                        ReDim uNotes(0)
                        uNotes(0) = K(UBound(K))
                        uNotes(0).PairWithI = -1

                        'KMouseDown = 1

                        'uNote.Value = 0
                        'uVPos = xVPosition
                        uAdded = False

                        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                        Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                        Me.RedoAddNote(K(UBound(K)), True, xUndo, xRedo)
                        AddUndo(xUndo, xRedo)

                    End If

                    SortByVPositionInsertion()
                    UpdatePairing()
                    CalculateTotalNotes()

                ElseIf TBTimeSelect.Checked Then

                    Dim xL1 As Double
                    If xITemp >= 0 Then xL1 = K(xITemp).VPosition _
                                   Else xL1 = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight

                    vSelAdjust = My.Computer.Keyboard.ShiftKeyDown

                    vSelMouseOverLine = 0
                    If Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                        vSelMouseOverLine = 3
                    ElseIf Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                        vSelMouseOverLine = 2
                    ElseIf Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                        vSelMouseOverLine = 1
                    End If

                    If Not vSelAdjust Then
                        If vSelMouseOverLine = 1 Then
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then xL1 = SnapToGrid(xL1)
                            vSelLength += vSelStart - xL1
                            vSelHalf += vSelStart - xL1
                            vSelStart = xL1

                        ElseIf vSelMouseOverLine = 2 Then
                            vSelHalf = xL1
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelHalf = SnapToGrid(vSelHalf)
                            vSelHalf -= vSelStart

                        ElseIf vSelMouseOverLine = 3 Then
                            vSelLength = xL1
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelLength = SnapToGrid(vSelLength)
                            vSelLength -= vSelStart

                        Else
                            vSelLength = 0
                            vSelStart = xL1
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelStart = SnapToGrid(vSelStart)
                        End If
                        ValidateSelection()

                    Else
                        If vSelMouseOverLine = 2 Then
                            SortByVPositionInsertion()
                            vSelPStart = vSelStart
                            vSelPLength = vSelLength
                            vSelPHalf = vSelHalf
                            vSelK = K
                            ReDim Preserve vSelK(UBound(vSelK))

                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then xL1 = SnapToGrid(xL1)
                            AddUndo(New UndoRedo.Void, New UndoRedo.Void)
                            BPMChangeHalf(xL1 - vSelHalf - vSelStart, , True)
                            SortByVPositionInsertion()
                            UpdatePairing()
                            CalculateGreatestVPosition()

                        ElseIf vSelMouseOverLine = 3 Or vSelMouseOverLine = 1 Then
                            SortByVPositionInsertion()
                            vSelPStart = vSelStart
                            vSelPLength = vSelLength
                            vSelPHalf = vSelHalf
                            vSelK = K
                            ReDim Preserve vSelK(UBound(vSelK))

                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then xL1 = SnapToGrid(xL1)
                            AddUndo(New UndoRedo.Void, New UndoRedo.Void)
                            BPMChangeTop(IIf(vSelMouseOverLine = 3, xL1 - vSelStart, vSelStart + vSelLength - xL1) / vSelLength, , True)
                            SortByVPositionInsertion()
                            UpdatePairing()
                            CalculateGreatestVPosition()

                        Else
                            vSelLength = xL1
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelLength = SnapToGrid(vSelLength)
                            vSelLength -= vSelStart
                        End If

                    End If

                    If vSelLength Then
                        Dim xVLower As Double = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
                        Dim xVUpper As Double = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
                        If NTInput Then
                            For xI2 As Integer = 1 To UBound(K)
                                K(xI2).Selected = Not K(xI2).VPosition >= xVUpper And Not K(xI2).VPosition + K(xI2).Length < xVLower And nEnabled(K(xI2).ColumnIndex)
                            Next
                        Else
                            For xI2 As Integer = 1 To UBound(K)
                                K(xI2).Selected = K(xI2).VPosition >= xVLower And K(xI2).VPosition < xVUpper And nEnabled(K(xI2).ColumnIndex)
                            Next
                        End If
                    Else
                        For xI2 As Integer = 1 To UBound(K)
                            K(xI2).Selected = False
                        Next
                    End If

                End If

                RefreshPanelAll()
                POStatusRefresh()

            Case Windows.Forms.MouseButtons.Middle
                If MiddleButtonMoveMethod = 1 Then
                    tempX = e.X
                    tempY = e.Y
                    tempV = xVS
                    tempH = xHS
                Else
                    MiddleButtonLocation = Cursor.Position
                    MiddleButtonClicked = True
                    TimerMiddle.Enabled = True
                End If

            Case Windows.Forms.MouseButtons.Right
                KMouseOver = -1
                'KMouseDown = -1
                ReDim uNotes(-1)
                'If K Is Nothing Then pMouseDown = e.Location : Exit Select

                If tempFirstMouseDown Then GoTo Jump0

                Dim xI1 As Integer
                For xI1 = UBound(K) To 1 Step -1
                    'If mouse is clicking on a K
                    If e.X >= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex), xHS) + 1 And _
                       e.X <= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex) + nLength(K(xI1).ColumnIndex), xHS) - 1 And _
                       e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0), xVS, xHeight) - vo.kHeight And _
                       e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) Then
                        'var xITemp is the index
                        'Dim xRedo As String = sCmdKD(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden)
                        'Dim xUndo As String = sCmdK(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True)

                        If My.Computer.Keyboard.ShiftKeyDown Then
                            LWAV.SelectedIndices.Clear()
                            LWAV.SelectedIndex = C36to10(C10to36(K(xI1).Value \ 10000)) - 1
                            validate_LWAV_view()

                        Else
                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = Nothing

                            Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                            RemoveNote(xI1)

                            AddUndo(xUndo, xRedo)
                            RefreshPanelAll()
                        End If

                        Exit For
                    End If
                Next

                CalculateTotalNotes()

Jump0:          'If xI1 = 0 Then
                '    menuVPosition = -(gxHeight * xVS - xHeight + 1 + e.Y) / gxHeight
                '    Menu1.Show(sender, e.Location) ', ToolStripDropDownDirection.BelowRight)
                '    'mnSys.Show(sender, e.Location, ToolStripDropDownDirection.BelowLeft)
                'End If
        End Select
    End Sub

    Private Sub PMainInMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PMainIn.MouseEnter, PMainInL.MouseEnter, PMainInR.MouseEnter
        spMouseOver = sender.Tag
        Dim xPMainIn As Panel = sender
        If AutoFocusMouseEnter AndAlso Me.Focused Then xPMainIn.Focus() : spFocus = spMouseOver
        If FirstMouseEnter Then FirstMouseEnter = False : xPMainIn.Focus() : spFocus = spMouseOver
    End Sub

    Private Sub PMainInMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PMainIn.MouseLeave, PMainInL.MouseLeave, PMainInR.MouseLeave
        KMouseOver = -1
        'KMouseDown = -1
        ReDim uNotes(-1)
        TempVPosition = -1
        TempColumn = -1
        RefreshPanelAll()
    End Sub

    Private Sub PMainInMouseMove(ByVal sender As Panel)
        Dim p As Point = sender.PointToClient(Cursor.Position)
        Me.PMainInMouseMove(sender, New MouseEventArgs(Windows.Forms.MouseButtons.None, 0, p.X, p.Y, 0))
    End Sub

    Private Sub PMainInMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PMainIn.MouseMove, PMainInL.MouseMove, PMainInR.MouseMove
        MouseMoveStatus = e.Location

        Dim iI As Integer = sender.Tag

        Dim xHS As Long = spH(iI)
        Dim xVS As Long = spV(iI)
        Dim xHeight As Integer = spMain(iI).Height
        Dim xWidth As Integer = spMain(iI).Width

        Select Case e.Button
            Case Windows.Forms.MouseButtons.None
                'If K Is Nothing Then Exit Select
                If MiddleButtonClicked Then Exit Select

                If isFullScreen Then
                    If e.Y < 5 Then ToolStripContainer1.TopToolStripPanelVisible = True Else ToolStripContainer1.TopToolStripPanelVisible = False
                End If

                Dim xMouseRemainInSameRegion As Boolean = False

                Dim xI1 As Integer
                Dim xITemp As Integer = -1
                For xI1 = UBound(K) To 0 Step -1
                    If e.X >= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex), xHS) + 1 And _
                       e.X <= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex) + nLength(K(xI1).ColumnIndex), xHS) - 1 And _
                       e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0), xVS, xHeight) - vo.kHeight And _
                       e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) Then
                        xITemp = xI1

                        xMouseRemainInSameRegion = xITemp = KMouseOver
                        If NTInput Then
                            Dim xbAdjustUpper As Boolean = (e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition + K(xI1).Length, xVS, xHeight)) And My.Computer.Keyboard.ShiftKeyDown
                            Dim xbAdjustLength As Boolean = (e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) - vo.kHeight Or xbAdjustUpper) And My.Computer.Keyboard.ShiftKeyDown
                            xMouseRemainInSameRegion = xMouseRemainInSameRegion And xbAdjustUpper = bAdjustUpper And xbAdjustLength = bAdjustLength
                            bAdjustUpper = xbAdjustUpper
                            bAdjustLength = xbAdjustLength
                        End If

                        Exit For
                    End If
                Next

                Dim xTempbTimeSelectionMode As Boolean = TBTimeSelect.Checked

                If TBSelect.Checked Or xTempbTimeSelectionMode Then

                    If xMouseRemainInSameRegion Then Exit Select
                    If KMouseOver >= 0 Then KMouseOver = -1 : RefreshPanelAll()

                    If xTempbTimeSelectionMode Then

                        Dim xMouseOverLine As Integer = vSelMouseOverLine
                        vSelMouseOverLine = 0

                        If Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                            vSelMouseOverLine = 3
                        ElseIf Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                            vSelMouseOverLine = 2
                        ElseIf Math.Abs(e.Y - VerticalPositiontoDisplay(vSelStart, xVS, xHeight)) <= vo.PEDeltaMouseOver Then
                            vSelMouseOverLine = 1
                        End If

                        If xMouseOverLine <> vSelMouseOverLine Then RefreshPanelAll()
                    End If

                    If xITemp > -1 Then
                        Dim xDispX As Integer = HorizontalPositiontoDisplay(nLeft(K(xITemp).ColumnIndex), xHS)
                        Dim xDispY As Integer = IIf(Not NTInput Or (bAdjustLength And Not bAdjustUpper), _
                                                    VerticalPositiontoDisplay(K(xITemp).VPosition, xVS, xHeight) - vo.kHeight - 1, _
                                                    VerticalPositiontoDisplay(K(xITemp).VPosition + K(xITemp).Length, xVS, xHeight) - vo.kHeight - 1)
                        Dim xDispW As Integer = nLength(K(xITemp).ColumnIndex) * gxWidth + 1
                        Dim xDispH As Integer = IIf(Not NTInput Or bAdjustLength, _
                                                    vo.kHeight + 3, _
                                                    K(xITemp).Length * gxHeight + vo.kHeight + 3)

                        Dim e1 As BufferedGraphics = BufferedGraphicsManager.Current.Allocate(spMain(iI).CreateGraphics, New Rectangle(xDispX, xDispY, xDispW, xDispH))
                        e1.Graphics.FillRectangle(vo.Bg, New Rectangle(xDispX, xDispY, xDispW, xDispH))

                        If NTInput Then DrawNoteNT(K(xITemp), e1, xHS, xVS, xHeight) Else DrawNote(K(xITemp), e1, xHS, xVS, xHeight)

                        e1.Graphics.DrawRectangle(IIf(bAdjustLength, vo.kMouseOverE, vo.kMouseOver), xDispX, xDispY, xDispW - 1, xDispH - 1)

                        e1.Render(spMain(iI).CreateGraphics)
                        e1.Dispose()
                    End If

                    KMouseOver = xITemp

                ElseIf TBWrite.Checked Then
                    TempVPosition = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight 'VPosition of the mouse
                    If gSnap Then TempVPosition = SnapToGrid(TempVPosition)

                    xI1 = 0
                    Dim mLeft As Integer = e.X / gxWidth + xHS 'horizontal position of the mouse
                    If mLeft >= 0 Then
                        Do
                            If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then TempColumn = xI1 : Exit Do 'get the column where mouse is 
                            xI1 += 1
                        Loop
                    End If
                    TempColumn = EnabledColumnToReal(RealColumnToEnabled(TempColumn))  'get the enabled column where mouse is 

                    TempLength = 0
                    If xITemp > -1 Then TempLength = K(xITemp).Length

                    RefreshPanelAll()
                End If

            Case Windows.Forms.MouseButtons.Left
                If tempFirstMouseDown And Not TBTimeSelect.Checked Then Exit Select

                tempX = 0
                tempY = 0
                If e.X < 0 Or e.X > xWidth Or e.Y < 0 Or e.Y > xHeight Then
                    If e.X < 0 Then tempX = e.X
                    If e.X > xWidth Then tempX = e.X - xWidth
                    If e.Y < 0 Then tempY = e.Y
                    If e.Y > xHeight Then tempY = e.Y - xHeight
                    Timer1.Enabled = True
                Else
                    Timer1.Enabled = False
                End If

                If TBSelect.Checked Then

                    pMouseMove = e.Location

                    'If K Is Nothing Then RefreshPanelAll() : Exit Select

                    If Not pMouseDown = New Point(-1, -1) Then
                        Dim rSBox As New Rectangle(IIf(pMouseMove.X > pMouseDown.X, pMouseDown.X, pMouseMove.X), _
                                                   IIf(pMouseMove.Y > pMouseDown.Y, pMouseDown.Y, pMouseMove.Y), _
                                                   Math.Abs(pMouseMove.X - pMouseDown.X), _
                                                   Math.Abs(pMouseMove.Y - pMouseDown.Y))
                        Dim rNote As Rectangle

                        Dim xI1 As Integer
                        For xI1 = 1 To UBound(K)
                            rNote = New Rectangle(HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex), xHS) + 1, _
                                                  VerticalPositiontoDisplay(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0), xVS, xHeight) - vo.kHeight, _
                                                  nLength(K(xI1).ColumnIndex) * gxWidth - 2, _
                                                  vo.kHeight + IIf(NTInput, K(xI1).Length * gxHeight, 0))
                            If Math.Abs((rSBox.X + rSBox.Width / 2) - (rNote.X + rNote.Width / 2)) <= Math.Abs((rSBox.Width + rNote.Width) / 2) And _
                               Math.Abs((rSBox.Y + rSBox.Height / 2) - (rNote.Y + rNote.Height / 2)) <= Math.Abs((rSBox.Height + rNote.Height) / 2) Then
                                K(xI1).Selected = Not K(xI1).TempSelected And nEnabled(K(xI1).ColumnIndex)
                            Else
                                K(xI1).Selected = K(xI1).TempSelected And nEnabled(K(xI1).ColumnIndex)
                            End If
                        Next

                        'ElseIf Not KMouseDown = -1 Then
                    ElseIf uNotes.Length <> 0 Then
                        Dim dColumn As Integer = 0
                        Dim dVPosition As Double
                        Dim mouseColumn As Integer 'Enabled
                        Dim mouseVPosition As Double
                        Dim xI1 As Integer

                        Dim xITemp As Integer
                        For xI1 = 1 To UBound(K)
                            If K(xI1).TempMouseDown Then xITemp = xI1 : Exit For
                        Next

                        mouseVPosition = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight - IIf(Not bAdjustLength, deltaVPosition, 0)  'VPosition of the mouse
                        If gSnap Then mouseVPosition = SnapToGrid(mouseVPosition)

                        If bAdjustLength And bAdjustSingle Then
                            If bAdjustUpper AndAlso mouseVPosition < K(xITemp).VPosition Then
                                bAdjustUpper = False
                                K(xITemp).VPosition += K(xITemp).Length
                                K(xITemp).Length *= -1
                            ElseIf Not bAdjustUpper AndAlso mouseVPosition > K(xITemp).VPosition + K(xITemp).Length Then
                                bAdjustUpper = True
                                K(xITemp).VPosition += K(xITemp).Length
                                K(xITemp).Length *= -1
                            End If
                        End If

                        'If moving
                        If Not bAdjustLength Then
                            If DisableVerticalMove Then mouseVPosition = uNotes(0).VPosition
                            dVPosition = mouseVPosition - K(xITemp).VPosition  'delta VPosition

                            xI1 = 0
                            Dim mLeft As Integer = e.X / gxWidth + xHS 'horizontal position of the mouse
                            If mLeft >= 0 Then
                                Do
                                    If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then mouseColumn = RealColumnToEnabled(xI1) : Exit Do 'get the column where mouse is 
                                    xI1 += 1
                                Loop
                            End If
                            dColumn = mouseColumn - RealColumnToEnabled(K(xITemp).ColumnIndex) 'get the enabled delta column where mouse is 

                            'Ks cannot be beyond the left, the upper and the lower boundary
                            mLeft = 0
                            Dim mVPosition As Double = 0
                            Dim muVPosition As Double = 191999
                            For xI1 = 1 To UBound(K)
                                If K(xI1).Selected Then
                                    mLeft = IIf(RealColumnToEnabled(K(xI1).ColumnIndex) + dColumn < mLeft, _
                                                RealColumnToEnabled(K(xI1).ColumnIndex) + dColumn, _
                                                mLeft)
                                    mVPosition = IIf(K(xI1).VPosition + dVPosition < mVPosition, _
                                                     K(xI1).VPosition + dVPosition, _
                                                     mVPosition)
                                    muVPosition = IIf(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + dVPosition > muVPosition, _
                                                      K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + dVPosition, _
                                                      muVPosition)
                                End If
                            Next
                            muVPosition -= 191999

                            Dim xCol As Integer
                            Dim xVPos As Double

                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                            Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                            'start moving
                            For xI1 = 1 To UBound(K)
                                If Not K(xI1).Selected Then Continue For

                                xCol = EnabledColumnToReal(RealColumnToEnabled(K(xI1).ColumnIndex) + dColumn - mLeft)
                                xVPos = K(xI1).VPosition + dVPosition - mVPosition - muVPosition
                                Me.RedoMoveNote(uNotes(K(xI1).TempIndex), xCol, xVPos, True, xUndo, xRedo)

                                K(xI1).ColumnIndex = xCol
                                K(xI1).VPosition = xVPos
                            Next

                            'If mouseColumn - uNotes(0).ColumnIndex - mLeft <> 0 Or mouseVPosition - uNotes(0).VPosition - mVPosition - muVPosition <> 0 Then
                            AddUndo(xUndo, xBaseRedo.Next, uAdded)
                            If Not uAdded Then uAdded = True

                            'End If

                        ElseIf bAdjustUpper Then    'If adjusting upper end
                            dVPosition = mouseVPosition - K(xITemp).VPosition - K(xITemp).Length  'delta Length
                            '< 0 means shorten, > 0 means lengthen

                            Dim minLength As Double = 0
                            Dim maxHeight As Double = 191999
                            For xI1 = 1 To UBound(K)
                                If Not K(xI1).Selected Then Continue For
                                If K(xI1).Length + dVPosition < minLength Then minLength = K(xI1).Length + dVPosition
                                If K(xI1).Length + K(xI1).VPosition + dVPosition > maxHeight Then maxHeight = K(xI1).Length + K(xI1).VPosition + dVPosition
                            Next
                            maxHeight -= 191999

                            'declare undo variables
                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                            Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                            'start moving
                            Dim xLen As Double
                            For xI1 = 1 To UBound(K)
                                If Not K(xI1).Selected Then Continue For

                                xLen = K(xI1).Length + dVPosition - minLength - maxHeight
                                Me.RedoLongNoteModify(uNotes(K(xI1).TempIndex), K(xI1).VPosition, xLen, True, xUndo, xRedo)

                                K(xI1).Length = xLen
                            Next

                            'Add undo
                            If dVPosition - minLength - maxHeight <> 0 Then
                                'Dim xUndo As String
                                'Dim xRedo As String
                                '
                                'If bAdjustSingle Then
                                '    With K(KMouseDown)
                                '        xUndo = sCmdKC(.ColumnIndex, .VPosition, .Value, .Length, .Hidden, 0, uNote.VPosition - .VPosition, .Value, uNote.Length, .Hidden, True)
                                '        xRedo = sCmdKC(.ColumnIndex, uNote.VPosition, .Value, uNote.Length, .Hidden, 0, .VPosition - uNote.VPosition, .Value, .Length, .Hidden, True)
                                '    End With
                                'Else
                                '    xUndo = sCmdKLsNT(uNote.Length - K(KMouseDown).Length, True, True)
                                '    xRedo = sCmdKLsNTR(uNote.Length - K(KMouseDown).Length, True, True)
                                'End If

                                AddUndo(xUndo, xBaseRedo.Next, uAdded)
                                If Not uAdded Then uAdded = True
                            End If

                        Else    'If adjusting lower end
                            dVPosition = mouseVPosition - K(xITemp).VPosition  'delta VPosition
                            '> 0 means shorten, < 0 means lengthen

                            Dim minLength As Double = 0
                            Dim minVPosition As Double = 0
                            For xI1 = 1 To UBound(K)
                                If K(xI1).Selected AndAlso K(xI1).Length - dVPosition < minLength Then minLength = K(xI1).Length - dVPosition
                                If K(xI1).Selected AndAlso K(xI1).VPosition + dVPosition < minVPosition Then minVPosition = K(xI1).VPosition + dVPosition
                            Next

                            'declare undo variables
                            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                            Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                            Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                            'start moving
                            Dim xVPos As Double
                            Dim xLen As Double
                            For xI1 = 0 To UBound(K)
                                If Not K(xI1).Selected Then Continue For

                                xVPos = K(xI1).VPosition + dVPosition + minLength - minVPosition
                                xLen = K(xI1).Length - dVPosition - minLength + minVPosition
                                Me.RedoLongNoteModify(uNotes(K(xI1).TempIndex), xVPos, xLen, True, xUndo, xRedo)

                                K(xI1).VPosition = xVPos
                                K(xI1).Length = xLen
                            Next

                            'Add undo
                            If dVPosition + minLength - minVPosition <> 0 Then
                                'Dim xUndo As String
                                'Dim xRedo As String
                                '
                                'If bAdjustSingle Then
                                '    With K(KMouseDown)
                                '        xUndo = sCmdKC(.ColumnIndex, .VPosition, .Value, .Length, .Hidden, 0, uNote.VPosition - .VPosition, .Value, uNote.Length, .Hidden, True)
                                '        xRedo = sCmdKC(.ColumnIndex, uNote.VPosition, .Value, uNote.Length, .Hidden, 0, .VPosition - uNote.VPosition, .Value, .Length, .Hidden, True)
                                '    End With
                                'Else
                                '    xUndo = sCmdKLsNT(uNote.Length - K(KMouseDown).Length, False, True)
                                '    xRedo = sCmdKLsNTR(uNote.Length - K(KMouseDown).Length, False, True)
                                'End If

                                AddUndo(xUndo, xBaseRedo.Next, uAdded)
                                If Not uAdded Then uAdded = True
                            End If

                        End If

                        SortByVPositionInsertion()
                        UpdatePairing()
                        CalculateTotalNotes()
                        'Label1.Text = KInfo(KMouseDown)

                    ElseIf ctrlPressed Then
                        Dim xITemp As Integer
                        For xITemp = 1 To UBound(K)
                            If K(xITemp).TempMouseDown Then Exit For
                        Next

                        Dim mouseVPosition As Double = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight - deltaVPosition
                        If gSnap Then mouseVPosition = SnapToGrid(mouseVPosition)
                        If DisableVerticalMove Then mouseVPosition = K(xITemp).VPosition

                        Dim dVPosition As Double = mouseVPosition - K(xITemp).VPosition  'delta VPosition

                        Dim mouseColumn As Integer = 0
                        Dim xI1 As Integer = 0
                        Dim mLeft As Integer = e.X / gxWidth + xHS 'horizontal position of the mouse
                        Do
                            If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then mouseColumn = RealColumnToEnabled(xI1) : Exit Do 'get the column where mouse is 
                            xI1 += 1
                        Loop
                        Dim dColumn As Integer = mouseColumn - RealColumnToEnabled(K(xITemp).ColumnIndex) 'delta Column

                        'Ks cannot be beyond the left, the upper and the lower boundary
                        mLeft = 0
                        Dim mVPosition As Double = 0
                        Dim muVPosition As Double = 191999
                        For xI1 = 1 To UBound(K)
                            If Not K(xI1).Selected Then Continue For

                            If RealColumnToEnabled(K(xI1).ColumnIndex) + dColumn < mLeft Then _
                                mLeft = RealColumnToEnabled(K(xI1).ColumnIndex) + dColumn
                            If K(xI1).VPosition + dVPosition < mVPosition Then _
                                mVPosition = K(xI1).VPosition + dVPosition
                            If K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + dVPosition > muVPosition Then _
                                muVPosition = K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + dVPosition
                        Next
                        muVPosition -= 191999

                        'If not moving then exit
                        If (Not ctrlForDuplicate) And dColumn - mLeft = 0 And dVPosition - mVPosition - muVPosition = 0 Then _
                            GoTo EndCtrlOpn

                        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                        If Not ctrlForDuplicate Then     'If uAdded = False
                            K(xITemp).Selected = True

                            Dim xSelectedNotesCount As Integer = 0
                            For i As Integer = 1 To UBound(K)
                                If K(i).Selected Then xSelectedNotesCount += 1
                            Next

                            Dim xTempNotes(xSelectedNotesCount - 1) As Note
                            Dim xI2 As Integer = 0
                            For i As Integer = 1 To UBound(K)
                                If Not K(i).Selected Then Continue For

                                xTempNotes(xI2) = K(i)
                                xTempNotes(xI2).ColumnIndex = EnabledColumnToReal(RealColumnToEnabled(K(i).ColumnIndex) + dColumn - mLeft)
                                xTempNotes(xI2).VPosition = K(i).VPosition + dVPosition - mVPosition - muVPosition
                                Me.RedoAddNote(xTempNotes(xI2), True, xUndo, xRedo)

                                K(i).Selected = False
                                xI2 += 1
                            Next
                            K(xITemp).TempMouseDown = False

                            'copy to K
                            Dim xOrigUBound As Integer = UBound(K)
                            ReDim Preserve K(xOrigUBound + xSelectedNotesCount)
                            xI2 = 0
                            For i As Integer = xOrigUBound + 1 To UBound(K)
                                K(i) = xTempNotes(xI2)
                                xI2 += 1
                            Next

                            AddUndo(xUndo, xBaseRedo.Next)
                            ctrlForDuplicate = True

                        Else
                            For i As Integer = 1 To UBound(K)
                                If Not K(i).Selected Then Continue For

                                K(i).ColumnIndex = EnabledColumnToReal(RealColumnToEnabled(K(i).ColumnIndex) + dColumn - mLeft)
                                K(i).VPosition = K(i).VPosition + dVPosition - mVPosition - muVPosition
                                Me.RedoAddNote(K(i), True, xUndo, xRedo)
                            Next

                            AddUndo(xUndo, xBaseRedo.Next, True)
                        End If

                        SortByVPositionInsertion()
                        UpdatePairing()
                        CalculateTotalNotes()
EndCtrlOpn:         End If

                ElseIf TBWrite.Checked Then

                    If NTInput Then
                        'If Not KMouseDown = -1 Then
                        If uNotes.Length <> 0 Then

                            Dim xI1 As Integer
                            Dim xITemp As Integer
                            For xI1 = 1 To UBound(K)
                                If K(xI1).TempMouseDown Then xITemp = xI1 : Exit For
                            Next

                            Dim mouseVPosition As Double = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight  'VPosition of the mouse
                            If gSnap Then mouseVPosition = SnapToGrid(mouseVPosition)

                            With K(xITemp)
                                If bAdjustUpper AndAlso mouseVPosition < .VPosition Then
                                    bAdjustUpper = False
                                    .VPosition += .Length
                                    .Length *= -1
                                ElseIf Not bAdjustUpper AndAlso mouseVPosition > .VPosition + .Length Then
                                    bAdjustUpper = True
                                    .VPosition += .Length
                                    .Length *= -1
                                End If

                                If bAdjustUpper Then
                                    .Length = mouseVPosition - .VPosition
                                Else
                                    .Length = .VPosition + .Length - mouseVPosition
                                    .VPosition = mouseVPosition
                                End If

                                If .VPosition < 0 Then .Length += .VPosition : .VPosition = 0
                                If .VPosition + .Length >= VPosition1000() Then .Length = VPosition1000() - 1 - .VPosition

                                If uNotes(0).PairWithI = -1 Then 'If new note
                                    Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                                    Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                                    Me.RedoAddNote(K(xITemp), True, xUndo, xRedo)
                                    AddUndo(xUndo, xRedo, True)

                                Else 'If existing note
                                    Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                                    Dim xRedo As UndoRedo.LinkedURCmd = Nothing
                                    Me.RedoLongNoteModify(uNotes(0), .VPosition, .Length, True, xUndo, xRedo)
                                    AddUndo(xUndo, xRedo, True)
                                    'AddUndo(sCmdKC(.ColumnIndex, .VPosition, .Value, .Length, .Hidden, 0, uNote.VPosition - .VPosition, .Value, uNote.Length, .Hidden, True), _
                                    '        sCmdKC(.ColumnIndex, uNote.VPosition, .Value, uNote.Length, .Hidden, 0, .VPosition - uNote.VPosition, .Value, .Length, .Hidden, True), _
                                    '        True)
                                End If

                                TempColumn = .ColumnIndex
                                TempVPosition = mouseVPosition
                                TempLength = .Length

                            End With

                            SortByVPositionInsertion()
                            UpdatePairing()
                            CalculateTotalNotes()

                        End If

                    Else
                        TempVPosition = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight 'VPosition of the mouse
                        If gSnap Then TempVPosition = SnapToGrid(TempVPosition)

                        Dim xI1 As Integer = 0
                        Dim mLeft As Integer = e.X / gxWidth + xHS 'horizontal position of the mouse
                        If mLeft >= 0 Then
                            Do
                                If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then TempColumn = xI1 : Exit Do 'get the column where mouse is 
                                xI1 += 1
                            Loop
                        End If
                        TempColumn = EnabledColumnToReal(RealColumnToEnabled(TempColumn))  'get the enabled column where mouse is 

                    End If

                ElseIf TBTimeSelect.Checked Then
                    Dim xI1 As Integer
                    Dim xITemp As Integer = -1
                    If K IsNot Nothing Then
                        For xI1 = UBound(K) To 0 Step -1
                            If e.X >= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex), xHS) + 1 And _
                               e.X <= HorizontalPositiontoDisplay(nLeft(K(xI1).ColumnIndex) + nLength(K(xI1).ColumnIndex), xHS) - 1 And _
                               e.Y >= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) - vo.kHeight And _
                               e.Y <= VerticalPositiontoDisplay(K(xI1).VPosition, xVS, xHeight) Then
                                xITemp = xI1
                                Exit For
                            End If
                        Next
                    End If

                    If Not vSelAdjust Then
                        If vSelMouseOverLine = 1 Then
                            Dim xV As Double = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight
                            If xITemp >= 0 Then xV = K(xITemp).VPosition
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then xV = SnapToGrid(xV)
                            vSelLength += vSelStart - xV
                            vSelHalf += vSelStart - xV
                            vSelStart = xV

                        ElseIf vSelMouseOverLine = 2 Then
                            vSelHalf = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight
                            If xITemp >= 0 Then vSelHalf = K(xITemp).VPosition
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelHalf = SnapToGrid(vSelHalf)
                            vSelHalf -= vSelStart

                        ElseIf vSelMouseOverLine = 3 Then
                            vSelLength = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight
                            If xITemp >= 0 Then vSelLength = K(xITemp).VPosition
                            If gSnap And xITemp <= 0 And Not My.Computer.Keyboard.CtrlKeyDown Then vSelLength = SnapToGrid(vSelLength)
                            vSelLength -= vSelStart

                        Else
                            If xITemp >= 0 Then
                                vSelLength = K(xITemp).VPosition
                            Else
                                vSelLength = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight
                                If gSnap And Not My.Computer.Keyboard.CtrlKeyDown Then vSelLength = SnapToGrid(vSelLength)
                            End If
                            vSelLength -= vSelStart
                            vSelHalf = vSelLength / 2
                        End If
                        ValidateSelection()

                    Else
                        Dim xL1 As Double = (xHeight - xVS * gxHeight - e.Y - 1) / gxHeight

                        If vSelMouseOverLine = 2 Then
                            vSelStart = vSelPStart
                            vSelLength = vSelPLength
                            vSelHalf = vSelPHalf
                            K = vSelK
                            ReDim Preserve K(UBound(K))

                            If gSnap And Not My.Computer.Keyboard.CtrlKeyDown Then xL1 = SnapToGrid(xL1)
                            BPMChangeHalf(xL1 - vSelHalf - vSelStart, , True)
                            SortByVPositionInsertion()
                            UpdatePairing()
                            CalculateGreatestVPosition()

                        ElseIf vSelMouseOverLine = 3 Or vSelMouseOverLine = 1 Then
                            vSelStart = vSelPStart
                            vSelLength = vSelPLength
                            vSelHalf = vSelPHalf
                            K = vSelK
                            ReDim Preserve K(UBound(K))

                            If gSnap And Not My.Computer.Keyboard.CtrlKeyDown Then xL1 = SnapToGrid(xL1)
                            BPMChangeTop(IIf(vSelMouseOverLine = 3, xL1 - vSelStart, vSelStart + vSelLength - xL1) / vSelLength, , True)
                            SortByVPositionInsertion()
                            UpdatePairing()
                            CalculateGreatestVPosition()

                        Else
                            vSelLength = xL1
                            If gSnap And Not My.Computer.Keyboard.CtrlKeyDown Then vSelLength = SnapToGrid(vSelLength)
                            If xITemp >= 0 Then vSelLength = K(xITemp).VPosition
                            vSelLength -= vSelStart
                            ValidateSelection()
                        End If
                    End If

                    If vSelLength Then
                        Dim xVLower As Double = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
                        Dim xVUpper As Double = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
                        If NTInput Then
                            For xI2 As Integer = 1 To UBound(K)
                                K(xI2).Selected = K(xI2).VPosition < xVUpper And K(xI2).VPosition + K(xI2).Length >= xVLower And nEnabled(K(xI2).ColumnIndex)
                            Next
                        Else
                            For xI2 As Integer = 1 To UBound(K)
                                K(xI2).Selected = K(xI2).VPosition >= xVLower And K(xI2).VPosition < xVUpper And nEnabled(K(xI2).ColumnIndex)
                            Next
                        End If
                    Else
                        For xI2 As Integer = 1 To UBound(K)
                            K(xI2).Selected = False
                        Next
                    End If

                End If
                RefreshPanelAll()

            Case Windows.Forms.MouseButtons.Middle

                If MiddleButtonMoveMethod = 1 Then
                    Dim xI1 As Integer = tempV + (tempY - e.Y) / gxHeight
                    Dim xI2 As Integer = tempH + (tempX - e.X) / gxWidth
                    If xI1 > 0 Then xI1 = 0
                    If xI2 < 0 Then xI2 = 0

                    Select Case spFocus
                        Case 0
                            If xI1 < VSL.Minimum Then xI1 = VSL.Minimum
                            VSL.Value = xI1

                            If xI2 > HSL.Maximum - HSL.LargeChange + 1 Then xI2 = HSL.Maximum - HSL.LargeChange + 1
                            HSL.Value = xI2

                        Case 1
                            If xI1 < VS.Minimum Then xI1 = VS.Minimum
                            VS.Value = xI1

                            If xI2 > HS.Maximum - HS.LargeChange + 1 Then xI2 = HS.Maximum - HS.LargeChange + 1
                            HS.Value = xI2

                        Case 2
                            If xI1 < VSR.Minimum Then xI1 = VSR.Minimum
                            VSR.Value = xI1

                            If xI2 > HSR.Maximum - HSR.LargeChange + 1 Then xI2 = HSR.Maximum - HSR.LargeChange + 1
                            HSR.Value = xI2

                    End Select
                End If
        End Select
        POStatusRefresh()
    End Sub

    Private Sub PMainInMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PMainIn.MouseUp, PMainInL.MouseUp, PMainInR.MouseUp
        tempX = 0
        tempY = 0
        tempV = 0
        tempH = 0
        VSValue = -1
        HSValue = -1
        Timer1.Enabled = False
        'KMouseDown = -1
        ReDim uNotes(-1)

        Dim iI As Integer = sender.Tag

        If MiddleButtonClicked AndAlso e.Button = Windows.Forms.MouseButtons.Middle AndAlso _
            (MiddleButtonLocation.X - Cursor.Position.X) ^ 2 + (MiddleButtonLocation.Y - Cursor.Position.Y) ^ 2 >= vo.MiddleDeltaRelease Then
            MiddleButtonClicked = False
        End If

        If TBSelect.Checked Then
            pMouseDown = New Point(-1, -1)
            pMouseMove = New Point(-1, -1)

            If ctrlPressed And Not ctrlForDuplicate Then
                For i As Integer = 1 To UBound(K)
                    If K(i).TempMouseDown Then K(i).Selected = Not K(i).Selected : Exit For
                Next
            End If

            ctrlPressed = False
            ctrlForDuplicate = False

        ElseIf TBWrite.Checked Then

            If NTInput Then GoTo Jump0
            If tempFirstMouseDown Then GoTo Jump0

            Dim xI1 As Integer
            Dim xVPosition As Double
            Dim xColumn As Integer

            xVPosition = (sender.Height - spV(iI) * gxHeight - e.Y - 1) / gxHeight 'VPosition of the mouse
            If gSnap Then xVPosition = SnapToGrid(xVPosition)

            xI1 = 0
            Dim mLeft As Integer = e.X / gxWidth + spH(iI) 'horizontal position of the mouse
            If mLeft >= 0 Then
                Do
                    If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then xColumn = xI1 : Exit Do 'get the column where mouse is 
                    xI1 += 1
                Loop
            End If
            xColumn = EnabledColumnToReal(RealColumnToEnabled(xColumn))  'get the enabled column where mouse is 

            If e.Button = Windows.Forms.MouseButtons.Left Then
                If nNumericLabel(xColumn) Then
                    Dim xMessage As String = Locale.Messages.PromptEnterNumeric
                    If xColumn = niBPM Then xMessage = Locale.Messages.PromptEnterBPM
                    If xColumn = niSTOP Then xMessage = Locale.Messages.PromptEnterSTOP

                    Dim xBoolean As Boolean = My.Computer.Keyboard.ShiftKeyDown
                    Dim xBoolean2 As Boolean = My.Computer.Keyboard.CtrlKeyDown
                    Dim xD1 As Double = Val(InputBox(xMessage, Me.Text)) * 10000

                    If xD1 = 0 Then GoTo Jump0

                    If xD1 <= 0 Then xD1 = 1
                    If xD1 > 655359999 Then xD1 = 655359999

                    Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                    Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                    Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                    For xI1 = 1 To UBound(K)
                        If K(xI1).VPosition = xVPosition AndAlso K(xI1).ColumnIndex = xColumn Then _
                            Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    Next

                    Me.RedoAddNote(xColumn, xVPosition, xD1, xBoolean, xBoolean2, True, xUndo, xRedo)
                    AddNote(xVPosition, xColumn, xD1, xBoolean, xBoolean2)

                    AddUndo(xUndo, xBaseRedo.Next)

                Else
                    Dim xBoolean As Boolean = My.Computer.Keyboard.ShiftKeyDown
                    Dim xBoolean2 As Boolean = My.Computer.Keyboard.CtrlKeyDown
                    Dim xUI1 As Integer = (LWAV.SelectedIndex + 1) * 10000

                    Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                    Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                    Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                    For xI1 = 1 To UBound(K)
                        If K(xI1).VPosition = xVPosition AndAlso K(xI1).ColumnIndex = xColumn Then _
                            Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    Next

                    Me.RedoAddNote(xColumn, xVPosition, xUI1, xBoolean, xBoolean2, True, xUndo, xRedo)
                    AddNote(xVPosition, xColumn, xUI1, xBoolean, xBoolean2)

                    AddUndo(xUndo, xRedo)

                End If

            End If

Jump0:      If Not TempDraw Then TempDraw = True
            TempVPosition = -1
            TempColumn = -1
        End If
        CalculateGreatestVPosition()
        RefreshPanelAll()
    End Sub

    Private Sub PMainInMouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PMainIn.MouseWheel, PMainInL.MouseWheel, PMainInR.MouseWheel
        If MiddleButtonClicked Then MiddleButtonClicked = False

        Dim xI1 As Integer

        Select Case spMouseOver
            Case 0
                'xI1 = spV(iI) - Math.Sign(e.Delta) * VSL.SmallChange * 5 / gxHeight
                xI1 = spV(spMouseOver) - Math.Sign(e.Delta) * gWheel
                If xI1 > 0 Then xI1 = 0
                If xI1 < VSL.Minimum Then xI1 = VSL.Minimum
                VSL.Value = xI1
            Case 1
                'xI1 = spV(iI) - Math.Sign(e.Delta) * VS.SmallChange * 5 / gxHeight
                xI1 = spV(spMouseOver) - Math.Sign(e.Delta) * gWheel
                If xI1 > 0 Then xI1 = 0
                If xI1 < VS.Minimum Then xI1 = VS.Minimum
                VS.Value = xI1
            Case 2
                'xI1 = spV(iI) - Math.Sign(e.Delta) * VSR.SmallChange * 5 / gxHeight
                xI1 = spV(spMouseOver) - Math.Sign(e.Delta) * gWheel
                If xI1 > 0 Then xI1 = 0
                If xI1 < VSR.Minimum Then xI1 = VSR.Minimum
                VSR.Value = xI1
        End Select
    End Sub

    Private Sub PMainInPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PMainIn.Paint, PMainInL.Paint, PMainInR.Paint
        RefreshPanel(sender.Tag, e.ClipRectangle)
    End Sub

    ''' <summary>
    ''' Draw a note in a buffer.
    ''' </summary>
    ''' <param name="sNote">Note to be drawn.</param>
    ''' <param name="e">Buffer.</param>
    ''' <param name="xHS">HS.Value.</param>
    ''' <param name="xVS">VS.Value.</param>
    ''' <param name="xHeight">Display height of the panel. (not ClipRectangle.Height)</param>

    Private Sub DrawNote(ByVal sNote As Note, ByVal e As BufferedGraphics, ByVal xHS As Long, ByVal xVS As Long, ByVal xHeight As Integer) ', Optional ByVal CheckError As Boolean = True) ', Optional ByVal ConnectToIndex As Long = 0)
        If Not nEnabled(sNote.ColumnIndex) Then Exit Sub
        Dim xAlpha As Single = 1.0F
        If sNote.Hidden Then xAlpha = vo.kOpacity

        Dim xLabel As String = C10to36(sNote.Value \ 10000)
        If ShowFileName AndAlso hWAV(C36to10(xLabel)) <> "" Then xLabel = Path.GetFileNameWithoutExtension(hWAV(C36to10(xLabel)))

        If Not sNote.LongNote Then

            Dim xPen1 As New Pen(nCol(sNote.ColumnIndex).getBright(xAlpha))
            Dim xBrush As New Drawing2D.LinearGradientBrush(New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10), _
                           New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) + 10), _
                           nCol(sNote.ColumnIndex).getBright(xAlpha), _
                           nCol(sNote.ColumnIndex).getDark(xAlpha))
            Dim xBrush2 As New SolidBrush(nCol(sNote.ColumnIndex).cText)

            e.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + 1, nLength(sNote.ColumnIndex) * gxWidth - 3, vo.kHeight - 1)
            e.Graphics.DrawRectangle(xPen1, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight, nLength(sNote.ColumnIndex) * gxWidth - 2, vo.kHeight)

            e.Graphics.DrawString(IIf(nNumericLabel(sNote.ColumnIndex), sNote.Value / 10000, xLabel), _
                        vo.kFont, xBrush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShift, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift)

        Else

            Dim xPen2 As New Pen(nCol(sNote.ColumnIndex).getLongBright(xAlpha))
            Dim xBrush As New Drawing2D.LinearGradientBrush(New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10), _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) + 10), _
                            nCol(sNote.ColumnIndex).getLongBright(xAlpha), _
                            nCol(sNote.ColumnIndex).getLongDark(xAlpha))
            Dim xBrush2 As New SolidBrush(nCol(sNote.ColumnIndex).cLText)

            e.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + 1, nLength(sNote.ColumnIndex) * gxWidth - 3, vo.kHeight - 1)
            e.Graphics.DrawRectangle(xPen2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight, nLength(sNote.ColumnIndex) * gxWidth - 2, vo.kHeight)

            e.Graphics.DrawString(IIf(nNumericLabel(sNote.ColumnIndex), sNote.Value / 10000, xLabel), _
                        vo.kFont, xBrush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShiftL, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift)

        End If

        If sNote.PairWithI <> 0 Then
            Dim xPen2 As New Pen(nCol(sNote.ColumnIndex).getLongBright(xAlpha))
            Dim xBrush3 As New Drawing2D.LinearGradientBrush( _
                        New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) - 0.5 * nLength(sNote.ColumnIndex), xHS), _
                                VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight)), _
                        New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + 1.5 * nLength(sNote.ColumnIndex), xHS), _
                                VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) + vo.kHeight), _
                        nCol(sNote.ColumnIndex).getLongBright(xAlpha), _
                        nCol(sNote.ColumnIndex).getLongDark(xAlpha))
            e.Graphics.FillRectangle(xBrush3, HorizontalPositiontoDisplay(nLeft(K(sNote.PairWithI).ColumnIndex), xHS) + 3, VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) + 1, _
                                            nLength(K(sNote.PairWithI).ColumnIndex) * gxWidth - 5, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) - vo.kHeight - 1)
            e.Graphics.DrawRectangle(xPen2, HorizontalPositiontoDisplay(nLeft(K(sNote.PairWithI).ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight), _
                                            nLength(K(sNote.PairWithI).ColumnIndex) * gxWidth - 4, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) - vo.kHeight)
        End If

        'e.Graphics.DrawString(sNote.TimeOffset.ToString("0.##"), New Font("Verdana", 9), Brushes.Cyan, _
        '                      New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex + 1), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 2))

        'If ErrorCheck AndAlso (sNote.LongNote Xor sNote.PairWithI <> 0) Then e.Graphics.DrawImage(My.Resources.ImageError, _
        If ErrorCheck AndAlso sNote.HasError Then e.Graphics.DrawImage(My.Resources.ImageError, _
                                                            CInt(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex) / 2, xHS) - 12), _
                                                            CInt(VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight / 2 - 12), _
                                                            24, 24)

        If sNote.Selected Then e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 1, nLength(sNote.ColumnIndex) * gxWidth, vo.kHeight + 2)

    End Sub

    ''' <summary>
    ''' Draw a note in a buffer under NT mode.
    ''' </summary>
    ''' <param name="sNote">Note to be drawn.</param>
    ''' <param name="e">Buffer.</param>
    ''' <param name="xHS">HS.Value.</param>
    ''' <param name="xVS">VS.Value.</param>
    ''' <param name="xHeight">Display height of the panel. (not ClipRectangle.Height)</param>

    Private Sub DrawNoteNT(ByVal sNote As Note, ByVal e As BufferedGraphics, ByVal xHS As Long, ByVal xVS As Long, ByVal xHeight As Integer) ', Optional ByVal CheckError As Boolean = True)
        If Not nEnabled(sNote.ColumnIndex) Then Exit Sub
        Dim xAlpha As Single = 1.0F
        If sNote.Hidden Then xAlpha = vo.kOpacity

        Dim xLabel As String = C10to36(sNote.Value \ 10000)
        If ShowFileName AndAlso hWAV(C36to10(xLabel)) <> "" Then xLabel = Path.GetFileNameWithoutExtension(hWAV(C36to10(xLabel)))

        Dim xPen1 As Pen
        Dim xBrush As Drawing2D.LinearGradientBrush
        Dim xBrush2 As SolidBrush

        If sNote.Length = 0 Then
            xPen1 = New Pen(nCol(sNote.ColumnIndex).getBright(xAlpha))
            xBrush = New Drawing2D.LinearGradientBrush( _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10), _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) + 10), _
                            nCol(sNote.ColumnIndex).getBright(xAlpha), _
                            nCol(sNote.ColumnIndex).getDark(xAlpha))
            xBrush2 = New SolidBrush(nCol(sNote.ColumnIndex).cText)

            e.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + 1, nLength(sNote.ColumnIndex) * gxWidth - 3, vo.kHeight - 1)
            e.Graphics.DrawRectangle(xPen1, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight, nLength(sNote.ColumnIndex) * gxWidth - 2, vo.kHeight)

            e.Graphics.DrawString(IIf(nNumericLabel(sNote.ColumnIndex), sNote.Value / 10000, xLabel), _
                         vo.kFont, xBrush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShift, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift)

            If sNote.PairWithI > 0 Then
                Dim xPen2 As New Pen(nCol(sNote.ColumnIndex).getLongBright(xAlpha))
                Dim xBrush3 As New Drawing2D.LinearGradientBrush( _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) - 0.5 * nLength(sNote.ColumnIndex), xHS), _
                                    VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight)), _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + 1.5 * nLength(sNote.ColumnIndex), xHS), _
                                    VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) + vo.kHeight), _
                            nCol(sNote.ColumnIndex).getLongBright(xAlpha), _
                            nCol(sNote.ColumnIndex).getLongDark(xAlpha))
                e.Graphics.FillRectangle(xBrush3, HorizontalPositiontoDisplay(nLeft(K(sNote.PairWithI).ColumnIndex), xHS) + 3, VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) + 1, _
                                                nLength(K(sNote.PairWithI).ColumnIndex) * gxWidth - 5, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) - vo.kHeight - 1)
                e.Graphics.DrawRectangle(xPen2, HorizontalPositiontoDisplay(nLeft(K(sNote.PairWithI).ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight), _
                                                nLength(K(sNote.PairWithI).ColumnIndex) * gxWidth - 4, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - VerticalPositiontoDisplay(K(sNote.PairWithI).VPosition, xVS, xHeight) - vo.kHeight)
            End If

            If ErrorCheck AndAlso sNote.HasError Then e.Graphics.DrawImage(My.Resources.ImageError, CInt(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex) / 2, xHS) - 12), _
                                                                                                    CInt(VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight / 2 - 12), _
                                                                                                    24, 24)
            If sNote.Selected Then e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 1, _
                                                                        nLength(sNote.ColumnIndex) * gxWidth, vo.kHeight + 2)

        Else
            xPen1 = New Pen(nCol(sNote.ColumnIndex).getLongBright(xAlpha))
            xBrush = New Drawing2D.LinearGradientBrush( _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) - 0.5 * nLength(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight), _
                            New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + 1.5 * nLength(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight)), _
                            nCol(sNote.ColumnIndex).getLongBright(xAlpha), _
                            nCol(sNote.ColumnIndex).getLongDark(xAlpha))
            xBrush2 = New SolidBrush(nCol(sNote.ColumnIndex).cLText)

            e.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 3, VerticalPositiontoDisplay(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight + 1, _
                                             nLength(sNote.ColumnIndex) * gxWidth - 5, CInt(sNote.Length * gxHeight) + vo.kHeight - 1)
            e.Graphics.DrawRectangle(xPen1, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, VerticalPositiontoDisplay(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight, _
                                            nLength(sNote.ColumnIndex) * gxWidth - 4, CInt(sNote.Length * gxHeight) + vo.kHeight)

            e.Graphics.DrawString(IIf(nNumericLabel(sNote.ColumnIndex), sNote.Value / 10000, xLabel), _
                         vo.kFont, xBrush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShiftL, VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift)

            If ErrorCheck AndAlso sNote.HasError Then e.Graphics.DrawImage(My.Resources.ImageError, CInt(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + nLength(sNote.ColumnIndex) / 2, xHS) - 12), _
                                                                                                    CInt(VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight / 2 - 12), _
                                                                                                    24, 24)
            If sNote.Selected Then e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), VerticalPositiontoDisplay(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight - 1, _
                                                                        nLength(sNote.ColumnIndex) * gxWidth, CInt(sNote.Length * gxHeight) + vo.kHeight + 2)

        End If

        'e.Graphics.DrawString(sNote.TimeOffset.ToString("0.##"), New Font("Verdana", 9), Brushes.Cyan, _
        '                      New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex + 1), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 2))

    End Sub

    Private Sub UpdatePairing()
        Dim i As Integer, j As Integer

        If NTInput Then
            For i = 0 To UBound(K)
                K(i).HasError = False
                K(i).PairWithI = 0
                If K(i).Length < 0 Then K(i).Length = 0
            Next

            For i = 1 To UBound(K)
                If K(i).Length <> 0 Then
                    For j = i + 1 To UBound(K)
                        If K(j).VPosition > K(i).VPosition + K(i).Length Then Exit For
                        If K(j).ColumnIndex = K(i).ColumnIndex Then K(j).HasError = True
                    Next
                Else
                    For j = i + 1 To UBound(K)
                        If K(j).VPosition > K(i).VPosition Then Exit For
                        If K(j).ColumnIndex = K(i).ColumnIndex Then K(j).HasError = True
                    Next

                    If K(i).Value \ 10000 = LnObj AndAlso Not nNumericLabel(K(i).ColumnIndex) Then
                        For j = i - 1 To 1 Step -1
                            If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
                            If K(j).Hidden Then Continue For

                            If K(j).Length <> 0 OrElse K(j).Value \ 10000 = LnObj Then
                                K(i).HasError = True
                            Else
                                K(i).PairWithI = j
                                K(j).PairWithI = i
                            End If
                            Exit For
                        Next
                        If j = 0 Then K(i).HasError = True
                    End If
                End If
            Next

        Else
            For i = 0 To UBound(K)
                K(i).HasError = False
                K(i).PairWithI = 0
            Next

            For i = 1 To UBound(K)

                If K(i).LongNote Then
                    'LongNote: If overlapping a note, then error.
                    '          Else if already matched by a LongNote below, then match it.
                    '          Otherwise match anything above.
                    '              If ShortNote above then error on above.
                    '          If nothing above then error.
                    For j = i - 1 To 1 Step -1
                        If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
                        If K(j).VPosition = K(i).VPosition Then
                            K(i).HasError = True
                            GoTo EndSearch
                        ElseIf K(j).LongNote And K(j).PairWithI = i Then
                            K(i).PairWithI = j
                            GoTo EndSearch
                        Else
                            Exit For
                        End If
                    Next

                    For j = i + 1 To UBound(K)
                        If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
                        K(i).PairWithI = j
                        K(j).PairWithI = i
                        If Not K(j).LongNote AndAlso K(j).Value \ 10000 <> LnObj Then K(j).HasError = True
                        Exit For
                    Next

                    If j = UBound(K) + 1 Then K(i).HasError = True
EndSearch:

                ElseIf K(i).Value \ 10000 = LnObj Then
                    'LnObj: Match anything below.
                    '           If matching a LongNote not matching back, then error on below.
                    '           If overlapping a note, then error.
                    '           If mathcing a LnObj below, then error on below.
                    '       If nothing below, then error.
                    For j = i - 1 To 1 Step -1
                        If K(i).ColumnIndex <> K(j).ColumnIndex Then Continue For
                        If K(j).PairWithI <> 0 And K(j).PairWithI <> i Then K(j).HasError = True
                        K(i).PairWithI = j
                        K(j).PairWithI = i
                        If K(i).VPosition = K(j).VPosition Then K(i).HasError = True
                        If K(j).Value \ 10000 = LnObj Then K(j).HasError = True
                        Exit For
                    Next

                    If j = 0 Then K(i).HasError = True

                Else
                    'ShortNote: If overlapping a note, then error.
                    For j = i - 1 To 1 Step -1
                        If K(j).VPosition < K(i).VPosition Then Exit For
                        If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
                        K(i).HasError = True
                        Exit For
                    Next

                End If
            Next


            'For i = 0 To UBound(K)
            '    If K(i).LongNote Then
            '        For j = i - 1 To 1 Step -1
            '            If K(i).ColumnIndex <> K(j).ColumnIndex Then Continue For
            '
            '            If K(i).VPosition = K(j).VPosition Then
            '                K(i).HasError = True
            '                GoTo EndOfLoop
            '            End If
            '
            '            If K(j).LongNote AndAlso K(j).PairWithI = i Then
            '                K(i).PairWithI = j
            '                GoTo EndOfLoop
            '            End If
            '        Next
            '
            '        For j = i + 1 To UBound(K)
            '            If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
            '            If K(i).VPosition = K(j).VPosition Then
            '                K(j).HasError = True
            '            Else
            '                K(i).PairWithI = j
            '            End If
            '            Exit For
            '        Next
            'EndOfLoop:  
            '    Else
            '        For j = i + 1 To UBound(K)
            '            If K(j).VPosition > K(i).VPosition Then Exit For
            '            If K(j).ColumnIndex = K(i).ColumnIndex Then
            '                K(j).HasError = True
            '                K(j).TempBoolean = True
            '            End If
            '        Next
            '
            '        If K(i).Value \ 10000 = LnObj AndAlso Not nNumericLabel(K(i).ColumnIndex) Then
            '            For j = i - 1 To 1 Step -1
            '                If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For
            '                If K(j).Hidden Then Continue For
            '
            '                If K(j).LongNote OrElse K(j).Value \ 10000 = LnObj Then
            '                    K(i).HasError = True
            '                Else
            '                    K(i).PairWithI = j
            '                    K(j).PairWithI = i
            '                End If
            '                Exit For
            '            Next
            '            If j = 0 Then K(i).HasError = True
            '        End If
            '    End If
            '    'K(xI1).TempBoolean = True
            'Next
        End If

        Dim currentMS = 0.0#
        Dim currentBPM = K(0).Value / 10000
        Dim currentBPMVPosition = 0.0#
        For i = 1 To UBound(K)
            If K(i).ColumnIndex = niBPM Then
                currentMS += (K(i).VPosition - currentBPMVPosition) / currentBPM * 1250
                currentBPM = K(i).Value / 10000
                currentBPMVPosition = K(i).VPosition
            End If
            'K(i).TimeOffset = currentMS + (K(i).VPosition - currentBPMVPosition) / currentBPM * 1250
        Next
    End Sub

    Private Sub OpenBMS(ByVal xStrAll As String)
        KMouseOver = -1

        'Line feed validation: will remove some empty lines
        xStrAll = Replace(Replace(Replace(xStrAll, vbLf, vbCr), vbCr & vbCr, vbCr), vbCr, vbCrLf)

        Dim xStrLine() As String = Split(xStrAll, vbCrLf, , CompareMethod.Text)
        Dim xI1 As Integer
        Dim sLine As String
        Dim xExpansion As String = ""
        ReDim K(0)
        ReDim mColumn(999)
        ReDim hWAV(1295)
        ReDim hBPM(1295)    'x10000
        ReDim hSTOP(1295)
        Me.InitializeNewBMS()
        Me.InitializeOpenBMS()

        With K(0)
            .ColumnIndex = niBPM
            .VPosition = -1
            '.LongNote = False
            '.Selected = False
            .Value = 1200000
        End With

        'random, setRandom      0
        'endRandom              0
        'if             +1
        'else           0
        'endif          -1
        'switch, setSwitch      +1
        'case, skip, def        0
        'endSw                  -1
        Dim xStack As Integer = 0

        For Each sLine In xStrLine
            Dim sLineTrim As String = sLine.Trim
            If xStack > 0 Then GoTo Expansion

            If sLineTrim.StartsWith("#") And Mid(sLineTrim, 5, 3) = "02:" Then
                Dim xIndex As Integer = Val(Mid(sLineTrim, 2, 3))
                Dim xRatio As Double = Val(Mid(sLineTrim, 8))
                Dim xxD As Long = GetDenominator(xRatio)
                MeasureLength(xIndex) = xRatio * 192.0R
                LBeat.Items(xIndex) = Add3Zeros(xIndex) & ": " & xRatio & IIf(xxD > 10000, "", " ( " & CLng(xRatio * xxD) & " / " & xxD & " ) ")

            ElseIf sLineTrim.StartsWith("#WAV", StringComparison.CurrentCultureIgnoreCase) Then
                hWAV(C36to10(Mid(sLineTrim, Len("#WAV") + 1, 2))) = Mid(sLineTrim, Len("#WAV") + 4)

            ElseIf sLineTrim.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase) And Not Mid(sLineTrim, Len("#BPM") + 1, 1).Trim = "" Then  'If BPM##
                If Val(Mid(sLineTrim, Len("#BPM") + 4)) > 0 And Val(Mid(sLineTrim, Len("#BPM") + 4)) < 65536 Then
                    hBPM(C36to10(Mid(sLineTrim, Len("#BPM") + 1, 2))) = Val(Mid(sLineTrim, Len("#BPM") + 4)) * 10000
                ElseIf Val(Mid(sLineTrim, Len("#BPM") + 4)) >= 65536 Then
                    hBPM(C36to10(Mid(sLineTrim, Len("#BPM") + 1, 2))) = 655359999
                End If

            ElseIf sLineTrim.StartsWith("#STOP", StringComparison.CurrentCultureIgnoreCase) Then
                If Val(Mid(sLineTrim, Len("#STOP") + 4)) > 0 And Val(Mid(sLineTrim, Len("#STOP") + 4)) < 65536 Then
                    hSTOP(C36to10(Mid(sLineTrim, Len("#STOP") + 1, 2))) = Val(Mid(sLineTrim, Len("#STOP") + 4)) * 10000
                ElseIf Val(Mid(sLineTrim, Len("#STOP") + 4)) >= 65536 Then
                    hSTOP(C36to10(Mid(sLineTrim, Len("#STOP") + 1, 2))) = 655359999
                End If


            ElseIf sLineTrim.StartsWith("#TITLE", StringComparison.CurrentCultureIgnoreCase) Then
                THTitle.Text = Mid(sLineTrim, Len("#TITLE") + 1).Trim

            ElseIf sLineTrim.StartsWith("#ARTIST", StringComparison.CurrentCultureIgnoreCase) Then
                THArtist.Text = Mid(sLineTrim, Len("#ARTIST") + 1).Trim

            ElseIf sLineTrim.StartsWith("#GENRE", StringComparison.CurrentCultureIgnoreCase) Then
                THGenre.Text = Mid(sLineTrim, Len("#GENRE") + 1).Trim

            ElseIf sLineTrim.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase) Then  'If BPM ####
                K(0).Value = Val(Mid(sLineTrim, Len("#BPM") + 1).Trim) * 10000
                THBPM.Value = K(0).Value / 10000

            ElseIf sLineTrim.StartsWith("#PLAYER", StringComparison.CurrentCultureIgnoreCase) Then
                Dim xInt As Integer = Val(Mid(sLineTrim, Len("#PLAYER") + 1).Trim)
                If xInt >= 1 And xInt <= 4 Then _
                    CHPlayer.SelectedIndex = xInt - 1

            ElseIf sLineTrim.StartsWith("#RANK", StringComparison.CurrentCultureIgnoreCase) Then
                Dim xInt As Integer = Val(Mid(sLineTrim, Len("#RANK") + 1).Trim)
                If xInt >= 0 And xInt <= 4 Then _
                    CHRank.SelectedIndex = xInt

            ElseIf sLineTrim.StartsWith("#PLAYLEVEL", StringComparison.CurrentCultureIgnoreCase) Then
                THPlayLevel.Text = Mid(sLineTrim, Len("#PLAYLEVEL") + 1).Trim


            ElseIf sLineTrim.StartsWith("#SUBTITLE", StringComparison.CurrentCultureIgnoreCase) Then
                THSubTitle.Text = Mid(sLineTrim, Len("#SUBTITLE") + 1).Trim

            ElseIf sLineTrim.StartsWith("#SUBARTIST", StringComparison.CurrentCultureIgnoreCase) Then
                THSubArtist.Text = Mid(sLineTrim, Len("#SUBARTIST") + 1).Trim

            ElseIf sLineTrim.StartsWith("#STAGEFILE", StringComparison.CurrentCultureIgnoreCase) Then
                THStageFile.Text = Mid(sLineTrim, Len("#STAGEFILE") + 1).Trim

            ElseIf sLineTrim.StartsWith("#BANNER", StringComparison.CurrentCultureIgnoreCase) Then
                THBanner.Text = Mid(sLineTrim, Len("#BANNER") + 1).Trim

            ElseIf sLineTrim.StartsWith("#BACKBMP", StringComparison.CurrentCultureIgnoreCase) Then
                THBackBMP.Text = Mid(sLineTrim, Len("#BACKBMP") + 1).Trim

            ElseIf sLineTrim.StartsWith("#DIFFICULTY", StringComparison.CurrentCultureIgnoreCase) Then
                Try
                    CHDifficulty.SelectedIndex = Integer.Parse(Mid(sLineTrim, Len("#DIFFICULTY") + 1).Trim)
                Catch ex As Exception
                End Try

            ElseIf sLineTrim.StartsWith("#EXRANK", StringComparison.CurrentCultureIgnoreCase) Then
                THExRank.Text = Mid(sLineTrim, Len("#EXRANK") + 1).Trim

            ElseIf sLineTrim.StartsWith("#TOTAL", StringComparison.CurrentCultureIgnoreCase) Then
                Dim xStr As String = Mid(sLineTrim, Len("#TOTAL") + 1).Trim
                'If xStr.EndsWith("%") Then xStr = Mid(xStr, 1, Len(xStr) - 1)
                THTotal.Text = xStr

            ElseIf sLineTrim.StartsWith("#COMMENT", StringComparison.CurrentCultureIgnoreCase) Then
                Dim xStr As String = Mid(sLineTrim, Len("#COMMENT") + 1).Trim
                If xStr.StartsWith("""") Then xStr = Mid(xStr, 2)
                If xStr.EndsWith("""") Then xStr = Mid(xStr, 1, Len(xStr) - 1)
                THComment.Text = xStr

            ElseIf sLineTrim.StartsWith("#LNTYPE", StringComparison.CurrentCultureIgnoreCase) Then
                'THLnType.Text = Mid(sLineTrim, Len("#LNTYPE") + 1).Trim
                If Val(Mid(sLineTrim, Len("#LNTYPE") + 1).Trim) = 1 Then CHLnObj.SelectedIndex = 0

            ElseIf sLineTrim.StartsWith("#LNOBJ", StringComparison.CurrentCultureIgnoreCase) Then
                Dim xValue As Integer = C36to10(Mid(sLineTrim, Len("#LNOBJ") + 1).Trim)
                CHLnObj.SelectedIndex = xValue

                'TODO: LNOBJ value validation

                'ElseIf sLineTrim.StartsWith("#LNTYPE", StringComparison.CurrentCultureIgnoreCase) Then
                '    CAdLNTYPE.Checked = True
                '    If Mid(sLineTrim, 9) = "" Or Mid(sLineTrim, 9) = "1" Or Mid(sLineTrim, 9) = "01" Then CAdLNTYPEb.Text = "1"
                '    CAdLNTYPEb.Text = Mid(sLineTrim, 9)

            ElseIf sLineTrim.StartsWith("#") And Mid(sLineTrim, 7, 1) = ":" Then   'If the line contains Ks
                Dim xIdentifier As String = Mid(sLineTrim, 5, 2)
                If IdentifiertoColumnIndex(xIdentifier) = 0 Then GoTo AddExpansion

            Else
Expansion:      If sLineTrim.StartsWith("#IF", StringComparison.CurrentCultureIgnoreCase) Then
                    xStack += 1 : GoTo AddExpansion
                ElseIf sLineTrim.StartsWith("#ENDIF", StringComparison.CurrentCultureIgnoreCase) Then
                    xStack -= 1 : GoTo AddExpansion
                ElseIf sLineTrim.StartsWith("#SWITCH", StringComparison.CurrentCultureIgnoreCase) Then
                    xStack += 1 : GoTo AddExpansion
                ElseIf sLineTrim.StartsWith("#SETSWITCH", StringComparison.CurrentCultureIgnoreCase) Then
                    xStack += 1 : GoTo AddExpansion
                ElseIf sLineTrim.StartsWith("#ENDSW", StringComparison.CurrentCultureIgnoreCase) Then
                    xStack -= 1 : GoTo AddExpansion

                ElseIf sLineTrim.StartsWith("#") Then
AddExpansion:       xExpansion &= sLine & vbCrLf
                End If

            End If
        Next

        UpdateMeasureBottom()

        xStack = 0
        For Each sLine In xStrLine
            Dim sLineTrim As String = sLine.Trim
            If xStack > 0 Then Continue For

            If Not (sLineTrim.StartsWith("#") And Mid(sLineTrim, 7, 1) = ":") Then Continue For 'If the line contains Ks

            ' >> Measure =           Mid(sLine, 2, 3)
            ' >> Column Identifier = Mid(sLine, 5, 2)
            ' >> K =                 Mid(sLine, xI1, 2)
            Dim xMeasure As Integer = Val(Mid(sLineTrim, 2, 3))
            Dim xIdentifier As String = Mid(sLineTrim, 5, 2)
            If IdentifiertoColumnIndex(xIdentifier) = 0 Then Continue For

            If xIdentifier = "01" Then mColumn(xMeasure) += 1 'If the identifier is 01 then add a B column in that measure
            For xI1 = 8 To Len(sLineTrim) - 1 Step 2   'For all Ks within that line ( - 1 can be ommitted )
                If Mid(sLineTrim, xI1, 2) = "00" Then Continue For 'If the K is not 00

                ReDim Preserve K(K.Length)
                With K(UBound(K))
                    .ColumnIndex = IdentifiertoColumnIndex(xIdentifier) + _
                                        IIf(xIdentifier = "01", 1, 0) * (mColumn(xMeasure) - 1)
                    .LongNote = IdentifiertoLongNote(xIdentifier)
                    .Hidden = IdentifiertoHidden(xIdentifier)
                    .Selected = False
                    .VPosition = MeasureBottom(xMeasure) + MeasureLength(xMeasure) * (xI1 / 2 - 4) / ((Len(sLineTrim) - 7) / 2)
                    .Value = C36to10(Mid(sLineTrim, xI1, 2)) * 10000
                    If xIdentifier = "03" Then .Value = Convert.ToInt32(Mid(sLineTrim, xI1, 2), 16) * 10000
                    If xIdentifier = "08" Then .Value = hBPM(C36to10(Mid(sLineTrim, xI1, 2)))
                    If xIdentifier = "09" Then .Value = hSTOP(C36to10(Mid(sLineTrim, xI1, 2)))
                End With
            Next
        Next

        If NTInput Then ConvertBMSE2NT()

        LWAV.Visible = False
        LWAV.Items.Clear()
        For xI1 = 1 To 1295
            LWAV.Items.Add(C10to36(xI1) & ": " & hWAV(xI1))
        Next
        LWAV.SelectedIndex = 0
        LWAV.Visible = True

        TExpansion.Text = xExpansion

        SortByVPositionQuick(0, UBound(K))
        UpdatePairing()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Function SaveBMS() As String
        CalculateGreatestVPosition()
        SortByVPositionInsertion()
        UpdatePairing()
        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer
        Dim xI4 As Integer
        Dim hasOverlapping As Boolean = False
        'Dim xStrAll As String = ""   'for all 
        Dim xStrMeasure(InMeasure(GreatestVPosition) + 1) As String
        Dim Identifiers() As String = {"01", "03", "04", "06", "07", "08", "09", _
                                       "11", "12", "13", "14", "15", "16", "18", "19", _
                                       "21", "22", "23", "24", "25", "26", "28", "29", _
                                       "31", "32", "33", "34", "35", "36", "38", "39", _
                                       "41", "42", "43", "44", "45", "46", "48", "49", _
                                       "51", "52", "53", "54", "55", "56", "58", "59", _
                                       "61", "62", "63", "64", "65", "66", "68", "69", _
                                       "71", "72", "73", "74", "75", "76", "78", "79", _
                                       "81", "82", "83", "84", "85", "86", "88", "89"}
        ReDim hBPM(0)
        ReDim hSTOP(0)

        Dim xNTInput As Boolean = NTInput
        Dim xKBackUp() As Note = K
        If xNTInput Then
            NTInput = False
            ConvertNT2BMSE()
        End If

        'Dim xNumPlayer As String = "1"
        'For xI1 = 1 To UBound(K)
        ' If K(xI1).ColumnIndex >= niD1 And K(xI1).ColumnIndex <= niD8 Then xNumPlayer = "2" : Exit For
        'Next

        Dim xStrHeader As String = vbCrLf & "*---------------------- HEADER FIELD" & vbCrLf & vbCrLf
        xStrHeader &= "#PLAYER " & (CHPlayer.SelectedIndex + 1) & vbCrLf
        xStrHeader &= "#GENRE " & THGenre.Text & vbCrLf
        xStrHeader &= "#TITLE " & THTitle.Text & vbCrLf
        xStrHeader &= "#ARTIST " & THArtist.Text & vbCrLf
        xStrHeader &= "#BPM " & (K(0).Value / 10000) & vbCrLf
        xStrHeader &= "#PLAYLEVEL " & THPlayLevel.Text & vbCrLf
        xStrHeader &= "#RANK " & CHRank.SelectedIndex & vbCrLf
        xStrHeader &= vbCrLf
        If THSubTitle.Text <> "" Then xStrHeader &= "#SUBTITLE " & THSubTitle.Text & vbCrLf
        If THSubArtist.Text <> "" Then xStrHeader &= "#SUBARTIST " & THSubArtist.Text & vbCrLf
        If THStageFile.Text <> "" Then xStrHeader &= "#STAGEFILE " & THStageFile.Text & vbCrLf
        If THBanner.Text <> "" Then xStrHeader &= "#BANNER " & THBanner.Text & vbCrLf
        If THBackBMP.Text <> "" Then xStrHeader &= "#BACKBMP " & THBackBMP.Text & vbCrLf
        xStrHeader &= vbCrLf
        If CHDifficulty.SelectedIndex Then xStrHeader &= "#DIFFICULTY " & CHDifficulty.SelectedIndex & vbCrLf
        If THExRank.Text <> "" Then xStrHeader &= "#EXRANK " & THExRank.Text & vbCrLf
        If THTotal.Text <> "" Then xStrHeader &= "#TOTAL " & THTotal.Text & vbCrLf
        If THComment.Text <> "" Then xStrHeader &= "#COMMENT """ & THComment.Text & """" & vbCrLf
        'If THLnType.Text <> "" Then xStrHeader &= "#LNTYPE " & THLnType.Text & vbCrLf
        If CHLnObj.SelectedIndex > 0 Then xStrHeader &= "#LNOBJ " & C10to36(CHLnObj.SelectedIndex) & vbCrLf _
                                     Else xStrHeader &= "#LNTYPE 1" & vbCrLf
        xStrHeader &= vbCrLf

        Dim TempK() As Note   'Temp K for storing Ks in the same measure
        Dim xK As Note     'Temp K
        Dim GreatestColumn As Integer = 0  'greatest column for B column

        Dim xprevNotes(-1) As Note  'Notes too close to the next measure

        For xI1 = 0 To InMeasure(GreatestVPosition) + 1  'For xI1 in each measure
            xStrMeasure(xI1) = vbCrLf
            If MeasureLength(xI1) <> 192.0R Then xStrMeasure(xI1) &= "#" & Add3Zeros(xI1) & "02:" & (MeasureLength(xI1) / 192.0R) & vbCrLf

            For xI2 = 1 To UBound(K)  'Collect Ks in the same measure
                If InMeasure(K(xI2).VPosition) >= xI1 Then Exit For 'Lower limit found
            Next
            For xI3 = xI2 To UBound(K)
                If InMeasure(K(xI3).VPosition) > xI1 Then Exit For 'Upper limit found
            Next
            If xI3 - xI2 = 0 Then Continue For 'If there is no K in the current measure then end this loop

            'Start collecting Ks
            Dim xUPrevText As Integer = UBound(xprevNotes)
            ReDim TempK(xI3 - xI2 + xUPrevText)
            For xI4 = 0 To xUPrevText
                TempK(xI4) = xprevNotes(xI4)
            Next
            For xI4 = xI2 To xI3 - 1
                TempK(xI4 - xI2 + xprevNotes.Length) = K(xI4)
            Next
            ReDim xprevNotes(-1)

            GreatestColumn = 0
            For Each xK In TempK  'Find greatest column
                GreatestColumn = IIf(xK.ColumnIndex > GreatestColumn, xK.ColumnIndex, GreatestColumn)
            Next

            Dim xVPosition() As Double 'Ks in the same column
            Dim xText() As String    'Ks in the same column

            For xI3 = niB To GreatestColumn 'Start rendering B notes (xI3 is columnindex)
                ReDim xVPosition(-1) 'Ks in the same column
                ReDim xText(-1)      'Ks in the same column

                For xI4 = 0 To UBound(TempK) 'Find Ks in the same column (xI4 is TK index)
                    If TempK(xI4).ColumnIndex = xI3 Then
                        ReDim Preserve xVPosition(UBound(xVPosition) + 1)
                        ReDim Preserve xText(UBound(xText) + 1)
                        xVPosition(UBound(xVPosition)) = TempK(xI4).VPosition - MeasureBottom(InMeasure(TempK(xI4).VPosition))
                        If xVPosition(UBound(xVPosition)) < 0 Then xVPosition(UBound(xVPosition)) = 0
                        xText(UBound(xText)) = C10to36(TempK(xI4).Value \ 10000)
                    End If
                Next

                Dim xGCD As Double = MeasureLength(xI1)
                For xI2 = 0 To UBound(xVPosition)        'find greatest common divisor
                    If xVPosition(xI2) > 0 Then xGCD = GCD(xGCD, xVPosition(xI2))
                Next

                Dim xStrKey(CInt(MeasureLength(xI1) / xGCD) - 1) As String
                For xI2 = 0 To UBound(xStrKey)           'assign 00 to all keys
                    xStrKey(xI2) = "00"
                Next

                For xI2 = 0 To UBound(xVPosition)        'assign K texts
                    If CInt(xVPosition(xI2) / xGCD) > UBound(xStrKey) Then
                        ReDim Preserve xprevNotes(UBound(xprevNotes) + 1)
                        With xprevNotes(UBound(xprevNotes))
                            .ColumnIndex = xI3
                            .VPosition = MeasureBottom(xI1)
                            .Value = C36to10(xText(xI2))
                        End With
                        Continue For
                    End If
                    If xStrKey(CInt(xVPosition(xI2) / xGCD)) <> "00" Then hasOverlapping = True
                    xStrKey(CInt(xVPosition(xI2) / xGCD)) = xText(xI2)
                Next

                xStrMeasure(xI1) &= "#" & Add3Zeros(xI1) & "01:" & Join(xStrKey, "") & vbCrLf
            Next

            For xI3 = 1 To UBound(Identifiers) 'Start rendering other notes (xI3 is Identifiers index)
                ReDim xVPosition(-1) 'Ks in the same column
                ReDim xText(-1)      'Ks in the same column

                For xI4 = 0 To UBound(TempK) 'Find Ks in the same column (xI4 is TK index)
                    If nIdentifier(TempK(xI4).ColumnIndex, TempK(xI4).Value, TempK(xI4).LongNote, TempK(xI4).Hidden) = Identifiers(xI3) Then
                        ReDim Preserve xVPosition(UBound(xVPosition) + 1)
                        ReDim Preserve xText(UBound(xText) + 1)
                        xVPosition(UBound(xVPosition)) = TempK(xI4).VPosition - MeasureBottom(InMeasure(TempK(xI4).VPosition))
                        If xVPosition(UBound(xVPosition)) < 0 Then xVPosition(UBound(xVPosition)) = 0

                        If Identifiers(xI3) = "03" Then 'If integer bpm
                            xText(UBound(xText)) = Mid("0" & Hex(TempK(xI4).Value \ 10000), Len(Hex(TempK(xI4).Value \ 10000)))
                        ElseIf Identifiers(xI3) = "08" Then 'If bpm requires declaration
                            For xI2 = 1 To UBound(hBPM)
                                If TempK(xI4).Value = hBPM(xI2) Then Exit For
                            Next
                            If xI2 > UBound(hBPM) Then
                                ReDim Preserve hBPM(UBound(hBPM) + 1)
                                hBPM(UBound(hBPM)) = TempK(xI4).Value
                            End If
                            xText(UBound(xText)) = IIf(BPMx1296, C10to36(xI2), Mid("0" & Hex(xI2), Len(Hex(xI2))))
                        ElseIf Identifiers(xI3) = "09" Then 'If STOP
                            For xI2 = 1 To UBound(hSTOP)
                                If TempK(xI4).Value = hSTOP(xI2) Then Exit For
                            Next
                            If xI2 > UBound(hSTOP) Then
                                ReDim Preserve hSTOP(UBound(hSTOP) + 1)
                                hSTOP(UBound(hSTOP)) = TempK(xI4).Value
                            End If
                            xText(UBound(xText)) = IIf(STOPx1296, C10to36(xI2), Mid("0" & Hex(xI2), Len(Hex(xI2))))
                        Else
                            xText(UBound(xText)) = C10to36(TempK(xI4).Value \ 10000)
                        End If
                    End If
                Next

                If xVPosition.Length = 0 Then Continue For

                Dim xGCD As Double = MeasureLength(xI1)
                For xI2 = 0 To UBound(xVPosition)        'find greatest common divisor
                    If xVPosition(xI2) > 0 Then xGCD = GCD(xGCD, xVPosition(xI2))
                Next

                Dim xStrKey() As String
                ReDim xStrKey(CInt(MeasureLength(xI1) / xGCD) - 1)
                For xI2 = 0 To UBound(xStrKey)           'assign 00 to all keys
                    xStrKey(xI2) = "00"
                Next

                For xI2 = 0 To UBound(xVPosition)        'assign K texts
                    If CInt(xVPosition(xI2) / xGCD) > UBound(xStrKey) Then
                        ReDim Preserve xprevNotes(UBound(xprevNotes) + 1)
                        With xprevNotes(UBound(xprevNotes))
                            .ColumnIndex = IdentifiertoColumnIndex(Identifiers(xI3))
                            .LongNote = IdentifiertoLongNote(Identifiers(xI3))
                            .Hidden = IdentifiertoHidden(Identifiers(xI3))
                            .VPosition = MeasureBottom(xI1)
                            .Value = C36to10(xText(xI2))
                        End With
                        If Identifiers(xI3) = "08" Then _
                            xprevNotes(UBound(xprevNotes)).Value = IIf(BPMx1296, hBPM(C36to10(xText(xI2))), hBPM(Convert.ToInt32(xText(xI2), 16)))
                        If Identifiers(xI3) = "09" Then _
                            xprevNotes(UBound(xprevNotes)).Value = IIf(STOPx1296, hSTOP(C36to10(xText(xI2))), hSTOP(Convert.ToInt32(xText(xI2), 16)))
                        Continue For
                    End If
                    If xStrKey(CInt(xVPosition(xI2) / xGCD)) <> "00" Then hasOverlapping = True
                    xStrKey(CInt(xVPosition(xI2) / xGCD)) = xText(xI2)
                Next

                xStrMeasure(xI1) &= "#" & Add3Zeros(xI1) & Identifiers(xI3) & ":" & Join(xStrKey, "") & vbCrLf
            Next

        Next

        For xI1 = 1 To UBound(hWAV)
            If Not hWAV(xI1) = "" Then xStrHeader &= "#WAV" & C10to36(xI1) & " " & hWAV(xI1) & vbCrLf
        Next
        For xI1 = 1 To UBound(hBPM)
            xStrHeader &= "#BPM" & IIf(BPMx1296, C10to36(xI1), Mid("0" & Hex(xI1), Len(Hex(xI1)))) & " " & CStr(hBPM(xI1) / 10000) & vbCrLf
        Next
        For xI1 = 1 To UBound(hSTOP)
            xStrHeader &= "#STOP" & IIf(STOPx1296, C10to36(xI1), Mid("0" & Hex(xI1), Len(Hex(xI1)))) & " " & CStr(hSTOP(xI1) / 10000) & vbCrLf
        Next

        If hasOverlapping Then MsgBox(Locale.Messages.SaveWarning & vbCrLf & _
                                                          Locale.Messages.NoteOverlapError & vbCrLf & _
                                                Locale.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation)
        If UBound(hBPM) > IIf(BPMx1296, 1295, 255) Then MsgBox(Locale.Messages.SaveWarning & vbCrLf & _
                                                          Locale.Messages.BPMOverflowError & UBound(hBPM) & " > " & IIf(BPMx1296, 1295, 255) & vbCrLf & _
                                                Locale.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation)
        If UBound(hSTOP) > IIf(STOPx1296, 1295, 255) Then MsgBox(Locale.Messages.SaveWarning & vbCrLf & _
                                                           Locale.Messages.STOPOverflowError & UBound(hSTOP) & " > " & IIf(STOPx1296, 1295, 255) & vbCrLf & _
                                                  Locale.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation)

        Dim xStrExp As String = vbCrLf & "*---------------------- EXPANSION FIELD" & vbCrLf & TExpansion.Text & vbCrLf & vbCrLf
        If TExpansion.Text = "" Then xStrExp = ""

        Dim xStrMain As String = "*---------------------- MAIN DATA FIELD" & vbCrLf & vbCrLf & Join(xStrMeasure, "") & vbCrLf

        If xNTInput Then
            K = xKBackUp
            NTInput = True
            'SortByVPositionInsertion()
            'UpdatePairing()
        End If

        Dim xStrAll As String = xStrHeader & vbCrLf & xStrExp & vbCrLf & xStrMain
        Return xStrAll
    End Function

    Public Sub ExceptionSave(ByVal Path As String)
        SaveiBMSC(Path)
    End Sub

    Private Function OpenSM(ByVal xStrAll As String) As Boolean
        KMouseOver = -1

        Dim xStrLine() As String = Split(xStrAll, vbCrLf)
        'Remove comments starting with "//"
        For xI1 As Integer = 0 To UBound(xStrLine)
            If xStrLine(xI1).Contains("//") Then xStrLine(xI1) = Mid(xStrLine(xI1), 1, InStr(xStrLine(xI1), "//") - 1)
        Next

        xStrAll = Join(xStrLine, "")
        xStrLine = Split(xStrAll, ";")

        Dim iDiff As Integer = 0
        Dim iCurrentDiff As Integer = 0
        Dim xTempSplit() As String = Split(xStrAll, "#NOTES:")
        Dim xTempStr() As String = {}
        If xTempSplit.Length > 2 Then
            ReDim Preserve xTempStr(UBound(xTempSplit) - 1)
            For xI1 As Integer = 1 To UBound(xTempSplit)
                xTempSplit(xI1) = Mid(xTempSplit(xI1), InStr(xTempSplit(xI1), ":") + 1)
                xTempSplit(xI1) = Mid(xTempSplit(xI1), InStr(xTempSplit(xI1), ":") + 1).Trim
                xTempStr(xI1 - 1) = Mid(xTempSplit(xI1), 1, InStr(xTempSplit(xI1), ":") - 1)
                xTempSplit(xI1) = Mid(xTempSplit(xI1), InStr(xTempSplit(xI1), ":") + 1).Trim
                xTempStr(xI1 - 1) &= " : " & Mid(xTempSplit(xI1), 1, InStr(xTempSplit(xI1), ":") - 1)
            Next

            Dim xDiag As New dgImportSM(xTempStr)
            If xDiag.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return True
            iDiff = xDiag.iResult
        End If

        Dim sL As String
        ReDim K(0)
        ReDim mColumn(999)
        ReDim hWAV(1295)
        ReDim hBPM(1295)    'x10000
        ReDim hSTOP(1295)
        Me.InitializeNewBMS()

        With K(0)
            .ColumnIndex = niBPM
            .VPosition = -1
            '.LongNote = False
            '.Selected = False
            .Value = 1200000
        End With

        For Each sL In xStrLine
            If UCase(sL).StartsWith("#TITLE:") Then
                THTitle.Text = Mid(sL, Len("#TITLE:") + 1)

            ElseIf UCase(sL).StartsWith("#SUBTITLE:") Then
                If Not UCase(sL).EndsWith("#SUBTITLE:") Then THTitle.Text &= " " & Mid(sL, Len("#SUBTITLE:") + 1)

            ElseIf UCase(sL).StartsWith("#ARTIST:") Then
                THArtist.Text = Mid(sL, Len("#ARTIST:") + 1)

            ElseIf UCase(sL).StartsWith("#GENRE:") Then
                THGenre.Text = Mid(sL, Len("#GENRE:") + 1)

            ElseIf UCase(sL).StartsWith("#BPMS:") Then
                Dim xLine As String = Mid(sL, Len("#BPMS:") + 1)
                Dim xItem() As String = Split(xLine, ",")

                Dim xVal1 As Double
                Dim xVal2 As Double

                For xI1 As Integer = 0 To UBound(xItem)
                    xVal1 = Mid(xItem(xI1), 1, InStr(xItem(xI1), "=") - 1)
                    xVal2 = Mid(xItem(xI1), InStr(xItem(xI1), "=") + 1)

                    If xVal1 <> 0 Then
                        ReDim Preserve K(K.Length)
                        With K(UBound(K))
                            .ColumnIndex = niBPM
                            '.LongNote = False
                            '.Hidden = False
                            '.Selected = False
                            .VPosition = xVal1 * 48
                            .Value = xVal2 * 10000
                        End With
                    Else
                        K(0).Value = xVal2 * 10000
                    End If
                Next

            ElseIf UCase(sL).StartsWith("#NOTES:") Then
                If iCurrentDiff <> iDiff Then iCurrentDiff += 1 : GoTo Jump1

                iCurrentDiff += 1
                Dim xLine As String = Mid(sL, Len("#NOTES:") + 1)
                Dim xItem() As String = Split(xLine, ":")
                For xI1 As Integer = 0 To UBound(xItem)
                    xItem(xI1) = xItem(xI1).Trim
                Next

                If xItem.Length <> 6 Then GoTo Jump1

                THPlayLevel.Text = xItem(3)

                Dim xM() As String = Split(xItem(5), ",")
                For xI1 As Integer = 0 To UBound(xM)
                    xM(xI1) = xM(xI1).Trim
                Next

                For xI1 As Integer = 0 To UBound(xM)
                    For xI2 As Integer = 0 To Len(xM(xI1)) - 1 Step 4
                        If xM(xI1)(xI2) <> "0" Then
                            ReDim Preserve K(K.Length)
                            With K(UBound(K))
                                .ColumnIndex = niA1
                                .LongNote = xM(xI1)(xI2) = "2" Or xM(xI1)(xI2) = "3"
                                '.Hidden = False
                                '.Selected = False
                                .VPosition = (192 \ (Len(xM(xI1)) \ 4)) * xI2 \ 4 + xI1 * 192
                                .Value = 10000
                            End With
                        End If
                        If xM(xI1)(xI2 + 1) <> "0" Then
                            ReDim Preserve K(K.Length)
                            With K(UBound(K))
                                .ColumnIndex = niA2
                                .LongNote = xM(xI1)(xI2 + 1) = "2" Or xM(xI1)(xI2 + 1) = "3"
                                '.Hidden = False
                                '.Selected = False
                                .VPosition = (192 \ (Len(xM(xI1)) \ 4)) * xI2 \ 4 + xI1 * 192
                                .Value = 10000
                            End With
                        End If
                        If xM(xI1)(xI2 + 2) <> "0" Then
                            ReDim Preserve K(K.Length)
                            With K(UBound(K))
                                .ColumnIndex = niA3
                                .LongNote = xM(xI1)(xI2 + 2) = "2" Or xM(xI1)(xI2 + 2) = "3"
                                '.Hidden = False
                                '.Selected = False
                                .VPosition = (192 \ (Len(xM(xI1)) \ 4)) * xI2 \ 4 + xI1 * 192
                                .Value = 10000
                            End With
                        End If
                        If xM(xI1)(xI2 + 3) <> "0" Then
                            ReDim Preserve K(K.Length)
                            With K(UBound(K))
                                .ColumnIndex = niA4
                                .LongNote = xM(xI1)(xI2 + 3) = "2" Or xM(xI1)(xI2 + 3) = "3"
                                '.Hidden = False
                                '.Selected = False
                                .VPosition = (192 \ (Len(xM(xI1)) \ 4)) * xI2 \ 4 + xI1 * 192
                                .Value = 10000
                            End With
                        End If
                    Next
                Next
Jump1:
            End If
        Next

        If NTInput Then ConvertBMSE2NT()

        LWAV.Visible = False
        LWAV.Items.Clear()
        For xI1 As Integer = 1 To 1295
            LWAV.Items.Add(C10to36(xI1) & ": " & hWAV(xI1))
        Next
        LWAV.SelectedIndex = 0
        LWAV.Visible = True

        THBPM.Value = K(0).Value / 10000
        SortByVPositionQuick(0, UBound(K))
        UpdatePairing()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
        Return False
    End Function

    ''' <summary>Do not clear Undo.</summary>
    Private Sub OpeniBMSC(ByVal Path As String)
        KMouseOver = -1

        Dim br As New BinaryReader(New FileStream(Path, FileMode.Open, FileAccess.Read), System.Text.Encoding.Unicode)

        If br.ReadInt32 <> &H534D4269 Then GoTo EndOfSub
        If br.ReadByte <> CByte(&H43) Then GoTo EndOfSub
        Dim xMajor As Integer = br.ReadByte
        Dim xMinor As Integer = br.ReadByte
        Dim xBuild As Integer = br.ReadByte

        ClearUndo()
        ReDim K(0)
        ReDim mColumn(999)
        ReDim hWAV(1295)
        Me.InitializeNewBMS()
        Me.InitializeOpenBMS()

        With K(0)
            .ColumnIndex = niBPM
            .VPosition = -1
            '.LongNote = False
            '.Selected = False
            .Value = 1200000
        End With

        Do Until br.BaseStream.Position >= br.BaseStream.Length
            Dim BlockID As Integer = br.ReadInt32()

            Select Case BlockID

                Case &H66657250     'Preferences
                    Dim xPref As Integer = br.ReadInt32

                    NTInput = xPref And &H1
                    TBNTInput.Checked = NTInput
                    mnNTInput.Checked = NTInput
                    POBLong.Enabled = Not NTInput
                    POBLongShort.Enabled = Not NTInput

                    ErrorCheck = xPref And &H2
                    TBErrorCheck.Checked = ErrorCheck
                    TBErrorCheck_Click(TBErrorCheck, New System.EventArgs)

                    PreviewOnClick = xPref And &H4
                    TBPreviewOnClick.Checked = PreviewOnClick
                    TBPreviewOnClick_Click(TBPreviewOnClick, New System.EventArgs)

                    ShowFileName = xPref And &H8
                    TBShowFileName.Checked = ShowFileName
                    TBShowFileName_Click(TBShowFileName, New System.EventArgs)

                    mnSMenu.Checked = xPref And &H100
                    mnSTB.Checked = xPref And &H200
                    mnSOP.Checked = xPref And &H400
                    mnSStatus.Checked = xPref And &H800
                    mnSLSplitter.Checked = xPref And &H1000
                    mnSRSplitter.Checked = xPref And &H2000

                    CGShow.Checked = xPref And &H4000
                    CGShowS.Checked = xPref And &H8000
                    CGShowBG.Checked = xPref And &H10000
                    CGShowM.Checked = xPref And &H20000
                    CGShowMB.Checked = xPref And &H40000
                    CGShowV.Checked = xPref And &H80000
                    CGShowC.Checked = xPref And &H100000
                    CGBLP.Checked = xPref And &H200000
                    CGSTOP.Checked = xPref And &H400000
                    CGBPM.Checked = xPref And &H800000

                    CGSnap.Checked = xPref And &H1000000
                    CGDisableVertical.Checked = xPref And &H2000000
                    cVSLockL.Checked = xPref And &H4000000
                    cVSLock.Checked = xPref And &H8000000
                    cVSLockR.Checked = xPref And &H10000000

                    CGDivide.Value = br.ReadInt32
                    CGSub.Value = br.ReadInt32
                    gSlash = br.ReadInt32
                    CGHeight.Value = br.ReadSingle
                    CGWidth.Value = br.ReadSingle
                    CGB.Value = br.ReadInt32

                Case &H64616548     'Header
                    THTitle.Text = br.ReadString
                    THArtist.Text = br.ReadString
                    THGenre.Text = br.ReadString
                    K(0).Value = br.ReadInt32
                    Dim xPlayerRank As Integer = br.ReadByte
                    THPlayLevel.Text = br.ReadString

                    CHPlayer.SelectedIndex = xPlayerRank And &HF
                    CHRank.SelectedIndex = xPlayerRank >> 4

                    THSubTitle.Text = br.ReadString
                    THSubArtist.Text = br.ReadString
                    'THMaker.Text = br.ReadString
                    THStageFile.Text = br.ReadString
                    THBanner.Text = br.ReadString
                    THBackBMP.Text = br.ReadString
                    'THMidiFile.Text = br.ReadString
                    CHDifficulty.SelectedIndex = br.ReadByte
                    THExRank.Text = br.ReadString
                    THTotal.Text = br.ReadString
                    'THVolWAV.Text = br.ReadString
                    THComment.Text = br.ReadString
                    'THLnType.Text = br.ReadString
                    CHLnObj.SelectedIndex = br.ReadInt16

                Case &H564157       'WAV List
                    Dim xWAVOptions As Integer = br.ReadByte
                    WAVMultiSelect = xWAVOptions And &H1
                    CWAVMultiSelect.Checked = WAVMultiSelect
                    CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, New EventArgs)
                    WAVChangeLabel = xWAVOptions And &H2
                    CWAVChangeLabel.Checked = WAVChangeLabel
                    CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, New EventArgs)

                    Dim xWAVCount As Integer = br.ReadInt32
                    For xxi As Integer = 1 To xWAVCount
                        Dim xI As Integer = br.ReadInt16
                        hWAV(xI) = br.ReadString
                    Next

                Case &H74616542     'Beat
                    nBeatN.Value = br.ReadInt16
                    nBeatD.Value = br.ReadInt16
                    'nBeatD.SelectedIndex = br.ReadByte

                    Dim xBeatChangeMode As Integer = br.ReadByte
                    Dim xBeatChangeList As RadioButton() = {CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale}
                    xBeatChangeList(xBeatChangeMode).Checked = True
                    CBeatPreserve_Click(xBeatChangeList(xBeatChangeMode), New System.EventArgs)

                    Dim xBeatCount As Integer = br.ReadInt32
                    For xxi As Integer = 1 To xBeatCount
                        Dim xIndex As Integer = br.ReadInt16
                        MeasureLength(xIndex) = br.ReadDouble
                        Dim xRatio As Double = MeasureLength(xIndex) / 192.0R
                        Dim xxD As Long = GetDenominator(xRatio)
                        LBeat.Items(xIndex) = Add3Zeros(xIndex) & ": " & xRatio & IIf(xxD > 10000, "", " ( " & CLng(xRatio * xxD) & " / " & xxD & " ) ")
                    Next

                Case &H6E707845     'Expansion Code
                    TExpansion.Text = br.ReadString

                Case &H65746F4E     'Note
                    Dim xNoteUbound As Integer = br.ReadInt32
                    ReDim Preserve K(xNoteUbound)
                    For i As Integer = 1 To UBound(K)
                        K(i).VPosition = br.ReadDouble
                        K(i).ColumnIndex = br.ReadInt32
                        K(i).Value = br.ReadInt32
                        Dim xFormat As Integer = br.ReadByte
                        K(i).Length = br.ReadDouble

                        K(i).LongNote = xFormat And &H1
                        K(i).Hidden = xFormat And &H2
                        K(i).Selected = xFormat And &H4
                    Next

                Case &H6F646E55     'Undo / Redo Commands
                    Dim URCount As Integer = br.ReadInt32   'Should be 100
                    sI = br.ReadInt32

                    For xI As Integer = 0 To 99
                        Dim xUndoCount As Integer = br.ReadInt32
                        Dim xBaseUndo As New UndoRedo.Void
                        Dim xIteratorUndo As UndoRedo.LinkedURCmd = xBaseUndo
                        For xxj As Integer = 1 To xUndoCount
                            Dim xByteLen As Integer = br.ReadInt32
                            Dim xByte() As Byte = br.ReadBytes(xByteLen)
                            xIteratorUndo.Next = UndoRedo.fromBytes(xByte)
                            xIteratorUndo = xIteratorUndo.Next
                        Next
                        sUndo(xI) = xBaseUndo.Next

                        Dim xRedoCount As Integer = br.ReadInt32
                        Dim xBaseRedo As New UndoRedo.Void
                        Dim xIteratorRedo As UndoRedo.LinkedURCmd = xBaseRedo
                        For xxj As Integer = 1 To xRedoCount
                            Dim xByteLen As Integer = br.ReadInt32
                            Dim xByte() As Byte = br.ReadBytes(xByteLen)
                            xIteratorRedo.Next = UndoRedo.fromBytes(xByte)
                            xIteratorRedo = xIteratorRedo.Next
                        Next
                        sRedo(xI) = xBaseRedo.Next
                    Next

            End Select
        Loop

EndOfSub:
        br.Close()

        'Dim xStrLine() As String = Split(xStrAll, vbCrLf)
        'Dim xStrVersion() As String = Split(xStrLine(0), " ")
        'If xStrVersion.Length <> 4 Then Return
        'If UCase(xStrVersion(0)) <> "IBMSC" Then Return

        'For Each sLine As String In xStrLine
        '    Dim sW() As String = Split(sLine, " ")
        '
        '    Select Case UCase(sW(0))
        '        Case "NOTE"
        '            If Val(xStrVersion(1) & xStrVersion(2)) <= 23 Then GoTo 1200
        '
        '            If Not UBound(sW) = 6 Then Exit Select
        '            ReDim Preserve K(UBound(K) + 1)
        '            With K(UBound(K))
        '                .VPosition = Val(sW(1))
        '                .ColumnIndex = Val(sW(2))
        '                .Value = Val(sW(3))
        '                .LongNote = (Val(sW(4)) \ 4) Mod 2
        '                .Hidden = (Val(sW(4)) \ 2) Mod 2
        '                .Selected = (Val(sW(4)) \ 1) Mod 2
        '                .PairWithI = Val(sW(5))
        '                .Length = Val(sW(6))
        '            End With
        '            Exit Select
        '
        '1200:               If Not UBound(sW) = 5 Then Exit Select
        '            ReDim Preserve K(UBound(K) + 1)
        '            With K(UBound(K))
        '                .VPosition = Val(sW(1))
        '                .ColumnIndex = Val(sW(2))
        '                .Value = Val(sW(3))
        '                .LongNote = (Val(sW(4)) \ 4) Mod 2
        '                .Hidden = (Val(sW(4)) \ 2) Mod 2
        '                .Selected = (Val(sW(4)) \ 1) Mod 2
        '                .PairWithI = Val(sW(5))
        '                .Length = Val(sW(5))
        '            End With
        '
        '        Case "WAV"
        '            If UBound(sW) < 2 Then Exit Select
        '            hWAV(Val(sW(1))) = Mid(sLine, 6 + Len(sW(1)))
        '
        '        Case "UNDO"
        '            If UBound(sW) < 2 Then Exit Select
        '            sUndo(Val(sW(1))) = Replace(Mid(sLine, 7 + Len(sW(1))), " ", vbCrLf)
        '
        '        Case "REDO"
        '            If UBound(sW) < 2 Then Exit Select
        '            sRedo(Val(sW(1))) = Replace(Mid(sLine, 7 + Len(sW(1))), " ", vbCrLf)
        '
        '        Case ""
        '
        '        Case "NT"
        '            NTInput = Val(Mid(sLine, 4))
        '            TBNTInput.Checked = NTInput
        '            mnNTInput.Checked = NTInput
        '            POBLong.Enabled = Not NTInput
        '            POBLongShort.Enabled = Not NTInput
        '            bAdjustLength = False
        '            bAdjustUpper = False
        '
        '        Case "GENRE" : THGenre.Text = Mid(sLine, 7)
        '        Case "TITLE" : THTitle.Text = Mid(sLine, 7)
        '        Case "ARTIST" : THArtist.Text = Mid(sLine, 8)
        '        Case "LEVEL" : THPlayLevel.Text = Mid(sLine, 7)
        '        Case "BPM" : K(0).Value = Val(Mid(sLine, 5))
        '
        '        Case "COLUMN"
        '            Dim iW As Integer = Val(sW(1))
        '            If Val(xStrVersion(1) & xStrVersion(2)) <= 23 Then GoTo column_2_4
        '
        '            'TODO: clear CGP2
        '            'Rewrite ibmsc
        '            If Not UBound(sW) = 2 Then Exit Select
        '            CGBLP.Checked = iW And 8
        '            CGSTOP.Checked = iW And 4
        '            'CGA8.Checked = (Val(sW(1)) \ 2) Mod 2
        '            'CGP2.Checked = (Val(sW(1)) \ 1) Mod 2
        '            CGB.Value = Val(sW(2))
        '
        'column_2_4:         If Not UBound(sW) = 2 Then Exit Select
        '            CGBLP.Checked = iW And 8
        '            CGSTOP.Checked = iW And 4
        '            CGB.Value = Val(sW(2))
        '
        '        Case "GRID"
        '            If Not UBound(sW) = 6 Then Exit Select
        '            If Val(xStrVersion(1) & xStrVersion(2)) <= 23 Then Exit Select
        '            CGDivide.Value = Val(sW(1))
        '            CGSub.Value = Val(sW(2))
        '            CGHeight.Value = Val(sW(3))
        '            CGWidth.Value = Val(sW(4))
        '            gWheel = Val(sW(5))
        '            CGSnap.Checked = (Val(sW(6)) \ 128) Mod 2
        '            CGShow.Checked = (Val(sW(6)) \ 64) Mod 2
        '            CGShowS.Checked = (Val(sW(6)) \ 32) Mod 2
        '            CGShowBG.Checked = (Val(sW(6)) \ 16) Mod 2
        '            CGShowM.Checked = (Val(sW(6)) \ 8) Mod 2
        '            CGShowV.Checked = (Val(sW(6)) \ 4) Mod 2
        '            CGShowMB.Checked = (Val(sW(6)) \ 2) Mod 2
        '            CGShowC.Checked = (Val(sW(6)) \ 1) Mod 2
        '
        '        Case "TBOPTIONS"
        '            If Not UBound(sW) = 1 Then Exit Select
        '            ErrorCheck = (Val(sW(1)) \ 4) Mod 2 : TBErrorCheck.Checked = ErrorCheck : TBErrorCheck_Click(TBErrorCheck, New System.EventArgs)
        '            PreviewOnClick = (Val(sW(1)) \ 2) Mod 2 : TBPreviewOnClick.Checked = PreviewOnClick : TBPreviewOnClick_Click(TBPreviewOnClick, New System.EventArgs)
        '            ShowFileName = (Val(sW(1)) \ 1) Mod 2 : TBShowFileName.Checked = ShowFileName : TBShowFileName_Click(TBShowFileName, New System.EventArgs)
        '
        '        Case "URVAL"
        '            If UBound(sW) <> 1 Then Exit Select
        '            sI = Val(sW(1))
        '
        '    End Select
        '
        'Next
        '
        'TBUndo.Enabled = Not (sUndo(sI) = "NO")
        'TBRedo.Enabled = Not (sRedo(sIA) = "NO")

        TBUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        TBRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation
        mnUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        mnRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation

        LWAV.Visible = False
        LWAV.Items.Clear()
        For xI1 As Integer = 1 To 1295
            LWAV.Items.Add(C10to36(xI1) & ": " & hWAV(xI1))
        Next
        LWAV.SelectedIndex = 0
        LWAV.Visible = True

        THBPM.Value = K(0).Value / 10000
        SortByVPositionQuick(0, UBound(K))
        UpdatePairing()
        UpdateMeasureBottom()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub SaveiBMSC(ByVal Path As String)
        CalculateGreatestVPosition()
        SortByVPositionInsertion()
        UpdatePairing()

        Try

            Dim bw As New BinaryWriter(New IO.FileStream(Path, FileMode.Create), System.Text.Encoding.Unicode)

            'bw.Write("iBMSC".ToCharArray)
            bw.Write(&H534D4269)
            bw.Write(CByte(&H43))
            bw.Write(CByte(My.Application.Info.Version.Major))
            bw.Write(CByte(My.Application.Info.Version.Minor))
            bw.Write(CByte(My.Application.Info.Version.Build))

            'Preferences
            'bw.Write("Pref".ToCharArray)
            bw.Write(&H66657250)
            Dim xPref As Integer = 0
            If NTInput Then xPref = xPref Or &H1
            If ErrorCheck Then xPref = xPref Or &H2
            If PreviewOnClick Then xPref = xPref Or &H4
            If ShowFileName Then xPref = xPref Or &H8
            If mnSMenu.Checked Then xPref = xPref Or &H100
            If mnSTB.Checked Then xPref = xPref Or &H200
            If mnSOP.Checked Then xPref = xPref Or &H400
            If mnSStatus.Checked Then xPref = xPref Or &H800
            If mnSLSplitter.Checked Then xPref = xPref Or &H1000
            If mnSRSplitter.Checked Then xPref = xPref Or &H2000
            If gShow Then xPref = xPref Or &H4000
            If gShowS Then xPref = xPref Or &H8000
            If gShowBG Then xPref = xPref Or &H10000
            If gShowM Then xPref = xPref Or &H20000
            If gShowMB Then xPref = xPref Or &H40000
            If gShowV Then xPref = xPref Or &H80000
            If gShowC Then xPref = xPref Or &H100000
            If gBLP Then xPref = xPref Or &H200000
            If gSTOP Then xPref = xPref Or &H400000
            If gBPM Then xPref = xPref Or &H800000
            If gSnap Then xPref = xPref Or &H1000000
            If DisableVerticalMove Then xPref = xPref Or &H2000000
            If spLock(0) Then xPref = xPref Or &H4000000
            If spLock(1) Then xPref = xPref Or &H8000000
            If spLock(2) Then xPref = xPref Or &H10000000
            bw.Write(xPref)
            bw.Write(BitConverter.GetBytes(gDivide))
            bw.Write(BitConverter.GetBytes(gSub))
            bw.Write(BitConverter.GetBytes(gSlash))
            bw.Write(BitConverter.GetBytes(gxHeight))
            bw.Write(BitConverter.GetBytes(gxWidth))
            bw.Write(BitConverter.GetBytes(gCol))

            'Header
            'bw.Write("Head".ToCharArray)
            bw.Write(&H64616548)
            bw.Write(THTitle.Text)
            bw.Write(THArtist.Text)
            bw.Write(THGenre.Text)
            bw.Write(K(0).Value)
            Dim xPlayer As Integer = CHPlayer.SelectedIndex
            Dim xRank As Integer = CHRank.SelectedIndex << 4
            bw.Write(CByte(xPlayer Or xRank))
            bw.Write(THPlayLevel.Text)

            bw.Write(THSubTitle.Text)
            bw.Write(THSubArtist.Text)
            'bw.Write(THMaker.Text)
            bw.Write(THStageFile.Text)
            bw.Write(THBanner.Text)
            bw.Write(THBackBMP.Text)
            'bw.Write(THMidiFile.Text)
            bw.Write(CByte(CHDifficulty.SelectedIndex))
            bw.Write(THExRank.Text)
            bw.Write(THTotal.Text)
            'bw.Write(THVolWAV.Text)
            bw.Write(THComment.Text)
            'bw.Write(THLnType.Text)
            bw.Write(CShort(CHLnObj.SelectedIndex))

            'Wav List
            'bw.Write(("WAV" & vbNullChar).ToCharArray)
            bw.Write(&H564157)

            Dim xWAVOptions As Integer = 0
            If WAVMultiSelect Then xWAVOptions = xWAVOptions Or &H1
            If WAVChangeLabel Then xWAVOptions = xWAVOptions Or &H2
            bw.Write(CByte(xWAVOptions))

            Dim xWAVCount As Integer = 0
            For i As Integer = 1 To UBound(hWAV)
                If hWAV(i) <> "" Then xWAVCount += 1
            Next
            bw.Write(xWAVCount)

            For i As Integer = 1 To UBound(hWAV)
                If hWAV(i) = "" Then Continue For
                bw.Write(CShort(i))
                bw.Write(hWAV(i))
            Next

            'Beat
            'bw.Write("Beat".ToCharArray)
            bw.Write(&H74616542)
            'Dim xNumerator As Short = nBeatN.Value
            'Dim xDenominator As Short = nBeatD.Value
            'Dim xBeatChangeMode As Byte = BeatChangeMode
            bw.Write(CShort(nBeatN.Value))
            bw.Write(CShort(nBeatD.Value))
            bw.Write(CByte(BeatChangeMode))

            Dim xBeatCount As Integer = 0
            For i As Integer = 0 To UBound(MeasureLength)
                If MeasureLength(i) <> 192.0R Then xBeatCount += 1
            Next
            bw.Write(xBeatCount)

            For i As Integer = 0 To UBound(MeasureLength)
                If MeasureLength(i) = 192.0R Then Continue For
                bw.Write(CShort(i))
                bw.Write(MeasureLength(i))
            Next

            'Expansion Code
            'bw.Write("Expn".ToCharArray)
            bw.Write(&H6E707845)
            bw.Write(TExpansion.Text)

            'Note
            'bw.Write("Note".ToCharArray)
            bw.Write(&H65746F4E)
            bw.Write(UBound(K))
            For i As Integer = 1 To UBound(K)
                Dim xFormat As Integer = 0
                If K(i).LongNote Then xFormat = xFormat Or &H1
                If K(i).Hidden Then xFormat = xFormat Or &H2
                If K(i).Selected Then xFormat = xFormat Or &H4

                bw.Write(K(i).VPosition)
                bw.Write(K(i).ColumnIndex)
                bw.Write(K(i).Value)
                bw.Write(CByte(xFormat))
                bw.Write(K(i).Length)
            Next

            'Undo / Redo Commands
            'bw.Write("Undo".ToCharArray)
            bw.Write(&H6F646E55)
            bw.Write(100)
            bw.Write(sI)

            For i As Integer = 0 To 99
                'UndoCommandsCount
                Dim countUndo As Integer = 0
                Dim pUndo As UndoRedo.LinkedURCmd = sUndo(i)
                While pUndo IsNot Nothing
                    countUndo += 1
                    pUndo = pUndo.Next
                End While
                bw.Write(countUndo)

                'UndoCommands
                pUndo = sUndo(i)
                For xxi As Integer = 1 To countUndo
                    Dim bUndo() As Byte = pUndo.toBytes
                    bw.Write(bUndo.Length)  'Length
                    bw.Write(bUndo)         'Command
                    pUndo = pUndo.Next
                Next

                'RedoCommandsCount
                Dim countRedo As Integer = 0
                Dim pRedo As UndoRedo.LinkedURCmd = sRedo(i)
                While pRedo IsNot Nothing
                    countRedo += 1
                    pRedo = pRedo.Next
                End While
                bw.Write(countRedo)

                'RedoCommands
                pRedo = sRedo(i)
                For xxi As Integer = 1 To countRedo
                    Dim bRedo() As Byte = pRedo.toBytes
                    bw.Write(bRedo.Length)
                    bw.Write(bRedo)
                    pRedo = pRedo.Next
                Next
            Next

            bw.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        'Dim xI1 As Integer
        'Dim xStr As String
        'Dim xStrAll As String = ""
        '
        'Dim xNTInput As Boolean = NTInput
        '
        'Dim xColumn As Integer = IIf(CGBLP.Checked, 8, 0) + IIf(CGSTOP.Checked, 4, 0) + 2 + 1 'IIf(CGP2.Checked, 1, 0)
        'Dim xGrid As Integer = IIf(gSnap, 128, 0) + IIf(gShow, 64, 0) + IIf(gShowS, 32, 0) + IIf(gShowBG, 16, 0) + _
        '                       IIf(gShowM, 8, 0) + IIf(gShowV, 4, 0) + IIf(gShowMB, 2, 0) + IIf(gShowC, 1, 0)
        'Dim xOptions As Integer = IIf(ErrorCheck, 4, 0) + IIf(PreviewOnClick, 2, 0) + IIf(ShowFileName, 1, 0)
        '
        ''TODO: Measure lengths, show/hide controls
        ''Header
        'xStrAll = "iBMSC " & My.Application.Info.Version.Major & " " & My.Application.Info.Version.Minor & " " & My.Application.Info.Version.Build & vbCrLf & _
        '          "NT " & CInt(NTInput) & vbCrLf & _
        '          "Genre " & THGenre.Text & vbCrLf & _
        '          "Title " & THTitle.Text & vbCrLf & _
        '          "Artist " & THArtist.Text & vbCrLf & _
        '          "Level " & THPlayLevel.Text & vbCrLf & _
        '          "BPM " & K(0).Value & vbCrLf & _
        '          "Column " & xColumn & " " & CGB.Value & vbCrLf & _
        '          "Grid " & gDivide & " " & gSub & " " & gxHeight & " " & gxWidth & " " & gWheel & " " & xGrid & vbCrLf & _
        '          "TBOptions " & xOptions & vbCrLf
        '
        ''WAV
        'xStr = ""
        'For xI1 = 1 To UBound(hWAV)
        '    If Not hWAV(xI1) = "" Then xStr &= "WAV " & xI1 & " " & hWAV(xI1) & vbCrLf
        'Next
        'xStrAll &= xStr & vbCrLf
        '
        ''Note
        'xStr = ""
        'For xI1 = 1 To UBound(K)
        '    xStr &= "Note " & K(xI1).VPosition & _
        '                " " & K(xI1).ColumnIndex & _
        '                " " & K(xI1).Value & _
        '                " " & (IIf(K(xI1).LongNote, 4, 0) + IIf(K(xI1).Hidden, 2, 0) + IIf(K(xI1).Selected, 1, 0)) & _
        '                " " & K(xI1).PairWithI & _
        '                " " & K(xI1).Length & vbCrLf
        'Next
        'xStrAll &= xStr & vbCrLf
        '
        ''Undo / Redo
        'xStr = ""
        'For xI1 = 0 To UBound(sUndo)
        '    If Not sUndo(xI1) = "" Then xStr &= "Undo " & xI1 & " " & Replace(sUndo(xI1), vbCrLf, " ") & vbCrLf
        '    If Not sRedo(xI1) = "" Then xStr &= "Redo " & xI1 & " " & Replace(sRedo(xI1), vbCrLf, " ") & vbCrLf
        'Next
        'xStrAll &= "URVal " & sI & vbCrLf & _
        '           xStr & vbCrLf
        '
        'Return xStrAll
    End Sub

    ''' <summary>
    ''' True if pressed cancel. False elsewise.
    ''' </summary>
    ''' <returns>True if pressed cancel. False elsewise.</returns>

    Private Function ClosingPopSave() As Boolean
        If Not IsSaved Then
            Dim xResult As MsgBoxResult = MsgBox(Locale.Messages.SaveOnExit, MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, Me.Text)

            If xResult = MsgBoxResult.Yes Then
                If ExcludeFileName(FileName) = "" Then
                    Dim xDSave As New SaveFileDialog
                    xDSave.Filter = Locale.FileType._bms & "|*.bms;*.bme;*.bml;*.pms;*.txt|" & _
                                    Locale.FileType.BMS & "|*.bms|" & _
                                    Locale.FileType.BME & "|*.bme|" & _
                                    Locale.FileType.BML & "|*.bml|" & _
                                    Locale.FileType.PMS & "|*.pms|" & _
                                    Locale.FileType.TXT & "|*.txt|" & _
                                    Locale.FileType._all & "|*.*"
                    xDSave.DefaultExt = "bms"
                    xDSave.InitialDirectory = InitPath

                    If xDSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return True
                    SetFileName(xDSave.FileName)
                End If
                Dim xStrAll As String = SaveBMS()
                My.Computer.FileSystem.WriteAllText(FileName, xStrAll, False, TextEncoding)
                NewRecent(FileName)
                If BeepWhileSaved Then Beep()
            End If

            If xResult = MsgBoxResult.Cancel Then Return True
        End If
        Return False
    End Function

    Private Sub TBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNew.Click, mnNew.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If ClosingPopSave() Then Exit Sub

        ClearUndo()
        InitializeNewBMS()

        ReDim K(0)
        ReDim mColumn(999)
        ReDim hWAV(1295)
        ReDim hBPM(1295)    'x10000
        ReDim hSTOP(1295)
        THGenre.Text = ""
        THTitle.Text = ""
        THArtist.Text = ""
        THPlayLevel.Text = ""

        With K(0)
            .ColumnIndex = niBPM
            .VPosition = -1
            '.LongNote = False
            '.Selected = False
            .Value = 1200000
        End With
        THBPM.Value = 120

        LWAV.Items.Clear()
        Dim xI1 As Integer
        For xI1 = 1 To 1295
            LWAV.Items.Add(C10to36(xI1) & ": " & hWAV(xI1))
        Next
        LWAV.SelectedIndex = 0

        SetFileName("Untitled.bms")
        SetIsSaved(True)
        'pIsSaved.Visible = Not IsSaved

        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub TBNewC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles TBNewC.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If ClosingPopSave() Then Exit Sub

        ClearUndo()

        ReDim K(0)
        ReDim mColumn(999)
        ReDim hWAV(1295)
        ReDim hBPM(1295)    'x10000
        ReDim hSTOP(1295)
        THGenre.Text = ""
        THTitle.Text = ""
        THArtist.Text = ""
        THPlayLevel.Text = ""

        With K(0)
            .ColumnIndex = niBPM
            .VPosition = -1
            '.LongNote = False
            '.Selected = False
            .Value = 1200000
        End With
        THBPM.Value = 120

        SetFileName("Untitled.bms")
        SetIsSaved(True)
        'pIsSaved.Visible = Not IsSaved

        If MsgBox("Please copy your code to clipboard and click OK.", MsgBoxStyle.OkCancel, "Create from code") = MsgBoxResult.Cancel Then Exit Sub
        OpenBMS(Clipboard.GetText)
    End Sub

    Private Sub TBOpen_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpen.ButtonClick, mnOpen.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If ClosingPopSave() Then Exit Sub

        Dim xDOpen As New OpenFileDialog
        xDOpen.Filter = Locale.FileType._bms & "|*.bms;*.bme;*.bml;*.pms;*.txt"
        xDOpen.DefaultExt = "bms"
        xDOpen.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDOpen.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDOpen.FileName)
        OpenBMS(My.Computer.FileSystem.ReadAllText(xDOpen.FileName, TextEncoding))
        ClearUndo()
        SetFileName(xDOpen.FileName)
        NewRecent(FileName)
        SetIsSaved(True)
        'pIsSaved.Visible = Not IsSaved
    End Sub

    Private Sub TBImportIBMSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBImportIBMSC.Click, mnImportIBMSC.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If ClosingPopSave() Then Return

        Dim xDOpen As New OpenFileDialog
        xDOpen.Filter = Locale.FileType.IBMSC & "|*.ibmsc"
        xDOpen.DefaultExt = "ibmsc"
        xDOpen.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDOpen.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return
        InitPath = ExcludeFileName(xDOpen.FileName)
        SetFileName("Imported_" & GetFileName(xDOpen.FileName))
        OpeniBMSC(xDOpen.FileName)
        NewRecent(xDOpen.FileName)
        SetIsSaved(False)
        'pIsSaved.Visible = Not IsSaved
    End Sub

    Private Sub TBImportSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBImportSM.Click, mnImportSM.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If ClosingPopSave() Then Exit Sub

        Dim xDOpen As New OpenFileDialog
        xDOpen.Filter = Locale.FileType.SM & "|*.sm"
        xDOpen.DefaultExt = "sm"
        xDOpen.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDOpen.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If OpenSM(My.Computer.FileSystem.ReadAllText(xDOpen.FileName, TextEncoding)) Then Exit Sub
        InitPath = ExcludeFileName(xDOpen.FileName)
        SetFileName("Untitled.bms")
        ClearUndo()
        SetIsSaved(False)
        'pIsSaved.Visible = Not IsSaved
    End Sub

    Private Sub TBSave_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSave.ButtonClick, mnSave.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1

        If ExcludeFileName(FileName) = "" Then
            Dim xDSave As New SaveFileDialog
            xDSave.Filter = Locale.FileType._bms & "|*.bms;*.bme;*.bml;*.pms;*.txt|" & _
                            Locale.FileType.BMS & "|*.bms|" & _
                            Locale.FileType.BME & "|*.bme|" & _
                            Locale.FileType.BML & "|*.bml|" & _
                            Locale.FileType.PMS & "|*.pms|" & _
                            Locale.FileType.TXT & "|*.txt|" & _
                            Locale.FileType._all & "|*.*"
            xDSave.DefaultExt = "bms"
            xDSave.InitialDirectory = InitPath

            If xDSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            InitPath = ExcludeFileName(xDSave.FileName)
            SetFileName(xDSave.FileName)
        End If
        Dim xStrAll As String = SaveBMS()
        My.Computer.FileSystem.WriteAllText(FileName, xStrAll, False, TextEncoding)
        NewRecent(FileName)
        SetFileName(FileName)
        SetIsSaved(True)
        'pIsSaved.Visible = Not IsSaved
        If BeepWhileSaved Then Beep()
    End Sub

    Private Sub TBSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSaveAs.Click, mnSaveAs.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1

        Dim xDSave As New SaveFileDialog
        xDSave.Filter = Locale.FileType._bms & "|*.bms;*.bme;*.bml;*.pms;*.txt|" & _
                        Locale.FileType.BMS & "|*.bms|" & _
                        Locale.FileType.BME & "|*.bme|" & _
                        Locale.FileType.BML & "|*.bml|" & _
                        Locale.FileType.PMS & "|*.pms|" & _
                        Locale.FileType.TXT & "|*.txt|" & _
                        Locale.FileType._all & "|*.*"
        xDSave.DefaultExt = "bms"
        xDSave.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDSave.FileName)
        SetFileName(xDSave.FileName)
        Dim xStrAll As String = SaveBMS()
        My.Computer.FileSystem.WriteAllText(FileName, xStrAll, False, TextEncoding)
        NewRecent(FileName)
        SetFileName(FileName)
        SetIsSaved(True)
        'pIsSaved.Visible = Not IsSaved
        If BeepWhileSaved Then Beep()
    End Sub

    Private Sub TBExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBExport.Click, mnExport.Click
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1

        Dim xDSave As New SaveFileDialog
        xDSave.Filter = Locale.FileType.IBMSC & "|*.ibmsc"
        xDSave.DefaultExt = "ibmsc"
        xDSave.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))
        If xDSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        SaveiBMSC(xDSave.FileName)
        'My.Computer.FileSystem.WriteAllText(xDSave.FileName, xStrAll, False, TextEncoding)
        NewRecent(FileName)
        If BeepWhileSaved Then Beep()
    End Sub

    Private Sub PMainInPreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles PMainIn.PreviewKeyDown, PMainInL.PreviewKeyDown, PMainInR.PreviewKeyDown
        If e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ControlKey Then
            RefreshPanelAll()
            POStatusRefresh()
            Exit Sub
        End If

        If e.KeyCode = 18 Then Exit Sub

        Dim iI As Integer = sender.Tag
        Dim xI1 As Integer
        Dim xTargetColumn As Integer = -1
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
        ReDim uNotes(-1)

        Select Case e.KeyCode
            Case Keys.Up
                Dim xVPosition As Double = 192 / gDivide
                If My.Computer.Keyboard.CtrlKeyDown Then xVPosition = 1

                'Ks cannot be beyond the upper boundary
                Dim muVPosition As Double = VPosition1000() - 1
                For xI1 = 1 To UBound(K)
                    If K(xI1).Selected Then
                        'K(xI1).VPosition = Math.Floor(K(xI1).VPosition / (192 / gDivide)) * 192 / gDivide
                        muVPosition = IIf(K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + xVPosition > muVPosition, _
                                                          K(xI1).VPosition + IIf(NTInput, K(xI1).Length, 0) + xVPosition, _
                                                          muVPosition)
                    End If
                Next
                muVPosition -= 191999

                'xRedo = sCmdKMs(0, xVPosition - muVPosition, True)
                Dim xVPos As Double
                For xI1 = 1 To UBound(K)
                    If Not K(xI1).Selected Then Continue For

                    xVPos = K(xI1).VPosition + xVPosition - muVPosition
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, xVPos, True, xUndo, xRedo)
                    K(xI1).VPosition = xVPos
                Next
                'xUndo = sCmdKMs(0, -xVPosition + muVPosition, True)

                If xVPosition - muVPosition <> 0 Then AddUndo(xUndo, xBaseRedo.Next)
                SortByVPositionInsertion()
                UpdatePairing()
                CalculateTotalNotes()
                CalculateGreatestVPosition()
                RefreshPanelAll()

            Case Keys.Down
                Dim xVPosition As Double = -192 / gDivide
                If My.Computer.Keyboard.CtrlKeyDown Then xVPosition = -1

                'Ks cannot be beyond the lower boundary
                Dim mVPosition As Double = 0
                For xI1 = 1 To UBound(K)
                    If K(xI1).Selected Then
                        'K(xI1).VPosition = Math.Ceiling(K(xI1).VPosition / (192 / gDivide)) * 192 / gDivide
                        mVPosition = IIf(K(xI1).VPosition + xVPosition < mVPosition, _
                                                                 K(xI1).VPosition + xVPosition, _
                                                                 mVPosition)
                    End If
                Next

                'xRedo = sCmdKMs(0, xVPosition - mVPosition, True)
                Dim xVPos As Double
                For xI1 = 1 To UBound(K)
                    If Not K(xI1).Selected Then Continue For

                    xVPos = K(xI1).VPosition + xVPosition - mVPosition
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, xVPos, True, xUndo, xRedo)
                    K(xI1).VPosition = xVPos
                Next
                'xUndo = sCmdKMs(0, -xVPosition + mVPosition, True)

                If xVPosition - mVPosition <> 0 Then AddUndo(xUndo, xBaseRedo.Next)
                SortByVPositionInsertion()
                UpdatePairing()
                CalculateTotalNotes()
                CalculateGreatestVPosition()
                RefreshPanelAll()

            Case Keys.Left
                'For xI1 = 1 To UBound(K)
                '    If K(xI1).Selected Then K(xI1).ColumnIndex = RealColumnToEnabled(K(xI1).ColumnIndex) - 1
                'Next

                'Ks cannot be beyond the left boundary
                Dim mLeft As Integer = 0
                For xI1 = 1 To UBound(K)
                    If K(xI1).Selected Then mLeft = IIf(RealColumnToEnabled(K(xI1).ColumnIndex) - 1 < mLeft, _
                                                        RealColumnToEnabled(K(xI1).ColumnIndex) - 1, _
                                                        mLeft)
                Next
                'xRedo = sCmdKMs(-1 - mLeft, 0, True)
                Dim xCol As Integer
                For xI1 = 1 To UBound(K)
                    If Not K(xI1).Selected Then Continue For

                    xCol = EnabledColumnToReal(RealColumnToEnabled(K(xI1).ColumnIndex) - 1 - mLeft)
                    Me.RedoMoveNote(K(xI1), xCol, K(xI1).VPosition, True, xUndo, xRedo)
                    K(xI1).ColumnIndex = xCol
                Next
                'xUndo = sCmdKMs(1 + mLeft, 0, True)

                If -1 - mLeft <> 0 Then AddUndo(xUndo, xBaseRedo.Next)
                UpdatePairing()
                CalculateTotalNotes()
                RefreshPanelAll()

            Case Keys.Right
                'xRedo = sCmdKMs(1, 0, True)
                Dim xCol As Integer
                For xI1 = 1 To UBound(K)
                    If Not K(xI1).Selected Then Continue For

                    xCol = EnabledColumnToReal(RealColumnToEnabled(K(xI1).ColumnIndex) + 1)
                    Me.RedoMoveNote(K(xI1), xCol, K(xI1).VPosition, True, xUndo, xRedo)
                    K(xI1).ColumnIndex = xCol
                Next
                'xUndo = sCmdKMs(-1, 0, True)

                AddUndo(xUndo, xBaseRedo.Next)
                UpdatePairing()
                CalculateTotalNotes()
                RefreshPanelAll()

            Case Keys.Delete
                mnDelete_Click(mnDelete, New System.EventArgs)

            Case Keys.Home
                If spFocus = 0 Then VSL.Value = 0
                If spFocus = 1 Then VS.Value = 0
                If spFocus = 2 Then VSR.Value = 0

            Case Keys.End
                If spFocus = 0 Then VSL.Value = VSL.Minimum
                If spFocus = 1 Then VS.Value = VS.Minimum
                If spFocus = 2 Then VSR.Value = VSR.Minimum

            Case Keys.PageUp
                If spFocus = 0 Then VSL.Value = IIf(VSL.Value - gPgUpDn > VSL.Minimum, VSL.Value - gPgUpDn, VSL.Minimum)
                If spFocus = 1 Then VS.Value = IIf(VS.Value - gPgUpDn > VS.Minimum, VS.Value - gPgUpDn, VS.Minimum)
                If spFocus = 2 Then VSR.Value = IIf(VSR.Value - gPgUpDn > VSR.Minimum, VSR.Value - gPgUpDn, VSR.Minimum)

            Case Keys.PageDown
                If spFocus = 0 Then VSL.Value = IIf(VSL.Value + gPgUpDn < 0, VSL.Value + gPgUpDn, 0)
                If spFocus = 1 Then VS.Value = IIf(VS.Value + gPgUpDn < 0, VS.Value + gPgUpDn, 0)
                If spFocus = 2 Then VSR.Value = IIf(VSR.Value + gPgUpDn < 0, VSR.Value + gPgUpDn, 0)

            Case Keys.Oemcomma
                If gDivide * 2 <= CGDivide.Maximum Then CGDivide.Value = gDivide * 2

            Case Keys.OemPeriod
                If gDivide \ 2 >= CGDivide.Minimum Then CGDivide.Value = gDivide \ 2

            Case Keys.OemQuestion
                'Dim xTempSwap As Integer = gSlash
                'gSlash = CGDivide.Value
                'CGDivide.Value = xTempSwap
                CGDivide.Value = gSlash

            Case Keys.Oemplus
                With CGHeight
                    .Value += IIf(.Value > .Maximum - .Increment, .Maximum - .Value, .Increment)
                End With

            Case Keys.OemMinus
                With CGHeight
                    .Value -= IIf(.Value < .Minimum + .Increment, .Value - .Minimum, .Increment)
                End With

            Case Keys.Add
                If LWAV.SelectedIndex = -1 Then
                    LWAV.SelectedIndex = 0
                Else
                    Dim newIndex As Integer = LWAV.SelectedIndex + 1
                    If newIndex > LWAV.Items.Count - 1 Then newIndex = LWAV.Items.Count - 1
                    LWAV.SelectedIndices.Clear()
                    LWAV.SelectedIndex = newIndex
                    validate_LWAV_view()
                End If

            Case Keys.Subtract
                If LWAV.SelectedIndex = -1 Then
                    LWAV.SelectedIndex = 0
                Else
                    Dim newIndex As Integer = LWAV.SelectedIndex - 1
                    If newIndex < 0 Then newIndex = 0
                    LWAV.SelectedIndices.Clear()
                    LWAV.SelectedIndex = newIndex
                End If

            Case Keys.G
                CGSnap.Checked = Not gSnap

            Case Keys.L
                If Not My.Computer.Keyboard.CtrlKeyDown Then POBLong_Click(Nothing, Nothing)

            Case Keys.S
                If Not My.Computer.Keyboard.CtrlKeyDown Then POBNormal_Click(Nothing, Nothing)

            Case Keys.D
                CGDisableVertical.Checked = Not CGDisableVertical.Checked

            Case Keys.NumPad0, Keys.D0
                For xI2 As Integer = 1 To UBound(K)
                    If Not K(xI2).Selected Then Continue For

                    With K(xI2)
                        Dim xxCol As Integer = niB

                        'TODO: optimize the for loops below
                        If NTInput Then
                            For xI0 As Integer = 1 To UBound(K)
                                If K(xI0).ColumnIndex = xxCol AndAlso _
                                    K(xI0).VPosition <= K(xI2).VPosition + K(xI2).Length And K(xI0).VPosition + K(xI0).Length >= K(xI2).VPosition Then _
                                    xxCol += 1 : xI0 = 1
                                'If K(xI0).ColumnIndex = xxCol AndAlso _
                                'IIf(K(xI0).Length > 0, _
                                '    IIf(.Length = 0, _
                                '        K(xI0).VPosition <= K(xI2).VPosition And K(xI0).VPosition + K(xI0).Length >= K(xI2).VPosition, _
                                '        K(xI0).VPosition <= K(xI2).VPosition + K(xI2).Length And K(xI0).VPosition + K(xI0).Length >= K(xI2).VPosition), _
                                '    IIf(.Length = 0, _
                                '        K(xI0).VPosition = K(xI2).VPosition, _
                                '        K(xI2).VPosition <= K(xI0).VPosition And K(xI2).VPosition + K(xI2).Length >= K(xI0).VPosition)) Then _
                                'xxCol += 1 : xI0 = 1
                                'If K(xI0).VPosition > K(xI2).VPosition + IIf(K(xI2).Length > 0.0#, K(xI2).Length, 0.0#) Then Exit For
                            Next
                        Else
                            For xI0 As Integer = 1 To UBound(K)
                                If K(xI0).ColumnIndex = xxCol AndAlso K(xI0).VPosition = K(xI2).VPosition Then _
                                    xxCol += 1 : xI0 = 1
                                'If K(xI0).VPosition > K(xI2).VPosition Then Exit For
                            Next
                        End If

                        Me.RedoMoveNote(K(xI2), xxCol, .VPosition, True, xUndo, xRedo)
                        .ColumnIndex = xxCol
                    End With
                Next
                AddUndo(xUndo, xBaseRedo.Next)
                UpdatePairing()
                CalculateTotalNotes()
                RefreshPanelAll()

            Case Keys.Oem1, Keys.NumPad1, Keys.D1 : xTargetColumn = niA1 : GoTo MoveToColumn
            Case Keys.Oem2, Keys.NumPad2, Keys.D2 : xTargetColumn = niA2 : GoTo MoveToColumn
            Case Keys.Oem3, Keys.NumPad3, Keys.D3 : xTargetColumn = niA3 : GoTo MoveToColumn
            Case Keys.Oem4, Keys.NumPad4, Keys.D4 : xTargetColumn = niA4 : GoTo MoveToColumn
            Case Keys.Oem5, Keys.NumPad5, Keys.D5 : xTargetColumn = niA5 : GoTo MoveToColumn
            Case Keys.Oem6, Keys.NumPad6, Keys.D6 : xTargetColumn = niA6 : GoTo MoveToColumn
            Case Keys.Oem7, Keys.NumPad7, Keys.D7 : xTargetColumn = niA7 : GoTo MoveToColumn
            Case Keys.Oem8, Keys.NumPad8, Keys.D8 : xTargetColumn = niA8 : GoTo MoveToColumn

MoveToColumn:   If xTargetColumn = -1 Then Exit Select
                If Not nEnabled(xTargetColumn) Then Exit Select

                For xI2 As Integer = 1 To UBound(K)
                    If Not K(xI2).Selected Then Continue For

                    Me.RedoMoveNote(K(xI2), xTargetColumn, K(xI2).VPosition, True, xUndo, xRedo)
                    K(xI2).ColumnIndex = xTargetColumn
                Next
                AddUndo(xUndo, xBaseRedo.Next)
                UpdatePairing()
                CalculateTotalNotes()
                RefreshPanelAll()

        End Select

        If My.Computer.Keyboard.CtrlKeyDown And (Not My.Computer.Keyboard.AltKeyDown) And (Not My.Computer.Keyboard.ShiftKeyDown) Then
            Select Case e.KeyCode
                Case Keys.Z : TBUndo_Click(TBUndo, New EventArgs)
                Case Keys.Y : TBRedo_Click(TBRedo, New EventArgs)
                Case Keys.X : TBCut_Click(TBCut, New EventArgs)
                Case Keys.C : TBCopy_Click(TBCopy, New EventArgs)
                Case Keys.V : TBPaste_Click(TBPaste, New EventArgs)
                Case Keys.A : mnSelectAll_Click(mnSelectAll, New EventArgs)
                Case Keys.F : TBFind_Click(TBFind, New EventArgs)
                Case Keys.T : TBStatistics_Click(TBStatistics, New EventArgs)
            End Select
        End If

        PMainInMouseMove(sender)
        POStatusRefresh()
    End Sub

    Private Sub PMainInResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PMainIn.Resize, PMainInL.Resize, PMainInR.Resize
        If Not Me.Created Then Exit Sub

        Dim iI As Integer = sender.Tag
        spWidth(0) = PMainL.Width
        spWidth(1) = PMain.Width
        spWidth(2) = PMainR.Width

        Select Case iI
            Case 0
                VSL.LargeChange = sender.Height * 0.9
                VSL.Maximum = VSL.LargeChange - 1
                HSL.LargeChange = sender.Width / gxWidth
                If HSL.Value > HSL.Maximum - HSL.LargeChange + 1 Then HSL.Value = HSL.Maximum - HSL.LargeChange + 1
            Case 1
                VS.LargeChange = sender.Height * 0.9
                VS.Maximum = VS.LargeChange - 1
                HS.LargeChange = sender.Width / gxWidth
                If HS.Value > HS.Maximum - HS.LargeChange + 1 Then HS.Value = HS.Maximum - HS.LargeChange + 1
            Case 2
                VSR.LargeChange = sender.Height * 0.9
                VSR.Maximum = VSR.LargeChange - 1
                HSR.LargeChange = sender.Width / gxWidth
                If HSR.Value > HSR.Maximum - HSR.LargeChange + 1 Then HSR.Value = HSR.Maximum - HSR.LargeChange + 1
        End Select
        RefreshPanel(iI, sender.DisplayRectangle)
    End Sub

    Private Sub RefreshPanelAll()
        If IsInitializing Then Exit Sub
        RefreshPanel(0, PMainInL.DisplayRectangle)
        RefreshPanel(1, PMainIn.DisplayRectangle)
        RefreshPanel(2, PMainInR.DisplayRectangle)
    End Sub

    Private Sub RefreshPanel(ByVal xIndex As Integer, ByVal DisplayRect As Rectangle)
        If Me.WindowState = FormWindowState.Minimized Then Return
        If DisplayRect.Width <= 0 Or DisplayRect.Height <= 0 Then Return
        'If spMain.Count = 0 Then Return
        'Dim currentContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
        Dim e1 As BufferedGraphics = BufferedGraphicsManager.Current.Allocate(spMain(xIndex).CreateGraphics, DisplayRect)
        e1.Graphics.FillRectangle(vo.Bg, DisplayRect)

        Dim xTHeight As Integer = spMain(xIndex).Height
        Dim xTWidth As Integer = spMain(xIndex).Width
        Dim xHS As Integer = spH(xIndex)
        Dim xVS As Integer = spV(xIndex)
        Dim xVSR As Integer = -spV(xIndex)
        Dim xVSu As Integer = IIf(xVSR + xTHeight / gxHeight > VPosition1000(), VPosition1000(), xVSR + xTHeight / gxHeight)

        'e1.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim xI1 As Integer

        'Bg color
        If gShowBG Then
            For xI1 = 0 To gCol
                If nLeft(xI1 + 1) * gxWidth - xHS * gxWidth + 1 < 0 Then Continue For
                If nLeft(xI1) * gxWidth - xHS * gxWidth + 1 > xTWidth Then Exit For
                If Not nCol(xI1).cBG.GetBrightness = 0 And nLength(xI1) > 0 Then _
                    e1.Graphics.FillRectangle(New SolidBrush(nCol(xI1).cBG), nLeft(xI1) * gxWidth - xHS * gxWidth + 1, 0, nLength(xI1) * gxWidth, xTHeight)
            Next
        End If

        'Vertical line
        If gShowV Then
            For xI1 = 0 To gCol
                If nLeft(xI1) * gxWidth - xHS * gxWidth + 1 < 0 Then Continue For
                If nLeft(xI1) * gxWidth - xHS * gxWidth + 1 > xTWidth Then Exit For
                If nLength(xI1) > 0 Then e1.Graphics.DrawLine(vo.pVLine, nLeft(xI1) * gxWidth - xHS * gxWidth, 0, nLeft(xI1) * gxWidth - xHS * gxWidth, xTHeight)
            Next
        End If

        'Grid, Sub, Measure
        For xI1 = InMeasure(xVSR) To InMeasure(xVSu)
            Dim xI2 As Integer
            Dim xCurr As Double
            Dim xDiff As Double
            Dim xUpper As Double = MeasureBottom(xI1) + MeasureLength(xI1)

            'grid
            If Not gShow Then GoTo 2000
            xI2 = 0
            xCurr = MeasureBottom(xI1)
            xDiff = 192 / gDivide
            Do While xCurr < xUpper
                e1.Graphics.DrawLine(vo.pGrid, 0, VerticalPositiontoDisplay(xCurr, xVS, xTHeight), _
                                       xTWidth, VerticalPositiontoDisplay(xCurr, xVS, xTHeight))
                xI2 += 1
                xCurr = MeasureBottom(xI1) + xI2 * xDiff
            Loop

            'sub
2000:       If Not gShowS Then GoTo 2100
            xI2 = 0
            xCurr = MeasureBottom(xI1)
            xDiff = 192 / gSub
            Do While xCurr < xUpper
                e1.Graphics.DrawLine(vo.pSub, 0, VerticalPositiontoDisplay(xCurr, xVS, xTHeight), _
                                      xTWidth, VerticalPositiontoDisplay(xCurr, xVS, xTHeight))
                xI2 += 1
                xCurr = MeasureBottom(xI1) + xI2 * xDiff
            Loop

            'measure and measurebar
2100:       xCurr = MeasureBottom(xI1)
            If gShowMB Then e1.Graphics.DrawLine(vo.pMLine, 0, VerticalPositiontoDisplay(xCurr, xVS, xTHeight), _
                                                 xTWidth, VerticalPositiontoDisplay(xCurr, xVS, xTHeight))
            If gShowM Then e1.Graphics.DrawString("[" & Add3Zeros(xI1).ToString & "]", vo.kMFont, New SolidBrush(nCol(0).cText), -xHS * gxWidth, _
                                                  VerticalPositiontoDisplay(xCurr, xVS, xTHeight) - vo.kMFont.Height)
        Next
        'If gShow Then
        '    For xI1 = Math.Floor(xVSR / (192 / gDivide)) To Math.Ceiling(xVSu / (192 / gDivide))
        '        e1.Graphics.DrawLine(voGrid, 0, _
        '                xTHeight - CInt(192 / gDivide * xI1 * gxHeight) + xVSR * gxHeight - 1, xTWidth, _
        '                xTHeight - CInt(192 / gDivide * xI1 * gxHeight) + xVSR * gxHeight - 1)
        '    Next
        'End If
        'If gShowS Then
        '    For xI1 = Math.Floor(xVSR / (192 / gSub)) To Math.Ceiling(xVSu / (192 / gSub))
        '        e1.Graphics.DrawLine(voSub, 0, _
        '                xTHeight - CInt(192 / gSub * xI1 * gxHeight) + xVSR * gxHeight - 1, xTWidth, _
        '                xTHeight - CInt(192 / gSub * xI1 * gxHeight) + xVSR * gxHeight - 1)
        '    Next
        'End If
        'For xI1 = (xVSR) \ 192 To xVSu \ 192
        '    If gShowMB Then e1.Graphics.DrawLine(voMLine, 0, _
        '            xTHeight - 192 * xI1 * gxHeight + xVSR * gxHeight - 1, xTWidth, _
        '            xTHeight - 192 * xI1 * gxHeight + xVSR * gxHeight - 1)
        '    If gShowM Then e1.Graphics.DrawString("[" & Add3Zeros(xI1).ToString & "]", vKMFont, New SolidBrush(nForeColor(0)), -xHS * gxWidth, _
        '            xTHeight - 192 * xI1 * gxHeight + xVSR * gxHeight - vKMFont.Height)
        'Next

        'Column Caption
        If gShowC Then
            For xI1 = 0 To gCol
                If nLeft(xI1 + 1) * gxWidth - xHS * gxWidth + 1 < 0 Then Continue For
                If nLeft(xI1) * gxWidth - xHS * gxWidth + 1 > xTWidth Then Exit For
                If nLength(xI1) > 0 Then e1.Graphics.DrawString(nTitle(xI1), vo.ColumnTitleFont, vo.ColumnTitle, nLeft(xI1) * gxWidth - xHS * gxWidth, 0)
            Next
        End If

        'WaveForm
        If wWavL IsNot Nothing And wWavR IsNot Nothing And wPrecision > 0 Then
            If wLock Then
                For xI0 As Integer = 1 To UBound(K)
                    If K(xI0).ColumnIndex >= niB Then wPosition = K(xI0).VPosition : Exit For
                Next
            End If

            Dim xPtsL(xTHeight * wPrecision) As PointF
            Dim xPtsR(xTHeight * wPrecision) As PointF

            Dim xD1 As Double

            Dim bVPosition() As Double = {wPosition}
            Dim bBPM() As Decimal = {K(0).Value / 10000}
            Dim bWavDataIndex() As Decimal = {0}

            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex = niBPM Then
                    If K(xI1).VPosition >= wPosition Then
                        ReDim Preserve bVPosition(UBound(bVPosition) + 1)
                        ReDim Preserve bBPM(UBound(bBPM) + 1)
                        ReDim Preserve bWavDataIndex(UBound(bWavDataIndex) + 1)
                        bVPosition(UBound(bVPosition)) = K(xI1).VPosition
                        bBPM(UBound(bBPM)) = K(xI1).Value / 10000
                        bWavDataIndex(UBound(bWavDataIndex)) = (K(xI1).VPosition - bVPosition(UBound(bVPosition) - 1)) * 1.25 * wSampleRate / bBPM(UBound(bBPM) - 1) + bWavDataIndex(UBound(bWavDataIndex) - 1)
                    Else
                        bBPM(0) = K(xI1).Value / 10000
                    End If
                End If
            Next

            Dim xI2 As Integer = 0
            Dim xI3 As Double

            For xI1 = xTHeight * wPrecision To 0 Step -1
                xI3 = (-xI1 / wPrecision + xTHeight + xVSR * gxHeight - 1) / gxHeight
                For xI2 = 1 To UBound(bVPosition)
                    If bVPosition(xI2) >= xI3 Then Exit For
                Next
                xI2 -= 1
                xD1 = bWavDataIndex(xI2) + (xI3 - bVPosition(xI2)) * 1.25 * wSampleRate / bBPM(xI2)

                If xD1 <= UBound(wWavL) And xD1 >= 0 Then
                    xPtsL(xI1) = New PointF(wWavL(Int(xD1)) / 65536 * wWidth + wLeft, xI1 / wPrecision)
                    xPtsR(xI1) = New PointF(wWavR(Int(xD1)) / 65536 * wWidth + wLeft, xI1 / wPrecision)
                Else
                    xPtsL(xI1) = New PointF(wLeft, xI1 / wPrecision)
                    xPtsR(xI1) = New PointF(wLeft, xI1 / wPrecision)
                End If
            Next
            e1.Graphics.DrawLines(vo.pBGMWav, xPtsL)
            e1.Graphics.DrawLines(vo.pBGMWav, xPtsR)
        End If

        'K
        'If Not K Is Nothing Then
        Dim xUpperBorder As Single = Math.Abs(xVS) + xTHeight / gxHeight
        Dim xLowerBorder As Single = Math.Abs(xVS) - vo.kHeight / gxHeight

        If NTInput Then
            For xI1 = 0 To UBound(K)
                If K(xI1).VPosition > xUpperBorder Then Exit For
                'If the K is inside the visible area or
                '   the K is below the visible area but has an end point above the lower border
                If K(xI1).VPosition >= xLowerBorder OrElse _
                   (K(xI1).VPosition <= xLowerBorder And K(xI1).VPosition + K(xI1).Length >= xLowerBorder) Then _
                    DrawNoteNT(K(xI1), e1, xHS, xVS, xTHeight)
            Next

        Else
            For xI1 = 0 To UBound(K)
                If K(xI1).VPosition > xUpperBorder Then Exit For
                'If the K is inside the visible area or
                '   the K is below the visible area but is paired with another K above the lower border
                If K(xI1).VPosition >= xLowerBorder OrElse _
                   (K(xI1).VPosition <= xLowerBorder And K(K(xI1).PairWithI).VPosition >= xLowerBorder) Then _
                    DrawNote(K(xI1), e1, xHS, xVS, xTHeight)
            Next
        End If

        'End If

        'Selection Box
        If TBSelect.Checked AndAlso xIndex = spFocus AndAlso Not (pMouseMove = New Point(-1, -1) Or pMouseDown = New Point(-1, -1)) Then
            e1.Graphics.DrawRectangle(vo.SelBox, IIf(pMouseMove.X > pMouseDown.X, pMouseDown.X, pMouseMove.X), _
                                                IIf(pMouseMove.Y > pMouseDown.Y, pMouseDown.Y, pMouseMove.Y), _
                                                Math.Abs(pMouseMove.X - pMouseDown.X), Math.Abs(pMouseMove.Y - pMouseDown.Y))
        End If

        'Mouse Over
        If TBSelect.Checked AndAlso Not KMouseOver = -1 Then
            If NTInput Then
                Dim xDispX As Integer = HorizontalPositiontoDisplay(nLeft(K(KMouseOver).ColumnIndex), xHS)
                Dim xDispY As Integer = IIf(Not NTInput Or (bAdjustLength And Not bAdjustUpper), _
                                            VerticalPositiontoDisplay(K(KMouseOver).VPosition, xVS, xTHeight) - vo.kHeight - 1, _
                                            VerticalPositiontoDisplay(K(KMouseOver).VPosition + K(KMouseOver).Length, xVS, xTHeight) - vo.kHeight - 1)
                Dim xDispW As Integer = nLength(K(KMouseOver).ColumnIndex) * gxWidth + 1
                Dim xDispH As Integer = IIf(Not NTInput Or bAdjustLength, _
                                            vo.kHeight + 3, _
                                            K(KMouseOver).Length * gxHeight + vo.kHeight + 3)

                If Not bAdjustLength Then DrawNoteNT(K(KMouseOver), e1, xHS, xVS, xTHeight)
                e1.Graphics.DrawRectangle(IIf(bAdjustLength, vo.kMouseOverE, vo.kMouseOver), xDispX, xDispY, xDispW - 1, xDispH - 1)

            Else
                DrawNote(K(KMouseOver), e1, xHS, xVS, xTHeight)
                e1.Graphics.DrawRectangle(vo.kMouseOver, _
                                          HorizontalPositiontoDisplay(nLeft(K(KMouseOver).ColumnIndex), xHS), _
                                          VerticalPositiontoDisplay(K(KMouseOver).VPosition, xVS, xTHeight) - vo.kHeight - 1, _
                                          nLength(K(KMouseOver).ColumnIndex) * gxWidth, _
                                          vo.kHeight + 2)
            End If
        End If

        If TempDraw AndAlso (TempColumn > -1 And TempVPosition > -1) Then
            'Dim xNote As Note
            'With xNote
            '    .ColumnIndex = TempColumn
            '    .LongNote = My.Computer.Keyboard.ShiftKeyDown And Not NTInput
            '    .VPosition = TempVPosition
            '    .Value = (LWAV.SelectedIndex + 1) * 10000
            'End With
            'DrawNote(xNote, e1, xHS, xVS, xTHeight, False)
            Dim xValue As Integer = (LWAV.SelectedIndex + 1) * 10000

            Dim xAlpha As Single = 1.0F
            If My.Computer.Keyboard.CtrlKeyDown Then xAlpha = vo.kOpacity

            Dim xText As String = C10to36(xValue \ 10000)
            If nNumericLabel(TempColumn) Then xText = nCol(TempColumn).Title
            'If nNumericLabel(TempColumn) Then xText = xValue / 10000
            'If nCol(TempColumn).Text <> "" Then xText = nCol(TempColumn).Text

            If NTInput Or Not My.Computer.Keyboard.ShiftKeyDown Then

                Dim xPen1 As New Pen(nCol(TempColumn).getBright(xAlpha))
                Dim xBrush As New Drawing2D.LinearGradientBrush(New Point(HorizontalPositiontoDisplay(nLeft(TempColumn), xHS), VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight - 10), _
                               New Point(HorizontalPositiontoDisplay(nLeft(TempColumn) + nLength(TempColumn), xHS), VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) + 10), _
                               nCol(TempColumn).getBright(xAlpha), _
                               nCol(TempColumn).getDark(xAlpha))
                Dim xBrush2 As New SolidBrush(nCol(TempColumn).cText)

                e1.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + 2, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight + 1, nLength(TempColumn) * gxWidth - 3, vo.kHeight - 1)
                e1.Graphics.DrawRectangle(xPen1, HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + 1, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight, nLength(TempColumn) * gxWidth - 2, vo.kHeight)

                e1.Graphics.DrawString(xText, vo.kFont, xBrush2, _
                            HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + vo.kLabelHShift, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight + vo.kLabelVShift)

            Else
                Dim xPen2 As New Pen(nCol(TempColumn).getLongBright(xAlpha))
                Dim xBrush As New Drawing2D.LinearGradientBrush(New Point(HorizontalPositiontoDisplay(nLeft(TempColumn), xHS), VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight - 10), _
                                New Point(HorizontalPositiontoDisplay(nLeft(TempColumn) + nLength(TempColumn), xHS), VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) + 10), _
                                nCol(TempColumn).getLongBright(xAlpha), _
                                nCol(TempColumn).getLongDark(xAlpha))
                Dim xBrush2 As New SolidBrush(nCol(TempColumn).cLText)

                e1.Graphics.FillRectangle(xBrush, HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + 2, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight + 1, nLength(TempColumn) * gxWidth - 3, vo.kHeight - 1)
                e1.Graphics.DrawRectangle(xPen2, HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + 1, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight, nLength(TempColumn) * gxWidth - 2, vo.kHeight)

                e1.Graphics.DrawString(xText, vo.kFont, xBrush2, _
                            HorizontalPositiontoDisplay(nLeft(TempColumn), xHS) + vo.kLabelHShiftL, VerticalPositiontoDisplay(TempVPosition, xVS, xTHeight) - vo.kHeight + vo.kLabelVShift)
            End If

        End If

        'Time Selection
        If TBTimeSelect.Checked Then
            Dim xBPMStart As Integer = K(0).Value
            Dim xBPMHalf As Integer = K(0).Value
            Dim xBPMEnd As Integer = K(0).Value

            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex = niBPM Then
                    If K(xI1).VPosition <= vSelStart Then xBPMStart = K(xI1).Value
                    If K(xI1).VPosition <= vSelStart + vSelHalf Then xBPMHalf = K(xI1).Value
                    If K(xI1).VPosition <= vSelStart + vSelLength Then xBPMEnd = K(xI1).Value
                End If
                If K(xI1).VPosition > vSelStart + vSelLength Then Exit For
            Next

            'Selection area
            e1.Graphics.FillRectangle(vo.PESel, _
                                      0, _
                                      VerticalPositiontoDisplay(vSelStart + IIf(vSelLength > 0, vSelLength, 0), xVS, xTHeight) + Math.Abs(CInt(vSelLength <> 0)), _
                                      xTWidth, _
                                      CInt(Math.Abs(vSelLength) * gxHeight))
            'End Cursor
            e1.Graphics.DrawLine(vo.PECursor, _
                                 0, _
                                 VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xTHeight), _
                                 xTWidth, _
                                 VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xTHeight))
            'Half Cursor
            e1.Graphics.DrawLine(vo.PEHalf, _
                                 0, _
                                 VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xTHeight), _
                                 xTWidth, _
                                 VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xTHeight))
            'Start BPM
            e1.Graphics.DrawString(xBPMStart / 10000, _
                                   vo.PEBPMFont, vo.PEBPM, _
                                   (-xHS + nLeft(niBPM)) * gxWidth, _
                                   VerticalPositiontoDisplay(vSelStart, xVS, xTHeight) - vo.PEBPMFont.Height + 3)
            'Half BPM
            e1.Graphics.DrawString(xBPMHalf / 10000, _
                                   vo.PEBPMFont, vo.PEBPM, _
                                   (-xHS + nLeft(niBPM)) * gxWidth, _
                                   VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xTHeight) - vo.PEBPMFont.Height + 3)
            'End BPM
            e1.Graphics.DrawString(xBPMEnd / 10000, _
                                   vo.PEBPMFont, vo.PEBPM, _
                                   (-xHS + nLeft(niBPM)) * gxWidth, _
                                   VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xTHeight) - vo.PEBPMFont.Height + 3)

            'SelLine
            If vSelMouseOverLine = 1 Then 'Start Cursor
                e1.Graphics.DrawRectangle(vo.PEMouseOver, _
                                          0, VerticalPositiontoDisplay(vSelStart, xVS, xTHeight) - 1, _
                                          xTWidth - 1, 2)
            ElseIf vSelMouseOverLine = 2 Then 'Half Cursor
                e1.Graphics.DrawRectangle(vo.PEMouseOver, _
                                          0, VerticalPositiontoDisplay(vSelStart + vSelHalf, xVS, xTHeight) - 1, _
                                          xTWidth - 1, 2)
            ElseIf vSelMouseOverLine = 3 Then 'End Cursor
                e1.Graphics.DrawRectangle(vo.PEMouseOver, _
                                          0, VerticalPositiontoDisplay(vSelStart + vSelLength, xVS, xTHeight) - 1, _
                                          xTWidth - 1, 2)
            End If
        End If

        'Middle button: CLick and Scroll
        If MiddleButtonClicked Then
            Dim xDeltaLocation As Point = spMain(xIndex).PointToScreen(New Point(0, 0))

            Dim xInitX As Single = MiddleButtonLocation.X - xDeltaLocation.X
            Dim xInitY As Single = MiddleButtonLocation.Y - xDeltaLocation.Y
            Dim xCurrX As Single = Cursor.Position.X - xDeltaLocation.X
            Dim xCurrY As Single = Cursor.Position.Y - xDeltaLocation.Y
            Dim xAngle As Double = Math.Atan2(xCurrY - xInitY, xCurrX - xInitX)
            e1.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

            If Not (xInitX = xCurrX And xInitY = xCurrY) Then
                Dim xPointx() As PointF = {New PointF(xCurrX, xCurrY), _
                                           New PointF(CSng(Math.Cos(xAngle + Math.PI / 2) * 10 + xInitX), CSng(Math.Sin(xAngle + Math.PI / 2) * 10 + xInitY)), _
                                           New PointF(CSng(Math.Cos(xAngle - Math.PI / 2) * 10 + xInitX), CSng(Math.Sin(xAngle - Math.PI / 2) * 10 + xInitY))}
                e1.Graphics.FillPolygon(New Drawing2D.LinearGradientBrush(New Point(xInitX, xInitY), New Point(xCurrX, xCurrY), Color.FromArgb(0), Color.FromArgb(-1)), xPointx)
            End If

            e1.Graphics.FillEllipse(Brushes.LightGray, xInitX - 10, xInitY - 10, 20, 20)
            e1.Graphics.DrawEllipse(Pens.Black, xInitX - 8, xInitY - 8, 16, 16)

            e1.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
        End If

        'Drag/Drop
        If UBound(DDFileName) > -1 Then
            'Dim xFont As New Font("Cambria", 12)
            Dim xBrush As New SolidBrush(Color.FromArgb(&HC0FFFFFF))
            Dim xCenterX As Single = spMain(xIndex).DisplayRectangle.Width / 2
            Dim xCenterY As Single = spMain(xIndex).DisplayRectangle.Height / 2
            Dim xFormat As New System.Drawing.StringFormat
            xFormat.Alignment = StringAlignment.Center
            xFormat.LineAlignment = StringAlignment.Center
            e1.Graphics.DrawString(Join(DDFileName, vbCrLf), Me.Font, xBrush, spMain(xIndex).DisplayRectangle, xFormat)
        End If

        e1.Render(spMain(xIndex).CreateGraphics)
        e1.Dispose()
    End Sub

    Private Sub VSGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles VS.GotFocus, VSL.GotFocus, VSR.GotFocus
        spFocus = sender.Tag
        spMain(spFocus).Focus()
    End Sub

    Private Sub VSValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VS.ValueChanged, VSL.ValueChanged, VSR.ValueChanged
        Dim iI As Integer = sender.Tag
        If iI = spFocus And Not pMouseDown = New Point(-1, -1) And Not VSValue = -1 Then pMouseDown.Y += (VSValue - sender.Value) * gxHeight
        spV(iI) = sender.Value

        If spLock((iI + 1) Mod 3) Then
            Dim xVS As Integer = spV(iI) + spDiff(iI)
            If xVS > 0 Then xVS = 0
            If xVS < VS.Minimum Then xVS = VS.Minimum
            Select Case iI
                Case 0 : VS.Value = xVS
                Case 1 : VSR.Value = xVS
                Case 2 : VSL.Value = xVS
            End Select
        End If

        If spLock((iI + 2) Mod 3) Then
            Dim xVS As Integer = spV(iI) - spDiff((iI + 2) Mod 3)
            If xVS > 0 Then xVS = 0
            If xVS < VS.Minimum Then xVS = VS.Minimum
            Select Case iI
                Case 0 : VSR.Value = xVS
                Case 1 : VSL.Value = xVS
                Case 2 : VS.Value = xVS
            End Select
        End If

        spDiff(iI) = spV((iI + 1) Mod 3) - spV(iI)
        spDiff((iI + 2) Mod 3) = spV(iI) - spV((iI + 2) Mod 3)

        VSValue = sender.Value
        RefreshPanel(iI, spMain(iI).DisplayRectangle)
    End Sub

    Private Sub cVSLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cVSLockL.CheckedChanged, cVSLock.CheckedChanged, cVSLockR.CheckedChanged
        Dim iI As Integer = sender.Tag
        spLock(iI) = sender.Checked
        If Not spLock(iI) Then Return

        spDiff(iI) = spV((iI + 1) Mod 3) - spV(iI)
        spDiff((iI + 2) Mod 3) = spV(iI) - spV((iI + 2) Mod 3)

        'POHeaderB.Text = spDiff(0) & "_" & spDiff(1) & "_" & spDiff(2)
    End Sub

    Private Sub HSGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles HS.GotFocus, HSL.GotFocus, HSR.GotFocus
        spFocus = sender.Tag
        spMain(spFocus).Focus()
    End Sub

    Private Sub HSValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HS.ValueChanged, HSL.ValueChanged, HSR.ValueChanged
        Dim iI As Integer = sender.Tag
        If Not pMouseDown = New Point(-1, -1) And Not HSValue = -1 Then pMouseDown.X += (HSValue - sender.Value) * gxWidth
        spH(iI) = sender.Value
        HSValue = sender.Value
        RefreshPanel(iI, spMain(iI).DisplayRectangle)
    End Sub

    Private Sub TBSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSelect.Click, mnSelect.Click
        TBSelect.Checked = True
        TBWrite.Checked = False
        TBTimeSelect.Checked = False
        mnSelect.Checked = True
        mnWrite.Checked = False
        mnTimeSelect.Checked = False

        FStatus2.Visible = False
        FStatus.Visible = True

        TempDraw = False
        TempColumn = -1
        TempVPosition = -1
        TempLength = 0

        vSelStart = MeasureBottom(InMeasure(-spV(spFocus)) + 1)
        vSelLength = 0

        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub TBWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBWrite.Click, mnWrite.Click
        TBSelect.Checked = False
        TBWrite.Checked = True
        TBTimeSelect.Checked = False
        mnSelect.Checked = False
        mnWrite.Checked = True
        mnTimeSelect.Checked = False

        FStatus2.Visible = False
        FStatus.Visible = True

        TempDraw = True
        TempColumn = -1
        TempVPosition = -1
        TempLength = 0

        vSelStart = MeasureBottom(InMeasure(-spV(spFocus)) + 1)
        vSelLength = 0

        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub TBPostEffects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBTimeSelect.Click, mnTimeSelect.Click
        TBSelect.Checked = False
        TBWrite.Checked = False
        TBTimeSelect.Checked = True
        mnSelect.Checked = False
        mnWrite.Checked = False
        mnTimeSelect.Checked = True

        FStatus.Visible = False
        FStatus2.Visible = True

        vSelMouseOverLine = 0
        TempDraw = False
        TempColumn = -1
        TempVPosition = -1
        TempLength = 0
        ValidateSelection()

        Dim xI1 As Integer
        For xI1 = 0 To UBound(K)
            K(xI1).Selected = False
        Next
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub CGHeight_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CGHeight.ValueChanged
        gxHeight = CSng(CGHeight.Value)
        CGHeight2.Value = IIf(CGHeight.Value * 4 < CGHeight2.Maximum, CDec(CGHeight.Value * 4), CGHeight2.Maximum)
        RefreshPanelAll()
    End Sub

    Private Sub CGHeight2_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles CGHeight2.Scroll
        CGHeight.Value = CGHeight2.Value / 4
    End Sub

    Private Sub CGWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CGWidth.ValueChanged
        gxWidth = CSng(CGWidth.Value)
        CGWidth2.Value = IIf(CGWidth.Value * 4 < CGWidth2.Maximum, CDec(CGWidth.Value * 4), CGWidth2.Maximum)

        HS.LargeChange = PMainIn.Width / gxWidth
        If HS.Value > HS.Maximum - HS.LargeChange + 1 Then HS.Value = HS.Maximum - HS.LargeChange + 1
        HSL.LargeChange = PMainInL.Width / gxWidth
        If HSL.Value > HSL.Maximum - HSL.LargeChange + 1 Then HSL.Value = HSL.Maximum - HSL.LargeChange + 1
        HSR.LargeChange = PMainInR.Width / gxWidth
        If HSR.Value > HSR.Maximum - HSR.LargeChange + 1 Then HSR.Value = HSR.Maximum - HSR.LargeChange + 1

        RefreshPanelAll()
    End Sub

    Private Sub CGWidth2_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles CGWidth2.Scroll
        CGWidth.Value = CGWidth2.Value / 4
    End Sub

    Private Sub CGDivide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGDivide.ValueChanged
        gDivide = CGDivide.Value
        RefreshPanelAll()
    End Sub
    Private Sub CGSub_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGSub.ValueChanged
        gSub = CGSub.Value
        RefreshPanelAll()
    End Sub
    Private Sub BGSlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGSlash.Click
        Dim xd As Integer = Val(InputBox(Locale.Messages.PromptSlashValue, , gSlash))
        If xd = 0 Then Exit Sub
        If xd > CGDivide.Maximum Then xd = CGDivide.Maximum
        If xd < CGDivide.Minimum Then xd = CGDivide.Minimum
        gSlash = xd
    End Sub

    'Private Sub CGWheel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case CGWheel.SelectedIndex
    '        Case 0 : gWheel = 192
    '        Case 1 : gWheel = 96
    '        Case 2 : gWheel = 64
    '        Case 3 : gWheel = 48
    '    End Select
    'End Sub

    Private Sub CGSnap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGSnap.CheckedChanged
        gSnap = CGSnap.Checked
        RefreshPanelAll()
    End Sub

    'Private Sub bCompareMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If K Is Nothing Then Exit Sub
    '    Dim KTemp() As Note = K
    '    Dim Timer0 As Double
    '    Dim Timer1 As Double
    '    Dim Timer2 As Double
    '    Dim Timer3 As Double
    '
    '    Timer0 = DateAndTime.Timer
    '    SortByVPositionQuick(0, UBound(K))
    '    Timer3 = DateAndTime.Timer - Timer0
    '    Dim K3() As Note = K
    '    K = KTemp
    '
    '    Timer0 = DateAndTime.Timer
    '    SortByVPositionBubble()
    '    Timer1 = DateAndTime.Timer - Timer0
    '    Dim K1() As Note = K
    '    K = KTemp
    '
    '    Timer0 = DateAndTime.Timer
    '    SortByVPosition()
    '    Timer2 = DateAndTime.Timer - Timer0
    '    Dim K2() As Note = K
    '    K = KTemp
    '
    '    Dim xI1 As Integer
    '    Dim xBoolean As Boolean = True
    '    For xI1 = 1 To UBound(K)
    '        xBoolean = xBoolean And K1(xI1).VPosition = K2(xI1).VPosition And K3(xI1).VPosition = K2(xI1).VPosition
    '    Next
    '
    '    MsgBox(Timer1 & vbCrLf & Timer2 & vbCrLf & Timer3 & vbCrLf & xBoolean)
    '
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim xI1 As Integer

        Select Case spFocus
            Case 0
                With VSL
                    xI1 = .Value + (tempY / 5) / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HSL
                    xI1 = .Value + (tempX / 10) / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With

            Case 1
                With VS
                    xI1 = .Value + (tempY / 5) / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HS
                    xI1 = .Value + (tempX / 10) / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With

            Case 2
                With VSR
                    xI1 = .Value + (tempY / 5) / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HSR
                    xI1 = .Value + (tempX / 10) / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
        End Select

        Dim xMEArgs As New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0)
        PMainInMouseMove(spMain(spFocus), xMEArgs)

    End Sub

    Private Sub TimerMiddle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMiddle.Tick
        If Not MiddleButtonClicked Then TimerMiddle.Enabled = False : Return

        Dim xI1 As Integer

        Select Case spFocus
            Case 0
                With VSL
                    xI1 = .Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5 / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HSL
                    xI1 = .Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5 / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With

            Case 1
                With VS
                    xI1 = .Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5 / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HS
                    xI1 = .Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5 / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With

            Case 2
                With VSR
                    xI1 = .Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5 / gxHeight
                    If xI1 > 0 Then xI1 = 0
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
                With HSR
                    xI1 = .Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5 / gxWidth
                    If xI1 > .Maximum - .LargeChange + 1 Then xI1 = .Maximum - .LargeChange + 1
                    If xI1 < .Minimum Then xI1 = .Minimum
                    .Value = xI1
                End With
        End Select

        Dim xMEArgs As New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0)
        PMainInMouseMove(spMain(spFocus), xMEArgs)
    End Sub

    Private Sub validate_LWAV_view()
        Try
            Dim xRect As Rectangle = LWAV.GetItemRectangle(LWAV.SelectedIndex)
            If xRect.Top + xRect.Height > LWAV.DisplayRectangle.Height Then SendMessage(LWAV.Handle, &H115, 1, 0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LWAV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LWAV.Click
        If TBWrite.Checked Then FSW.Text = C10to36(LWAV.SelectedIndex + 1)

        PreviewNote("", True)
        If Not PreviewOnClick Then Exit Sub
        If hWAV(LWAV.SelectedIndex + 1) = "" Then Exit Sub

        Dim xFileLocation As String = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName)) & "\" & hWAV(LWAV.SelectedIndex + 1)
        PreviewNote(xFileLocation, False)
    End Sub

    Private Sub LWAV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LWAV.DoubleClick
        Dim xDWAV As New OpenFileDialog
        xDWAV.DefaultExt = "wav"
        xDWAV.Filter = Locale.FileType._wave & "|*.wav;*.ogg;*.mp3|" & _
                       Locale.FileType.WAV & "|*.wav|" & _
                       Locale.FileType.OGG & "|*.ogg|" & _
                       Locale.FileType.MP3 & "|*.mp3|" & _
                       Locale.FileType._all & "|*.*"
        xDWAV.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDWAV.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDWAV.FileName)
        hWAV(LWAV.SelectedIndex + 1) = GetFileName(xDWAV.FileName)
        LWAV.Items.Item(LWAV.SelectedIndex) = C10to36(LWAV.SelectedIndex + 1) & ": " & GetFileName(xDWAV.FileName)
        If IsSaved Then SetIsSaved(False)
    End Sub

    'Private Sub LWAV_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LWAV.GotFocus, LWAV.SelectedIndexChanged, LWAV.LostFocus
    '    Dim xI1 As Integer = LWAV.SelectedIndex
    '    If xI1 = -1 Then Exit Sub
    '
    '    Dim xOffset As Integer = LWAV.GetItemRectangle(xI1).Y
    '    If xOffset >= 0 And xOffset < LWAV.Height Then
    '        xOffset += LWAV.Top
    '        BWAVBrowse2.Top = xOffset
    '        BWAVRemove2.Top = xOffset
    '        BWAVBrowse2.Visible = True
    '        BWAVRemove2.Visible = True
    '    Else
    '        BWAVBrowse2.Visible = False
    '        BWAVRemove2.Visible = False
    '    End If
    'End Sub

    Private Sub LWAV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LWAV.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                hWAV(LWAV.SelectedIndex + 1) = ""
                LWAV.Items.Item(LWAV.SelectedIndex) = C10to36(LWAV.SelectedIndex + 1) & ": "
                If IsSaved Then SetIsSaved(False)
        End Select
    End Sub

    Private Sub TBErrorCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBErrorCheck.Click, mnErrorCheck.Click
        ErrorCheck = sender.Checked
        TBErrorCheck.Checked = ErrorCheck
        mnErrorCheck.Checked = ErrorCheck
        TBErrorCheck.Image = IIf(TBErrorCheck.Checked, My.Resources.x16CheckError, My.Resources.x16CheckErrorN)
        mnErrorCheck.Image = IIf(TBErrorCheck.Checked, My.Resources.x16CheckError, My.Resources.x16CheckErrorN)
        RefreshPanelAll()
    End Sub

    Private Sub TBPreviewOnClick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPreviewOnClick.Click, mnPreviewOnClick.Click
        PreviewNote("", True)
        PreviewOnClick = sender.Checked
        TBPreviewOnClick.Checked = PreviewOnClick
        mnPreviewOnClick.Checked = PreviewOnClick
        TBPreviewOnClick.Image = IIf(PreviewOnClick, My.Resources.x16PreviewOnClick, My.Resources.x16PreviewOnClickN)
        mnPreviewOnClick.Image = IIf(PreviewOnClick, My.Resources.x16PreviewOnClick, My.Resources.x16PreviewOnClickN)
    End Sub

    'Private Sub TBPreviewErrorCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PreviewErrorCheck = TBPreviewErrorCheck.Checked
    '    TBPreviewErrorCheck.Image = IIf(PreviewErrorCheck, My.Resources.x16PreviewCheck, My.Resources.x16PreviewCheckN)
    'End Sub

    Private Sub TBShowFileName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBShowFileName.Click, mnShowFileName.Click
        ShowFileName = sender.Checked
        TBShowFileName.Checked = ShowFileName
        mnShowFileName.Checked = ShowFileName
        TBShowFileName.Image = IIf(ShowFileName, My.Resources.x16ShowFileName, My.Resources.x16ShowFileNameN)
        mnShowFileName.Image = IIf(ShowFileName, My.Resources.x16ShowFileName, My.Resources.x16ShowFileNameN)
        RefreshPanelAll()
    End Sub

    Private Sub TBCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCut.Click, mnCut.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
        For xI1 As Integer = 1 To UBound(K)
            Me.RedoRemoveNoteSelected(True, xUndo, xRedo)
        Next
        'Dim xRedo As String = sCmdKDs()
        'Dim xUndo As String = sCmdKs(True)

        CopyNotes(False)
        RemoveNotes(False)
        AddUndo(xUndo, xBaseRedo.Next)

        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
        RefreshPanelAll()
        POStatusRefresh()
        CalculateGreatestVPosition()
    End Sub

    Private Sub TBCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCopy.Click, mnCopy.Click
        CopyNotes()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub TBPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPaste.Click, mnPaste.Click
        AddNotes()

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
        Me.RedoAddNoteSelected(True, xUndo, xRedo)
        AddUndo(xUndo, xBaseRedo.Next)

        'AddUndo(sCmdKDs(), sCmdKs(True))

        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
        RefreshPanelAll()
        POStatusRefresh()
        CalculateGreatestVPosition()
    End Sub

    'Private Function pArgPath(ByVal I As Integer)
    '    Return Mid(pArgs(I), 1, InStr(pArgs(I), vbCrLf) - 1)
    'End Function

    Private Function GetFileName(ByVal s As String) As String
        Dim fslash As Integer = InStrRev(s, "/")
        Dim bslash As Integer = InStrRev(s, "\")
        Return Mid(s, IIf(fslash > bslash, fslash, bslash) + 1)
    End Function

    Private Function ExcludeFileName(ByVal s As String) As String
        Dim fslash As Integer = InStrRev(s, "/")
        Dim bslash As Integer = InStrRev(s, "\")
        If (bslash Or fslash) = 0 Then Return ""
        Return Mid(s, 1, IIf(fslash > bslash, fslash, bslash) - 1)
    End Function

    Private Sub PlayerMissingPrompt()
        Dim xArg As Form1.PlayerArguments = pArgs(CurrentPlayer)
        MsgBox(Locale.Messages.CannotFind.Replace("{}", PrevCodeToReal(xArg.Path)) & vbCrLf & _
               Locale.Messages.PleaseRespecifyPath, MsgBoxStyle.Critical, Locale.Messages.PlayerNotFound)

        Dim xDOpen As New OpenFileDialog
        xDOpen.InitialDirectory = IIf(ExcludeFileName(PrevCodeToReal(xArg.Path)) = "", _
                                      My.Application.Info.DirectoryPath, _
                                      ExcludeFileName(PrevCodeToReal(xArg.Path)))
        xDOpen.FileName = PrevCodeToReal(xArg.Path)
        xDOpen.Filter = Locale.FileType.EXE & "|*.exe"
        xDOpen.DefaultExt = "exe"
        If xDOpen.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        'pArgs(CurrentPlayer) = Replace(xDOpen.FileName, My.Application.Info.DirectoryPath, "<apppath>") & _
        '                                           Mid(pArgs(CurrentPlayer), InStr(pArgs(CurrentPlayer), vbCrLf))
        'xStr = Split(pArgs(CurrentPlayer), vbCrLf)
        pArgs(CurrentPlayer).Path = Replace(xDOpen.FileName, My.Application.Info.DirectoryPath, "<apppath>")
        xArg = pArgs(CurrentPlayer)
    End Sub

    Private Sub TBPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPlay.Click, mnPlay.Click
        'Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
        Dim xArg As Form1.PlayerArguments = pArgs(CurrentPlayer)

        If Not File.Exists(PrevCodeToReal(xArg.Path)) Then
            PlayerMissingPrompt()
            xArg = pArgs(CurrentPlayer)
        End If

        Dim xStrAll As String = SaveBMS()
        Dim xFileName As String = IIf(Not PathIsValid(FileName), _
                                      IIf(InitPath = "", My.Application.Info.DirectoryPath, InitPath), _
                                      ExcludeFileName(FileName)) & "\___TempBMS.bms"
        My.Computer.FileSystem.WriteAllText(xFileName, xStrAll, False, TextEncoding)

        AddTempFileList(xFileName)
        System.Diagnostics.Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aHere))
    End Sub

    Private Sub TBPlayB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPlayB.Click, mnPlayB.Click
        'Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
        Dim xArg As Form1.PlayerArguments = pArgs(CurrentPlayer)

        If Not File.Exists(PrevCodeToReal(xArg.Path)) Then
            PlayerMissingPrompt()
            xArg = pArgs(CurrentPlayer)
        End If

        Dim xStrAll As String = SaveBMS()
        Dim xFileName As String = IIf(Not PathIsValid(FileName), _
                                      IIf(InitPath = "", My.Application.Info.DirectoryPath, InitPath), _
                                      ExcludeFileName(FileName)) & "\___TempBMS.bms"
        My.Computer.FileSystem.WriteAllText(xFileName, xStrAll, False, TextEncoding)

        AddTempFileList(xFileName)
        System.Diagnostics.Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aBegin))
    End Sub

    Private Sub TBStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBStop.Click, mnStop.Click
        'Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
        Dim xArg As Form1.PlayerArguments = pArgs(CurrentPlayer)

        If Not File.Exists(PrevCodeToReal(xArg.Path)) Then
            PlayerMissingPrompt()
            xArg = pArgs(CurrentPlayer)
        End If

        System.Diagnostics.Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aStop))
    End Sub

    Private Sub AddTempFileList(ByVal s As String)
        Dim xAdd As Boolean = True
        If pTempFileNames IsNot Nothing Then
            For Each xStr1 As String In pTempFileNames
                If xStr1 = s Then xAdd = False : Exit For
            Next
        End If

        If xAdd Then
            ReDim Preserve pTempFileNames(UBound(pTempFileNames) + 1)
            pTempFileNames(UBound(pTempFileNames)) = s
        End If
    End Sub

    Private Sub TBStatistics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBStatistics.Click, mnStatistics.Click
        SortByVPositionInsertion()
        UpdatePairing()

        'Dim xI1 As Integer
        'Dim xIAll As Integer = 0
        'Dim xILong As Integer = 0
        'Dim xINormal As Integer = 0
        'Dim xIB As Integer = 0
        'Dim xIError As Integer = 0
        '
        'If Not NTInput Then
        '    For xI1 = 1 To UBound(K)
        '        With K(xI1)
        '            If .ColumnIndex >= niA1 And .ColumnIndex <= niA8 Then
        '                xIAll += 1
        '                If .LongNote Then xILong += 1 Else xINormal += 1
        '            End If
        '            If .HasError Then xIError += 1
        '            If .ColumnIndex >= niB Then xIB += 1
        '        End With
        '    Next
        '
        'Else
        '    For xI1 = 1 To UBound(K)
        '        With K(xI1)
        '            If .ColumnIndex >= niA1 And .ColumnIndex <= niA8 Then
        '                xIAll += 1
        '                If .Length = 0 Then xINormal += 1 Else xIAll += 1 : xILong += 2
        '            End If
        '            If .HasError Then xIError += 1
        '            If .ColumnIndex >= niB Then xIB += 1
        '        End With
        '    Next
        'End If

        Dim data(5, 5) As Integer
        For i As Integer = 1 To UBound(K)
            With K(i)
                Dim row As Integer = -1
                Select Case .ColumnIndex
                    Case niBPM : row = 0
                    Case niSTOP : row = 1
                    Case niA1, niA2, niA3, niA4, niA5, niA6, niA7, niA8 : row = 2
                    Case niD1, niD2, niD3, niD4, niD5, niD6, niD7, niD8 : row = 3
                    Case Is >= niB : row = 4
                    Case Else : row = 5
                End Select


StartCount:     If Not NTInput Then
                    If Not .LongNote Then data(row, 0) += 1
                    If .LongNote Then data(row, 1) += 1
                    If .Value \ 10000 = LnObj Then data(row, 2) += 1
                    If .Hidden Then data(row, 3) += 1
                    If .HasError Then data(row, 4) += 1
                    data(row, 5) += 1

                Else
                    Dim noteUnit As Integer = 1
                    If .Length = 0 Then data(row, 0) += 1
                    If .Length <> 0 Then data(row, 1) += 2 : noteUnit = 2

                    If .Value \ 10000 = LnObj Then data(row, 2) += noteUnit
                    If .Hidden Then data(row, 3) += noteUnit
                    If .HasError Then data(row, 4) += noteUnit
                    data(row, 5) += noteUnit

                End If

                If row <> 5 Then row = 5 : GoTo StartCount
            End With
        Next

        Dim dStat As New dgStatistics(data)
        dStat.ShowDialog()
    End Sub

    ''' <summary>
    ''' Remark: Pls sort and updatepairing before this process.
    ''' </summary>

    Private Sub CalculateTotalNotes()
        Dim xI1 As Integer
        Dim xIAll As Integer = 0

        If Not NTInput Then
            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex >= niA1 And K(xI1).ColumnIndex <= niA8 Then xIAll += 1
            Next

        Else
            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex >= niA1 And K(xI1).ColumnIndex <= niA8 Then
                    xIAll += 1
                    If K(xI1).Length <> 0 Then xIAll += 1
                End If
            Next
        End If

        TBStatistics.Text = xIAll
    End Sub

    Private Sub POStatusRefresh()

        If TBSelect.Checked Then
            Dim xI1 As Integer = KMouseOver
            If xI1 < 0 Then

                TempVPosition = (spMain(spFocus).Height - spV(spFocus) * gxHeight - MouseMoveStatus.Y - 1) / gxHeight 'VPosition of the mouse
                If gSnap Then TempVPosition = SnapToGrid(TempVPosition)

                xI1 = 0
                Dim mLeft As Integer = MouseMoveStatus.X / gxWidth + spH(spFocus) 'horizontal position of the mouse
                If mLeft >= 0 Then
                    Do
                        If mLeft < nLeft(xI1 + 1) Or xI1 >= gCol Then TempColumn = xI1 : Exit Do 'get the column where mouse is 
                        xI1 += 1
                    Loop
                End If
                TempColumn = EnabledColumnToReal(RealColumnToEnabled(TempColumn))  'get the enabled column where mouse is 

                Dim xMeasure As Integer = InMeasure(TempVPosition)
                Dim xMLength As Double = MeasureLength(xMeasure)
                Dim xVposMod As Double = TempVPosition - MeasureBottom(xMeasure)
                Dim xGCD As Double = GCD(IIf(xVposMod = 0, xMLength, xVposMod), xMLength)

                FSP1.Text = (xVposMod * gDivide / 192).ToString & " / " & (xMLength * gDivide / 192).ToString & "  "
                FSP2.Text = xVposMod.ToString & " / " & xMLength & "  "
                FSP3.Text = CInt(xVposMod / xGCD).ToString & " / " & CInt(xMLength / xGCD).ToString & "  "
                FSP4.Text = TempVPosition.ToString() & "  "
                FSC.Text = nTitle(TempColumn)
                FSW.Text = ""
                FSM.Text = Add3Zeros(xMeasure)
                FST.Text = ""
                FSH.Text = ""
                FSE.Text = ""

            Else
                Dim xMeasure As Integer = InMeasure(K(xI1).VPosition)
                Dim xMLength As Double = MeasureLength(xMeasure)
                Dim xVposMod As Double = K(xI1).VPosition - MeasureBottom(xMeasure)
                Dim xGCD As Double = GCD(IIf(xVposMod = 0, xMLength, xVposMod), xMLength)

                FSP1.Text = (xVposMod * gDivide / 192).ToString & " / " & (xMLength * gDivide / 192).ToString & "  "
                FSP2.Text = xVposMod.ToString & " / " & xMLength & "  "
                FSP3.Text = CInt(xVposMod / xGCD).ToString & " / " & CInt(xMLength / xGCD).ToString & "  "
                FSP4.Text = K(xI1).VPosition.ToString() & "  "
                FSC.Text = nTitle(K(xI1).ColumnIndex)
                FSW.Text = IIf(nNumericLabel(K(xI1).ColumnIndex), _
                               K(xI1).Value / 10000, _
                               C10to36(K(xI1).Value \ 10000))
                FSM.Text = Add3Zeros(xMeasure)
                FST.Text = IIf(NTInput, Locale.StatusBar.Length & " = " & K(xI1).Length, IIf(K(xI1).LongNote, Locale.StatusBar.LongNote, ""))
                FSH.Text = IIf(K(xI1).Hidden, Locale.StatusBar.Hidden, "")
                FSE.Text = IIf(K(xI1).HasError, Locale.StatusBar.Err, "")

            End If

        ElseIf TBWrite.Checked Then
            If TempColumn < 0 Then Exit Sub

            Dim xMeasure As Integer = InMeasure(TempVPosition)
            Dim xMLength As Double = MeasureLength(xMeasure)
            Dim xVposMod As Double = TempVPosition - MeasureBottom(xMeasure)
            Dim xGCD As Double = GCD(IIf(xVposMod = 0, xMLength, xVposMod), xMLength)

            FSP1.Text = (xVposMod * gDivide / 192).ToString & " / " & (xMLength * gDivide / 192).ToString & "  "
            FSP2.Text = xVposMod.ToString & " / " & xMLength & "  "
            FSP3.Text = CInt(xVposMod / xGCD).ToString & " / " & CInt(xMLength / xGCD).ToString & "  "
            FSP4.Text = TempVPosition.ToString() & "  "
            FSC.Text = nTitle(TempColumn)
            FSW.Text = C10to36(LWAV.SelectedIndex + 1)
            FSM.Text = Add3Zeros(xMeasure)
            FST.Text = IIf(NTInput, TempLength, IIf(My.Computer.Keyboard.ShiftKeyDown, Locale.StatusBar.LongNote, ""))
            FSH.Text = IIf(My.Computer.Keyboard.CtrlKeyDown, Locale.StatusBar.Hidden, "")

        ElseIf TBTimeSelect.Checked Then
            FSSS.Text = vSelStart
            FSSL.Text = vSelLength
            FSSH.Text = vSelHalf

        End If

    End Sub

    Private Sub POBStorm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBStorm.Click
        'Dim xCI() As Integer = {niA1, niA2, niA3, niA4, niA5, niA6, niA7} 'Column Index
        'Dim xNI As Integer 'New Index
        'Dim xInt As Integer  'Temp Integer Val
        'Dim xI1 As Integer
        '
        'Dim xUndo As String = ""
        'Dim xRedo As String = ""
        '
        'Randomize()
        'For xI1 = 0 To 5
        '    xNI = Int(Rnd() * (7 - xI1) + xI1)
        '    If Not xNI = xI1 Then
        '        xInt = xCI(xI1)
        '        xCI(xI1) = xCI(xNI)
        '        xCI(xNI) = xInt
        '    End If
        'Next
        '
        'For xI1 = 1 To UBound(K)
        '    If K(xI1).Selected Then
        '        With K(xI1)
        '            Select Case .ColumnIndex
        '                Case niA1
        '                    xRedo &= sCmdKM(niA1, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(0)) - RealColumnToEnabled(niA1), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(0), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA1) - RealColumnToEnabled(xCI(0)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(0)
        '                Case niA2
        '                    xRedo &= sCmdKM(niA2, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(1)) - RealColumnToEnabled(niA2), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(1), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA2) - RealColumnToEnabled(xCI(1)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(1)
        '                Case niA3
        '                    xRedo &= sCmdKM(niA3, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(2)) - RealColumnToEnabled(niA3), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(2), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA3) - RealColumnToEnabled(xCI(2)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(2)
        '                Case niA4
        '                    xRedo &= sCmdKM(niA4, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(3)) - RealColumnToEnabled(niA4), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(3), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA4) - RealColumnToEnabled(xCI(3)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(3)
        '                Case niA5
        '                    xRedo &= sCmdKM(niA5, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(4)) - RealColumnToEnabled(niA5), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(4), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA5) - RealColumnToEnabled(xCI(4)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(4)
        '                Case niA6
        '                    xRedo &= sCmdKM(niA6, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(5)) - RealColumnToEnabled(niA6), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(5), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA6) - RealColumnToEnabled(xCI(5)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(5)
        '                Case niA7
        '                    xRedo &= sCmdKM(niA7, .VPosition, .Value, .LongNote, RealColumnToEnabled(xCI(6)) - RealColumnToEnabled(niA7), 0, True) & vbCrLf
        '                    xUndo &= sCmdKM(xCI(6), .VPosition, .Value, .LongNote, RealColumnToEnabled(niA7) - RealColumnToEnabled(xCI(6)), 0, True) & vbCrLf
        '                    .ColumnIndex = xCI(6)
        '            End Select
        '        End With
        '    End If
        'Next
        '
        'AddUndo(xUndo, xRedo)
        'UpdatePairing()
        'RefreshPanelAll()
    End Sub

    Private Sub POBMirror_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBMirror.Click
        Dim xI1 As Integer
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
        'xRedo &= sCmdKM(niA1, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, RealColumnToEnabled(niA7) - RealColumnToEnabled(niA1), 0, True) & vbCrLf
        'xUndo &= sCmdKM(niA7, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, RealColumnToEnabled(niA1) - RealColumnToEnabled(niA7), 0, True) & vbCrLf

        Dim xCol As Integer = 0
        For xI1 = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Select Case K(xI1).ColumnIndex
                Case niA1 : xCol = niA7
                Case niA2 : xCol = niA6
                Case niA3 : xCol = niA5
                Case niA4 : xCol = niA4
                Case niA5 : xCol = niA3
                Case niA6 : xCol = niA2
                Case niA7 : xCol = niA1
                Case Else : Continue For
            End Select

            Me.RedoMoveNote(K(xI1), xCol, K(xI1).VPosition, True, xUndo, xRedo)
            K(xI1).ColumnIndex = xCol
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub BWLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWLoad.Click
        Dim xDWAV As New OpenFileDialog
        xDWAV.Filter = Locale.FileType.WAV & "|*.wav"
        xDWAV.DefaultExt = "wav"
        xDWAV.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))

        If xDWAV.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDWAV.FileName)
        'Dim xByte As Byte() = My.Computer.FileSystem.ReadAllBytes(DImportWaveForm.FileName)
        'If xByte.Length < 48 Then Exit Sub 'If xByte.Length <= 44 Then Exit Sub 

        Dim xI1 As Integer
        '        ReDim wWavL((xByte.Length - 44) \ 4 - 1)
        '        ReDim wWavR((xByte.Length - 44) \ 4 - 1)
        '        For xI1 = 44 To UBound(xByte) Step 4
        '            wWavL((xI1 - 44) \ 4) = IIf(xByte(xI1 + 1) >= 128, _
        '                                        xByte(xI1) + xByte(xI1 + 1) * 256 - 65536, _
        '                                        xByte(xI1) + xByte(xI1 + 1) * 256)
        '            wWavR((xI1 - 44) \ 4) = IIf(xByte(xI1 + 3) >= 128, _
        '                                        xByte(xI1 + 2) + xByte(xI1 + 3) * 256 - 65536, _
        '                                        xByte(xI1 + 2) + xByte(xI1 + 3) * 256)
        '        Next

        Dim xFileLength As Long = FileSystem.FileLen(xDWAV.FileName)
        If xFileLength < 44 Then Exit Sub

        Dim xData As IO.BinaryReader = New IO.BinaryReader(New IO.FileStream(xDWAV.FileName, IO.FileMode.Open, FileAccess.Read))

        Dim xwChunkID As Integer = xData.ReadInt32
        Dim xwChunkSize As Integer = xData.ReadInt32
        Dim xwFormat As Integer = xData.ReadInt32

        Dim xwSubchunk1ID As Integer = xData.ReadInt32
        Dim xwSubchunk1Size As Integer = xData.ReadInt32
        Dim xwAudioFormat As Short = xData.ReadInt16
        Dim xwNumChannels As Short = xData.ReadInt16
        Dim xwSampleRate As Integer = xData.ReadInt32
        Dim xwByteRate As Integer = xData.ReadInt32
        Dim xwBlockAlign As Short = xData.ReadInt16
        Dim xwBitsPerSample As Short = xData.ReadInt16

        Dim xwCharDA As Short = 0
        Dim xwCharTA As Short = 0
        For xI2 As Integer = 0 To 64
            xwCharDA = xwCharTA
            xwCharTA = xData.ReadInt16

            If xwCharDA = &H6164 And xwCharTA = &H6174 Then
                Exit For
            End If
            If xI2 = 64 Then GoTo ErrFormat
        Next

        'Dim xwSubchunk2ID As Integer = xData.ReadInt32
        Dim xwSubchunk2Size As Integer = xData.ReadInt32

        If xFileLength < xwNumChannels * xwBitsPerSample / 8 + 44 Then GoTo ErrFormat
        If Not xwChunkID = &H46464952 Then GoTo ErrFormat
        If Not xwFormat = &H45564157 Then GoTo ErrFormat
        If Not xwSubchunk1ID = &H20746D66 Then GoTo ErrFormat
        'If Not xwSubchunk1Size = 16 Then GoTo ErrFormat
        If Not xwAudioFormat = 1 Then GoTo ErrFormat

        ReDim wWavL(xwSubchunk2Size \ (xwNumChannels * xwBitsPerSample \ 8) - 1)
        ReDim wWavR(xwSubchunk2Size \ (xwNumChannels * xwBitsPerSample \ 8) - 1)

        Dim xTemp As Byte
        Dim xTemp2 As Short
        Select Case xwNumChannels + xwBitsPerSample
            Case 9      '8b mono
                For xI1 = 0 To UBound(wWavL)
                    wWavL(xI1) = CShort(xData.ReadByte) * 256 - 32768
                    wWavR(xI1) = wWavL(xI1)
                Next

            Case 10     '8b stereo
                For xI1 = 0 To UBound(wWavL)
                    wWavL(xI1) = CShort(xData.ReadByte) * 256 - 32768
                    wWavR(xI1) = CShort(xData.ReadByte) * 256 - 32768
                Next

            Case 17     '16b mono
                For xI1 = 0 To UBound(wWavL)
                    wWavL(xI1) = xData.ReadInt16
                    wWavR(xI1) = wWavL(xI1)
                Next

            Case 18     '16b stereo
                For xI1 = 0 To UBound(wWavL)
                    wWavL(xI1) = xData.ReadInt16
                    wWavR(xI1) = xData.ReadInt16
                Next

            Case 25     '24b mono
                For xI1 = 0 To UBound(wWavL)
                    xTemp = xData.ReadByte
                    wWavL(xI1) = xData.ReadInt16
                    wWavR(xI1) = wWavL(xI1)
                Next

            Case 26     '24b stereo
                For xI1 = 0 To UBound(wWavL)
                    xTemp = xData.ReadByte
                    wWavL(xI1) = xData.ReadInt16
                    xTemp = xData.ReadByte
                    wWavR(xI1) = xData.ReadInt16
                Next

            Case 33     '32b mono
                For xI1 = 0 To UBound(wWavL)
                    xTemp2 = xData.ReadInt16
                    wWavL(xI1) = xData.ReadInt16
                    wWavR(xI1) = wWavL(xI1)
                Next

            Case 34     '32b stereo
                For xI1 = 0 To UBound(wWavL)
                    xTemp2 = xData.ReadInt16
                    wWavL(xI1) = xData.ReadInt16
                    xTemp2 = xData.ReadInt16
                    wWavR(xI1) = xData.ReadInt16
                Next

            Case Else
                Erase wWavL
                Erase wWavR
                GoTo ErrFormat
        End Select

        wBitsPerSample = xwBitsPerSample
        wSampleRate = xwSampleRate
        wNumChannels = xwNumChannels

        TWFileName.Text = xDWAV.FileName
        TWFileName.Select(Len(xDWAV.FileName), 0)
        RefreshPanelAll()
ErrFormat:
        xData.Close()
    End Sub

    Private Sub BWClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWClear.Click
        Erase wWavL
        Erase wWavR
        TWFileName.Text = "(" & Locale.None & ")"
        RefreshPanelAll()
    End Sub

    Private Sub BWLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWLock.CheckedChanged
        wLock = BWLock.Checked
        TWPosition.Enabled = Not wLock
        TWPosition2.Enabled = Not wLock
        RefreshPanelAll()
    End Sub

    Private Sub BVCApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVCApply.Click
        If Not TBTimeSelect.Checked Then Exit Sub

        SortByVPositionInsertion()
        BPMChangeTop(Val(TVCM.Text) / Val(TVCD.Text))

        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
        POStatusRefresh()
        CalculateGreatestVPosition()

        Beep()
        TVCM.Focus()
        'Select Case spFocus
        '    Case 0 : PMainInL.Focus()
        '    Case 1 : PMainIn.Focus()
        '    Case 2 : PMainInR.Focus()
        'End Select
    End Sub

    Private Sub BVCCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVCCalculate.Click
        If Not TBTimeSelect.Checked Then Exit Sub

        SortByVPositionInsertion()
        BPMChangeByValue(Val(TVCBPM.Text) * 10000)

        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
        POStatusRefresh()

        Beep()
        TVCBPM.Focus()
        'Select Case spFocus
        '    Case 0 : PMainInL.Focus()
        '    Case 1 : PMainIn.Focus()
        '    Case 2 : PMainInR.Focus()
        'End Select
    End Sub

    Private Sub ValidateSelection()
        If vSelStart < 0 Then vSelLength += vSelStart : vSelHalf += vSelStart : vSelStart = 0
        If vSelStart > VPosition1000() - 1 Then vSelLength += vSelStart - VPosition1000() + 1 : vSelHalf += vSelStart - VPosition1000() + 1 : vSelStart = VPosition1000() - 1
        If vSelStart + vSelLength < 0 Then vSelLength = -vSelStart
        If vSelStart + vSelLength > VPosition1000() - 1 Then vSelLength = VPosition1000() - 1 - vSelStart

        If Math.Sign(vSelHalf) <> Math.Sign(vSelLength) Then vSelHalf = 0
        If Math.Abs(vSelHalf) > Math.Abs(vSelLength) Then vSelHalf = vSelLength
    End Sub

    Private Sub BPMChangeTop(ByVal xRatio As Double, Optional ByVal bAddUndo As Boolean = True, Optional ByVal bOverWriteUndo As Boolean = False)
        'Dim xUndo As String = vbCrLf
        'Dim xRedo As String = vbCrLf
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        If vSelLength = 0 Then GoTo EndofSub
        If xRatio = 1 Or xRatio <= 0 Then GoTo EndofSub

        Dim xVLower As Double = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        Dim xVUpper As Double = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If xVLower < 0 Then xVLower = 0
        If xVUpper >= VPosition1000() Then xVUpper = VPosition1000() - 1

        Dim xBPM As Integer = K(0).Value
        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer

        Dim xValueL As Integer = xBPM
        Dim xValueU As Integer = xBPM

        'Save undo
        'For xI3 = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xUndo = "KZ" & vbCrLf & _
        '        sCmdKs(False) & vbCrLf & _
        '        "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        'Start
        If Not NTInput Then
            'Below Selection
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition > xVLower Then Exit For
                If K(xI1).ColumnIndex = niBPM Then xBPM = K(xI1).Value
            Next
            xValueL = xBPM
            xI2 = xI1

            'Within Selection
            For xI1 = xI2 To UBound(K)
                If K(xI1).VPosition > xVUpper Then Exit For
                If K(xI1).ColumnIndex = niBPM Then
                    xBPM = K(xI1).Value
                    K(xI1).Value = IIf(K(xI1).Value * xRatio <= 655359999, K(xI1).Value * xRatio, 655359999)
                End If
                K(xI1).VPosition = (K(xI1).VPosition - xVLower) * xRatio + xVLower
            Next
            xValueU = xBPM
            xI2 = xI1

            'Above Selection
            For xI1 = xI2 To UBound(K)
                K(xI1).VPosition += (xRatio - 1) * (xVUpper - xVLower)
            Next

            'Add BPMs
            AddNote(xVLower, niBPM, IIf(xValueL * xRatio <= 655359999, xValueL * xRatio, 655359999), False, False, , , False)
            AddNote(xVUpper + (xRatio - 1) * (xVUpper - xVLower), niBPM, xValueU, False, False, , , False)

        Else
            Dim xAddBPML As Boolean = True
            Dim xAddBPMU As Boolean = True

            For xI1 = 1 To UBound(K)
                'Modify notes
                If K(xI1).VPosition <= xVLower Then
                    'check BPM
                    If K(xI1).ColumnIndex = niBPM Then
                        xValueL = K(xI1).Value
                        xValueU = K(xI1).Value
                        If K(xI1).VPosition = xVLower Then xAddBPML = False : K(xI1).Value = IIf(K(xI1).Value * xRatio <= 655359999, K(xI1).Value * xRatio, 655359999)
                    End If

                    'If longnote then adjust length
                    If K(xI1).VPosition + K(xI1).Length > xVLower Then
                        K(xI1).Length += (IIf(xVUpper < K(xI1).VPosition + K(xI1).Length, xVUpper, K(xI1).VPosition + K(xI1).Length) - xVLower) * (xRatio - 1)
                    End If

                ElseIf K(xI1).VPosition <= xVUpper Then
                    'check BPM
                    If K(xI1).ColumnIndex = niBPM Then
                        xValueU = K(xI1).Value
                        If K(xI1).VPosition = xVUpper Then xAddBPMU = False Else K(xI1).Value = IIf(K(xI1).Value * xRatio <= 655359999, K(xI1).Value * xRatio, 655359999)
                    End If

                    'Adjust Length
                    K(xI1).Length += (IIf(xVUpper < K(xI1).Length + K(xI1).VPosition, xVUpper, K(xI1).Length + K(xI1).VPosition) - K(xI1).VPosition) * (xRatio - 1)

                    'Adjust VPosition
                    K(xI1).VPosition = (K(xI1).VPosition - xVLower) * xRatio + xVLower

                Else
                    K(xI1).VPosition += (xVUpper - xVLower) * (xRatio - 1)
                End If
            Next

            'Add BPMs
            If xAddBPML Then AddNote(xVLower, niBPM, IIf(xValueL * xRatio <= 655359999, xValueL * xRatio, 655359999), False, False, , , False)
            If xAddBPMU Then AddNote((xVUpper - xVLower) * xRatio + xVLower, niBPM, xValueU, False, False, , , False)
        End If

        'Check BPM Overflow
        For xI3 = 1 To UBound(K)
            If K(xI3).ColumnIndex = niBPM AndAlso K(xI3).Value < 1 Then K(xI3).Value = 1
        Next

        Me.RedoAddNoteAll(False, xUndo, xRedo)

        'Restore selection
        Dim pSelStart As Double = vSelStart
        Dim pSelLength As Double = vSelLength
        Dim pSelHalf As Double = vSelHalf
        If vSelLength < 0 Then vSelStart += (xRatio - 1) * (xVUpper - xVLower)
        vSelLength = vSelLength * xRatio
        vSelHalf = vSelHalf * xRatio
        ValidateSelection()
        Me.RedoChangeTimeSelection(pSelStart, pSelLength, pSelHalf, vSelStart, vSelLength, vSelHalf, True, xUndo, xRedo)

        'Save redo
        'For xI3 = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xRedo = "KZ" & vbCrLf & _
        '                      sCmdKs(False) & vbCrLf & _
        '                      "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        'Restore note selection
        xVLower = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        xVUpper = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If Not NTInput Then
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition >= xVLower And K(xI3).VPosition < xVUpper And nEnabled(K(xI3).ColumnIndex)
            Next
        Else
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition < xVUpper And K(xI3).VPosition + K(xI3).Length >= xVLower And nEnabled(K(xI3).ColumnIndex)
            Next
        End If

EndofSub:
        If bAddUndo Then AddUndo(xUndo, xBaseRedo.Next, bOverWriteUndo)
    End Sub

    Private Sub BPMChangeHalf(ByVal dVPosition As Double, Optional ByVal bAddUndo As Boolean = True, Optional ByVal bOverWriteUndo As Boolean = False)
        'Dim xUndo As String = vbCrLf
        'Dim xRedo As String = vbCrLf
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        If vSelLength = 0 Then GoTo EndofSub
        If dVPosition = 0 Then GoTo EndofSub

        Dim xVLower As Double = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        Dim xVHalf As Double = vSelStart + vSelHalf
        Dim xVUpper As Double = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If dVPosition + xVHalf <= xVLower Or dVPosition + xVHalf >= xVUpper Then GoTo EndofSub

        If xVLower < 0 Then xVLower = 0
        If xVUpper >= VPosition1000() Then xVUpper = VPosition1000() - 1
        If xVHalf > xVUpper Then xVHalf = xVUpper
        If xVHalf < xVLower Then xVHalf = xVLower

        Dim xBPM As Integer = K(0).Value
        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer

        Dim xValueL As Integer = xBPM
        Dim xValueM As Integer = xBPM
        Dim xValueU As Integer = xBPM

        Dim xRatio1 As Double = (xVHalf - xVLower + dVPosition) / (xVHalf - xVLower)
        Dim xRatio2 As Double = (xVUpper - xVHalf - dVPosition) / (xVUpper - xVHalf)

        'Save undo
        'For xI3 = 1 To UBound(K)
        'K(xI3).Selected = True
        'Next
        'xUndo = "KZ" & vbCrLf & _
        '        sCmdKs(False) & vbCrLf & _
        '        "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        If Not NTInput Then
            'Below Selection
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition > xVLower Then Exit For
                If K(xI1).ColumnIndex = niBPM Then xBPM = K(xI1).Value
            Next
            xValueL = xBPM
            xI2 = xI1

            'Below Half
            For xI1 = xI2 To UBound(K)
                If K(xI1).VPosition > xVHalf Then Exit For
                If K(xI1).ColumnIndex = niBPM Then
                    xBPM = K(xI1).Value
                    K(xI1).Value = IIf(K(xI1).Value * xRatio1 <= 655359999, K(xI1).Value * xRatio1, 655359999)
                End If
                K(xI1).VPosition = (K(xI1).VPosition - xVLower) * xRatio1 + xVLower
            Next
            xValueM = xBPM
            xI2 = xI1

            'Above Half
            For xI1 = xI2 To UBound(K)
                If K(xI1).VPosition > xVUpper Then Exit For
                If K(xI1).ColumnIndex = niBPM Then
                    xBPM = K(xI1).Value
                    K(xI1).Value = IIf(K(xI1).Value * xRatio2 <= 655359999, K(xI1).Value * xRatio2, 655359999)
                End If
                K(xI1).VPosition = (K(xI1).VPosition - xVHalf) * xRatio2 + xVHalf + dVPosition
            Next
            xValueU = xBPM
            xI2 = xI1

            'Above Selection
            'For xI1 = xI2 To UBound(K)
            '    K(xI1).VPosition += (xRatio - 1) * (xVUpper - xVLower)
            'Next

            'Add BPMs
            AddNote(xVLower, niBPM, IIf(xVHalf <> xVLower AndAlso xValueL * xRatio1 <= 655359999, xValueL * xRatio1, 655359999), False, False, , , False)
            AddNote(xVHalf + dVPosition, niBPM, IIf(xVHalf <> xVUpper AndAlso xValueM * xRatio2 <= 655359999, xValueM * xRatio2, 655359999), False, False, , , False)
            AddNote(xVUpper, niBPM, xValueU, False, False, , , False)

        Else
            Dim xAddBPML As Boolean = True
            Dim xAddBPMM As Boolean = True
            Dim xAddBPMU As Boolean = True

            'Modify notes
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition <= xVLower Then
                    'check BPM
                    If K(xI1).ColumnIndex = niBPM Then
                        xValueL = K(xI1).Value
                        xValueM = K(xI1).Value
                        xValueU = K(xI1).Value
                        If K(xI1).VPosition = xVLower Then
                            xAddBPML = False
                            K(xI1).Value = IIf(xVHalf <> xVLower AndAlso K(xI1).Value * xRatio1 <= 655359999, K(xI1).Value * xRatio1, 655359999)
                        End If
                    End If

                    'If longnote then adjust length
                    Dim xEnd As Double = K(xI1).VPosition + K(xI1).Length
                    If xEnd > xVUpper Then
                    ElseIf xEnd > xVHalf Then
                        K(xI1).Length = (xEnd - xVHalf) * xRatio2 + xVHalf + dVPosition - K(xI1).VPosition
                    ElseIf xEnd > xVLower Then
                        K(xI1).Length = (xEnd - xVLower) * xRatio1 + xVLower - K(xI1).VPosition
                    End If

                ElseIf K(xI1).VPosition <= xVHalf Then
                    'check BPM
                    If K(xI1).ColumnIndex = niBPM Then
                        xValueM = K(xI1).Value
                        xValueU = K(xI1).Value
                        If K(xI1).VPosition = xVHalf Then
                            xAddBPMM = False
                            K(xI1).Value = IIf(xVHalf <> xVUpper AndAlso K(xI1).Value * xRatio2 <= 655359999, K(xI1).Value * xRatio2, 655359999)
                        Else
                            K(xI1).Value = IIf(K(xI1).Value * xRatio1 <= 655359999, K(xI1).Value * xRatio1, 655359999)
                        End If
                    End If

                    'Adjust Length
                    Dim xEnd As Double = K(xI1).VPosition + K(xI1).Length
                    If xEnd > xVUpper Then
                        K(xI1).Length = xEnd - xVLower - (K(xI1).VPosition - xVLower) * xRatio1
                    ElseIf xEnd > xVHalf Then
                        K(xI1).Length = (xVHalf - K(xI1).VPosition) * xRatio1 + (xEnd - xVHalf) * xRatio2
                    Else
                        K(xI1).Length *= xRatio1
                    End If

                    'Adjust VPosition
                    K(xI1).VPosition = (K(xI1).VPosition - xVLower) * xRatio1 + xVLower

                ElseIf K(xI1).VPosition <= xVUpper Then
                    'check BPM
                    If K(xI1).ColumnIndex = niBPM Then
                        xValueU = K(xI1).Value
                        If K(xI1).VPosition = xVUpper Then xAddBPMU = False Else K(xI1).Value = IIf(K(xI1).Value * xRatio2 <= 655359999, K(xI1).Value * xRatio2, 655359999)
                    End If

                    'Adjust Length
                    Dim xEnd As Double = K(xI1).VPosition + K(xI1).Length
                    If xEnd > xVUpper Then
                        K(xI1).Length = (xVUpper - K(xI1).VPosition) * xRatio2 + xEnd - xVUpper
                    Else
                        K(xI1).Length *= xRatio2
                    End If

                    'Adjust VPosition
                    K(xI1).VPosition = (K(xI1).VPosition - xVHalf) * xRatio2 + xVHalf + dVPosition

                    'Else
                    '    K(xI1).VPosition += (xVUpper - xVLower) * (xRatio - 1)
                End If
            Next

            'Add BPMs
            If xAddBPML Then AddNote(xVLower, niBPM, IIf(xVHalf <> xVLower AndAlso xValueL * xRatio1 <= 655359999, xValueL * xRatio1, 655359999), False, False, , , False)
            If xAddBPMM Then AddNote(xVHalf + dVPosition, niBPM, IIf(xVHalf <> xVUpper AndAlso xValueM * xRatio2 <= 655359999, xValueM * xRatio2, 655359999), False, False, , , False)
            If xAddBPMU Then AddNote(xVUpper, niBPM, xValueU, False, False, , , False)
        End If

        'Check BPM Overflow
        For xI3 = 1 To UBound(K)
            If K(xI3).ColumnIndex = niBPM Then
                If K(xI3).Value > 655359999 Then K(xI3).Value = 655359999
                If K(xI3).Value < 1 Then K(xI3).Value = 1
            End If
        Next

        'Restore selection
        'If vSelLength < 0 Then vSelStart += (xRatio - 1) * (xVUpper - xVLower)
        'vSelLength = vSelLength * xRatio
        Dim pSelHalf As Double = vSelHalf
        vSelHalf += dVPosition
        ValidateSelection()
        Me.RedoChangeTimeSelection(vSelStart, vSelLength, pSelHalf, vSelStart, vSelStart, vSelHalf, True, xUndo, xRedo)

        Me.RedoAddNoteAll(False, xUndo, xRedo)

        'Save redo
        'For xI3 = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xRedo = "KZ" & vbCrLf & _
        '                      sCmdKs(False) & vbCrLf & _
        '                      "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        'Restore note selection
        xVLower = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        xVUpper = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If Not NTInput Then
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition >= xVLower And K(xI3).VPosition < xVUpper And nEnabled(K(xI3).ColumnIndex)
            Next
        Else
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition < xVUpper And K(xI3).VPosition + K(xI3).Length >= xVLower And nEnabled(K(xI3).ColumnIndex)
            Next
        End If

EndofSub:
        If bAddUndo Then AddUndo(xUndo, xBaseRedo.Next, bOverWriteUndo)
    End Sub

    Private Sub BPMChangeByValue(ByVal xValue As Integer)
        'Dim xUndo As String = vbCrLf
        'Dim xRedo As String = vbCrLf
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        If vSelLength = 0 Then Return

        Dim xVLower As Double = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        Dim xVHalf As Double = vSelStart + vSelHalf
        Dim xVUpper As Double = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If xVHalf = xVUpper Then xVHalf = xVLower
        'If dVPosition + xVHalf <= xVLower Or dVPosition + xVHalf >= xVUpper Then GoTo EndofSub

        If xVLower < 0 Then xVLower = 0
        If xVUpper >= VPosition1000() Then xVUpper = VPosition1000() - 1
        If xVHalf > xVUpper Then xVHalf = xVUpper
        If xVHalf < xVLower Then xVHalf = xVLower

        Dim xBPM As Integer = K(0).Value
        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer

        Dim xConstBPM As Double = 0

        'Below Selection
        For xI1 = 1 To UBound(K)
            If K(xI1).VPosition > xVLower Then Exit For
            If K(xI1).ColumnIndex = niBPM Then xBPM = K(xI1).Value
        Next
        xI2 = xI1
        Dim xVPos() As Double = {xVLower}
        Dim xVal() As Integer = {xBPM}

        'Within Selection
        Dim xU As Integer = 0
        For xI1 = xI2 To UBound(K)
            If K(xI1).VPosition > xVUpper Then Exit For

            If K(xI1).ColumnIndex = niBPM Then
                xU = UBound(xVPos) + 1
                ReDim Preserve xVPos(xU)
                ReDim Preserve xVal(xU)
                xVPos(xU) = K(xI1).VPosition
                xVal(xU) = K(xI1).Value
            End If
        Next
        ReDim Preserve xVPos(xU + 1)
        xVPos(xU + 1) = xVUpper

        'Calculate Constant BPM
        For xI1 = 0 To xU
            xConstBPM += (xVPos(xI1 + 1) - xVPos(xI1)) / xVal(xI1)
        Next
        xConstBPM = (xVUpper - xVLower) / xConstBPM

        'Compare BPM        '(xVHalf - xVLower) / xValue + (xVUpper - xVHalf) / xResult = (xVUpper - xVLower) / xConstBPM
        If (xVUpper - xVLower) / xConstBPM < (xVHalf - xVLower) / xValue Or xValue > 655359999 Then _
            MsgBox("Please enter a value between " & ((xVHalf - xVLower) * xConstBPM / (xVUpper - xVLower) / 10000) & " and 65535.9999.", MsgBoxStyle.Critical, Locale.Messages.Err) : Return
        Dim xResult As Integer
        Dim xTempDivider As Double = xConstBPM * xVHalf - xConstBPM * xVLower - xValue * xVUpper + xValue * xVLower
        Dim xTemp001 As Double = (xVHalf - xVUpper) * xValue * xConstBPM / xTempDivider
        If xTempDivider >= 0 Or _
          (xVHalf - xVUpper) * xValue * xConstBPM / xTempDivider > 655359999 Then
            xResult = 655359999
        Else
            xResult = (xVHalf - xVUpper) * xValue * xConstBPM / xTempDivider
        End If

        'Save undo
        'For xI3 = 1 To UBound(K)
        ' K(xI3).Selected = True
        ' Next
        ' xUndo = "KZ" & vbCrLf & _
        '         sCmdKs(False) & vbCrLf & _
        '         "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        'Adjust note
        If Not NTInput Then
            'Below Selection
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition > xVLower Then Exit For
            Next
            xI2 = xI1
            If xI2 > UBound(K) Then GoTo EndOfAdjustment

            'Within Selection
            Dim xTempTime As Double
            Dim xTempVPos As Double
            For xI1 = xI2 To UBound(K)
                If K(xI1).VPosition >= xVUpper Then Exit For
                xTempTime = 0

                xTempVPos = K(xI1).VPosition
                For xI3 = 0 To xU
                    If xTempVPos < xVPos(xI3 + 1) Then Exit For
                    xTempTime += (xVPos(xI3 + 1) - xVPos(xI3)) / xVal(xI3)
                Next
                xTempTime += (xTempVPos - xVPos(xI3)) / xVal(xI3)

                If xTempTime - (xVHalf - xVLower) / xValue > 0 Then
                    K(xI1).VPosition = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf
                Else
                    K(xI1).VPosition = xTempTime * xValue + xVLower
                End If
            Next

        Else
            Dim xTempTime As Double
            Dim xTempVPos As Double
            Dim xTempEnd As Double

            For xI1 = 1 To UBound(K)
                If K(xI1).Length Then xTempEnd = K(xI1).VPosition + K(xI1).Length

                If K(xI1).VPosition > xVLower And K(xI1).VPosition < xVUpper Then
                    xTempTime = 0

                    xTempVPos = K(xI1).VPosition
                    For xI3 = 0 To xU
                        If xTempVPos < xVPos(xI3 + 1) Then Exit For
                        xTempTime += (xVPos(xI3 + 1) - xVPos(xI3)) / xVal(xI3)
                    Next
                    xTempTime += (xTempVPos - xVPos(xI3)) / xVal(xI3)

                    If xTempTime - (xVHalf - xVLower) / xValue > 0 Then
                        K(xI1).VPosition = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf
                    Else
                        K(xI1).VPosition = xTempTime * xValue + xVLower
                    End If
                End If

                If K(xI1).Length Then
                    If xTempEnd > xVLower And xTempEnd < xVUpper Then
                        xTempTime = 0

                        For xI3 = 0 To xU
                            If xTempEnd < xVPos(xI3 + 1) Then Exit For
                            xTempTime += (xVPos(xI3 + 1) - xVPos(xI3)) / xVal(xI3)
                        Next
                        xTempTime += (xTempEnd - xVPos(xI3)) / xVal(xI3)

                        If xTempTime - (xVHalf - xVLower) / xValue > 0 Then
                            K(xI1).Length = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf - K(xI1).VPosition
                        Else
                            K(xI1).Length = xTempTime * xValue + xVLower - K(xI1).VPosition
                        End If

                    Else
                        K(xI1).Length = xTempEnd - K(xI1).VPosition
                    End If
                End If

            Next
        End If

EndOfAdjustment:

        'Delete BPMs
        xI1 = 1
        Do While xI1 <= UBound(K)
            If K(xI1).VPosition > xVUpper Then Exit Do
            If K(xI1).VPosition >= xVLower And K(xI1).ColumnIndex = niBPM Then
                For xI3 = xI1 + 1 To UBound(K)
                    K(xI3 - 1) = K(xI3)
                Next
                ReDim Preserve K(UBound(K) - 1)
            Else
                xI1 += 1
            End If
        Loop

        'Add BPMs
        ReDim Preserve K(UBound(K) + 2)
        With K(UBound(K) - 1)
            .ColumnIndex = niBPM
            .VPosition = xVHalf
            .Value = xResult
        End With
        With K(UBound(K))
            .ColumnIndex = niBPM
            .VPosition = xVUpper
            .Value = xVal(xU)
        End With
        If xVLower <> xVHalf Then
            ReDim Preserve K(UBound(K) + 1)
            With K(UBound(K))
                .ColumnIndex = niBPM
                .VPosition = xVLower
                .Value = xValue
            End With
        End If

        'Save redo
        'For xI3 = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xRedo = "KZ" & vbCrLf & _
        '                      sCmdKs(False) & vbCrLf & _
        '                      "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"
        Me.RedoAddNoteAll(False, xUndo, xRedo)

        'Restore note selection
        xVLower = IIf(vSelLength > 0, vSelStart, vSelStart + vSelLength)
        xVUpper = IIf(vSelLength < 0, vSelStart, vSelStart + vSelLength)
        If Not NTInput Then
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition >= xVLower And K(xI3).VPosition < xVUpper And nEnabled(K(xI3).ColumnIndex)
            Next
        Else
            For xI3 = 1 To UBound(K)
                K(xI3).Selected = K(xI3).VPosition < xVUpper And K(xI3).VPosition + K(xI3).Length >= xVLower And nEnabled(K(xI3).ColumnIndex)
            Next
        End If

        'EndofSub:
        AddUndo(xUndo, xBaseRedo.Next)
    End Sub

    Private Sub TVCM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TVCM.KeyDown
        If e.KeyCode = Keys.Enter Then
            TVCM.Text = Val(TVCM.Text)
            If Val(TVCM.Text) <= 0 Then
                MsgBox(Locale.Messages.NegativeFactorError, MsgBoxStyle.Critical, Locale.Messages.Err)
                TVCM.Text = 1
                TVCM.Focus()
                TVCM.SelectAll()
            Else
                BVCApply_Click(BVCApply, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub TVCM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TVCM.LostFocus
        TVCM.Text = Val(TVCM.Text)
        If Val(TVCM.Text) <= 0 Then
            MsgBox(Locale.Messages.NegativeFactorError, MsgBoxStyle.Critical, Locale.Messages.Err)
            TVCM.Text = 1
            TVCM.Focus()
            TVCM.SelectAll()
        End If
    End Sub

    Private Sub TVCD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TVCD.KeyDown
        If e.KeyCode = Keys.Enter Then
            TVCD.Text = Val(TVCD.Text)
            If Val(TVCD.Text) <= 0 Then
                MsgBox(Locale.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Locale.Messages.Err)
                TVCD.Text = 1
                TVCD.Focus()
                TVCD.SelectAll()
            Else
                BVCApply_Click(BVCApply, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub TVCD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TVCD.LostFocus
        TVCD.Text = Val(TVCD.Text)
        If Val(TVCD.Text) <= 0 Then
            MsgBox(Locale.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Locale.Messages.Err)
            TVCD.Text = 1
            TVCD.Focus()
            TVCD.SelectAll()
        End If
    End Sub

    Private Sub TVCBPM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TVCBPM.KeyDown
        If e.KeyCode = Keys.Enter Then
            TVCBPM.Text = Val(TVCBPM.Text)
            If Val(TVCBPM.Text) <= 0 Then
                MsgBox(Locale.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Locale.Messages.Err)
                TVCBPM.Text = K(0).Value / 10000
                TVCBPM.Focus()
                TVCBPM.SelectAll()
            Else
                BVCCalculate_Click(BVCCalculate, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub TVCBPM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TVCBPM.LostFocus
        TVCBPM.Text = Val(TVCBPM.Text)
        If Val(TVCBPM.Text) <= 0 Then
            MsgBox(Locale.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Locale.Messages.Err)
            TVCBPM.Text = K(0).Value / 10000
            TVCBPM.Focus()
            TVCBPM.SelectAll()
        End If
    End Sub

    Private Function FindNoteIndex(ByVal nColumnIndex As Integer, ByVal nVposition As Double, ByVal nValue As Integer, ByVal nLongNote As Double, ByVal nHidden As Boolean) As Integer
        Dim xI1 As Integer
        If NTInput Then
            For xI1 = 1 To UBound(K)
                If K(xI1).equalsNT(nColumnIndex, nVposition, nValue, nLongNote, nHidden) Then Return xI1
            Next
        Else
            For xI1 = 1 To UBound(K)
                If K(xI1).equalsBMSE(nColumnIndex, nVposition, nValue, nLongNote, nHidden) Then Return xI1
            Next
        End If
        Return xI1
    End Function

    Private Sub Operate(ByVal sCmd As UndoRedo.LinkedURCmd)
        For xI2 As Integer = 1 To UBound(K)
            K(xI2).Selected = False
        Next
        LBeat.SelectedIndices.Clear()

        Do While sCmd IsNot Nothing
            Dim xType As Byte = sCmd.ofType

            Select Case xType
                Case UndoRedo.opAddNote
                    Dim xCmd As UndoRedo.AddNote = sCmd

                    ReDim Preserve K(UBound(K) + 1)
                    With K(UBound(K))
                        .ColumnIndex = xCmd.ColumnIndex
                        .VPosition = xCmd.VPosition
                        .Value = xCmd.Value
                        If NTInput Then .Length = xCmd.LongNote Else .LongNote = xCmd.LongNote
                        .Hidden = xCmd.Hidden
                        .Selected = xCmd.Selected And nEnabled(.ColumnIndex)
                    End With

                Case UndoRedo.opRemoveNote
                    Dim xCmd As UndoRedo.RemoveNote = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        For xI3 As Integer = xI2 + 1 To UBound(K)
                            K(xI3 - 1) = K(xI3)
                        Next
                        ReDim Preserve K(UBound(K) - 1)
                    End If

                Case UndoRedo.opChangeNote
                    Dim xCmd As UndoRedo.ChangeNote = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        With K(xI2)
                            .ColumnIndex = xCmd.NColumnIndex
                            .VPosition = xCmd.NVPosition
                            .Value = xCmd.NValue
                            If NTInput Then .Length = xCmd.NLongNote Else .LongNote = xCmd.LongNote
                            .Hidden = xCmd.NHidden
                            .Selected = xCmd.Selected And nEnabled(.ColumnIndex)
                        End With
                    End If

                Case UndoRedo.opMoveNote
                    Dim xCmd As UndoRedo.MoveNote = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        With K(xI2)
                            .ColumnIndex = xCmd.NColumnIndex
                            .VPosition = xCmd.NVPosition
                            .Selected = xCmd.Selected And nEnabled(.ColumnIndex)
                        End With
                    End If

                Case UndoRedo.opLongNoteModify
                    Dim xCmd As UndoRedo.LongNoteModify = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        With K(xI2)
                            If NTInput Then
                                .VPosition = xCmd.NVPosition
                                .Length = xCmd.NLongNote
                            Else
                                .LongNote = xCmd.NLongNote
                            End If
                            .Selected = xCmd.Selected And nEnabled(.ColumnIndex)
                        End With
                    End If

                Case UndoRedo.opHiddenNoteModify
                    Dim xCmd As UndoRedo.HiddenNoteModify = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        K(xI2).Hidden = xCmd.NHidden
                        K(xI2).Selected = xCmd.Selected And nEnabled(K(xI2).ColumnIndex)
                    End If

                Case UndoRedo.opRelabelNote
                    Dim xCmd As UndoRedo.RelabelNote = sCmd
                    Dim xI2 As Integer = FindNoteIndex(xCmd.ColumnIndex, xCmd.VPosition, xCmd.Value, xCmd.LongNote, xCmd.Hidden)

                    If xI2 < K.Length Then
                        K(xI2).Value = xCmd.NValue
                        K(xI2).Selected = xCmd.Selected And nEnabled(K(xI2).ColumnIndex)
                    End If

                Case UndoRedo.opRemoveAllNotes
                    ReDim Preserve K(0)

                Case UndoRedo.opChangeMeasureLength
                    Dim xCmd As UndoRedo.ChangeMeasureLength = sCmd
                    Dim xxD As Long = GetDenominator(xCmd.Value / 192)
                    'Dim xDenom As Integer = 192 / GCD(xCmd.Value, 192.0R)
                    'If xDenom < 4 Then xDenom = 4
                    For Each xM As Integer In xCmd.Indices
                        MeasureLength(xM) = xCmd.Value
                        LBeat.Items(xM) = Add3Zeros(xM) & ": " & (xCmd.Value / 192) & IIf(xxD > 10000, "", " ( " & CLng(xCmd.Value / 192 * xxD) & " / " & xxD & " ) ")
                        LBeat.SelectedIndices.Add(xM)
                    Next
                    UpdateMeasureBottom()

                Case UndoRedo.opChangeTimeSelection
                    Dim xCmd As UndoRedo.ChangeTimeSelection = sCmd
                    vSelStart = xCmd.SelStart
                    vSelLength = xCmd.SelLength
                    vSelHalf = xCmd.SelHalf
                    If xCmd.Selected Then
                        Dim xSelLo As Double = vSelStart + IIf(vSelLength < 0, vSelLength, 0)
                        Dim xSelHi As Double = vSelStart + IIf(vSelLength > 0, vSelLength, 0)
                        For xI2 As Integer = 1 To UBound(K)
                            K(xI2).Selected = K(xI2).VPosition >= xSelLo AndAlso _
                                              K(xI2).VPosition < xSelHi AndAlso _
                                              nEnabled(K(xI2).ColumnIndex)
                        Next
                    End If

                Case UndoRedo.opNT
                    Dim xCmd As UndoRedo.NT = sCmd
                    NTInput = xCmd.BecomeNT
                    TBNTInput.Checked = NTInput
                    mnNTInput.Checked = NTInput

                    POBLong.Enabled = Not NTInput
                    POBLongShort.Enabled = Not NTInput
                    bAdjustLength = False
                    bAdjustUpper = False

                    If xCmd.AutoConvert Then
                        If NTInput Then ConvertBMSE2NT() Else ConvertNT2BMSE()
                    End If

                    'Case UndoRedo.opChangeVisibleColumns
                    '    Dim xCmd As UndoRedo.ChangeVisibleColumns = sCmd
                    '    IsInitializing = True
                    '    CGBLP.Checked = xCmd.CGBLP
                    '    CGSTOP.Checked = xCmd.CGSTOP
                    '    CHPlayer.SelectedIndex = xCmd.CHPlayer
                    '    IsInitializing = False
                    '    For xI2 As Integer = 1 To UBound(K)
                    '        K(xI2).Selected = K(xI2).Selected And nEnabled(K(xI2).ColumnIndex)
                    '    Next
                    '    UpdateKLeft()

                Case UndoRedo.opVoid

                Case UndoRedo.opNoOperation
                    'Exit Do

            End Select

            sCmd = sCmd.Next
        Loop

        THBPM.Value = K(0).Value / 10000
        If IsSaved Then SetIsSaved(False)

        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    'Private Sub Operate(ByVal sCommand As String)
    '    Dim xLine() As String = Split(UCase(sCommand), vbCrLf)
    '    Dim xArg() As String
    '    Dim xI1 As Integer
    '    Dim xI2 As Integer
    '    Dim xI3 As Integer
    '
    '    Dim xColumnIndex As Integer
    '    Dim xVPosition As Double
    '    Dim xValue As Integer
    '    Dim xLong As Double
    '    Dim xHidden As Boolean
    '
    '    Dim dfDColumnIndex As Integer = 0
    '    Dim dfDVPosition As Double = 0
    '
    '    For xI2 = 1 To UBound(K)
    '        K(xI2).Selected = False
    '    Next
    '
    '    If InStr(sCommand, "CB_") Then LBeat.SelectedIndices.Clear()
    '
    '    For xI1 = 0 To UBound(xLine)
    '        xArg = Split(xLine(xI1), "_")
    '
    '        Select Case xArg(0)
    '            Case "K"
    '                'Add a note
    '                'K_ColumnIndex_VPosition_Value_LongNote_Hidden_Select
    '                If Not UBound(xArg) = 6 Then Exit Select
    '                ReDim Preserve K(UBound(K) + 1)
    '                With K(UBound(K))
    '                    .ColumnIndex = Val(xArg(1))
    '                    .VPosition = Val(xArg(2))
    '                    .Value = Val(xArg(3))
    '                    If NTInput Then .Length = Val(xArg(4)) Else .LongNote = CBool(Val(xArg(4)))
    '                    .Hidden = CBool(Val(xArg(5)))
    '                    .Selected = CBool(Val(xArg(6))) And nEnabled(.ColumnIndex)
    '                End With
    '
    '            Case "KD"
    '                'Remove a note
    '                'KD_ColumnIndex_VPosition_Value_LongNote_Hidden
    '                If Not UBound(xArg) = 5 Then Exit Select
    '                xColumnIndex = Val(xArg(1))
    '                xVPosition = Val(xArg(2))
    '                xValue = Val(xArg(3))
    '                xLong = Val(xArg(4))
    '                xHidden = CBool(Val(xArg(5)))
    '
    '                For xI2 = 1 To UBound(K)
    '                    If K(xI2).ColumnIndex = xColumnIndex And _
    '                       dbleql(K(xI2).VPosition, xVPosition) And _
    '                       K(xI2).Value = xValue And _
    '                       IIf(NTInput, dbleql(K(xI2).Length, xLong), K(xI2).LongNote = CBool(xLong)) And _
    '                       K(xI2).Hidden = xHidden Then
    '
    '                        For xI3 = xI2 + 1 To UBound(K)
    '                            K(xI3 - 1) = K(xI3)
    '                        Next
    '                        ReDim Preserve K(UBound(K) - 1)
    '                        Exit For
    '                    End If
    '                Next
    '
    '            Case "KC"
    '                'Change a note
    '                'KC_ColumnIndex_VPosition_Value_LongNote_Hidden_DColumnIndex_DVPosition_NValue_NLongNote_NHidden_Selected
    '
    '                If Not UBound(xArg) = 11 Then Exit Select
    '                xColumnIndex = Val(xArg(1))
    '                xVPosition = Val(xArg(2))
    '                xValue = Val(xArg(3))
    '                xLong = Val(xArg(4))
    '                xHidden = CBool(Val(xArg(5)))
    '
    '                For xI2 = 0 To UBound(K)
    '                    If K(xI2).ColumnIndex = xColumnIndex And _
    '                       dbleql(K(xI2).VPosition, xVPosition) And _
    '                       K(xI2).Value = xValue And _
    '                       IIf(NTInput, dbleql(K(xI2).Length, xLong), K(xI2).LongNote = CBool(xLong)) And _
    '                       K(xI2).Hidden = xHidden Then
    '
    '                        K(xI2).ColumnIndex = EnabledColumnToReal(RealColumnToEnabled(K(xI2).ColumnIndex) + Val(xArg(6)))
    '                        K(xI2).VPosition += Val(xArg(7))
    '                        If Val(xArg(8)) > 0 Then K(xI2).Value = Val(xArg(8))
    '                        If NTInput Then K(xI2).Length = Val(xArg(9)) Else K(xI2).LongNote = CBool(Val(xArg(9)))
    '                        K(xI2).Hidden = CBool(Val(xArg(10)))
    '                        K(xI2).Selected = CBool(Val(xArg(11))) And nEnabled(K(xI2).ColumnIndex)
    '                        Exit For
    '                    End If
    '                Next
    '
    '            Case "KM"
    '                'Move a note
    '                'KM_ColumnIndex_VPosition_Value_LongNote_Hidden_DColumnIndex_DVPosition_Selected
    '
    '                If Not UBound(xArg) = 8 Then Exit Select
    '                xColumnIndex = Val(xArg(1))
    '                xVPosition = Val(xArg(2))
    '                xValue = Val(xArg(3))
    '                xLong = Val(xArg(4))
    '                xHidden = CBool(Val(xArg(5)))
    '
    '                For xI2 = 1 To UBound(K)
    '                    If K(xI2).ColumnIndex = xColumnIndex And _
    '                       dbleql(K(xI2).VPosition, xVPosition) And _
    '                       K(xI2).Value = xValue And _
    '                       IIf(NTInput, dbleql(K(xI2).Length, xLong), K(xI2).LongNote = CBool(xLong)) And _
    '                       K(xI2).Hidden = xHidden Then
    '
    '                        K(xI2).ColumnIndex = EnabledColumnToReal(RealColumnToEnabled(K(xI2).ColumnIndex) + Val(xArg(6)))
    '                        K(xI2).VPosition += Val(xArg(7))
    '                        K(xI2).Selected = CBool(Val(xArg(8))) And nEnabled(K(xI2).ColumnIndex)
    '                        Exit For
    '                    End If
    '                Next
    '
    '            Case "KL"
    '                'Modify LongNote state. / Adjust note length in NT Input mode.
    '                'KL_ColumnIndex_VPosition_Value_LongNote_Hidden_NLongNote_AdjustUpperEnd_Selected
    '
    '                If Not UBound(xArg) = 8 Then Exit Select
    '                xColumnIndex = Val(xArg(1))
    '                xVPosition = Val(xArg(2))
    '                xValue = Val(xArg(3))
    '                xLong = Val(xArg(4))
    '                xHidden = CBool(Val(xArg(5)))
    '
    '                For xI2 = 1 To UBound(K)
    '                    If K(xI2).ColumnIndex = xColumnIndex And _
    '                       dbleql(K(xI2).VPosition, xVPosition) And _
    '                       K(xI2).Value = xValue And _
    '                       IIf(NTInput, dbleql(K(xI2).Length, xLong), K(xI2).LongNote = CBool(xLong)) And _
    '                       K(xI2).Hidden = xHidden Then
    '
    '                        If NTInput Then
    '                            If Not CBool(Val(xArg(7))) Then K(xI2).VPosition += K(xI2).Length - Val(xArg(6))
    '                            K(xI2).Length = Val(xArg(6))
    '                        Else
    '                            K(xI2).LongNote = CBool(Val(xArg(6)))
    '                        End If
    '
    '                        K(xI2).Selected = CBool(Val(xArg(8))) And nEnabled(K(xI2).ColumnIndex)
    '                        Exit For
    '                    End If
    '                Next
    '
    '            Case "KH"
    '                'Show / Hide note.
    '                'KH_ColumnIndex_VPosition_Value_LongNote_Hidden_NHidden_Selected
    '
    '                If Not UBound(xArg) = 7 Then Exit Select
    '                xColumnIndex = Val(xArg(1))
    '                xVPosition = Val(xArg(2))
    '                xValue = Val(xArg(3))
    '                xLong = Val(xArg(4))
    '                xHidden = CBool(Val(xArg(5)))
    '
    '                For xI2 = 1 To UBound(K)
    '                    If K(xI2).ColumnIndex = xColumnIndex And _
    '                       dbleql(K(xI2).VPosition, xVPosition) And _
    '                       K(xI2).Value = xValue And _
    '                       IIf(NTInput, dbleql(K(xI2).Length, xLong), K(xI2).LongNote = CBool(xLong)) And _
    '                       K(xI2).Hidden = xHidden Then
    '
    '                        K(xI2).Hidden = CBool(Val(xArg(6)))
    '                        K(xI2).Selected = CBool(Val(xArg(7))) And nEnabled(K(xI2).ColumnIndex)
    '                        Exit For
    '                    End If
    '                Next
    '
    '            Case "KZ"
    '                'Remove all notes
    '                'KZ
    '                ReDim Preserve K(0)
    '
    '            Case "CB"
    '                'Change measure length.
    '                'CB_Value_MIndex1_MIndex2_ ...
    '                If UBound(xArg) < 1 Then Exit Select
    '                xVPosition = Val(xArg(1))
    '                xColumnIndex = 192 / GCD(xVPosition, 192.0R)
    '                If xColumnIndex < 4 Or xColumnIndex = 192 Then xColumnIndex = 4
    '                For xI0 As Integer = 2 To UBound(xArg)
    '                    Dim xM As Integer = CInt(Val(xArg(xI0)))
    '                    MeasureLength(xM) = xVPosition
    '                    LBeat.Items(xM) = Add3Zeros(xM) & ": " & (xVPosition / 192 * xColumnIndex) & "/" & xColumnIndex & " (" & (xVPosition / 192) & ")"'
    '                    LBeat.SelectedIndices.Add(xM)
    '                Next
    '                UpdateMeasureBottom()
    '
    '            Case "SA"
    '                'Change selected area in posteffects mode
    '                'SA_SelStart_SelLength_SelHalf_Selected
    '                If Not UBound(xArg) = 4 Then Exit Select
    '                vSelStart = Val(xArg(1))
    '                vSelLength = Val(xArg(2))
    '                vSelHalf = Val(xArg(3))
    '                If Not Val(xArg(4)) = 0 Then
    '                    For xI3 = 1 To UBound(K)
    '                        K(xI3).Selected = dblgtreql(K(xI3).VPosition, vSelStart + IIf(vSelLength < 0, vSelLength, 0)) And _
    '                                          dblsmr(K(xI3).VPosition, vSelStart + IIf(vSelLength > 0, vSelLength, 0)) And _
    '                                          nEnabled(K(xI3).ColumnIndex)
    '                    Next
    '                End If
    '
    '            Case "NT"
    '                'Change NTInput state.
    '                'NT_BecomeNTInput_AutoConvert
    '                If Not UBound(xArg) = 2 Then Exit Select
    '                NTInput = CBool(Val(xArg(1)))
    '                TBNTInput.Checked = NTInput
    '                mnNTInput.Checked = NTInput
    '
    '                POBLong.Enabled = Not NTInput
    '                POBLongShort.Enabled = Not NTInput
    '
    '                bAdjustLength = False
    '                bAdjustUpper = False
    '                If CBool(Val(xArg(2))) Then
    '                    If NTInput Then ConvertBMSE2NT() Else ConvertNT2BMSE()
    '                End If
    '
    '            Case "CV"
    '                'Change visible columns
    '                'CV_CGBLP_CGSTOP_CGA8_CGP2
    '                If Not UBound(xArg) = 4 Then Exit Select
    '                IsInitializing = True
    '                CGBLP.Checked = CBool(Val(xArg(1)))
    '                CGSTOP.Checked = CBool(Val(xArg(2)))
    '                'CGA8.Checked = CBool(Val(xArg(3)))
    '                CHPlayer.SelectedIndex = Math.Abs(Val(xArg(4)))
    '                IsInitializing = False
    '
    '                For xI4 As Integer = 1 To UBound(K)
    '                    K(xI4).Selected = K(xI4).Selected And nEnabled(K(xI4).ColumnIndex)
    '                Next
    '                UpdateKLeft()
    '                RefreshPanelAll()
    '
    '            Case "NO"
    '                'No operation
    '                'NO
    '                Exit For
    '
    '        End Select
    '    Next
    '
    '    THBPM.Value = K(0).Value / 10000
    '    If IsSaved Then SetIsSaved(False)
    '
    '    SortByVPosition()
    '    UpdatePairing()
    '    CalculateTotalNotes()
    '    CalculateGreatestVPosition()
    '    RefreshPanelAll()
    '    POStatusRefresh()
    'End Sub

    'Private Sub ClearURReference(ByVal xCmd As UndoRedo.LinkedURCmd)
    '    If xCmd Is Nothing Then Exit Sub
    '    ClearURReference(xCmd.Next)
    '    xCmd = Nothing
    'End Sub

    Private Function sIA() As Integer
        Return IIf(sI > 98, 0, sI + 1)
    End Function

    Private Function sIM() As Integer
        Return IIf(sI < 1, 99, sI - 1)
    End Function

    'Private Sub AddUndo(ByVal sCUndo As String, ByVal sCRedo As String, Optional ByVal OverWrite As Boolean = False)
    Private Sub AddUndo(ByVal sCUndo As UndoRedo.LinkedURCmd, ByVal sCRedo As UndoRedo.LinkedURCmd, Optional ByVal OverWrite As Boolean = False)
        If sCUndo Is Nothing And sCRedo Is Nothing Then Exit Sub
        If IsSaved Then SetIsSaved(False)
        If Not OverWrite Then sI = sIA()

        'ClearURReference(sUndo(sI))
        'ClearURReference(sRedo(sI))
        'ClearURReference(sUndo(sIA))
        'ClearURReference(sRedo(sIA))
        sUndo(sI) = sCUndo
        sRedo(sI) = sCRedo
        sUndo(sIA) = New UndoRedo.NoOperation
        sRedo(sIA) = New UndoRedo.NoOperation
        TBUndo.Enabled = True
        TBRedo.Enabled = False
        mnUndo.Enabled = True
        mnRedo.Enabled = False
    End Sub

    Private Sub ClearUndo()
        'For xI1 As Integer = 0 To 99
        '    ClearURReference(sUndo(xI1))
        '    ClearURReference(sRedo(xI1))
        'Next

        ReDim sUndo(99)
        ReDim sRedo(99)
        sUndo(0) = New UndoRedo.NoOperation
        sUndo(1) = New UndoRedo.NoOperation
        sRedo(0) = New UndoRedo.NoOperation
        sRedo(1) = New UndoRedo.NoOperation
        sI = 0
        TBUndo.Enabled = False
        TBRedo.Enabled = False
        mnUndo.Enabled = False
        mnRedo.Enabled = False
    End Sub

    Private Sub TBUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUndo.Click, mnUndo.Click
        KMouseOver = -1
        'KMouseDown = -1
        ReDim uNotes(-1)
        If sUndo(sI).ofType = UndoRedo.opNoOperation Then Exit Sub
        Operate(sUndo(sI))
        sI = sIM()

        TBUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        TBRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation
        mnUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        mnRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation
    End Sub

    Private Sub TBRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBRedo.Click, mnRedo.Click
        KMouseOver = -1
        'KMouseDown = -1
        ReDim uNotes(-1)
        If sRedo(sIA).ofType = UndoRedo.opNoOperation Then Exit Sub
        Operate(sRedo(sIA))
        sI = sIA()

        TBUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        TBRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation
        mnUndo.Enabled = sUndo(sI).ofType <> UndoRedo.opNoOperation
        mnRedo.Enabled = sRedo(sIA).ofType <> UndoRedo.opNoOperation
    End Sub

    'Undo appends before, Redo appends after.
    'After a sequence of Commands, 
    '   Undo will be the first one to execute, 
    '   Redo will be the last one to execute.
    'Remember to save the first Redo.

    'In case where undo is Nothing: Dont worry.
    'In case where redo is Nothing: 
    '   If only one redo is in a sequence, put Nothing.
    '   If several redo are in a sequence, 
    '       Create Void first. 
    '       Record its reference into a seperate copy. (xBaseRedo = xRedo)
    '       Use this xRedo as the BaseRedo.
    '       When calling AddUndo subroutine, use xBaseRedo.Next as cRedo.

    'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
    'Dim xRedo As UndoRedo.LinkedURCmd = Nothing
    '... 'Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
    'AddUndo(xUndo, xRedo)

    'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
    'Dim xRedo As New UndoRedo.Void
    'Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
    '... 'Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
    'AddUndo(xUndo, xBaseRedo.Next)

    Private Sub RedoAddNote(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.RemoveNote(xCol, xVPos, xVal, xLong, xHide)
        Dim xRedo As New UndoRedo.AddNote(xCol, xVPos, xVal, xLong, xHide, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoAddNote(ByVal xN As Note, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.RemoveNote(xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden)
        Dim xRedo As New UndoRedo.AddNote(xN.ColumnIndex, _
                                          xN.VPosition, _
                                          xN.Value, _
                             IIf(NTInput, xN.Length, xN.LongNote), _
                                          xN.Hidden, _
                                          xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoAddNote(ByVal xIndices() As Integer, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 0 To UBound(xIndices)
            With K(xIndices(xI1))
                Dim xUndo As New UndoRedo.RemoveNote(.ColumnIndex, _
                                                     .VPosition, _
                                                     .Value, _
                                        IIf(NTInput, .Length, .LongNote), _
                                                     .Hidden)
                Dim xRedo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                xUndo.Next = BaseUndo
                BaseUndo = xUndo
                If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
                BaseRedo = xRedo
            End With
        Next
    End Sub

    Private Sub RedoAddNoteSelected(ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For
            With K(xI1)
                Dim xUndo As New UndoRedo.RemoveNote(.ColumnIndex, _
                                                     .VPosition, _
                                                     .Value, _
                                        IIf(NTInput, .Length, .LongNote), _
                                                     .Hidden)
                Dim xRedo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                xUndo.Next = BaseUndo
                BaseUndo = xUndo
                If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
                BaseRedo = xRedo
            End With
        Next
    End Sub

    Private Sub RedoAddNoteAll(ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 1 To UBound(K)
            With K(xI1)
                Dim xRedo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
                BaseRedo = xRedo
            End With
        Next
        Dim xUndo As New UndoRedo.RemoveAllNotes
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
    End Sub

    Private Sub RedoRemoveNote(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.AddNote(xCol, xVPos, xVal, xLong, xHide, xSel)
        Dim xRedo As New UndoRedo.RemoveNote(xCol, xVPos, xVal, xLong, xHide)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoRemoveNote(ByVal xN As Note, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.AddNote(xN.ColumnIndex, _
                                          xN.VPosition, _
                                          xN.Value, _
                             IIf(NTInput, xN.Length, xN.LongNote), _
                                          xN.Hidden, _
                                          xSel)
        Dim xRedo As New UndoRedo.RemoveNote(xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoRemoveNote(ByVal xIndices() As Integer, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 0 To UBound(xIndices)
            With K(xIndices(xI1))
                Dim xUndo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                Dim xRedo As New UndoRedo.RemoveNote(.ColumnIndex, _
                                                     .VPosition, _
                                                     .Value, _
                                        IIf(NTInput, .Length, .LongNote), _
                                                     .Hidden)
                xUndo.Next = BaseUndo
                BaseUndo = xUndo
                If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
                BaseRedo = xRedo
            End With
        Next
    End Sub

    Private Sub RedoRemoveNoteSelected(ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For
            With K(xI1)
                Dim xUndo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                Dim xRedo As New UndoRedo.RemoveNote(.ColumnIndex, _
                                                     .VPosition, _
                                                     .Value, _
                                        IIf(NTInput, .Length, .LongNote), _
                                                     .Hidden)
                xUndo.Next = BaseUndo
                BaseUndo = xUndo
                If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
                BaseRedo = xRedo
            End With
        Next
    End Sub

    Private Sub RedoRemoveNoteAll(ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        For xI1 As Integer = 1 To UBound(K)
            With K(xI1)
                Dim xUndo As New UndoRedo.AddNote(.ColumnIndex, _
                                                  .VPosition, _
                                                  .Value, _
                                     IIf(NTInput, .Length, .LongNote), _
                                                  .Hidden, _
                                                  xSel)
                xUndo.Next = BaseUndo
                BaseUndo = xUndo
            End With
        Next
        Dim xRedo As New UndoRedo.RemoveAllNotes
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoChangeNote(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
                               ByVal nCol As Integer, ByVal nVPos As Double, ByVal nVal As Integer, ByVal nLong As Double, ByVal nHide As Boolean, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.ChangeNote(nCol, nVPos, nVal, nLong, nHide, xCol, xVPos, xVal, xLong, xHide, xSel)
        Dim xRedo As New UndoRedo.ChangeNote(xCol, xVPos, xVal, xLong, xHide, nCol, nVPos, nVal, nLong, nHide, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoChangeNote(ByVal xN As Note, ByVal nCol As Integer, ByVal nVPos As Double, ByVal nVal As Integer, ByVal nLong As Double, ByVal nHide As Boolean, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.ChangeNote(nCol, nVPos, nVal, nLong, nHide, _
                                             xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden, _
                                             xSel)
        Dim xRedo As New UndoRedo.ChangeNote(xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden, _
                                             nCol, nVPos, nVal, nLong, nHide, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoChangeNote(ByVal xN As Note, ByVal nN As Note, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.ChangeNote(nN.ColumnIndex, _
                                             nN.VPosition, _
                                             nN.Value, _
                                IIf(NTInput, nN.Length, nN.LongNote), _
                                             nN.Hidden, _
                                             xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden, _
                                             xSel)
        Dim xRedo As New UndoRedo.ChangeNote(xN.ColumnIndex, _
                                             xN.VPosition, _
                                             xN.Value, _
                                IIf(NTInput, xN.Length, xN.LongNote), _
                                             xN.Hidden, _
                                             nN.ColumnIndex, _
                                             nN.VPosition, _
                                             nN.Value, _
                                IIf(NTInput, nN.Length, nN.LongNote), _
                                             nN.Hidden, _
                                             xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoMoveNote(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
                             ByVal nCol As Integer, ByVal nVPos As Double, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.MoveNote(nCol, nVPos, xVal, xLong, xHide, xCol, xVPos, xSel)
        Dim xRedo As New UndoRedo.MoveNote(xCol, xVPos, xVal, xLong, xHide, nCol, nVPos, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoMoveNote(ByVal xN As Note, ByVal nCol As Integer, ByVal nVPos As Double, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.MoveNote(nCol, nVPos, _
                                           xN.Value, _
                              IIf(NTInput, xN.Length, xN.LongNote), _
                                           xN.Hidden, _
                                           xN.ColumnIndex, _
                                           xN.VPosition, _
                                           xSel)
        Dim xRedo As New UndoRedo.MoveNote(xN.ColumnIndex, _
                                           xN.VPosition, _
                                           xN.Value, _
                              IIf(NTInput, xN.Length, xN.LongNote), _
                                           xN.Hidden, _
                                           nCol, nVPos, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoLongNoteModify(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
                                   ByVal nVPos As Double, ByVal nLong As Double, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.LongNoteModify(xCol, nVPos, xVal, nLong, xHide, xVPos, xLong, xSel)
        Dim xRedo As New UndoRedo.LongNoteModify(xCol, xVPos, xVal, xLong, xHide, nVPos, nLong, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoLongNoteModify(ByVal xN As Note, ByVal nVPos As Double, ByVal nLong As Double, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.LongNoteModify(xN.ColumnIndex, nVPos, xN.Value, nLong, xN.Hidden, _
                                                                 xN.VPosition, IIf(NTInput, xN.Length, xN.LongNote), xSel)
        Dim xRedo As New UndoRedo.LongNoteModify(xN.ColumnIndex, _
                                                 xN.VPosition, _
                                                 xN.Value, _
                                    IIf(NTInput, xN.Length, xN.LongNote), _
                                                 xN.Hidden, _
                                                 nVPos, nLong, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoHiddenNoteModify(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
    ByVal nHide As Boolean, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.HiddenNoteModify(xCol, xVPos, xVal, xLong, nHide, xHide, xSel)
        Dim xRedo As New UndoRedo.HiddenNoteModify(xCol, xVPos, xVal, xLong, xHide, nHide, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoHiddenNoteModify(ByVal xN As Note, ByVal nHide As Boolean, _
    ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.HiddenNoteModify(xN.ColumnIndex, _
                                                   xN.VPosition, _
                                                   xN.Value, _
                                      IIf(NTInput, xN.Length, xN.LongNote), _
                                                   nHide, _
                                                   xN.Hidden, _
                                                   xSel)
        Dim xRedo As New UndoRedo.HiddenNoteModify(xN.ColumnIndex, _
                                                   xN.VPosition, _
                                                   xN.Value, _
                                      IIf(NTInput, xN.Length, xN.LongNote), _
                                                   xN.Hidden, _
                                                   nHide, _
                                                   xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoRelabelNote(ByVal xCol As Integer, ByVal xVPos As Double, ByVal xVal As Integer, ByVal xLong As Double, ByVal xHide As Boolean, _
    ByVal nVal As Integer, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.RelabelNote(xCol, xVPos, nVal, xLong, xHide, xVal, xSel)
        Dim xRedo As New UndoRedo.RelabelNote(xCol, xVPos, xVal, xLong, xHide, nVal, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoRelabelNote(ByVal xN As Note, ByVal nVal As Integer, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.RelabelNote(xN.ColumnIndex, _
                                              xN.VPosition, _
                                              nVal, _
                                 IIf(NTInput, xN.Length, xN.LongNote), _
                                              xN.Hidden, _
                                              xN.Value, _
                                              xSel)
        Dim xRedo As New UndoRedo.RelabelNote(xN.ColumnIndex, _
                                              xN.VPosition, _
                                              xN.Value, _
                                 IIf(NTInput, xN.Length, xN.LongNote), _
                                              xN.Hidden, _
                                              nVal, _
                                              xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoChangeMeasureLengthSelected(ByVal nVal As Double, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xIndices(LBeat.SelectedIndices.Count - 1) As Integer
        LBeat.SelectedIndices.CopyTo(xIndices, 0)
        If xIndices.Length = 0 Then Exit Sub

        Dim xmLen(-1) As Double
        Dim xUndo(-1) As UndoRedo.ChangeMeasureLength
        For Each xI1 As Integer In xIndices
            Dim xI As Integer = Array.IndexOf(xmLen, MeasureLength(xI1))
            If xI = -1 Then
                ReDim Preserve xmLen(UBound(xmLen) + 1)
                ReDim Preserve xUndo(UBound(xUndo) + 1)
                xmLen(UBound(xmLen)) = MeasureLength(xI1)
                xUndo(UBound(xUndo)) = New UndoRedo.ChangeMeasureLength(MeasureLength(xI1), New Integer() {xI1})
            Else
                With xUndo(xI)
                    ReDim Preserve .Indices(UBound(.Indices) + 1)
                    .Indices(UBound(.Indices)) = xI1
                End With
            End If
        Next
        For xI1 As Integer = 0 To UBound(xUndo) - 1
            xUndo(xI1).Next = xUndo(xI1 + 1)
        Next
        xUndo(UBound(xUndo)).Next = BaseUndo
        BaseUndo = xUndo(0)

        Dim xRedo As New UndoRedo.ChangeMeasureLength(nVal, xIndices.Clone)
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    Private Sub RedoChangeTimeSelection(ByVal pStart As Double, ByVal pLen As Double, ByVal pHalf As Double, _
    ByVal nStart As Double, ByVal nLen As Double, ByVal nHalf As Double, ByVal xSel As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.ChangeTimeSelection(pStart, pLen, pHalf, xSel)
        Dim xRedo As New UndoRedo.ChangeTimeSelection(nStart, nLen, nHalf, xSel)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    'Private Sub RedoChangeVisibleColumns(ByVal pBLP As Boolean, ByVal pSTOP As Boolean, ByVal pPlayer As Integer, _
    '                                     ByVal nBLP As Boolean, ByVal nSTOP As Boolean, ByVal nPlayer As Integer, _
    'ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
    '    Dim xUndo As New UndoRedo.ChangeVisibleColumns(pBLP, pSTOP, pPlayer)
    '    Dim xRedo As New UndoRedo.ChangeVisibleColumns(nBLP, nSTOP, nPlayer)
    '    xUndo.Next = BaseUndo
    '    BaseUndo = xUndo
    '    If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
    '    BaseRedo = xRedo
    'End Sub

    Private Sub RedoNT(ByVal becomeNT As Boolean, ByVal autoConvert As Boolean, ByRef BaseUndo As UndoRedo.LinkedURCmd, ByRef BaseRedo As UndoRedo.LinkedURCmd)
        Dim xUndo As New UndoRedo.NT(Not becomeNT, autoConvert)
        Dim xRedo As New UndoRedo.NT(becomeNT, autoConvert)
        xUndo.Next = BaseUndo
        BaseUndo = xUndo
        If BaseRedo IsNot Nothing Then BaseRedo.Next = xRedo
        BaseRedo = xRedo
    End Sub

    '''' <summary>
    '''' Add K.
    '''' </summary>
    'Private Function sCmdK(ByVal xCol As Integer, _
    '                       ByVal xVP As Double, _
    '                       ByVal xVal As Integer, _
    '                       ByVal xLongNote As Double, _
    '                       ByVal xHidden As Boolean, _
    '                       ByVal xSel As Boolean) As String
    '    Return "K_" & _
    '            xCol & "_" & _
    '            xVP & "_" & _
    '            xVal & "_" & _
    '            xLongNote & "_" & _
    '       CInt(xHidden) & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Add K.
    '''' </summary>
    'Private Function sCmdK(ByVal xNote As Note, ByVal xSel As Boolean) As String
    '    Return "K_" & _
    '            xNote.ColumnIndex & "_" & _
    '            xNote.VPosition & "_" & _
    '            xNote.Value & "_" & _
    '            IIf(NTInput, xNote.Length, CInt(xNote.LongNote)) & "_" & _
    '       CInt(xNote.Hidden) & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Add selected K's.
    '''' </summary>
    'Private Function sCmdKs(ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '    For xI1 = 1 To UBound(K)
    '        If K(xI1).Selected Then
    '            xStr &= "K_" & _
    '                    K(xI1).ColumnIndex & "_" & _
    '                    K(xI1).VPosition & "_" & _
    '                    K(xI1).Value & "_" & _
    '                    IIf(NTInput, K(xI1).Length, CInt(K(xI1).LongNote)) & "_" & _
    '                    CInt(K(xI1).Hidden) & "_" & _
    '                    IIf(xSel, "1", "0") & _
    '                    vbCrLf
    '        End If
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Add all K's.
    '''' </summary>
    'Private Function sCmdKsAll(ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '    For xI1 = 1 To UBound(K)
    '        xStr &= "K_" & _
    '                 K(xI1).ColumnIndex & "_" & _
    '                 K(xI1).VPosition & "_" & _
    '                 K(xI1).Value & "_" & _
    '                 IIf(NTInput, K(xI1).Length, CInt(K(xI1).LongNote)) & "_" & _
    '                 CInt(K(xI1).Hidden) & "_" & _
    '                 IIf(xSel, "1", "0") & _
    '                 vbCrLf
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Remove K.
    '''' </summary>
    'Private Function sCmdKD(ByVal xCol As Integer, _
    '                        ByVal xVP As Double, _
    '                        ByVal xVal As Integer, _
    '                        ByVal xLongNote As Double, _
    '                        ByVal xHidden As Boolean) As String
    '    Return "KD_" & _
    '            xCol & "_" & _
    '            xVP & "_" & _
    '            xVal & "_" & _
    '            xLongNote & "_" & _
    '       CInt(xHidden)
    'End Function
    '
    '''' <summary>
    '''' Remove K.
    '''' </summary>
    'Private Function sCmdKD(ByVal xNote As Note) As String
    '    Return "KD_" & _
    '            xNote.ColumnIndex & "_" & _
    '            xNote.VPosition & "_" & _
    '            xNote.Value & "_" & _
    '            IIf(NTInput, xNote.Length, CInt(xNote.LongNote)) & "_" & _
    '       CInt(xNote.Hidden)
    'End Function
    '
    '''' <summary>
    '''' Remove selected K's.
    '''' </summary>
    'Private Function sCmdKDs() As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '    For xI1 = 1 To UBound(K)
    '        If K(xI1).Selected Then
    '            xStr &= "KD_" & _
    '                    K(xI1).ColumnIndex & "_" & _
    '                    K(xI1).VPosition & "_" & _
    '                    K(xI1).Value & "_" & _
    '                    IIf(NTInput, K(xI1).Length, CInt(K(xI1).LongNote)) & "_" & _
    '                    CInt(K(xI1).Hidden) & _
    '                    vbCrLf
    '        End If
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Modify K.
    '''' </summary>
    'Private Function sCmdKC(ByVal xCol As Integer, _
    '                        ByVal xVP As Double, _
    '                        ByVal xVal As Integer, _
    '                        ByVal xLongNote As Double, _
    '                        ByVal xHidden As Boolean, _
    '                        ByVal xDCol As Integer, _
    '                        ByVal xDVP As Double, _
    '                        ByVal xNVal As Integer, _
    '                        ByVal xNLongNote As Double, _
    '                        ByVal xNHidden As Boolean, _
    '                        ByVal xSel As Boolean) As String
    '    Return "KC_" & _
    '            xCol & "_" & _
    '            xVP & "_" & _
    '            xVal & "_" & _
    '            xLongNote & "_" & _
    '       CInt(xHidden) & "_" & _
    '            xDCol & "_" & _
    '            xDVP & "_" & _
    '            xNVal & "_" & _
    '            xNLongNote & "_" & _
    '       CInt(xNHidden) & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Modify K.
    '''' </summary>
    'Private Function sCmdKC(ByVal xBNote As Note, ByVal xANote As Note, ByVal xSel As Boolean) As String
    '    Return "KC_" & _
    '            xBNote.ColumnIndex & "_" & _
    '            xBNote.VPosition & "_" & _
    '            xBNote.Value & "_" & _
    '            IIf(NTInput, xBNote.Length, CInt(xBNote.LongNote)) & "_" & _
    '       CInt(xBNote.Hidden) & "_" & _
    '           (xANote.ColumnIndex - xBNote.ColumnIndex) & "_" & _
    '           (xANote.VPosition - xBNote.VPosition) & "_" & _
    '            xANote.Value & "_" & _
    '            IIf(NTInput, xANote.Length, CInt(xANote.LongNote)) & "_" & _
    '       CInt(xANote.Hidden) & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Move a K.
    '''' </summary>
    'Private Function sCmdKM(ByVal xCol As Integer, _
    '                        ByVal xVP As Double, _
    '                        ByVal xVal As Integer, _
    '                        ByVal xLongNote As Double, _
    '                        ByVal xHidden As Boolean, _
    '                        ByVal xDCol As Integer, _
    '                        ByVal xDVP As Double, _
    '                        ByVal xSel As Boolean) As String
    '    Return "KM_" & _
    '            xCol & "_" & _
    '            xVP & "_" & _
    '            xVal & "_" & _
    '            xLongNote & "_" & _
    '       CInt(xHidden) & "_" & _
    '            xDCol & "_" & _
    '            xDVP & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Move a K.
    '''' </summary>
    'Private Function sCmdKM(ByVal xNote As Note, _
    '                        ByVal xDCol As Integer, _
    '                        ByVal xDVP As Double, _
    '                        ByVal xSel As Boolean) As String
    '    Return "KM_" & _
    '            xNote.ColumnIndex & "_" & _
    '            xNote.VPosition & "_" & _
    '            xNote.Value & "_" & _
    '            IIf(NTInput, xNote.Length, CInt(xNote.LongNote)) & "_" & _
    '       CInt(xNote.Hidden) & "_" & _
    '            xDCol & "_" & _
    '            xDVP & "_" & _
    '            IIf(xSel, "1", "0")
    'End Function
    '
    '''' <summary>
    '''' Move selected K's.
    '''' </summary>
    'Private Function sCmdKMs(ByVal xDCol As Integer, ByVal xDVP As Double, ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '    For xI1 = 1 To UBound(K)
    '        If K(xI1).Selected Then
    '            xStr &= "KM_" & _
    '                    K(xI1).ColumnIndex & "_" & _
    '                    K(xI1).VPosition & "_" & _
    '                    K(xI1).Value & "_" & _
    '                    IIf(NTInput, K(xI1).Length, CInt(K(xI1).LongNote)) & "_" & _
    '               CInt(K(xI1).Hidden) & "_" & _
    '                    xDCol & "_" & _
    '                    xDVP & "_" & _
    '                    IIf(xSel, "1", "0") & _
    '                    vbCrLf
    '        End If
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Move selected K's (reverse operation).
    '''' </summary>
    'Private Function sCmdKMsR(ByVal xDCol As Integer, ByVal xDVP As Double, ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '    For xI1 = 1 To UBound(K)
    '        If K(xI1).Selected Then
    '            xStr &= "KM_" & _
    '                    EnabledColumnToReal(RealColumnToEnabled(K(xI1).ColumnIndex) + xDCol) & "_" & _
    '                    (K(xI1).VPosition + xDVP) & "_" & _
    '                    K(xI1).Value & "_" & _
    '                    IIf(NTInput, K(xI1).Length, CInt(K(xI1).LongNote)) & "_" & _
    '               CInt(K(xI1).Hidden) & "_" & _
    '                    -xDCol & "_" & _
    '                    -xDVP & "_" & _
    '                    IIf(xSel, "1", "0") & _
    '                    vbCrLf
    '        End If
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Modify LongNote state. / Adjust note length in NT Input mode.
    '''' </summary>
    'Private Function sCmdKL(ByVal xCol As Integer, _
    '                        ByVal xVP As Double, _
    '                        ByVal xVal As Integer, _
    '                        ByVal xLongNote As Double, _
    '                        ByVal xHidden As Boolean, _
    '                        ByVal xNLongNote As Double, _
    '                        ByVal xAdjUpper As Boolean, _
    '                        ByVal xSel As Boolean) As String
    '    Return "KL_" & _
    '           xCol & "_" & _
    '           xVP & "_" & _
    '           xVal & "_" & _
    '           xLongNote & "_" & _
    '      CInt(xHidden) & "_" & _
    '           xNLongNote & "_" & _
    '      CInt(xAdjUpper) & "_" & _
    '      CInt(xSel)
    'End Function
    '
    '''' <summary>
    '''' Adjust note length in NT Input mode.
    '''' </summary>
    'Private Function sCmdKLxNT(ByVal xNote As Note, _
    '                           ByVal xNLength As Double, _
    '                           ByVal xAdjUpper As Boolean, _
    '                           ByVal xSel As Boolean) As String
    '    Return "KL_" & _
    '           xNote.ColumnIndex & "_" & _
    '           xNote.VPosition & "_" & _
    '           xNote.Value & "_" & _
    '           xNote.Length & "_" & _
    '      CInt(xNote.Hidden) & "_" & _
    '           xNLength & "_" & _
    '      CInt(xAdjUpper) & "_" & _
    '      CInt(xSel)
    'End Function
    '
    '''' <summary>
    '''' Adjust selected note length in NT Input mode.
    '''' </summary>
    'Private Function sCmdKLsNT(ByVal xDeltaLongNote As Double, ByVal xAdjUpper As Boolean, ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '
    '    For xI1 = 1 To UBound(K)
    '        If K(xI1).Selected Then
    '            xStr &= "KL_" & _
    '                    K(xI1).ColumnIndex & "_" & _
    '                    K(xI1).VPosition & "_" & _
    '                    K(xI1).Value & "_" & _
    '                    K(xI1).Length & "_" & _
    '               CInt(K(xI1).Hidden) & "_" & _
    '                    (K(xI1).Length + xDeltaLongNote) & "_" & _
    '                    CInt(xAdjUpper) & "_" & _
    '                    CInt(xSel) & _
    '                    vbCrLf
    '        End If
    '    Next
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Adjust selected note length in NT Input mode. (reverse operation)
    '''' </summary>
    'Private Function sCmdKLsNTR(ByVal xDeltaLongNote As Double, ByVal xAdjUpper As Boolean, ByVal xSel As Boolean) As String
    '    Dim xI1 As Integer
    '    Dim xStr As String = ""
    '
    '    If xAdjUpper Then
    '        For xI1 = 1 To UBound(K)
    '            If K(xI1).Selected Then
    '                xStr &= "KL_" & _
    '                        K(xI1).ColumnIndex & "_" & _
    '                        K(xI1).VPosition & "_" & _
    '                        K(xI1).Value & "_" & _
    '                        (K(xI1).Length + xDeltaLongNote) & "_" & _
    '                   CInt(K(xI1).Hidden) & "_" & _
    '                        K(xI1).Length & "_" & _
    '                   CInt(xAdjUpper) & "_" & _
    '                   CInt(xSel) & _
    '                        vbCrLf
    '            End If
    '        Next
    '    Else
    '        For xI1 = 1 To UBound(K)
    '            If K(xI1).Selected Then
    '                xStr &= "KL_" & _
    '                        K(xI1).ColumnIndex & "_" & _
    '                        (K(xI1).VPosition - xDeltaLongNote) & "_" & _
    '                        K(xI1).Value & "_" & _
    '                        (K(xI1).Length + xDeltaLongNote) & "_" & _
    '                   CInt(K(xI1).Hidden) & "_" & _
    '                        K(xI1).Length & "_" & _
    '                   CInt(xAdjUpper) & "_" & _
    '                   CInt(xSel) & _
    '                        vbCrLf
    '            End If
    '        Next
    '    End If
    '
    '    Return xStr
    'End Function
    '
    '''' <summary>
    '''' Show / Hide note.
    '''' </summary>
    'Private Function sCmdKH(ByVal xCol As Integer, _
    '                        ByVal xVP As Double, _
    '                        ByVal xVal As Integer, _
    '                        ByVal xLongNote As Double, _
    '                        ByVal xHidden As Boolean, _
    '                        ByVal xNHidden As Boolean, _
    '                        ByVal xSel As Boolean) As String
    '    Return "KH_" & _
    '           xCol & "_" & _
    '           xVP & "_" & _
    '           xVal & "_" & _
    '           xLongNote & "_" & _
    '      CInt(xHidden) & "_" & _
    '      CInt(xNHidden) & "_" & _
    '      CInt(xSel)
    'End Function
    '
    'Private Function sCmdCV() As String
    '    Return "CV_" & CInt(gBLP) & "_" & CInt(gSTOP) & "_" & 1 & "_" & CInt(gP2)
    'End Function

    Private Sub TBAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBAbout.Click, mnAbout1.Click
        Dim Aboutboxx1 As New AboutBox1()
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\About.png") Then
        Aboutboxx1.bBitmap = My.Resources.About0
        'Aboutboxx1.SelectBitmap()
        Aboutboxx1.ClientSize = New Size(1000, 500)
        Aboutboxx1.ClickToCopy.Visible = True
        Aboutboxx1.ShowDialog(Me)
        'Else
        '    MsgBox(locale.Messages.cannotfind & " ""About.png""", MsgBoxStyle.Critical, locale.Messages.err)
        'End If
    End Sub

    Private Sub TBOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBVOptions.Click, mnVOptions.Click
        'Dim xeColor() As Color = {vo.Title.Color, _
        '                          vo.Bg.Color, _
        '                          vo.pGrid.Color, _
        '                          vo.pSub.Color, _
        '                          vo.pVLine.Color, _
        '                          vo.pMLine.Color, _
        '                          vo.pBGMWav.Color, _
        '                          vo.SelBox.Color, _
        '                          vo.PECursor.Color, _
        '                          vo.PESel.Color, _
        '                          vo.PEBPM.Color, _
        '                          vo.kMouseOver.Color, _
        '                          vo.kSelected.Color, _
        '                          vo.kMouseOverE.Color}
        'Dim xeFont() As Font = {vo.TitleFont, _
        '                        vo.PEBPMFont, _
        '                        vo.kFont, _
        '                        vo.kMFont}
        'Dim xeI() As Integer = {vo.kHeight, _
        '                        vo.kLabelVShift, _
        '                        vo.kLabelHShift, _
        '                        vo.kLabelHShiftL, _
        '                        vo.kHidTransparency * 100}
        'Dim xkLength(niB) As Integer
        'Dim xkTitle(niB) As String
        'Dim xkNumericLabel(niB) As Boolean
        'Dim xkColor(niB) As Color
        'Dim xkForeColor(niB) As Color
        'Dim xkColorL(niB) As Color
        'Dim xkForeColorL(niB) As Color
        'Dim xkBgColor(niB) As Color
        '
        'For xI1 As Integer = 0 To niB
        '    xkLength(xI1) = kLength(xI1)
        '    xkTitle(xI1) = kTitle(xI1)
        '    xkNumericLabel(xI1) = kNumericLabel(xI1)
        '    xkColor(xI1) = Color.FromArgb(kColor(xI1))
        '    xkForeColor(xI1) = Color.FromArgb(kForeColor(xI1))
        '    xkColorL(xI1) = Color.FromArgb(kColorL(xI1))
        '    xkForeColorL(xI1) = Color.FromArgb(kForeColorL(xI1))
        '    xkBgColor(xI1) = Color.FromArgb(kBgColor(xI1))
        'Next
        '
        'Dim OptionBox As New OpVisual(xeColor, xeFont, xeI, _
        '                              xkLength, xkTitle, _
        '                              xkColor, xkForeColor, xkColorL, xkForeColorL, xkBgColor)
        'OptionBox.ShowDialog(Me)

        Dim xDiag As New OpVisual(vo, col, LWAV.Font)
        xDiag.ShowDialog(Me)
        UpdateKLeft()
        RefreshPanelAll()
    End Sub

    'Private Sub POHeaderB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POHeaderB.CheckedChanged
    '    POHeader.Visible = POHeaderB.Checked
    'End Sub
    'Private Sub POGridB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POGridB.CheckedChanged
    '    If POGridB.Checked Then
    '        POGrid.Visible = True
    '        POWaveFormB.Checked = False
    '        PO1.Visible = True
    '    Else
    '        POGrid.Visible = False
    '        If Not POWaveForm.Visible Then PO1.Visible = False
    '    End If
    'End Sub
    'Private Sub POWaveFormB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POWaveFormB.CheckedChanged
    '    If POWaveFormB.Checked Then
    '        POWaveForm.Visible = True
    '        POGridB.Checked = False
    '        PO1.Visible = True
    '    Else
    '        POWaveForm.Visible = False
    '        If Not POGrid.Visible Then PO1.Visible = False
    '    End If
    'End Sub
    'Private Sub POPrevB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POPrevB.CheckedChanged
    '    POPrev.Visible = POPrevB.Checked
    'End Sub
    'Private Sub POWAVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POWAVB.CheckedChanged
    '    If POWAVB.Checked Then
    '        POWAV.Visible = True
    '        POAdvancedB.Checked = False
    '        POExpansionB.Checked = False
    '    Else
    '        POWAV.Visible = False
    '    End If
    'End Sub
    'Private Sub POAdvancedB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POAdvancedB.CheckedChanged
    '    If POAdvancedB.Checked Then
    '        POAdvanced.Visible = True
    '        POWAVB.Checked = False
    '        POExpansionB.Checked = False
    '    Else
    '        POAdvanced.Visible = False
    '    End If
    'End Sub
    'Private Sub POExpansionB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POExpansionB.CheckedChanged
    '    If POExpansionB.Checked Then
    '        POExpansion.Visible = True
    '        POWAVB.Checked = False
    '        POAdvancedB.Checked = False
    '    Else
    '        POExpansion.Visible = False
    '    End If
    'End Sub

    Private Sub AddToPOWAV(ByVal xPath() As String)
        Dim xIndices(LWAV.SelectedIndices.Count - 1) As Integer
        LWAV.SelectedIndices.CopyTo(xIndices, 0)
        If xIndices.Length = 0 Then Exit Sub

        If xIndices.Length < xPath.Length Then
            Dim i As Integer = xIndices.Length
            Dim currWavIndex As Integer = xIndices(UBound(xIndices)) + 1
            ReDim Preserve xIndices(UBound(xPath))

            Do While i < xIndices.Length And currWavIndex <= 1294
                Do While currWavIndex <= 1294 AndAlso hWAV(currWavIndex + 1) <> ""
                    currWavIndex += 1
                Loop
                If currWavIndex > 1294 Then Exit Do

                xIndices(i) = currWavIndex
                currWavIndex += 1
                i += 1
            Loop

            If currWavIndex > 1294 Then
                ReDim Preserve xPath(i - 1)
                ReDim Preserve xIndices(i - 1)
            End If
        End If

        'Dim xI2 As Integer = 0
        For xI1 As Integer = 0 To UBound(XPath)
            'If xI2 > UBound(xIndices) Then Exit For
            'hWAV(xIndices(xI2) + 1) = GetFileName(xPath(xI1))
            'LWAV.Items.Item(xIndices(xI2)) = C10to36(xIndices(xI2) + 1) & ": " & GetFileName(xPath(xI1))
            hWAV(xIndices(xI1) + 1) = GetFileName(XPath(xI1))
            LWAV.Items.Item(xIndices(xI1)) = C10to36(xIndices(xI1) + 1) & ": " & GetFileName(XPath(xI1))
            'xI2 += 1
        Next

        LWAV.SelectedIndices.Clear()
        For xI1 As Integer = 0 To IIf(UBound(xIndices) < UBound(XPath), UBound(xIndices), UBound(XPath))
            LWAV.SelectedIndices.Add(xIndices(xI1))
        Next

        If IsSaved Then SetIsSaved(False)
        RefreshPanelAll()
    End Sub

    Private Sub POWAV_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles POWAV.DragDrop
        ReDim DDFileName(-1)
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Return

        Dim xOrigPath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        Dim xPath() As String = FilterFileBySupported(xOrigPath, SupportedAudioExtension)
        If xPath.Length = 0 Then
            RefreshPanelAll()
            Exit Sub
        End If

        AddToPOWAV(xPath)
    End Sub

    Private Sub POWAV_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles POWAV.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            DDFileName = FilterFileBySupported(CType(e.Data.GetData(DataFormats.FileDrop), String()), SupportedAudioExtension)
        Else
            e.Effect = DragDropEffects.None
        End If
        RefreshPanelAll()
    End Sub

    Private Sub POWAV_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles POWAV.DragLeave
        ReDim DDFileName(-1)
        RefreshPanelAll()
    End Sub

    Private Sub POWAV_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles POWAV.Resize
        LWAV.Height = sender.Height - 25
    End Sub
    Private Sub POBeat_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles POBeat.Resize
        LBeat.Height = POBeat.Height - 25
    End Sub
    Private Sub POExpansion_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles POExpansion.Resize
        TExpansion.Height = POExpansion.Height - 2
    End Sub

    Private Sub mn_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.ForeColor = Color.White
    End Sub
    Private Sub mn_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.ForeColor = Color.Black
    End Sub
    Private Sub mn_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.Pressed Then Return
        sender.ForeColor = Color.Black
    End Sub
    Private Sub mn_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.Pressed Then Return
        sender.ForeColor = Color.White
    End Sub

    Private Sub TBPOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPOptions.Click, mnPOptions.Click
        Dim xDOp As New OpPlayer(CurrentPlayer)
        xDOp.ShowDialog(Me)
    End Sub

    Private Sub THGenre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    THGenre.TextChanged, THTitle.TextChanged, THArtist.TextChanged, THPlayLevel.TextChanged, CHRank.SelectedIndexChanged, TExpansion.TextChanged, _
    THSubTitle.TextChanged, THSubArtist.TextChanged, THStageFile.TextChanged, THBanner.TextChanged, THBackBMP.TextChanged, _
    CHDifficulty.SelectedIndexChanged, THExRank.TextChanged, THTotal.TextChanged, THComment.TextChanged
        If IsSaved Then SetIsSaved(False)
    End Sub

    Private Sub CHLnObj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHLnObj.SelectedIndexChanged
        If IsSaved Then SetIsSaved(False)
        LnObj = CHLnObj.SelectedIndex
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub ConvertBMSE2NT()
        ReDim uNotes(-1)
        SortByVPositionInsertion()

        'Dim NewK(0) As Note
        'NewK(0) = K(0)
        ''With NewK(0)
        ''    .VPosition = K(0).VPosition
        ''    .ColumnIndex = K(0).ColumnIndex
        ''    .Value = K(0).Value
        ''    .LongNote = False
        ''    .Length = 0
        ''End With
        '
        'For xI1 As Integer = 1 To UBound(K)
        '    K(xI1).TempBoolean = False
        '    K(xI1).TempSelected = False
        'Next
        '
        'For xI1 As Integer = 1 To UBound(K)
        '    If Not K(xI1).TempBoolean Then
        '        ReDim Preserve NewK(NewK.Length)
        '        With NewK(UBound(NewK))
        '            .VPosition = K(xI1).VPosition
        '            .ColumnIndex = K(xI1).ColumnIndex
        '            .Value = K(xI1).Value
        '            .Selected = K(xI1).Selected
        '            .Hidden = K(xI1).Hidden
        '            .LongNote = K(xI1).TempSelected
        '
        '            If K(xI1).LongNote Then
        '                For xI2 As Integer = xI1 + 1 To UBound(K)
        '                    If K(xI2).ColumnIndex = K(xI1).ColumnIndex And K(xI2).LongNote Then
        '                        K(xI2).TempBoolean = True
        '                        .Length = K(xI2).VPosition - .VPosition
        '                        Exit For
        '                    ElseIf K(xI2).ColumnIndex = K(xI1).ColumnIndex Then
        '                        K(xI2).TempSelected = True
        '                    End If
        '                Next
        '            End If
        '
        '        End With
        '    End If
        'Next
        '
        'K = NewK

        For i2 As Integer = 0 To UBound(K)
            K(i2).Length = 0.0#
        Next

        Dim i As Integer = 1
        Dim j As Integer = 0
        Dim xUbound As Integer = UBound(K)

        Do While i <= xUbound
            If Not K(i).LongNote Then i += 1 : Continue Do

            For j = i + 1 To xUbound
                If K(j).ColumnIndex <> K(i).ColumnIndex Then Continue For

                If K(j).LongNote Then
                    K(i).Length = K(j).VPosition - K(i).VPosition
                    For j2 As Integer = j To xUbound - 1
                        K(j2) = K(j2 + 1)
                    Next
                    xUbound -= 1
                    Exit For

                ElseIf K(j).Value \ 10000 = LnObj Then
                    Exit For

                End If
            Next

            i += 1
        Loop

        ReDim Preserve K(xUbound)

        For i = 0 To xUbound
            K(i).LongNote = False
        Next

        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
    End Sub

    Private Sub ConvertNT2BMSE()
        ReDim uNotes(-1)
        Dim xK(0) As Note
        xK(0) = K(0)

        For xI1 As Integer = 1 To UBound(K)
            ReDim Preserve xK(UBound(xK) + 1)
            With xK(UBound(xK))
                .ColumnIndex = K(xI1).ColumnIndex
                .LongNote = K(xI1).Length > 0
                .Value = K(xI1).Value
                .VPosition = K(xI1).VPosition
                .Selected = K(xI1).Selected
                .Hidden = K(xI1).Hidden
            End With

            If K(xI1).Length > 0 Then
                ReDim Preserve xK(UBound(xK) + 1)
                With xK(UBound(xK))
                    .ColumnIndex = K(xI1).ColumnIndex
                    .LongNote = True
                    .Value = K(xI1).Value
                    .VPosition = K(xI1).VPosition + K(xI1).Length
                    .Selected = K(xI1).Selected
                    .Hidden = K(xI1).Hidden
                End With
            End If
        Next

        K = xK

        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
    End Sub

    Private Sub TBNTInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNTInput.Click, mnNTInput.Click
        'Dim xUndo As String = "NT_" & CInt(NTInput) & "_0" & vbCrLf & "KZ" & vbCrLf & sCmdKsAll(False)
        'Dim xRedo As String = "NT_" & CInt(Not NTInput) & "_1"
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        NTInput = sender.Checked

        TBNTInput.Checked = NTInput
        mnNTInput.Checked = NTInput
        POBLong.Enabled = Not NTInput
        POBLongShort.Enabled = Not NTInput

        bAdjustLength = False
        bAdjustUpper = False

        Me.RedoNT(NTInput, False, xUndo, xRedo)
        If NTInput Then
            ConvertBMSE2NT()
        Else
            ConvertNT2BMSE()
        End If
        Me.RedoAddNoteAll(False, xUndo, xRedo)

        AddUndo(xUndo, xBaseRedo.Next)
        RefreshPanelAll()
    End Sub

    Private Sub XMLLoadLocaleMenu(ByVal n As XmlElement, ByRef target As String)
        If n Is Nothing Then Exit Sub
        If n.HasAttribute("amp") Then
            target = n.InnerText.Insert(Integer.Parse(n.GetAttribute("amp")), "&")
        Else
            target = n.InnerText
        End If
    End Sub

    Private Sub XMLLoadLocale(ByVal n As XmlElement, ByRef target As String)
        If n IsNot Nothing Then target = n.InnerText
    End Sub

    Private Sub XMLLoadLocaleToolTipUniversal(ByVal n As XmlElement, ByVal target As Control)
        If n Is Nothing Then Exit Sub
        ToolTipUniversal.SetToolTip(target, n.InnerText)
    End Sub

    Private Function isFontInstalled(ByVal f As String) As Boolean
        Dim xFontCollection As New Drawing.Text.InstalledFontCollection
        For Each ff As FontFamily In xFontCollection.Families
            If f.Equals(ff.Name, StringComparison.CurrentCultureIgnoreCase) Then Return True
        Next
        Return False
    End Function

    Private Sub LoadLocale(ByVal Path As String)
        If Not My.Computer.FileSystem.FileExists(Path) Then Return

        'Dim xTempFileName As String = ""
        'Do
        ' Try
        ' xTempFileName = Me.RandomFileName(".xml")
        ' File.Copy(Path, xTempFileName)
        ' Catch
        ' Continue Do
        ' End Try
        ' Exit Do
        ' Loop

        Dim Doc As XmlDataDocument = Nothing
        Dim FileStream As IO.FileStream = Nothing

        Dim xPOHeaderPart2 As Boolean = POHeaderPart2.Visible
        Dim xPOGridPart2 As Boolean = POGridPart2.Visible
        Dim xPOWaveFormPart2 As Boolean = POWaveFormPart2.Visible
        POHeaderPart2.Visible = True
        POGridPart2.Visible = True
        POWaveFormPart2.Visible = True

        Try
            Doc = New XmlDataDocument
            FileStream = New IO.FileStream(Path, FileMode.Open, FileAccess.Read)
            Doc.Load(FileStream)

            Dim Root As XmlElement = Doc.Item("iBMSC.Locale")
            If Root Is Nothing Then Throw New NullReferenceException

            XMLLoadLocale(Root.Item("OK"), Locale.OK)
            XMLLoadLocale(Root.Item("Cancel"), Locale.Cancel)
            XMLLoadLocale(Root.Item("None"), Locale.None)

            Dim eFont As XmlElement = Root.Item("Font")
            If eFont IsNot Nothing Then
                Dim xSize As Integer = 9
                If eFont.HasAttribute("Size") Then xSize = Val(eFont.GetAttribute("Size"))

                Dim fRegular As New Font(Me.Font.FontFamily, xSize, FontStyle.Regular)
                Dim xChildNode As XmlNode = eFont.LastChild
                Do While xChildNode IsNot Nothing
                    If xChildNode.LocalName <> "Family" Then Continue Do
                    If Me.isFontInstalled(xChildNode.InnerText) Then
                        fRegular = New Font(xChildNode.InnerText, xSize)
                    End If
                    xChildNode = xChildNode.PreviousSibling
                Loop

                Dim rList() As Object = {Me, mnSys, Menu1, mnMain, cmnLanguage, cmnTheme, cmnConversion, TBMain, FStatus, FStatus2}
                For Each c As Object In rList
                    Try
                        c.Font = fRegular
                    Catch ex As Exception
                    End Try
                Next

                Dim fBold As New Font(fRegular, FontStyle.Bold)

                Dim bList() As Object = {TBStatistics, FSSS, FSSL, FSSH, TVCM, TVCD, TVCBPM, FSP1, FSP3, FSP2, PMain, PMainIn, PMainR, PMainInR, PMainL, PMainInL}
                For Each c As Object In bList
                    Try
                        c.Font = fBold
                    Catch ex As Exception
                    End Try
                Next
            End If

            Dim eMonoFont As XmlElement = Root.Item("MonoFont")
            If eMonoFont IsNot Nothing Then
                Dim xSize As Integer = 9
                If eMonoFont.HasAttribute("Size") Then xSize = Val(eMonoFont.GetAttribute("Size"))

                Dim fMono As New Font(POWAVInner.Font.FontFamily, xSize)
                Dim xChildNode As XmlNode = eMonoFont.LastChild
                Do While xChildNode IsNot Nothing
                    If xChildNode.LocalName <> "Family" Then Continue Do
                    If Me.isFontInstalled(xChildNode.InnerText) Then
                        fMono = New Font(xChildNode.InnerText, xSize)
                    End If
                    xChildNode = xChildNode.PreviousSibling
                Loop

                Dim mList() As Object = {LWAV, LBeat, TExpansion}
                For Each c As Object In mList
                    Try
                        c.font = fMono
                    Catch ex As Exception
                    End Try
                Next
            End If

            Dim eMenu As XmlElement = Root.Item("Menu")
            If eMenu IsNot Nothing Then

                Dim eFile As XmlElement = eMenu.Item("File")
                If eFile IsNot Nothing Then
                    XMLLoadLocaleMenu(eFile.Item("Title"), mnFile.Text)
                    XMLLoadLocaleMenu(eFile.Item("New"), mnNew.Text)
                    XMLLoadLocaleMenu(eFile.Item("Open"), mnOpen.Text)
                    XMLLoadLocaleMenu(eFile.Item("ImportSM"), mnImportSM.Text)
                    XMLLoadLocaleMenu(eFile.Item("ImportIBMSC"), mnImportIBMSC.Text)
                    XMLLoadLocaleMenu(eFile.Item("Save"), mnSave.Text)
                    XMLLoadLocaleMenu(eFile.Item("SaveAs"), mnSaveAs.Text)
                    XMLLoadLocaleMenu(eFile.Item("ExportIBMSC"), mnExport.Text)
                    If Recent(0) = "" Then XMLLoadLocaleMenu(eFile.Item("Recent0"), mnOpenR0.Text)
                    If Recent(1) = "" Then XMLLoadLocaleMenu(eFile.Item("Recent1"), mnOpenR1.Text)
                    If Recent(2) = "" Then XMLLoadLocaleMenu(eFile.Item("Recent2"), mnOpenR2.Text)
                    If Recent(3) = "" Then XMLLoadLocaleMenu(eFile.Item("Recent3"), mnOpenR3.Text)
                    If Recent(4) = "" Then XMLLoadLocaleMenu(eFile.Item("Recent4"), mnOpenR4.Text)
                    XMLLoadLocaleMenu(eFile.Item("Quit"), mnQuit.Text)
                End If

                Dim eEdit As XmlElement = eMenu.Item("Edit")
                If eEdit IsNot Nothing Then
                    XMLLoadLocaleMenu(eEdit.Item("Title"), mnEdit.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Undo"), mnUndo.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Redo"), mnRedo.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Cut"), mnCut.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Copy"), mnCopy.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Paste"), mnPaste.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Delete"), mnDelete.Text)
                    XMLLoadLocaleMenu(eEdit.Item("SelectAll"), mnSelectAll.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Find"), mnFind.Text)
                    XMLLoadLocaleMenu(eEdit.Item("Stat"), mnStatistics.Text)
                    XMLLoadLocaleMenu(eEdit.Item("TimeSelectionTool"), mnTimeSelect.Text)
                    XMLLoadLocaleMenu(eEdit.Item("SelectTool"), mnSelect.Text)
                    XMLLoadLocaleMenu(eEdit.Item("WriteTool"), mnWrite.Text)
                    XMLLoadLocaleMenu(eEdit.Item("MyO2"), mnMyO2.Text)
                End If

                Dim eOptions As XmlElement = eMenu.Item("Options")
                If eOptions IsNot Nothing Then
                    XMLLoadLocaleMenu(eOptions.Item("Title"), mnOptions.Text)
                    XMLLoadLocaleMenu(eOptions.Item("NT"), mnNTInput.Text)
                    XMLLoadLocaleMenu(eOptions.Item("ErrorCheck"), mnErrorCheck.Text)
                    XMLLoadLocaleMenu(eOptions.Item("PreviewOnClick"), mnPreviewOnClick.Text)
                    XMLLoadLocaleMenu(eOptions.Item("ShowFileName"), mnShowFileName.Text)
                    XMLLoadLocaleMenu(eOptions.Item("GeneralOptions"), mnGOptions.Text)
                    XMLLoadLocaleMenu(eOptions.Item("VisualOptions"), mnVOptions.Text)
                    XMLLoadLocaleMenu(eOptions.Item("PlayerOptions"), mnPOptions.Text)
                    XMLLoadLocaleMenu(eOptions.Item("Language"), mnLanguage.Text)
                    XMLLoadLocaleMenu(eOptions.Item("Theme"), mnTheme.Text)
                End If

                XMLLoadLocaleMenu(eMenu.Item("Conversion"), mnConversion.Text)

                Dim ePreview As XmlElement = eMenu.Item("Preview")
                If ePreview IsNot Nothing Then
                    XMLLoadLocaleMenu(ePreview.Item("Title"), mnPreview.Text)
                    XMLLoadLocaleMenu(ePreview.Item("PlayBegin"), mnPlayB.Text)
                    XMLLoadLocaleMenu(ePreview.Item("PlayHere"), mnPlay.Text)
                    XMLLoadLocaleMenu(ePreview.Item("PlayStop"), mnStop.Text)
                End If

                Dim eAbout As XmlElement = eMenu.Item("About")
                If eAbout IsNot Nothing Then
                    XMLLoadLocaleMenu(eAbout.Item("Title"), mnAbout.Text)
                    XMLLoadLocaleMenu(eAbout.Item("About"), mnAbout1.Text)
                    XMLLoadLocaleMenu(eAbout.Item("CheckUpdates"), mnUpdate.Text)
                    XMLLoadLocaleMenu(eAbout.Item("CheckUpdatesC"), mnUpdateC.Text)
                End If
            End If

            Dim eToolBar As XmlElement = Root.Item("ToolBar")
            If eToolBar IsNot Nothing Then
                XMLLoadLocale(eToolBar.Item("New"), TBNew.Text)
                XMLLoadLocale(eToolBar.Item("Open"), TBOpen.Text)
                XMLLoadLocale(eToolBar.Item("Save"), TBSave.Text)
                XMLLoadLocale(eToolBar.Item("Cut"), TBCut.Text)
                XMLLoadLocale(eToolBar.Item("Copy"), TBCopy.Text)
                XMLLoadLocale(eToolBar.Item("Paste"), TBPaste.Text)
                XMLLoadLocale(eToolBar.Item("Find"), TBFind.Text)
                XMLLoadLocale(eToolBar.Item("Stat"), TBStatistics.ToolTipText)
                XMLLoadLocale(eToolBar.Item("Conversion"), POConvert.Text)
                XMLLoadLocale(eToolBar.Item("MyO2"), TBMyO2.Text)
                XMLLoadLocale(eToolBar.Item("ErrorCheck"), TBErrorCheck.Text)
                XMLLoadLocale(eToolBar.Item("PreviewOnClick"), TBPreviewOnClick.Text)
                XMLLoadLocale(eToolBar.Item("ShowFileName"), TBShowFileName.Text)
                XMLLoadLocale(eToolBar.Item("Undo"), TBUndo.Text)
                XMLLoadLocale(eToolBar.Item("Redo"), TBRedo.Text)
                XMLLoadLocale(eToolBar.Item("NT"), TBNTInput.Text)
                XMLLoadLocale(eToolBar.Item("TimeSelectionTool"), TBTimeSelect.Text)
                XMLLoadLocale(eToolBar.Item("SelectTool"), TBSelect.Text)
                XMLLoadLocale(eToolBar.Item("WriteTool"), TBWrite.Text)
                XMLLoadLocale(eToolBar.Item("PlayBegin"), TBPlayB.Text)
                XMLLoadLocale(eToolBar.Item("PlayHere"), TBPlay.Text)
                XMLLoadLocale(eToolBar.Item("PlayStop"), TBStop.Text)
                XMLLoadLocale(eToolBar.Item("PlayerOptions"), TBPOptions.Text)
                XMLLoadLocale(eToolBar.Item("VisualOptions"), TBVOptions.Text)
                XMLLoadLocale(eToolBar.Item("GeneralOptions"), TBGOptions.Text)
                XMLLoadLocale(eToolBar.Item("Language"), TBLanguage.Text)
                XMLLoadLocale(eToolBar.Item("Theme"), TBTheme.Text)
                XMLLoadLocale(eToolBar.Item("About"), TBAbout.Text)
            End If

            Dim eStatusBar As XmlElement = Root.Item("StatusBar")
            If eStatusBar IsNot Nothing Then
                XMLLoadLocale(eStatusBar.Item("ColumnCaption"), FSC.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("NoteIndex"), FSW.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("MeasureIndex"), FSM.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("GridResolution"), FSP1.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("ReducedResolution"), FSP3.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("MeasureResolution"), FSP2.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("AbsolutePosition"), FSP4.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("Length"), Locale.StatusBar.Length)
                XMLLoadLocale(eStatusBar.Item("LongNote"), Locale.StatusBar.LongNote)
                XMLLoadLocale(eStatusBar.Item("Hidden"), Locale.StatusBar.Hidden)
                XMLLoadLocale(eStatusBar.Item("Error"), Locale.StatusBar.Err)
                XMLLoadLocale(eStatusBar.Item("SelStart"), FSSS.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("SelLength"), FSSL.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("SelSplit"), FSSH.ToolTipText)
                XMLLoadLocale(eStatusBar.Item("Reverse"), BVCReverse.Text)
                XMLLoadLocale(eStatusBar.Item("ByMultiple"), BVCApply.Text)
                XMLLoadLocale(eStatusBar.Item("ByValue"), BVCCalculate.Text)
            End If

            Dim eSubMenu As XmlElement = Root.Item("SubMenu")
            If eSubMenu IsNot Nothing Then

                Dim eShowHide As XmlElement = eSubMenu.Item("ShowHide")
                If eShowHide IsNot Nothing Then
                    Dim xToolTip As String = ToolTipUniversal.GetToolTip(ttlIcon)
                    XMLLoadLocaleMenu(eShowHide.Item("ToolTip"), xToolTip)
                    ToolTipUniversal.SetToolTip(ttlIcon, xToolTip)

                    XMLLoadLocaleMenu(eShowHide.Item("Menu"), mnSMenu.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("ToolBar"), mnSTB.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("OptionsPanel"), mnSOP.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("StatusBar"), mnSStatus.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("LSplit"), mnSLSplitter.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("RSplit"), mnSRSplitter.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("Grid"), CGShow.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("Sub"), CGShowS.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("BG"), CGShowBG.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("MeasureIndex"), CGShowM.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("MeasureLine"), CGShowMB.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("Vertical"), CGShowV.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("ColumnCaption"), CGShowC.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("BPM"), CGBPM.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("STOP"), CGSTOP.Text)
                    XMLLoadLocaleMenu(eShowHide.Item("BLP"), CGBLP.Text)
                End If

                Dim eInsertMeasure As XmlElement = eSubMenu.Item("InsertMeasure")
                If eInsertMeasure IsNot Nothing Then
                    XMLLoadLocaleMenu(eInsertMeasure.Item("Insert"), MInsert.Text)
                    XMLLoadLocaleMenu(eInsertMeasure.Item("Remove"), MRemove.Text)
                End If

                Dim eLanguage As XmlElement = eSubMenu.Item("Language")
                If eLanguage IsNot Nothing Then
                    XMLLoadLocaleMenu(eLanguage.Item("Default"), TBLangDef.Text)
                    XMLLoadLocaleMenu(eLanguage.Item("Refresh"), TBLangRefresh.Text)
                End If

                Dim eTheme As XmlElement = eSubMenu.Item("Theme")
                If eTheme IsNot Nothing Then
                    XMLLoadLocaleMenu(eTheme.Item("Default"), TBThemeDef.Text)
                    XMLLoadLocaleMenu(eTheme.Item("Save"), TBThemeSave.Text)
                    XMLLoadLocaleMenu(eTheme.Item("Refresh"), TBThemeRefresh.Text)
                    XMLLoadLocaleMenu(eTheme.Item("LoadComptability"), TBThemeLoadComptability.Text)
                End If

                Dim eConvert As XmlElement = eSubMenu.Item("Convert")
                If eConvert IsNot Nothing Then
                    XMLLoadLocaleMenu(eConvert.Item("Long"), POBLong.Text)
                    XMLLoadLocaleMenu(eConvert.Item("Short"), POBShort.Text)
                    XMLLoadLocaleMenu(eConvert.Item("LongShort"), POBLongShort.Text)
                    XMLLoadLocaleMenu(eConvert.Item("Hidden"), POBHidden.Text)
                    XMLLoadLocaleMenu(eConvert.Item("Visible"), POBVisible.Text)
                    XMLLoadLocaleMenu(eConvert.Item("HiddenVisible"), POBHiddenVisible.Text)
                    XMLLoadLocaleMenu(eConvert.Item("Relabel"), POBModify.Text)
                    XMLLoadLocaleMenu(eConvert.Item("Mirror"), POBMirror.Text)
                End If

                Dim eWAV As XmlElement = eSubMenu.Item("WAV")
                If eWAV IsNot Nothing Then
                    XMLLoadLocaleMenu(eWAV.Item("MultiSelection"), CWAVMultiSelect.Text)
                    XMLLoadLocaleMenu(eWAV.Item("Synchronize"), CWAVChangeLabel.Text)
                End If

                Dim eBeat As XmlElement = eSubMenu.Item("Beat")
                If eBeat IsNot Nothing Then
                    XMLLoadLocaleMenu(eBeat.Item("Absolute"), CBeatPreserve.Text)
                    XMLLoadLocaleMenu(eBeat.Item("Measure"), CBeatMeasure.Text)
                    XMLLoadLocaleMenu(eBeat.Item("Cut"), CBeatCut.Text)
                    XMLLoadLocaleMenu(eBeat.Item("Scale"), CBeatScale.Text)
                End If
            End If

            Dim eOptionsPanel As XmlElement = Root.Item("OptionsPanel")
            If eOptionsPanel IsNot Nothing Then

                Dim eHeader As XmlElement = eOptionsPanel.Item("Header")
                If eHeader IsNot Nothing Then
                    XMLLoadLocale(eHeader.Item("Header"), POHeaderSwitch.Text)
                    XMLLoadLocale(eHeader.Item("Title"), Label3.Text)
                    XMLLoadLocale(eHeader.Item("Artist"), Label4.Text)
                    XMLLoadLocale(eHeader.Item("Genre"), Label2.Text)
                    XMLLoadLocale(eHeader.Item("BPM"), Label9.Text)
                    XMLLoadLocale(eHeader.Item("Player"), Label8.Text)
                    XMLLoadLocale(eHeader.Item("Rank"), Label10.Text)
                    XMLLoadLocale(eHeader.Item("PlayLevel"), Label6.Text)
                    XMLLoadLocale(eHeader.Item("SubTitle"), Label15.Text)
                    XMLLoadLocale(eHeader.Item("SubArtist"), Label17.Text)
                    'XMLLoadLocale(eHeader.Item("Maker"), Label14.Text)
                    XMLLoadLocale(eHeader.Item("StageFile"), Label16.Text)
                    XMLLoadLocale(eHeader.Item("Banner"), Label12.Text)
                    XMLLoadLocale(eHeader.Item("BackBMP"), Label11.Text)
                    'XMLLoadLocale(eHeader.Item("MidiFile"), Label18.Text)
                    XMLLoadLocale(eHeader.Item("Difficulty"), Label21.Text)
                    XMLLoadLocale(eHeader.Item("ExRank"), Label23.Text)
                    XMLLoadLocale(eHeader.Item("Total"), Label20.Text)
                    'XMLLoadLocale(eHeader.Item("VolWav"), Label22.Text)
                    XMLLoadLocale(eHeader.Item("Comment"), Label19.Text)
                    'XMLLoadLocale(eHeader.Item("LnType"), Label13.Text)
                    XMLLoadLocale(eHeader.Item("LnObj"), Label24.Text)

                    RemoveHandler CHPlayer.SelectedIndexChanged, AddressOf CHPlayer_SelectedIndexChanged
                    XMLLoadLocale(eHeader.Item("Player1"), CHPlayer.Items.Item(0))
                    XMLLoadLocale(eHeader.Item("Player2"), CHPlayer.Items.Item(1))
                    XMLLoadLocale(eHeader.Item("Player3"), CHPlayer.Items.Item(2))
                    AddHandler CHPlayer.SelectedIndexChanged, AddressOf CHPlayer_SelectedIndexChanged

                    RemoveHandler CHRank.SelectedIndexChanged, AddressOf THGenre_TextChanged
                    XMLLoadLocale(eHeader.Item("Rank0"), CHRank.Items.Item(0))
                    XMLLoadLocale(eHeader.Item("Rank1"), CHRank.Items.Item(1))
                    XMLLoadLocale(eHeader.Item("Rank2"), CHRank.Items.Item(2))
                    XMLLoadLocale(eHeader.Item("Rank3"), CHRank.Items.Item(3))
                    XMLLoadLocale(eHeader.Item("Rank4"), CHRank.Items.Item(4))
                    AddHandler CHRank.SelectedIndexChanged, AddressOf THGenre_TextChanged

                    RemoveHandler CHDifficulty.SelectedIndexChanged, AddressOf THGenre_TextChanged
                    XMLLoadLocale(eHeader.Item("Difficulty0"), CHDifficulty.Items.Item(0))
                    XMLLoadLocale(eHeader.Item("Difficulty1"), CHDifficulty.Items.Item(1))
                    XMLLoadLocale(eHeader.Item("Difficulty2"), CHDifficulty.Items.Item(2))
                    XMLLoadLocale(eHeader.Item("Difficulty3"), CHDifficulty.Items.Item(3))
                    XMLLoadLocale(eHeader.Item("Difficulty4"), CHDifficulty.Items.Item(4))
                    XMLLoadLocale(eHeader.Item("Difficulty5"), CHDifficulty.Items.Item(5))
                    AddHandler CHDifficulty.SelectedIndexChanged, AddressOf THGenre_TextChanged
                End If

                Dim eGrid As XmlElement = eOptionsPanel.Item("Grid")
                If eGrid IsNot Nothing Then
                    XMLLoadLocale(eGrid.Item("Title"), POGridSwitch.Text)
                    XMLLoadLocale(eGrid.Item("Snap"), CGSnap.Text)
                    XMLLoadLocale(eGrid.Item("BCols"), Label1.Text)
                    XMLLoadLocale(eGrid.Item("DisableVertical"), CGDisableVertical.Text)
                    XMLLoadLocale(eGrid.Item("Scroll"), Label5.Text)
                    XMLLoadLocaleToolTipUniversal(eGrid.Item("LockLeft"), cVSLockL)
                    XMLLoadLocaleToolTipUniversal(eGrid.Item("LockMiddle"), cVSLock)
                    XMLLoadLocaleToolTipUniversal(eGrid.Item("LockRight"), cVSLockR)
                End If

                Dim eWaveForm As XmlElement = eOptionsPanel.Item("WaveForm")
                If eWaveForm IsNot Nothing Then
                    XMLLoadLocale(eWaveForm.Item("Title"), POWaveFormSwitch.Text)
                    XMLLoadLocaleToolTipUniversal(eWaveForm.Item("Load"), BWLoad)
                    XMLLoadLocaleToolTipUniversal(eWaveForm.Item("Clear"), BWClear)
                    XMLLoadLocaleToolTipUniversal(eWaveForm.Item("Lock"), BWLock)
                End If

                Dim eWAV As XmlElement = eOptionsPanel.Item("WAV")
                If eWAV IsNot Nothing Then
                    XMLLoadLocale(eWAV.Item("Title"), POWAVSwitch.Text)
                    XMLLoadLocaleToolTipUniversal(eWAV.Item("MoveUp"), BWAVUp)
                    XMLLoadLocaleToolTipUniversal(eWAV.Item("MoveDown"), BWAVDown)
                    XMLLoadLocaleToolTipUniversal(eWAV.Item("Browse"), BWAVBrowse)
                    XMLLoadLocaleToolTipUniversal(eWAV.Item("Remove"), BWAVRemove)
                End If

                XMLLoadLocale(eOptionsPanel.Item("Beat"), POBeatSwitch.Text)
                XMLLoadLocale(eOptionsPanel.Item("Beat.Apply"), BBeatApply.Text)
                XMLLoadLocale(eOptionsPanel.Item("Beat.Apply"), BBeatApplyV.Text)
                XMLLoadLocale(eOptionsPanel.Item("Expansion"), POExpansionSwitch.Text)
            End If

            Dim eMessages As XmlElement = Root.Item("Messages")
            If eMessages IsNot Nothing Then
                XMLLoadLocale(eMessages.Item("Err"), Locale.Messages.Err)
                XMLLoadLocale(eMessages.Item("SaveOnExit"), Locale.Messages.SaveOnExit)
                XMLLoadLocale(eMessages.Item("SaveOnExit1"), Locale.Messages.SaveOnExit1)
                XMLLoadLocale(eMessages.Item("SaveOnExit2"), Locale.Messages.SaveOnExit2)
                XMLLoadLocale(eMessages.Item("PromptEnter"), Locale.Messages.PromptEnter)
                XMLLoadLocale(eMessages.Item("PromptEnterNumeric"), Locale.Messages.PromptEnterNumeric)
                XMLLoadLocale(eMessages.Item("PromptEnterBPM"), Locale.Messages.PromptEnterBPM)
                XMLLoadLocale(eMessages.Item("PromptEnterSTOP"), Locale.Messages.PromptEnterSTOP)
                XMLLoadLocale(eMessages.Item("PromptSlashValue"), Locale.Messages.PromptSlashValue)
                XMLLoadLocale(eMessages.Item("InvalidLabel"), Locale.Messages.InvalidLabel)
                XMLLoadLocale(eMessages.Item("CannotFind"), Locale.Messages.CannotFind)
                XMLLoadLocale(eMessages.Item("PleaseRespecifyPath"), Locale.Messages.PleaseRespecifyPath)
                XMLLoadLocale(eMessages.Item("PlayerNotFound"), Locale.Messages.PlayerNotFound)
                XMLLoadLocale(eMessages.Item("PreviewDelError"), Locale.Messages.PreviewDelError)
                XMLLoadLocale(eMessages.Item("NegativeFactorError"), Locale.Messages.NegativeFactorError)
                XMLLoadLocale(eMessages.Item("NegativeDivisorError"), Locale.Messages.NegativeDivisorError)
                XMLLoadLocale(eMessages.Item("PreferencePostpone"), Locale.Messages.PreferencePostpone)
                XMLLoadLocale(eMessages.Item("EraserObsolete"), Locale.Messages.EraserObsolete)
                XMLLoadLocale(eMessages.Item("SaveWarning"), Locale.Messages.SaveWarning)
                XMLLoadLocale(eMessages.Item("NoteOverlapError"), Locale.Messages.NoteOverlapError)
                XMLLoadLocale(eMessages.Item("BPMOverflowError"), Locale.Messages.BPMOverflowError)
                XMLLoadLocale(eMessages.Item("STOPOverflowError"), Locale.Messages.STOPOverflowError)
                XMLLoadLocale(eMessages.Item("SavedFileWillContainErrors"), Locale.Messages.SavedFileWillContainErrors)
                XMLLoadLocale(eMessages.Item("FileAssociationPrompt"), Locale.Messages.FileAssociationPrompt)
                XMLLoadLocale(eMessages.Item("FileAssociationError"), Locale.Messages.FileAssociationError)
                XMLLoadLocale(eMessages.Item("RestoreDefaultSettings"), Locale.Messages.RestoreDefaultSettings)
                XMLLoadLocale(eMessages.Item("RestoreAutosavedFile"), Locale.Messages.RestoreAutosavedFile)
            End If

            Dim eFileType As XmlElement = Root.Item("FileType")
            If eFileType IsNot Nothing Then
                XMLLoadLocale(eFileType.Item("_all"), Locale.FileType._all)
                XMLLoadLocale(eFileType.Item("_bms"), Locale.FileType._bms)
                XMLLoadLocale(eFileType.Item("BMS"), Locale.FileType.BMS)
                XMLLoadLocale(eFileType.Item("BME"), Locale.FileType.BME)
                XMLLoadLocale(eFileType.Item("BML"), Locale.FileType.BML)
                XMLLoadLocale(eFileType.Item("PMS"), Locale.FileType.PMS)
                XMLLoadLocale(eFileType.Item("TXT"), Locale.FileType.TXT)
                XMLLoadLocale(eFileType.Item("SM"), Locale.FileType.SM)
                XMLLoadLocale(eFileType.Item("IBMSC"), Locale.FileType.IBMSC)
                XMLLoadLocale(eFileType.Item("XML"), Locale.FileType.XML)
                XMLLoadLocale(eFileType.Item("THEME_XML"), Locale.FileType.THEME_XML)
                XMLLoadLocale(eFileType.Item("TH"), Locale.FileType.TH)
                XMLLoadLocale(eFileType.Item("_audio"), Locale.FileType._audio)
                XMLLoadLocale(eFileType.Item("_wave"), Locale.FileType._wave)
                XMLLoadLocale(eFileType.Item("WAV"), Locale.FileType.WAV)
                XMLLoadLocale(eFileType.Item("OGG"), Locale.FileType.OGG)
                XMLLoadLocale(eFileType.Item("MP3"), Locale.FileType.MP3)
                XMLLoadLocale(eFileType.Item("MID"), Locale.FileType.MID)
                XMLLoadLocale(eFileType.Item("_image"), Locale.FileType._image)
                XMLLoadLocale(eFileType.Item("EXE"), Locale.FileType.EXE)
            End If

            Dim eStatistics As XmlElement = Root.Item("Statistics")
            If eStatistics IsNot Nothing Then
                XMLLoadLocale(eStatistics.Item("Title"), Locale.fStatistics.Title)
                XMLLoadLocale(eStatistics.Item("lBPM"), Locale.fStatistics.lBPM)
                XMLLoadLocale(eStatistics.Item("lSTOP"), Locale.fStatistics.lSTOP)
                XMLLoadLocale(eStatistics.Item("lA"), Locale.fStatistics.lA)
                XMLLoadLocale(eStatistics.Item("lD"), Locale.fStatistics.lD)
                XMLLoadLocale(eStatistics.Item("lBGM"), Locale.fStatistics.lBGM)
                XMLLoadLocale(eStatistics.Item("lTotal"), Locale.fStatistics.lTotal)
                XMLLoadLocale(eStatistics.Item("lShort"), Locale.fStatistics.lShort)
                XMLLoadLocale(eStatistics.Item("lLong"), Locale.fStatistics.lLong)
                XMLLoadLocale(eStatistics.Item("lLnObj"), Locale.fStatistics.lLnObj)
                XMLLoadLocale(eStatistics.Item("lHidden"), Locale.fStatistics.lHidden)
                XMLLoadLocale(eStatistics.Item("lErrors"), Locale.fStatistics.lErrors)
            End If

            Dim ePlayerOptions As XmlElement = Root.Item("PlayerOptions")
            If ePlayerOptions IsNot Nothing Then
                XMLLoadLocale(ePlayerOptions.Item("Title"), Locale.fopPlayer.Title)
                XMLLoadLocale(ePlayerOptions.Item("Add"), Locale.fopPlayer.Add)
                XMLLoadLocale(ePlayerOptions.Item("Remove"), Locale.fopPlayer.Remove)
                XMLLoadLocale(ePlayerOptions.Item("Path"), Locale.fopPlayer.Path)
                XMLLoadLocale(ePlayerOptions.Item("PlayFromBeginning"), Locale.fopPlayer.PlayFromBeginning)
                XMLLoadLocale(ePlayerOptions.Item("PlayFromHere"), Locale.fopPlayer.PlayFromHere)
                XMLLoadLocale(ePlayerOptions.Item("StopPlaying"), Locale.fopPlayer.StopPlaying)
                XMLLoadLocale(ePlayerOptions.Item("References"), Locale.fopPlayer.References)
                XMLLoadLocale(ePlayerOptions.Item("DirectoryOfApp"), Locale.fopPlayer.DirectoryOfApp)
                XMLLoadLocale(ePlayerOptions.Item("CurrMeasure"), Locale.fopPlayer.CurrMeasure)
                XMLLoadLocale(ePlayerOptions.Item("FileName"), Locale.fopPlayer.FileName)
                XMLLoadLocale(ePlayerOptions.Item("RestoreDefault"), Locale.fopPlayer.RestoreDefault)
            End If

            Dim eVisualOptions As XmlElement = Root.Item("VisualOptions")
            If eVisualOptions IsNot Nothing Then
                XMLLoadLocale(eVisualOptions.Item("Title"), Locale.fopVisual.Title)
                XMLLoadLocale(eVisualOptions.Item("Width"), Locale.fopVisual.Width)
                XMLLoadLocale(eVisualOptions.Item("Caption"), Locale.fopVisual.Caption)
                XMLLoadLocale(eVisualOptions.Item("Note"), Locale.fopVisual.Note)
                XMLLoadLocale(eVisualOptions.Item("Label"), Locale.fopVisual.Label)
                XMLLoadLocale(eVisualOptions.Item("LongNote"), Locale.fopVisual.LongNote)
                XMLLoadLocale(eVisualOptions.Item("LongNoteLabel"), Locale.fopVisual.LongNoteLabel)
                XMLLoadLocale(eVisualOptions.Item("Bg"), Locale.fopVisual.Bg)
                XMLLoadLocale(eVisualOptions.Item("ColumnCaption"), Locale.fopVisual.ColumnCaption)
                XMLLoadLocale(eVisualOptions.Item("ColumnCaptionFont"), Locale.fopVisual.ColumnCaptionFont)
                XMLLoadLocale(eVisualOptions.Item("Background"), Locale.fopVisual.Background)
                XMLLoadLocale(eVisualOptions.Item("Grid"), Locale.fopVisual.Grid)
                XMLLoadLocale(eVisualOptions.Item("SubGrid"), Locale.fopVisual.SubGrid)
                XMLLoadLocale(eVisualOptions.Item("VerticalLine"), Locale.fopVisual.VerticalLine)
                XMLLoadLocale(eVisualOptions.Item("MeasureBarLine"), Locale.fopVisual.MeasureBarLine)
                XMLLoadLocale(eVisualOptions.Item("BGMWaveform"), Locale.fopVisual.BGMWaveform)
                XMLLoadLocale(eVisualOptions.Item("NoteHeight"), Locale.fopVisual.NoteHeight)
                XMLLoadLocale(eVisualOptions.Item("NoteLabel"), Locale.fopVisual.NoteLabel)
                XMLLoadLocale(eVisualOptions.Item("MeasureLabel"), Locale.fopVisual.MeasureLabel)
                XMLLoadLocale(eVisualOptions.Item("LabelVerticalShift"), Locale.fopVisual.LabelVerticalShift)
                XMLLoadLocale(eVisualOptions.Item("LabelHorizontalShift"), Locale.fopVisual.LabelHorizontalShift)
                XMLLoadLocale(eVisualOptions.Item("LongNoteLabelHorizontalShift"), Locale.fopVisual.LongNoteLabelHorizontalShift)
                XMLLoadLocale(eVisualOptions.Item("HiddenNoteOpacity"), Locale.fopVisual.HiddenNoteOpacity)
                XMLLoadLocale(eVisualOptions.Item("NoteBorderOnMouseOver"), Locale.fopVisual.NoteBorderOnMouseOver)
                XMLLoadLocale(eVisualOptions.Item("NoteBorderOnSelection"), Locale.fopVisual.NoteBorderOnSelection)
                XMLLoadLocale(eVisualOptions.Item("NoteBorderOnAdjustingLength"), Locale.fopVisual.NoteBorderOnAdjustingLength)
                XMLLoadLocale(eVisualOptions.Item("SelectionBoxBorder"), Locale.fopVisual.SelectionBoxBorder)
                XMLLoadLocale(eVisualOptions.Item("TSCursor"), Locale.fopVisual.TSCursor)
                XMLLoadLocale(eVisualOptions.Item("TSSplitter"), Locale.fopVisual.TSSplitter)
                XMLLoadLocale(eVisualOptions.Item("TSCursorSensitivity"), Locale.fopVisual.TSCursorSensitivity)
                XMLLoadLocale(eVisualOptions.Item("TSMouseOverBorder"), Locale.fopVisual.TSMouseOverBorder)
                XMLLoadLocale(eVisualOptions.Item("TSFill"), Locale.fopVisual.TSFill)
                XMLLoadLocale(eVisualOptions.Item("TSBPM"), Locale.fopVisual.TSBPM)
                XMLLoadLocale(eVisualOptions.Item("TSBPMFont"), Locale.fopVisual.TSBPMFont)
                XMLLoadLocale(eVisualOptions.Item("MiddleSensitivity"), Locale.fopVisual.MiddleSensitivity)
            End If

            Dim eGeneralOptions As XmlElement = Root.Item("GeneralOptions")
            If eGeneralOptions IsNot Nothing Then
                XMLLoadLocale(eGeneralOptions.Item("Title"), Locale.fopGeneral.Title)
                XMLLoadLocale(eGeneralOptions.Item("MouseWheel"), Locale.fopGeneral.MouseWheel)
                XMLLoadLocale(eGeneralOptions.Item("TextEncoding"), Locale.fopGeneral.TextEncoding)
                'XMLLoadLocale(eGeneralOptions.Item("SortingMethod"), Locale.fopGeneral.SortingMethod)
                'XMLLoadLocale(eGeneralOptions.Item("sortBubble"), Locale.fopGeneral.sortBubble)
                'XMLLoadLocale(eGeneralOptions.Item("sortInsertion"), Locale.fopGeneral.sortInsertion)
                'XMLLoadLocale(eGeneralOptions.Item("sortQuick"), Locale.fopGeneral.sortQuick)
                'XMLLoadLocale(eGeneralOptions.Item("sortQuickD3"), Locale.fopGeneral.sortQuickD3)
                'XMLLoadLocale(eGeneralOptions.Item("sortHeap"), Locale.fopGeneral.sortHeap)
                XMLLoadLocale(eGeneralOptions.Item("PageUpDown"), Locale.fopGeneral.PageUpDown)
                XMLLoadLocale(eGeneralOptions.Item("MiddleButton"), Locale.fopGeneral.MiddleButton)
                XMLLoadLocale(eGeneralOptions.Item("MiddleButtonAuto"), Locale.fopGeneral.MiddleButtonAuto)
                XMLLoadLocale(eGeneralOptions.Item("MiddleButtonDrag"), Locale.fopGeneral.MiddleButtonDrag)
                XMLLoadLocale(eGeneralOptions.Item("AssociateFileType"), Locale.fopGeneral.AssociateFileType)
                XMLLoadLocale(eGeneralOptions.Item("MaxGridPartition"), Locale.fopGeneral.MaxGridPartition)
                XMLLoadLocale(eGeneralOptions.Item("BeepWhileSaved"), Locale.fopGeneral.BeepWhileSaved)
                XMLLoadLocale(eGeneralOptions.Item("ExtendBPM"), Locale.fopGeneral.ExtendBPM)
                XMLLoadLocale(eGeneralOptions.Item("ExtendSTOP"), Locale.fopGeneral.ExtendSTOP)
                XMLLoadLocale(eGeneralOptions.Item("AutoFocusOnMouseEnter"), Locale.fopGeneral.AutoFocusOnMouseEnter)
                XMLLoadLocale(eGeneralOptions.Item("DisableFirstClick"), Locale.fopGeneral.DisableFirstClick)
                XMLLoadLocale(eGeneralOptions.Item("AutoSave"), Locale.fopGeneral.AutoSave)
                XMLLoadLocale(eGeneralOptions.Item("minutes"), Locale.fopGeneral.minutes)
                XMLLoadLocale(eGeneralOptions.Item("StopPreviewOnClick"), Locale.fopGeneral.StopPreviewOnClick)
            End If

            Dim eFind As XmlElement = Root.Item("Find")
            If eFind IsNot Nothing Then
                XMLLoadLocale(eFind.Item("NoteRange"), Locale.fFind.NoteRange)
                XMLLoadLocale(eFind.Item("MeasureRange"), Locale.fFind.MeasureRange)
                XMLLoadLocale(eFind.Item("LabelRange"), Locale.fFind.LabelRange)
                XMLLoadLocale(eFind.Item("ValueRange"), Locale.fFind.ValueRange)
                XMLLoadLocale(eFind.Item("to"), Locale.fFind.to_)
                XMLLoadLocale(eFind.Item("Selected"), Locale.fFind.Selected)
                XMLLoadLocale(eFind.Item("UnSelected"), Locale.fFind.UnSelected)
                XMLLoadLocale(eFind.Item("ShortNote"), Locale.fFind.ShortNote)
                XMLLoadLocale(eFind.Item("LongNote"), Locale.fFind.LongNote)
                XMLLoadLocale(eFind.Item("Hidden"), Locale.fFind.Hidden)
                XMLLoadLocale(eFind.Item("Visible"), Locale.fFind.Visible)
                XMLLoadLocale(eFind.Item("Column"), Locale.fFind.Column)
                XMLLoadLocale(eFind.Item("SelectAll"), Locale.fFind.SelectAll)
                XMLLoadLocale(eFind.Item("SelectInverse"), Locale.fFind.SelectInverse)
                XMLLoadLocale(eFind.Item("UnselectAll"), Locale.fFind.UnselectAll)
                XMLLoadLocale(eFind.Item("Operation"), Locale.fFind.Operation)
                XMLLoadLocale(eFind.Item("ReplaceWithLabel"), Locale.fFind.ReplaceWithLabel)
                XMLLoadLocale(eFind.Item("ReplaceWithValue"), Locale.fFind.ReplaceWithValue)
                XMLLoadLocale(eFind.Item("Select"), Locale.fFind.Select_)
                XMLLoadLocale(eFind.Item("Unselect"), Locale.fFind.Unselect_)
                XMLLoadLocale(eFind.Item("Delete"), Locale.fFind.Delete_)
                XMLLoadLocale(eFind.Item("Close"), Locale.fFind.Close_)
            End If

            Dim eImportSM As XmlElement = Root.Item("ImportSM")
            If eImportSM IsNot Nothing Then
                XMLLoadLocale(eImportSM.Item("Title"), Locale.fImportSM.Title)
                XMLLoadLocale(eImportSM.Item("Difficulty"), Locale.fImportSM.Difficulty)
                XMLLoadLocale(eImportSM.Item("Note"), Locale.fImportSM.Note)
            End If

            Dim eFileAssociation As XmlElement = Root.Item("FileAssociation")
            If eFileAssociation IsNot Nothing Then
                XMLLoadLocale(eFileAssociation.Item("BMS"), Locale.FileAssociation.BMS)
                XMLLoadLocale(eFileAssociation.Item("BME"), Locale.FileAssociation.BME)
                XMLLoadLocale(eFileAssociation.Item("BML"), Locale.FileAssociation.BML)
                XMLLoadLocale(eFileAssociation.Item("PMS"), Locale.FileAssociation.PMS)
                XMLLoadLocale(eFileAssociation.Item("IBMSC"), Locale.FileAssociation.IBMSC)
                XMLLoadLocale(eFileAssociation.Item("Open"), Locale.FileAssociation.Open)
                XMLLoadLocale(eFileAssociation.Item("Preview"), Locale.FileAssociation.Preview)
                XMLLoadLocale(eFileAssociation.Item("ViewCode"), Locale.FileAssociation.ViewCode)
            End If

            DispLang = Path.Replace(My.Application.Info.DirectoryPath & "\", "")

        Catch ex As Exception
            MsgBox(Path & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

        Finally
            If FileStream IsNot Nothing Then FileStream.Close()

            POHeaderPart2.Visible = xPOHeaderPart2
            POGridPart2.Visible = xPOGridPart2
            POWaveFormPart2.Visible = xPOWaveFormPart2
        End Try

        'File.Delete(xTempFileName)
    End Sub

    'Private Sub ReadLanguagePack(ByVal FilePath As String)
    '    If FilePath = "" Then Exit Sub
    '    If Not My.Computer.FileSystem.FileExists(FilePath) Then
    '        MsgBox(Locale.Messages.CannotFind & " " & FilePath, MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground)
    '        Return
    '    End If
    '
    '    Dim xStrLine() As String = Split(My.Computer.FileSystem.ReadAllText(FilePath, System.Text.Encoding.Unicode), vbCrLf)
    '    If Not xStrLine(0).Trim = "iBMSC Language Pack Format" Then Exit Sub
    '    DispLang = FilePath
    '    Dim xW1 As String
    '    Dim xW2 As String
    '    Dim xInstr As Integer
    '
    '    For Each xLine As String In xStrLine
    '        xInstr = InStr(xLine, "=")
    '        If xInstr = 0 Then Continue For
    '        xW1 = UCase(Mid(xLine, 1, xInstr - 1))
    '        xW2 = Mid(xLine, xInstr + 1)
    '
    '        Select Case xW1
    '            Case "TBNEW" : TBNew.Text = xW2
    '                'Case "TBNEWC" : TBNewC.Text = xW2
    '            Case "TBOPEN" : TBOpen.Text = xW2
    '            Case "TBIMPORTIBMSC" : TBImportIBMSC.Text = xW2
    '            Case "TBIMPORTSM" : TBImportSM.Text = xW2
    '            Case "TBSAVE" : TBSave.Text = xW2
    '            Case "TBSAVEAS" : TBSaveAs.Text = xW2
    '            Case "TBEXPORT" : TBExport.Text = xW2
    '            Case "TBCUT" : TBCut.Text = xW2
    '            Case "TBCOPY" : TBCopy.Text = xW2
    '            Case "TBPASTE" : TBPaste.Text = xW2
    '            Case "TBFIND" : TBFind.Text = xW2
    '            Case "TBSTAT" : TBStatistics.ToolTipText = xW2
    '            Case "TBMYO2" : TBMyO2.Text = xW2
    '            Case "TBCHECK" : TBErrorCheck.Text = xW2
    '            Case "TBSHOWFN" : TBShowFileName.Text = xW2
    '            Case "TBPREV" : TBPreviewOnClick.Text = xW2
    '                'Case "TBPREVC" : TBPreviewErrorCheck.Text = xW2
    '            Case "TBUNDO" : TBUndo.Text = xW2
    '            Case "TBREDO" : TBRedo.Text = xW2
    '
    '            Case "TBTOLONG" : POBLong.Text = xW2
    '            Case "TBTOSHORT" : POBShort.Text = xW2
    '            Case "TBLONGSHORT" : POBLongShort.Text = xW2
    '            Case "TBTOHIDDEN" : POBHidden.Text = xW2
    '            Case "TBTOVISIBLE" : POBVisible.Text = xW2
    '            Case "TBHIDDENVISIBLE" : POBHiddenVisible.Text = xW2
    '            Case "TBMODIFYLABEL" : POBModify.Text = xW2
    '
    '            Case "TBCONVERT" : POConvert.Text = xW2
    '            Case "TBSTORM" : POBStorm.Text = xW2
    '            Case "TBMIRROR" : POBMirror.Text = xW2
    '            Case "TBNT" : TBNTInput.Text = xW2
    '            Case "TBTIMESEL" : TBTimeSelect.Text = xW2
    '            Case "TBSELECT" : TBSelect.Text = xW2
    '            Case "TBWRITE" : TBWrite.Text = xW2
    '
    '            Case "TBPLAYB" : TBPlayB.Text = xW2
    '            Case "TBPLAY" : TBPlay.Text = xW2
    '            Case "TBSTOP" : TBStop.Text = xW2
    '            Case "TBGOPTIONS" : TBGOptions.Text = xW2
    '            Case "TBVOPTIONS" : TBVOptions.Text = xW2
    '            Case "TBTHEME" : TBTheme.Text = xW2
    '            Case "TBTHEMEDEF" : TBThemeDef.Text = "(" & xW2 & ")"
    '            Case "TBTHEMESAVE" : TBThemeSave.Text = xW2
    '            Case "TBTHEMEREFRESH" : TBThemeRefresh.Text = xW2
    '            Case "TBABOUT" : TBAbout.Text = xW2
    '
    '                'Case "TEMPWRITEBPM" : lpTempWriteBPM = xW2
    '
    '            Case "POHTTL" : POHeader1.Text = xW2
    '            Case "POHG" : Label2.Text = xW2
    '            Case "POHT" : Label3.Text = xW2
    '            Case "POHA" : Label4.Text = xW2
    '            Case "POHP" : Label6.Text = xW2
    '            Case "POHBPM" : Label9.Text = xW2
    '                'Case "POHN" : Label1.Text = xW2
    '
    '            Case "POGTTL" : POGrid.Text = xW2
    '            Case "POGCSNAP" : CGSnap.Text = xW2
    '
    '            Case "POWTTL" : POWaveForm.Text = xW2
    '            Case "POWNONE"
    '                Locale.None = xW2
    '                If wWavL Is Nothing And wWavR Is Nothing Then TWFileName.Text = "(" & xW2 & ")"
    '
    '                'Case "POPTTL" : POPrev.Text = xW2
    '
    '            Case "LVCINVERT" : BVCInvert.Text = xW2
    '            Case "LVCAPPLY" : BVCApply.Text = xW2
    '            Case "LVCCALCULATE" : BVCCalculate.Text = xW2
    '
    '            Case "MSGERR" : Locale.Messages.Err = xW2
    '            Case "MSGSAVE" : Locale.Messages.SaveOnExit = xW2
    '            Case "MSGSAVE1" : Locale.Messages.SaveOnExit1 = xW2
    '            Case "MSGSAVE2" : Locale.Messages.SaveOnExit2 = xW2
    '            Case "MSGPREVCERR" : Locale.Messages.PreviewError = xW2
    '                'Case "MSGPREVCERR1" : lpmsg(5) = xW2
    '                'Case "MSGPREVCERR2" : lpmsg(6) = xW2
    '            Case "MSGENTER" : Locale.Messages.PromptEnter = xW2
    '            Case "MSGENTER1" : Locale.Messages.PromptEnterBPM = xW2
    '            Case "MSGENTERERR" : Locale.Messages.InvalidLabel = xW2
    '                'Case "MSGNEWC" : lpmsg(10) = xW2
    '            Case "MSGPREVERR1" : Locale.Messages.CannotFind = xW2
    '            Case "MSGPREVERR2" : Locale.Messages.PleaseRespecifyPath = xW2
    '            Case "MSGPREVERRT" : Locale.Messages.PlayerNotFound = xW2
    '            Case "MSGPREVERRARG" : Locale.Messages.PreviewArgError = xW2
    '            Case "MSGPREVERRDEL" : Locale.Messages.PreviewDelError = xW2
    '            Case "MSGVCERRF" : Locale.Messages.NegativeFactorError = xW2
    '            Case "MSGVCERRD" : Locale.Messages.NegativeDivisorError = xW2
    '            Case "MSGLANGDEF" : Locale.Messages.PreferencePostpone = xW2
    '            Case "MSGF4" : Locale.Messages.EraserObsolete = xW2
    '            Case "MSGBPMX1" : Locale.Messages.SaveWarning = xW2
    '            Case "MSGBPMX2" : Locale.Messages.BPMOverflowError = xW2
    '            Case "MSGBPMX3" : Locale.Messages.SavedFileWillContainErrors = xW2
    '            Case "MSGSTOPX1" : Locale.Messages.SaveWarning = xW2
    '            Case "MSGSTOPX2" : Locale.Messages.STOPOverflowError = xW2
    '            Case "MSGSTOPX3" : Locale.Messages.SavedFileWillContainErrors = xW2
    '            Case "MSGASSOCIATION" : Locale.Messages.FileAssociationPrompt = xW2
    '            Case "MSGRESDEFAULT" : Locale.Messages.RestoreDefaultSettings = xW2
    '            Case "MSGRECOVER" : Locale.Messages.RestoreAutosavedFile = xW2
    '
    '                'Case "TYPEALL" : lptype(0) = xW2
    '                'Case "TYPEBMS" : lptype(1) = xW2
    '                'Case "TYPETXT" : lptype(2) = xW2
    '                'Case "TYPEAUDIO" : lptype(3) = xW2
    '                'Case "TYPEWAV" : lptype(4) = xW2
    '                'Case "TYPEOGG" : lptype(5) = xW2
    '                'Case "TYPEMP3" : lptype(6) = xW2
    '                'Case "TYPEEXE" : lptype(7) = xW2
    '
    '                'Case "STATTTL" : lpstat(0) = xW2
    '                'Case "STATTOTAL" : lpstat(1) = xW2
    '                'Case "STATSHORT" : lpstat(2) = xW2
    '                'Case "STATLONG" : lpstat(3) = xW2
    '                'Case "STATERROR" : lpstat(4) = xW2
    '                'Case "STATBNOTES" : lpstat(5) = xW2
    '                'Case "STATOK" : lpstat(6) = xW2
    '
    '                'Case "PARGTTL" : lpparg(0) = xW2
    '                'Case "PARGPATH" : lpparg(1) = xW2
    '                'Case "PARGBROWSE" : lpparg(2) = xW2
    '                'Case "PARGARG" : lpparg(3) = xW2
    '                'Case "PARGPLAYB" : lpparg(4) = xW2
    '                'Case "PARGPLAY" : lpparg(5) = xW2
    '                'Case "PARGSTOP" : lpparg(6) = xW2
    '                'Case "PARGREF0" : lpparg(7) = xW2
    '                'Case "PARGREF1" : lpparg(8) = xW2
    '                'Case "PARGREF2" : lpparg(9) = xW2
    '                'Case "PARGREF3" : lpparg(10) = xW2
    '                'Case "PARGOK" : lpparg(11) = xW2
    '                'Case "PARGCANCEL" : lpparg(12) = xW2
    '
    '                'Case "VOTTL" : lpvo(0) = xW2
    '                'Case "VOP1TTL" : lpvo(1) = xW2
    '                'Case "VOP2TTL" : lpvo(2) = xW2
    '                'Case "VOP1MEASURE" : lpvo(3) = xW2
    '                'Case "VOP1BPM" : lpvo(4) = xW2
    '                'Case "VOP1SEPERATOR" : lpvo(5) = xW2
    '                'Case "VOP1A1" : lpvo(6) = xW2
    '                'Case "VOP1A2" : lpvo(7) = xW2
    '                'Case "VOP1A3" : lpvo(8) = xW2
    '                'Case "VOP1A4" : lpvo(9) = xW2
    '                'Case "VOP1A5" : lpvo(10) = xW2
    '                'Case "VOP1A6" : lpvo(11) = xW2
    '                'Case "VOP1A7" : lpvo(12) = xW2
    '                'Case "VOP1B" : lpvo(13) = xW2
    '                'Case "VOP1WIDTH" : lpvo(14) = xW2
    '                'Case "VOP1CAPTION" : lpvo(15) = xW2
    '                'Case "VOP1ISNUM" : lpvo(16) = xW2
    '                'Case "VOP1NOTE" : lpvo(17) = xW2
    '                'Case "VOP1LABEL" : lpvo(18) = xW2
    '                'Case "VOP1LNOTE" : lpvo(19) = xW2
    '                'Case "VOP1LLABEL" : lpvo(20) = xW2
    '                'Case "VOP1BG" : lpvo(21) = xW2
    '                'Case "VOP2X1" : lpvo(22) = xW2
    '                'Case "VOP2X2" : lpvo(23) = xW2
    '                'Case "VOP2X3" : lpvo(24) = xW2
    '                'Case "VOP2X4" : lpvo(25) = xW2
    '                'Case "VOP2X5" : lpvo(26) = xW2
    '                'Case "VOP2X6" : lpvo(27) = xW2
    '                'Case "VOP2X7" : lpvo(28) = xW2
    '                'Case "VOP2X8" : lpvo(29) = xW2
    '                'Case "VOP2X9" : lpvo(30) = xW2
    '                'Case "VOP2X10" : lpvo(31) = xW2
    '                'Case "VOP2X11" : lpvo(32) = xW2
    '                'Case "VOP2X12" : lpvo(33) = xW2
    '                'Case "VOP2X13" : lpvo(34) = xW2
    '                'Case "VOP2X14" : lpvo(35) = xW2
    '                'Case "VOP2X15" : lpvo(36) = xW2
    '                'Case "VOP2X16" : lpvo(37) = xW2
    '                'Case "VOP2X17" : lpvo(38) = xW2
    '                'Case "VOP2X18" : lpvo(39) = xW2
    '                'Case "VOP2X19" : lpvo(40) = xW2
    '                'Case "VOP2X20" : lpvo(41) = xW2
    '                'Case "VOP2X21" : lpvo(44) = xW2
    '                'Case "VOOK" : lpvo(42) = xW2
    '                'Case "VOCANCEL" : lpvo(43) = xW2
    '                '
    '                'Case "GOTTL" : lpgo(0) = xW2
    '                'Case "GOS1" : lpgo(1) = xW2
    '                'Case "GOS2" : lpgo(2) = xW2
    '                'Case "GOS3" : lpgo(3) = xW2
    '                'Case "GOS3X1" : lpgo(4) = xW2
    '                'Case "GOS3X2" : lpgo(5) = xW2
    '                'Case "GOS3X3" : lpgo(6) = xW2
    '                'Case "GOS3X4" : lpgo(7) = xW2
    '                'Case "GOS3X5" : lpgo(8) = xW2
    '                'Case "GOOK" : lpgo(9) = xW2
    '                'Case "GOCANCEL" : lpgo(10) = xW2
    '                'Case "GOS4" : lpgo(11) = xW2
    '                'Case "GOS4X1" : lpgo(12) = xW2
    '                'Case "GOC1" : lpgo(13) = xW2
    '                'Case "GOC2" : lpgo(14) = xW2
    '                'Case "GOC3" : lpgo(15) = xW2
    '                'Case "GOC4" : lpgo(16) = xW2
    '                'Case "GOC5" : lpgo(17) = xW2
    '                'Case "GOC6" : lpgo(18) = xW2
    '                'Case "GOC7" : lpgo(19) = xW2
    '                'Case "GOC7B" : lpgo(20) = xW2
    '                'Case "GOC8" : lpgo(21) = xW2
    '                'Case "GOS5" : lpgo(22) = xW2
    '                '
    '                'Case "FDRNR" : lpfdr(0) = xW2
    '                'Case "FDRMR" : lpfdr(1) = xW2
    '                'Case "FDRLR" : lpfdr(2) = xW2
    '                'Case "FDRVR" : lpfdr(3) = xW2
    '                'Case "FDRTO" : lpfdr(4) = xW2
    '                'Case "FDRRSEL" : lpfdr(5) = xW2
    '                'Case "FDRRUNSEL" : lpfdr(6) = xW2
    '                'Case "FDRRSHORT" : lpfdr(7) = xW2
    '                'Case "FDRRLONG" : lpfdr(8) = xW2
    '                'Case "FDRRHID" : lpfdr(9) = xW2
    '                'Case "FDRRVIS" : lpfdr(10) = xW2
    '                'Case "FDRCCOL" : lpfdr(11) = xW2
    '                'Case "FDRCSELALL" : lpfdr(12) = xW2
    '                'Case "FDRCSELINV" : lpfdr(13) = xW2
    '                'Case "FDRCSELNONE" : lpfdr(14) = xW2
    '                'Case "FDROOP" : lpfdr(15) = xW2
    '                'Case "FDRORL" : lpfdr(16) = xW2
    '                'Case "FDRORV" : lpfdr(17) = xW2
    '                'Case "FDROSEL" : lpfdr(18) = xW2
    '                'Case "FDROUNSEL" : lpfdr(19) = xW2
    '                'Case "FDRODEL" : lpfdr(20) = xW2
    '                'Case "FDROCLOSE" : lpfdr(21) = xW2
    '                '
    '                'Case "IMPSMTTL" : lpimpSM(0) = xW2
    '                'Case "IMPSMDIFF" : lpimpSM(1) = xW2
    '                'Case "IMPSMMSG" : lpimpSM(2) = xW2
    '                'Case "IMPSMOK" : lpimpSM(3) = xW2
    '                'Case "IMPSMCANCEL" : lpimpSM(4) = xW2
    '                '
    '                'Case "FADESCRIPTION" : lpfa(0) = xW2
    '                'Case "FAOPEN" : lpfa(1) = xW2
    '                'Case "FAPREVIEW" : lpfa(2) = xW2
    '                'Case "FAVIEWCODE" : lpfa(3) = xW2
    '
    '            Case "MNINSERT" : MInsert.Text = xW2
    '            Case "MNREMOVE" : MRemove.Text = xW2
    '
    '        End Select
    '    Next
    'End Sub

    Private Sub THBPM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles THBPM.ValueChanged
        If K IsNot Nothing Then K(0).Value = THBPM.Value * 10000 : RefreshPanelAll()
        If IsSaved Then SetIsSaved(False)
    End Sub

    Private Function EncodingToString() As String
        If TextEncoding Is System.Text.Encoding.Default Then Return "ANSI"
        If TextEncoding Is System.Text.Encoding.Unicode Then Return "Unicode"
        If TextEncoding Is System.Text.Encoding.ASCII Then Return "ASCII"
        If TextEncoding Is System.Text.Encoding.BigEndianUnicode Then Return "BigEndian"
        If TextEncoding Is System.Text.Encoding.UTF32 Then Return "UTF32"
        If TextEncoding Is System.Text.Encoding.UTF7 Then Return "UTF7"
        If TextEncoding Is System.Text.Encoding.UTF8 Then Return "UTF8"
        Return "ANSI"
    End Function

    Private Function FontToString(ByVal xFont As Font) As String
        Return xFont.FontFamily.Name & "," & xFont.Size & "," & CInt(xFont.Style)
    End Function

    Private Function StringToFont(ByVal xStr As String) As Font
        Dim xLine() As String = Split(xStr, ",")
        If UBound(xLine) = 2 Then
            Dim xFontStyle As System.Drawing.FontStyle = Val(xLine(2))
            Return New Font(xLine(0), CSng(Val(xLine(1))), xFontStyle, GraphicsUnit.Pixel)
        Else
            Return Me.Font
        End If
    End Function

    Private Function ArrayToString(ByVal xInt() As Integer) As String
        Dim xStr As String = ""
        For xI1 As Integer = 0 To UBound(xInt)
            xStr &= xInt(xI1).ToString & IIf(xI1 = UBound(xInt), "", ",")
        Next
        Return xStr
    End Function

    Private Function ArrayToString(ByVal xBool() As Boolean) As String
        Dim xStr As String = ""
        For xI1 As Integer = 0 To UBound(xBool)
            xStr &= CInt(xBool(xI1)).ToString & IIf(xI1 = UBound(xBool), "", ",")
        Next
        Return xStr
    End Function

    Private Function ArrayToString(ByVal xColor() As Color) As String
        Dim xStr As String = ""
        For xI1 As Integer = 0 To UBound(xColor)
            xStr &= xColor(xI1).ToArgb.ToString & IIf(xI1 = UBound(xColor), "", ",")
        Next
        Return xStr
    End Function

    Private Function StringToArrayInt(ByVal xStr As String) As Integer()
        Dim xL() As String = Split(xStr, ",")
        Dim xInt(UBound(xL)) As Integer
        For xI1 As Integer = 0 To UBound(xInt)
            xInt(xI1) = Val(xL(xI1))
        Next
        Return xInt
    End Function

    Private Function StringToArrayBool(ByVal xStr As String) As Boolean()
        Dim xL() As String = Split(xStr, ",")
        Dim xBool(UBound(xL)) As Boolean
        For xI1 As Integer = 0 To UBound(xBool)
            xBool(xI1) = CBool(Val(xL(xI1)))
        Next
        Return xBool
    End Function

    Private Sub XMLWriteValue(ByVal w As XmlTextWriter, ByVal local As String, ByVal val As String)
        w.WriteStartElement(local)
        w.WriteAttributeString("Value", val)
        w.WriteEndElement()
    End Sub

    Private Sub XMLWriteColumn(ByVal w As XmlTextWriter, ByVal I As Integer)
        w.WriteStartElement("Column")
        w.WriteAttributeString("Index", I)
        With col(I)
            'w.WriteAttributeString("Left", .Left)
            w.WriteAttributeString("Width", .Width)
            w.WriteAttributeString("Title", .Title)
            'w.WriteAttributeString("Text", .Text)
            'w.WriteAttributeString("Enabled", .Enabled)
            'w.WriteAttributeString("isNumeric", .isNumeric)
            'w.WriteAttributeString("Visible", .Visible)
            'w.WriteAttributeString("Identifier", .Identifier)
            w.WriteAttributeString("NoteColor", .cNote)
            w.WriteAttributeString("TextColor", .cText.ToArgb)
            w.WriteAttributeString("LongNoteColor", .cLNote)
            w.WriteAttributeString("LongTextColor", .cLText.ToArgb)
            w.WriteAttributeString("BG", .cBG.ToArgb)
        End With
        w.WriteEndElement()
    End Sub

    Private Sub XMLWriteFont(ByVal w As XmlTextWriter, ByVal local As String, ByVal f As Font)
        w.WriteStartElement(local)
        w.WriteAttributeString("Name", f.FontFamily.Name)
        w.WriteAttributeString("Size", f.SizeInPoints)
        w.WriteAttributeString("Style", f.Style)
        w.WriteEndElement()
    End Sub

    Private Sub XMLWritePlayerArguments(ByVal w As XmlTextWriter, ByVal I As Integer)
        w.WriteStartElement("Player")
        w.WriteAttributeString("Index", I)
        w.WriteAttributeString("Path", pArgs(I).Path)
        w.WriteAttributeString("FromBeginning", pArgs(I).aBegin)
        w.WriteAttributeString("FromHere", pArgs(I).aHere)
        w.WriteAttributeString("Stop", pArgs(I).aStop)
        w.WriteEndElement()
    End Sub

    Private Sub SaveSettings(ByVal Path As String, ByVal ThemeOnly As Boolean)
        Dim w As New XmlTextWriter(Path, System.Text.Encoding.Unicode)
        With w
            .WriteStartDocument()
            .Formatting = Formatting.Indented
            .Indentation = 4

            .WriteStartElement("iBMSC")
            .WriteAttributeString("Major", My.Application.Info.Version.Major)
            .WriteAttributeString("Minor", My.Application.Info.Version.Minor)
            .WriteAttributeString("Build", My.Application.Info.Version.Build)

            If ThemeOnly Then GoTo 5000

            .WriteStartElement("Form")
            .WriteAttributeString("WindowState", IIf(isFullScreen, previousWindowState, Me.WindowState))
            .WriteAttributeString("Width", IIf(isFullScreen, previousWindowPosition.Width, Me.Width))
            .WriteAttributeString("Height", IIf(isFullScreen, previousWindowPosition.Height, Me.Height))
            .WriteAttributeString("Top", IIf(isFullScreen, previousWindowPosition.Top, Me.Top))
            .WriteAttributeString("Left", IIf(isFullScreen, previousWindowPosition.Left, Me.Left))
            .WriteEndElement()

            .WriteStartElement("Recent")
            .WriteAttributeString("Recent0", Recent(0))
            .WriteAttributeString("Recent1", Recent(1))
            .WriteAttributeString("Recent2", Recent(2))
            .WriteAttributeString("Recent3", Recent(3))
            .WriteAttributeString("Recent4", Recent(4))
            .WriteEndElement()

            .WriteStartElement("Edit")
            .WriteAttributeString("NTInput", NTInput)
            .WriteAttributeString("Language", DispLang)
            '.WriteAttributeString("SortingMethod", SortingMethod)
            .WriteAttributeString("ErrorCheck", ErrorCheck)
            .WriteAttributeString("AutoFocusMouseEnter", AutoFocusMouseEnter)
            .WriteAttributeString("FirstClickDisabled", FirstClickDisabled)
            .WriteAttributeString("ShowFileName", ShowFileName)
            .WriteAttributeString("MiddleButtonMoveMethod", MiddleButtonMoveMethod)
            .WriteAttributeString("AutoSaveInterval", AutoSaveInterval)
            .WriteAttributeString("PreviewOnClick", PreviewOnClick)
            '.WriteAttributeString("PreviewErrorCheck", PreviewErrorCheck)
            .WriteAttributeString("ClickStopPreview", ClickStopPreview)
            .WriteEndElement()

            .WriteStartElement("Save")
            .WriteAttributeString("TextEncoding", EncodingToString)
            .WriteAttributeString("BMSGridLimit", BMSGridLimit)
            .WriteAttributeString("BeepWhileSaved", BeepWhileSaved)
            .WriteAttributeString("BPMx1296", BPMx1296)
            .WriteAttributeString("STOPx1296", STOPx1296)
            .WriteEndElement()

            .WriteStartElement("WAV")
            .WriteAttributeString("WAVMultiSelect", WAVMultiSelect)
            .WriteAttributeString("WAVChangeLabel", WAVChangeLabel)
            .WriteAttributeString("BeatChangeMode", BeatChangeMode)
            .WriteEndElement()

            .WriteStartElement("ShowHide")
            .WriteAttributeString("showMenu", mnSMenu.Checked)
            .WriteAttributeString("showTB", mnSTB.Checked)
            .WriteAttributeString("showOpPanel", mnSOP.Checked)
            .WriteAttributeString("showStatus", mnSStatus.Checked)
            .WriteAttributeString("showLSplit", mnSLSplitter.Checked)
            .WriteAttributeString("showRSplit", mnSRSplitter.Checked)
            .WriteEndElement()

            .WriteStartElement("Grid")
            .WriteAttributeString("gSnap", gSnap)
            .WriteAttributeString("gWheel", gWheel)
            .WriteAttributeString("gPgUpDn", gPgUpDn)
            .WriteAttributeString("gShow", gShow)
            .WriteAttributeString("gShowS", gShowS)
            .WriteAttributeString("gShowBG", gShowBG)
            .WriteAttributeString("gShowM", gShowM)
            .WriteAttributeString("gShowV", gShowV)
            .WriteAttributeString("gShowMB", gShowMB)
            .WriteAttributeString("gShowC", gShowC)
            .WriteAttributeString("gBPM", gBPM)
            .WriteAttributeString("gSTOP", gSTOP)
            .WriteAttributeString("gBLP", gBLP)
            .WriteAttributeString("gP2", CHPlayer.SelectedIndex)
            .WriteAttributeString("gCol", CGB.Value)
            .WriteAttributeString("gDivide", gDivide)
            .WriteAttributeString("gSub", gSub)
            .WriteAttributeString("gSlash", gSlash)
            .WriteAttributeString("gxHeight", gxHeight)
            .WriteAttributeString("gxWidth", gxWidth)
            .WriteEndElement()

            .WriteStartElement("WaveForm")
            .WriteAttributeString("wLock", wLock)
            .WriteAttributeString("wPosition", wPosition)
            .WriteAttributeString("wLeft", wLeft)
            .WriteAttributeString("wWidth", wWidth)
            .WriteAttributeString("wPrecision", wPrecision)
            .WriteEndElement()

            .WriteStartElement("Player")
            .WriteAttributeString("Count", pArgs.Length)
            .WriteAttributeString("CurrentPlayer", CurrentPlayer)
            For i As Integer = 0 To UBound(pArgs)
                XMLWritePlayerArguments(w, i) : Next
            .WriteEndElement()

5000:       .WriteStartElement("Columns")
            '.WriteAttributeString("Count", col.Length)
            For i As Integer = 0 To UBound(col)
                XMLWriteColumn(w, i) : Next
            .WriteEndElement()

            .WriteStartElement("VisualSettings")
            XMLWriteValue(w, "ColumnTitle", vo.ColumnTitle.Color.ToArgb)
            XMLWriteFont(w, "ColumnTitleFont", vo.ColumnTitleFont)
            XMLWriteValue(w, "Bg", vo.Bg.Color.ToArgb)
            XMLWriteValue(w, "Grid", vo.pGrid.Color.ToArgb)
            XMLWriteValue(w, "Sub", vo.pSub.Color.ToArgb)
            XMLWriteValue(w, "VLine", vo.pVLine.Color.ToArgb)
            XMLWriteValue(w, "MLine", vo.pMLine.Color.ToArgb)
            XMLWriteValue(w, "BGMWav", vo.pBGMWav.Color.ToArgb)
            XMLWriteValue(w, "SelBox", vo.SelBox.Color.ToArgb)
            XMLWriteValue(w, "TSCursor", vo.PECursor.Color.ToArgb)
            XMLWriteValue(w, "TSHalf", vo.PEHalf.Color.ToArgb)
            XMLWriteValue(w, "TSDeltaMouseOver", vo.PEDeltaMouseOver)
            XMLWriteValue(w, "TSMouseOver", vo.PEMouseOver.Color.ToArgb)
            XMLWriteValue(w, "TSSel", vo.PESel.Color.ToArgb)
            XMLWriteValue(w, "TSBPM", vo.PEBPM.Color.ToArgb)
            XMLWriteFont(w, "TSBPMFont", vo.PEBPMFont)
            XMLWriteValue(w, "MiddleDeltaRelease", vo.MiddleDeltaRelease)
            XMLWriteValue(w, "kHeight", vo.kHeight)
            XMLWriteFont(w, "kFont", vo.kFont)
            XMLWriteFont(w, "kMFont", vo.kMFont)
            XMLWriteValue(w, "kLabelVShift", vo.kLabelVShift)
            XMLWriteValue(w, "kLabelHShift", vo.kLabelHShift)
            XMLWriteValue(w, "kLabelHShiftL", vo.kLabelHShiftL)
            XMLWriteValue(w, "kMouseOver", vo.kMouseOver.Color.ToArgb)
            XMLWriteValue(w, "kMouseOverE", vo.kMouseOverE.Color.ToArgb)
            XMLWriteValue(w, "kSelected", vo.kSelected.Color.ToArgb)
            XMLWriteValue(w, "kOpacity", vo.kOpacity)
            .WriteEndElement()

            .WriteEndElement()
            .WriteEndDocument()
            .Close()
        End With
    End Sub

    'Private Function SaveCFF() As String
    'Dim xStr As String = "iBMSC Configuration Settings Format" & vbCrLf & _
    '                     IIf(Me.WindowState = FormWindowState.Maximized, _
    '                        "Maximized=-1" & vbCrLf, _
    '                        IIf(Me.WindowState = FormWindowState.Minimized, _
    '                            "", _
    '                            "FormHeight=" & Me.Height & vbCrLf & _
    '                            "FormWidth=" & Me.Width & vbCrLf & _
    '                            "FormTop=" & Me.Top & vbCrLf & _
    '                            "FormLeft=" & Me.Left & vbCrLf)) & _
    '                     "Language=" & DispLang & vbCrLf & _
    '                        vbCrLf & _
    '                     "Recent0=" & Recent(0) & vbCrLf & _
    '                     "Recent1=" & Recent(1) & vbCrLf & _
    '                     "Recent2=" & Recent(2) & vbCrLf & _
    '                     "Recent3=" & Recent(3) & vbCrLf & _
    '                     "Recent4=" & Recent(4) & vbCrLf & _
    '                        vbCrLf & _
    '                     "AutoSaveInterval=" & AutoSaveInterval & vbCrLf & _
    '                     "TextEncoding=" & EncodingToString() & vbCrLf & _
    '                     "SortingMethod=" & SortingMethod & vbCrLf & _
    '                     "NTInput=" & CInt(NTInput) & vbCrLf & _
    '                     "ErrorCheck=" & CInt(ErrorCheck) & vbCrLf & _
    '                     "ShowFileName=" & CInt(ShowFileName) & vbCrLf & _
    '                        vbCrLf & _
    '                     "BMSGridLimit=" & BMSGridLimit & vbCrLf & _
    '                     "BeepWhileSave=" & CInt(BeepWhileSave) & vbCrLf & _
    '                     "BPMx1296=" & CInt(BPMx1296) & vbCrLf & _
    '                     "STOPx1296=" & CInt(STOPx1296) & vbCrLf & _
    '                        vbCrLf & _
    '                     "AutoFocusMouseEnter=" & CInt(AutoFocusMouseEnter) & vbCrLf & _
    '                     "FirstClickDisabled=" & CInt(FirstClickDisabled) & vbCrLf & _
    '                        vbCrLf & _
    '                     "WAVMultiSelect=" & CInt(WAVMultiSelect) & vbCrLf & _
    '                     "WAVChangeLabel=" & CInt(WAVChangeLabel) & vbCrLf & _
    '                     "BeatChangeMode=" & BeatChangeMode & vbCrLf & _
    '                        vbCrLf & _
    '                     "showMenu=" & CInt(mnSMenu.Checked) & vbCrLf & _
    '                     "showTB=" & CInt(mnSTB.Checked) & vbCrLf & _
    '                     "showOpPanel=" & CInt(mnSOP.Checked) & vbCrLf & _
    '                     "showStatus=" & CInt(mnSStatus.Checked) & vbCrLf & _
    '                     "showLSplit=" & CInt(mnSLSplitter.Checked) & vbCrLf & _
    '                     "showRSplit=" & CInt(mnSRSplitter.Checked) & vbCrLf & _
    '                        vbCrLf & _
    '                     "gSnap=" & CInt(gSnap) & vbCrLf & _
    '                     "gWheel=" & gWheel & vbCrLf & _
    '                     "gPgUpDn=" & gPgUpDn & vbCrLf & _
    '                     "gShow=" & CInt(gShow) & vbCrLf & _
    '                     "gShowS=" & CInt(gShowS) & vbCrLf & _
    '                     "gShowBG=" & CInt(gShowBG) & vbCrLf & _
    '                     "gShowM=" & CInt(gShowM) & vbCrLf & _
    '                     "gShowV=" & CInt(gShowV) & vbCrLf & _
    '                     "gShowMB=" & CInt(gShowMB) & vbCrLf & _
    '                     "gShowC=" & CInt(gShowC) & vbCrLf & _
    '                     "gBLP=" & CInt(gBLP) & vbCrLf & _
    '                     "gSTOP=" & CInt(gSTOP) & vbCrLf & _
    '                     "gP2=" & CHPlayer.SelectedIndex & vbCrLf & _
    '                     "gCol=" & gCol & vbCrLf & _
    '                     "gDivide=" & gDivide & vbCrLf & _
    '                     "gSub=" & gSub & vbCrLf & _
    '                     "gxHeight=" & gxHeight & vbCrLf & _
    '                     "gxWidth=" & gxWidth & vbCrLf & _
    '                        vbCrLf & _
    '                     "wLock=" & CInt(wLock) & vbCrLf & _
    '                     "wPosition=" & wPosition & vbCrLf & _
    '                     "wLeft=" & wLeft & vbCrLf & _
    '                     "wWidth=" & wWidth & vbCrLf & _
    '                     "wPrecision=" & wPrecision & vbCrLf & _
    '                        vbCrLf & _
    '                     "PreviewOnClick=" & CInt(PreviewOnClick) & vbCrLf & _
    '                     "PreviewErrorCheck=" & CInt(PreviewErrorCheck) & vbCrLf & _
    '                     "ClickStopPreview=" & CInt(ClickStopPreview) & vbCrLf & _
    '                     "CPrevPlayerIndex=" & CurrentPlayer & vbCrLf & _
    '                        vbCrLf & _
    '                     "kEnabled=" & ArrayToString(kEnabled) & vbCrLf & _
    '                     "kNumeric=" & ArrayToString(kNumericLabel) & vbCrLf & _
    '                     "kVisible=" & ArrayToString(kVisible) & vbCrLf
    'Return xStr
    'End Function

    'Private Function SaveSkinCFF() As String
    'Dim xStr As String = "iBMSC Theme Format" & vbCrLf & _
    '                        vbCrLf & _
    '                     "voTitle=" & vo.Title.Color.ToArgb & vbCrLf & _
    '                     "voTitleFont=" & FontToString(vo.TitleFont) & vbCrLf & _
    '                     "vo.Bg=" & vo.Bg.Color.ToArgb & vbCrLf & _
    '                     "voGrid=" & vo.pGrid.Color.ToArgb & vbCrLf & _
    '                     "voSub=" & vo.pSub.Color.ToArgb & vbCrLf & _
    '                     "voVLine=" & vo.pVLine.Color.ToArgb & vbCrLf & _
    '                     "voMLine=" & vo.pMLine.Color.ToArgb & vbCrLf & _
    '                     "vo.BgMWav=" & vo.pBGMWav.Color.ToArgb & vbCrLf & _
    '                     "voSelBox=" & vo.SelBox.Color.ToArgb & vbCrLf & _
    '                     "voPECursor=" & vo.PECursor.Color.ToArgb & vbCrLf & _
    '                     "voPEHalf=" & vo.PEHalf.Color.ToArgb & vbCrLf & _
    '                     "voPEDeltaMouseOver=" & vo.PEDeltaMouseOver & vbCrLf & _
    '                     "voPEMouseOver=" & vo.PEMouseOver.Color.ToArgb & vbCrLf & _
    '                     "voPESel=" & vo.PESel.Color.ToArgb & vbCrLf & _
    '                     "voPEBPM=" & vo.PEBPM.Color.ToArgb & vbCrLf & _
    '                     "voPEBPMFont=" & FontToString(vo.PEBPMFont) & vbCrLf & _
    '                     "vo.KHeight=" & vo.kHeight & vbCrLf & _
    '                     "vKFont=" & FontToString(vo.kFont) & vbCrLf & _
    '                     "vKMFont=" & FontToString(vo.kMFont) & vbCrLf & _
    '                     "vKLabelVShift=" & vo.kLabelVShift & vbCrLf & _
    '                     "vKLabelHShift=" & vo.kLabelHShift & vbCrLf & _
    '                     "vKLabelHShiftL=" & vo.kLabelHShiftL & vbCrLf & _
    '                     "vo.kMouseOver=" & vo.kMouseOver.Color.ToArgb & vbCrLf & _
    '                     "vo.kMouseOverE =" & vo.kMouseOverE.Color.ToArgb & vbCrLf & _
    '                     "vKSelected=" & vo.kSelected.Color.ToArgb & vbCrLf & _
    '                     "vKHidTransparency=" & vo.kHidTransparency & vbCrLf & _
    '                        vbCrLf & _
    '                     "kLength=" & ArrayToString(kLength) & vbCrLf & _
    '                     "kTitle=" & Join(kTitle, ",") & vbCrLf & _
    '                     "kColor=" & ArrayToString(kColor) & vbCrLf & _
    '                     "kColorL=" & ArrayToString(kColorL) & vbCrLf & _
    '                     "kForeColor=" & ArrayToString(kForeColor) & vbCrLf & _
    '                     "kForeColorL=" & ArrayToString(kForeColorL) & vbCrLf & _
    '                     "kBgColor=" & ArrayToString(kBgColor) & vbCrLf
    'Return xStr
    'End Function

    'Private Function SavePlayerCFF() As String
    'Dim xpArgs As String = "{" & vbCrLf
    'For xI1 As Integer = 0 To UBound(pArgs)
    '    xpArgs &= Replace(pArgs(xI1), vbCrLf, "|") & vbCrLf
    'Next
    'xpArgs &= "}"
    '
    'Dim xStr As String = "iBMSC Configuration Settings Format" & vbCrLf & _
    '                     "pArgs=" & xpArgs & vbCrLf
    'Return xStr
    'End Function

    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As String)
        If s.Length = 0 Then Exit Sub
        v = s
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Boolean)
        If s.Length = 0 Then Exit Sub
        v = CBool(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Integer)
        If s.Length = 0 Then Exit Sub
        v = CInt(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Single)
        If s.Length = 0 Then Exit Sub
        v = CSng(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Double)
        If s.Length = 0 Then Exit Sub
        v = CDbl(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Long)
        If s.Length = 0 Then Exit Sub
        v = CLng(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Decimal)
        If s.Length = 0 Then Exit Sub
        v = CDec(s)
    End Sub
    Private Sub XMLLoadAttribute(ByVal s As String, ByRef v As Color)
        If s.Length = 0 Then Exit Sub
        v = Color.FromArgb(CInt(s))
    End Sub

    Private Sub XMLLoadElementValue(ByVal n As XmlElement, ByRef v As Integer)
        If n Is Nothing Then Exit Sub
        XMLLoadAttribute(n.GetAttribute("Value"), v)
    End Sub
    Private Sub XMLLoadElementValue(ByVal n As XmlElement, ByRef v As Single)
        If n Is Nothing Then Exit Sub
        XMLLoadAttribute(n.GetAttribute("Value"), v)
    End Sub
    Private Sub XMLLoadElementValue(ByVal n As XmlElement, ByRef v As Color)
        If n Is Nothing Then Exit Sub
        XMLLoadAttribute(n.GetAttribute("Value"), v)
    End Sub
    Private Sub XMLLoadElementValue(ByVal n As XmlElement, ByRef v As Font)
        If n Is Nothing Then Exit Sub

        Dim xName As String = Me.Font.FontFamily.Name
        Dim xSize As Integer = Me.Font.Size
        Dim xStyle As Integer = Me.Font.Style
        XMLLoadAttribute(n.GetAttribute("Name"), xName)
        XMLLoadAttribute(n.GetAttribute("Size"), xSize)
        XMLLoadAttribute(n.GetAttribute("Style"), xStyle)
        v = New Font(xName, xSize, CType(xStyle, System.Drawing.FontStyle))
    End Sub

    Private Sub XMLLoadPlayer(ByVal n As XmlElement)
        Dim i As Integer = -1
        XMLLoadAttribute(n.GetAttribute("Index"), i)
        If i < 0 Or i > UBound(pArgs) Then Exit Sub

        XMLLoadAttribute(n.GetAttribute("Path"), pArgs(i).Path)
        XMLLoadAttribute(n.GetAttribute("FromBeginning"), pArgs(i).aBegin)
        XMLLoadAttribute(n.GetAttribute("FromHere"), pArgs(i).aHere)
        XMLLoadAttribute(n.GetAttribute("Stop"), pArgs(i).aStop)
    End Sub

    Private Sub XMLLoadColumn(ByVal n As XmlElement)
        Dim i As Integer = -1
        XMLLoadAttribute(n.GetAttribute("Index"), i)
        If i < 0 Or i > UBound(col) Then Exit Sub

        With col(i)
            'XMLLoadAttribute(n.GetAttribute("Left"), .Left)
            XMLLoadAttribute(n.GetAttribute("Width"), .Width)
            XMLLoadAttribute(n.GetAttribute("Title"), .Title)
            'XMLLoadAttribute(n.GetAttribute("Text"), .Text)
            'XMLLoadAttribute(n.GetAttribute("Enabled"), .Enabled)
            'XMLLoadAttribute(n.GetAttribute("isNumeric"), .isNumeric)
            'XMLLoadAttribute(n.GetAttribute("Visible"), .Visible)
            'XMLLoadAttribute(n.GetAttribute("Identifier"), .Identifier)
            XMLLoadAttribute(n.GetAttribute("NoteColor"), .cNote)
            .setNoteColor(.cNote)
            XMLLoadAttribute(n.GetAttribute("TextColor"), .cText)
            XMLLoadAttribute(n.GetAttribute("LongNoteColor"), .cLNote)
            .setLNoteColor(.cLNote)
            XMLLoadAttribute(n.GetAttribute("LongTextColor"), .cLText)
            XMLLoadAttribute(n.GetAttribute("BG"), .cBG)
        End With
    End Sub

    Private Sub LoadSettings(ByVal Path As String)
        If Not My.Computer.FileSystem.FileExists(Path) Then Return

        'Dim xTempFileName As String = ""
        'Do
        'Try
        'xTempFileName = Me.RandomFileName(".xml")
        'File.Copy(Path, xTempFileName)
        'Catch
        'Continue Do
        'End Try
        'Exit Do
        'Loop
        Dim Doc As New XmlDataDocument
        Dim FileStream As New IO.FileStream(Path, FileMode.Open, FileAccess.Read)
        Doc.Load(FileStream)

        Dim Root As XmlElement = Doc.Item("iBMSC")
        If Root Is Nothing Then GoTo EndOfSub

        'version
        Dim Major As Integer = My.Application.Info.Version.Major
        Dim Minor As Integer = My.Application.Info.Version.Minor
        Dim Build As Integer = My.Application.Info.Version.Build
        Try
            Dim xMajor As Integer = Val(Root.Attributes("Major").Value)
            Dim xMinor As Integer = Val(Root.Attributes("Minor").Value)
            Dim xBuild As Integer = Val(Root.Attributes("Build").Value)
            Major = xMajor
            Minor = xMinor
            Build = xBuild
        Catch ex As Exception
        End Try

        'form
        Dim eForm As XmlElement = Root.Item("Form")
        If eForm IsNot Nothing Then
            With eForm
                Select Case Val(.GetAttribute("WindowState"))
                    Case FormWindowState.Normal
                        Me.WindowState = FormWindowState.Normal
                        XMLLoadAttribute(.GetAttribute("Width"), Me.Width)
                        XMLLoadAttribute(.GetAttribute("Height"), Me.Height)
                        XMLLoadAttribute(.GetAttribute("Top"), Me.Top)
                        XMLLoadAttribute(.GetAttribute("Left"), Me.Left)
                    Case FormWindowState.Maximized
                        Me.WindowState = FormWindowState.Maximized
                End Select
            End With
        End If

        'recent
        Dim eRecent As XmlElement = Root.Item("Recent")
        If eRecent IsNot Nothing Then
            With eRecent
                XMLLoadAttribute(.GetAttribute("Recent0"), Recent(0)) : SetRecent(0, Recent(0))
                XMLLoadAttribute(.GetAttribute("Recent1"), Recent(1)) : SetRecent(1, Recent(1))
                XMLLoadAttribute(.GetAttribute("Recent2"), Recent(2)) : SetRecent(2, Recent(2))
                XMLLoadAttribute(.GetAttribute("Recent3"), Recent(3)) : SetRecent(3, Recent(3))
                XMLLoadAttribute(.GetAttribute("Recent4"), Recent(4)) : SetRecent(4, Recent(4))
            End With
        End If

        'edit
        Dim eEdit As XmlElement = Root.Item("Edit")
        If eEdit IsNot Nothing Then
            With eEdit
                XMLLoadAttribute(.GetAttribute("NTInput"), NTInput)
                TBNTInput.Checked = NTInput
                mnNTInput.Checked = NTInput
                POBLong.Enabled = Not NTInput
                POBLongShort.Enabled = Not NTInput

                LoadLocale(My.Application.Info.DirectoryPath & "\" & .GetAttribute("Language"))

                'XMLLoadAttribute(.GetAttribute("SortingMethod"), SortingMethod)

                XMLLoadAttribute(.GetAttribute("ErrorCheck"), ErrorCheck)
                TBErrorCheck.Checked = ErrorCheck
                TBErrorCheck_Click(TBErrorCheck, New System.EventArgs)

                XMLLoadAttribute(.GetAttribute("ShowFileName"), ShowFileName)
                TBShowFileName.Checked = ShowFileName
                TBShowFileName_Click(TBShowFileName, New System.EventArgs)

                XMLLoadAttribute(.GetAttribute("MiddleButtonMoveMethod"), MiddleButtonMoveMethod)
                XMLLoadAttribute(.GetAttribute("AutoFocusMouseEnter"), AutoFocusMouseEnter)
                XMLLoadAttribute(.GetAttribute("FirstClickDisabled"), FirstClickDisabled)

                XMLLoadAttribute(.GetAttribute("AutoSaveInterval"), AutoSaveInterval)
                If AutoSaveInterval Then AutoSaveTimer.Interval = AutoSaveInterval Else AutoSaveTimer.Enabled = False

                XMLLoadAttribute(.GetAttribute("PreviewOnClick"), PreviewOnClick)
                TBPreviewOnClick.Checked = PreviewOnClick
                TBPreviewOnClick_Click(TBPreviewOnClick, New System.EventArgs)

                XMLLoadAttribute(.GetAttribute("ClickStopPreview"), ClickStopPreview)
            End With
        End If

        'save
        Dim eSave As XmlElement = Root.Item("Save")
        If eSave IsNot Nothing Then
            With eSave
                Select Case UCase(.GetAttribute("TextEncoding"))
                    Case "ANSI" : TextEncoding = System.Text.Encoding.Default
                    Case "UNICODE" : TextEncoding = System.Text.Encoding.Unicode
                    Case "ASCII" : TextEncoding = System.Text.Encoding.ASCII
                    Case "BIGENDIAN" : TextEncoding = System.Text.Encoding.BigEndianUnicode
                    Case "UTF32" : TextEncoding = System.Text.Encoding.UTF32
                    Case "UTF7" : TextEncoding = System.Text.Encoding.UTF7
                    Case "UTF8" : TextEncoding = System.Text.Encoding.UTF8
                End Select

                XMLLoadAttribute(.GetAttribute("BMSGridLimit"), BMSGridLimit)
                XMLLoadAttribute(.GetAttribute("BeepWhileSaved"), BeepWhileSaved)
                XMLLoadAttribute(.GetAttribute("BPMx1296"), BPMx1296)
                XMLLoadAttribute(.GetAttribute("STOPx1296"), STOPx1296)
            End With
        End If

        'WAV
        Dim eWAV As XmlElement = Root.Item("WAV")
        If eWAV IsNot Nothing Then
            With eWAV
                XMLLoadAttribute(.GetAttribute("WAVMultiSelect"), WAVMultiSelect)
                CWAVMultiSelect.Checked = WAVMultiSelect
                CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, New EventArgs)

                XMLLoadAttribute(.GetAttribute("WAVChangeLabel"), WAVChangeLabel)
                CWAVChangeLabel.Checked = WAVChangeLabel
                CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, New EventArgs)

                Dim xInt As Integer = CInt(.GetAttribute("BeatChangeMode"))
                Dim xBeatOpList As RadioButton() = {CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale}
                If xInt >= 0 And xInt < xBeatOpList.Length Then
                    xBeatOpList(xInt).Checked = True
                    CBeatPreserve_Click(xBeatOpList(xInt), New System.EventArgs)
                End If
            End With
        End If

        'ShowHide
        Dim eShowHide As XmlElement = Root.Item("ShowHide")
        If eShowHide IsNot Nothing Then
            With eShowHide
                XMLLoadAttribute(.GetAttribute("showMenu"), mnSMenu.Checked)
                XMLLoadAttribute(.GetAttribute("showTB"), mnSTB.Checked)
                XMLLoadAttribute(.GetAttribute("showOpPanel"), mnSOP.Checked)
                XMLLoadAttribute(.GetAttribute("showStatus"), mnSStatus.Checked)
                XMLLoadAttribute(.GetAttribute("showLSplit"), mnSLSplitter.Checked)
                XMLLoadAttribute(.GetAttribute("showRSplit"), mnSRSplitter.Checked)
            End With
        End If

        'Grid
        Dim eGrid As XmlElement = Root.Item("Grid")
        If eGrid IsNot Nothing Then
            With eGrid
                XMLLoadAttribute(.GetAttribute("gSnap"), CGSnap.Checked)
                XMLLoadAttribute(.GetAttribute("gWheel"), gWheel)
                XMLLoadAttribute(.GetAttribute("gPgUpDn"), gPgUpDn)
                XMLLoadAttribute(.GetAttribute("gShow"), CGShow.Checked)
                XMLLoadAttribute(.GetAttribute("gShowS"), CGShowS.Checked)
                XMLLoadAttribute(.GetAttribute("gShowBG"), CGShowBG.Checked)
                XMLLoadAttribute(.GetAttribute("gShowM"), CGShowM.Checked)
                XMLLoadAttribute(.GetAttribute("gShowV"), CGShowV.Checked)
                XMLLoadAttribute(.GetAttribute("gShowMB"), CGShowMB.Checked)
                XMLLoadAttribute(.GetAttribute("gShowC"), CGShowC.Checked)
                XMLLoadAttribute(.GetAttribute("gBPM"), CGBPM.Checked)
                XMLLoadAttribute(.GetAttribute("gSTOP"), CGSTOP.Checked)
                XMLLoadAttribute(.GetAttribute("gBLP"), CGBLP.Checked)
                XMLLoadAttribute(.GetAttribute("gP2"), CHPlayer.SelectedIndex)
                XMLLoadAttribute(.GetAttribute("gCol"), CGB.Value)
                XMLLoadAttribute(.GetAttribute("gxHeight"), CGHeight.Value)
                XMLLoadAttribute(.GetAttribute("gxWidth"), CGWidth.Value)
                XMLLoadAttribute(.GetAttribute("gSlash"), gSlash)

                Dim xgDivide As Integer = CInt(.GetAttribute("gDivide"))
                If xgDivide >= CGDivide.Minimum And xgDivide <= CGDivide.Maximum Then CGDivide.Value = xgDivide

                Dim xgSub As Integer = CInt(.GetAttribute("gSub"))
                If xgSub >= CGSub.Minimum And xgSub <= CGSub.Maximum Then CGSub.Value = xgSub
            End With
        End If

        'WaveForm
        Dim eWaveForm As XmlElement = Root.Item("WaveForm")
        If eWaveForm IsNot Nothing Then
            With eWaveForm
                XMLLoadAttribute(.GetAttribute("wLock"), BWLock.Checked)
                XMLLoadAttribute(.GetAttribute("wPosition"), TWPosition.Value)
                XMLLoadAttribute(.GetAttribute("wLeft"), TWLeft.Value)
                XMLLoadAttribute(.GetAttribute("wWidth"), TWWidth.Value)
                XMLLoadAttribute(.GetAttribute("wPrecision"), TWPrecision.Value)
            End With
        End If

        'Player
        Dim ePlayer As XmlElement = Root.Item("Player")
        If ePlayer IsNot Nothing Then
            With ePlayer
                XMLLoadAttribute(.GetAttribute("CurrentPlayer"), CurrentPlayer)

                Dim xCount As Integer = .GetAttribute("Count")
                If xCount > 0 Then ReDim Preserve pArgs(xCount - 1)
            End With

            For Each eePlayer As XmlElement In ePlayer.ChildNodes
                Me.XMLLoadPlayer(eePlayer)
            Next
        End If

        'Columns
        Dim eColumns As XmlElement = Root.Item("Columns")
        If eColumns IsNot Nothing Then
            For Each eeCol As XmlElement In eColumns.ChildNodes
                Me.XMLLoadColumn(eeCol)
            Next
        End If

        'VisualSettings
        Dim eVisualSettings As XmlElement = Root.Item("VisualSettings")
        If eVisualSettings IsNot Nothing Then
            With eVisualSettings
                XMLLoadElementValue(.Item("ColumnTitle"), vo.ColumnTitle.Color)
                XMLLoadElementValue(.Item("ColumnTitleFont"), vo.ColumnTitleFont)
                XMLLoadElementValue(.Item("Bg"), vo.Bg.Color)
                XMLLoadElementValue(.Item("Grid"), vo.pGrid.Color)
                XMLLoadElementValue(.Item("Sub"), vo.pSub.Color)
                XMLLoadElementValue(.Item("VLine"), vo.pVLine.Color)
                XMLLoadElementValue(.Item("MLine"), vo.pMLine.Color)

                XMLLoadElementValue(.Item("BGMWav"), vo.pBGMWav.Color)
                TWTransparency.Value = vo.pBGMWav.Color.A
                TWTransparency2.Value = vo.pBGMWav.Color.A
                TWSaturation.Value = vo.pBGMWav.Color.GetSaturation * 1000
                TWSaturation2.Value = vo.pBGMWav.Color.GetSaturation * 1000

                XMLLoadElementValue(.Item("SelBox"), vo.SelBox.Color)
                XMLLoadElementValue(.Item("TSCursor"), vo.PECursor.Color)
                XMLLoadElementValue(.Item("TSHalf"), vo.PEHalf.Color)
                XMLLoadElementValue(.Item("TSDeltaMouseOver"), vo.PEDeltaMouseOver)
                XMLLoadElementValue(.Item("TSMouseOver"), vo.PEMouseOver.Color)
                XMLLoadElementValue(.Item("TSSel"), vo.PESel.Color)
                XMLLoadElementValue(.Item("TSBPM"), vo.PEBPM.Color)
                XMLLoadElementValue(.Item("TSBPMFont"), vo.PEBPMFont)
                XMLLoadElementValue(.Item("MiddleDeltaRelease"), vo.MiddleDeltaRelease)
                XMLLoadElementValue(.Item("kHeight"), vo.kHeight)
                XMLLoadElementValue(.Item("kFont"), vo.kFont)
                XMLLoadElementValue(.Item("kMFont"), vo.kMFont)
                XMLLoadElementValue(.Item("kLabelVShift"), vo.kLabelVShift)
                XMLLoadElementValue(.Item("kLabelHShift"), vo.kLabelHShift)
                XMLLoadElementValue(.Item("kLabelHShiftL"), vo.kLabelHShiftL)
                XMLLoadElementValue(.Item("kMouseOver"), vo.kMouseOver.Color)
                XMLLoadElementValue(.Item("kMouseOverE"), vo.kMouseOverE.Color)
                XMLLoadElementValue(.Item("kSelected"), vo.kSelected.Color)
                XMLLoadElementValue(.Item("kOpacity"), vo.kOpacity)
            End With
        End If

EndOfSub:
        UpdateKLeft()
        FileStream.Close()
        'File.Delete(xTempFileName)
    End Sub

    Private Sub LoadThemeComptability(ByVal xPath As String)
        Try
            Dim xStrLine() As String = Split(My.Computer.FileSystem.ReadAllText(xPath), vbCrLf)
            If xStrLine(0).Trim <> "iBMSC Configuration Settings Format" And xStrLine(0).Trim <> "iBMSC Theme Format" Then Exit Sub

            Dim xW1 As String = ""
            Dim xW2 As String = ""

            For Each xLine As String In xStrLine
                xW1 = UCase(Mid(xLine, 1, InStr(xLine, "=") - 1))
                xW2 = Mid(xLine, InStr(xLine, "=") + 1)

                Select Case xW1
                    Case "VOTITLE" : vo.ColumnTitle.Color = Color.FromArgb(Val(xW2))
                    Case "VOTITLEFONT" : vo.ColumnTitleFont = StringToFont(xW2)
                    Case "VOBG" : vo.Bg.Color = Color.FromArgb(Val(xW2))
                    Case "VOGRID" : vo.pGrid.Color = Color.FromArgb(Val(xW2))
                    Case "VOSUB" : vo.pSub.Color = Color.FromArgb(Val(xW2))
                    Case "VOVLINE" : vo.pVLine.Color = Color.FromArgb(Val(xW2))
                    Case "VOMLINE" : vo.pMLine.Color = Color.FromArgb(Val(xW2))
                    Case "VOBGMWAV"
                        vo.pBGMWav.Color = Color.FromArgb(Val(xW2))
                        TWTransparency.Value = vo.pBGMWav.Color.A
                        TWTransparency2.Value = vo.pBGMWav.Color.A
                        TWSaturation.Value = vo.pBGMWav.Color.GetSaturation * 1000
                        TWSaturation2.Value = vo.pBGMWav.Color.GetSaturation * 1000
                    Case "VOSELBOX" : vo.SelBox.Color = Color.FromArgb(Val(xW2))
                    Case "VOPECURSOR" : vo.PECursor.Color = Color.FromArgb(Val(xW2))
                    Case "VOPEHALF" : vo.PEHalf.Color = Color.FromArgb(Val(xW2))
                    Case "VOPEDELTAMOUSEOVER" : vo.PEDeltaMouseOver = Val(xW2)
                    Case "VOPEMOUSEOVER" : vo.PEMouseOver.Color = Color.FromArgb(Val(xW2))
                    Case "VOPESEL" : vo.PESel.Color = Color.FromArgb(Val(xW2))
                    Case "VOPEBPM" : vo.PEBPM.Color = Color.FromArgb(Val(xW2))
                    Case "VOPEBPMFONT" : vo.PEBPMFont = StringToFont(xW2)
                    Case "VKHEIGHT" : vo.kHeight = Val(xW2)
                    Case "VKFONT" : vo.kFont = StringToFont(xW2)
                    Case "VKMFONT" : vo.kMFont = StringToFont(xW2)
                    Case "VKLABELVSHIFT" : vo.kLabelVShift = Val(xW2)
                    Case "VKLABELHSHIFT" : vo.kLabelHShift = Val(xW2)
                    Case "VKLABELHSHIFTL" : vo.kLabelHShiftL = Val(xW2)
                    Case "VKMOUSEOVER" : vo.kMouseOver.Color = Color.FromArgb(Val(xW2))
                    Case "VKMOUSEOVERE " : vo.kMouseOverE.Color = Color.FromArgb(Val(xW2))
                    Case "VKSELECTED" : vo.kSelected.Color = Color.FromArgb(Val(xW2))
                        'Case "VKHIDTRANSPARENCY" : vo.kOpacity = Val(xW2)

                    Case "KLENGTH"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).Width = Val(xE(i))
                        Next

                    Case "KTITLE"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).Title = xE(i)
                        Next

                    Case "KCOLOR"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).setNoteColor(Val(xE(i)))
                        Next

                    Case "KCOLORL"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).setLNoteColor(Val(xE(i)))
                        Next

                    Case "KFORECOLOR"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).cText = Color.FromArgb(Val(xE(i)))
                        Next

                    Case "KFORECOLORL"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).cLText = Color.FromArgb(Val(xE(i)))
                        Next

                    Case "KBGCOLOR"
                        Dim xE() As String = LoadThemeComptability_SplitStringInto26Parts(xW2)
                        For i As Integer = 0 To 26
                            col(i).cBG = Color.FromArgb(Val(xE(i)))
                        Next

                End Select

            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Locale.Messages.Err)

        Finally
            UpdateKLeft()

        End Try
    End Sub

    Private Function LoadThemeComptability_SplitStringInto26Parts(ByVal xLine As String) As String()
        Dim xE() As String = Split(xLine, ",")
        ReDim Preserve xE(26)
        Return xE
    End Function

    'Private Sub LoadCFF(ByVal xStr As String)
    'Dim xStrLine() As String = Split(xStr, vbCrLf)
    'If xStrLine(0).Trim <> "iBMSC Configuration Settings Format" And xStrLine(0).Trim <> "iBMSC Theme Format" Then Exit Sub
    'Dim xW1 As String = ""
    'Dim xW2 As String = ""
    'Dim xInstr As Integer
    'Dim xEnclosingW1 As String = ""
    '
    'For Each xLine As String In xStrLine
    '    xInstr = InStr(xLine, "=")
    '    If xInstr = 0 Then
    '        If xEnclosingW1 = "" Then GoTo 1 Else xW1 = "" : xW2 = ""
    '    Else
    '        xW1 = UCase(Mid(xLine, 1, xInstr - 1))
    '        xW2 = Mid(xLine, xInstr + 1)
    '    End If
    '
    '    If xEnclosingW1 = "" Then
    '        Select Case xW1
    '
    '            Case "FORMHEIGHT" : Me.Height = Val(xW2)
    '            Case "FORMWIDTH" : Me.Width = Val(xW2)
    '            Case "FORMTOP" : Me.Top = Val(xW2)
    '            Case "FORMLEFT" : Me.Left = Val(xW2)
    '            Case "MAXIMIZED" : If CBool(Val(xW2)) Then Me.WindowState = FormWindowState.Maximized
    '            Case "LANGUAGE" : ReadLanguagePack(xW2)
    '
    '            Case "RECENT0" : Recent(0) = xW2 : SetRecent(0, xW2)
    '            Case "RECENT1" : Recent(1) = xW2 : SetRecent(1, xW2)
    '            Case "RECENT2" : Recent(2) = xW2 : SetRecent(2, xW2)
    '            Case "RECENT3" : Recent(3) = xW2 : SetRecent(3, xW2)
    '            Case "RECENT4" : Recent(4) = xW2 : SetRecent(4, xW2)
    '
    '            Case "AUTOSAVEINTERVAL"
    '                AutoSaveInterval = Val(xW2)
    '                If AutoSaveInterval Then AutoSaveTimer.Interval = AutoSaveInterval Else AutoSaveTimer.Enabled = False
    '
    '            Case "TEXTENCODING"
    '                Select Case UCase(xW2)
    '                    Case "ANSI" : TextEncoding = System.Text.Encoding.Default
    '                    Case "UNICODE" : TextEncoding = System.Text.Encoding.Unicode
    '                    Case "ASCII" : TextEncoding = System.Text.Encoding.ASCII
    '                    Case "BIGENDIAN" : TextEncoding = System.Text.Encoding.BigEndianUnicode
    '                    Case "UTF32" : TextEncoding = System.Text.Encoding.UTF32
    '                    Case "UTF7" : TextEncoding = System.Text.Encoding.UTF7
    '                    Case "UTF8" : TextEncoding = System.Text.Encoding.UTF8
    '                End Select
    '
    '            Case "NTINPUT"
    '                If CBool(Val(xW2)) Then
    '                    NTInput = True
    '                    TBNTInput.Checked = True
    '                    mnNTInput.Checked = True
    '                    POBLong.Enabled = False
    '                    POBLongShort.Enabled = False
    '                End If
    '
    '            Case "SORTINGMETHOD" : SortingMethod = Val(xW2)
    '            Case "ERRORCHECK" : ErrorCheck = Val(xW2) : TBErrorCheck.Checked = ErrorCheck : TBErrorCheck_Click(TBErrorCheck, New System.EventArgs)
    '            Case "SHOWFILENAME" : ShowFileName = Val(xW2) : TBShowFileName.Checked = ShowFileName : TBShowFileName_Click(TBShowFileName, New System.EventArgs)
    '
    '            Case "BMSGRIDLIMIT" : BMSGridLimit = Val(xW2)
    '            Case "BEEPWHILESAVE" : BeepWhileSave = Val(xW2)
    '            Case "BPMX1296" : BPMx1296 = Val(xW2)
    '            Case "STOPX1296" : STOPx1296 = Val(xW2)
    '
    '            Case "AUTOFOCUSMOUSEENTER" : AutoFocusMouseEnter = Val(xW2)
    '            Case "FIRSTCLICKDISABLED" : FirstClickDisabled = Val(xW2)
    '
    '            Case "WAVMULTISELECT" : CWAVMultiSelect.Checked = Val(xW2) : WAVMultiSelect = Val(xW2) : CWAVMultiSelect_CheckedChanged(Nothing, Nothing)
    '            Case "WAVCHANGELABEL" : CWAVChangeLabel.Checked = Val(xW2) : WAVChangeLabel = Val(xW2) : CWAVChangeLabel_CheckedChanged(Nothing, Nothing)
    '            Case "BEATCHANGEMODE"
    '                Dim xInt As Integer = CInt(Val(xW2))
    '                If xInt >= 0 And xInt < mnBeat.Items.Count Then _
    '                    CType(mnBeat.Items(xInt), ToolStripMenuItem).Checked = True : CBeatPreserve_Click(mnBeat.Items(xInt), New System.EventArgs)
    '
    '            Case "SHOWMENU" : mnSMenu.Checked = Val(xW2)
    '            Case "SHOWTB" : mnSTB.Checked = Val(xW2)
    '            Case "SHOWOPPANEL" : mnSOP.Checked = Val(xW2)
    '            Case "SHOWSTATUS" : mnSStatus.Checked = Val(xW2)
    '            Case "SHOWLSPLIT" : mnSLSplitter.Checked = Val(xW2)
    '            Case "SHOWRSPLIT" : mnSRSplitter.Checked = Val(xW2)
    '
    '            Case "GSNAP" : CGSnap.Checked = Val(xW2)
    '            Case "GWHEEL" : gWheel = Val(xW2)
    '            Case "GPGUPDN" : gPgUpDn = Val(xW2)
    '            Case "GSHOW" : CGShow.Checked = Val(xW2)
    '            Case "GSHOWS" : CGShowS.Checked = Val(xW2)
    '            Case "GSHOWBG" : CGShowBG.Checked = Val(xW2)
    '            Case "GSHOWM" : CGShowM.Checked = Val(xW2)
    '            Case "GSHOWV" : CGShowV.Checked = Val(xW2)
    '            Case "GSHOWMB" : CGShowMB.Checked = Val(xW2)
    '            Case "GSHOWC" : CGShowC.Checked = Val(xW2)
    '
    '            Case "GBLP" : CGBLP.Checked = Val(xW2)
    '            Case "GSTOP" : CGSTOP.Checked = Val(xW2)
    '                'Case "GA8" : CGA8.Checked = Val(xW2)
    '            Case "GP2" : CHPlayer.SelectedIndex = Val(xW2)
    '            Case "GCOL" : CGB.Value = Val(xW2) - niB + 1
    '
    '            Case "GDIVIDE"
    '                Dim xTemp As Integer = Val(xW2)
    '                If xTemp < CGDivide.Minimum Or xTemp > CGDivide.Maximum Then Exit Select
    '                CGDivide.Value = xTemp
    '            Case "GSUB"
    '                Dim xTemp As Integer = Val(xW2)
    '                If xTemp < CGSub.Minimum Or xTemp > CGSub.Maximum Then Exit Select
    '                CGSub.Value = xTemp
    '            Case "GXHEIGHT" : CGHeight.Value = Val(xW2)
    '            Case "GXWIDTH" : CGWidth.Value = Val(xW2)
    '
    '            Case "VOTITLE" : vo.Title.Color = Color.FromArgb(Val(xW2))
    '            Case "VOTITLEFONT" : vo.TitleFont = StringToFont(xW2)
    '            Case "vo.Bg" : vo.Bg.Color = Color.FromArgb(Val(xW2))
    '            Case "VOGRID" : vo.pGrid.Color = Color.FromArgb(Val(xW2))
    '            Case "VOSUB" : vo.pSub.Color = Color.FromArgb(Val(xW2))
    '            Case "VOVLINE" : vo.pVLine.Color = Color.FromArgb(Val(xW2))
    '            Case "VOMLINE" : vo.pMLine.Color = Color.FromArgb(Val(xW2))
    '            Case "vo.BgMWAV"
    '                vo.pBGMWav.Color = Color.FromArgb(Val(xW2))
    '                TWTransparency.Value = vo.pBGMWav.Color.A
    '                TWTransparency2.Value = vo.pBGMWav.Color.A
    '                TWSaturation.Value = vo.pBGMWav.Color.GetSaturation * 1000
    '                TWSaturation2.Value = vo.pBGMWav.Color.GetSaturation * 1000
    '            Case "VOSELBOX" : vo.SelBox.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPECURSOR" : vo.PECursor.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPEHALF" : vo.PEHalf.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPEDELTAMOUSEOVER" : vo.PEDeltaMouseOver = Val(xW2)
    '            Case "VOPEMOUSEOVER" : vo.PEMouseOver.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPESEL" : vo.PESel.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPEBPM" : vo.PEBPM.Color = Color.FromArgb(Val(xW2))
    '            Case "VOPEBPMFONT" : vo.PEBPMFont = StringToFont(xW2)
    '            Case "vo.KHeight" : vo.KHeight = Val(xW2)
    '            Case "VKFONT" : vo.kFont = StringToFont(xW2)
    '            Case "VKMFONT" : vo.kMFont = StringToFont(xW2)
    '            Case "VKLABELVSHIFT" : vo.kLabelVShift = Val(xW2)
    '            Case "VKLABELHSHIFT" : vo.kLabelHShift = Val(xW2)
    '            Case "VKLABELHSHIFTL" : vo.kLabelHShiftL = Val(xW2)
    '            Case "vo.kMouseOver" : vo.kMouseOver.Color = Color.FromArgb(Val(xW2))
    '            Case "vo.kMouseOverE " : vo.kMouseOverE.Color = Color.FromArgb(Val(xW2))
    '            Case "VKSELECTED" : vo.kSelected.Color = Color.FromArgb(Val(xW2))
    '            Case "VKHIDTRANSPARENCY" : vo.kHidTransparency = Val(xW2)
    '
    '            Case "WLOCK" : wLock = Val(xW2) : BWLock.Checked = wLock
    '            Case "WPOSITION" : TWPosition.Value = Val(xW2)
    '            Case "WLEFT" : TWLeft.Value = Val(xW2)
    '            Case "WWIDTH" : TWWidth.Value = Val(xW2)
    '            Case "WPRECISION" : TWPrecision.Value = Val(xW2)
    '
    '            Case "PARGS" : xEnclosingW1 = "PARGS" : Erase pArgs
    '            Case "PREVIEWONCLICK" : PreviewOnClick = Val(xW2) : TBPreviewOnClick.Checked = PreviewOnClick : TBPreviewOnClick_Click(TBPreviewOnClick, New System.EventArgs)
    '                'Case "PREVIEWERRORCHECK" : PreviewErrorCheck = Val(xW2) : TBPreviewErrorCheck.Checked = PreviewErrorCheck : TBPreviewErrorCheck_Click(TBPreviewErrorCheck, New System.EventArgs)
    '            Case "CLICKSTOPPREVIEW" : ClickStopPreview = Val(xW2)
    '            Case "CPREVPLAYERINDEX" : CurrentPlayer = Val(xW2)
    '
    '            Case "KLENGTH" : kLength = StringToArrayInt(xW2) : UpdateKLeft()
    '            Case "KTITLE" : kTitle = Split(xW2, ",")
    '            Case "KENABLED" : kEnabled = StringToArrayBool(xW2)
    '            Case "KNUMERIC" : kNumericLabel = StringToArrayBool(xW2)
    '            Case "KVISIBLE" : kVisible = StringToArrayBool(xW2)
    '            Case "KCOLOR" : kColor = StringToArrayInt(xW2)
    '            Case "KCOLORL" : kColorL = StringToArrayInt(xW2)
    '            Case "KFORECOLOR" : kForeColor = StringToArrayInt(xW2)
    '            Case "KFORECOLORL" : kForeColorL = StringToArrayInt(xW2)
    '            Case "KBGCOLOR" : kBgColor = StringToArrayInt(xW2)
    '        End Select
    '
    '    Else
    '        Select Case xEnclosingW1
    '            Case "PARGS"
    '                If Not xLine.Trim = "}" Then
    '                    If pArgs Is Nothing Then ReDim pArgs(0) Else ReDim Preserve pArgs(UBound(pArgs) + 1)
    '                    pArgs(UBound(pArgs)) = Replace(xLine, "|", vbCrLf)
    '                Else
    '                    xEnclosingW1 = ""
    '                End If
    '
    '        End Select
    '    End If
    'Next
    '
    'UpdateKLeft()
    'End Sub

    Private Sub NewRecent(ByVal xFileName As String)
        Dim xAlreadyExists As Boolean = False
        Dim xI1 As Integer

        For xI1 = 0 To 4
            If Recent(xI1) = xFileName Then
                xAlreadyExists = True
                Exit For
            End If
        Next

        If xAlreadyExists Then
            For xI2 As Integer = xI1 To 1 Step -1
                Recent(xI2) = Recent(xI2 - 1)
            Next
            Recent(0) = xFileName

        Else
            Recent(4) = Recent(3)
            Recent(3) = Recent(2)
            Recent(2) = Recent(1)
            Recent(1) = Recent(0)
            Recent(0) = xFileName
        End If

        SetRecent(4, Recent(4))
        SetRecent(3, Recent(3))
        SetRecent(2, Recent(2))
        SetRecent(1, Recent(1))
        SetRecent(0, Recent(0))
    End Sub

    Private Sub SetRecent(ByVal Index As Integer, ByVal Text As String)
        Text = Text.Trim

        Dim xTBOpenR As ToolStripMenuItem
        Dim xmnOpenR As ToolStripMenuItem
        Select Case Index
            Case 0 : xTBOpenR = TBOpenR0 : xmnOpenR = mnOpenR0
            Case 1 : xTBOpenR = TBOpenR1 : xmnOpenR = mnOpenR1
            Case 2 : xTBOpenR = TBOpenR2 : xmnOpenR = mnOpenR2
            Case 3 : xTBOpenR = TBOpenR3 : xmnOpenR = mnOpenR3
            Case 4 : xTBOpenR = TBOpenR4 : xmnOpenR = mnOpenR4
            Case Else : Return
        End Select

        xTBOpenR.Text = IIf(Text = "", "<" & Locale.None & ">", GetFileName(Text)) : xTBOpenR.ToolTipText = Text : xTBOpenR.Enabled = Not Text = ""
        xmnOpenR.Text = IIf(Text = "", "<" & Locale.None & ">", GetFileName(Text)) : xmnOpenR.ToolTipText = Text : xmnOpenR.Enabled = Not Text = ""
    End Sub

    Private Sub OpenRecent(ByVal xFileName As String)
        'KMouseDown = -1
        ReDim uNotes(-1)
        KMouseOver = -1
        If Not My.Computer.FileSystem.FileExists(xFileName) Then
            MsgBox(Locale.Messages.CannotFind.Replace("{}", xFileName), MsgBoxStyle.Critical)
            Exit Sub
        End If
        If ClosingPopSave() Then Exit Sub

        Select Case UCase(Path.GetExtension(xFileName))
            Case ".BMS", ".BME", ".BML", ".PMS", ".TXT"
                InitPath = ExcludeFileName(xFileName)
                SetFileName(xFileName)
                ClearUndo()
                OpenBMS(My.Computer.FileSystem.ReadAllText(xFileName, TextEncoding))
                SetFileName(FileName)
                SetIsSaved(True)
            Case ".IBMSC"
                InitPath = ExcludeFileName(xFileName)
                SetFileName("Imported_" & GetFileName(xFileName))
                OpeniBMSC(xFileName)
                SetIsSaved(False)
        End Select
    End Sub

    Private Sub TBOpenR0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpenR0.Click, mnOpenR0.Click
        OpenRecent(Recent(0))
    End Sub
    Private Sub TBOpenR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpenR1.Click, mnOpenR1.Click
        OpenRecent(Recent(1))
    End Sub
    Private Sub TBOpenR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpenR2.Click, mnOpenR2.Click
        OpenRecent(Recent(2))
    End Sub
    Private Sub TBOpenR3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpenR3.Click, mnOpenR3.Click
        OpenRecent(Recent(3))
    End Sub
    Private Sub TBOpenR4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBOpenR4.Click, mnOpenR4.Click
        OpenRecent(Recent(4))
    End Sub

    ''' <param name="xH">Hue (0-359)</param>
    ''' <param name="xS">Saturation (0-1000)</param>
    ''' <param name="xL">Lightness (0-1000)</param>
    ''' <param name="xA">Alpha (0-255)</param>
    Private Function HSL2RGB(ByVal xH As Integer, ByVal xS As Integer, ByVal xL As Integer, Optional ByVal xA As Integer = 255) As Color
        If xH > 360 Or xS > 1000 Or xL > 1000 Or xA > 255 Then Return Color.Black

        'Dim xxH As Double = xH
        Dim xxS As Double = xS / 1000
        Dim xxB As Double = (xL - 500) / 500
        Dim xR As Double
        Dim xG As Double
        Dim xB As Double

        If xH < 60 Then
            xB = -1 : xR = 1 : xG = (xH - 30) / 30
        ElseIf xH < 120 Then
            xB = -1 : xG = 1 : xR = (90 - xH) / 30
        ElseIf xH < 180 Then
            xR = -1 : xG = 1 : xB = (xH - 150) / 30
        ElseIf xH < 240 Then
            xR = -1 : xB = 1 : xG = (210 - xH) / 30
        ElseIf xH < 300 Then
            xG = -1 : xB = 1 : xR = (xH - 270) / 30
        Else
            xG = -1 : xR = 1 : xB = (330 - xH) / 30
        End If

        xR = (xR * xxS * (1 - Math.Abs(xxB)) + xxB + 1) * 255 / 2
        xG = (xG * xxS * (1 - Math.Abs(xxB)) + xxB + 1) * 255 / 2
        xB = (xB * xxS * (1 - Math.Abs(xxB)) + xxB + 1) * 255 / 2

        Return Color.FromArgb(xA, xR, xG, xB)
    End Function

    Private Sub TWPosition_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWPosition.ValueChanged
        wPosition = TWPosition.Value
        TWPosition2.Value = IIf(wPosition > TWPosition2.Maximum, TWPosition2.Maximum, wPosition)
        RefreshPanelAll()
    End Sub

    Private Sub TWLeft_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWLeft.ValueChanged
        wLeft = TWLeft.Value
        TWLeft2.Value = IIf(wLeft > TWLeft2.Maximum, TWLeft2.Maximum, wLeft)
        RefreshPanelAll()
    End Sub

    Private Sub TWWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWWidth.ValueChanged
        wWidth = TWWidth.Value
        TWWidth2.Value = IIf(wWidth > TWWidth2.Maximum, TWWidth2.Maximum, wWidth)
        RefreshPanelAll()
    End Sub

    Private Sub TWPrecision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWPrecision.ValueChanged
        wPrecision = TWPrecision.Value
        TWPrecision2.Value = IIf(wPrecision > TWPrecision2.Maximum, TWPrecision2.Maximum, wPrecision)
        RefreshPanelAll()
    End Sub

    Private Sub TWTransparency_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWTransparency.ValueChanged
        TWTransparency2.Value = TWTransparency.Value
        vo.pBGMWav.Color = Color.FromArgb(TWTransparency.Value, vo.pBGMWav.Color)
        RefreshPanelAll()
    End Sub

    Private Sub TWSaturation_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWSaturation.ValueChanged
        Dim xColor As Color = vo.pBGMWav.Color
        TWSaturation2.Value = TWSaturation.Value
        vo.pBGMWav.Color = HSL2RGB(xColor.GetHue, TWSaturation.Value, xColor.GetBrightness * 1000, xColor.A)
        RefreshPanelAll()
    End Sub

    Private Sub TWPosition2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWPosition2.Scroll
        TWPosition.Value = TWPosition2.Value
    End Sub

    Private Sub TWLeft2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWLeft2.Scroll
        TWLeft.Value = TWLeft2.Value
    End Sub

    Private Sub TWWidth2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWWidth2.Scroll
        TWWidth.Value = TWWidth2.Value
    End Sub

    Private Sub TWPrecision2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWPrecision2.Scroll
        TWPrecision.Value = TWPrecision2.Value
    End Sub

    Private Sub TWTransparency2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWTransparency2.Scroll
        TWTransparency.Value = TWTransparency2.Value
    End Sub

    Private Sub TWSaturation2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TWSaturation2.Scroll
        TWSaturation.Value = TWSaturation2.Value
    End Sub

    Private Sub TBLangDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBLangDef.Click
        DispLang = ""
        MsgBox(Locale.Messages.PreferencePostpone, MsgBoxStyle.Information)
    End Sub

    Private Sub TBLangRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBLangRefresh.Click
        For xI1 As Integer = cmnLanguage.Items.Count - 1 To 3 Step -1
            Try
                cmnLanguage.Items.RemoveAt(xI1)
            Catch ex As Exception
            End Try
        Next

        If Not Directory.Exists(My.Application.Info.DirectoryPath & "\Data") Then My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Data")
        Dim xFileNames() As FileInfo = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Data").GetFiles("*.Lang.xml")

        'For Each xStr As FileInfo In xFileNames
        '    Dim xStrAll As String = My.Computer.FileSystem.ReadAllText(xStr.FullName, System.Text.Encoding.Unicode)
        '    If Not xStrAll.StartsWith("iBMSC Language Pack Format", StringComparison.CurrentCultureIgnoreCase) Then Continue For
        '
        '    Dim xAuthOcc As Integer = InStr(UCase(xStrAll), "AUTHOR=")
        '    Dim xLangOcc As Integer = InStr(UCase(xStrAll), "LANG=")
        '    If xLangOcc = 0 Then xLangOcc = InStr(UCase(xStrAll), "LAN=")
        '    If xLangOcc = 0 Then xLangOcc = InStr(UCase(xStrAll), "LANGUAGE=")
        '
        '    Dim xName As String
        '    If xAuthOcc <> 0 And xLangOcc <> 0 Then
        '        xName = Mid(xStrAll, xLangOcc + 5, InStr(xLangOcc + 5, xStrAll, vbCrLf) - xLangOcc - 5) & " by " & _
        '                Mid(xStrAll, xAuthOcc + 7, InStr(xAuthOcc + 7, xStrAll, vbCrLf) - xAuthOcc - 7)
        '    ElseIf xAuthOcc = 0 And xLangOcc <> 0 Then
        '        xName = Mid(xStrAll, xLangOcc + 5, InStr(xLangOcc + 5, xStrAll, vbCrLf) - xLangOcc - 5) & " by Unknown"
        '    ElseIf xAuthOcc <> 0 Then
        '        xName = xStr.Name & " by " & Mid(xStrAll, xAuthOcc + 7, InStr(xAuthOcc + 7, xStrAll, vbCrLf) - xAuthOcc - 7)
        '    Else
        '        xName = xStr.Name
        '    End If
        '
        '    cmnLanguage.Items.Add(xName, Nothing, AddressOf LoadLang)
        '    cmnLanguage.Items(cmnLanguage.Items.Count - 1).ToolTipText = xStr.FullName
        'Next

        For Each xStr As FileInfo In xFileNames
            Dim d As New XmlDataDocument
            Dim fs As New FileStream(xStr.FullName, FileMode.Open, FileAccess.Read)

            Try
                d.Load(fs)
                Dim xName As String = d.Item("iBMSC.Locale").GetAttribute("Name")
                If xName = "" Then xName = xStr.Name

                cmnLanguage.Items.Add(xName, Nothing, AddressOf LoadLang)
                cmnLanguage.Items(cmnLanguage.Items.Count - 1).ToolTipText = xStr.FullName

            Catch ex As Exception
                MsgBox(xStr.FullName & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

            End Try

            fs.Close()
        Next
    End Sub

    Private Sub LoadLang(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xFN2 As String = sender.ToolTipText
        'ReadLanguagePack(xFN2)
        LoadLocale(xFN2)
    End Sub

    Private Sub UpdateKLeft()
        col(0).Left = 0
        'If col(0).Width = 0 Then col(0).Visible = False

        For xI1 As Integer = 1 To UBound(col)
            col(xI1).Left = col(xI1 - 1).Left + IIf(col(xI1 - 1).isVisible, col(xI1 - 1).Width, 0)
            'If col(xI1).Width = 0 Then col(xI1).Visible = False
        Next
        HSL.Maximum = nLeft(gCol) + col(niB).Width
        HS.Maximum = nLeft(gCol) + col(niB).Width
        HSR.Maximum = nLeft(gCol) + col(niB).Width
    End Sub

    'Private Sub CGA8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGA8.CheckedChanged
    '    Dim xUndo As String = sCmdCV()
    '    gA8 = CGA8.Checked
    '    Dim xRedo As String = sCmdCV()

    '    kVisible(niA8) = gA8

    '    If IsInitializing Then Exit Sub
    '    For xI1 As Integer = 1 To UBound(K)
    '        K(xI1).Selected = K(xI1).Selected And nEnabled(K(xI1).ColumnIndex)
    '    Next
    '    AddUndo(xUndo, xRedo)
    '    UpdateKLeft()
    '    RefreshPanelAll()
    'End Sub

    Private Sub CHPlayer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHPlayer.SelectedIndexChanged
        If CHPlayer.SelectedIndex = -1 Then CHPlayer.SelectedIndex = 0

        'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        'Dim xRedo As UndoRedo.LinkedURCmd = Nothing

        'Dim xUndo As String = sCmdCV()
        'gP2 = CHPlayer.SelectedIndex
        'Dim xRedo As String = sCmdCV()

        'Me.RedoChangeVisibleColumns(gBLP, gSTOP, iPlayer, gBLP, gSTOP, CHPlayer.SelectedIndex, xUndo, xRedo)

        iPlayer = CHPlayer.SelectedIndex
        Dim xGP2 As Boolean = iPlayer <> 0
        col(niD1).isVisible = xGP2
        col(niD2).isVisible = xGP2
        col(niD3).isVisible = xGP2
        col(niD4).isVisible = xGP2
        col(niD5).isVisible = xGP2
        col(niD6).isVisible = xGP2
        col(niD7).isVisible = xGP2
        col(niD8).isVisible = xGP2
        col(niS3).isVisible = xGP2

        For xI1 As Integer = 1 To UBound(K)
            K(xI1).Selected = K(xI1).Selected And nEnabled(K(xI1).ColumnIndex)
        Next
        'AddUndo(xUndo, xRedo)
        UpdateKLeft()

        If IsInitializing Then Exit Sub
        RefreshPanelAll()
    End Sub

    Private Sub CGB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGB.ValueChanged
        gCol = niB + CGB.Value - 1
        UpdateKLeft()
        RefreshPanelAll()
    End Sub

    Private Sub TBGOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBGOptions.Click, mnGOptions.Click
        Dim xTE As Integer
        Select Case UCase(EncodingToString())
            Case "ANSI" : xTE = 0
            Case "UNICODE" : xTE = 1
            Case "ASCII" : xTE = 2
            Case "BIGENDIAN" : xTE = 3
            Case "UTF32" : xTE = 4
            Case "UTF7" : xTE = 5
            Case "UTF8" : xTE = 6
        End Select

        Dim xDiag As New OpGeneral(gWheel, gPgUpDn, MiddleButtonMoveMethod, xTE, 192.0R / BMSGridLimit, _
            AutoSaveInterval, BeepWhileSaved, BPMx1296, STOPx1296, _
            AutoFocusMouseEnter, FirstClickDisabled, ClickStopPreview)

        If xDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With xDiag
                gWheel = .zWheel
                gPgUpDn = .zPgUpDn
                TextEncoding = .zEncoding
                'SortingMethod = .zSort
                MiddleButtonMoveMethod = .zMiddle
                AutoSaveInterval = .zAutoSave
                BMSGridLimit = 192.0R / .zGridPartition
                BeepWhileSaved = .cBeep.Checked
                BPMx1296 = .cBpm1296.Checked
                STOPx1296 = .cStop1296.Checked
                AutoFocusMouseEnter = .cMEnterFocus.Checked
                FirstClickDisabled = .cMClickFocus.Checked
                ClickStopPreview = .cMStopPreview.Checked
            End With
            If AutoSaveInterval Then AutoSaveTimer.Interval = AutoSaveInterval
            AutoSaveTimer.Enabled = AutoSaveInterval
        End If
    End Sub

    Private Sub POBLong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBLong.Click
        If NTInput Then Exit Sub

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, True, True, xUndo, xRedo)
            K(xI1).LongNote = True
        Next
        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBShort.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        If Not NTInput Then
            For xI1 As Integer = 1 To UBound(K)
                If Not K(xI1).Selected Then Continue For

                Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, 0, True, xUndo, xRedo)
                K(xI1).LongNote = False
            Next

        Else
            For xI1 As Integer = 1 To UBound(K)
                If Not K(xI1).Selected Then Continue For

                Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, 0, True, xUndo, xRedo)
                K(xI1).Length = 0
            Next
        End If

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBNormalLong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBLongShort.Click
        If NTInput Then Exit Sub

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, Not K(xI1).LongNote, True, xUndo, xRedo)
            K(xI1).LongNote = Not K(xI1).LongNote
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBHidden.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Me.RedoHiddenNoteModify(K(xI1), True, True, xUndo, xRedo)
            K(xI1).Hidden = True
        Next
        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBVisible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBVisible.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Me.RedoHiddenNoteModify(K(xI1), False, True, xUndo, xRedo)
            K(xI1).Hidden = False
        Next
        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBHiddenVisible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBHiddenVisible.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        For xI1 As Integer = 1 To UBound(K)
            If Not K(xI1).Selected Then Continue For

            Me.RedoHiddenNoteModify(K(xI1), Not K(xI1).Hidden, True, xUndo, xRedo)
            K(xI1).Hidden = Not K(xI1).Hidden
        Next
        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
    End Sub

    Private Sub POBModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBModify.Click
        Dim xNum As Boolean = False
        Dim xLbl As Boolean = False
        Dim xI1 As Integer

        For xI1 = 1 To UBound(K)
            If K(xI1).Selected AndAlso nNumericLabel(K(xI1).ColumnIndex) Then xNum = True : Exit For
        Next
        For xI1 = 1 To UBound(K)
            If K(xI1).Selected AndAlso Not nNumericLabel(K(xI1).ColumnIndex) Then xLbl = True : Exit For
        Next
        If Not (xNum Or xLbl) Then Exit Sub

        If xNum Then
            Dim xD1 As Double = Val(InputBox(Locale.Messages.PromptEnterNumeric, Me.Text)) * 10000
            If Not xD1 = 0 Then
                If xD1 <= 0 Then xD1 = 1
                If xD1 > 655359999 Then xD1 = 655359999

                Dim xUndo As UndoRedo.LinkedURCmd = Nothing
                Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
                Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

                For xI1 = 1 To UBound(K)
                    If Not nNumericLabel(K(xI1).ColumnIndex) Then Continue For
                    If Not K(xI1).Selected Then Continue For

                    Me.RedoRelabelNote(K(xI1), xD1, True, xUndo, xRedo)
                    K(xI1).Value = xD1
                Next
                AddUndo(xUndo, xBaseRedo.Next)
            End If
        End If

        If xLbl Then
            Dim xStr As String = UCase(Trim(InputBox(Locale.Messages.PromptEnter, Me.Text)))

            If Len(xStr) = 0 Then GoTo Jump2
            If xStr = "00" Or xStr = "0" Then GoTo Jump1
            If Not Len(xStr) = 1 And Not Len(xStr) = 2 Then GoTo Jump1

            Dim xI3 As Integer = Asc(Mid(xStr, 1, 1))
            If Not ((xI3 >= 48 And xI3 <= 57) Or (xI3 >= 65 And xI3 <= 90)) Then GoTo Jump1
            If Len(xStr) = 2 Then
                Dim xI4 As Integer = Asc(Mid(xStr, 2, 1))
                If Not ((xI4 >= 48 And xI4 <= 57) Or (xI4 >= 65 And xI4 <= 90)) Then GoTo Jump1
            End If
            Dim xVal As Integer = C36to10(xStr) * 10000

            Dim xUndo As UndoRedo.LinkedURCmd = Nothing
            Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
            Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

            For xI1 = 1 To UBound(K)
                If nNumericLabel(K(xI1).ColumnIndex) Then Continue For
                If Not K(xI1).Selected Then Continue For

                Me.RedoRelabelNote(K(xI1), xVal, True, xUndo, xRedo)
                K(xI1).Value = xVal
            Next
            AddUndo(xUndo, xBaseRedo.Next)
            GoTo Jump2
Jump1:
            MsgBox(Locale.Messages.InvalidLabel, MsgBoxStyle.Critical, Locale.Messages.Err)
Jump2:
        End If

        RefreshPanelAll()
    End Sub

    Private Sub TBMyO2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBMyO2.Click, mnMyO2.Click
        Dim xDiag As New dgMyO2
        xDiag.Show()
    End Sub

    Public Sub MyO2ConstBPM(ByVal vBPM As Integer)
        SortByVPositionInsertion()
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Dim xI1 As Integer
        Dim xI2 As Integer
        Dim xI3 As Integer

        'Save undo
        'For xI3 = 1 To UBound(K)
        ' K(xI3).Selected = True
        ' Next
        ' xUndo = "KZ" & vbCrLf & _
        '         sCmdKs(False) & vbCrLf & _
        '         "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_0"
        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        'Adjust note
        Dim xcTime As Double = 0
        Dim xcVPos As Double = 0
        Dim xcBPM As Integer = K(0).Value

        If Not NTInput Then
            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex = niBPM Then
                    xcTime += (K(xI1).VPosition - xcVPos) / xcBPM
                    xcVPos = K(xI1).VPosition
                    xcBPM = K(xI1).Value
                Else
                    K(xI1).VPosition = vBPM * (xcTime + (K(xI1).VPosition - xcVPos) / xcBPM)
                End If
            Next

        Else
            For xI1 = 1 To UBound(K)
                If K(xI1).ColumnIndex = niBPM Then
                    xcTime += (K(xI1).VPosition - xcVPos) / xcBPM
                    xcVPos = K(xI1).VPosition
                    xcBPM = K(xI1).Value
                ElseIf K(xI1).Length = 0 Then
                    K(xI1).VPosition = vBPM * (xcTime + (K(xI1).VPosition - xcVPos) / xcBPM)
                Else
                    Dim xNewTimeL As Double = (xcTime + (K(xI1).VPosition - xcVPos) / xcBPM)

                    'find bpms
                    Dim xcTime2 As Double = xcTime
                    Dim xcVPos2 As Double = xcVPos
                    Dim xcBPM2 As Integer = xcBPM
                    For xI2 = xI1 + 1 To UBound(K)
                        If K(xI2).VPosition >= K(xI1).VPosition + K(xI1).Length Then Exit For
                        If K(xI2).ColumnIndex = niBPM Then
                            xcTime2 += (K(xI2).VPosition - xcVPos2) / xcBPM2
                            xcVPos2 = K(xI2).VPosition
                            xcBPM2 = K(xI2).Value
                        End If
                    Next
                    Dim xNewTimeU As Double = (xcTime2 + (K(xI1).VPosition + K(xI1).Length - xcVPos2) / xcBPM2)

                    K(xI1).VPosition = vBPM * xNewTimeL
                    K(xI1).Length = vBPM * xNewTimeU - K(xI1).VPosition
                End If
            Next
        End If

        'Delete BPMs
        xI1 = 1
        Do While xI1 <= UBound(K)
            If K(xI1).ColumnIndex = niBPM Then
                For xI3 = xI1 + 1 To UBound(K)
                    K(xI3 - 1) = K(xI3)
                Next
                ReDim Preserve K(UBound(K) - 1)
            Else
                xI1 += 1
            End If
        Loop

        'Save redo
        'For xI3 = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xRedo = "KZ" & vbCrLf & _
        '        sCmdKs(False) & vbCrLf & _
        '        "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

        Me.RedoAddNoteAll(False, xUndo, xRedo)
        Me.RedoRelabelNote(K(0), vBPM, False, xUndo, xRedo)

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        K(0).Value = vBPM
        THBPM.Value = vBPM / 10000
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Public Function MyO2GridCheck() As String()
        CalculateGreatestVPosition()
        SortByVPositionInsertion()
        Dim xResult(-1) As String
        Dim xResult2(-1) As String
        Dim Identifiers() As String = {"01", "03", "04", "06", "07", "08", "09", _
                                       "16", "11", "12", "13", "14", "15", "18", "19", _
                                       "26", "21", "22", "23", "24", "25", "28", "29", _
                                       "36", "31", "32", "33", "34", "35", "38", "39", _
                                       "46", "41", "42", "43", "44", "45", "48", "49", _
                                       "56", "51", "52", "53", "54", "55", "58", "59", _
                                       "66", "61", "62", "63", "64", "65", "68", "69", _
                                       "76", "71", "72", "73", "74", "75", "78", "79", _
                                       "86", "81", "82", "83", "84", "85", "88", "89"}

        Dim xLowerIndex As Integer = 1
        Dim xUpperIndex As Integer = 1

        If Not NTInput Then
            For xMeasure As Integer = 0 To InMeasure(GreatestVPosition)
                'Find Ks in the same measure
                Dim xI1 As Integer
                For xI1 = xLowerIndex To UBound(K)
                    If InMeasure(K(xI1).VPosition) > xMeasure Then Exit For
                Next
                xUpperIndex = xI1

                For Each xId As String In Identifiers
                    'collect vposition data
                    Dim xVPos(-1) As Double
                    For xI2 As Integer = xLowerIndex To xUpperIndex - 1
                        If nIdentifier(K(xI2).ColumnIndex, K(xI2).Value, K(xI2).LongNote, K(xI2).Hidden) = xId And Math.Abs(K(xI2).VPosition - InMeasure(K(xI2).VPosition) * 192) > 0 Then
                            ReDim Preserve xVPos(UBound(xVPos) + 1)
                            xVPos(UBound(xVPos)) = K(xI2).VPosition - xMeasure * 192 : If xVPos(UBound(xVPos)) < 0 Then xVPos(UBound(xVPos)) = 0
                        End If
                    Next

                    'find gcd
                    Dim xGCD As Double = 192
                    For xI2 As Integer = 0 To UBound(xVPos)
                        xGCD = GCD(xGCD, xVPos(xI2))
                    Next

                    'check if smaller than minGCD
                    If xGCD < 3 Then
                        'suggestion
                        Dim xAdj64 As Boolean
                        Dim xD48 As Integer = 0
                        Dim xD64 As Integer = 0
                        For xI2 As Integer = 0 To UBound(xVPos)
                            xD48 += Math.Abs(xVPos(xI2) - CInt(xVPos(xI2) / 4) * 4)
                            xD64 += Math.Abs(xVPos(xI2) - CInt(xVPos(xI2) / 3) * 3)
                        Next
                        xAdj64 = xD48 > xD64

                        'put result
                        ReDim Preserve xResult(UBound(xResult) + 1)
                        xResult(UBound(xResult)) = xMeasure & "_" & _
                                                   IdentifiertoColumnIndex(xId) & "_" & _
                                                   nTitle(IdentifiertoColumnIndex(xId)) & "_" & _
                                                   CStr(CInt(192 / xGCD)) & "_" & _
                                                   CInt(IdentifiertoLongNote(xId)) & "_" & _
                                                   CInt(IdentifiertoHidden(xId)) & "_" & _
                                                   CInt(xAdj64) & "_" & _
                                                   xD64 & "_" & _
                                                   xD48
                    End If
                Next

980:            xLowerIndex = xUpperIndex
990:        Next

        Else
            For xMeasure As Integer = 0 To InMeasure(GreatestVPosition)

                For Each xId As String In Identifiers
                    Dim xVPos(-1) As Double

                    'collect vposition data
                    For xI2 As Integer = 1 To UBound(K)
                        If InMeasure(K(xI2).VPosition) > xMeasure Then Exit For

                        If nIdentifier(K(xI2).ColumnIndex, K(xI2).Value, CBool(K(xI2).Length), K(xI2).Hidden) <> xId Then GoTo 1330
                        If IdentifiertoLongNote(xId) Xor CBool(K(xI2).Length) Then GoTo 1330

                        If InMeasure(K(xI2).VPosition) = xMeasure AndAlso Math.Abs(K(xI2).VPosition - InMeasure(K(xI2).VPosition) * 192) > 0 Then
                            ReDim Preserve xVPos(UBound(xVPos) + 1)
                            xVPos(UBound(xVPos)) = K(xI2).VPosition - xMeasure * 192 : If xVPos(UBound(xVPos)) < 0 Then xVPos(UBound(xVPos)) = 0
                        End If

                        If Not CBool(K(xI2).Length) Then GoTo 1330

                        If InMeasure(K(xI2).VPosition + K(xI2).Length) = xMeasure AndAlso Not K(xI2).VPosition + K(xI2).Length - xMeasure * 192 = 0 Then
                            ReDim Preserve xVPos(UBound(xVPos) + 1)
                            xVPos(UBound(xVPos)) = K(xI2).VPosition + K(xI2).Length - xMeasure * 192 : If xVPos(UBound(xVPos)) < 0 Then xVPos(UBound(xVPos)) = 0
                        End If
1330:               Next

                    'find gcd
                    Dim xGCD As Double = 192
                    For xI2 As Integer = 0 To UBound(xVPos)
                        xGCD = GCD(xGCD, xVPos(xI2))
                    Next

                    'check if smaller than minGCD
                    If xGCD < 3 Then
                        'suggestion
                        Dim xAdj64 As Boolean
                        Dim xD48 As Integer = 0
                        Dim xD64 As Integer = 0
                        For xI2 As Integer = 0 To UBound(xVPos)
                            xD48 += Math.Abs(xVPos(xI2) - CInt(xVPos(xI2) / 4) * 4)
                            xD64 += Math.Abs(xVPos(xI2) - CInt(xVPos(xI2) / 3) * 3)
                        Next
                        xAdj64 = xD48 > xD64

                        'put result
                        ReDim Preserve xResult(UBound(xResult) + 1)
                        xResult(UBound(xResult)) = xMeasure & "_" & _
                                                   IdentifiertoColumnIndex(xId) & "_" & _
                                                   nTitle(IdentifiertoColumnIndex(xId)) & "_" & _
                                                   CStr(CInt(192 / xGCD)) & "_" & _
                                                   CInt(IdentifiertoLongNote(xId)) & "_" & _
                                                   CInt(IdentifiertoHidden(xId)) & "_" & _
                                                   CInt(xAdj64) & "_" & _
                                                   xD64 & "_" & _
                                                   xD48
                    End If
                Next

1990:       Next
        End If

        Return xResult
    End Function

    Public Sub MyO2GridAdjust(ByVal xaj() As dgMyO2.Adj)
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        'Save undo
        'For xI3 As Integer = 1 To UBound(K)
        '    K(xI3).Selected = True
        'Next
        'xUndo = "KZ" & vbCrLf & _
        '        sCmdKs(False) & vbCrLf & _
        '        "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_0"
        Me.RedoRemoveNoteAll(False, xUndo, xRedo)

        'adjust
        If Not NTInput Then
            For Each xadj As dgMyO2.Adj In xaj
                For xI1 As Integer = 1 To UBound(K)
                    If InMeasure(K(xI1).VPosition) = xadj.Measure And _
                       K(xI1).ColumnIndex = xadj.ColumnIndex And _
                       K(xI1).LongNote = xadj.LongNote And _
                       K(xI1).Hidden = xadj.Hidden Then
                        K(xI1).VPosition = CLng(K(xI1).VPosition / IIf(xadj.AdjTo64, 3, 4)) * IIf(xadj.AdjTo64, 3, 4)
                    End If
                Next
            Next

        Else
            For Each xadj As dgMyO2.Adj In xaj
                For xI1 As Integer = 1 To UBound(K)
                    If CBool(K(xI1).Length) Xor xadj.LongNote Then GoTo 1100

                    Dim xStart As Double = K(xI1).VPosition
                    Dim xEnd As Double = K(xI1).VPosition + K(xI1).Length
                    If InMeasure(K(xI1).VPosition) = xadj.Measure And _
                       K(xI1).ColumnIndex = xadj.ColumnIndex And _
                       K(xI1).Hidden = xadj.Hidden Then _
                        xStart = CLng(K(xI1).VPosition / IIf(xadj.AdjTo64, 3, 4)) * IIf(xadj.AdjTo64, 3, 4)

                    If K(xI1).Length > 0 AndAlso _
                       InMeasure(K(xI1).VPosition + K(xI1).Length) = xadj.Measure And _
                       K(xI1).ColumnIndex = xadj.ColumnIndex And _
                       K(xI1).Hidden = xadj.Hidden Then _
                        xEnd = CLng((K(xI1).VPosition + K(xI1).Length) / IIf(xadj.AdjTo64, 3, 4)) * IIf(xadj.AdjTo64, 3, 4)

                    K(xI1).VPosition = xStart
                    If K(xI1).Length > 0 Then K(xI1).Length = xEnd - K(xI1).VPosition
1100:           Next
            Next
        End If

        'Save redo
        'For xI3 As Integer = 1 To UBound(K)
        ' K(xI3).Selected = True
        ' Next
        ' xRedo = "KZ" & vbCrLf & _
        '         sCmdKs(False) & vbCrLf & _
        '         "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"
        Me.RedoAddNoteAll(False, xUndo, xRedo)

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
        Beep()
    End Sub

    Private Sub TBFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFind.Click, mnFind.Click
        Dim xDiag As New diagFind(gCol, Locale.Messages.Err, Locale.Messages.InvalidLabel)
        xDiag.Show()
    End Sub

    Private Function fdrCheck(ByVal xNote As Note) As Boolean
        Return xNote.VPosition >= MeasureBottom(fdriMesL) And xNote.VPosition < MeasureBottom(fdriMesU) + MeasureLength(fdriMesU) AndAlso _
               IIf(nNumericLabel(xNote.ColumnIndex), _
                   xNote.Value >= fdriValL And xNote.Value <= fdriValU, _
                   xNote.Value >= fdriLblL And xNote.Value <= fdriLblU) AndAlso _
               Array.IndexOf(fdriCol, xNote.ColumnIndex) <> -1
    End Function

    Private Function fdrRangeS(ByVal xbLim1 As Boolean, ByVal xbLim2 As Boolean, ByVal xVal As Boolean) As Boolean
        Return (Not xbLim1 And xbLim2 And xVal) Or (xbLim1 And Not xbLim2 And Not xVal) Or (xbLim1 And xbLim2)
    End Function

    Public Sub fdrSelect(ByVal iRange As Integer, _
                         ByVal xMesL As Integer, ByVal xMesU As Integer, _
                         ByVal xLblL As String, ByVal xLblU As String, _
                         ByVal xValL As Integer, ByVal xValU As Integer, _
                         ByVal iCol() As Integer)

        fdriMesL = xMesL
        fdriMesU = xMesU
        fdriLblL = C36to10(xLblL) * 10000
        fdriLblU = C36to10(xLblU) * 10000
        fdriValL = xValL
        fdriValU = xValU
        fdriCol = iCol

        Dim xbSel As Boolean = iRange Mod 2 = 0
        Dim xbUnsel As Boolean = iRange Mod 3 = 0
        Dim xbShort As Boolean = iRange Mod 5 = 0
        Dim xbLong As Boolean = iRange Mod 7 = 0
        Dim xbHidden As Boolean = iRange Mod 11 = 0
        Dim xbVisible As Boolean = iRange Mod 13 = 0

        Dim xSel(UBound(K)) As Boolean
        For xI1 As Integer = 1 To UBound(K)
            xSel(xI1) = K(xI1).Selected
        Next

        'Main process
        For xI1 As Integer = 1 To UBound(K)
            Dim bbba As Boolean = xbSel And xSel(xI1)
            Dim bbbb As Boolean = xbUnsel And Not xSel(xI1)
            Dim bbbc As Boolean = nEnabled(K(xI1).ColumnIndex)
            Dim bbbd As Boolean = fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote))
            Dim bbbe As Boolean = fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden)
            Dim bbbf As Boolean = fdrCheck(K(xI1))

            If ((xbSel And xSel(xI1)) Or (xbUnsel And Not xSel(xI1))) AndAlso _
                    nEnabled(K(xI1).ColumnIndex) AndAlso fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote)) And fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden) Then
                K(xI1).Selected = fdrCheck(K(xI1))
            End If
        Next

        RefreshPanelAll()
        Beep()
    End Sub

    Public Sub fdrUnselect(ByVal iRange As Integer, _
                           ByVal xMesL As Integer, ByVal xMesU As Integer, _
                           ByVal xLblL As String, ByVal xLblU As String, _
                           ByVal xValL As Integer, ByVal xValU As Integer, _
                           ByVal iCol() As Integer)

        fdriMesL = xMesL
        fdriMesU = xMesU
        fdriLblL = C36to10(xLblL) * 10000
        fdriLblU = C36to10(xLblU) * 10000
        fdriValL = xValL
        fdriValU = xValU
        fdriCol = iCol

        Dim xbSel As Boolean = iRange Mod 2 = 0
        Dim xbUnsel As Boolean = iRange Mod 3 = 0
        Dim xbShort As Boolean = iRange Mod 5 = 0
        Dim xbLong As Boolean = iRange Mod 7 = 0
        Dim xbHidden As Boolean = iRange Mod 11 = 0
        Dim xbVisible As Boolean = iRange Mod 13 = 0

        Dim xSel(UBound(K)) As Boolean
        For xI1 As Integer = 1 To UBound(K)
            xSel(xI1) = K(xI1).Selected
        Next

        'Main process
        For xI1 As Integer = 1 To UBound(K)
            If ((xbSel And xSel(xI1)) Or (xbUnsel And Not xSel(xI1))) AndAlso _
                        nEnabled(K(xI1).ColumnIndex) AndAlso fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote)) And fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden) Then
                K(xI1).Selected = Not fdrCheck(K(xI1))
            End If
        Next

        RefreshPanelAll()
        Beep()
    End Sub

    Public Sub fdrDelete(ByVal iRange As Integer, _
                         ByVal xMesL As Integer, ByVal xMesU As Integer, _
                         ByVal xLblL As String, ByVal xLblU As String, _
                         ByVal xValL As Integer, ByVal xValU As Integer, _
                         ByVal iCol() As Integer)

        fdriMesL = xMesL
        fdriMesU = xMesU
        fdriLblL = C36to10(xLblL) * 10000
        fdriLblU = C36to10(xLblU) * 10000
        fdriValL = xValL
        fdriValU = xValU
        fdriCol = iCol

        Dim xbSel As Boolean = iRange Mod 2 = 0
        Dim xbUnsel As Boolean = iRange Mod 3 = 0
        Dim xbShort As Boolean = iRange Mod 5 = 0
        Dim xbLong As Boolean = iRange Mod 7 = 0
        Dim xbHidden As Boolean = iRange Mod 11 = 0
        Dim xbVisible As Boolean = iRange Mod 13 = 0

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        'Main process
        Dim xI1 As Integer = 1
        Do While xI1 <= UBound(K)
            If ((xbSel And K(xI1).Selected) Or (xbUnsel And Not K(xI1).Selected)) AndAlso _
                        fdrCheck(K(xI1)) AndAlso nEnabled(K(xI1).ColumnIndex) AndAlso fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote)) And fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden) Then
                'xUndo &= sCmdK(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                'xRedo &= sCmdKD(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden) & vbCrLf
                Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                RemoveNote(xI1, False)
            Else
                xI1 += 1
            End If
        Loop

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        RefreshPanelAll()
        CalculateTotalNotes()
        Beep()
    End Sub

    Public Sub fdrReplaceL(ByVal iRange As Integer, _
                           ByVal xMesL As Integer, ByVal xMesU As Integer, _
                           ByVal xLblL As String, ByVal xLblU As String, _
                           ByVal xValL As Integer, ByVal xValU As Integer, _
                           ByVal iCol() As Integer, ByVal xReplaceLbl As String)

        fdriMesL = xMesL
        fdriMesU = xMesU
        fdriLblL = C36to10(xLblL) * 10000
        fdriLblU = C36to10(xLblU) * 10000
        fdriValL = xValL
        fdriValU = xValU
        fdriCol = iCol

        Dim xbSel As Boolean = iRange Mod 2 = 0
        Dim xbUnsel As Boolean = iRange Mod 3 = 0
        Dim xbShort As Boolean = iRange Mod 5 = 0
        Dim xbLong As Boolean = iRange Mod 7 = 0
        Dim xbHidden As Boolean = iRange Mod 11 = 0
        Dim xbVisible As Boolean = iRange Mod 13 = 0

        Dim xxLbl As Integer = C36to10(xReplaceLbl) * 10000

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        'Main process
        For xI1 As Integer = 1 To UBound(K)
            If ((xbSel And K(xI1).Selected) Or (xbUnsel And Not K(xI1).Selected)) AndAlso _
                    fdrCheck(K(xI1)) AndAlso nEnabled(K(xI1).ColumnIndex) And Not nNumericLabel(K(xI1).ColumnIndex) AndAlso fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote)) And fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden) Then
                'xUndo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, xxLbl, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                'xRedo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, xxLbl, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                Me.RedoRelabelNote(K(xI1), xxLbl, True, xUndo, xRedo)
                K(xI1).Value = xxLbl
            End If
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        RefreshPanelAll()
        Beep()
    End Sub

    Public Sub fdrReplaceV(ByVal iRange As Integer, _
                           ByVal xMesL As Integer, ByVal xMesU As Integer, _
                           ByVal xLblL As String, ByVal xLblU As String, _
                           ByVal xValL As Integer, ByVal xValU As Integer, _
                           ByVal iCol() As Integer, ByVal xReplaceVal As Integer)

        fdriMesL = xMesL
        fdriMesU = xMesU
        fdriLblL = C36to10(xLblL) * 10000
        fdriLblU = C36to10(xLblU) * 10000
        fdriValL = xValL
        fdriValU = xValU
        fdriCol = iCol

        Dim xbSel As Boolean = iRange Mod 2 = 0
        Dim xbUnsel As Boolean = iRange Mod 3 = 0
        Dim xbShort As Boolean = iRange Mod 5 = 0
        Dim xbLong As Boolean = iRange Mod 7 = 0
        Dim xbHidden As Boolean = iRange Mod 11 = 0
        Dim xbVisible As Boolean = iRange Mod 13 = 0

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        'Main process
        For xI1 As Integer = 1 To UBound(K)
            If ((xbSel And K(xI1).Selected) Or (xbUnsel And Not K(xI1).Selected)) AndAlso _
                    fdrCheck(K(xI1)) AndAlso nEnabled(K(xI1).ColumnIndex) And nNumericLabel(K(xI1).ColumnIndex) AndAlso fdrRangeS(xbShort, xbLong, IIf(NTInput, K(xI1).Length, K(xI1).LongNote)) And fdrRangeS(xbVisible, xbHidden, K(xI1).Hidden) Then
                'xUndo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, xReplaceVal, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                'xRedo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, xReplaceVal, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                Me.RedoRelabelNote(K(xI1), xReplaceVal, True, xUndo, xRedo)
                K(xI1).Value = xReplaceVal
            End If
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        RefreshPanelAll()
        Beep()
    End Sub

    Private Sub MInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MInsert.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Dim xMeasure As Integer = InMeasure(menuVPosition)
        Dim xMLength As Double = MeasureLength(xMeasure)
        Dim xVP As Double = MeasureBottom(xMeasure)

        If NTInput Then
            Dim xI1 As Integer = 1
            Do While xI1 <= UBound(K)
                If InMeasure(K(xI1).VPosition) >= 999 Then
                    Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    RemoveNote(xI1, False)
                Else
                    xI1 += 1
                End If
            Loop

            Dim xdVP As Double
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition >= xVP And K(xI1).VPosition + K(xI1).Length <= MeasureBottom(999) Then
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, K(xI1).VPosition + xMLength, True, xUndo, xRedo)
                    K(xI1).VPosition += xMLength

                ElseIf K(xI1).VPosition >= xVP Then
                    xdVP = MeasureBottom(999) - 1 - K(xI1).VPosition - K(xI1).Length
                    Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition + xMLength, K(xI1).Length + xdVP, True, xUndo, xRedo)
                    K(xI1).VPosition += xMLength
                    K(xI1).Length += xdVP

                ElseIf K(xI1).VPosition + K(xI1).Length >= xVP Then
                    xdVP = IIf(K(xI1).VPosition + K(xI1).Length > MeasureBottom(999) - 1, VPosition1000() - 1 - K(xI1).VPosition - K(xI1).Length, xMLength)
                    Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, K(xI1).Length + xdVP, True, xUndo, xRedo)
                    K(xI1).Length += xdVP
                End If
            Next

        Else
            Dim xI1 As Integer = 1
            Do While xI1 <= UBound(K)
                If InMeasure(K(xI1).VPosition) >= 999 Then
                    Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    RemoveNote(xI1, False)
                Else
                    xI1 += 1
                End If
            Loop

            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition >= xVP Then
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, K(xI1).VPosition + xMLength, True, xUndo, xRedo)
                    K(xI1).VPosition += xMLength
                End If
            Next
        End If

        For xI1 As Integer = 999 To xMeasure + 1 Step -1
            MeasureLength(xI1) = MeasureLength(xI1 - 1)
        Next
        UpdateMeasureBottom()

        AddUndo(xUndo, xBaseRedo.Next)
        UpdatePairing()
        CalculateGreatestVPosition()
        CalculateTotalNotes()
        RefreshPanelAll()
    End Sub

    Private Sub MRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRemove.Click
        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Dim xMeasure As Integer = InMeasure(menuVPosition)
        Dim xMLength As Double = MeasureLength(xMeasure)
        Dim xVP As Double = MeasureBottom(xMeasure)

        If NTInput Then
            Dim xI1 As Integer = 1
            Do While xI1 <= UBound(K)
                If InMeasure(K(xI1).VPosition) = xMeasure And InMeasure(K(xI1).VPosition + K(xI1).Length) = xMeasure Then
                    Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    RemoveNote(xI1, False)
                Else
                    xI1 += 1
                End If
            Loop

            Dim xdVP As Double
            xVP = MeasureBottom(xMeasure)
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition >= xVP + xMLength Then
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, K(xI1).VPosition - xMLength, True, xUndo, xRedo)
                    K(xI1).VPosition -= xMLength

                ElseIf K(xI1).VPosition >= xVP Then
                    xdVP = xMLength + xVP - K(xI1).VPosition
                    Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition + xdVP - xMLength, K(xI1).Length - xdVP, True, xUndo, xRedo)
                    K(xI1).VPosition += xdVP - xMLength
                    K(xI1).Length -= xdVP

                ElseIf K(xI1).VPosition + K(xI1).Length >= xVP Then
                    xdVP = IIf(K(xI1).VPosition + K(xI1).Length >= xVP + xMLength, xMLength, K(xI1).VPosition + K(xI1).Length - xVP + 1)
                    Me.RedoLongNoteModify(K(xI1), K(xI1).VPosition, K(xI1).Length - xdVP, True, xUndo, xRedo)
                    K(xI1).Length -= xdVP
                End If
            Next

        Else
            Dim xI1 As Integer = 1
            Do While xI1 <= UBound(K)
                If InMeasure(K(xI1).VPosition) = xMeasure Then
                    Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
                    RemoveNote(xI1, False)
                Else
                    xI1 += 1
                End If
            Loop

            xVP = MeasureBottom(xMeasure)
            For xI1 = 1 To UBound(K)
                If K(xI1).VPosition >= xVP Then
                    Me.RedoMoveNote(K(xI1), K(xI1).ColumnIndex, K(xI1).VPosition - xMLength, True, xUndo, xRedo)
                    K(xI1).VPosition -= xMLength
                End If
            Next
        End If

        For xI1 As Integer = 999 To xMeasure + 1 Step -1
            MeasureLength(xI1 - 1) = MeasureLength(xI1)
        Next
        UpdateMeasureBottom()

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        CalculateGreatestVPosition()
        CalculateTotalNotes()
        RefreshPanelAll()
    End Sub

    Private Sub TBThemeDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBThemeDef.Click
        'SaveTheme = False
        'MsgBox(Locale.Messages.PreferencePostpone, MsgBoxStyle.Information)
        'col = New Column() {New Column(0, 50, "Measure", False, True, True, 0, 0, &HFF00FFFF, 0, &HFF00FFFF, 0), _
        '                    New Column(50, 60, "BPM", True, True, True, 3, 0, &HFFFF0000, 0, &HFFFF0000, 0), _
        '                    New Column(110, 50, "STOP", True, True, False, 9, 0, &HFFFF0000, 0, &HFFFF0000, 0), _
        '                    New Column(110, 5, "", False, False, True, 0, 0, 0, 0, 0, 0), _
        '                    New Column(115, 42, "A1", True, False, True, 16, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(157, 30, "A2", True, False, True, 11, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
        '                    New Column(187, 42, "A3", True, False, True, 12, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(229, 45, "A4", True, False, True, 13, &HFFFFC862, &HFF000000, &HFFF7C66A, &HFF000000, &H16F38B0C), _
        '                    New Column(274, 42, "A5", True, False, True, 14, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(316, 30, "A6", True, False, True, 15, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
        '                    New Column(346, 42, "A7", True, False, True, 18, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(388, 40, "A8", True, False, True, 19, &HFF808080, &HFF000000, &HFF909090, &HFF000000, 0), _
        '                    New Column(388, 5, "", False, False, True, 0, 0, 0, 0, 0, 0), _
        '                    New Column(393, 42, "D1", True, False, False, 21, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(393, 30, "D2", True, False, False, 22, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
        '                    New Column(393, 42, "D3", True, False, False, 23, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(393, 45, "D4", True, False, False, 24, &HFFFFC862, &HFF000000, &HFFF7C66A, &HFF000000, &H16F38B0C), _
        '                    New Column(393, 42, "D5", True, False, False, 25, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(393, 30, "D6", True, False, False, 28, &HFF62B0FF, &HFF000000, &HFF6AB0F7, &HFF000000, &H140033FF), _
        '                    New Column(393, 42, "D7", True, False, False, 29, &HFFB0B0B0, &HFF000000, &HFFC0C0C0, &HFF000000, &H14FFFFFF), _
        '                    New Column(393, 40, "D8", True, False, False, 26, &HFF808080, &HFF000000, &HFF909090, &HFF000000, 0), _
        '                    New Column(393, 5, "", False, False, False, 0, 0, 0, 0, 0, 0), _
        '                    New Column(393, 40, "BGA", True, False, False, 4, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
        '                    New Column(393, 40, "LAYER", True, False, False, 7, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
        '                    New Column(393, 40, "POOR", True, False, False, 6, &HFF8CD78A, &HFF000000, &HFF90D38E, &HFF000000, 0), _
        '                    New Column(393, 5, "", False, False, False, 0, 0, 0, 0, 0, 0), _
        '                    New Column(393, 40, "B", True, False, True, 1, &HFFE18080, &HFF000000, &HFFDC8585, &HFF000000, 0)}
        'vo = New visualSettings(New SolidBrush(Color.Lime), _
        '                        New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel), _
        '                        New SolidBrush(Color.Black), _
        '                        New Pen(Color.FromArgb(893008442)), _
        '                        New Pen(Color.FromArgb(1530542650)), _
        '                        New Pen(Color.FromArgb(-13158601)), _
        '                        New Pen(Color.FromArgb(1599230546)), _
        '                        New Pen(Color.FromArgb(851493056)), _
        '                        New Pen(Color.FromArgb(-1056964609)), _
        '                        New Pen(Color.FromArgb(&HC0FF8080)), _
        '                        New Pen(Color.FromArgb(&H808080FF)), _
        '                        5, _
        '                        New Pen(Color.FromArgb(&H80FF8080)), _
        '                        New SolidBrush(Color.FromArgb(855605376)), _
        '                        New SolidBrush(Color.FromArgb(855605376)), _
        '                        New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel), _
        '                        1, _
        '                        10, _
        '                        New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel), _
        '                        New Font("Verdana", 12, FontStyle.Regular, GraphicsUnit.Pixel), _
        '                        -2, _
        '                        0, _
        '                        2, _
        '                        New Pen(Color.Lime), _
        '                        New Pen(Color.FromArgb(-16711681)), _
        '                        New Pen(Color.Red), _
        '                        0.5)
        'CHPlayer_SelectedIndexChanged(CHPlayer, New System.EventArgs)
        Dim xTempFileName As String = My.Application.Info.DirectoryPath & "\____TempFile.Theme.xml"
        My.Computer.FileSystem.WriteAllText(xTempFileName, My.Resources.O2Mania_Theme, False, System.Text.Encoding.Unicode)
        LoadSettings(xTempFileName)
        System.IO.File.Delete(xTempFileName)

        RefreshPanelAll()
    End Sub

    Private Sub TBThemeSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBThemeSave.Click
        'Dim xDiag As New SaveFileDialog
        'xDiag.Filter = Locale.FileType.TH & "|*.th"
        'xDiag.DefaultExt = "th"
        'xDiag.InitialDirectory = My.Application.Info.DirectoryPath & "\Theme"
        '
        'If xDiag.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'My.Computer.FileSystem.WriteAllText(xDiag.FileName, SaveSkinCFF, False, System.Text.Encoding.Unicode)
        'If BeepWhileSave Then Beep()
        'TBThemeRefresh_Click(TBThemeRefresh, New System.EventArgs)

        Dim xDiag As New SaveFileDialog
        xDiag.Filter = Locale.FileType.THEME_XML & "|*.Theme.xml"
        xDiag.DefaultExt = "Theme.xml"
        xDiag.InitialDirectory = My.Application.Info.DirectoryPath & "\Data"
        If xDiag.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Me.SaveSettings(xDiag.FileName, True)
        If BeepWhileSaved Then Beep()
        TBThemeRefresh_Click(TBThemeRefresh, New System.EventArgs)
    End Sub

    Private Sub TBThemeRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBThemeRefresh.Click
        For xI1 As Integer = cmnTheme.Items.Count - 1 To 5 Step -1
            Try
                cmnTheme.Items.RemoveAt(xI1)
            Catch ex As Exception
            End Try
        Next

        If Not Directory.Exists(My.Application.Info.DirectoryPath & "\Data") Then My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Data")
        Dim xFileNames() As FileInfo = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Data").GetFiles("*.Theme.xml")
        For Each xStr As FileInfo In xFileNames
            cmnTheme.Items.Add(xStr.Name, Nothing, AddressOf LoadTheme)
        Next
    End Sub

    Private Sub LoadTheme(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Not File.Exists(My.Application.Info.DirectoryPath & "\Data\" & sender.Text) Then Exit Sub
        'SaveTheme = True
        'LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Theme\" & sender.Text, System.Text.Encoding.Unicode))
        LoadSettings(My.Application.Info.DirectoryPath & "\Data\" & sender.Text)
        RefreshPanelAll()
    End Sub

    Private Sub TBThemeLoadComptability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBThemeLoadComptability.Click
        Dim xDiag As New OpenFileDialog
        xDiag.Filter = Locale.FileType.TH & "|*.th"
        xDiag.DefaultExt = "th"
        xDiag.InitialDirectory = My.Application.Info.DirectoryPath
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Theme") Then xDiag.InitialDirectory = My.Application.Info.DirectoryPath & "\Theme"
        If xDiag.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Me.LoadThemeComptability(xDiag.FileName)
        RefreshPanelAll()
    End Sub

    ''' <summary>
    ''' Will return Double.PositiveInfinity if canceled.
    ''' </summary>
    Private Function InputBoxDouble(ByVal Prompt As String, ByVal LBound As Double, ByVal UBound As Double, Optional ByVal Title As String = "", Optional ByVal DefaultResponse As String = "") As Double
        Dim xStr As String = InputBox(Prompt, Title, DefaultResponse)
        If xStr = "" Then Return Double.PositiveInfinity

        InputBoxDouble = Val(xStr)
        If InputBoxDouble > UBound Then InputBoxDouble = UBound
        If InputBoxDouble < LBound Then InputBoxDouble = LBound
    End Function

    Private Sub FSSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSSS.Click
        Dim xMax As Double = IIf(vSelLength > 0, VPosition1000() - vSelLength, VPosition1000)
        Dim xMin As Double = IIf(vSelLength < 0, -vSelLength, 0)
        Dim xDouble As Double = InputBoxDouble("Please enter a number between " & xMin & " and " & xMax & ".", xMin, xMax, , vSelStart)
        If xDouble = Double.PositiveInfinity Then Return

        vSelStart = xDouble
        ValidateSelection()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub FSSL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSSL.Click
        Dim xMax As Double = VPosition1000() - vSelStart
        Dim xMin As Double = -vSelStart
        Dim xDouble As Double = InputBoxDouble("Please enter a number between " & xMin & " and " & xMax & ".", xMin, xMax, , vSelLength)
        If xDouble = Double.PositiveInfinity Then Return

        vSelLength = xDouble
        ValidateSelection()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub FSSH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSSH.Click
        Dim xMax As Double = IIf(vSelLength > 0, vSelLength, 0)
        Dim xMin As Double = IIf(vSelLength > 0, 0, -vSelLength)
        Dim xDouble As Double = InputBoxDouble("Please enter a number between " & xMin & " and " & xMax & ".", xMin, xMax, , vSelHalf)
        If xDouble = Double.PositiveInfinity Then Return

        vSelHalf = xDouble
        ValidateSelection()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub BVCReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVCReverse.Click
        vSelStart += vSelLength
        vSelHalf -= vSelLength
        vSelLength *= -1
        ValidateSelection()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub AutoSaveTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaveTimer.Tick
        Dim xTime As Date = Now
        Dim xFileName As String
        With xTime
            xFileName = My.Application.Info.DirectoryPath & "\AutoSave_" & _
                              .Year & "_" & .Month & "_" & .Day & "_" & .Hour & "_" & .Minute & "_" & .Second & "_" & .Millisecond & ".IBMSC"
        End With
        'My.Computer.FileSystem.WriteAllText(xFileName, SaveiBMSC, False, System.Text.Encoding.Unicode)
        SaveiBMSC(xFileName)

        On Error Resume Next
        If PreviousAutoSavedFileName <> "" Then IO.File.Delete(PreviousAutoSavedFileName)
        On Error GoTo 0

        PreviousAutoSavedFileName = xFileName
    End Sub

    Private Sub CWAVMultiSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CWAVMultiSelect.CheckedChanged
        WAVMultiSelect = CWAVMultiSelect.Checked
        LWAV.SelectionMode = IIf(WAVMultiSelect, SelectionMode.MultiExtended, SelectionMode.One)
    End Sub

    Private Sub CWAVChangeLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CWAVChangeLabel.CheckedChanged
        WAVChangeLabel = CWAVChangeLabel.Checked
    End Sub

    Private Sub BWAVUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWAVUp.Click
        If LWAV.SelectedIndex = -1 Then Return

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Dim xIndices(LWAV.SelectedIndices.Count - 1) As Integer
        LWAV.SelectedIndices.CopyTo(xIndices, 0)

        Dim xS As Integer
        For xS = 0 To 1294
            If Array.IndexOf(xIndices, xS) = -1 Then Exit For
        Next

        Dim xStr As String = ""
        Dim xIndex As Integer = -1
        For xI1 As Integer = xS To 1294
            xIndex = Array.IndexOf(xIndices, xI1)
            If xIndex <> -1 Then
                xStr = hWAV(xI1 + 1)
                hWAV(xI1 + 1) = hWAV(xI1)
                hWAV(xI1) = xStr

                LWAV.Items.Item(xI1) = C10to36(xI1 + 1) & ": " & hWAV(xI1 + 1)
                LWAV.Items.Item(xI1 - 1) = C10to36(xI1) & ": " & hWAV(xI1)

                If Not WAVChangeLabel Then GoTo 1100

                Dim xL1 As String = C10to36(xI1)
                Dim xL2 As String = C10to36(xI1 + 1)
                For xI2 As Integer = 1 To UBound(K)
                    If nNumericLabel(K(xI2).ColumnIndex) Then Continue For

                    If C10to36(K(xI2).Value \ 10000) = xL1 Then
                        Me.RedoRelabelNote(K(xI2), xI1 * 10000 + 10000, True, xUndo, xRedo)
                        K(xI2).Value = xI1 * 10000 + 10000

                    ElseIf C10to36(K(xI2).Value \ 10000) = xL2 Then
                        Me.RedoRelabelNote(K(xI2), xI1 * 10000, True, xUndo, xRedo)
                        K(xI2).Value = xI1 * 10000

                    End If
                Next

1100:           xIndices(xIndex) += -1
            End If
        Next

        LWAV.SelectedIndices.Clear()
        For xI1 As Integer = 0 To UBound(xIndices)
            LWAV.SelectedIndices.Add(xIndices(xI1))
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub BWAVDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWAVDown.Click
        If LWAV.SelectedIndex = -1 Then Return

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Dim xIndices(LWAV.SelectedIndices.Count - 1) As Integer
        LWAV.SelectedIndices.CopyTo(xIndices, 0)

        Dim xS As Integer
        For xS = 1294 To 0 Step -1
            If Array.IndexOf(xIndices, xS) = -1 Then Exit For
        Next

        Dim xStr As String = ""
        Dim xIndex As Integer = -1
        For xI1 As Integer = xS To 0 Step -1
            xIndex = Array.IndexOf(xIndices, xI1)
            If xIndex <> -1 Then
                xStr = hWAV(xI1 + 1)
                hWAV(xI1 + 1) = hWAV(xI1 + 2)
                hWAV(xI1 + 2) = xStr

                LWAV.Items.Item(xI1) = C10to36(xI1 + 1) & ": " & hWAV(xI1 + 1)
                LWAV.Items.Item(xI1 + 1) = C10to36(xI1 + 2) & ": " & hWAV(xI1 + 2)

                If Not WAVChangeLabel Then GoTo 1100

                Dim xL1 As String = C10to36(xI1 + 2)
                Dim xL2 As String = C10to36(xI1 + 1)
                For xI2 As Integer = 1 To UBound(K)
                    If nNumericLabel(K(xI2).ColumnIndex) Then Continue For

                    If C10to36(K(xI2).Value \ 10000) = xL1 Then
                        Me.RedoRelabelNote(K(xI2), xI1 * 10000 + 10000, True, xUndo, xRedo)
                        K(xI2).Value = xI1 * 10000 + 10000

                    ElseIf C10to36(K(xI2).Value \ 10000) = xL2 Then
                        Me.RedoRelabelNote(K(xI2), xI1 * 10000 + 20000, True, xUndo, xRedo)
                        K(xI2).Value = xI1 * 10000 + 20000

                    End If
                Next

1100:           xIndices(xIndex) += 1
            End If
        Next

        LWAV.SelectedIndices.Clear()
        For xI1 As Integer = 0 To UBound(xIndices)
            LWAV.SelectedIndices.Add(xIndices(xI1))
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub BWAVBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWAVBrowse.Click
        Dim xDWAV As New OpenFileDialog
        xDWAV.DefaultExt = "wav"
        xDWAV.Filter = Locale.FileType._wave & "|*.wav;*.ogg;*.mp3|" & _
                       Locale.FileType.WAV & "|*.wav|" & _
                       Locale.FileType.OGG & "|*.ogg|" & _
                       Locale.FileType.MP3 & "|*.mp3|" & _
                       Locale.FileType._all & "|*.*"
        xDWAV.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))
        xDWAV.Multiselect = WAVMultiSelect

        If xDWAV.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDWAV.FileName)

        AddToPOWAV(xDWAV.FileNames)
    End Sub

    Private Sub BWAVRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWAVRemove.Click
        Dim xIndices(LWAV.SelectedIndices.Count - 1) As Integer
        LWAV.SelectedIndices.CopyTo(xIndices, 0)
        For xI1 As Integer = 0 To UBound(xIndices)
            hWAV(xIndices(xI1) + 1) = ""
            LWAV.Items.Item(xIndices(xI1)) = C10to36(xIndices(xI1) + 1) & ": "
        Next

        LWAV.SelectedIndices.Clear()
        For xI1 As Integer = 0 To UBound(xIndices)
            LWAV.SelectedIndices.Add(xIndices(xI1))
        Next

        If IsSaved Then SetIsSaved(False)
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub mnMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mnMain.MouseDown ', TBMain.MouseDown  ', pttl.MouseDown, pIsSaved.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, &H112, &HF012, 0)
            If e.Clicks = 2 Then
                If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal Else Me.WindowState = FormWindowState.Maximized
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            mnSys.Show(sender, e.Location)
        End If
    End Sub

    Private Sub mnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSelectAll.Click
        If Not (PMainIn.Focused OrElse PMainInL.Focused Or PMainInR.Focused) Then Exit Sub
        For xI1 As Integer = 1 To UBound(K)
            K(xI1).Selected = nEnabled(K(xI1).ColumnIndex)
        Next
        If TBTimeSelect.Checked Then
            CalculateGreatestVPosition()
            vSelStart = 0
            vSelLength = MeasureBottom(InMeasure(GreatestVPosition)) + MeasureLength(InMeasure(GreatestVPosition))
        End If
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub mnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnDelete.Click
        If Not (PMainIn.Focused OrElse PMainInL.Focused Or PMainInR.Focused) Then Exit Sub

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Me.RedoRemoveNoteSelected(True, xUndo, xRedo)
        RemoveNotes(True)

        AddUndo(xUndo, xBaseRedo.Next)
        CalculateGreatestVPosition()
        CalculateTotalNotes()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub mnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnUpdate.Click
        System.Diagnostics.Process.Start("http://www.cs.mcgill.ca/~ryang6/iBMSC/")
    End Sub

    Private Sub mnUpdateC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnUpdateC.Click
        System.Diagnostics.Process.Start("http://bbs.rohome.net/thread-1074065-1-1.html")
    End Sub

    Private Sub mnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnQuit.Click
        Me.Close()
    End Sub

    'Private Sub ttlCls_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlCls.Image = My.Resources.tCls2
    'End Sub
    'Private Sub ttlCls_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlCls.Image = My.Resources.tCls
    'End Sub
    'Private Sub ttlRst_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlRst.Image = My.Resources.tRst2
    'End Sub
    'Private Sub ttlRst_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlRst.Image = My.Resources.tRst
    'End Sub
    'Private Sub ttlMax_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlMax.Image = My.Resources.tMax2
    'End Sub
    'Private Sub ttlMax_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlMax.Image = My.Resources.tMax
    'End Sub
    'Private Sub ttlMin_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlMin.Image = My.Resources.tMin2
    'End Sub
    'Private Sub ttlMin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ttlMin.Image = My.Resources.tMin
    'End Sub

    'Private Sub ttlCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Close()
    'End Sub
    'Private Sub ttlRst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.WindowState = FormWindowState.Normal
    'End Sub
    'Private Sub ttlMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.WindowState = FormWindowState.Maximized
    'End Sub
    'Private Sub ttlMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.WindowState = FormWindowState.Minimized
    'End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'ttlMax.Visible = Me.WindowState <> FormWindowState.Maximized
        'ttlRst.Visible = Me.WindowState = FormWindowState.Maximized
        'sysMax.Enabled = Me.WindowState <> FormWindowState.Maximized
        'sysRst.Enabled = Me.WindowState = FormWindowState.Maximized
        'ControlVisibleChanged(Nothing, Nothing)

        'Me.ShowCaption = Me.WindowState = FormWindowState.Maximized
    End Sub

    'Private Sub ControlVisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FStatus.VisibleChanged, pStatus.VisibleChanged, TBMain.VisibleChanged
    '    Dim xBottom As Integer = 0
    '    If FStatus.Visible And pStatus.Visible Then xBottom = FStatus.Height
    '    Dim xTop As Integer = mnMain.Height + 1
    '    If TBMain.Visible Then xTop += TBMain.Height
    '    'DwmExtendFrameIntoClientArea(Me.Handle, NewMargin(0, 0, xTop, xBottom))
    'End Sub

    Private Sub EnableDWM()
        mnMain.BackColor = Color.Black
        'TBMain.BackColor = Color.FromArgb(64, 64, 64)

        For Each xmn As ToolStripMenuItem In mnMain.Items
            xmn.ForeColor = Color.White
            AddHandler xmn.DropDownClosed, AddressOf mn_DropDownClosed
            AddHandler xmn.DropDownOpened, AddressOf mn_DropDownOpened
            AddHandler xmn.MouseEnter, AddressOf mn_MouseEnter
            AddHandler xmn.MouseLeave, AddressOf mn_MouseLeave
        Next
    End Sub

    Private Sub DisableDWM()
        mnMain.BackColor = SystemColors.Control
        'TBMain.BackColor = SystemColors.Control

        For Each xmn As ToolStripMenuItem In mnMain.Items
            xmn.ForeColor = SystemColors.ControlText
            RemoveHandler xmn.DropDownClosed, AddressOf mn_DropDownClosed
            RemoveHandler xmn.DropDownOpened, AddressOf mn_DropDownOpened
            RemoveHandler xmn.MouseEnter, AddressOf mn_MouseEnter
            RemoveHandler xmn.MouseLeave, AddressOf mn_MouseLeave
        Next
    End Sub

    'Private Sub pttl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pttl.Paint
    '    e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
    '    'If Not IsSaved Then e.Graphics.DrawPath(New Pen(Color.Black, 2), TitlePath)
    '    e.Graphics.DrawPath(Pens.Gray, TitlePath)
    '    e.Graphics.FillPath(Brushes.White, TitlePath)
    'End Sub

    Private Sub ttlIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ttlIcon.MouseDown
        ttlIcon.Image = My.Resources.icon2_16
        mnSys.Show(ttlIcon, 0, ttlIcon.Height)
    End Sub
    Private Sub ttlIcon_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttlIcon.MouseEnter
        ttlIcon.Image = My.Resources.icon2_16_highlight
    End Sub
    Private Sub ttlIcon_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ttlIcon.MouseLeave
        ttlIcon.Image = My.Resources.icon2_16
    End Sub

    Private Sub mnSMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSMenu.CheckedChanged
        mnMain.Visible = mnSMenu.Checked
    End Sub
    Private Sub mnSTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSTB.CheckedChanged
        TBMain.Visible = mnSTB.Checked
    End Sub
    Private Sub mnSOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSOP.CheckedChanged
        POptions.Visible = mnSOP.Checked
    End Sub
    Private Sub mnSStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSStatus.CheckedChanged
        pStatus.Visible = mnSStatus.Checked
    End Sub
    Private Sub mnSLSplitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSLSplitter.CheckedChanged
        SpL.Visible = mnSLSplitter.Checked
    End Sub
    Private Sub mnSRSplitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSRSplitter.CheckedChanged
        SpR.Visible = mnSRSplitter.Checked
    End Sub
    Private Sub CGShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShow.CheckedChanged
        gShow = CGShow.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowS.CheckedChanged
        gShowS = CGShowS.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowBG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowBG.CheckedChanged
        gShowBG = CGShowBG.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowM.CheckedChanged
        gShowM = CGShowM.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowV.CheckedChanged
        gShowV = CGShowV.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowMB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowMB.CheckedChanged
        gShowMB = CGShowMB.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGShowC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGShowC.CheckedChanged
        gShowC = CGShowC.Checked
        RefreshPanelAll()
    End Sub
    Private Sub CGBLP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGBLP.CheckedChanged
        'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        'Dim xRedo As UndoRedo.LinkedURCmd = Nothing
        'Me.RedoChangeVisibleColumns(gBLP, gSTOP, iPlayer, CGBLP.Checked, gSTOP, iPlayer, xUndo, xRedo)
        gBLP = CGBLP.Checked

        col(niBGA).isVisible = gBLP
        col(niLAYER).isVisible = gBLP
        col(niPOOR).isVisible = gBLP
        col(niS4).isVisible = gBLP

        If IsInitializing Then Exit Sub
        For xI1 As Integer = 1 To UBound(K)
            K(xI1).Selected = K(xI1).Selected And nEnabled(K(xI1).ColumnIndex)
        Next
        'AddUndo(xUndo, xRedo)
        UpdateKLeft()
        RefreshPanelAll()
    End Sub
    Private Sub CGSTOP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGSTOP.CheckedChanged
        'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        'Dim xRedo As UndoRedo.LinkedURCmd = Nothing
        'Me.RedoChangeVisibleColumns(gBLP, gSTOP, iPlayer, gBLP, CGSTOP.Checked, iPlayer, xUndo, xRedo)
        gSTOP = CGSTOP.Checked

        col(niSTOP).isVisible = gSTOP

        If IsInitializing Then Exit Sub
        For xI1 As Integer = 1 To UBound(K)
            K(xI1).Selected = K(xI1).Selected And nEnabled(K(xI1).ColumnIndex)
        Next
        'AddUndo(xUndo, xRedo)
        UpdateKLeft()
        RefreshPanelAll()
    End Sub
    Private Sub CGBPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGBPM.CheckedChanged
        'Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        'Dim xRedo As UndoRedo.LinkedURCmd = Nothing
        'Me.RedoChangeVisibleColumns(gBLP, gSTOP, iPlayer, gBLP, CGSTOP.Checked, iPlayer, xUndo, xRedo)
        gBPM = CGBPM.Checked

        col(niBPM).isVisible = gBPM

        If IsInitializing Then Exit Sub
        For xI1 As Integer = 1 To UBound(K)
            K(xI1).Selected = K(xI1).Selected And nEnabled(K(xI1).ColumnIndex)
        Next
        'AddUndo(xUndo, xRedo)
        UpdateKLeft()
        RefreshPanelAll()
    End Sub

    Private Sub CGDisableVertical_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGDisableVertical.CheckedChanged
        DisableVerticalMove = CGDisableVertical.Checked
    End Sub

    'Private Sub BWAVOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BWAVOptions.Click
    '    mnWAV.Show(BWAVOptions, 0, 24)
    'End Sub
    'Private Sub BBeatOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBeatOptions.Click
    '    mnBeat.Show(BBeatOptions, 0, 24)
    'End Sub

    Private Sub CBeatPreserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBeatPreserve.Click, CBeatMeasure.Click, CBeatCut.Click, CBeatScale.Click
        'If Not sender.Checked Then Exit Sub
        Dim xBeatList() As RadioButton = {CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale}
        BeatChangeMode = Array.IndexOf(Of RadioButton)(xBeatList, sender)
        'For xI1 As Integer = 0 To mnBeat.Items.Count - 1
        'If xI1 <> BeatChangeMode Then CType(mnBeat.Items(xI1), ToolStripMenuItem).Checked = False
        'Next
        'sender.Checked = True
    End Sub

    'Private Function ValidateBeat(ByVal xValue As Double) As Double
    '    Dim xTemp As Double = CDbl(CInt(xValue * 64.0R)) / 64.0R
    '    If xTemp > 16.0R Then xTemp = 16.0R
    '    If xTemp < 0.015625 Then xTemp = 0.015625
    '    Return xTemp
    'End Function

    'Private Function FloatToFraction64(ByVal xFloat As Double) As String
    '    Dim xTemp As Integer = ValidateBeat(xFloat) * 64
    '    Dim xGCD As Integer = GCD(xTemp, 64.0#)
    '    Dim xxD As Integer = 64.0# / xGCD
    '    Dim xxN As Integer = xTemp * xxD
    '    Return xxN & "/" & xxD
    'End Function

    Private Sub tBeatValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tBeatValue.LostFocus
        Dim a As Double = Val(tBeatValue.Text)
        If a <= 0.0# Or a >= 1000.0# Then tBeatValue.BackColor = Color.FromArgb(&HFFFFC0C0) Else tBeatValue.BackColor = Nothing

        tBeatValue.Text = a
        'Dim xDenom As Long = GetDenominator(a, 10000)
        'tBeatValue.Text = CLng(a * xDenom) / xDenom
    End Sub

    Private Function GetDenominator(ByVal a As Double, Optional ByVal maxDenom As Long = &H7FFFFFFF) As Long
        Dim m00 As Long = 1
        Dim m01 As Long = 0
        Dim m10 As Long = 0
        Dim m11 As Long = 1
        Dim x As Double = a
        Dim ai As Long = Int(x)

        Do While m10 * ai + m11 <= maxDenom
            Dim t As Long
            t = m00 * ai + m01
            m01 = m00
            m00 = t
            t = m10 * ai + m11
            m11 = m10
            m10 = t

            If x = CDbl(ai) Then Exit Do
            x = 1 / (x - ai)

            If x > CDbl(&H7FFFFFFFFFFFFFFF) Then Exit Do
            ai = Int(x)
        Loop

        Return m10
    End Function

    Private Sub ApplyBeat(ByVal xRatio As Double, ByVal xDisplay As String)
        SortByVPositionInsertion()

        Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        Dim xRedo As UndoRedo.LinkedURCmd = New UndoRedo.Void
        Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo

        Me.RedoChangeMeasureLengthSelected(192 * xRatio, xUndo, xRedo)

        Dim xIndices(LBeat.SelectedIndices.Count - 1) As Integer
        LBeat.SelectedIndices.CopyTo(xIndices, 0)

        'Dim xUndo As String = ""
        'Dim xMLen(-1) As Double
        'Dim xMCmd(-1) As String
        'For Each xI1 As Integer In xIndices
        'Dim xI As Integer = Array.IndexOf(xMLen, MeasureLength(xI1))
        'If xI = -1 Then
        'ReDim Preserve xMLen(UBound(xMLen) + 1)
        'ReDim Preserve xMCmd(UBound(xMCmd) + 1)
        'xMLen(UBound(xMLen)) = MeasureLength(xI1)
        'xMCmd(UBound(xMCmd)) = "CB_" & MeasureLength(xI1) & "_" & xI1
        'Else
        'xMCmd(xI) &= "_" & xI1
        'End If
        'Next
        'xUndo = Join(xMCmd, vbCrLf)
        '
        'Dim xRedo As String = "CB_" & (192 * xxRatio)
        'Dim xMCmdR(UBound(xIndices)) As String
        'For Each xI1 As Integer In xIndices
        'xRedo &= "_" & xI1
        'Next

        'Dim xUndo2 As String = ""
        'Dim xRedo2 As String = ""

        For Each xI1 As Integer In xIndices
            Dim dLength As Double = xRatio * 192.0R - MeasureLength(xI1)
            Dim dRatio As Double = xRatio * 192.0R / MeasureLength(xI1)

            Dim xBottom As Double = 0
            For xI2 As Integer = 0 To xI1 - 1
                xBottom += MeasureLength(xI2)
            Next
            Dim xUpBefore As Double = xBottom + MeasureLength(xI1)
            Dim xUpAfter As Double = xUpBefore + dLength

            Select Case BeatChangeMode
                Case 1
case2:              Dim xI0 As Integer

                    If NTInput Then
                        For xI0 = 1 To UBound(K)
                            If K(xI0).VPosition >= xUpBefore Then Exit For
                            If K(xI0).VPosition + K(xI0).Length >= xUpBefore Then
                                Me.RedoLongNoteModify(K(xI0), K(xI0).VPosition, K(xI0).Length + dLength, False, xUndo, xRedo)
                                K(xI0).Length += dLength
                            End If
                        Next
                    Else
                        For xI0 = 1 To UBound(K)
                            If K(xI0).VPosition >= xUpBefore Then Exit For
                        Next
                    End If

                    For xI9 As Integer = xI0 To UBound(K)
                        Me.RedoLongNoteModify(K(xI9), K(xI9).VPosition + dLength, K(xI9).Length, False, xUndo, xRedo)
                        K(xI9).VPosition += dLength
                    Next

                Case 2
                    If dLength < 0 Then
                        If NTInput Then
                            Dim xI0 As Integer = 1
                            Dim xU As Integer = UBound(K)
                            Do While xI0 <= xU
                                If K(xI0).VPosition < xUpAfter Then
                                    If K(xI0).VPosition + K(xI0).Length >= xUpAfter And K(xI0).VPosition + K(xI0).Length < xUpBefore Then
                                        Dim nLen As Double = xUpAfter - K(xI0).VPosition - 1.0R
                                        Me.RedoLongNoteModify(K(xI0), K(xI0).VPosition, nLen, False, xUndo, xRedo)
                                        K(xI0).Length = nLen
                                    End If
                                ElseIf K(xI0).VPosition < xUpBefore Then
                                    If K(xI0).VPosition + K(xI0).Length < xUpBefore Then
                                        Me.RedoRemoveNote(K(xI0), False, xUndo, xRedo)
                                        RemoveNote(xI0)
                                        xI0 -= 1
                                        xU -= 1
                                    Else
                                        Dim nLen As Double = K(xI0).Length - xUpBefore + K(xI0).VPosition
                                        Me.RedoLongNoteModify(K(xI0), xUpBefore, nLen, False, xUndo, xRedo)
                                        K(xI0).Length = nLen
                                        K(xI0).VPosition = xUpBefore
                                    End If
                                End If
                                xI0 += 1
                            Loop
                        Else
                            Dim xI0 As Integer
                            Dim xI9 As Integer
                            For xI0 = 1 To UBound(K)
                                If K(xI0).VPosition >= xUpAfter Then Exit For
                            Next
                            For xI9 = xI0 To UBound(K)
                                If K(xI9).VPosition >= xUpBefore Then Exit For
                            Next

                            For xI8 As Integer = xI0 To xI9 - 1
                                Me.RedoRemoveNote(K(xI8), False, xUndo, xRedo)
                            Next
                            For xI8 As Integer = xI9 To UBound(K)
                                K(xI8 - xI9 + xI0) = K(xI8)
                            Next
                            ReDim Preserve K(UBound(K) - xI9 + xI0)
                        End If
                    End If

                    GoTo case2

                Case 3
                    If NTInput Then
                        For xI0 As Integer = 1 To UBound(K)
                            If K(xI0).VPosition < xBottom Then
                                If K(xI0).VPosition + K(xI0).Length > xUpBefore Then
                                    Me.RedoLongNoteModify(K(xI0), K(xI0).VPosition, K(xI0).Length + dLength, False, xUndo, xRedo)
                                    K(xI0).Length += dLength
                                ElseIf K(xI0).VPosition + K(xI0).Length > xBottom Then
                                    Dim nLen As Double = (K(xI0).Length + K(xI0).VPosition - xBottom) * dRatio + xBottom - K(xI0).VPosition
                                    Me.RedoLongNoteModify(K(xI0), K(xI0).VPosition, nLen, False, xUndo, xRedo)
                                    K(xI0).Length = nLen
                                End If
                            ElseIf K(xI0).VPosition < xUpBefore Then
                                If K(xI0).VPosition + K(xI0).Length > xUpBefore Then
                                    Dim nLen As Double = (xUpBefore - K(xI0).VPosition) * dRatio + K(xI0).VPosition + K(xI0).Length - xUpBefore
                                    Dim nVPos As Double = (K(xI0).VPosition - xBottom) * dRatio + xBottom
                                    Me.RedoLongNoteModify(K(xI0), nVPos, nLen, False, xUndo, xRedo)
                                    K(xI0).Length = nLen
                                    K(xI0).VPosition = nVPos
                                Else
                                    Dim nLen As Double = K(xI0).Length * dRatio
                                    Dim nVPos As Double = (K(xI0).VPosition - xBottom) * dRatio + xBottom
                                    Me.RedoLongNoteModify(K(xI0), nVPos, nLen, False, xUndo, xRedo)
                                    K(xI0).Length = nLen
                                    K(xI0).VPosition = nVPos
                                End If
                            Else
                                Me.RedoLongNoteModify(K(xI0), K(xI0).VPosition + dLength, K(xI0).Length, False, xUndo, xRedo)
                                K(xI0).VPosition += dLength
                            End If
                        Next
                    Else
                        Dim xI0 As Integer
                        Dim xI9 As Integer
                        For xI0 = 1 To UBound(K)
                            If K(xI0).VPosition >= xBottom Then Exit For
                        Next
                        For xI9 = xI0 To UBound(K)
                            If K(xI9).VPosition >= xUpBefore Then Exit For
                        Next

                        For xI8 As Integer = xI0 To xI9 - 1
                            Dim nVP As Double = (K(xI8).VPosition - xBottom) * dRatio + xBottom
                            Me.RedoLongNoteModify(K(xI0), nVP, K(xI0).Length, False, xUndo, xRedo)
                            K(xI8).VPosition = nVP
                        Next

                        'GoTo case2

                        For xI8 As Integer = xI9 To UBound(K)
                            Me.RedoLongNoteModify(K(xI8), K(xI8).VPosition + dLength, K(xI8).Length, False, xUndo, xRedo)
                            K(xI8).VPosition += dLength
                        Next
                    End If

            End Select

            MeasureLength(xI1) = xRatio * 192.0R
            LBeat.Items(xI1) = Add3Zeros(xI1) & ": " & xDisplay
        Next
        UpdateMeasureBottom()
        'xUndo &= vbCrLf & xUndo2
        'xRedo &= vbCrLf & xRedo2

        LBeat.SelectedIndices.Clear()
        For xI1 As Integer = 0 To UBound(xIndices)
            LBeat.SelectedIndices.Add(xIndices(xI1))
        Next

        AddUndo(xUndo, xBaseRedo.Next)
        SortByVPositionInsertion()
        UpdatePairing()
        CalculateTotalNotes()
        CalculateGreatestVPosition()
        RefreshPanelAll()
        POStatusRefresh()
    End Sub

    Private Sub BBeatApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBeatApply.Click
        Dim xxD As Integer = nBeatD.Value
        Dim xxN As Integer = nBeatN.Value
        Dim xxRatio As Double = xxN / xxD

        ApplyBeat(xxRatio, xxRatio & " ( " & xxN & " / " & xxD & " ) ")
    End Sub

    Private Sub BBeatApplyV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBeatApplyV.Click
        Dim a As Double = Val(tBeatValue.Text)
        If a <= 0.0# Or a >= 1000.0# Then System.Media.SystemSounds.Hand.Play() : Exit Sub

        Dim xxD As Long = Me.GetDenominator(a)

        ApplyBeat(a, a & IIf(xxD > 10000, "", " ( " & CLng(a * xxD) & " / " & xxD & " ) "))
    End Sub

    'Private Sub nBeatD_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nBeatD.SelectedItemChanged
    '    nBeatN.Maximum = Val(nBeatD.Text) * 16
    'End Sub

    'Private Sub CAdLNTYPE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CAdLNTYPEb.Enabled = CAdLNTYPE.Checked
    'End Sub

    'Dim TempFreezeMenu As Boolean = False

    'Private Sub Menu1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles Menu1.Closing
    '    e.Cancel = TempFreezeMenu
    'End Sub

    'Private Sub Menu1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu1.Opened
    '    TempFreezeMenu = True
    'End Sub

    'Private Sub mnSys_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnSys.Opened
    '    TempFreezeMenu = False
    'End Sub

    'Private Sub mnSys_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles mnSys.Closing
    '    If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then e.Cancel = True
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    changeFont(Me.Controls, "impact")
    'End Sub

    'Private Sub changeFont(ByVal ctrCol As ControlCollection, ByVal f As String)
    '    On Error Resume Next
    '    For Each ftr As Control In ctrCol
    '        If ftr.Font.Name = "Segoe UI" Then ftr.Font = New Font(f, ftr.Font.Size)
    '        changeFont(ftr.Controls, f)
    '    Next
    'End Sub

    Private Sub BHStageFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHStageFile.Click, BHBanner.Click, BHBackBMP.Click
        Dim xDiag As New OpenFileDialog
        xDiag.Filter = Locale.FileType._image & "|*.bmp;*.png;*.jpg;*.gif|" & _
                       Locale.FileType._all & "|*.*"
        xDiag.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))
        xDiag.DefaultExt = "png"

        If xDiag.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        InitPath = ExcludeFileName(xDiag.FileName)

        If [Object].ReferenceEquals(sender, BHStageFile) Then
            THStageFile.Text = GetFileName(xDiag.FileName)
        ElseIf [Object].ReferenceEquals(sender, BHBanner) Then
            THBanner.Text = GetFileName(xDiag.FileName)
        ElseIf [Object].ReferenceEquals(sender, BHBackBMP) Then
            THBackBMP.Text = GetFileName(xDiag.FileName)
        End If
    End Sub

    'Private Sub BHMidiFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim xDiag As New OpenFileDialog
    '    xDiag.Filter = Locale.FileType.MID & "|*.mid|" & _
    '                   Locale.FileType._all & "|*.*"
    '    xDiag.InitialDirectory = IIf(ExcludeFileName(FileName) = "", InitPath, ExcludeFileName(FileName))
    '    xDiag.DefaultExt = "mid"
    '
    '    If xDiag.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
    '    InitPath = ExcludeFileName(xDiag.FileName)
    '
    '    THMidiFile.Text = GetFileName(xDiag.FileName)
    'End Sub

    Private Sub Switches_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    POHeaderSwitch.CheckedChanged, _
    POGridSwitch.CheckedChanged, _
    POWaveFormSwitch.CheckedChanged, _
    POWAVSwitch.CheckedChanged, _
    POBeatSwitch.CheckedChanged, _
    POExpansionSwitch.CheckedChanged

        Try
            Dim Source As CheckBox = CType(sender, CheckBox)
            Dim Target As Panel = Nothing

            If Object.ReferenceEquals(sender, Nothing) Then : Exit Sub
            ElseIf Object.ReferenceEquals(sender, POHeaderSwitch) Then : Target = POHeaderInner
            ElseIf Object.ReferenceEquals(sender, POGridSwitch) Then : Target = POGridInner
            ElseIf Object.ReferenceEquals(sender, POWaveFormSwitch) Then : Target = POWaveFormInner
            ElseIf Object.ReferenceEquals(sender, POWAVSwitch) Then : Target = POWAVInner
            ElseIf Object.ReferenceEquals(sender, POBeatSwitch) Then : Target = POBeatInner
            ElseIf Object.ReferenceEquals(sender, POExpansionSwitch) Then : Target = POExpansionInner
            End If

            If Source.Checked Then
                Target.Visible = True
            Else
                Target.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Expanders_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    POHeaderExpander.CheckedChanged, _
    POGridExpander.CheckedChanged, _
    POWaveFormExpander.CheckedChanged, _
    POWAVExpander.CheckedChanged, _
    POBeatExpander.CheckedChanged

        Try
            Dim Source As CheckBox = CType(sender, CheckBox)
            Dim Target As Panel = Nothing
            'Dim TargetParent As Panel = Nothing

            If Object.ReferenceEquals(sender, Nothing) Then : Exit Sub
            ElseIf Object.ReferenceEquals(sender, POHeaderExpander) Then : Target = POHeaderPart2 ' : TargetParent = POHeaderInner
            ElseIf Object.ReferenceEquals(sender, POGridExpander) Then : Target = POGridPart2 ' : TargetParent = POGridInner
            ElseIf Object.ReferenceEquals(sender, POWaveFormExpander) Then : Target = POWaveFormPart2 ' : TargetParent = POWaveFormInner
            ElseIf Object.ReferenceEquals(sender, POWAVExpander) Then : Target = POWAVPart2 ' : TargetParent = POWaveFormInner
            ElseIf Object.ReferenceEquals(sender, POBeatExpander) Then : Target = POBeatPart2 ' : TargetParent = POWaveFormInner
            End If

            If Source.Checked Then
                Target.Visible = True
                Source.Image = My.Resources.Collapse
            Else
                Target.Visible = False
                Source.Image = My.Resources.Expand
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub VerticalResizer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles POWAVResizer.MouseDown, POBeatResizer.MouseDown, POExpansionResizer.MouseDown
        tempResize = e.Y
    End Sub

    Private Sub HorizontalResizer_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles POptionsResizer.MouseDown, SpL.MouseDown, SpR.MouseDown
        tempResize = e.X
    End Sub

    Private Sub POResizer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles POWAVResizer.MouseMove, POBeatResizer.MouseMove, POExpansionResizer.MouseMove
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        If e.Y = tempResize Then Exit Sub

        Try
            Dim Source As Button = CType(sender, Button)
            Dim Target As Panel = Source.Parent

            Dim xHeight As Integer = Target.Height + e.Y - tempResize
            If xHeight < 10 Then xHeight = 10
            Target.Height = xHeight

            Target.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub POptionsResizer_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles POptionsResizer.MouseMove
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        If e.X = tempResize Then Exit Sub

        Try
            Dim xWidth As Integer = POptionsScroll.Width - e.X + tempResize
            If xWidth < 25 Then xWidth = 25
            POptionsScroll.Width = xWidth

            Me.Refresh()
            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SpR_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpR.MouseMove
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        If e.X = tempResize Then Exit Sub

        Try
            Dim xWidth As Integer = PMainR.Width - e.X + tempResize
            If xWidth < 0 Then xWidth = 0
            PMainR.Width = xWidth

            Me.ToolStripContainer1.Refresh()
            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SpL_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpL.MouseMove
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        If e.X = tempResize Then Exit Sub

        Try
            Dim xWidth As Integer = PMainL.Width + e.X - tempResize
            If xWidth < 0 Then xWidth = 0
            PMainL.Width = xWidth

            Me.ToolStripContainer1.Refresh()
            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub
End Class
