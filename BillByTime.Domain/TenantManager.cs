using BillByTime.Common;


namespace BillByTime.Domain
{
    internal class TenantManager
    {
        public int TenantManagerId { get; set; }
        public string Name { get; set; } = "";
        public EmailAddress Email { get; set; } = new EmailAddress();

    }
}
