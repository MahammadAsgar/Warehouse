namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetBuyingDto
    {
        public int Id { get; set; }
        public GetProductNameDto Product { get; set; }
        public GetMeasureTypeNameDto MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public double? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime BuyingDate { get; set; }
    }
}
