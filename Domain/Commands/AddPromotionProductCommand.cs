using System;

namespace Domain.Commands
{
    public class AddPromotionProductCommand
    {
        public Guid Id { get; set; }        
        public decimal Price { get; set; }
    }
}