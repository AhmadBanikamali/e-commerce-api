using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.BaseDto;
using Application.ProductService.Category.Command;
using Application.ProductService.Category.Command.Dto;
using Application.ProductService.Category.Query;
using Application.ProductService.Category.Query.Dto;
using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.Product.Query.Single;
using Application.ProductService.Product.Query.Single.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace e_commerce_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductService _createProductService;
        private readonly CreateCategoryService _createCategoryService;
        private readonly GetCategoriesService _getCategoriesService;
        private readonly GetSingleProductService _getSingleProductService;


        public ProductController(
            CreateProductService createProductService,
            CreateCategoryService createCategoryService,
            GetCategoriesService getCategoriesService,
            GetSingleProductService getSingleProductService,
            
            SqlServerDbContext context)
        {
            /*
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            */

            _createProductService = createProductService;
            _createCategoryService = createCategoryService;
            _getCategoriesService = getCategoriesService;
            _getSingleProductService = getSingleProductService;
        }

        [HttpPost("Product")]
        public Response Post(CreateProductRequest request)
        {
            return _createProductService.Execute(request);
        }

        [HttpPost("Category")]
        public Response Post(CreateCategoryRequest request)
        {
            return _createCategoryService.Execute(request);
        }

        [HttpGet("Category")]
        public PaginatedResponse<GetCategoriesResponse> Get([FromQuery] GetCategoriesRequest request)
        {
            return _getCategoriesService.Execute(request);
        }

        [HttpGet("Product")]
        public Response<GetSingleProductResponse> Get([FromQuery] GetSingleProductRequest request)
        {
            return _getSingleProductService.Execute(request);
        }
    }
}