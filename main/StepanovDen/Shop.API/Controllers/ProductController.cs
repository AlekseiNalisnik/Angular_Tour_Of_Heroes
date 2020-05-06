using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Shop.API.Models;
using Shop.API.ViewModels.Product;
using Shop.API.Services;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productEntities = _productRepository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(productEntities));

        }
        
        [HttpGet("{productId}", Name = "GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);

            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductModel>(product));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var finalProduct = _mapper.Map<Models.Product>(model);

            _productRepository.AddProduct(finalProduct);

            var productToReturn = _mapper
                .Map<ProductModel>(finalProduct);

            return CreatedAtRoute("GetProduct",
                new { productId = productToReturn.Id },
                productToReturn);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId,
            [FromBody] ProductUpdateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            _mapper.Map(model, productEntity);
            _productRepository.UpdateProduct(productEntity);
            return NoContent();
        }

         
        [HttpPatch("{productId}")]
        public IActionResult PatchProduct(int productId,
            [FromBody] JsonPatchDocument<ProductUpdateModel> productPatch)
        {
            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            // Маппинг нужен, чтобы применить к нему JsonPatchDocument.
            var productToPatch = _mapper.Map<ProductUpdateModel>(productEntity);
            
            // Убрал ModelState.
            productPatch.ApplyTo(productToPatch);
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!TryValidateModel(productToPatch)) return BadRequest(ModelState);

            _mapper.Map(productToPatch, productEntity);
            _productRepository.UpdateProduct(productEntity);
            return NoContent();
        }


        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            _productRepository.DeleteProduct(productEntity);
            return NoContent();
        }

        #region Helpers
        
        // TODO: Затолкать хэлпер методы.
        
        #endregion
    }
}
