namespace TodoAppMaui.Pages.MenuPage;

public partial class FlyoutPageNavigation : FlyoutPage
{
	public FlyoutPageNavigation()
	{
		InitializeComponent();
        flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            //DisplayAlert("Hello", $"{item.TargetType}", "ok");
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;
        }
        
    }
}