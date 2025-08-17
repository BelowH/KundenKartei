using Avalonia.Controls;
using Avalonia.Interactivity;

namespace KundenKartei;

public partial class MainWindow : Window
{
  
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    
}