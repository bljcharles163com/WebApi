﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using WebStack.QA.Test.OData.SxS2.ODataV3.Models;

namespace WebStack.QA.Test.OData.SxS2.ODataV3.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly List<Product> _products;
        public ProductsController()
        {
            _products = new List<Product>();
            _products.AddRange(
                Enumerable.Range(1, 5).Select(n =>
                    new Product()
                    {
                        Id = n,
                        Title = string.Concat("Title", n),
                        ManufactureDateTime = DateTime.Now,
                    }));
        }

        // GET odata/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return _products.AsQueryable();
        }

        // GET odata/Products(5)
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(_products.Where(product => product.Id == key).AsQueryable());
        }
    }
}
