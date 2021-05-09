using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nairobi.Application.Requests;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.RequestHandlers
{
    public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest,BaseResponse<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<CategoryDto>>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<CategoryDto>>();

            var categories = await _categoryRepository.GetList(p => p.IsActive);

            response.Data = _mapper.Map<List<CategoryDto>>(categories);

            return response;
        }
    }
}
