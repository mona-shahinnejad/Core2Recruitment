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
    public class ProductTypeService : IProductTypeService
    {

        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductTypeService(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(ProductTypeDto unit)
        {
            var result = false;

            try
            {
                var addEntity = _mapper.Map<ProductType>(unit);
                _unitOfWork.ProductTypeRepository.Add(addEntity);
                _unitOfWork.Save();

                result = true;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(ProductTypeDto unit)
        {
            var result = false;

            try
            {
                var delete = _unitOfWork.ProductTypeRepository.Find(u => u.Code == unit.Code);

                if (delete.Any())
                {
                    _unitOfWork.ProductTypeRepository.Remove(delete.First());
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

        public ProductTypeDto Find(string code)
        {
            var result = _unitOfWork.ProductTypeRepository.Find(u => u.Code == code);

            return _mapper.Map<ProductTypeDto>(result.FirstOrDefault());
        }

        public IEnumerable<ProductTypeDto> FindByName(string name)
        {
            var result = _unitOfWork.ProductTypeRepository.Find(u => u.Name == name);

            return _mapper.Map<IEnumerable<ProductTypeDto>>(result);
        }

        public IEnumerable<ProductTypeDto> GeTAll()
        {
            var result = _unitOfWork.ProductTypeRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductTypeDto>>(result);
        }

        public bool Update(ProductTypeDto unit)
        {
            var result = false;

            var update = _unitOfWork.ProductTypeRepository.Find(u => u.Code == unit.Code);

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
