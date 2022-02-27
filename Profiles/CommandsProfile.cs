using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // from Command to CommandReadDTO => source to target
            //on recoit une commande de la bdd et on veut le transformer en commandreaddto
            CreateMap<Command, CommandReadDto>();

            //On a une commandecreatedto du controller et on veut le transformer en command pour l'envoyer en bdd
            CreateMap<CommandCreateDto, Command>();

            //pour put
            CreateMap<CommandUpdateDto, Command>();

            //pour patch
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}