namespace KitProjects.ArtLib.Core.Models
{
    public class QueryArgsBase
    {
        public long LastId { get; }
        public int Limit { get; }
        public bool WithRelationships { get; }

        public QueryArgsBase(long lastId = 0, int limit = 25, bool withRelationships = false)
        {
            LastId = lastId;
            Limit = limit;
            WithRelationships = withRelationships;
        }
    }
}
