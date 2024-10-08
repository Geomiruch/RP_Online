﻿using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Models.Repositories;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public ICollection<LocationDto> GetAll()
            => _locationRepository.GetAll().Result.Select(_mapper.Map<LocationDto>).ToList();

        public LocationDto GetById(int id)
            => _mapper.Map<LocationDto>(_locationRepository.GetById(id));

        public bool Delete(int id)
            => _locationRepository.Delete(id);

        public LocationDto Create(LocationCreateRequest request)
            => _mapper.Map<LocationDto>(_locationRepository.Create(_mapper.Map<Location>(request)));

        public LocationDto Update(LocationDto request)
            => _mapper.Map<LocationDto>(_locationRepository.Update(_mapper.Map<Location>(request)));
    }
}
