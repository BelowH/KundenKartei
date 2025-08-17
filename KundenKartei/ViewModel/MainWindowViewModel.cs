using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using KundenKartei.ViewModel;

namespace KundenKartei;

public class MainWindowViewModel : ViewModelBase
{

    public enum SelectedTab
    {
        CUSTOMER,
        EVENT,
        SALES
    }
    
    private readonly SolidColorBrush _selectedColor = (Application.Current!.FindResource("Orange") as SolidColorBrush)!; 
    private readonly SolidColorBrush _unselectedColor = (Application.Current!.FindResource("Yellow") as SolidColorBrush)!;
    
    private readonly CornerRadius _unselectedCornerRadius = new CornerRadius(16);
    private readonly CornerRadius _selectedCornerRadius = new CornerRadius(16, 16, 0, 0);
    
    private SelectedTab _selectedTab;
    public SelectedTab SelectedTabItem
    {
        get => _selectedTab;
        set
        {
            if (SetProperty(ref _selectedTab, value))
            {
                OnPropertyChanged(nameof(CustomerBorderHeight));
                OnPropertyChanged(nameof(CustomerCornerRadius));
                OnPropertyChanged(nameof(CustomerColor));
                OnPropertyChanged(nameof(CustomerIcon));
                
                OnPropertyChanged(nameof(EventBorderHeight));
                OnPropertyChanged(nameof(EventCornerRadius));
                OnPropertyChanged(nameof(EventColor));
                OnPropertyChanged(nameof(EventIcon));
                
                OnPropertyChanged(nameof(SalesBorderHeight));
                OnPropertyChanged(nameof(SalesCornerRadius));
                OnPropertyChanged(nameof(SalesColor));
                OnPropertyChanged(nameof(SalesIcon));
            }
        }
    }
    
    private ViewModelBase? _currentContent;
    public ViewModelBase CurrentContent
    {
        get => _currentContent!;
        set => SetProperty(ref _currentContent, value);
    }
    
    public int CustomerBorderHeight => SelectedTabItem == SelectedTab.CUSTOMER ? 70 : 48;
    public CornerRadius CustomerCornerRadius => SelectedTabItem == SelectedTab.CUSTOMER ? _selectedCornerRadius : _unselectedCornerRadius;
    public SolidColorBrush CustomerColor => SelectedTabItem == SelectedTab.CUSTOMER ? _selectedColor : _unselectedColor;
    public DataTemplate CustomerIcon => (SelectedTabItem == SelectedTab.CUSTOMER ? Application.Current?.FindResource("CustomerSelectedIcon") as DataTemplate : Application.Current?.FindResource("CustomerIcon") as DataTemplate)!;
    
    
    public int EventBorderHeight => SelectedTabItem == SelectedTab.EVENT ? 70 : 48;
    public CornerRadius EventCornerRadius => SelectedTabItem == SelectedTab.EVENT ? _selectedCornerRadius : _unselectedCornerRadius;
    public SolidColorBrush EventColor => SelectedTabItem == SelectedTab.EVENT ? _selectedColor : _unselectedColor;
    public DataTemplate EventIcon => (SelectedTabItem == SelectedTab.EVENT ? Application.Current?.FindResource("EventSelectedIcon") as DataTemplate : Application.Current?.FindResource("EventIcon") as DataTemplate)!;
    
    public int SalesBorderHeight => SelectedTabItem == SelectedTab.SALES ? 70 : 48;
    public CornerRadius SalesCornerRadius => SelectedTabItem == SelectedTab.SALES ? _selectedCornerRadius : _unselectedCornerRadius;
    public SolidColorBrush SalesColor => SelectedTabItem == SelectedTab.SALES ? _selectedColor : _unselectedColor;
    public DataTemplate SalesIcon => (SelectedTabItem == SelectedTab.SALES ? Application.Current?.FindResource("SaleSelectedIcon") as DataTemplate : Application.Current?.FindResource("SaleIcon") as DataTemplate)!;
    
    public MainWindowViewModel()
    {
        SelectedTabItem = SelectedTab.CUSTOMER;
        CurrentContent = new CustomerSearchControlViewModel();
    }
    
    public void ShowCustomer()
    {
        SelectedTabItem = SelectedTab.CUSTOMER;
        CurrentContent = new CustomerSearchControlViewModel();
    }

    public void ShowEvent()
    {
        SelectedTabItem = SelectedTab.EVENT;
        CurrentContent = new EventSearchControlViewModel();
    }

    public void ShowSales()
    {
        SelectedTabItem = SelectedTab.SALES;
        CurrentContent = new SalesSearchControlViewModel();
    }
}