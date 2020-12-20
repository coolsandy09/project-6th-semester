Imports System.Data.OleDb
Public Class Form2
    Dim currentTime As DateTime
    Dim currenttime1 As DateTime
    Private alert As DateTime = Now

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Timer2.Stop()
        Me.Timer2.Start()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Timer2.Stop()

        Me.Timer2.Stop()

        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.alarm, AudioPlayMode.Background)


        If Form1.HomeDataTable.Rows.Count = 2 Then
            ClientName.Text = Form1.HomeDataTable.Rows(0).Cells(0).Value.ToString
            compname.Text = Form1.HomeDataTable.Rows(0).Cells(1).Value.ToString

        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        currentTime = DateTime.Parse(TimeOfDay.ToShortTimeString)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If currentTime = DateTime.Parse(alert.AddMinutes(10).ToShortTimeString) Then
            Me.Timer1.Stop()
            Me.Show()
            Form1.Hide()

        End If
    End Sub




End Class