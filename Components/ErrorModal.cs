using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Thwip_WPF.Components
{
    public class ErrorModal : Window
    {
        public ErrorModal(string message, Window owner)
        {
            Style = (Style)FindResource("ErrorModalWindow");
            
            Owner = Owner;

            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = owner.Left + (owner.Width - Width) / 2;
            Top = owner.Top + (owner.Height - Height) / 2;

            Content = new StackPanel
            {
                Style = (Style)FindResource("ErrorModalStackPanel"),
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        Style = (Style)FindResource("ErrorModalTextBlock")
                    },
                    new Button
                    {
                        Content = "OK",
                        Style = (Style)FindResource("ErrorModalButton"),
                        Command = new RelayCommand(o => Close())
                    }
                }
            };
        }
    }
}