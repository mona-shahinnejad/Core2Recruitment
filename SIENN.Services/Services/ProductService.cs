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
    public class ProductService : IProductService
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(ProductDto unit)
        {
            var result = false;

            try
            {
                var addEntity = _mapper.Map<Product>(unit);
                _unitOfWork.ProductRepository.Add(addEntity);
                _unitOfWork.Save();

                result = true;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(ProductDto unit)
        {
            var result = false;

            try
            {
                var delete = _unitOfWork.ProductRepository.Find(u => u.Code == unit.Code);

                if (delete.Any())
                {
                    _unitOfWork.ProductRepository.Remove(delete.First());
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

        public ProductDto Find(string code)
        {
            var result = _unitOfWork.ProductRepository.Find(u => u.Code == code);

            return _mapper.Map<ProductDto>(result.FirstOrDefault());
        }

        public IEnumerable<ProductDto> FindByName(string name)
        {
            var result = _unitOfWork.ProductRepository.Find(u => u.Name == name);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public IEnumerable<ProductDto> GeTAll()
        {
            var result = _unitOfWork.ProductRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public bool Update(ProductDto unit)
        {
            var result = false;

            var update = _unitOfWork.ProductRepository.Find(u => u.Code == unit.Code);

            if (update.Any())
            {
                var updatedEntity = update.First();

                updatedEntity = _mapper.Map(unit, updatedEntity);

                _unitOfWork.Save();

                result = true;
            }

            return result;
        }

        public PagingDto<ProductDto> GetAvailableProducts(PagingRequestDto request)
        {
            var data = _unitOfWork.ProductRepository.GetRange(request.PageSize * request.PageNumber, request.PageSize, p => p.IsAvailable);

            return new PagingDto<ProductDto>
            {
                Results = _mapper.Map<IEnumerable<ProductDto>>(data),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = _unitOfWork.ProductRepository.Count(p => p.IsAvailable)
            };
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilterDto filters)
        {
            var data = _unitOfWork.ProductRepository
                                  .Find(p => (filters.HasUnitFilter && filters.UnitCodesFilter.Contains(p.Unit.Code))
                                        || (filters.HasProductTypeFilter && filters.ProductTypeCodesFilter.Contains(p.ProductType.Code))
                                        || (filters.HasCategoryFilter && p.ProductCategories.Any(pc => filters.CategoryCodesFilter.Contains(pc.Category.Code))));
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public PagingDto<ProductCustomViewDto> GetProductCustomViews(PagingRequestDto request)
        {
            var data = _unitOfWork.ProductRepository.GetAllQuery().Select(p => new ProductCustomViewDto
            {
                CategoryCount = p.ProductCategories.Count,
                DeliveryDate = p.DeliveryDateTime.ToString("MM.dd.yyyy"),
                IsAVailable = p.IsAvailable ? "Available" : "Not available",
                Price = $"{p.Price:C}",
                ProductDescription = $"({p.Code}) {p.Description}",
                Type = $"({p.Unit.Code}) {p.Unit.Description}",
                Unit = $"({p.Unit.Code}) {p.Unit.Description}"
            }).Skip(request.PageSize * request.PageNumber).Take(request.PageSize).ToList();

            return new PagingDto<ProductCustomViewDto>
            {
                Results = data,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = _unitOfWork.ProductRepository.Count()
            };
        }
    }
}
