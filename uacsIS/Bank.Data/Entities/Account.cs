using Bank.Data.Enums;

namespace Bank.Data.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}