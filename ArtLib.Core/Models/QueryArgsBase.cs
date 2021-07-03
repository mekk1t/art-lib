namespace KitProjects.ArtLib.Core.Models
{
    public class QueryArgsBase
    {
        public long LastId { get; init; }
        public int Limit { get; init; }
        public bool WithRelationships { get; init; }

        public QueryArgsBase()
        {
            LastId = 0;
            Limit = 25;
            WithRelationships = false;
        }
    }
}
