using System;
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
            
            return _context.Commands.Where(p => p.Id == id).FirstOrDefault();
            //same as
            //return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Add(cmd);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void UpdateCommand(Command cmd)
        {
            //nothing
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }
    }
}