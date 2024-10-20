namespace ProductService.Dto
{
    public class ProductDto
    {
        public string? Id { get; set;}
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set;}
        public string? Brand { get; set; }
        public string? Price { get; set; }
        public string? ImageFile { get; set; }

        public DateTime? CreatedAt { get; set; }
        public float? Rating { get; set;}
        
    }
}