﻿using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Repositories;
using RP_Server.Models.Entities;

namespace RP_Server.Services.Implementation
{
    public class GroupService : IGroupService
    {
        IGroupRepository _groupRepository;
        IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public ICollection<GroupDto> GetAll()
            => _groupRepository.GetAll().Result.Select(_mapper.Map<GroupDto>).ToList();

        public GroupDto GetById(int id)
            => _mapper.Map<GroupDto>(_groupRepository.GetById(id));

        public bool Delete(int id)
            => _groupRepository.Delete(id);

        public GroupDto Create(GroupDto request)
            => _mapper.Map<GroupDto>(_groupRepository.Create(_mapper.Map<Group>(request)));

        public GroupDto Update(GroupDto request)
            => _mapper.Map<GroupDto>(_groupRepository.Update(_mapper.Map<Group>(request)));
    }
}