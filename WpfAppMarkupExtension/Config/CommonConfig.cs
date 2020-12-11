using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfAppMarkupExtension.Config
{
    [Serializable]
    public class CommonConfig : IDisposable
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public double Float { get; set; }

        public static CommonConfig Instance { get; private set; }
        private static readonly string _saveFilePath = typeof(CommonConfig).Namespace + ".sav";
        private bool disposedValue;

        static CommonConfig()
        {
            Instance = Load(_saveFilePath);
        }

        public bool Save()
        {
            try
            {
                using (var fs = new FileStream(_saveFilePath, FileMode.Create))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, Instance);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static CommonConfig Load(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    return bf.Deserialize(fs) as CommonConfig;
                }
            }
            catch (Exception)
            {
                return new CommonConfig();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                    Instance?.Save();
                    Instance = null;
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~GlobalConfig()
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
    }
}
