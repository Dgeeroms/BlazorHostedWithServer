﻿using Bogus;
using Project.Shared.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FakeProductService : IProductService
{
    private static readonly List<ProductDto.Detail> _products = new();
    static FakeProductService()
    {
        var productIds = 0;
        var productFaker = new Faker<ProductDto.Detail>("nl")
        .UseSeed(1337) // Always return the same products
        .RuleFor(x => x.Id, _ => ++productIds)
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
        .RuleFor(x => x.Image, f => f.Internet.Avatar())
        .RuleFor(x => x.Price, f => f.Random.Decimal(0, 250));

        _products = productFaker.Generate(25);
    }

	public Task<ProductDto.Detail> GetDetailAsync(int productId)
	{
		return Task.FromResult(_products.Single(p => p.Id == productId));
	}

	public Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
	{
        return Task.FromResult(_products.Select(x => new ProductDto.Index
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price
        }));
    }
}