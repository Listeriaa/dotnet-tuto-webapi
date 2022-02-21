using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;

namespace Commander.Controllers

{
    
    //Décorateur
    [ApiController]

    //api/commands => déterminé en fonction du nom de la classe ___Controller
    //[Route("api/[controller]")]

    [Route("api/commands")]

    //ControllerBase à utiliser quand il n'y a pas de vue (sinon c'est Controller)
    public class CommandsController : ControllerBase

    {
        private readonly ICommanderRepo _repository;

        //Constructeur, avec injection de dépendances
        //Throughout our entire application, in all the places where ICommanderRepo is injected an instance of MockCommanderRepo is provided. (cf addScoped in startup)
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandById = _repository.GetCommandById(id);
            return Ok(commandById);
        }
    }
}