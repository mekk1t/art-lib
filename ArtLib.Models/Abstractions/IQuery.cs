using KitProjects.ArtLib.Core.Models;

namespace KitProjects.ArtLib.Core.Abstractions
{
    public interface IQuery<out TResult>
    {
        TResult Query();
    }

    public interface IQuery<out TResult, in TArgs>
        where TResult : class, new()
        where TArgs : QueryArgsBase
    {
        TResult Query(TArgs args);
    }
}
