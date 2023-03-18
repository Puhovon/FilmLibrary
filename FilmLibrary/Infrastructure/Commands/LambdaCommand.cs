﻿using FilmLibrary.Infrastructure.Commands.Base;
using System;

namespace FilmLibrary.Infrastructure.Commands
{
    class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }
        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;


        public override void Execute(object? parameter) => _execute(parameter);
    }
}
