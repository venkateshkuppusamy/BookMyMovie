namespace BookMyMovie.TenantMgmt.API.Repositories.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public required string LastUpdateBy { get; set; }
        public DateTime LastUpdateDt { get; set; }
    }
}
