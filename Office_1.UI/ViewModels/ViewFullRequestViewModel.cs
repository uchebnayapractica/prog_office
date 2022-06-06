using Office_1.DataLayer;
using Office_1.DataLayer.Models;
using Office_1.UI.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Office_1.UI.ViewModels
{
    public class ViewFullRequestViewModel : TabViewModel
    {
        private string _directorName;

        private string _subject;

        private string _content;

        private string _resolution;

        private string _remark;

        private Status _status;

        private Request _viewingRequest;

        private string _statusDefinition;


        public ViewFullRequestViewModel()
        {
            GridVisibility = Visibility.Hidden;
        }

        public Request ViewingRequest
        {
            get => _viewingRequest;
            set
            {
                if (value != _viewingRequest)
                {
                    _viewingRequest = value;
                    OnPropertyChanged(nameof(ViewingRequest));
                    DirectorName = _viewingRequest.DirectorName;
                    Subject = _viewingRequest.Subject;
                    Content = _viewingRequest.Content;
                    ClientName = _viewingRequest.Client.Name;
                    ClientAddress = _viewingRequest.Client.Address;
                    Client = _viewingRequest.Client;

                    //Optional
                    Resolution = _viewingRequest.Resolution;
                    Remark = _viewingRequest.Remark;
                    Status = _viewingRequest.Status;
                }
            }
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

        public Status Status
        {
            get => _status;
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                    StatusDefinition = EnumExtension.GetDescription(_status);
                }
            }
        }

        public string StatusDefinition
        {
            get => _statusDefinition;
            set
            {
                if (value != _statusDefinition)
                {
                    _statusDefinition = value;
                    OnPropertyChanged(nameof(StatusDefinition));
                    Status = EnumExtension.GetValueFromDescription<Status>(_statusDefinition);
                }
            }
        }
    }
}
