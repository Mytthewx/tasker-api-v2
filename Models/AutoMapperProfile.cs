using AutoMapper;
using TaskerAPI.Entities;
using TaskerAPI.Models.Update;
using TaskerAPI.Models.ViewModel;

namespace TaskerAPI.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Note, NoteViewModel>().ReverseMap();
        CreateMap<Note, NoteUpdate>().ReverseMap();

        CreateMap<Reminder, ReminderUpdate>().ReverseMap();
        CreateMap<Reminder, ReminderViewModel>().ReverseMap();

        CreateMap<Cost, CostViewModel>().ReverseMap();

        CreateMap<User, UserViewModel>().ReverseMap();
    }
}
