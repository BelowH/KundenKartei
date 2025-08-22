using System;
using System.Collections.Generic;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using KundenKartei.Domain;
using KundenKartei.State;
using KundenKartei.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using static KundenKartei.Domain.EnumCollection;

namespace KundenKartei;

public class MainWindowViewModel : ViewModelBase
{
    
    private Dictionary<SubMask, ViewModelBase> _subMasks = new()
    {
        { SubMask.NewCustomer, new NewCustomerControlViewModel() },
        { SubMask.CustomerDetail , new CustomerDetailControlViewModel()}
    };
    
    
    private ViewModelBase? _currentContent;
    public ViewModelBase CurrentContent
    {
        get => _currentContent!;
        set => SetProperty(ref _currentContent, value);
    }
    
    private ViewModelBase? _previousContent;
    
    
#region TabStyling

    public enum SelectedTab
    {
        CUSTOMER,
        EVENT,
        SALES
    }

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

    private readonly SolidColorBrush _selectedColor = (Application.Current!.FindResource("Orange") as SolidColorBrush)!; 
    private readonly SolidColorBrush _unselectedColor = (Application.Current!.FindResource("Yellow") as SolidColorBrush)!;
    
    private readonly CornerRadius _unselectedCornerRadius = new CornerRadius(16);
    private readonly CornerRadius _selectedCornerRadius = new CornerRadius(16, 16, 0, 0);
    
    
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
    
#endregion


    private readonly GlobalDisplayState _globalDisplayState;

    public MainWindowViewModel()
    {
        IServiceProvider serviceProvider = ((App)Application.Current!).ServiceProvider!;
        _globalDisplayState = serviceProvider.GetRequiredService<GlobalDisplayState>();
        
        _globalDisplayState.OnSubMaskChanged += OnSubmaskChanged;
        _globalDisplayState.OnNavigateToCustomerDetail += GlobalDisplayStateOnOnNavigateToCustomerCustomerDetail;
        _globalDisplayState.OnBack += OnBack;
        
        SelectedTabItem = SelectedTab.CUSTOMER;
        CurrentContent = new CustomerSearchControlViewModel();

    }

    private void GlobalDisplayStateOnOnNavigateToCustomerCustomerDetail(object? sender, string id)
    {
        _previousContent = CurrentContent;
        CurrentContent = new CustomerDetailControlViewModel(){ CustomerId = id};
    }

    private void OnBack(object? sender, EventArgs e)
    {
        if (_previousContent != null)
        {
            CurrentContent = _previousContent;
            _previousContent = null;
        }
    }

    private void OnSubmaskChanged(object? sender, SubMask maskToChangeTo)
    {
        _previousContent = CurrentContent;
        CurrentContent = _subMasks[maskToChangeTo];
    }
}