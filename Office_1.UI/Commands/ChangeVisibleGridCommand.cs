﻿using Office_1.UI.ViewModels;
using System.Windows;

namespace Office_1.UI.Commands
{
    public class ChangeVisibleGridCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public ChangeVisibleGridCommand(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {
            TabViewModel viewModel = (TabViewModel)parameter;
            if (!viewModel.Equals(_mainWindowViewModel.VisibleVM))
            {
                //делаем видимым и активным нужное окно
                viewModel.GridVisibility = Visibility.Visible;

                //делаем невидимым и неактивным ненужное окно
                _mainWindowViewModel.VisibleVM.GridVisibility = Visibility.Hidden;

                //заполняем заявку, если необходимо
                if (parameter is ViewFullRequestViewModel)
                {
                    ViewFullRequestViewModel rvm = (ViewFullRequestViewModel)parameter;
                    rvm.ViewingRequest = _mainWindowViewModel.AllRequests.SelectedItem;
                }

                //записываем инфу о том, какое сейчас активно
                _mainWindowViewModel.VisibleVM = viewModel;
            }
        }
    }
}
