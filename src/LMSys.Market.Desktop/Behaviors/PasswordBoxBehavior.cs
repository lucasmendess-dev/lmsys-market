using System.Windows;
using System.Windows.Controls;

namespace LMSys.Market.Desktop.Behaviors;

public static class PasswordBoxBehavior
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordBoxBehavior),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions
                    .BindsTwoWayByDefault,
                OnPasswordChanged));

    public static readonly DependencyProperty IsEnabledProperty =
        DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(PasswordBoxBehavior),
            new PropertyMetadata(
                false,
                OnIsEnabledChanged));

    private static bool _isUpdating;

    public static string GetPassword(
        DependencyObject obj)
    {
        return (string)obj.GetValue(
            PasswordProperty);
    }

    public static void SetPassword(
        DependencyObject obj,
        string value)
    {
        obj.SetValue(
            PasswordProperty,
            value);
    }

    public static bool GetIsEnabled(
        DependencyObject obj)
    {
        return (bool)obj.GetValue(
            IsEnabledProperty);
    }

    public static void SetIsEnabled(
        DependencyObject obj,
        bool value)
    {
        obj.SetValue(
            IsEnabledProperty,
            value);
    }

    private static void OnIsEnabledChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        if (d is not PasswordBox passwordBox)
            return;

        if ((bool)e.OldValue)
        {
            passwordBox.PasswordChanged -=
                PasswordBox_PasswordChanged;
        }

        if ((bool)e.NewValue)
        {
            passwordBox.PasswordChanged +=
                PasswordBox_PasswordChanged;
        }
    }

    private static void OnPasswordChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        if (_isUpdating)
            return;

        if (d is not PasswordBox passwordBox)
            return;

        var newPassword =
            e.NewValue as string ??
            string.Empty;

        if (passwordBox.Password == newPassword)
            return;

        passwordBox.Password = newPassword;
    }

    private static void PasswordBox_PasswordChanged(
        object sender,
        RoutedEventArgs e)
    {
        if (sender is not PasswordBox passwordBox)
            return;

        _isUpdating = true;

        SetPassword(
            passwordBox,
            passwordBox.Password);

        _isUpdating = false;
    }
}