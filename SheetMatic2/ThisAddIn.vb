Public Class ThisAddIn
    Private drawingForm As VisualLanguageForm = New VisualLanguageForm
    Private Sub ThisAddIn_Startup() Handles Me.Startup
        drawingForm.Show()
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown
        drawingForm.Close()
    End Sub

End Class
