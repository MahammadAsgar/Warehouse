namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetDepotDto
    {
        public ICollection<GetStockDto> Stocks { get; set; }
    }
}
