Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class UIDataBlock
    Private blockRectangle As Rectangle
    Private incomingRelations As List(Of Integer)
    Private outgoingRelations As List(Of Integer)
    Public Sub New(ByVal location As Point)
        Const rectangleHeight As Integer = 76, rectangleWith As Integer = 114
        blockRectangle = New Rectangle(location.X + CInt(0.5 * rectangleWith), location.Y + CInt(0.5 * rectangleHeight), rectangleWith, rectangleHeight)
    End Sub
    ReadOnly Property DataBlockRectangle As Rectangle
        Get
            Return blockRectangle
        End Get
    End Property
    ReadOnly Property RelationsIn As List(Of Integer)
        Get
            Return incomingRelations
        End Get
    End Property
    ReadOnly Property RelationsOut As List(Of Integer)
        Get
            Return outgoingRelations
        End Get
    End Property
    Public Sub MoveRectangle(ByVal x As Integer, ByVal y As Integer)
        blockRectangle.Offset(x, y)
    End Sub
    Public Sub AddRelationIn(ByVal index As Integer)
        incomingRelations.Add(index)
    End Sub
    Public Sub AddRelationOut(ByVal index As Integer)
        outgoingRelations.Add(index)
    End Sub
    Public Sub RemoveRelation(ByVal index As Integer)
        outgoingRelations.RemoveAt(index)
    End Sub
End Class
