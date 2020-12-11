using MvvmLibrary;
using System;
using WpfAppMenu.Config;

namespace WpfAppMenu.ViewModel
{
    public class MainViewModel : NotifyObject, IDisposable
    {
        public MainViewModel()
        {
            UserInputText = CommonConfig.Instance.Text;
        }

        public string UserInputText
        {
            get { return _userInputText; }
            set
            {
                if (SetProperty(ref _userInputText, value))
                {
                    CommonConfig.Instance.Text = _userInputText;
                    ConvertedText = _userInputText.ToUpper();
                }
            }
        }
        string _userInputText;

        public string ConvertedText
        {
            get { return _convertedText; }
            set
            {
                SetProperty(ref _convertedText, value);
            }
        }
        string _convertedText = "";

        public DelegateCommand ClearInputCommand
        {
            get
            {
                if (_clearInputCommand == null)
                {
                    _clearInputCommand = new DelegateCommand(
                        _ => UserInputText = string.Empty,
                        _ => !string.IsNullOrEmpty(UserInputText)
                    );
                }

                return _clearInputCommand;
            }
        }
        private DelegateCommand _clearInputCommand;

        #region Dispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                    CommonConfig.Instance?.Dispose();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~MainViewModel()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
