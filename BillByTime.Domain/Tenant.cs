using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillByTime.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = "";

        //Navigation to Many
        public List<TenantManager> TenantManagers { get; set; } = new();

        public List<Worker> Workers { get; set; } = new();

    }
}