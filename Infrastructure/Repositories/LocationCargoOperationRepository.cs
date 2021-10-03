using Application.Middleware;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LocationCargoOperationRepository : ILocationCargoOperationRepository
    {
        private readonly WmsContext _context;

        public LocationCargoOperationRepository(WmsContext context)
        {
            _context = context;
        }

        public void AddOperation(LocationCargoOperation operation)
        {
            _context.LocationCargoOperation.Add(operation);
            _context.SaveChanges();
        }

        public IEnumerable<LocationCargoOperation> GetAllWithFilters(ref Pagination pagination, LocationCargoOperation operation = null)
        {
            var locationCargoOperation = _context.LocationCargoOperation.AsEnumerable();
            if(operation.Barcode != null)
                locationCargoOperation.Where(x => x.Barcode == operation.Barcode);
            if (operation.CreateAt != null)
                locationCargoOperation.Where(x => x.CreateAt == operation.CreateAt);
            if (operation.LocationId != null)
                locationCargoOperation.Where(x => x.LocationId == operation.LocationId);
            if (operation.OperationId != null)
                locationCargoOperation.Where(x => x.OperationId == operation.OperationId);
            if (operation.Qty != null)
                locationCargoOperation.Where(x => x.Qty == operation.Qty);
            if (operation.UserId != null)
                locationCargoOperation.Where(x => x.UserId == operation.UserId);

            return PaginationHandler.Page(locationCargoOperation, ref pagination);
        }
    }
}
