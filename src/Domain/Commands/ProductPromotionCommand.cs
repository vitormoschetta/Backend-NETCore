using System;

namespace Domain.Commands
{
    public class ProductPromotionCommand
    {
        public string Id { get; set; }        
        public decimal Price { get; set; }
    }
}