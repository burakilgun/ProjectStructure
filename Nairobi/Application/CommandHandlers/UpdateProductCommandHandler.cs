using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nairobi.Application.Commands;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;
using Nairobi.Entities;
using Nairobi.Helpers;

namespace Nairobi.Application.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductDto>>
    {
        private readonly IProductRespository _productRespository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRespository productRespository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRespository = productRespository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();

            var product = await _productRespository.GetByIdAsync(request.Id);
            if (product == null)
            {
                response.AddError("Product not found.", "404");
                return response;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            if (request.CategoryId != product.Category.Id)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
                if (category == null)
                {
                    response.AddError("Category not found.", "404");
                    return response;
                }

                product.Category = category;
            }
            

            await _productRespository.UpdateAsync(request.Id, product);

            response.Data = _mapper.Map<ProductDto>(product);
            return response;
        }
    }
}
