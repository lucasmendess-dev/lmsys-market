using LMSys.Market.Desktop.ViewModels;
using System.Windows;

namespace LMSys.Market.Desktop.Views;

public partial class LoginWindow : Window
{
    public LoginWindow(
        LoginViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}