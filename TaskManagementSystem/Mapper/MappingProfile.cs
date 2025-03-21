using AutoMapper;
using TaskManagementSystem.Models;
using TaskManagementSystem.DTO;

namespace TaskManagementSystem.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkItem, WorkItemOutputDto>();
            CreateMap<WorkItemInputDto, WorkItem>();
            CreateMap<WorkItem, WorkItemInputDto>();
            CreateMap<WorkItemOutputDto, WorkItem>();
            CreateMap<ProjectInputDto, Project>();
            CreateMap<Project, ProjectInputDto>();
            CreateMap<UserModel, UserModelInputDto>();
            CreateMap<UserModelInputDto, UserModel>();
            CreateMap<Notification, NotificationInputDto>();
            CreateMap<NotificationInputDto, Notification>();
            CreateMap<NotificationOutput, Notification>();
            CreateMap<Notification, NotificationOutput>();
            
    
        }
    }
}