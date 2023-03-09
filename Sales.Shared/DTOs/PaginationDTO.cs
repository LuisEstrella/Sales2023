namespace Sales.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Id { get; set; }
        public int Page { get; set; } = 1; //Page es la pagina en la que estamos
        public int RecordsNumber { get; set; } = 10;
        public string? Filter { get; set; }
    }
}
