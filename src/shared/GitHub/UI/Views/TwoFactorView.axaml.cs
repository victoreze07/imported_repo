using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GitHub.UI.Controls;
using GitCredentialManager.UI.Controls;

namespace GitHub.UI.Views
{
    public partial class TwoFactorView : UserControl, IFocusable
    {
        private SixDigitInput _codeInput;

        public TwoFactorView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            _codeInput = this.FindControl<SixDigitInput>("codeInput");
        }

        public void SetFocus()
        {
            _codeInput.SetFocus();
        }
    }
}
