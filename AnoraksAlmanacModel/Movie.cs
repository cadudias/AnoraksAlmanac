using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnoraksAlmanacModel
{
    public class Movie
    {
        public int Id
        {
            get; set;
        }

        public string OriginalTitle
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string OriginalLanguage
        {
            get; set;
        }

        public string PosterPath
        {
            get; set;
        }

        public bool Adult
        {
            get; set;
        }

        public string Overview
        {
            get; set;
        }

        //[NotMapped]
        public DateTimeOffset ReleaseDate
        {
            get; set;
        }

        [NotMapped]
        public ICollection<int> GenreIds
        {
            get; set;
        }

        public string BackdropPath
        {
            get; set;
        }

        public double Popularity
        {
            get; set;
        }

        public int VoteCount
        {
            get; set;
        }

        public string Video
        {
            get; set;
        }

        public double VoteAverage
        {
            get; set;
        }

        [NotMapped]
        public MoviesListsTypes ListType
        {
            get;
            set;
        }
    }
}