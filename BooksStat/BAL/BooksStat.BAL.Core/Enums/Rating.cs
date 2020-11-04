namespace BooksStat.BAL.Core.Enums
{
    using System.ComponentModel;

    public enum Rating
    {
        [Description("5")]
        Five = 5,
        [Description("4")]
        Four = 4,
        [Description("3")]
        Three = 3,
        [Description("2")]
        Two = 2,
        [Description("1")]
        One = 1
    }
}
