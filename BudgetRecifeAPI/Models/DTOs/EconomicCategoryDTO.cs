namespace Models.DTOs.Output
{
    public class EconomicCategoryDTO
    {
        public decimal? EconomicCategoryCode { get; set; }
        public string? EconomicCategoryName { get; set; }
        public long TotalCategoryValue { get; set; }
    }
}
