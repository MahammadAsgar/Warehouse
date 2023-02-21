namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<GetProductNameDto> Products { get; set; }
    }
}
