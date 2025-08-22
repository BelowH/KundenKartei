using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using KundenKartei.ViewModel;

namespace KundenKartei.Components;

public partial class CustomerSearchControl : UserControl
{
    public CustomerSearchControl()
    {
        InitializeComponent();
        DataContext = new CustomerSearchControlViewModel();
    }

    private void TextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is CustomerSearchControlViewModel customerSearchControl)
        {
            customerSearchControl.SearchCustomer(textBox.Text ?? "");
        }
    }
    
    private void ClearInput(object? sender, PointerPressedEventArgs e)
    {
        SearchBar.Clear();
    }

    private void DeleteItemPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is ContentPresenter contentPresenter && DataContext is CustomerSearchControlViewModel customerSearchControl)
        {
            
        }
    }
}