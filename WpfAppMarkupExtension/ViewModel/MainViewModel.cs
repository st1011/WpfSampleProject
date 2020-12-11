using MvvmLibrary;
using System;
using System.Collections;
using System.Windows.Markup;
using WpfAppMarkupExtension.Config;

namespace WpfAppMarkupExtension.ViewModel
{
    public class MainViewModel : NotifyObject, IDisposable
    {
        public MainViewModel()
        {
        }

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

    [MarkupExtensionReturnType(typeof(IEnumerable))]
    public class EnumCreateExtension:MarkupExtension
    {
        [ConstructorArgument("prefix")]
        public Type Type { get; set; }

        public EnumCreateExtension(Type type)
        {
            this.Type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Type.IsEnum ? Type.GetEnumValues() : null;
        }
    }
}
