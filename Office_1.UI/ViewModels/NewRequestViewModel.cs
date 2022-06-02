using Office_1.DataLayer.Models;
using Office_1.UI.Commands;
using System.Windows;


namespace Office_1.UI.ViewModels
{
    public class NewRequestViewModel : TabViewModel
    {
        private string _directorName;

        private string _subject;

        private string _content;


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

        ChooseClientCommand ChooseClientCommand { get; set; }

    }
}
