﻿using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	//private readonly StoreContext _context;
    private IProductRepository _repo;

    public ProductsController(IProductRepository repo)
	{
		_repo = repo; 
	}

	[HttpGet]
	public async Task<ActionResult<List<Product>>> GetProducts()
	{
		var products = await _repo.GetProductsAsync();

		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Product>>  GetProduct(int id) {
		return await _repo.GetProductByIdAsync(id);
	}

	[HttpGet("brands")]
	public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
	{
		var productBrands =  await _repo.GetProductBrandsAsync();
		return Ok(productBrands);
	}

	[HttpGet("types")]
	public async Task<ActionResult<List<ProductType>>> GetProductTypes()
	{
		var productTypes = await _repo.GetProductTypesAsync();
		return Ok(productTypes);
	}
}
