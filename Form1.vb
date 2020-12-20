Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Globalization

Public Class Form1

    Dim myConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                                                           "Data Source=Appdetails.accdb")


    Private LiveDateAndTime As Date = Now

    Dim currentTime As DateTime
    Dim AlarmTime As DateTime
    Private alert As DateTime

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Buttonhome.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile where Ending_date like @name and Status=True order by Ending_time ASC"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@name", LiveDateAndTime.ToShortDateString)
            da.SelectCommand = cmd

            da.Fill(dt)

            HomeDataTable.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try






        Dim count As Integer
        count = HomeDataTable.Rows.Count

        If count = 1 Then
            Panelhomedefault.Visible = True
            Panelhome.Visible = False
        Else
            Panelhome.Visible = True
            Panelhomedefault.Visible = False
        End If

        PanelAbout.Visible = False
        PanelviewReminders.Visible = False
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelshowhomedetails.Visible = False


        AlarmTime = Settingalarm()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Buttonaddreminder.Click
        Panelhome.Visible = False
        PanelAbout.Visible = False
        PanelviewReminders.Visible = False
        Paneldetails.Visible = True
        PanelshowDetails.Visible = False
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = False
        txtclient.Select()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Buttonviewreminder.Click
        Panelhome.Visible = False
        PanelAbout.Visible = False
        PanelviewReminders.Visible = True
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = False

        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile  order by Ending_time ASC"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            DataTableView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try
        txtsearch.Text = ""
        txtsearch.Select()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Buttonaboutus.Click
        Panelhome.Visible = False
        PanelAbout.Visible = True
        PanelviewReminders.Visible = False
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtclient.Clear()
        txtcompany.Clear()
        txtemail.Clear()
        txtphone.Clear()
        txtspread.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()

        txtclient.Select()
    End Sub

    Private Sub Butadd_Click(sender As Object, e As EventArgs) Handles Butadd.Click

        'MsgBox(MaskedTextBox1.Text + " " + ComboBox1.Text)
        Try
            If MaskedTextBox1.MaskFull = False Then
                MsgBox("starting time can't be empty!!")
                MaskedTextBox1.Select()
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex)
            MsgBox("first try fault!")
        End Try

        Try
            If MaskedTextBox2.MaskFull = False Then
                MsgBox("ending time can't be empty!!")
                MaskedTextBox2.Select()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex)
            MsgBox("third try fault!")
        End Try

        Try
            If (ComboBox1.SelectedIndex = -1) Then
                MsgBox("select AM/PM for starting time")
                ComboBox1.Select()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex)
            MsgBox("fifth try fault!")
        End Try
        Try
            If (ComboBox2.SelectedIndex = -1) Then
                MsgBox("select AM/PM for ending time")
                ComboBox1.Select()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex)
            MsgBox("sisth try fault!")
        End Try

        If String.IsNullOrWhiteSpace(txtclient.Text) = True Then
            MsgBox("client name can't be empty!!")
            txtclient.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtcompany.Text) = True Then
            MsgBox("Company name can't be empty!!")
            txtcompany.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtspread.Text) = True Then
            MsgBox("Nummber can't be null!!")
            txtspread.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtemail.Text) = True Then
            MsgBox("email can't be empty!!")
            txtemail.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtphone.Text) = True Then
            MsgBox("phone number can't be empty!!")
            txtphone.Select()
            Exit Sub
        End If


        Try

            If String.IsNullOrWhiteSpace(txtclient.Text) = False And String.IsNullOrWhiteSpace(txtcompany.Text) = False And String.IsNullOrWhiteSpace(txtemail.Text) = False And String.IsNullOrWhiteSpace(txtphone.Text) = False And String.IsNullOrWhiteSpace(txtspread.Text) = False Then

                Try
                    myConnection.Open()
                Catch ex As Exception
                    MsgBox(ex.ToString)


                End Try

                Dim str As String
                str = "Insert into profile([Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number]) Values (?,?,?,?,?,?,?,?,?,?)"
                Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                cmd.Parameters.Add(New OleDbParameter("Client_name", txtclient.Text))
                cmd.Parameters.Add(New OleDbParameter("Company_name", txtcompany.Text))
                cmd.Parameters.Add(New OleDbParameter("Arriavle_date", DateTime.Parse(DateTimePicker1.Value.ToShortDateString)))
                cmd.Parameters.Add(New OleDbParameter("Starting_date", DateTime.Parse(DateTimePicker2.Value.ToShortDateString)))
                cmd.Parameters.Add(New OleDbParameter("Starting_time", Convert.ToDateTime(MaskedTextBox1.Text + " " + ComboBox1.Text)))
                cmd.Parameters.Add(New OleDbParameter("Ending_date", DateTime.Parse(DateTimePicker3.Value.ToShortDateString)))
                cmd.Parameters.Add(New OleDbParameter("Ending_time", Convert.ToDateTime(MaskedTextBox2.Text + " " + ComboBox2.Text)))
                cmd.Parameters.Add(New OleDbParameter("Spread_per_day", CInt(txtspread.Text)))
                cmd.Parameters.Add(New OleDbParameter("Email", txtemail.Text))
                cmd.Parameters.Add(New OleDbParameter("Phone_number", txtphone.Text))




                Dim i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("New reminder has been saved successfully!")
                Else
                    MsgBox("Something went wrong!!!")
                End If
                cmd.Dispose()
                myConnection.Close()


                txtclient.Clear()
                txtcompany.Clear()
                txtemail.Clear()
                txtphone.Clear()
                txtspread.Clear()
                MaskedTextBox1.Clear()
                MaskedTextBox2.Clear()

                txtclient.Select()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            AlarmTime = Settingalarm()
            If Timer2.Enabled() = False Then
                Timer2.Start()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            AlarmTime = Settingalarm()
        End Try

    End Sub





    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select Client_name,Company_name,Arriavle_date,Starting_date,Starting_time,Ending_date,Ending_time,Spread_per_day,Email,Phone_number,Status FROM profile WHERE Client_name Like @name"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@name", txtsearch.Text)
            da.SelectCommand = cmd

            da.Fill(dt)

            DataTableView.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try


    End Sub




    Private Sub DataTableView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataTableView.CellClick
        Panelhome.Visible = False
        PanelAbout.Visible = False
        PanelviewReminders.Visible = False
        Paneldetails.Visible = False
        PanelshowDetails.Visible = True
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = False


        'Dim test1 As DateTime = Convert.ToDateTime(DataTableView.CurrentRow.Cells(4).Value.ToString())
        'Dim timetest As String = test1.ToShortTimeString
        'Dim test2 As DateTime = Convert.ToDateTime(DataTableView.CurrentRow.Cells(6).Value.ToString())
        'Dim timetest1 As String = test2.ToShortTimeString
        'Dim testArray(5) As String
        'Dim testArray1(5) As String
        'testArray = Split(timetest)
        'testArray1 = Split(timetest1)


        Dim testArray() As String
        testArray = Split(DataTableView.CurrentRow.Cells(4).Value.ToString())

        Dim testArray1() As String
        testArray1 = Split(DataTableView.CurrentRow.Cells(6).Value.ToString())

        txtclientshow.Text = DataTableView.CurrentRow.Cells(0).Value.ToString()
        txtcompanyshow.Text = DataTableView.CurrentRow.Cells(1).Value.ToString()


        Datearriavle.Value() = DateTime.Parse(DataTableView.CurrentRow.Cells(2).Value.ToString())
        Datestarting.Value() = DateTime.Parse(DataTableView.CurrentRow.Cells(3).Value.ToString())

        startingtimebox.Text() = testArray(1).ToString
        ComboBoxstarting.Text() = testArray(2).ToString
        Dateending.Value = DateTime.Parse(DataTableView.CurrentRow.Cells(5).Value.ToString())

        endingtimebox.Text() = testArray1(1).ToString
        ComboBoxending.Text() = testArray1(2).ToString

        txtspreadshow.Text = DataTableView.CurrentRow.Cells(7).Value.ToString()
        txtemailshow.Text = DataTableView.CurrentRow.Cells(8).Value.ToString()
        txtphoneshow.Text = DataTableView.CurrentRow.Cells(9).Value.ToString()






    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panelhome.Visible = False
        PanelAbout.Visible = False
        PanelviewReminders.Visible = True
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = False

        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile order by Ending_date"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            DataTableView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try


        txtsearch.Text = ""
        txtsearch.Select()

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        currentTime = DateTime.Parse(TimeOfDay.ToShortTimeString)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Dim count As Integer
        count = HomeDataTable.Rows.Count
        If count > 1 Then




            Try
                If DateTime.Parse(AlarmTime.ToShortTimeString) = DateTime.Parse(currentTime.ToShortTimeString) Then

                    Me.Hide()
                    Form2.Show()


                End If
            Catch ex As Exception
                MsgBox(ex.ToString + "484")
                Exit Sub
            End Try

        End If


    End Sub




    Private Function Settingalarm() As DateTime
        Dim alarm As DateTime



        Dim lowest As DateTime = Convert.ToDateTime("11:59 PM")

        Try

            Dim count As Integer
            count = HomeDataTable.Rows.Count
            Dim temp As Integer

            Try

                If count = 2 Then
                    Dim time1 As String = HomeDataTable.Rows(0).Cells(6).Value.ToString
                    alarm = Convert.ToDateTime(time1)

                ElseIf count > 2 Then


                    For temp = 0 To count - 2

                        Dim time2 As String = HomeDataTable.Rows(temp).Cells(6).Value.ToString


                        If Convert.ToDateTime(time2) > Convert.ToDateTime(currentTime.ToString) And lowest > Convert.ToDateTime(time2) Then

                            lowest = Convert.ToDateTime(time2)
                            Form2.ClientName.Text = HomeDataTable.Rows(temp).Cells(0).Value.ToString
                            Form2.compname.Text = HomeDataTable.Rows(temp).Cells(1).Value.ToString
                        End If

                        alarm = lowest
                        alert = lowest
                    Next

                End If
            Catch ex As Exception
                MsgBox(ex.ToString + "498")
            End Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return alarm
    End Function


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        NotifyIcon1.Visible = True
        Me.Hide()
        NotifyIcon1.ShowBalloonTip(3000)
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        NotifyIcon1.Visible = False

    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Dim test As Decimal = Convert.ToDecimal(startingtimebox.Text, System.Globalization.CultureInfo.InvariantCulture)
        'Dim test1 As Decimal = Convert.ToDecimal(endingtimebox.Text, System.Globalization.CultureInfo.InvariantCulture)




        If String.IsNullOrWhiteSpace(txtclientshow.Text) = True Then
            MsgBox("client name can't be empty!!")
            txtclientshow.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtcompanyshow.Text) = True Then
            MsgBox("Company name can't be empty!!")
            txtcompanyshow.Select()
            Exit Sub
        End If

        If startingtimebox.MaskFull = False Then
            MsgBox("starting time can't be empty!!")
            startingtimebox.Select()
            Exit Sub
        End If

        'If test > 12.59 Or (test > 11.59 And test < 12.0) Or (test > 10.59 And test < 11.0) Or (test > 9.59 And test < 10.0) Or (test > 8.59 And test < 9.0) Or (test > 7.59 And test < 8.0) Or (test > 6.59 And test < 7.0) Or (test > 5.59 And test < 6.0) Or (test > 4.59 And test < 5.0) Or (test > 3.59 And test < 4.0) Or (test > 2.59 And test < 3.0) Or (test > 1.59 And test < 2.0) Or (test > 0.59 And test < 1.0) Then
        '    MsgBox("Entered time is invalid!! please enter in the formate of hh:mm")
        '    startingtimebox.Select()
        '    Exit Sub
        'End If

        If endingtimebox.MaskFull = False Then
            MsgBox("ending time can't be empty!!")
            endingtimebox.Select()
            Exit Sub
        End If

        'If test1 > 12.59 Or (test1 > 11.59 And test1 < 12.0) Or (test1 > 10.59 And test1 < 11.0) Or (test1 > 9.59 And test1 < 10.0) Or (test1 > 8.59 And test1 < 9.0) Or (test1 > 7.59 And test1 < 8.0) Or (test1 > 6.59 And test1 < 7.0) Or (test1 > 5.59 And test1 < 6.0) Or (test1 > 4.59 And test1 < 5.0) Or (test1 > 3.59 And test1 < 4.0) Or (test1 > 2.59 And test1 < 3.0) Or (test1 > 1.59 And test1 < 2.0) Or (test1 > 0.59 And test1 < 1.0) Then
        '    MsgBox("Entered time is invalid!! please enter in the formate of hh:mm")

        '    endingtimebox.Select()
        '    Exit Sub
        'End If

        If ComboBoxstarting.Text.Equals("AM") Or ComboBoxstarting.Text.Equals("PM") Then

        Else
            MsgBox("Select either AM or PM!!!")
            ComboBoxstarting.Select()
            Exit Sub
        End If

        If ComboBoxending.Text.Equals("AM") Or ComboBoxending.Text.Equals("PM") Then

        Else
            MsgBox("Select either AM or PM!!!")
            ComboBoxending.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtspreadshow.Text) = True Then
            MsgBox("Nummber can't be null!!")
            txtspreadshow.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtemailshow.Text) = True Then
            MsgBox("email can't be empty!!")
            txtemailshow.Select()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtphoneshow.Text) = True Then
            MsgBox("phone number can't be empty!!")
            txtphoneshow.Select()
            Exit Sub
        End If

        Dim starttime As DateTime = Convert.ToDateTime(startingtimebox.Text + " " + ComboBoxstarting.Text)
        Dim endtime As DateTime = Convert.ToDateTime(endingtimebox.Text + " " + ComboBoxending.Text)
        Try
            myConnection.Open()
            Dim str As String
            Dim temp As String = DataTableView.CurrentRow.Cells(0).Value.ToString()

            str = "update [profile] set [Client_name]='" & txtclientshow.Text & "', [Company_name]='" & txtcompanyshow.Text & "' , [Arriavle_date]='" & Datearriavle.Value.ToShortDateString & "', [Starting_date]='" & Datestarting.Value.ToShortDateString & "', [Starting_time]='" & starttime.ToShortTimeString & "', [Ending_date]='" & Dateending.Value.ToShortDateString & "', [Ending_time]='" & endtime.ToShortTimeString & "', [Spread_per_day]='" & txtspreadshow.Text & "', [Email]='" & txtemailshow.Text & "', [Phone_number]='" & txtphoneshow.Text & "',[Status]=True where Client_name='" & temp & "'"

            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            Dim i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("reminder has been updated successfully!")
            Else
                MsgBox("Something went wrong!!!")
            End If
            cmd.Dispose()
            myConnection.Close()
            txtclientshow.Clear()
            txtcompanyshow.Clear()
            txtemailshow.Clear()
            txtphoneshow.Clear()
            txtspreadshow.Clear()
            startingtimebox.Clear()
            endingtimebox.Clear()

            txtclient.Select()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try


        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile where Ending_date like @name and Status=True order by Ending_time ASC"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@name", LiveDateAndTime.ToShortDateString)
            da.SelectCommand = cmd

            da.Fill(dt)

            HomeDataTable.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try


        Try
            AlarmTime = Settingalarm()
            If Timer2.Enabled() = False Then
                Timer2.Start()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            AlarmTime = Settingalarm()
        End Try

    End Sub




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaskedTextBox1.Mask = "00:00"
        Me.MaskedTextBox1.ValidatingType = GetType(System.DateTime)
        Me.MaskedTextBox2.Mask = "00:00"
        Me.MaskedTextBox2.ValidatingType = GetType(System.DateTime)
        Me.startingtimebox.Mask = "00:00"
        Me.startingtimebox.ValidatingType = GetType(System.DateTime)
        Me.endingtimebox.Mask = "00:00"
        Me.endingtimebox.ValidatingType = GetType(System.DateTime)
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile where Ending_date like @name and Status = True"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@name", LiveDateAndTime.ToShortDateString)
            da.SelectCommand = cmd

            da.Fill(dt)

            HomeDataTable.DataSource = dt


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try

        Dim count As Integer
        count = HomeDataTable.Rows.Count

        If count = 1 Then
            Panelhomedefault.Visible = True
            Panelhome.Visible = False
        Else
            Panelhome.Visible = True
            Panelhomedefault.Visible = False
        End If
        PanelAbout.Visible = False
        PanelviewReminders.Visible = False
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelshowhomedetails.Visible = False




        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            DataTableView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try






    End Sub

    Private Sub HomeDataTable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles HomeDataTable.CellClick
        Panelhome.Visible = False
        PanelAbout.Visible = False
        PanelviewReminders.Visible = False
        Paneldetails.Visible = False
        PanelshowDetails.Visible = False
        Panelhomedefault.Visible = False
        Panelshowhomedetails.Visible = True


        'Dim test1 As DateTime = Convert.ToDateTime(HomeDataTable.CurrentRow.Cells(4).Value.ToString())

        ' Dim test2 As DateTime = Convert.ToDateTime(HomeDataTable.CurrentRow.Cells(6).Value.ToString())

        Dim testArray() As String
        testArray = Split(HomeDataTable.CurrentRow.Cells(4).Value.ToString())

        Dim testArray1() As String
        testArray1 = Split(HomeDataTable.CurrentRow.Cells(6).Value.ToString())


        txthomeclientshow.Text = HomeDataTable.CurrentRow.Cells(0).Value.ToString()
        txthomecompanyshow.Text = HomeDataTable.CurrentRow.Cells(1).Value.ToString()


        arriavledatehomeshow.Value() = DateTime.Parse(HomeDataTable.CurrentRow.Cells(2).Value.ToString())

        startingdatehomeshow.Value() = DateTime.Parse(HomeDataTable.CurrentRow.Cells(3).Value.ToString())

        'startingtimehomeshow.Text() = test1.ToShortTimeString

        startingtimehomeshow.Text() = testArray(1) + " " + testArray(2)

        endingdatehomeshow.Value() = DateTime.Parse(HomeDataTable.CurrentRow.Cells(5).Value.ToString())

        'endingtimehomeshow.Text() = test2.ToShortTimeString
        endingtimehomeshow.Text() = testArray1(1) + " " + testArray1(2)


        txtsperadhomeshow.Text = HomeDataTable.CurrentRow.Cells(7).Value.ToString()
        txtemailhomeshow.Text = HomeDataTable.CurrentRow.Cells(8).Value.ToString()
        txtphonehomeshow.Text = HomeDataTable.CurrentRow.Cells(9).Value.ToString()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("www.ejanakpurtoday.com")

    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            myConnection.Open()
            Dim str As String
            Dim temp As String = HomeDataTable.CurrentRow.Cells(0).Value.ToString()

            str = "update [profile] set [Status]= False where Client_name='" & temp & "'"

            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            Dim i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Reminder has been closed successfully!")
            Else
                MsgBox("Something went wrong!!!")
            End If
            cmd.Dispose()
            myConnection.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            myConnection.Open()
            sql = "Select [Client_name],[Company_name],[Arriavle_date],[Starting_date],[Starting_time],[Ending_date],[Ending_time],[Spread_per_day],[Email],[Phone_number],[Status] from profile where Ending_date like @name and Status = True"
            cmd.Connection = myConnection
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@name", LiveDateAndTime.ToShortDateString)
            da.SelectCommand = cmd

            da.Fill(dt)

            HomeDataTable.DataSource = dt


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConnection.Close()

        End Try

        Try
            AlarmTime = Settingalarm()
            If Timer2.Enabled() = False Then
                Timer2.Start()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            AlarmTime = Settingalarm()
        End Try

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        'MsgBox(testArray(0))
        'MsgBox(testArray(1))
        'MsgBox(testArray(2))

        'Dim test1 As DateTime = Convert.ToDateTime(HomeDataTable.Rows(0).Cells(6).Value.ToString)
        'MsgBox(test1.ToString)
        'Dim timetest As String = test1.ToShortTimeString
        'MsgBox(timetest)


        'Dim alert As DateTime = DateTime.ParseExact(time2, "hh:mm tt", Globalization.DateTimeFormatInfo.InvariantInfo)

        'alert = Convert.ToDateTime(alert.ToShortTimeString)

        'MsgBox(alert)

        Try

            If Timer2.Enabled() = False Then
                Timer2.Start()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            AlarmTime = Settingalarm()
        End Try
        Try
            If Timer2.Enabled() = False Then
                MsgBox("Timer 2 is off")
            Else
                MsgBox("Timer 2 is on")
            End If

            If Timer1.Enabled() = False Then
                MsgBox("Timer 1 is off")
            Else
                MsgBox("Timer 1 is on")
            End If

            MsgBox("Next alarm time is:" + AlarmTime.ToShortTimeString)


        Catch ex As Exception
            MsgBox(ex.ToString + "error in refresh button")
        End Try

    End Sub





    Private Sub MaskedTextBox1_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles MaskedTextBox1.TypeValidationCompleted
        If Not IsDate(Me.MaskedTextBox1.Text) = True Then
            MsgBox("enter the time in hh:mm formate!! and time should be less then 12:59")
            MaskedTextBox1.Clear()
            MaskedTextBox1.Select()
        End If
    End Sub

    Private Sub MaskedTextBox2_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles MaskedTextBox2.TypeValidationCompleted
        If Not IsDate(Me.MaskedTextBox2.Text) = True Then
            MsgBox("enter the time in hh:mm formate!! and time should be less then 12:59")
            MaskedTextBox2.Clear()
            MaskedTextBox2.Select()
        End If
    End Sub

    Private Sub startingtimebox_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles startingtimebox.TypeValidationCompleted
        If Not IsDate(Me.startingtimebox.Text) = True Then
            MsgBox("enter the time in hh:mm formate!! and time should be less then 12:59")
            startingtimebox.Clear()
            startingtimebox.Select()
        End If
    End Sub

    Private Sub endingtimebox_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles endingtimebox.TypeValidationCompleted
        If Not IsDate(Me.endingtimebox.Text) = True Then
            MsgBox("enter the time in hh:mm formate!! and time should be less then 12:59")
            endingtimebox.Clear()
            endingtimebox.Select()
        End If
    End Sub

    Private Sub startingtimebox_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles startingtimebox.MaskInputRejected

    End Sub
End Class
