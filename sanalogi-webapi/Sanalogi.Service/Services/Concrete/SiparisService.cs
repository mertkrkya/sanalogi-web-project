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
using UrunKatalogProjesi.Service.Services;

namespace Sanalogi.Service.Services.Concrete
{
    public class SiparisService : BaseService<SiparisDto,Siparis>, ISiparisService
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SiparisService(ISiparisRepository siparisRepository, IMapper mapper, IUnitofWork unitofWork, IHttpContextAccessor httpContextAccessor) : base(siparisRepository, unitofWork, mapper, httpContextAccessor)
        {
            _siparisRepository = siparisRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
