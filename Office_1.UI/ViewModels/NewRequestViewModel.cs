using Office_1.DataLayer.Models;
using System.Windows;


namespace Office_1.UI.ViewModels
{
    public class NewRequestViewModel : TabViewModel
    {
        private string _directorName;

        private string _subject;

        private string _content;

        private string _resolution;

        private Status _status;

        private string _remark;


        public NewRequestViewModel()
        {
            GridVisibility = Visibility.Hidden;
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

        public string Resolution
        {
            get => _resolution;
            set
            {
                if (value != _resolution)
                {
                    _resolution = value;
                    OnPropertyChanged(nameof(Resolution));
                }
            }
        }

        public Status Status
        {
            get => _status;
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string Remark
        {
            get => _remark;
            set
            {
                if (value != _remark)
                {
                    _remark = value;
                    OnPropertyChanged(nameof(Remark));
                }
            }
        }

    }
}
