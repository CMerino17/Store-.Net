﻿using bootcamp_store_backend.Application.Dtos;
using bootcamp_store_backend.Domain.Entities;

namespace bootcamp_store_backend.Application.Services
{
    public interface ICategoryService
    {
        void DeleteCategory(long id);
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategory(long id);
        CategoryDto InsertCategory(CategoryDto categoryDto);
        CategoryDto UpdateCategory(CategoryDto categoryDto);
    }
}