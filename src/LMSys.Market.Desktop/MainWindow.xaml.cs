using LMSys.Market.Desktop.ViewModels;
using System.Windows;

namespace LMSys.Market.Desktop;

public partial class MainWindow : Window
{
    public MainWindow(
        MainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}