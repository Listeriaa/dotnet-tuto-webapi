using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data

{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        //injection de la dépendance correspondant au dbcontext
        public SQLCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            //ToList => retourne un tableau
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public Command CreateCommand(Command cmd)
        {
            return cmd;
        }

        public bool SaveChanges()
        {
            
        }
    }
}