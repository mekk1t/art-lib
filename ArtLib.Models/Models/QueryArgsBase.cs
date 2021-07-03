namespace KitProjects.ArtLib.Core.Models
{
    public class QueryArgsBase
    {
        public long LastId { get; init; }
        public int Limit { get; init; }
        public bool WithRelationships { get; init; }
    }
}
