namespace BookMyMovie.TenantMgmt.API.Business.Domain
{
    public class BaseDomain
    {
        public int Id { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public required string LastUpdateBy { get; set; }
        public DateTime LastUpdateDt { get; set; }
    }
}
