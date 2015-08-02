Imports System.Data.SqlClient

Public Class Form3

    Public check1 As Integer = 1
    Public check2 As Integer = 1
    Public dttb1 As New DataTable
    Public i As Integer = 0

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqlcmd As New SqlCommand("select lastsearch form student where id='" & id & "'", sqlcnct)
        Dim lastsearch As String
        Dim lastsearchtime As String
        sqlcnct.Open()
        lastsearch = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        sqlcmd = New SqlCommand("select lastsearchtime form student where id='" & id & "'", sqlcnct)
        sqlcnct.Open()
        lastsearchtime = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        Dim sqldtdpt As New SqlDataAdapter(lastsearch & "and regdate>'" & lastsearchtime & "'", sqlcnct)
        sqldtdpt.Fill(dttb1)
        If dttb1.Rows.Count = 0 Then
            check1 = 0
        End If
        Dim dttb2 As New DataTable
        sqldtdpt = New SqlDataAdapter("select id1,timedate,content from leftmessage where id2='" & id & "' and readorunread=0", sqlcnct)
        sqldtdpt.Fill(dttb2)
        If dttb2.Rows.Count = 0 Then
            check2 = 0
        End If
        Me.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮1.jpg")
        Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮2.jpg")
        Me.PictureBox3.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮3.jpg")
        Me.PictureBox4.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮4.jpg")
        Me.PictureBox5.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮5.jpg")
        Me.PictureBox6.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮6.jpg")
        Me.PictureBox7.Image = Image.FromFile(Application.StartupPath & "\素材\form3留言提醒.jpg")
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If check1 = 0 Then
            MsgBox("暂时还没有推荐哦~~")
        Else
            Dim f8 As New Form8
            f8.Show()
            f8.DataGridView1.DataSource = dttb1
        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        If check2 = 0 Then
            MsgBox("没有未读留言")
        Else
            Dim f9 As New Form9
            f9.Show()
        End If
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Me.Label1.Visible = False
        Me.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮1.jpg")
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Me.Label1.Visible = True
        Me.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮10.jpg")
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        Me.Label2.Visible = False
        Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮2.jpg")
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        Me.Label2.Visible = True
        Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮20.jpg")
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        Me.Label5.Visible = False
        Me.PictureBox3.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮3.jpg")
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        Me.Label5.Visible = True
        Me.PictureBox3.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮30.jpg")
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        Me.Label6.Visible = False
        Me.PictureBox4.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮4.jpg")
    End Sub

    Private Sub PictureBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseMove
        Me.Label6.Visible = True
        Me.PictureBox4.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮40.jpg")
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        Me.Label7.Visible = False
        Me.PictureBox5.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮5.jpg")
    End Sub

    Private Sub PictureBox5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseMove
        Me.Label7.Visible = True
        Me.PictureBox5.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮50.jpg")
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        Me.Label4.Visible = False
        Me.PictureBox6.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮6.jpg")
    End Sub

    Private Sub PictureBox6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove
        Me.Label4.Visible = True
        Me.PictureBox6.Image = Image.FromFile(Application.StartupPath & "\素材\form3按钮60.jpg")
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Me.Close()
    End Sub

End Class