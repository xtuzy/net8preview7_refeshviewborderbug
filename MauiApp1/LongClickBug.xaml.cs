using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
namespace MauiApp1;

public partial class LongClickBug : ContentPage
{
    public LongClickBug()
    {
        InitializeComponent();
        layout.Add(new MyContentView()
        {
            Content = new Grid() { WidthRequest = 100, HeightRequest = 100, BackgroundColor = Colors.Red }
        });
    }
}

public class MyContentView : ContentView
{

}

#if ANDROID
internal class MyContentViewGroup : Microsoft.Maui.Platform.ContentViewGroup
{
    public MyContentViewGroup(Android.Content.Context context) : base(context)
    {
        this.LongClick += MyContentViewGroup_LongClick;
        //this.SetOnLongClickListener(new LongClick());
        this.Click += MyContentViewGroup_Click;
    }

    private void MyContentViewGroup_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Click");
    }

    private void MyContentViewGroup_LongClick(object sender, LongClickEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("LongClick");
    }

    public override bool OnTouchEvent(Android.Views.MotionEvent e)
    {
        base.OnTouchEvent(e);
        return false;
    }
}

/// <summary>
/// Copy from https://github.com/dotnet/maui/blob/main/src/Core/src/Handlers/ContentView/ContentViewHandler.Android.cs
/// </summary>
internal class MyContentViewHandler : ContentViewHandler
{
    protected override ContentViewGroup CreatePlatformView()
    {
        if (VirtualView == null)
        {
            throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a ContentViewGroup");
        }

        var viewGroup = new MyContentViewGroup(Context)
        {
            CrossPlatformLayout = VirtualView
        };

        viewGroup.SetClipChildren(false);

        return viewGroup;
    }
}

class LongClick : Java.Lang.Object, Android.Views.View.IOnLongClickListener
{
    public bool OnLongClick(Android.Views.View v)
    {
        System.Diagnostics.Debug.WriteLine("LongClickListener");
        return true;
    }
}
#endif