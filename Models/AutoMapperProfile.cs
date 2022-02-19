using AutoMapper;
using TaskerAPI.Entities;
using TaskerAPI.Models.Create;

namespace TaskerAPI.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Note, NoteCreate>().ReverseMap();
        CreateMap<Note, NoteUpdate>().ReverseMap();

        CreateMap<User, UserCreate>().ReverseMap();
        CreateMap<User, UserUpdate>().ReverseMap();

        CreateMap<Reminder, ReminderUpdate>().ReverseMap();
        CreateMap<Reminder, ReminderCreate>().ReverseMap();
    }
}