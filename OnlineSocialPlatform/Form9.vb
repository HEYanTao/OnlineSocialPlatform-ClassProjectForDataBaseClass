Imports System.Data.SqlClient

Public Class Form9

    Public dttb As New DataTable
    Public index As Integer
    Public length As Integer

    Private Sub display()
        Label4.Text = dttb.Rows(index).Item(2)
        Label5.Text = dttb.Rows(index).Item(3).ToString
        TextBox1.Text = dttb.Rows(index).Item(4)
    End Sub

    Private Sub Form9_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqldtdpt As SqlDataAdapter
        sqldtdpt = New SqlDataAdapter("select id1,name,timedate,content from leftmessage,student where id=id1 and id2='" & id & "' and readorunread=0", sqlcnct)
        sqldtdpt.Fill(dttb)
        index = 0
        length = dttb.Rows.Count
        display()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqlcmd As New SqlCommand("update leftmessage set readorunread=1 where id1='" & dttb.Rows(index).Item(0) & "' and id2='" & id & "' and timedate='" & dttb.Rows(index).Item(1) & "'", sqlcnct)
        sqlcnct.Open()
        sqlcmd.ExecuteNonQuery()
        sqlcnct.Close()
        index += 1
        If index = length Then
            index -= 1
            MsgBox("留言全部读完啦~~")
        End If
        display()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim f7 As New Form7
        f7.Show()
        f7.Top = 100
        f7.Left = 830
        f7.Label30.Hide()
        Dim id1 As String = dttb.Rows(index).Item(0)
        '      MsgBox(username)
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqldtdpt As New SqlDataAdapter("select username,name,gender,year(getdate())-year(birthday),province,campus,major,grade,personality,hobby,describe from student where username='" & id1 & "'", sqlcnct)
        Dim dtst As New DataSet
        sqldtdpt.Fill(dtst)
        Dim personality As String = dtst.Tables(0).Rows(0).Item(8)
        f7.Label9.Text = dtst.Tables(0).Rows(0).Item(0)
        f7.Label10.Text = dtst.Tables(0).Rows(0).Item(1)
        f7.Label11.Text = dtst.Tables(0).Rows(0).Item(2)
        f7.Label12.Text = dtst.Tables(0).Rows(0).Item(3)
        f7.Label13.Text = dtst.Tables(0).Rows(0).Item(4)
        f7.Label14.Text = dtst.Tables(0).Rows(0).Item(5)
        f7.Label15.Text = dtst.Tables(0).Rows(0).Item(6)
        f7.Label16.Text = dtst.Tables(0).Rows(0).Item(7)
        f7.TextBox1.Text = dtst.Tables(0).Rows(0).Item(10)
        f7.TextBox2.Text = dtst.Tables(0).Rows(0).Item(9)
        If personality(0) = "1" Then
            f7.Label18.Visible = True
        End If
        If personality(1) = "1" Then
            f7.Label19.Visible = True
        End If
        If personality(2) = "1" Then
            f7.Label20.Visible = True
        End If
        If personality(3) = "1" Then
            f7.Label21.Visible = True
        End If
        If personality(4) = "1" Then
            f7.Label22.Visible = True
        End If
        If personality(5) = "1" Then
            f7.Label23.Visible = True
        End If
        If personality(6) = "1" Then
            f7.Label24.Visible = True
        End If
        If personality(7) = "1" Then
            f7.Label25.Visible = True
        End If
        If personality(8) = "1" Then
            f7.Label26.Visible = True
        End If
        If personality(9) = "1" Then
            f7.Label27.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim leftmessage As String = InputBox("请输入留言内容:", "留言", , , )
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqlcmd As New SqlCommand("insert into leftmessage values('" & id & "','" & dttb.Rows(index).Item(0) & "','" & Now.ToString & "','" & leftmessage & "',0)", sqlcnct)
        sqlcnct.Open()
        sqlcmd.ExecuteNonQuery()
        sqlcnct.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        index -= 1
        If index = -1 Then
            index += 1
            MsgBox("留言全部读完啦~~")
        End If
        display()
    End Sub
End Class