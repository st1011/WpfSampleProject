using MvvmLibrary;
using System;

namespace WpfAppCollectionView.ViewModel
{
    public class SampleItem : NotifyObject
    {
        private static int _uniqueId = 0;
        private static Random _random = new Random();

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _id;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _name;

        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
        private string _address;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }
        private bool _isChecked;

        public static SampleItem CreateDummy()
        {
            _uniqueId++;

            return new SampleItem()
            {
                Id = $"{_uniqueId:D3}",
                Name = Guid.NewGuid().ToString(),
                Address = $"City {_random.Next()}",
            };
        }
    }
}
