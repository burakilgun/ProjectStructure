﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nairobi.Application.Commands;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos.Core;
using Nairobi.Helpers;

namespace Nairobi.Application.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,BaseResponse<bool>>
    {
        private readonly IProductRespository _productRespository;

        public DeleteProductCommandHandler(IProductRespository productRespository)
        {
            _productRespository = productRespository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            var product = await _productRespository.GetByIdAsync(request.Id);
            if (product == null)
            {
                response.AddError("Product not found.", "404");
                return response;
            }

            var deleteStatus = await _productRespository.DeleteAsycn(request.Id);

            if (!deleteStatus)
            {
                response.AddError("An error occured please try again.", "500");
                return response;
            }

            return response;
        }
    }
}
