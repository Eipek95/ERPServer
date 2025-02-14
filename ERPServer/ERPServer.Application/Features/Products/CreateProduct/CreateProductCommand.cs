using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(
        string Name,
        int TypeValue) : IRequest<Result<string>>;
}
