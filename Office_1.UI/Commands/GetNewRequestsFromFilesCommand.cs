﻿using Office_1.UI.ViewModels;


namespace Office_1.UI.Commands
{
    public class GetNewRequestsFromFilesCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public GetNewRequestsFromFilesCommand(MainWindowViewModel vm)
        {
            _mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {


        }
    }
}