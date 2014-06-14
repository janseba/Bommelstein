Imports System.Drawing.Drawing2D
Imports System.Drawing
Public Class UIRelation
    Private path As GraphicsPath
    Private border As Rectangle
    Private startBlockIndex As Integer
    Private endBlockIndex As Integer

    Public Sub New(ByVal startPoint As Point, ByVal endPoint As Point)
        path = New GraphicsPath
        path.AddLine(startPoint, endPoint)
        SetRelationBorder(path)
    End Sub
    ReadOnly Property RelationPath As GraphicsPath
        Get
            Return path
        End Get
    End Property
    ReadOnly Property RelationBorder As Rectangle
        Get
            Return border
        End Get
    End Property
    Property StartDataBlockIndex As Integer
        Get
            Return startBlockIndex
        End Get
        Set(value As Integer)
            startBlockIndex = value
        End Set
    End Property
    Property EndDataBlockIndex As Integer
        Get
            Return endBlockIndex
        End Get
        Set(value As Integer)
            endBlockIndex = value
        End Set
    End Property
    Private Sub SetRelationBorder(ByVal path As GraphicsPath)
        border = New Rectangle(CInt(path.GetBounds.X), CInt(path.GetBounds.Y), CInt(path.GetBounds.Width), CInt(path.GetBounds.Height))
        border.Inflate(3, 3)
    End Sub
    Public Sub SetRelationPath(ByVal startPoint As Point, ByVal endPoint As Point)
        path = New GraphicsPath
        path.AddLine(startPoint, endPoint)
        SetRelationBorder(path)
    End Sub
    Public Function IsVisible(ByVal location As Point) As Boolean
        Dim selectionPen As Pen = New Pen(Color.Black, 10)
        Return Me.RelationPath.IsOutlineVisible(location, selectionPen)
    End Function

End Class
