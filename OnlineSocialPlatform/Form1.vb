Imports System.Data.SqlClient
Imports System.IO
Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim mycon As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
    Dim mybind As BindingManagerBase
    Dim mydataset As New Data.DataSet
    Dim sqldataadapter1 As SqlDataAdapter

    Private Sub StudentBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StudentBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.StudentBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CampusloveDataSet4)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CampusloveDataSet6.student' table. You can move, or remove it, as needed.
        Me.StudentTableAdapter1.Fill(Me.CampusloveDataSet6.student)
        'TODO: This line of code loads data into the 'CampusloveDataSet4.student' table. You can move, or remove it, as needed.
        Me.StudentTableAdapter.Fill(Me.CampusloveDataSet4.student)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()

        


    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.RefreshEdit()
        Me.DataGridView1.Refresh()

        Dim mysql As String = "select * from student where (id>=00000)and(id<=99999)"    '只要第一个查询条件可以执行，后面的均可以用and叠加
        If TextBox1.Text <> Nothing Then
            mysql = mysql & "and username='" & TextBox1.Text & "'"
        End If
        If TextBox2.Text <> Nothing Then
            mysql = mysql & "and name='" & TextBox2.Text & "'"
        End If
        If TextBox4.Text <> Nothing Then
            mysql = mysql & "and campus='" & TextBox4.Text & "'"
        End If
        If TextBox5.Text <> Nothing Then
            mysql = mysql & "and province='" & TextBox5.Text & "'"
        End If
        If TextBox6.Text <> Nothing Then
            mysql = mysql & "and snum='" & TextBox6.Text & "'"
        End If
        If TextBox7.Text <> Nothing Then
            mysql = mysql & "and grade='" & TextBox7.Text & "'"
        End If
        If TextBox3.Text <> Nothing Then
            mysql = mysql & "and major='" & TextBox7.Text & "'"
        End If
        If (Me.ComboBox1.Text <> Nothing) And (ComboBox1.Text = "男") Then
            mysql = mysql & "and grade='男'"
        ElseIf (Me.ComboBox1.Text <> Nothing) And (ComboBox1.Text = "女") Then
            mysql = mysql & "and grade='女'"
        End If


        Dim myadap As SqlDataAdapter = New SqlDataAdapter(mysql, mycon)
        myadap.Fill(mydataset, "1")
        mybind = Me.BindingContext(Me.mydataset, "1")
        Me.DataGridView1.DataSource = mydataset
        Me.DataGridView1.DataMember = "1"



        Dim sum As Integer = 0
        Dim mycom As SqlCommand = New SqlCommand(mysql, mycon)
        mycon.Open()
        Dim myreader As SqlDataReader = mycom.ExecuteReader
        Do While myreader.Read
            sum = sum + 1
        Loop
        myreader.Close()
        mycon.Close()
        Me.Label8.Text = "查询结果总数为" & sum

    End Sub


    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        Me.Label10.Visible = False
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Me.Label10.Visible = True
    End Sub

    Private Sub ComboBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.MouseLeave
        Me.Label11.Visible = False
    End Sub

    Private Sub ComboBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseMove
        Me.Label11.Visible = True
    End Sub

    Private Sub TextBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        Me.Label12.Visible = True
    End Sub

    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        Me.Label12.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpenFileDialog1.ShowDialog()
        PictureBox1.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim myconn1 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql As String = "insert into whattodo values ('" & TextBox9.Text & "','" & TextBox8.Text & "',null )"
        Dim mycmd As New SqlClient.SqlCommand(sql, myconn1)
        myconn1.Open()
        mycmd.ExecuteNonQuery()
        myconn1.Close()
        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim myadapter As New SqlDataAdapter("select * from whattodo where id='" & TextBox9.Text & "'", myconn)
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
            tongjiPic.Rows(i).Item(2) = data
        Next
        Dim cmdbuilder As New SqlCommandBuilder(myadapter)
        myadapter.Update(tongjiPic.GetChanges)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mybind.RemoveAt(mybind.Position)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        StudentBindingSource.AddNew()
        StudentBindingSource.EndEdit()
        StudentTableAdapter.Update(CampusloveDataSet6.Tables(0))
    End Sub

End Class