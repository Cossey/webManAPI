Imports System.Net

Public Class DownloadImageToIcon

    Public Shared Async Function GetIcon(URL As String, IconSize As Size) As Task(Of System.Drawing.Icon)
        Try
            Dim req As HttpWebRequest = WebRequest.Create(URL)
            Dim res As HttpWebResponse = Await req.GetResponseAsync

            Dim im As Image
            im = Image.FromStream(res.GetResponseStream)
            Dim tb = DirectCast(im.GetThumbnailImage(IconSize.Width, IconSize.Height, Nothing, IntPtr.Zero), Bitmap)
            Return Icon.FromHandle(tb.GetHicon)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
