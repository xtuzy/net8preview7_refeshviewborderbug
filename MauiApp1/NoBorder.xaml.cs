using System.Diagnostics;

namespace MauiApp1;

public partial class NoBorder : ContentPage
{
	public NoBorder()
	{
		InitializeComponent();
        scrollView.SizeChanged += ScrollView_SizeChanged;
        this.SizeChanged += NoBorder_SizeChanged;
    }

    private void NoBorder_SizeChanged(object sender, EventArgs e)
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