Public Class PS3TemperatureEx

    Property DegC As PS3Temperature
    Property DegF As PS3Temperature
    Property FanSpeed As Integer

    Sub New(DegC As PS3Temperature, DegF As PS3Temperature, Speed As Integer)
        Me.DegC = DegC
        Me.DegF = DegF
        Me.FanSpeed = Speed
    End Sub
End Class