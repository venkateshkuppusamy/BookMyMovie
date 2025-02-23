namespace BookMyMovie.TenantMgmt.API.Business.Domain
{
    public class Tenant : BaseDomain
    {
        public required string Name { get; set; }
    }
}
