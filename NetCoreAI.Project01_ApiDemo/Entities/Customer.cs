namespace NetCoreAI.Project01_ApiDemo.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerSurname { get; set; }
        public  decimal CustomerBalance { get; set; }
    }
}
