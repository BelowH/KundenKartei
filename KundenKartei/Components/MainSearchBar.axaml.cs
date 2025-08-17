using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace KundenKartei.Components;

public partial class MainSearchBar : UserControl
{
    public MainSearchBar()
    {
        InitializeComponent();
        
        
    }
    
    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        AutoCompleteBox.ClearValue(TextBox.TextProperty);
    }
}