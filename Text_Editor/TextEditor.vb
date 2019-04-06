Option Strict On
Imports System.IO

Public Class frmTextEditor
    Private Sub frmTextEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        If (SaveFileDialog1.FileName Is "") Then
            If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtBox.Text, False)
            End If
        Else
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtBox.Text, False)
        End If

        Me.Text = "Text Editor | " + Path.GetFileName(SaveFileDialog1.FileName)

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtBox.Text, False)
            Me.Text = "Text Editor | " + Path.GetFileName(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            txtBox.Text = My.Computer.FileSystem.OpenTextFileReader(OpenFileDialog1.FileName).ReadToEnd()
            Me.Text = "Text Editor | " + Path.GetFileName(OpenFileDialog1.FileName)
            SaveFileDialog1.FileName = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtBox.SelectedText)
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtBox.SelectedText)
        txtBox.SelectedText = ""
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtBox.SelectedText = My.Computer.Clipboard.GetText()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        OpenFileDialog1.FileName = ""
        SaveFileDialog1.FileName = ""
        Me.Text = "Text Editor | "
        txtBox.Text = ""
    End Sub
End Class
