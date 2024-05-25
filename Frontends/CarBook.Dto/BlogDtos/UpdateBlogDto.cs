namespace CarBook.Dto.BlogDtos
{
    public class UpdateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string Descripiton { get; set; }
    }
}
