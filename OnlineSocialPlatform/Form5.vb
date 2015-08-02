Imports System.Data.SqlClient
Imports System.IO
Public Class Form5
    Public mybind As BindingManagerBase
    Public q As String
    Public myset1 As New DataSet
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        myset1.Clear()
        q = ComboBox1.SelectedItem
        Dim myconn2 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql2 As String = "select id from student where username='" & q & "'"
        Dim myada2 As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sql2, myconn2)
        Dim myset2 As New DataSet
        myada2.Fill(myset2)
        q = myset2.Tables(0).Rows(0).Item(0)

        Dim myconn1 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql1 As String = "select whattodo .desription from whattodo ,whattodolike where whattodolike .id2 =whattodo .id and whattodolike .id1 ='" & q & "'"
        Dim myada1 As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sql1, myconn1)
        myada1.Fill(myset1)
        mybind = Me.BindingContext(myset1.Tables(0))
        TextBox1.Text = myset1.Tables(0).Rows(0).Item(0)
        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim myPic As MemoryStream
        Dim data As Byte()
        Dim mystr As String = "select whattodo .photow from whattodo ,whattodolike where whattodolike .id2 =whattodo .id and whattodolike .id1 ='" & q & "'"
        Dim myadapter As New SqlDataAdapter(mystr, myconn)
        Dim tongjiPic As New DataTable

        myadapter.Fill(tongjiPic)

        If tongjiPic.Rows.Count <> 0 Then
            If IsDBNull(tongjiPic.Rows(0).Item(0)) Then
                Return
            End If
            data = tongjiPic.Rows(0).Item(0)
            myPic = New MemoryStream(data)
            Me.PictureBox1.Image = Image.FromStream(myPic)
        End If
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        id = "00001" 'for test
        Dim myconn2 = New SqlClient.SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim sql2 As String = "select username from student,favorite where id1='" & id & "' and id2=id"
        Dim myada2 As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sql2, myconn2)
        Dim myset2 As New DataSet
        myada2.Fill(myset2)
        For t = 0 To myset2.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(myset2.Tables(0).Rows(0).Item(0))
        Next

        Me.PictureBox2.Image = Image.FromFile(Application.StartupPath & "form5(2).jpg")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If mybind.Position = mybind.Count - 1 Then
            MsgBox("无更多建议")
            Exit Sub
        End If
        mybind.Position = mybind.Position + 1

        TextBox1.Text = myset1.Tables(0).Rows(mybind.Position).Item(0)
        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim myPic As MemoryStream
        Dim data As Byte()
        Dim mystr As String = "select whattodo .photow from whattodo where whattodo.desription ='" & TextBox1.Text & "'"
        Dim myadapter As New SqlDataAdapter(mystr, myconn)
        Dim tongjiPic As New DataTable

        myadapter.Fill(tongjiPic)

        If tongjiPic.Rows.Count <> 0 Then
            If IsDBNull(tongjiPic.Rows(0).Item(0)) Then
                Return
            End If
            data = tongjiPic.Rows(0).Item(0)
            myPic = New MemoryStream(data)
            Me.PictureBox1.Image = Image.FromStream(myPic)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mybind.Position = 0 Then
            MsgBox("无更多建议")
            Exit Sub
        End If
        mybind.Position = mybind.Position - 1


        TextBox1.Text = myset1.Tables(0).Rows(mybind.Position).Item(0)
        Dim myconn As New SqlConnection("Data Source=.;Initial Catalog=campuslove;Integrated Security=True")
        Dim myPic As MemoryStream
        Dim data As Byte()
        Dim mystr As String = "select whattodo .photow from whattodo where whattodo.desription ='" & TextBox1.Text & "'"
        Dim myadapter As New SqlDataAdapter(mystr, myconn)
        Dim tongjiPic As New DataTable

        myadapter.Fill(tongjiPic)

        If tongjiPic.Rows.Count <> 0 Then
            If IsDBNull(tongjiPic.Rows(0).Item(0)) Then
                Return
            End If
            data = tongjiPic.Rows(0).Item(0)
            myPic = New MemoryStream(data)
            Me.PictureBox1.Image = Image.FromStream(myPic)
        End If
    End Sub
End Class