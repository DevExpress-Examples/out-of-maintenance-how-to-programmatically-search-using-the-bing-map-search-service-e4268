<!-- default file list -->
*Files to look at*:

* **[MainPage.xaml](./CS/Searching/MainPage.xaml) (VB: [MainPage.xaml](./VB/Searching/MainPage.xaml))**
* [MainPage.xaml.cs](./CS/Searching/MainPage.xaml.cs) (VB: [MainPage.xaml](./VB/Searching/MainPage.xaml))
<!-- default file list end -->
# How to  programmatically search using the Bing Map Search service


<p>This example demonstrates how to create a custom search panel that searches for location, keywords and other parameters using the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapBingSearchDataProvider_Searchtopic"><u>BingSearchDataProvider.Search</u></a> method.<br />
</p><p>To start using the Search panel, specify search parameters (location, keyword, start search index, geographical point coordinates) in the textbox elements. <br />
</p><p>When you handle the <strong>search_Click</strong> event, all parameters are passed to the <strong>Search</strong> method, and you can see the result in the textblock element below. </p><p>The results contain a <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_DisplayNametopic"><u>display name</u></a>, <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_EntityTypetopic"><u>entity type</u></a> and  <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_Addresstopic"><u>address</u></a> associated with the search <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_Locationtopic"><u>location</u></a>. In addition, the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapSearchRequestResult_AlternateSearchRegionstopic"><u>SearchRequestResult.AlternateSearchRegions</u></a> property returns results of searching alternate regions. <br />
</p><p>Moreover, you can see search request information returned by the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapRequestResultBase_ResultCodetopic"><u>RequestResultBase.ResultCode</u></a>, <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapRequestResultBase_FaultReasontopic"><u>RequestResultBase.FaultReason</u></a>  and <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapSearchRequestResult_EstimatedMatchestopic"><u>SearchRequestResult.EstimatedMatches</u></a>  properties. <br />
</p><p>Note that if you run this sample as is, you will get a warning message saying that the specified Bing Maps key is invalid. To learn more about Bing Map keys, please refer to the <a href="http://documentation.devexpress.com/#Silverlight/CustomDocument5975"><u>How to: Get a Bing Maps Key</u></a> tutorial.</p><br />


<br/>


