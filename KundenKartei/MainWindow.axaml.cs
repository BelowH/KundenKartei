using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using KundenKartei.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace KundenKartei;

public partial class MainWindow : Window
{
  
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    
}