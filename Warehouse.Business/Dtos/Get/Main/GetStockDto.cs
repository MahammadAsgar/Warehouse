namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetStockDto
    {
        public int Id { get; set; }
        public GetProductNameDto Product { get; set; }
        public GetMeasureTypeNameDto MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
    }
}
