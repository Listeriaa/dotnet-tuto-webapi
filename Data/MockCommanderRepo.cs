using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data

{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
           {
               new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and pan"},
               new Command{Id=1, HowTo="Make tea", Line="Place teabag in cup", Platform="Kettle and cup"},
               new Command{Id=2, HowTo="Get brioche", Line="Grab a knife", Platform="Knife and chopping board"},
           };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle"};
        }

    }
}