using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        //retourne un Ienumerable de type Command
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command cmd);
    }
}