namespace App.Domain.Core.Sangaghak.DTOs.Comments
{
    public class CommentForCreateDTO
    {
        public string Description { get; set; }
        public int Rate { get; set; }
        public int CustomerId { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
    }
}
