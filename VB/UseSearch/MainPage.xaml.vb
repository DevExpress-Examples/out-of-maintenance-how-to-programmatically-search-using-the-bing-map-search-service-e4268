Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.Windows
Imports DevExpress.Xpf.Map
Imports System
Imports System.Text

Namespace UseSearch
	Partial Public Class MainPage
		Inherits UserControl
		Private keywords As String
		Private location As String
		Private startingIndex As Integer
		Private Longitude As Double
		Private Latitude As Double

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub search_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			GetSearchArguments()
			Search()
		End Sub
		#Region "#Search"
		Private Sub Search()
			searchDataProvider.Search(keywords, location, New GeoPoint(Latitude, Longitude), startingIndex)
		End Sub
		#End Region ' #Search


		Private Sub GetSearchArguments()
			keywords = tbKeywords.Text
			location = tbLocation.Text
			startingIndex = If(String.IsNullOrEmpty(tbStartIndex.Text), 0, Int32.Parse(tbStartIndex.Text))
			Longitude = If(String.IsNullOrEmpty(tbLongitude.Text), 0, Double.Parse(tbLongitude.Text))
			Latitude = If(String.IsNullOrEmpty(tbLatitude.Text), 0, Double.Parse(tbLatitude.Text))
		End Sub

		Private Sub searchDataProvider_SearchCompleted(ByVal sender As Object, ByVal e As BingSearchCompletedEventArgs)
			DisplayResults(e.RequestResult)
		End Sub

		Private Sub DisplayResults(ByVal requestResult As SearchRequestResult)
			Dim resultList As New StringBuilder("")
			resultList.Append(String.Format("Result Code: {0}" & Constants.vbLf, requestResult.ResultCode))
			resultList.Append(String.Format("Fault Reason: {0}" & Constants.vbLf, requestResult.FaultReason))
			resultList.Append(String.Format("Estimated Matches: {0}" & Constants.vbLf, requestResult.EstimatedMatches))
			resultList.Append(String.Format("Keyword: {0}" & Constants.vbLf, requestResult.Keyword))
			resultList.Append(String.Format("Location: {0}" & Constants.vbLf, requestResult.Location))
			resultList.Append(String.Format(Constants.vbLf))

			If requestResult.ResultCode = RequestResultCode.Success Then
				Dim resCounter As Integer = 1
				For Each resultInfo As LocationInformation In requestResult.SearchResults
					resultList.Append(String.Format("Result {0}:" & Constants.vbLf, resCounter))
					resultList.Append(String.Format("Display Name: {0}" & Constants.vbLf, resultInfo.DisplayName))
					resultList.Append(String.Format("Entity Type: {0}" & Constants.vbLf, resultInfo.EntityType))
					resultList.Append(String.Format("Address: {0}" & Constants.vbLf, resultInfo.Address))
					resultList.Append(String.Format("Location: {0}" & Constants.vbLf, resultInfo.Location))
					resultList.Append(String.Format("______________________________" & Constants.vbLf))

					resCounter += 1
				Next resultInfo
				If requestResult.SearchRegion IsNot Nothing Then
					resultList.Append(String.Format(Constants.vbLf & "===================================" & Constants.vbLf))
					resultList.Append(String.Format("Search region:" & Constants.vbLf))
					resultList.Append(String.Format("Display Name: {0}" & Constants.vbLf, requestResult.SearchRegion.DisplayName))
					resultList.Append(String.Format("Entity Type: {0}" & Constants.vbLf, requestResult.SearchRegion.EntityType))
					resultList.Append(String.Format("Address: {0}" & Constants.vbLf, requestResult.SearchRegion.Address))
					resultList.Append(String.Format("Location: {0}" & Constants.vbLf, requestResult.SearchRegion.Location))
				End If
				resultList.Append(String.Format(Constants.vbLf & "===================================" & Constants.vbLf))
				resultList.Append(String.Format("Alternate search regions:" & Constants.vbLf + Constants.vbLf))
				resCounter = 1
				For Each locationInfo As LocationInformation In requestResult.AlternateSearchRegions
					resultList.Append(String.Format("Region {0}:" & Constants.vbLf, resCounter))
					resultList.Append(String.Format("Display Name: {0}" & Constants.vbLf, locationInfo.DisplayName))
					resultList.Append(String.Format("Entity Type: {0}" & Constants.vbLf, locationInfo.EntityType))
					resultList.Append(String.Format("Address: {0}" & Constants.vbLf, locationInfo.Address))
					resultList.Append(String.Format("Location: {0}" & Constants.vbLf, locationInfo.Location))
					resultList.Append(String.Format("______________________________" & Constants.vbLf))
					resCounter += 1
				Next locationInfo
			End If

			tbResults.Text = resultList.ToString()
		End Sub

	End Class
End Namespace
