Imports System.Data.SqlClient

Public Class Form10

    Public index As Integer = 0
    Public length As Integer
    Public dttb As New DataTable

    Private Sub display()
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim cmdtxt As String = "select name from student where id ='" & dttb.Rows(index).Item(0) & "'"
        Dim sqlcmd As New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct.Open()
        Label2.Text = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        cmdtxt = "select major from student where id='" & dttb.Rows(index).Item(0) & "'"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqlcnct.Open()
        Label4.Text = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        cmdtxt = "select name from student where id='" & dttb.Rows(index).Item(1) & "'"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqlcnct.Open()
        Label7.Text = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        cmdtxt = "select major from student where id='" & dttb.Rows(index).Item(1) & "'"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqlcnct.Open()
        Label9.Text = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        TextBox1.Text = dttb.Rows(index).Item(2)
        TextBox2.Text = dttb.Rows(index).Item(3)
    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqldtdpt As New SqlDataAdapter("select * from show", sqlcnct)
        sqldtdpt.Fill(dttb)
        length = dttb.Rows.Count
        display()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        index -= 1
        If index = -1 Then
            index += 1
        End If
        display()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        index += 1
        If index = length Then
            index -= 1
            MsgBox("希望下一对是你们哦")
        End If
        display()
    End Sub
End Class