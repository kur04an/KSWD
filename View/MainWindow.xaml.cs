using KSWD.ViewModel;
using System.Windows;

namespace KSWD.View
{
    public partial class MainWindow : Window
    {
        private ItemVM ViewModel = new();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = ViewModel;
        }
        public void OnLinkChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            ViewModel.Link = InAppBrowser.Source.ToString();
        }

    }
}
