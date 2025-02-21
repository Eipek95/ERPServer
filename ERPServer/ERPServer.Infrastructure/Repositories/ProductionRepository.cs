using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Infrastructure.Repositories
{
    internal sealed class ProductionRepository : Repository<Production, ApplicationDbContext>, IProductionRepository
    {
        public ProductionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
