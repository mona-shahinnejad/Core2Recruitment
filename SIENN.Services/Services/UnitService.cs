using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SIENN.DbAccess;
using SIENN.DbAccess.Entities;
using SIENN.Services.DTO;
using SIENN.Services.IServices;

namespace SIENN.Services.Services
{
    public class UnitService : IUnitService
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitService(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(UnitDto unit)
        {
            var result = false;

            try
            {
                var addEntity = _mapper.Map<Unit>(unit);
                _unitOfWork.UnitRepository.Add(addEntity);
                _unitOfWork.Save();

                result = true;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(UnitDto unit)
        {
            var result = false;

            try
            {
                var delete = _unitOfWork.UnitRepository.Find(u => u.Code == unit.Code);

                if (delete.Any())
                {
                    _unitOfWork.UnitRepository.Remove(delete.First());
                    _unitOfWork.Save();

                    result = true;

                    return result;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UnitDto Find(string code)
        {
            var result = _unitOfWork.UnitRepository.Find(u => u.Code == code);

            return _mapper.Map<UnitDto>(result.FirstOrDefault());
        }

        public IEnumerable<UnitDto> FindByName(string name)
        {
            var result = _unitOfWork.UnitRepository.Find(u => u.Name == name);

            return _mapper.Map<IEnumerable<UnitDto>>(result);
        }

        public IEnumerable<UnitDto> GeTAll()
        {
            var result = _unitOfWork.UnitRepository.GetAll();

            return _mapper.Map<IEnumerable<UnitDto>>(result);
        }

        public bool Update(UnitDto unit)
        {
            var result = false;

            var update = _unitOfWork.UnitRepository.Find(u => u.Code == unit.Code);

            if (update.Any())
            {
                var updatedEntity = update.First();

                updatedEntity = _mapper.Map(unit, updatedEntity);

                _unitOfWork.Save();

                result = true;
            }

            return result;
        }
    }
}
