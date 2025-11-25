Imports MySql.Data.MySqlClient

Public Class Form1

    Dim connectionString As String = "server=localhost; userid=root; password=root; database=crud_demo_db"


    Public Sub LoadData()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM student_tbl"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                MySqlData.DataSource = table
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Dim query As String = "INSERT INTO student_tbl (name, age, email) 
                               VALUES (@name, @age, @email)"

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Record Inserted Successfully")
            LoadData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        LoadData()
    End Sub

    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MySqlData.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = MySqlData.Rows(e.RowIndex)
            txtID.Text = row.Cells("id").Value.ToString()
            txtName.Text = row.Cells("name").Value.ToString()
            txtAge.Text = row.Cells("age").Value.ToString()
            txtEmail.Text = row.Cells("email").Value.ToString()
        End If
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim query As String = "UPDATE student_tbl 
                               SET name=@name, age=@age, email=@email 
                               WHERE id=@id"

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", txtID.Text)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Record Updated Successfully")
            LoadData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim query As String = "DELETE FROM student_tbl WHERE id=@id"

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", txtID.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Record Deleted Successfully")
            LoadData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
