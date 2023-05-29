using bootcamp_store_backend.Application;
using bootcamp_store_backend.Application.Dtos;
using bootcamp_store_backend.Application.Services;
using bootcamp_store_backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_store_backend.Infrastructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class ItemsController : GenericCrudController<ItemDto>
    {
        private IItemService _itemService;
        private readonly ILogger _logger;

        public ItemsController(IItemService service, ILogger<CategoriesController> logger) : base(service)
        {
            _itemService = service;
            _logger = logger;
        }


        [NonAction]
        public override ActionResult<IEnumerable<ItemDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost("/store/categories/{categoryId}/items/import")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<IEnumerable<ItemDto>> PostNewItems(long categoryId, List<ItemDto> items)
        {
            try
            {
                List<ItemDto> newItems = _itemService.postNewItemsFromCategory(categoryId, items);
                return Ok(newItems);
            } catch (InvalidImageException) 
            {
                _logger.LogInformation("Invalid image importing items from a category {categoryId} name", categoryId);
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PagedResponse<ItemDto>> Get([FromQuery] string? filter, [FromQuery] PaginationParameters paginationParameters) 
        {
            try
            {
                PagedList<ItemDto> page = _itemService.GetItemsByCriteriaPaged(filter, paginationParameters);
                var response = new PagedResponse<ItemDto>
                {
                    CurrentPage = page.CurrentPage,
                    TotalPages = page.TotalPages,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    Data = page
                };
                return Ok(response);
            } catch (MalformedFilterException) 
            {
                return BadRequest();
            }
        }
        
        [HttpGet("/store/categories/{categoryId}/items")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<ItemDto>> GetAllFromCategory(long categoryId) 
        {
            var categoriesDto = _itemService.GetAllByCategoryId(categoryId);
            return Ok(categoriesDto);
        }

        public override ActionResult<ItemDto> Insert(ItemDto dto)
        {
            try
            {
                return base.Insert(dto);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {dto.Name} name", dto.Name);
                return BadRequest();
            }
        }

        public override ActionResult<ItemDto> Update(ItemDto dto)
        {
            try
            {
                return base.Update(dto);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image updating category with {dto.Id} Id", dto.Id);
                return BadRequest();
            }
        }
    }
}
