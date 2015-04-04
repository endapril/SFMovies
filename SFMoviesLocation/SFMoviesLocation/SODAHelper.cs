using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SODA;
using SFMoviesLocation.Models;


namespace SFMoviesLocation
{
    public class SODAHelper
    {
        #region Constants

        private const string _AppToken = "fjfnjqw9G2xAzePnnXYRN7N8q";

        private const string _APIEndPointHost = "data.sfgov.org";

        private const string _APIPort4by4 = "yitu-d5am";

        private static string[] _APIFieldNames = {"title", "release_year", "locations", "fun_facts", "production_company", 
                "distributor", "director", "writer", "actor_1", "actor_2", "actor_3"};

        #endregion
        public static IEnumerable<Movie> GetMoviesByTitle(string MovieTitle)
        {
            var client = new SodaClient(_APIEndPointHost, _AppToken);
            var dataset = client.GetResource<List<Movie>>(_APIPort4by4);
            var soql = new SoqlQuery().Select(_APIFieldNames);

            if (!string.IsNullOrEmpty(MovieTitle))
            {
                return dataset.Query<Movie>(soql).Where(x => MovieTitle.Equals(x.Title.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            return  dataset.Query<Movie>(soql);
        }

        public static IEnumerable<Movie> GetMoviesByYear(string Year)
        {
            var client = new SodaClient(_APIEndPointHost, _AppToken);
            var dataset = client.GetResource<List<Movie>>(_APIPort4by4);
            var soql = new SoqlQuery().Select(_APIFieldNames);

            if (!string.IsNullOrEmpty(Year))
            {
                return dataset.Query<Movie>(soql).Where(x => Year.Equals(x.Release_Year, StringComparison.OrdinalIgnoreCase));
            }

            return dataset.Query<Movie>(soql);
        }

        public static IEnumerable<Movie> GetMoviesFuzzySearch(string SearchString)
        {
            var client = new SodaClient(_APIEndPointHost, _AppToken);
            var dataset = client.GetResource<List<Movie>>(_APIPort4by4);
            var soql = new SoqlQuery().Select(_APIFieldNames);

            if (!string.IsNullOrEmpty(SearchString))
            {
                soql = new SoqlQuery().FullTextSearch(SearchString.ToUpper().Trim());
            }
            var result = dataset.Query<Movie>(soql);
            return result;
        }



        public static IEnumerable<string> GetAllMoviesTitle()
        {
            var client = new SodaClient(_APIEndPointHost, _AppToken);
            var dataset = client.GetResource<List<Movie>>(_APIPort4by4);
            string[] columns = new[] {"title"};
            var soql = new SoqlQuery().Select(columns);
            return dataset.Query<Movie>(soql).Select(x => x.Title).Distinct();
            
        }

    }
}