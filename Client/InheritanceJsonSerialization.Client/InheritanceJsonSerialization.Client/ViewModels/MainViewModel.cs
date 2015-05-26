using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using InheritanceJsonSerialization.Client.Models;
using InheritanceJsonSerialization.Client.Services;

namespace InheritanceJsonSerialization.Client.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IHttpHandler _httpHandler;
        private ObservableCollection<ParentClass> _dataItems;
        private bool _isLoading;

        public MainViewModel(IHttpHandler httpHandler)
        {
            if (httpHandler == null) throw new ArgumentNullException("httpHandler");
            _httpHandler = httpHandler;
            DataItems = new ObservableCollection<ParentClass>();
        }

        public ObservableCollection<ParentClass> DataItems
        {
            get { return _dataItems; }
            set
            {
                if (value == _dataItems) return;
                _dataItems = value;
                RaisePropertyChanged(() => DataItems);
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (value == _isLoading) return;
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public async Task Init()
        {
            IsLoading = true;
            var dataItems = await _httpHandler.GetData();
            DataItems.Clear();
            foreach (var dataItem in dataItems)
            {
                DataItems.Add(dataItem);
            }
            IsLoading = false;
        }
    }
}
