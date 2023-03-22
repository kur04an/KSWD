using KSWD.Commands;
using KSWD.Model;
using KSWD.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace KSWD.ViewModel
{
    public class ItemVM : INotifyPropertyChanged
    {
        #region Fields
        private ItemList _listOfItems;
        private string _link;
        private CommandBase _addCommand;
        private CommandBase _removeCommand;
        private CommandBase _downloadCommand;
        private SteamProxy _steamProxy;
        #endregion

        #region Propertys
        public ItemList ListOfItems { get => _listOfItems; set => _listOfItems = value; }
        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged("Link");
            }
        }
        public CommandBase AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new CommandBase(obj =>
                    {
                        _listOfItems.AddItem(Link);
                        
                    }));
            }
        }
        public CommandBase RemoveCommand
        {
            get
            {
                return _removeCommand ??
                  (_removeCommand = new CommandBase(obj =>
                  {
                      SteamItem item = obj as SteamItem;
                      if (item != null)
                      {
                          _listOfItems.RemoveItem(item);
                      }
                  },
                 (obj) => _listOfItems.Items.Count > 0));
            }
        }
        public CommandBase DownloadCommand
        {
            get
            {
                return _downloadCommand ??
                    (_downloadCommand = new CommandBase(obj =>
                    {
                        //SteamProxy.DownloadItemList(_listOfItems.Items);
                        _steamProxy.DownloadItems(_listOfItems);
                    }));
            }
        }
        #endregion

        #region ctor
        public ItemVM()
        {
            _link = "https://steamcommunity.com/workshop/";
            _listOfItems = new();
            _steamProxy = new();
        }
        #endregion

        #region INotifyPropertyChanged realization
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

 
        #endregion
    }
}
