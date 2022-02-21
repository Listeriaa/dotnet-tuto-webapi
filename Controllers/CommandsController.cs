using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using Commander.Profiles;
using AutoMapper;
using Commander.Dtos;

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
        private readonly IMapper _mapper;

        //Constructeur, avec injection de dépendances
        //Throughout our entire application, in all the places where ICommanderRepo is injected an instance of MockCommanderRepo is provided. (cf addScoped in startup)

        //Imapper, on injecte le mapper
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandById = _repository.GetCommandById(id);

            if (commandById != null) 
            {
                //on map du commandbyId en CommandReadDTO
            return Ok(_mapper.Map<CommandReadDto>(commandById));

            }
            return NotFound();
        }
    }
}