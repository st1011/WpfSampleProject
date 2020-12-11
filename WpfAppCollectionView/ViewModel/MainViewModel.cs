using MvvmLibrary;
using MvvmLibrary.Collection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppCollectionView.Config;

namespace WpfAppCollectionView.ViewModel
{
    public class MainViewModel : NotifyObject, IDisposable
    {
        // Dictionaryの値でChangedEvent
        // https://stackoverflow.com/questions/4964683/notify-property-changed-on-a-dictionary

        const int _maxViewListCount = 100;



        public MainViewModel()
        {
            var list = Enumerable.Range(0, _maxViewListCount)
                .Select(n =>
                {
                    return SampleItem.CreateDummy();
                });

            ViewListCollection = new RangeObservableCollection<SampleItem>(list);
        }
        public RangeObservableCollection<SampleItem> ViewListCollection { get; set; }

        public DelegateCommand AddViewListCommand
        {
            get
            {
                if (_addViewListCommand == null)
                {
                    _addViewListCommand = new DelegateCommand(
                        () =>
                        {
                            ViewListCollection.Add(SampleItem.CreateDummy());
                        },
                        () => ViewListCollection.Count < _maxViewListCount
                    ); ;
                }

                return _addViewListCommand;
            }
        }
        private DelegateCommand _addViewListCommand;

        public DelegateCommand FillViewListCommand
        {
            get
            {
                if (_fillViewListCommand == null)
                {
                    _fillViewListCommand = new DelegateCommand(
                        () =>
                        {
                            var collection = Enumerable.Range(0, _maxViewListCount - ViewListCollection.Count)
                                .Select(_ => SampleItem.CreateDummy());
                            ViewListCollection.AddRange(collection);
                        },
                        () => ViewListCollection.Count < _maxViewListCount
                    ); ;
                }

                return _fillViewListCommand;
            }
        }
        private DelegateCommand _fillViewListCommand;

        public DelegateCommand ShuffleCommand
        {
            get
            {
                if (_shuffleCommand == null)
                {
                    _shuffleCommand = new DelegateCommand(
                        () =>
                        {
                            for (int i = 0; i < ViewListCollection.Count; i++)
                            {
                                var dummy = SampleItem.CreateDummy();

                                ViewListCollection[i].Id = dummy.Id;
                                ViewListCollection[i].Name = dummy.Name;
                                ViewListCollection[i].Address = dummy.Address;
                            }
                        },
                        () => ViewListCollection.Any()
                    );
                }

                return _shuffleCommand;
            }
        }
        private DelegateCommand _shuffleCommand;

        public DelegateCommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new DelegateCommand(
                        () =>
                        {
                            ViewListCollection.Clear();
                        },
                        () => ViewListCollection.Any()
                    );
                }

                return _clearCommand;
            }
        }
        private DelegateCommand _clearCommand;

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
