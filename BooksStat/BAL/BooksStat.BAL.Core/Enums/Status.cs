namespace BooksStat.BAL.Core.Enums
{
    using System.ComponentModel;

    public enum Status
    {
        [Description("Добавлено")]
        Added,
        [Description("Недочитано")]
        NotFinished,
        [Description("Прочитано")]
        Readed,
        [Description("Хочу прочитать")]
        WantToRead,
        [Description("Любимое")]
        Favorite
    }
}
