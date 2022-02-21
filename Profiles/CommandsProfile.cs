using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // from Command to CommandReadDTO
            CreateMap<Command, CommandReadDto>();
        }
    }
}