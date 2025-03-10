﻿using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.DTOs.Comments
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int ExpertId { get; set; }
        public string? ExpertName { get; set; }
        public int RequestId { get; set; }
        public int CategoryId { get; set; }
        public string? JobCategory { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public CommentStatusEnum Status { get; set; }
        public DateTime SetAt { get; set; }
    }
}
