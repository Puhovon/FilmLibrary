using FilmLibrary.Infrastructure.Commands.Base;
using System;
using System.Windows;

namespace FilmLibrary.Infrastructure.Commands
{
    internal class CloseWindowCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }

    internal class CloseDialogCommand : Command
    {
        public bool DialogResult { get; set; }



        public override bool CanExecute(object? parameter) => parameter is Window;
        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter)) 
                return;
            var w = (Window)parameter;
            w.DialogResult = DialogResult;
            w?.Close();
        }
    }
}
