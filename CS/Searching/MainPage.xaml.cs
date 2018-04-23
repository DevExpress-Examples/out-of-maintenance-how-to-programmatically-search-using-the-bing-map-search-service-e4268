using DevExpress.Xpf.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Searching {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #Search
        private void bSearch_Click(object sender, RoutedEventArgs e) {
            searchProvider.Search(tbKeyword.Text, tbLocation.Text);
        }
        #endregion #Search

        #region #SearchCompletedEvent
        private void searchProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e) {
            if (e.Cancelled) return;

            StringBuilder sb = new StringBuilder();
            SearchRequestResult requestResult = e.RequestResult;
            sb.Append(String.Format("Result Code: {0}\n", requestResult.ResultCode));
            if (String.IsNullOrEmpty(requestResult.FaultReason))
                sb.Append(String.Format("Fault Reason: (none)\n", requestResult.FaultReason));
            else
                sb.Append(String.Format("Fault Reason: {0}\n", requestResult.FaultReason));

            if (e.RequestResult.ResultCode == RequestResultCode.Success) {
                sb.Append(String.Format("Search Location: {0}\n", requestResult.Location));
                sb.Append(String.Format("Search Keyword: {0}\n", requestResult.Keyword));
                sb.Append(String.Format("Estimated Matches: {0}\n", requestResult.EstimatedMatches));
                sb.Append(String.Format("SearchRegion: {0}", ProcessLocationInformation(requestResult.SearchRegion)));
                sb.Append(String.Format("SearchResults:\n{0}", ProcessLocationList(requestResult.SearchResults)));
                sb.Append(String.Format("Alternate Search Regions:\n{0}", ProcessLocationList(requestResult.AlternateSearchRegions)));
            }
            tbResult.Text = sb.ToString();
        }

        string ProcessLocationList(List<LocationInformation> results) {
            if (results == null) return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < results.Count; i++) {
                sb.Append(String.Format("{0}) {1}", i + 1, ProcessLocationInformation(results[i])));
            }
            return sb.ToString();
        }
        #endregion #SearchCompletedEvent

        #region #ProcessLocationInformation
        string ProcessLocationInformation(LocationInformation info) {
            if (info == null) return "";

            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("{0}\n", info.DisplayName));
            sb.Append(String.Format("\tAdress: {0}\n", info.Address));
            sb.Append(String.Format("\tLocation: {0}\n", info.Location));
            return sb.ToString();
        }
        #endregion #ProcessLocationInformation
    }
}