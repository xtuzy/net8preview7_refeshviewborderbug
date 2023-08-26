using Microsoft.Maui.Layouts;
using System.Diagnostics;

namespace MauiApp1;

public partial class ScrollViewSizeBug : ContentPage
{
    MyScrollView scrollView;
    public ScrollViewSizeBug()
    {
        InitializeComponent();
        var refreshView = new RefreshView();
        scrollView = new MyScrollView();

        refreshView.Content = scrollView;
        grid.Add(refreshView);
        Grid.SetRow(refreshView, 1);
        scrollView.Content = new ContentViewForScrollView(this)
        {
            Background = new LinearGradientBrush()
            {
                GradientStops =
                {
                    new GradientStop(){Color= Colors.Yellow, Offset=0},
                    new GradientStop(){Color= Colors.Green, Offset=1},
                }
            }
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        CurrentHeight += 50;
        scrollView.Refresh();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        CurrentHeight -= 50;
        scrollView.Refresh();
    }

    double CurrentHeight = 2960564;
    private double GetCurrentHeight()
    {
        return CurrentHeight;
    }

    public class MyScrollView : ScrollView
    {
        public void Refresh()
        {
            this.InvalidateMeasure();
        }
    }

    public class ContentViewForScrollView : Layout
    {
        ScrollViewSizeBug container;
        public ContentViewForScrollView(ScrollViewSizeBug container)
        {
            this.container = container;
            this.IsClippedToBounds = true;

            this.Add(new Border());
        }

        protected override ILayoutManager CreateLayoutManager()
        {
            return new ContentViewLayoutManager(this, container);
        }

        public class ContentViewLayoutManager : LayoutManager
        {
            ScrollViewSizeBug container;
            public ContentViewLayoutManager(Microsoft.Maui.ILayout layout, ScrollViewSizeBug container) : base(layout)
            {
                this.container = container;
            }

            public override Size ArrangeChildren(Rect bounds)
            {
                Debug.WriteLine($"ArrangeChildren Bounds={bounds}");
                return bounds.Size;
            }

            public override Size Measure(double widthConstraint, double heightConstraint)
            {
                var size = new Size(widthConstraint, container.GetCurrentHeight());
                Debug.WriteLine($"Measure Size={size}");
                return size;
            }
        }
    }
}