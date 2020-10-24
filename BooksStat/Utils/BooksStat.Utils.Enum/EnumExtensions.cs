namespace BooksStat.Utils.Enum
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    using Enum = System.Enum;

    public static class EnumExtensions
    {
        public static IEnumerable<string> GetEnumAsList<T>()
            where T : Enum
        {
            var list = new List<string>();
            foreach (T enumValue in Enum.GetValues(typeof(T))) list.Add(enumValue.GetEnumDescription());
            return list;
        }

        public static T GetParsedEnum<T>(string value) where T : Enum => (T)Enum.Parse(typeof(T), value, true);

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}