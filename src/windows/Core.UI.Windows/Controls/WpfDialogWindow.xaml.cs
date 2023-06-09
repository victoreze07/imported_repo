﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using GitCredentialManager.UI.Controls;
using GitCredentialManager.UI.ViewModels;

namespace GitCredentialManager.UI.Windows.Controls
{
    public partial class WpfDialogWindow : Window
    {
        private readonly UserControl _view;

        public WpfDialogWindow(UserControl view)
        {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;

            _view = view;
            ContentHolder.Content = _view;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is WindowViewModel vm)
            {
                vm.Accepted += (s, _) =>
                {
                    DialogResult = true;
                    Close();
                };

                vm.Canceled += (s, _) =>
                {
                    DialogResult = false;
                    Close();
                };
            }

            if (_view is IFocusable focusable)
            {
                // Send a focus request to the child view on idle
                System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (Action)(() => focusable.SetFocus()));
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is WindowViewModel vm)
            {
                vm.Cancel();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
