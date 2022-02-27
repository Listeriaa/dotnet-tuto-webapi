using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using Commander.Profiles;
using AutoMapper;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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
        //Throughout our entire application, in all the places where ICommanderRepo is injected an instance of SQLCommanderRepo is provided. (cf addScoped in startup)

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
        [HttpGet("{id}", Name="GetCommandById")]
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

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandDTO)
        {
            //on map le dto en command pour l'envoyer dans la bdd
            var commandModel = _mapper.Map<Command>(commandDTO);
            _repository.CreateCommand(commandModel);

            _repository.SaveChanges();

            //on retourne le DTO pour l'exemple, donc on map le command en readdto
            var CreatedCommandDTO = _mapper.Map<CommandReadDto>(commandModel);

            //retourne aussi l'url du 
            return CreatedAtRoute(nameof(GetCommandById), new {Id = CreatedCommandDTO.Id}, CreatedCommandDTO);

        }

        //PUT api/commands/id
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = _repository.GetCommandById(id);

            if (commandFromRepo == null) {
                return NotFound();
            }

            //on transforme la command récupérée de la bdd (commandfromrepo) avec les datas de la requete (commandUpdateDTO, qui est passée en paramètre de la méthode
            _mapper.Map(commandUpdateDto, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //patch api/commands/id
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null) {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromRepo);

            patchDocument.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);

            _repository.SaveChanges();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null) {
                return NotFound();
            }

            _repository.DeleteCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}