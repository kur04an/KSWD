using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KSWD.Model
{
    public class SteamItem : INotifyPropertyChanged
    {
        #region Fields
        private string _game;
        private string _item;
        private string _gameID;
        private string _itemID;
        private string _author;
        //private string _downloadDate;     work in progress
        //private string _lastUpdateDate;   work in progress
        #endregion

        #region Propertys
        public string Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged("Game");
            }
        }
        public string Item
        {
            get { return _item; }
            set 
            {
                _item = value;
                OnPropertyChanged("Item");
            }
        }
        public string GameID
        {
            get { return _gameID; }
            set
            {
                _gameID = value;
                OnPropertyChanged("GameID");
            }
        }
        public string ItemID
        {
            get { return _itemID; }
            set
            {
                _itemID = value;
                OnPropertyChanged("ItemID");
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
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
