Imports System.Math
Imports System.Data.SqlClient
Imports System.String

Public Class Form4

    Public check As Integer = 0
    Public cmdtxt As String
    Public sqlcnct As SqlConnection
    Public sqldtdpt As SqlDataAdapter
    Public dtst As DataSet

    Private Function cosangle(ByVal str1 As String, ByVal str2 As String)
        Dim inner_product As Double = 0
        Dim length1 As Double = 0
        Dim length2 As Double = 0
        For i = 0 To 9
            inner_product += Val(str1(i)) * Val(str2(i))
            length1 += Val(str1(i)) * Val(str1(i))
            length2 += Val(str2(i)) * Val(str2(i))
        Next
        Return inner_product / Sqrt(length1 * length2)
    End Function

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim ptag As String
        Dim c(8) As Char
        Dim len As Integer
        For i = 0 To 8
            c(i) = "0"
        Next
        cmdtxt = "select username,name,gender,major,grade,personality from student where gender in ('男','女')"
        If RadioButton14.Checked = True Then
            cmdtxt += "and gender='男'"
        End If
        If RadioButton15.Checked = True Then
            cmdtxt += "and gender='女'"
        End If
        If TextBox3.TextLength > 0 Then
            cmdtxt += "and year(getdate())-year(birthday)>=" & Val(TextBox3.Text)
        End If
        If TextBox4.TextLength > 0 Then
            cmdtxt += "and year(getdate())-year(birthday)<=" & Val(TextBox4.Text)
        End If
        If ComboBox1.SelectedIndex > 0 Then
            cmdtxt += "and province='" & ComboBox1.SelectedItem & "'"
        End If
        If ComboBox2.SelectedIndex > 0 Then
            cmdtxt += "and grade='" & ComboBox2.SelectedItem & "'"
        End If
        If ComboBox3.SelectedIndex > 0 Then
            cmdtxt += "and campus='" & ComboBox3.SelectedItem & "'"
        End If
        If ComboBox4.SelectedIndex > 0 Then
            cmdtxt += "and major='" & ComboBox4.SelectedItem & "'"
        End If
        If TextBox1.Text.Length > 0 Then
            cmdtxt += "and name='" & TextBox1.Text & "'"
        End If
        If TextBox2.Text.Length > 0 Then
            cmdtxt += "and snum='" & TextBox2.Text & "'"
        End If
        '     MsgBox(ComboBox1.SelectedIndex)
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqldtdpt = New SqlDataAdapter(cmdtxt, sqlcnct)
        dtst = New DataSet
        sqldtdpt.Fill(dtst)
        len = dtst.Tables(0).Rows.Count
        dtst.Tables(0).Rows.Add()
        If CheckBox1.Checked = True Then
            ptag = "1"
        Else
            ptag = "0"
        End If
        If CheckBox2.Checked = True Then
            c(0) = "1"
        End If
        If CheckBox3.Checked = True Then
            c(1) = "1"
        End If
        If CheckBox4.Checked = True Then
            c(2) = "1"
        End If
        If CheckBox5.Checked = True Then
            c(3) = "1"
        End If
        If CheckBox6.Checked = True Then
            c(4) = "1"
        End If
        If CheckBox7.Checked = True Then
            c(5) = "1"
        End If
        If CheckBox8.Checked = True Then
            c(6) = "1"
        End If
        If CheckBox9.Checked = True Then
            c(7) = "1"
        End If
        If CheckBox10.Checked = True Then
            c(8) = "1"
        End If
        For i = 0 To 8
            ptag += c(i)
        Next
        '    MsgBox(cosangle(myset.Tables(0).Rows(1).Item(5), ptag))
        For i = 0 To len - 2
            For j = len - 1 To i + 1 Step -1
                If cosangle(dtst.Tables(0).Rows(j - 1).Item(5), ptag) < cosangle(dtst.Tables(0).Rows(j).Item(5), ptag) Then
                    dtst.Tables(0).Rows(len).Item(0) = dtst.Tables(0).Rows(j - 1).Item(0)
                    dtst.Tables(0).Rows(len).Item(1) = dtst.Tables(0).Rows(j - 1).Item(1)
                    dtst.Tables(0).Rows(len).Item(2) = dtst.Tables(0).Rows(j - 1).Item(2)
                    dtst.Tables(0).Rows(len).Item(3) = dtst.Tables(0).Rows(j - 1).Item(3)
                    dtst.Tables(0).Rows(len).Item(4) = dtst.Tables(0).Rows(j - 1).Item(4)
                    dtst.Tables(0).Rows(len).Item(5) = dtst.Tables(0).Rows(j - 1).Item(5)
                    dtst.Tables(0).Rows(j - 1).Item(0) = dtst.Tables(0).Rows(j).Item(0)
                    dtst.Tables(0).Rows(j - 1).Item(1) = dtst.Tables(0).Rows(j).Item(1)
                    dtst.Tables(0).Rows(j - 1).Item(2) = dtst.Tables(0).Rows(j).Item(2)
                    dtst.Tables(0).Rows(j - 1).Item(3) = dtst.Tables(0).Rows(j).Item(3)
                    dtst.Tables(0).Rows(j - 1).Item(4) = dtst.Tables(0).Rows(j).Item(4)
                    dtst.Tables(0).Rows(j - 1).Item(5) = dtst.Tables(0).Rows(j).Item(5)
                    dtst.Tables(0).Rows(j).Item(0) = dtst.Tables(0).Rows(len).Item(0)
                    dtst.Tables(0).Rows(j).Item(1) = dtst.Tables(0).Rows(len).Item(1)
                    dtst.Tables(0).Rows(j).Item(2) = dtst.Tables(0).Rows(len).Item(2)
                    dtst.Tables(0).Rows(j).Item(3) = dtst.Tables(0).Rows(len).Item(3)
                    dtst.Tables(0).Rows(j).Item(4) = dtst.Tables(0).Rows(len).Item(4)
                    dtst.Tables(0).Rows(j).Item(5) = dtst.Tables(0).Rows(len).Item(5)
                    MsgBox(dtst.Tables(0).Rows(0).Item(0))
                End If
            Next
        Next
        dtst.Tables(0).Rows.RemoveAt(len)
        DataGridView1.DataSource = dtst.Tables(0)
        '     sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        '     sqlcnct.Open()
        '    Dim sqlcmd As New SqlCommand("update student set lastsearch='" & cmdtxt & "',lastsearchtime=getdate() where id='" & id & "'", sqlcnct)
        '     sqlcmd.ExecuteNonQuery()
        '    sqlcnct.Close()
        '    MsgBox("update student set lastsearch='" & cmdtxt & "' where id='" & id & "'")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim username As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        '      MsgBox(username)
        Dim f7 As New Form7
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqldtdpt = New SqlDataAdapter("select username,name,gender,year(getdate())-year(birthday),province,campus,major,grade,personality,hobby,describe from student where username='" & username & "'", sqlcnct)
        dtst = New DataSet
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
        f7.Show()
        f7.Top = 100
        f7.Left = 830
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        Me.Left = 200
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        If check = 0 Then
            sqldtdpt = New SqlDataAdapter(cmdtxt & " order by year(getdate())-year(birthday)", sqlcnct)
            check = 1
        Else
            sqldtdpt = New SqlDataAdapter(cmdtxt & " order by year(getdate())-year(birthday) desc", sqlcnct)
            check = 0
        End If
        dtst = New DataSet
        sqldtdpt.Fill(dtst)
        DataGridView1.DataSource = dtst.Tables(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sqlcnct = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        sqldtdpt = New SqlDataAdapter(Mid(cmdtxt, 1, 126) & ",favorite" & Mid(cmdtxt, 127) & "and student.id=favorite.id2 group by student.id order by count(*) desc", sqlcnct)
        dtst = New DataSet
        sqldtdpt.Fill(dtst)
        DataGridView1.DataSource = dtst.Tables(0)
    End Sub

End Class