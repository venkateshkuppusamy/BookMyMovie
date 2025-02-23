namespace BookMyMovie.TenantMgmt.API.API.Attributes
{
    public class ActionDescriptionAttribute : Attribute
    {
        public string Code { get; }
        public string Description { get; }

        public ActionDescriptionAttribute(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
