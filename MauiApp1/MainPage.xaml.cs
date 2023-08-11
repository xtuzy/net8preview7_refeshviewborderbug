using System.Diagnostics;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //helloLabel
            scrollView.SizeChanged += ScrollView_SizeChanged;
            this.SizeChanged += MainPage_SizeChanged; ;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this + "_SizeChanged");
        }

        private void ScrollView_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this + "_ScrollView_SizeChanged");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
        }
    }

}
