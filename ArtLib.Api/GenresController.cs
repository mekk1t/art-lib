using KitProjects.Api.AspNetCore;
using Microsoft.Extensions.Logging;

namespace KitProjects.ArtLib.Api
{
    public class GenresController : ApiJsonController
    {
        public GenresController(ILogger<GenresController> logger) : base(logger)
        {
        }
    }
}
