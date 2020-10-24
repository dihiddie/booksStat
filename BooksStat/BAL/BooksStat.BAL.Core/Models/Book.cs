namespace BooksStat.BAL.Core.Models
{
    using System.Collections.Generic;

    using BooksStat.BAL.Core.Enums;
    using BooksStat.Utils.Enum;

    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string SelectedRating { get; set; }

        public string SelectedStatus { get; set; }

        public Rating SelectedRatingAsEnum => EnumExtensions.GetParsedEnum<Rating>(SelectedRating);

        public Status SelectedStatusAsEnum => EnumExtensions.GetParsedEnum<Status>(SelectedStatus);

        public IEnumerable<string> StatusList => EnumExtensions.GetEnumAsList<Status>();

        public IEnumerable<string> RatingList => EnumExtensions.GetEnumAsList<Rating>();

    }
}