using KitProjects.ArtLib.Core.Models;
using System.Collections.Generic;

namespace KitProjects.ArtLib.Core.Abstractions
{
    public interface ICrud<TEntity, TQueryArgs>
        where TEntity : class, new()
        where TQueryArgs : QueryArgsBase
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> Read(TQueryArgs baseArgs = default);
        TEntity ReadOrDefault(long id);
        void Update(TEntity entity);
        void Delete(long id);
    }
}
