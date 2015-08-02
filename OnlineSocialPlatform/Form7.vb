Imports System.Data.SqlClient

Public Class Form7

    Public id1 As String
    Public check As Integer = 0
    Public sqlcnct As SqlConnection
    Public sqlcmd As SqlCommand
    Public cmdtxt As String

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        If check = 0 Then
            cmdtxt = "insert into favorite values('" & id & "','" & id1 & "')"
            Label29.Text = "已收藏"
            check = 1
        Else
            cmdtxt = "delete from favorite where id1='" & id & "' and id2='" & id1 & "'"
            Label29.Text = "收藏"
            check = 0
        End If
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct.Open()
        Try
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sqlcnct.Close()
        MsgBox(cmdtxt)
    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click
        Dim leftmessage As String = InputBox("请输入留言内容:", "留言", , , )
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        cmdtxt = "insert into leftmessage values('" & id & "','" & id1 & "','" & Now.ToString & "','" & leftmessage & "',0)"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct.Open()
        sqlcmd.ExecuteNonQuery()
        sqlcnct.Close()
        MsgBox(cmdtxt)
    End Sub

    Private Sub Form7_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dttb As New DataTable
        Dim sqldtdpt As SqlDataAdapter
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        cmdtxt = "select id from student where username='" & Label9.Text & "'"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqlcnct.Open()
        id1 = sqlcmd.ExecuteScalar
        sqlcnct.Close()
        MsgBox(cmdtxt)
        cmdtxt = "select * from favorite where id1='" & id & "' and id2='" & id1 & "'"
        sqlcmd = New SqlCommand(cmdtxt, sqlcnct)
        sqldtdpt = New SqlDataAdapter(sqlcmd)
        sqldtdpt.Fill(dttb)
        If dttb.Rows.Count = 1 Then
            Label29.Text = "已收藏"
            check = 1
        End If
    End Sub

End Class