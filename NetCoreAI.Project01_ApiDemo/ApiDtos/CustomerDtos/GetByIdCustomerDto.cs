namespace NetCoreAI.Project01_ApiDemo.ApiDtos.CustomerDtos
{
    public class GetByIdCustomerDto
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public decimal CustomerBalance { get; set; }
    }
}
