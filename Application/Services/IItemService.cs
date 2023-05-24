using bootcamp_store_backend.Application.Dtos;

namespace bootcamp_store_backend.Application.Services
{
    public interface IItemService : IGenericService<ItemDto>
    {
        List<ItemDto> GetAllByCategoryId(long categoryId);
    }
}
