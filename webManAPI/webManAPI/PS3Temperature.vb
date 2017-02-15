''' <summary>
''' An object containing temperatures for a PlayStation 3 console.
''' </summary>
Public Class PS3Temperature
    ''' <summary>
    ''' Temperature of the Cell microprocessor.
    ''' </summary>
    ''' <returns></returns>
    Property CPU As String
    ''' <summary>
    ''' Temperature of the Reality Synthesizer GPU.
    ''' </summary>
    ''' <returns></returns>
    Property RSX As String

    Sub New(CPU As String, RSX As String)
        Me.CPU = CPU
        Me.RSX = RSX
    End Sub
End Class