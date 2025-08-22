using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KundenKartei.ViewModel;

namespace KundenKartei.Components;

public partial class CustomerDetailControl : UserControl
{
    public CustomerDetailControl()
    {
        InitializeComponent();
        DataContext = new CustomerDetailControlViewModel();
    }
}