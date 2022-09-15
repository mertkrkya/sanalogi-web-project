using AutoMapper;
using Microsoft.AspNetCore.Http;
using Sanalogi.Core.UnitofWork;
using Sanalogi.Data.Dto;
using Sanalogi.Data.Models;
using Sanalogi.Data.Repositories.Abstract;
using Sanalogi.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanalogi.Service.Services;
using Sanalogi.Core.Entities;
using Sanalogi.Data.Entities;
using Sanalogi.Service.Exceptions;

namespace Sanalogi.Service.Services.Concrete
{
    public class SiparisService : BaseService<SiparisDto,Siparis>, ISiparisService
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;
        public SiparisService(ISiparisRepository siparisRepository, IMapper mapper, IUnitofWork unitofWork) : base(siparisRepository, unitofWork, mapper)
        {
            _siparisRepository = siparisRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public override async Task<ResponseEntity> GetAllAsync()
        {
            try
            {
                var allRecord = await _siparisRepository.GetAllAsync();
                var mappedResult = _mapper.Map<IEnumerable<Siparis>, IEnumerable<SiparisDetailDto>>(allRecord);
                return new ResponseEntity(mappedResult);
            }
            catch (Exception e)
            {
                throw new Exception("Get All Error");
            }
        }

        public override async Task<ResponseEntity> GetByIdAsync(int id)
        {
            try
            {
                var result = await _siparisRepository.GetByIdAsync(id);
                var mappedResult = _mapper.Map<Siparis, SiparisDetailDto>(result);
                return new ResponseEntity(mappedResult);
            }
            catch (Exception e)
            {
                throw new ClientException("No Data with ID: " + id);
            }
        }
    }
}
