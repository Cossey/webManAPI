Imports System.ComponentModel

Module EnumExtensions

    <Runtime.CompilerServices.Extension>
    Public Function ToDescriptionString(val As [Enum]) As String
        Dim attributes As DescriptionAttribute() = DirectCast(val.[GetType]().GetField(val.ToString()).GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        Return If(attributes.Length > 0, attributes(0).Description, String.Empty)
    End Function

End Module
