using KSWD.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace KSWD.Model
{
    public class ItemList : INotifyPropertyChanged
    {
        #region Fields
        private SteamItem _selectedItem;
        private ObservableCollection<SteamItem> _items;
        private SteamParser _parser;

        const string GameNameXPath = "/html/body/div[1]/div[7]/div[5]/div[1]/div[1]/div[1]/div[2]/div[2]";
        const string ItemNameXPath = "/html/body/div[1]/div[7]/div[5]/div[1]/div[4]/div[5]/div[2]";
        const string GameIDXPath = "/html/body/div[1]/div[7]/div[5]/div[1]/div[3]/a[1]";
        const string AuthorXPath = "/html/body/div[1]/div[7]/div[5]/div[1]/div[3]/a[3]";
        const string ErrorString = "011001010111001001110010011011110111001000001010";
        #endregion

        #region Propertys
        public SteamItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ObservableCollection<SteamItem> Items { get => _items; set => _items = value; }
        #endregion

        #region ctor
        public ItemList()
        {
            _items = new();
            _parser = new();
        }

        #endregion

        #region Methods
        public void AddItem(string link)
        {        
            Items.Add(CreateItem(link));
        }
        public void RemoveItem(SteamItem item)
        {
            Items.Remove(item);
        }

        private SteamItem CreateItem(string link)
        {
            SteamItem item = new SteamItem 
            { 
                Game = _parser.GetContentByXPath(link, GameNameXPath) ?? ErrorString,
                Item = _parser.GetContentByXPath(link, ItemNameXPath) ?? ErrorString,
                GameID = Regex.Replace(_parser.GetAttributeValueByXPath(link, GameIDXPath) ?? ErrorString, @"[^\d]", ""),
                ItemID = Regex.Replace(link, @"[^\d]", ""),
                Author = _parser.GetContentByXPath(link,AuthorXPath) ?? ErrorString
            };
            return item;
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
