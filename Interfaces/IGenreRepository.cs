using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
