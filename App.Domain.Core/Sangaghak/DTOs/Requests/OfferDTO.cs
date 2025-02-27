namespace App.Domain.Core.Sangaghak.DTOs.Requests
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public int OfferedPrice { get; set; }
        public string Description { get; set; }
        public DateTime OfferedTime { get; set; }
    }
}
