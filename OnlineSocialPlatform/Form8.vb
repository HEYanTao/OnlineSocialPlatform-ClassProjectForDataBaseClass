Imports System.Data.SqlClient

Public Class Form8

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim username As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        '      MsgBox(username)
        Dim f7 As New Form7
        f7.Show()
        f7.Top = 100
        f7.Left = 830
        Dim sqlcnct As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sqldtdpt As New SqlDataAdapter("select username,name,gender,year(getdate())-year(birthday),province,campus,major,grade,personality,hobby,describe from student where username='" & username & "'", sqlcnct)
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

End Class