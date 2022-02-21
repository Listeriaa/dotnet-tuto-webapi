using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        //retourne un Ienumerable de type Command
        IEnumerable<Command> GetAppCommands();

        Command GetCommandById(int id);
    }
}