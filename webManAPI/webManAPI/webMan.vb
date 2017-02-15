Imports System.Net
Imports Newtonsoft.Json

''' <summary>
''' Remotely control webManager and the PlayStation 3 console.
''' </summary>
Public Class webMan
    Dim IPAddress As String


    Public Shared Function [Version]() As Version
        Return My.Application.Info.Version
    End Function

    ''' <summary>
    ''' Creates a new instance of this object.
    ''' </summary>
    ''' <param name="IPAddress">The IP Address of the PlayStation 3 console.</param>
    Sub New(IPAddress As String)
        Me.IPAddress = IPAddress
    End Sub

    ''' <summary>
    ''' Launches the loaded game on the PlayStation 3.
    ''' </summary>
    Sub LaunchGame()
        Dim wc As New WebClient
        Dim ln = wc.DownloadString(String.Format("http://{0}/play.ps3", IPAddress))
    End Sub

    ''' <summary>
    ''' Launches the loaded game on the PlayStation 3 via an asynchronous operation using a task object.
    ''' </summary>
    Async Function LaunchGameAsync() As Task(Of Boolean)
        Try
            Dim wc As New WebClient
            Await wc.DownloadStringTaskAsync(String.Format("http://{0}/play.ps3", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Mounts a game and launches it on the PlayStation 3.
    ''' </summary>
    ''' <param name="Game">The game to mount on the PlayStation 3.</param>
    ''' <param name="LaunchGame">Launch the game after mounting it.</param>
    Sub MountGame(Game As PS3GameItem, Optional LaunchGame As Boolean = False)
        Dim wc As New WebClient
        Dim loc = String.Format("http://{0}/mount.ps3{1}", IPAddress, Game.url)
        Dim temp = wc.DownloadString(loc)
        If LaunchGame Then
            Dim ln = wc.DownloadString(String.Format("http://{0}/play.ps3", IPAddress))
        End If
    End Sub

    ''' <summary>
    ''' Mounts a game and launches it on the PlayStation 3 via an asynchronous operation using a task object.
    ''' </summary>
    ''' <param name="Game">The game to mount on the PlayStation 3.</param>
    ''' <param name="LaunchGame">Launch the game after mounting it.</param>
    Async Function MountGameAsync(Game As PS3GameItem, Optional LaunchGame As Boolean = False) As Task(Of Boolean)
        Try
            Dim wc As New WebClient
            Dim loc = String.Format("http://{0}/mount.ps3{1}", IPAddress, Game.url)
            Await wc.DownloadStringTaskAsync(loc)
            If LaunchGame Then
                Await wc.DownloadStringTaskAsync(String.Format("http://{0}/play.ps3", IPAddress))
            End If
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Gets the game library on the PlayStation 3.
    ''' </summary>
    ''' <returns>A List of PS3GameItem objects that contains a list of games on the PlayStation 3 console.</returns>
    Function GetGames() As List(Of PS3GameItem)
        Dim wc As New WebClient
        Try
            wc.DownloadString(String.Format("http://{0}/games.ps3", IPAddress))
            wc.Headers.Add("Referer", "http://192.168.1.111/games.ps3")
            Dim temp = wc.DownloadString(String.Format("http://{0}/dev_hdd0/xmlhost/game_plugin/gamelist.js", IPAddress))
            'http://192.168.1.111/dev_hdd0/xmlhost/game_plugin/gamelist.js

            temp = temp.Substring(9)
            temp = temp.Substring(0, temp.Length - 3)
            temp &= "]"

            wc.Headers.Remove("Referer")
            Dim ob As List(Of PS3GameItem) = JsonConvert.DeserializeObject(Of List(Of PS3GameItem))(temp)
            Return ob
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the game library on the PlayStation 3 via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>A List of PS3GameItem objects that contains a list of games on the PlayStation 3 console.</returns>
    Async Function GetGamesAsync() As Task(Of List(Of PS3GameItem))
        Dim wc As New WebClient
        Try
            Await wc.DownloadStringTaskAsync(String.Format("http://{0}/games.ps3", IPAddress))
            wc.Headers.Add("Referer", String.Format("http://{0}/games.ps3", IPAddress))
            Dim temp = Await wc.DownloadStringTaskAsync(String.Format("http://{0}/dev_hdd0/xmlhost/game_plugin/gamelist.js", IPAddress))

            temp = temp.Substring(9)
            temp = temp.Substring(0, temp.Length - 3)
            temp &= "]"

            wc.Headers.Remove("Referer")
            Dim ob As List(Of PS3GameItem) = JsonConvert.DeserializeObject(Of List(Of PS3GameItem))(temp)
            Return ob
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the temperature of the PlayStation 3 console.
    ''' </summary>
    ''' <returns>A PS3Temperature object that contains the the CPU and RSX temperatures.</returns>
    Function GetTemperature() As PS3Temperature
        Dim wc As New WebClient
        Try
            Dim temp = wc.DownloadString(String.Format("http://{0}/cpursx_ps3", IPAddress))

            Dim startTemp As Integer = temp.LastIndexOf("<font color=""#fff"">") + 19
            Dim endTemp As Integer = temp.LastIndexOf("</a>") - startTemp
            Dim tempsliced As String = temp.Substring(startTemp, endTemp)

            Dim temps As String() = Strings.Split(tempsliced, "|")
            Dim cputmp = temps(0).Substring(temps(0).IndexOf(":") + 2)
            Dim rsxtmp = temps(1).Substring(temps(1).IndexOf(":") + 2)
            cputmp = cputmp.Replace(Chr(194), "").Trim
            rsxtmp = rsxtmp.Replace(Chr(194), "").Trim

            Return New PS3Temperature(cputmp, rsxtmp)
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the temperature of the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>A PS3Temperature object that contains the the CPU and RSX temperatures.</returns>
    Async Function GetTemperatureAsync() As Task(Of PS3Temperature)
        Dim wc As New WebClient
        Try
            Dim temp = Await wc.DownloadStringTaskAsync(String.Format("http://{0}/cpursx_ps3", IPAddress))

            Dim startTemp As Integer = temp.LastIndexOf("<font color=""#fff"">") + 19
            Dim endTemp As Integer = temp.LastIndexOf("</a>") - startTemp
            Dim tempsliced As String = temp.Substring(startTemp, endTemp)

            Dim temps As String() = Strings.Split(tempsliced, "|")
            Dim cputmp = temps(0).Substring(temps(0).IndexOf(":") + 2)
            Dim rsxtmp = temps(1).Substring(temps(1).IndexOf(":") + 2)
            cputmp = cputmp.Replace(Chr(194), "").Trim
            rsxtmp = rsxtmp.Replace(Chr(194), "").Trim

            Return New PS3Temperature(cputmp, rsxtmp)
        Catch we As Exception
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Gets the temperature of the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>A PS3Temperature object that contains the the CPU and RSX temperatures.</returns>
    Function GetTemperatureEx() As PS3TemperatureEx
        Dim wc As New WebClient
        Try
            Dim temp = wc.DownloadString(String.Format("http://{0}/cpursx.ps3", IPAddress))

            Dim startCPUTempC As Integer = temp.IndexOf("CPU:") + 5
            Dim endCPUTempC As Integer = temp.IndexOf("C", startCPUTempC) + 1
            Dim cpuTempC As String = temp.Substring(startCPUTempC, (endCPUTempC - startCPUTempC))
            cpuTempC = cpuTempC.Replace(Chr(194), "").Trim

            Dim startCPUTempF As Integer = temp.IndexOf("CPU:", endCPUTempC) + 5
            Dim endCPUTempF As Integer = temp.IndexOf("F", startCPUTempF) + 1
            Dim cpuTempF As String = temp.Substring(startCPUTempF, (endCPUTempF - startCPUTempF))
            cpuTempF = cpuTempF.Replace(Chr(194), "").Trim

            Dim startRSXTempC As Integer = temp.IndexOf("RSX:") + 5
            Dim endRSXTempC As Integer = temp.IndexOf("C", startRSXTempC) + 1
            Dim rsxTempC As String = temp.Substring(startRSXTempC, (endRSXTempC - startRSXTempC))
            rsxTempC = rsxTempC.Replace(Chr(194), "").Trim

            Dim startRSXTempF As Integer = temp.IndexOf("RSX:", endRSXTempC) + 5
            Dim endRSXTempF As Integer = temp.IndexOf("F", startRSXTempF) + 1
            Dim rsxTempF As String = temp.Substring(startRSXTempF, (endRSXTempF - startRSXTempF))
            rsxTempF = rsxTempF.Replace(Chr(194), "").Trim

            Dim startFanSpeed As Integer = temp.IndexOf("FAN SPEED:") + 11
            Dim endFanSpeed As Integer = temp.IndexOf("%", startFanSpeed)
            Dim FanSpeed As Integer = CInt(temp.Substring(startFanSpeed, (endFanSpeed - startFanSpeed)))

            Return New PS3TemperatureEx(New PS3Temperature(cpuTempC, rsxTempC), New PS3Temperature(cpuTempF, rsxTempF), FanSpeed)
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the temperature of the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>A PS3Temperature object that contains the the CPU and RSX temperatures.</returns>
    Async Function GetTemperatureExAsync() As Task(Of PS3TemperatureEx)
        Dim wc As New WebClient
        Try
            Dim temp = Await wc.DownloadStringTaskAsync(String.Format("http://{0}/cpursx.ps3", IPAddress))

            Dim startCPUTempC As Integer = temp.IndexOf("CPU:") + 5
            Dim endCPUTempC As Integer = temp.IndexOf("C", startCPUTempC) + 1
            Dim cpuTempC As String = temp.Substring(startCPUTempC, (endCPUTempC - startCPUTempC))
            cpuTempC = cpuTempC.Replace(Chr(194), "").Trim

            Dim startCPUTempF As Integer = temp.IndexOf("CPU:", endCPUTempC) + 5
            Dim endCPUTempF As Integer = temp.IndexOf("F", startCPUTempF) + 1
            Dim cpuTempF As String = temp.Substring(startCPUTempF, (endCPUTempF - startCPUTempF))
            cpuTempF = cpuTempF.Replace(Chr(194), "").Trim

            Dim startRSXTempC As Integer = temp.IndexOf("RSX:") + 5
            Dim endRSXTempC As Integer = temp.IndexOf("C", startRSXTempC) + 1
            Dim rsxTempC As String = temp.Substring(startRSXTempC, (endRSXTempC - startRSXTempC))
            rsxTempC = rsxTempC.Replace(Chr(194), "").Trim

            Dim startRSXTempF As Integer = temp.IndexOf("RSX:", endRSXTempC) + 5
            Dim endRSXTempF As Integer = temp.IndexOf("F", startRSXTempF) + 1
            Dim rsxTempF As String = temp.Substring(startRSXTempF, (endRSXTempF - startRSXTempF))
            rsxTempF = rsxTempF.Replace(Chr(194), "").Trim

            Dim startFanSpeed As Integer = temp.IndexOf("FAN SPEED:") + 11
            Dim endFanSpeed As Integer = temp.IndexOf("%", startFanSpeed)
            Dim FanSpeed As Integer = CInt(temp.Substring(startFanSpeed, (endFanSpeed - startFanSpeed)))

            Return New PS3TemperatureEx(New PS3Temperature(cpuTempC, rsxTempC), New PS3Temperature(cpuTempF, rsxTempF), FanSpeed)
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Unmounts the current game from WebMan via an asynchronous operation using a task object.
    ''' 
    ''' Warning: Doing this while playing the game will cause the console to freeze.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Async Function UnmountGameAsync() As Task(Of Boolean)
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = Await wc.DownloadDataTaskAsync(String.Format("http://{0}/mount.ps3/unmount", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Shuts down the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Async Function ShutdownAsync() As Task(Of Boolean)
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = Await wc.DownloadDataTaskAsync(String.Format("http://{0}/shutdown.ps3", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Restarts the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Async Function RestartAsync() As Task(Of Boolean)
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = Await wc.DownloadDataTaskAsync(String.Format("http://{0}/restart.ps3", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Unmounts the current game from WebMan.
    ''' 
    ''' Warning: Doing this while playing the game will cause the console to freeze.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Function UnmountGame() As Boolean
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = wc.DownloadData(String.Format("http://{0}/mount.ps3/unmount", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Shuts down the PlayStation 3 console.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Function Shutdown() As Boolean
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = wc.DownloadData(String.Format("http://{0}/shutdown.ps3", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Restarts the PlayStation 3 console.
    ''' </summary>
    ''' <returns>True if successful or false if an exception occurs.</returns>
    Function Restart() As Boolean
        Dim wc As New WebClient
        Try
            Dim mba As Byte() = wc.DownloadData(String.Format("http://{0}/restart.ps3", IPAddress))
            Return True
        Catch we As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Gets information about the PlayStation 3 console.
    ''' </summary>
    ''' <returns>A PS3Info object that contains Free Space, Version, Memory Usage and Uptime.</returns>
    Function GetInfo() As PS3Info
        Try
            Dim wc As New WebClient
            Dim temp = wc.DownloadString(String.Format("http://{0}/cpursx.ps3", IPAddress))

            Dim startUptime As Integer = temp.IndexOf("&#8986;</label>") + 16
            Dim endUptime As Integer = temp.IndexOf("<hr>", startUptime) - startUptime
            Dim Uptime As String = temp.Substring(startUptime, endUptime)

            Dim DayHrs As String() = Uptime.Split(" ")
            Dim HMS As String() = DayHrs(1).Split(":")

            Dim UptimeProcessed As New TimeSpan(CInt(DayHrs(0).TrimEnd("d"c)), CInt(HMS(0)), CInt(HMS(1)), CInt(HMS(2)))

            Dim startFirmware As Integer = temp.LastIndexOf("""/setup.ps3"">") + 13
            Dim endFirmware As Integer = temp.IndexOf("<br>", startFirmware) - startFirmware
            Dim Firmware As String = temp.Substring(startFirmware, endFirmware)

            Dim startMemory As Integer = temp.LastIndexOf("MEM:") + 5
            Dim endMemory As Integer = temp.IndexOf("<br>", startMemory) - startMemory
            Dim Memory As String = temp.Substring(startMemory, endMemory)

            Dim startHardDiskFree As Integer = temp.LastIndexOf("HDD:") + 5
            Dim endHardDiskFree As Integer = temp.IndexOf("</a>", startHardDiskFree) - startHardDiskFree
            Dim HardDiskFree As String = temp.Substring(startHardDiskFree, endHardDiskFree)

            Return New PS3Info(Memory, HardDiskFree, UptimeProcessed, Firmware)
        Catch we As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets information about the PlayStation 3 console via an asynchronous operation using a task object.
    ''' </summary>
    ''' <returns>A PS3Info object that contains Free Space, Version, Memory Usage and Uptime.</returns>
    Async Function GetInfoAsync() As Task(Of PS3Info)
        Try
            Dim wc As New WebClient
            Dim temp = Await wc.DownloadStringTaskAsync(String.Format("http://{0}/cpursx.ps3", IPAddress))

            Dim startUptime As Integer = temp.IndexOf("&#8986;</label>") + 16
            Dim endUptime As Integer = temp.IndexOf("<hr>", startUptime) - startUptime
            Dim Uptime As String = temp.Substring(startUptime, endUptime)

            Dim DayHrs As String() = Uptime.Split(" ")
            Dim HMS As String() = DayHrs(1).Split(":")

            Dim UptimeProcessed As New TimeSpan(CInt(DayHrs(0).TrimEnd("d"c)), CInt(HMS(0)), CInt(HMS(1)), CInt(HMS(2)))

            Dim startFirmware As Integer = temp.LastIndexOf("""/setup.ps3"">") + 13
            Dim endFirmware As Integer = temp.IndexOf("<br>", startFirmware) - startFirmware
            Dim Firmware As String = temp.Substring(startFirmware, endFirmware)

            Dim startMemory As Integer = temp.LastIndexOf("MEM:") + 5
            Dim endMemory As Integer = temp.IndexOf("<br>", startMemory) - startMemory
            Dim Memory As String = temp.Substring(startMemory, endMemory)

            Dim startHardDiskFree As Integer = temp.LastIndexOf("HDD:") + 5
            Dim endHardDiskFree As Integer = temp.IndexOf("</a>", startHardDiskFree) - startHardDiskFree
            Dim HardDiskFree As String = temp.Substring(startHardDiskFree, endHardDiskFree)

            Return New PS3Info(Memory, HardDiskFree, UptimeProcessed, Firmware)
        Catch we As Exception
            Return Nothing
        End Try
    End Function

End Class
