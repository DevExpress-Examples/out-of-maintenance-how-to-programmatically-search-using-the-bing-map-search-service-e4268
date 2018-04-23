Imports DevExpress.Xpf.Map
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace Searching
    Partial Public Class MainPage
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#Search"
        Private Sub bSearch_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            searchProvider.Search(tbKeyword.Text, tbLocation.Text)
        End Sub
        #End Region ' #Search

        #Region "#SearchCompletedEvent"
        Private Sub searchProvider_SearchCompleted(ByVal sender As Object, ByVal e As BingSearchCompletedEventArgs)
            If e.Cancelled Then
                Return
            End If

            Dim sb As New StringBuilder()
            Dim requestResult As SearchRequestResult = e.RequestResult
            sb.Append(String.Format("Result Code: {0}" & ControlChars.Lf, requestResult.ResultCode))
            If String.IsNullOrEmpty(requestResult.FaultReason) Then
                sb.Append(String.Format("Fault Reason: (none)" & ControlChars.Lf, requestResult.FaultReason))
            Else
                sb.Append(String.Format("Fault Reason: {0}" & ControlChars.Lf, requestResult.FaultReason))
            End If

            If e.RequestResult.ResultCode = RequestResultCode.Success Then
                sb.Append(String.Format("Search Location: {0}" & ControlChars.Lf, requestResult.Location))
                sb.Append(String.Format("Search Keyword: {0}" & ControlChars.Lf, requestResult.Keyword))
                sb.Append(String.Format("Estimated Matches: {0}" & ControlChars.Lf, requestResult.EstimatedMatches))
                sb.Append(String.Format("SearchRegion: {0}", ProcessLocationInformation(requestResult.SearchRegion)))
                sb.Append(String.Format("SearchResults:" & ControlChars.Lf & "{0}", ProcessLocationList(requestResult.SearchResults)))
                sb.Append(String.Format("Alternate Search Regions:" & ControlChars.Lf & "{0}", ProcessLocationList(requestResult.AlternateSearchRegions)))
            End If
            tbResult.Text = sb.ToString()
        End Sub

        Private Function ProcessLocationList(ByVal results As List(Of LocationInformation)) As String
            If results Is Nothing Then
                Return ""
            End If

            Dim sb As New StringBuilder()
            For i As Integer = 0 To results.Count - 1
                sb.Append(String.Format("{0}) {1}", i + 1, ProcessLocationInformation(results(i))))
            Next i
            Return sb.ToString()
        End Function
        #End Region ' #SearchCompletedEvent

        #Region "#ProcessLocationInformation"
        Private Function ProcessLocationInformation(ByVal info As LocationInformation) As String
            If info Is Nothing Then
                Return ""
            End If

            Dim sb As New StringBuilder()

            sb.Append(String.Format("{0}" & ControlChars.Lf, info.DisplayName))
            sb.Append(String.Format(ControlChars.Tab & "Adress: {0}" & ControlChars.Lf, info.Address))
            sb.Append(String.Format(ControlChars.Tab & "Location: {0}" & ControlChars.Lf, info.Location))
            Return sb.ToString()
        End Function
        #End Region ' #ProcessLocationInformation
    End Class
End Namespace