using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.BaseDto;
using Application.ProductService.Command.Create;
using Application.ProductService.Command.Create.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductService _createProductService;

        public ProductController(CreateProductService createProductService)
        {
            _createProductService = createProductService;
        }
        
        [HttpPost]
        public Response Post(CreateProductRequest request)
        {
            return _createProductService.Execute(request);
        }
    }
}
