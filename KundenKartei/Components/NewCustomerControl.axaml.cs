using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KundenKartei.ViewModel;

namespace KundenKartei.Components;

public partial class NewCustomerControl : UserControl
{
    public NewCustomerControl()
    {
        InitializeComponent();
        DataContext = new NewCustomerControlViewModel();
    }
}