Friend Class Networking

    Friend Shared Async Function SendMagicPacketAsync(MacAddress As String, LanSubnet As String) As Task

        Dim Port As Integer = 9
        Dim udpClient As New System.Net.Sockets.UdpClient
        Dim buf(101) As Char
        Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes(buf)

        For x As Integer = 0 To 5
            sendBytes(x) = CByte("&HFF")
        Next

        MacAddress = MacAddress.Replace("-", "").Replace(":", "")

        Dim i As Integer = 6

        For x As Integer = 1 To 16

            sendBytes(i) = CByte("&H" + MacAddress.Substring(0, 2))

            sendBytes(i + 1) = CByte("&H" + MacAddress.Substring(2, 2))

            sendBytes(i + 2) = CByte("&H" + MacAddress.Substring(4, 2))

            sendBytes(i + 3) = CByte("&H" + MacAddress.Substring(6, 2))

            sendBytes(i + 4) = CByte("&H" + MacAddress.Substring(8, 2))

            sendBytes(i + 5) = CByte("&H" + MacAddress.Substring(10, 2))

            i += 6

        Next

        Await udpClient.SendAsync(sendBytes, sendBytes.Length, LanSubnet, Port)
    End Function

    Friend Shared Sub SendMagicPacket(MacAddress As String, LanSubnet As String)

        Dim Port As Integer = 9
        Dim udpClient As New System.Net.Sockets.UdpClient
        Dim buf(101) As Char
        Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes(buf)

        For x As Integer = 0 To 5
            sendBytes(x) = CByte("&HFF")
        Next

        MacAddress = MacAddress.Replace("-", "").Replace(":", "")

        Dim i As Integer = 6

        For x As Integer = 1 To 16

            sendBytes(i) = CByte("&H" + MacAddress.Substring(0, 2))

            sendBytes(i + 1) = CByte("&H" + MacAddress.Substring(2, 2))

            sendBytes(i + 2) = CByte("&H" + MacAddress.Substring(4, 2))

            sendBytes(i + 3) = CByte("&H" + MacAddress.Substring(6, 2))

            sendBytes(i + 4) = CByte("&H" + MacAddress.Substring(8, 2))

            sendBytes(i + 5) = CByte("&H" + MacAddress.Substring(10, 2))

            i += 6

        Next

        udpClient.Send(sendBytes, sendBytes.Length, LanSubnet, Port)
    End Sub

End Class
