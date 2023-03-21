using KSWD.Commands;
using KSWD.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KSWD.ViewModel
{
    public class ItemVM : INotifyPropertyChanged
    {
        #region Fields
        private ItemList _listOfItems;
        private string _link;
        private CommandBase _addCommand;
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
                        ListOfItems.AddItem(Link);
                    }));
            }
        }
        #endregion

        #region ctor
        public ItemVM()
        {
            _link = "https://steamcommunity.com/workshop/";
            ListOfItems = new();
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
