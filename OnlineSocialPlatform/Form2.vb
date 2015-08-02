Imports System.Data.SqlClient
Imports System.IO
Public Class Form2
    Public num As Integer

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        Label5.Visible = True
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Label5.Visible = False
        For t = 0 To CampusloveDataSet2.Tables(0).Rows.Count - 1
            If TextBox1.Text = CampusloveDataSet2.Tables(0).Rows(t).Item(1) Then
                TextBox1.Text = ""
                MsgBox("此用户名已被使用")
                TextBox1.Focus()
                Exit Sub
            End If
        Next
                Label6.Visible = True
                Label6.Text = "此用户名未被使用"


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        Label13.Visible = True
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        Label13.Visible = False
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox3.ReadOnly = False

    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus

        If Len(TextBox2.Text) < 6 Then
            MsgBox("密码过短")
            TextBox2.Text = ""
            TextBox3.Text = ""
            Exit Sub
        End If
        If TextBox2.Text <> TextBox3.Text Then
            TextBox2.Text = ""
            TextBox3.Text = ""
            Label9.Text = "两次密码不符"
        Else
            Label9.Text = "两次密码相同"
        End If

    End Sub

    Private Sub TextBox3_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.StyleChanged

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Label9.Visible = True
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        Label11.Visible = True
    End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        Label11.Visible = False
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Integer
        For a = 0 To 1
            If TextBox1.Text = "" Then
                MsgBox("用户名为必填项")
                Exit Sub
            End If
            If TextBox2.Text = "" Then
                MsgBox("密码为必填项")
                Exit Sub
            End If
            If TextBox3.Text = "" Then
                MsgBox("请确认密码")
                Exit Sub
            End If
            If TextBox4.Text = "" Then
                MsgBox("电子邮件地址为必填项")
                Exit Sub
            End If
            TabControl1.SelectedIndex = 1
        Next
        ProgressBar1.Value = 30
        PictureBox3.Visible = True
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If
        Dim mail As String
        Dim l, u As Integer
        u = 0
        mail = TextBox4.Text
        l = mail.Length
        For x = 1 To l
            If Mid(mail, x, 1) = "@" Then
                u = u + 1
            End If
        Next
        If u <> 1 Then
            MsgBox("邮件地址输入错误")
            TextBox4.Text = ""
            Exit Sub
        End If

        Dim zbid As Integer
        Dim id1 As String
        zbid = CampusloveDataSet2.Tables(0).Rows.Count
        zbid = zbid + 1
        If zbid < 10 Then
            id1 = "0000" + Format(zbid)
        ElseIf zbid < 100 Then
            id1 = "000" + Format(zbid)
        ElseIf zbid < 1000 Then
            id1 = "00" + Format(zbid)
        ElseIf zbid < 10000 Then
            id1 = "0" + Format(zbid)
        Else
            id1 = Format(zbid)
        End If
        '自动确定ID
        id = id1
        Dim time As String
        time = Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + " 00:00:00.000"
        Dim myconn = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim mysql As String = "insert into student values('" & id1 & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "',null,null,null,null,null,'" & TextBox4.Text & "',null,null,null,null,null,null,null,null,'" & time & "',null,null)"
        Dim mycmd As New SqlClient.SqlCommand(mysql, myconn)
        myconn.Open()
        Try
            mycmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myconn.Close()
        MsgBox("注册成功")
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        Label17.Visible = True
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ProgressBar1.Value = ProgressBar1.Value + 15
       
        TabControl1.SelectedIndex = 2
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If
        Dim sex As String
        sex = Nothing
        If RadioButton1.Checked = True Then
            sex = "男"
        ElseIf RadioButton2.Checked = True Then
            sex = "女"
        End If
        Dim bir As String
        bir = ComboBox8.SelectedItem + "-" + ComboBox9.SelectedItem + "-" + ComboBox10.SelectedItem + " 00:00:00.000"
        Dim myconn1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set name='" & TextBox5.Text & "',gender='" & sex & " ',birthday='" & bir & "',province='" & ComboBox1.SelectedItem & "',mobile='" & TextBox6.Text & "'  where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn1)
        myconn1.Open()
        mycmd.ExecuteNonQuery()
        myconn1.Close()
        If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
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
        End If

        MsgBox("添加成功")
    End Sub

    Private Sub TextBox13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.LostFocus
        MsgBox("将授权管理员向同济大学认证您的学号和个人信息，这将会花费几天的时间", 0, "授权管理员")
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectedIndex = 7
        ProgressBar1.Value = ProgressBar1.Value + 15
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If
        TabControl1.SelectedIndex = 3
        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set snum='" & TextBox13.Text & "',campus='" & ComboBox2.SelectedItem & "',major='" & ComboBox3.SelectedItem & "',grade='" & ComboBox7.SelectedItem & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        MsgBox("添加成功")

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CampusloveDataSet2.B' table. You can move, or remove it, as needed.
        Me.BTableAdapter.Fill(Me.CampusloveDataSet2.B)
        'TODO: This line of code loads data into the 'CampusloveDataSet1.A' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'CampusloveDataSet5.student' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'CampusloveDataSet5.student' table. You can move, or remove it, as needed.



        num = 0
        Label49.Text = num
        Label48.Text = 5 - num

        '以下是界面设计代码
        Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "\素材\注册界面.jpg")
        Me.PictureBox3.Image = Image.FromFile(Application.StartupPath & "\素材\随便逛逛按钮.jpg")
        Me.PictureBox4.Image = Image.FromFile(Application.StartupPath & "\素材\主界面按钮.jpg")
        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\1.jpg.jpg")
    End Sub

    Private Sub TextBox14_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.LostFocus
        If TextBox14.TextLength > 400 Then
            MsgBox("超过规定字数")
            Button7.Enabled = False
        Else
            Button7.Enabled = True
        End If

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TabControl1.SelectedIndex = 4
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If
        Dim myconn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set hobby='" & TextBox15.Text & "',describe='" & TextBox14.Text & "' where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()
        MsgBox("添加成功")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
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
        Dim myconn = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "update student set personality='" & hobby & "'where id='" & id & "'"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        mycmd.ExecuteNonQuery()
        myconn.Close()




        TabControl1.SelectedIndex = 5
        ProgressBar1.Value = ProgressBar1.Value + 20
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If
        MsgBox("添加成功")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = 100 Then
            PictureBox2.Visible = True
        End If

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
        MsgBox("添加成功")
    End Sub

    Private Sub TabPage8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage8.Click

    End Sub

    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub CheckBox20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = True Then
            num = num + 1
        Else
            num = num - 1
        End If
        Label49.Text = num
        Label48.Text = 5 - num
    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub StudentBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub FillToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox16_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "OpenFileDialog1" Then
        Else
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If

    End Sub

    
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub TextBox16_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox16_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
End Class