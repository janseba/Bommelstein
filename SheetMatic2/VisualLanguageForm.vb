Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows

Public Class VisualLanguageForm

    Private Enum editMode
        selectMode = 0
        dataBlockMode = 1
        relationMode = 2
    End Enum
    Private Structure relationPoints
        Dim startPoint As Point
        Dim endPoint As Point
    End Structure

    Private StartPoint As Point
    Private endPoint As Point
    Private modelObjects As New List(Of Object)
    Private mode As editMode = editMode.selectMode
    Private selectedDataBlockIndex As Integer
    Private startDataBlockIndex As Integer
    Private endDataBlockIndex As Integer
    Private selectedRelationIndex As Integer
    Private selectedObject As Integer


    Private Sub DrawingPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso Control.MouseButtons = Windows.Forms.MouseButtons.None Then
            Dim location As Point = e.Location
            Me.selectedDataBlockIndex = Me.GetDataBlockIndexAtPoint(location)
            Me.selectedRelationIndex = Me.GetRelationIndexAtPoint(location)
            selectedRelationLabel.Text = CStr(Me.selectedRelationIndex)
            If Me.selectedDataBlockIndex <> -1 Or Me.selectedRelationIndex <> -1 Then
                Me.CanvasContextMenuStrip.Show(Me.DrawingPictureBox, location)
            End If
        End If
    End Sub

    Private Sub DrawingPictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.StartPoint = e.Location
            Me.endPoint = e.Location
            If Me.mode = editMode.dataBlockMode Then
                Dim dataBlock As UIDataBlock = New UIDataBlock(Me.StartPoint)
                Me.modelObjects.Add(dataBlock)
                Me.DrawingPictureBox.Invalidate(dataBlock.blockBorder)
                Me.DrawingPictureBox.Update()
            ElseIf Me.mode = editMode.selectMode Then
                Me.selectedDataBlockIndex = Me.GetDataBlockIndexAtPoint(e.Location)
            ElseIf Me.mode = editMode.relationMode Then
                Me.startDataBlockIndex = Me.GetDataBlockIndexAtPoint(e.Location)
            End If
        End If
    End Sub

    Private Sub DrawingPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseMove
        xLabel.Text = CStr(e.Location.X)
        yLabel.Text = CStr(e.Location.Y)
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            If Me.mode = editMode.selectMode Then
                If Me.selectedDataBlockIndex <> -1 Then
                    If Me.modelObjects(Me.selectedDataBlockIndex).GetType Is GetType(UIDataBlock) Then
                        Dim dataBlock As UIDataBlock = CType(Me.modelObjects(Me.selectedDataBlockIndex), UIDataBlock)
                        Dim location As Point = e.Location
                        Me.DrawingPictureBox.Invalidate(dataBlock.blockBorder)
                        dataBlock.MoveRectangle(location.X - Me.StartPoint.X, location.Y - Me.StartPoint.Y)
                        Me.modelObjects(Me.selectedDataBlockIndex) = dataBlock
                        Me.StartPoint = location
                        Me.DrawingPictureBox.Invalidate(dataBlock.blockBorder)
                        Me.DrawingPictureBox.Update()
                    End If
                End If
            ElseIf Me.mode = editMode.relationMode Then
                Dim relation As New UIRelation(Me.StartPoint, Me.endPoint)
                Me.DrawingPictureBox.Invalidate(relation.RelationBorder)
                Me.endPoint = e.Location
                Me.DrawingPictureBox.Update()
            End If
        End If
    End Sub

    Private Sub DrawingPictureBox_MouseUp(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso _
            Control.MouseButtons = Windows.Forms.MouseButtons.None Then
            Me.endPoint = e.Location
            Me.endDataBlockIndex = Me.GetDataBlockIndexAtPoint(e.Location)
            If Me.mode = editMode.relationMode Then
                Dim relation As UIRelation = New UIRelation(Me.StartPoint, Me.endPoint)
                If Me.startDataBlockIndex <> -1 AndAlso Me.endDataBlockIndex <> -1 AndAlso _
                    Me.startDataBlockIndex <> Me.endDataBlockIndex Then
                    ' Relation should start and end in a datablock. The end datablock should differ from the start
                    ' datablock
                    Dim startBlock As UIDataBlock = CType(Me.modelObjects(startDataBlockIndex), UIDataBlock)
                    Dim endBlock As UIDataBlock = CType(Me.modelObjects(endDataBlockIndex), UIDataBlock)
                    Me.DrawingPictureBox.Invalidate(relation.RelationBorder)
                    relation.SetRelationPath(Me.GetRelationPoints(startBlock.DataBlockRectangle, endBlock.DataBlockRectangle).startPoint, Me.GetRelationPoints(startBlock.DataBlockRectangle, endBlock.DataBlockRectangle).endPoint)
                    ' Add references to start and end data block
                    relation.StartDataBlockIndex = Me.startDataBlockIndex
                    relation.EndDataBlockIndex = Me.endDataBlockIndex
                    Me.modelObjects(startDataBlockIndex) = startBlock
                    Me.modelObjects(endDataBlockIndex) = endBlock
                    ' Add new relation to modelObjects and draw it on the screen
                    Me.modelObjects.Add(relation)
                    ' Add incoming and outgoing relations to dataBlock
                    startBlock.AddRelationOut(Me.modelObjects.Count - 1)
                    endBlock.AddRelationIn(Me.modelObjects.Count - 1)
                    Me.DrawingPictureBox.Invalidate(relation.RelationBorder)
                    Me.DrawingPictureBox.Update()
                ElseIf Me.startDataBlockIndex <> -1 And (Me.endDataBlockIndex = -1 Or Me.startDataBlockIndex = Me.endDataBlockIndex) Then
                    Me.DrawingPictureBox.Invalidate(relation.RelationBorder)
                End If
            End If
        End If
    End Sub



    Private Sub DrawingPictureBox_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles DrawingPictureBox.Paint
        Dim relationPen As New Pen(Color.Black, 2)
        Dim arrowCap As CustomLineCap = New AdjustableArrowCap(5, 5)

        With e.Graphics
            'Draw existing objects
            For Each modelObject As Object In Me.modelObjects
                If modelObject.GetType() Is GetType(UIDataBlock) Then
                    Dim dataBlock As UIDataBlock = CType(modelObject, UIDataBlock)
                    .FillRectangle(Brushes.White, dataBlock.DataBlockRectangle)
                    .DrawRectangle(Pens.Black, dataBlock.DataBlockRectangle)
                ElseIf modelObject.GetType Is GetType(UIRelation) Then
                    relationPen.EndCap = LineCap.ArrowAnchor
                    relationPen.CustomEndCap = arrowCap
                    Dim relation As UIRelation = CType(modelObject, UIRelation)
                    .DrawPath(relationPen, relation.RelationPath)
                End If
            Next
            'Draw current objects
            If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
                If Me.mode = editMode.dataBlockMode Then
                    Dim dataBlock As UIDataBlock = New UIDataBlock(Me.StartPoint)
                    .FillRectangle(Brushes.White, dataBlock.DataBlockRectangle)
                    .DrawRectangle(Pens.Black, dataBlock.DataBlockRectangle)
                ElseIf Me.mode = editMode.relationMode AndAlso _
                    Me.startDataBlockIndex <> -1 Then
                    Dim relation As UIRelation = New UIRelation(Me.StartPoint, Me.endPoint)
                    .DrawPath(relationPen, relation.RelationPath)
                End If
            End If
        End With
    End Sub

    Private Function GetDataBlockIndexAtPoint(ByVal location As Point) As Integer
        Dim result As Integer = -1

        For index As Integer = Me.modelObjects.Count - 1 To 0 Step -1
            If Me.modelObjects(index).GetType() Is GetType(UIDataBlock) Then
                Dim dataBlock As UIDataBlock = CType(Me.modelObjects(index), UIDataBlock)
                If dataBlock.DataBlockRectangle.Contains(location) Then
                    result = index
                    Exit For
                End If
            End If
        Next

        Return result
    End Function

    Private Sub SelectToolStripButton_Click(sender As Object, e As EventArgs) Handles SelectToolStripButton.Click
        Me.mode = editMode.selectMode
        Me.SelectToolStripButton.Checked = True
        Me.DatablockToolStripButton.Checked = False
        Me.RelationToolStripButton.Checked = False
    End Sub

    Private Sub DatablockToolStripButton_Click(sender As Object, e As EventArgs) Handles DatablockToolStripButton.Click
        Me.mode = editMode.dataBlockMode
        Me.DatablockToolStripButton.Checked = True
        Me.SelectToolStripButton.Checked = False
        Me.RelationToolStripButton.Checked = False
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim index As Integer, box As New Rectangle, dataBlock As UIDataBlock
        If Me.selectedDataBlockIndex <> -1 Then
            index = Me.selectedDataBlockIndex
        ElseIf Me.selectedRelationIndex <> -1 Then
            index = Me.selectedRelationIndex
        End If
        If Me.modelObjects(index).GetType Is GetType(UIDataBlock) Then
            dataBlock = CType(Me.modelObjects(Me.selectedDataBlockIndex), UIDataBlock)
            box = dataBlock.blockBorder
        ElseIf Me.modelObjects(index).GetType Is GetType(UIRelation) Then
            Dim relation As UIRelation = CType(Me.modelObjects(index), UIRelation)
            box = relation.RelationBorder
        End If
        Me.modelObjects.RemoveAt(index)
        Me.DrawingPictureBox.Invalidate(box)
        Me.DrawingPictureBox.Update()
    End Sub

    Private Sub RelationToolStripButton_Click(sender As Object, e As EventArgs) Handles RelationToolStripButton.Click
        Me.mode = editMode.relationMode
        Me.RelationToolStripButton.Checked = True
        Me.DatablockToolStripButton.Checked = False
        Me.SelectToolStripButton.Checked = False
    End Sub

    Private Function GetRelationIndexAtPoint(ByVal location As Point) As Integer
        Dim relation As UIRelation
        Dim result As Integer = -1

        For index As Integer = Me.modelObjects.Count - 1 To 0 Step -1
            If Me.modelObjects(index).GetType() Is GetType(UIRelation) Then
                relation = CType(Me.modelObjects(index), UIRelation)
                If relation.IsVisible(location) Then
                    result = index
                    Exit For
                End If
            End If
        Next

        Return result
    End Function

    Private Function GetRelationPoints(ByVal startBlock As Rectangle, ByVal endBlock As Rectangle) As relationPoints
        Dim angle As Double, vector1 As Point, vector2 As Point, startPoint As Point, tRelationPoints As relationPoints
        Dim endPoint As Point
        vector1 = New Point(endBlock.X - startBlock.X, endBlock.Y - startBlock.Y)
        vector2 = New Point(endBlock.X + endBlock.Width, 0)
        angle = GetAngle(vector1, vector2)
        If angle < 33.7 Then 'start right, end left
            startPoint = New Point(startBlock.X + startBlock.Width, startBlock.Y + CInt(0.5 * startBlock.Height))
            endPoint = New Point(endBlock.X, endBlock.Y + CInt(0.5 * endBlock.Height))
        ElseIf angle >= 146.3 Then 'start left, end right
            startPoint = New Point(startBlock.X, startBlock.Y + CInt(0.5 * startBlock.Height))
            endPoint = New Point(endBlock.X + endBlock.Width, endBlock.Y + CInt(0.5 * endBlock.Height))
        ElseIf endBlock.Y - startBlock.Y >= 0 Then 'start top, end bottom
            startPoint = New Point(startBlock.X + CInt(0.5 * startBlock.Width), startBlock.Y + startBlock.Height)
            endPoint = New Point(endBlock.X + CInt(0.5 * endBlock.Width), endBlock.Y)
        Else 'start bottom, end top
            startPoint = New Point(startBlock.X + CInt(0.5 * startBlock.Width), startBlock.Y)
            endPoint = New Point(endBlock.X + CInt(0.5 * endBlock.Width), endBlock.Y + endBlock.Height)
        End If
        tRelationPoints.startPoint = startPoint
        tRelationPoints.endPoint = endPoint
        Return tRelationPoints
    End Function
    Private Function GetAngle(ByVal vector1 As Point, vector2 As Point) As Double
        Dim angle As Double
        angle = Math.Acos((vector1.X * vector2.X + vector1.Y * vector2.Y) / _
                          (Math.Sqrt(vector1.X ^ 2 + vector1.Y ^ 2) * Math.Sqrt(vector2.X ^ 2 + vector2.Y ^ 2))) _
                      * 180 / Math.PI
        Return angle
    End Function

End Class