using Office_1.DataLayer.Models;
using Office_1.UI.Commands;
using System.Windows;
using System.Windows.Input;

namespace Office_1.UI.ViewModels
{
    public class NewRequestViewModel : TabViewModel
    {
        private string _directorName;

        private string _subject;

        private string _content;

        private Client _selectedItem;


        public NewRequestViewModel()
        {
            GridVisibility = Visibility.Hidden;
            ChooseClientCommand = new ChooseClientCommand(this);
        }

        public string DirectorName
        {
            get => _directorName;
            set
            {
                if (value != _directorName)
                {
                    _directorName = value;
                    OnPropertyChanged(nameof(DirectorName));
                }
            }
        }

        public string Subject
        {
            get => _subject;
            set
            {
                if (value != _subject)
                {
                    _subject = value;
                    OnPropertyChanged(nameof(Subject));
                }
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                if (value != _content)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }

        public Client SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public ICommand ChooseClientCommand { get; set; }
    }
}
