Imports System.Data.SqlClient
Imports System.IO
Public Class Form6
    Public num As Integer

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        num = 0
        Label16.Text = num
        Label17.Text = 5 - num
        id = "00002" 'for test
        _idToolStripTextBox.Text = id

        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Dim pro As Integer
        pro = 100
        For t = 3 To 15
            If IsDBNull(CampusloveDataSet3.Tables(0).Rows(0).Item(t)) = 1 Then
                pro = pro - 7.692
            End If
        Next
        ProgressBar1.Value = pro
        Dim hobby As String
        hobby = CampusloveDataSet3.Tables(0).Rows(0).Item(13)
        If Mid(hobby, 1, 1) = "1" Then
            CheckBox11.Checked = True
        End If
        If Mid(hobby, 2, 1) = "1" Then
            CheckBox12.Checked = True
        End If
        If Mid(hobby, 3, 1) = "1" Then
            CheckBox13.Checked = True
        End If
        If Mid(hobby, 4, 1) = "1" Then
            CheckBox14.Checked = True
        End If
        If Mid(hobby, 5, 1) = "1" Then
            CheckBox15.Checked = True
        End If
        If Mid(hobby, 6, 1) = "1" Then
            CheckBox16.Checked = True
        End If
        If Mid(hobby, 7, 1) = "1" Then
            CheckBox17.Checked = True
        End If
        If Mid(hobby, 8, 1) = "1" Then
            CheckBox18.Checked = True
        End If
        If Mid(hobby, 9, 1) = "1" Then
            CheckBox19.Checked = True
        End If
        If Mid(hobby, 10, 1) = "1" Then
            CheckBox20.Checked = True
        End If


        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
  Dim myPic As MemoryStream
        Dim data As Byte()
        Dim mystr As String = "select * from student where id='" & id & "'"
        Dim myadapter As New SqlDataAdapter(mystr, myconn)
        Dim tongjiPic As New DataTable

        myadapter.Fill(tongjiPic)

        If tongjiPic.Rows.Count <> 0 Then
            If IsDBNull(tongjiPic.Rows(0).Item(16)) Then
                Return
            End If
            data = tongjiPic.Rows(0).Item(16)
            myPic = New MemoryStream(data)
            Me.PictureBox1.Image = Image.FromStream(myPic)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim myconn1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set mobile='" & MobileTextBox.Text & "',email='" & EmailTextBox.Text & "',province='" & ProvinceTextBox.Text & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn1)
        myconn1.Open()
        mycmd.ExecuteNonQuery()
        myconn1.Close()
        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim myadapter As New SqlDataAdapter("select * from student", myconn)
        Dim tongjiPic As New DataTable
        myadapter.Fill(tongjiPic)
        Dim myPic As FileStream
        Dim data As Byte()
        Dim i As Integer
        For i = 0 To tongjiPic.Rows.Count - 1
            myPic = New FileStream(OpenFileDialog1.FileName.ToString, FileMode.Open)
            ReDim data(myPic.Length - 1)
            myPic.Read(data, 0, myPic.Length)
            myPic.Close()
            tongjiPic.Rows(i).Item(16) = data
        Next
        Dim cmdbuilder As New SqlCommandBuilder(myadapter)
        myadapter.Update(tongjiPic.GetChanges)
        MsgBox("更新成功")
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox2.Text <> TextBox3.Text Then
            TextBox2.Text = ""
            TextBox3.Text = ""
            MsgBox("两次输入不符")

        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = CampusloveDataSet3.Tables(0).Rows(0).Item(2) Then
            TextBox2.ReadOnly = False
            TextBox3.ReadOnly = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set hobby='" & HobbyTextBox.Text & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        MsgBox(sql)
        myconn.Close()
        Try
            mycmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Dim pro As Integer
        pro = 100
        For t = 3 To 15
            If IsDBNull(CampusloveDataSet3.Tables(0).Rows(0).Item(t)) = 1 Then
                pro = pro - 7.692
            End If
        Next
        ProgressBar1.Value = pro
        MsgBox("更新成功")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set grade='" & Val(GradeTextBox.Text) & "',major='" & Val(MajorTextBox.Text) & "',campus='" & Val(CampusTextBox.Text) & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Dim pro As Integer
        pro = 100
        For t = 3 To 15
            If IsDBNull(CampusloveDataSet3.Tables(0).Rows(0).Item(t)) = 1 Then
                pro = pro - 7.692
            End If
        Next
        ProgressBar1.Value = pro
        MsgBox("更新成功")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set pssword='" & Val(TextBox2.Text) & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Dim pro As Integer
        pro = 100
        For t = 3 To 15
            If IsDBNull(CampusloveDataSet3.Tables(0).Rows(0).Item(t)) = 1 Then
                pro = pro - 7.692
            End If
        Next
        ProgressBar1.Value = pro
        MsgBox("更新成功")
    End Sub

    Private Sub CheckBox16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub TabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub CheckBox17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub CheckBox20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label16.Text = num
        Label17.Text = 5 - num
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If num > 5 Then
            MsgBox("最多只能选五个！！")
            Exit Sub
        End If
        Dim hobby As String
        hobby = "0000000000"
        If CheckBox11.Checked = True Then
            Mid(hobby, 1, 1) = "1"
        Else
            Mid(hobby, 1, 1) = "0"
        End If
        If CheckBox12.Checked = True Then
            Mid(hobby, 2, 1) = "1"
        Else
            Mid(hobby, 2, 1) = "0"
        End If
        If CheckBox13.Checked = True Then
            Mid(hobby, 3, 1) = "1"
        Else
            Mid(hobby, 3, 1) = "0"
        End If
        If CheckBox14.Checked = True Then
            Mid(hobby, 4, 1) = "1"
        Else
            Mid(hobby, 4, 1) = "0"
        End If
        If CheckBox15.Checked = True Then
            Mid(hobby, 5, 1) = "1"
        Else
            Mid(hobby, 5, 1) = "0"
        End If
        If CheckBox16.Checked = True Then
            Mid(hobby, 6, 1) = "1"
        Else
            Mid(hobby, 6, 1) = "0"
        End If
        If CheckBox17.Checked = True Then
            Mid(hobby, 7, 1) = "1"
        Else
            Mid(hobby, 7, 1) = "0"
        End If
        If CheckBox18.Checked = True Then
            Mid(hobby, 8, 1) = "1"
        Else
            Mid(hobby, 8, 1) = "0"
        End If
        If CheckBox19.Checked = True Then
            Mid(hobby, 9, 1) = "1"
        Else
            Mid(hobby, 9, 1) = "0"
        End If
        If CheckBox20.Checked = True Then
            Mid(hobby, 10, 1) = "1"
        Else
            Mid(hobby, 10, 1) = "0"
        End If
        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set personality='" & Val(hobby) & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Dim pro As Integer
        pro = 100
        For t = 3 To 15
            If IsDBNull(CampusloveDataSet3.Tables(0).Rows(0).Item(t)) = 1 Then
                pro = pro - 7.692
            End If
        Next
        ProgressBar1.Value = pro
        MsgBox("更新成功")
    End Sub




    Private Sub FillToolStripButton_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillToolStripButton.Click
        Try
            Me.XTableAdapter.Fill(Me.CampusloveDataSet3.X, _idToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        OpenFileDialog1.ShowDialog()
        PictureBox1.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        If ComboBox11.SelectedIndex = 0 Then
            wtdf = "00001"
        End If
        If ComboBox11.SelectedIndex = 1 Then
            wtdf = "00002"
        End If
        If ComboBox11.SelectedIndex = 2 Then
            wtdf = "00003"
        End If
        If ComboBox11.SelectedIndex = 3 Then
            wtdf = "00005"
        End If
        If ComboBox11.SelectedIndex = 4 Then
            wtdf = "00004"
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        If ComboBox12.SelectedIndex = 0 Then
            wtd = "10001"
        End If
        If ComboBox12.SelectedIndex = 1 Then
            wtd = "10002"
        End If
        If ComboBox12.SelectedIndex = 2 Then
            wtd = "10003"
        End If
        If ComboBox12.SelectedIndex = 3 Then
            wtd = "10004"
        End If
        If ComboBox12.SelectedIndex = 4 Then
            wtd = "10005"
        End If
        If ComboBox12.SelectedIndex = 5 Then
            wtd = "10006"
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim myconn2 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql2 As String = "delete from whattodolike where id1='" & id & "'"
        Dim mycmd2 As New SqlClient.SqlCommand(sql2, myconn2)
        myconn2.Open()
        mycmd2.ExecuteNonQuery()
        myconn2.Close()
        Dim myconn = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "insert into whattodolike values('" & id & "','" & wtd & "')"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        Dim myconn1 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql1 As String = "insert into whattodolike values('" & id & "','" & wtdf & "')"
        Dim mycmd1 As New SqlClient.SqlCommand(sql1, myconn1)
        myconn1.Open()
        mycmd1.ExecuteNonQuery()
        myconn1.Close()
        MsgBox("更新成功")
    End Sub
End Class