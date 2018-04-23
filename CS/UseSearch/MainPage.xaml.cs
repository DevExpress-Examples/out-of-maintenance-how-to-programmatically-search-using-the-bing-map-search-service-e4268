using System.Windows.Controls;
using System.Windows;
using DevExpress.Xpf.Map;
using System;
using System.Text;

namespace UseSearch {
    public partial class MainPage : UserControl {
        string keywords;
        string location;
        int startingIndex;
        double Longitude;
        double Latitude;

        public MainPage() {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e) {
            GetSearchArguments();
            Search();
        }
        #region #Search
        private void Search() {
            searchDataProvider.Search(keywords, location, new GeoPoint(Latitude, Longitude), startingIndex);
        }
        #endregion #Search


        private void GetSearchArguments() {
            keywords = tbKeywords.Text;
            location = tbLocation.Text;
            startingIndex = String.IsNullOrEmpty(tbStartIndex.Text) ? 0 : Int32.Parse(tbStartIndex.Text);
            Longitude = String.IsNullOrEmpty(tbLongitude.Text) ? 0 : Double.Parse(tbLongitude.Text);
            Latitude = String.IsNullOrEmpty(tbLatitude.Text) ? 0 : Double.Parse(tbLatitude.Text);
        }

        private void searchDataProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e) {
            DisplayResults(e.RequestResult);
        }

        private void DisplayResults(SearchRequestResult requestResult) {
            StringBuilder resultList = new StringBuilder("");
            resultList.Append(String.Format("Result Code: {0}\n", requestResult.ResultCode));
            resultList.Append(String.Format("Fault Reason: {0}\n", requestResult.FaultReason));
            resultList.Append(String.Format("Estimated Matches: {0}\n", requestResult.EstimatedMatches));
            resultList.Append(String.Format("Keyword: {0}\n", requestResult.Keyword));
            resultList.Append(String.Format("Location: {0}\n", requestResult.Location));
            resultList.Append(String.Format("\n"));

            if (requestResult.ResultCode == RequestResultCode.Success) {
                int resCounter = 1;
                foreach (LocationInformation resultInfo in requestResult.SearchResults) {
                    resultList.Append(String.Format("Result {0}:\n", resCounter));
                    resultList.Append(String.Format("Display Name: {0}\n", resultInfo.DisplayName));
                    resultList.Append(String.Format("Entity Type: {0}\n", resultInfo.EntityType));
                    resultList.Append(String.Format("Address: {0}\n", resultInfo.Address));
                    resultList.Append(String.Format("Location: {0}\n", resultInfo.Location));
                    resultList.Append(String.Format("______________________________\n"));

                    resCounter++;
                }
                if (requestResult.SearchRegion != null) {
                    resultList.Append(String.Format("\n===================================\n"));
                    resultList.Append(String.Format("Search region:\n"));
                    resultList.Append(String.Format("Display Name: {0}\n", requestResult.SearchRegion.DisplayName));
                    resultList.Append(String.Format("Entity Type: {0}\n", requestResult.SearchRegion.EntityType));
                    resultList.Append(String.Format("Address: {0}\n", requestResult.SearchRegion.Address));
                    resultList.Append(String.Format("Location: {0}\n", requestResult.SearchRegion.Location));
                }
                resultList.Append(String.Format("\n===================================\n"));
                resultList.Append(String.Format("Alternate search regions:\n\n"));
                resCounter = 1;
                foreach (LocationInformation locationInfo in requestResult.AlternateSearchRegions) {
                    resultList.Append(String.Format("Region {0}:\n", resCounter));
                    resultList.Append(String.Format("Display Name: {0}\n", locationInfo.DisplayName));
                    resultList.Append(String.Format("Entity Type: {0}\n", locationInfo.EntityType));
                    resultList.Append(String.Format("Address: {0}\n", locationInfo.Address));
                    resultList.Append(String.Format("Location: {0}\n", locationInfo.Location));
                    resultList.Append(String.Format("______________________________\n"));
                    resCounter++;
                }
            }

            tbResults.Text = resultList.ToString();
        }

    }
}
