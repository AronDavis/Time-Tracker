Imports System
Imports Hotkeys


Public Class Sub_Main

    Dim timer As Timer = New Timer
    Dim xmlDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument
    Dim xmlTodaysLog As System.Xml.XmlDocument

    Const strDirectory As String = "@C:\Program Files\TimeTracker\"
    Dim strTodaysLogFileName As String = "TimeTrackerLog-" & Now.ToString("yyyy") & "-" & Now.ToString("MM") & "-" & Now.ToString("dd")

    Dim ghk As Hotkeys.GlobalHotkey = New Hotkeys.GlobalHotkey(Constants.CTRL + Constants.ALT + Constants.SHIFT, Keys.O, this)

    Sub Main()
        Application.Run()
    End Sub

    Sub StartUp()
        System.IO.Directory.CreateDirectory(strDirectory)

        If System.IO.Directory.Exists(strDirectory & strTodaysLogFileName) Then
            xmlTodaysLog.Load(strDirectory & strTodaysLogFileName)

        End If
    End Sub

End Class
