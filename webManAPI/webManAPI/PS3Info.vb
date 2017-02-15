
Public Class PS3Info
    ''' <summary>
    ''' The amount of RAM in use.
    ''' </summary>
    ''' <returns></returns>
    Property Memory As String
    ''' <summary>
    ''' The free space remaining on the internal hard disk.
    ''' </summary>
    ''' <returns></returns>
    Property HardDiskFree As String
    ''' <summary>
    ''' The system uptime.
    ''' </summary>
    ''' <returns>Returns a TimeSpan object.</returns>
    Property UpTime As TimeSpan
    ''' <summary>
    ''' The firmware version.
    ''' </summary>
    ''' <returns></returns>
    Property Firmware As String

    Sub New(Memory As String, HardDiskFree As String, Uptime As TimeSpan, Firmware As String)
        Me.Memory = Memory
        Me.HardDiskFree = HardDiskFree
        Me.UpTime = Uptime
        Me.Firmware = Firmware
    End Sub

End Class