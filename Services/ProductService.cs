﻿using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}
				
		public ProductList ListProducts(int page)
        {			
            return new ProductList() { HasNext = false, TotalCount = 10, Products = _ctx.Products
				.OrderBy(x => x.Id)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToList()
            };
        }

	}
}
