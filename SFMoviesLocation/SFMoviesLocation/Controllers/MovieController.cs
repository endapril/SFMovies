using SFMoviesLocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SFMoviesLocation.Controllers
{
    /// <summary>
    /// API controller.
    /// </summary>
    public class MovieController : ApiController
    {
        /// <summary>
        /// Gets all Movies.
        /// </summary>
        /// <returns>The all movies.</returns>
        public IEnumerable<Movie> Get()
        {
            var list = SODAHelper.GetMoviesByTitle(null).ToList();
            return list;
        }

        /// <summary>
        /// Gets the movies by title.
        /// </summary>
        /// <param name="Title">The title.</param>
        /// <returns>The movies with the input title.</returns>
        public IEnumerable<Movie> GetByTitle(string Title)
        {
            var list = SODAHelper.GetMoviesByTitle(Title).ToList();
            return list;
        }

        /// <summary>
        /// Gets the movies by year.
        /// </summary>
        /// <param name="Year">The movie release year.</param>
        /// <returns>The movies with the input year.</returns>
        public IEnumerable<Movie> GetByYear(string Year)
        {
            var list = SODAHelper.GetMoviesByYear(Year).ToList();
            return list;
        }

        /// <summary>
        /// Gets the movies by fuzzy search.
        /// </summary>
        /// <param name="FuzzySearch">The search string.</param>
        /// <returns>The movies with the input search string.</returns>
        public IEnumerable<Movie> Get(string FuzzySearch)
        {
            var list = SODAHelper.GetMoviesFuzzySearch(FuzzySearch).ToList();
            return list;
        }

    }
}
