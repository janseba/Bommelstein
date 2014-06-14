<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisualLanguageForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisualLanguageForm))
        Me.DrawingToolsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SelectToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DatablockToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RelationToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DrawingPictureBox = New System.Windows.Forms.PictureBox()
        Me.CanvasContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.xLabel = New System.Windows.Forms.Label()
        Me.yLabel = New System.Windows.Forms.Label()
        Me.angleLabel = New System.Windows.Forms.Label()
        Me.selectedRelationLabel = New System.Windows.Forms.Label()
        Me.DrawingToolsToolStrip.SuspendLayout()
        CType(Me.DrawingPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CanvasContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'DrawingToolsToolStrip
        '
        Me.DrawingToolsToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrawingToolsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectToolStripButton, Me.DatablockToolStripButton, Me.RelationToolStripButton})
        Me.DrawingToolsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.DrawingToolsToolStrip.Name = "DrawingToolsToolStrip"
        Me.DrawingToolsToolStrip.Size = New System.Drawing.Size(65, 533)
        Me.DrawingToolsToolStrip.TabIndex = 0
        Me.DrawingToolsToolStrip.Text = "ToolStrip1"
        '
        'SelectToolStripButton
        '
        Me.SelectToolStripButton.Checked = True
        Me.SelectToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SelectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SelectToolStripButton.Image = CType(resources.GetObject("SelectToolStripButton.Image"), System.Drawing.Image)
        Me.SelectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectToolStripButton.Name = "SelectToolStripButton"
        Me.SelectToolStripButton.Size = New System.Drawing.Size(62, 19)
        Me.SelectToolStripButton.Text = "Select"
        Me.SelectToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DatablockToolStripButton
        '
        Me.DatablockToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DatablockToolStripButton.Image = CType(resources.GetObject("DatablockToolStripButton.Image"), System.Drawing.Image)
        Me.DatablockToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DatablockToolStripButton.Name = "DatablockToolStripButton"
        Me.DatablockToolStripButton.Size = New System.Drawing.Size(62, 19)
        Me.DatablockToolStripButton.Text = "Datablock"
        Me.DatablockToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RelationToolStripButton
        '
        Me.RelationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.RelationToolStripButton.Image = CType(resources.GetObject("RelationToolStripButton.Image"), System.Drawing.Image)
        Me.RelationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RelationToolStripButton.Name = "RelationToolStripButton"
        Me.RelationToolStripButton.Size = New System.Drawing.Size(62, 19)
        Me.RelationToolStripButton.Text = "Relation"
        Me.RelationToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RelationToolStripButton.ToolTipText = "ToolStripButton"
        '
        'DrawingPictureBox
        '
        Me.DrawingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DrawingPictureBox.Location = New System.Drawing.Point(65, 0)
        Me.DrawingPictureBox.Name = "DrawingPictureBox"
        Me.DrawingPictureBox.Size = New System.Drawing.Size(733, 533)
        Me.DrawingPictureBox.TabIndex = 1
        Me.DrawingPictureBox.TabStop = False
        '
        'CanvasContextMenuStrip
        '
        Me.CanvasContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.CanvasContextMenuStrip.Name = "ContextMenuStrip1"
        Me.CanvasContextMenuStrip.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'xLabel
        '
        Me.xLabel.AutoSize = True
        Me.xLabel.Location = New System.Drawing.Point(0, 262)
        Me.xLabel.Name = "xLabel"
        Me.xLabel.Size = New System.Drawing.Size(0, 13)
        Me.xLabel.TabIndex = 2
        '
        'yLabel
        '
        Me.yLabel.AutoSize = True
        Me.yLabel.Location = New System.Drawing.Point(0, 284)
        Me.yLabel.Name = "yLabel"
        Me.yLabel.Size = New System.Drawing.Size(0, 13)
        Me.yLabel.TabIndex = 3
        '
        'angleLabel
        '
        Me.angleLabel.AutoSize = True
        Me.angleLabel.Location = New System.Drawing.Point(0, 240)
        Me.angleLabel.Name = "angleLabel"
        Me.angleLabel.Size = New System.Drawing.Size(0, 13)
        Me.angleLabel.TabIndex = 4
        '
        'selectedRelationLabel
        '
        Me.selectedRelationLabel.AutoSize = True
        Me.selectedRelationLabel.Location = New System.Drawing.Point(0, 102)
        Me.selectedRelationLabel.Name = "selectedRelationLabel"
        Me.selectedRelationLabel.Size = New System.Drawing.Size(86, 13)
        Me.selectedRelationLabel.TabIndex = 5
        Me.selectedRelationLabel.Text = "selectedRelation"
        '
        'VisualLanguageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 533)
        Me.Controls.Add(Me.selectedRelationLabel)
        Me.Controls.Add(Me.angleLabel)
        Me.Controls.Add(Me.yLabel)
        Me.Controls.Add(Me.xLabel)
        Me.Controls.Add(Me.DrawingPictureBox)
        Me.Controls.Add(Me.DrawingToolsToolStrip)
        Me.Name = "VisualLanguageForm"
        Me.Text = "VisualLanguageForm"
        Me.TopMost = True
        Me.DrawingToolsToolStrip.ResumeLayout(False)
        Me.DrawingToolsToolStrip.PerformLayout()
        CType(Me.DrawingPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CanvasContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DrawingToolsToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DatablockToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DrawingPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CanvasContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelationToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents xLabel As System.Windows.Forms.Label
    Friend WithEvents yLabel As System.Windows.Forms.Label
    Friend WithEvents angleLabel As System.Windows.Forms.Label
    Friend WithEvents selectedRelationLabel As System.Windows.Forms.Label
End Class
