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
    public class CategoryService : ICategoryService
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(CategoryDto unit)
        {
            var result = false;

            try
            {
                var addEntity = _mapper.Map<Category>(unit);
                _unitOfWork.CategoryRepository.Add(addEntity);
                _unitOfWork.Save();

                result = true;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(CategoryDto unit)
        {
            var result = false;

            try
            {
                var delete = _unitOfWork.CategoryRepository.Find(u => u.Code == unit.Code);

                if (delete.Any())
                {
                    _unitOfWork.CategoryRepository.Remove(delete.First());
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

        public CategoryDto Find(string code)
        {
            var result = _unitOfWork.CategoryRepository.Find(u => u.Code == code);

            return _mapper.Map<CategoryDto>(result.FirstOrDefault());
        }

        public IEnumerable<CategoryDto> FindByName(string name)
        {
            var result = _unitOfWork.CategoryRepository.Find(u => u.Name == name);

            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public IEnumerable<CategoryDto> GeTAll()
        {
            var result = _unitOfWork.CategoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public bool Update(CategoryDto unit)
        {
            var result = false;

            var update = _unitOfWork.CategoryRepository.Find(u => u.Code == unit.Code);

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
