﻿using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public ICollection<ActivityDto> GetAll()
            => _activityRepository.GetAll().Result.Select(_mapper.Map<ActivityDto>).ToList();

        public ActivityDto GetById(int id)
            => _mapper.Map<ActivityDto>(_activityRepository.GetById(id));

        public bool Delete(int id)
            => _activityRepository.Delete(id);

        public ActivityDto Create(ActivityCreateRequest request)
            => _mapper.Map<ActivityDto>(_activityRepository.Create(_mapper.Map<Activity>(request)));

        public ActivityDto Update(ActivityDto request)
            => _mapper.Map<ActivityDto>(_activityRepository.Update(_mapper.Map<Activity>(request)));
    }
}
