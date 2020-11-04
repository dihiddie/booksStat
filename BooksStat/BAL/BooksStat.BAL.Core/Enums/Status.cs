namespace BooksStat.BAL.Core.Enums
{
    using System.ComponentModel;

    public enum Status
    {
        [Description("Добавлено")]
        Added = 1,
        [Description("Недочитано")]
        NotFinished = 2,
        [Description("Прочитано")]
        Readed = 3,
        [Description("Хочу прочитать")]
        WantToRead = 4
    }
}
