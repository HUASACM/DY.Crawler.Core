namespace DY.Crawler.Domains
{
    public class ResourceFieldDef
    {
        public virtual CustomFieldDef FieldDef { get; set; }
        public virtual ParseRule Rule { get; set; }
    }
}