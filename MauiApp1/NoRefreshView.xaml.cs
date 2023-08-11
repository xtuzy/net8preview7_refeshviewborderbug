using System.Diagnostics;

namespace MauiApp1;

public partial class NoRefreshView : ContentPage
{
	public NoRefreshView()
	{
		InitializeComponent();
        scrollView.SizeChanged += ScrollView_SizeChanged;
        this.SizeChanged += NoRefreshView_SizeChanged;
	}

    private void NoRefreshView_SizeChanged(object sender, EventArgs e)
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