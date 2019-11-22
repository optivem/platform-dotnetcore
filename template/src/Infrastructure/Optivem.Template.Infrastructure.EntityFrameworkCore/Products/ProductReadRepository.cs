﻿using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductReadRepository : Repository, IProductReadRepository
    {
        public ProductReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(ProductIdentity productId)
        {
            var productRecordId = productId.Id;

            return Context.ProductRecords.AsNoTracking()
                .AnyAsync(e => e.Id == productRecordId);
        }

        public async Task<Product> FindAsync(ProductIdentity productId)
        {
            var productRecordId = productId.Id;

            var productRecord = await Context.ProductRecords.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productRecordId);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public async Task<PageReadModel<ProductHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var productRecords = await Context.ProductRecords.AsNoTracking()
                .Page(pageQuery)
                .ToListAsync();

            var productHeaderReadModels = productRecords
                .Select(GetProductHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return PageReadModel<ProductHeaderReadModel>.Create(pageQuery, productHeaderReadModels, totalRecords);
        }

        public async Task<ListReadModel<ProductIdNameReadModel>> ListAsync()
        {
            var productRecords = await Context.ProductRecords.AsNoTracking()
                .OrderBy(e => e.ProductCode)
                .ToListAsync();

            var resultRecords = productRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListReadModel<ProductIdNameReadModel>(resultRecords, totalRecords);
        }

        public Task<long> CountAsync()
        {
            return Context.ProductRecords.LongCountAsync();
        }

        #region Helper

        protected Product GetProduct(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isListed = productRecord.IsListed;

            return new Product(id, productCode, productName, listPrice, isListed);
        }

        protected ProductHeaderReadModel GetProductHeaderReadModel(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isListed = productRecord.IsListed;

            return new ProductHeaderReadModel(id, productCode, productName, listPrice, isListed);
        }

        protected ProductIdNameReadModel GetIdNameResult(ProductRecord productRecord)
        {
            var id = productRecord.Id;
            var name = $"{productRecord.ProductCode} - {productRecord.ProductName}";

            return new ProductIdNameReadModel(id, name);
        }

        #endregion
    }
}