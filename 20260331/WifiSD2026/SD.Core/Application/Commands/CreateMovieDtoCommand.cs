using Mediator;
using SD.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SD.Core.Application.Commands
{
    public class CreateMovieDtoCommand : ICommand<MovieDto> //hier wird nichts mitgegeben, nur neue instanz von MovieDto erstellt, damit die Id automatisch generiert wird
    {
    }
}
