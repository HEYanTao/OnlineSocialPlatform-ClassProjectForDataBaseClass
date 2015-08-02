Imports System.Data.SqlClient
Public Class Open

    Dim timerone As Integer = 0, timertwo As Integer = 0, t3 As Integer = 0, t4 As Integer = 0, t5 As Integer = 0, t6 As Integer = 0

    Private Sub 开场_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\素材\遇见.mp3"
        Me.AxWindowsMediaPlayer2.URL = Application.StartupPath & "\素材\开场动画.avi"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If timerone >= 19 Then
            Me.AxWindowsMediaPlayer2.close()
            Me.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\素材\登陆界面.jpg")
            Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\椅子.jpg")
            Me.PictureBox3.Image = Image.FromFile(Application.StartupPath & "\素材\注册.jpg")
            Me.PictureBox4.Image = Image.FromFile(Application.StartupPath & "\素材\登陆.jpg")
            Me.PictureBox2.Visible = True
            Me.PictureBox3.Visible = True
            Me.PictureBox1.Visible = True
            Me.TextBox2.Visible = True
            Me.TextBox1.Visible = True
            Me.Timer1.Stop()

        Else
            timerone = timerone + 1
        End If
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If timerone >= 19 And timertwo = 0 Then
            Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\椅子.jpg")
            timertwo = timertwo + 1
        ElseIf timerone >= 19 And timertwo = 1 Then
            Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\椅子1.jpg")
            timertwo = timertwo - 1
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub


    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        Me.Label1.Visible = False
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        Me.Label1.Visible = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim a As New Form2
        a.Show()

    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If TextBox1.Text <> Nothing And TextBox2.Text <> Nothing Then
            Me.PictureBox4.Visible = True
        End If
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim a As New Form3
        a.Show()
    End Sub

End Class