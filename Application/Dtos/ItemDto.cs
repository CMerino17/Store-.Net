﻿using bootcamp_store_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bootcamp_store_backend.Application.Dtos
{
    public class ItemDto: IDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string? Description { get; set; }
       
        public double Price { get; set; }
       
        public byte[] Image { get; set; }
        
        public long CategoryId { get; set; }
       
        public string CategoryName { get; set; }
    }
}
