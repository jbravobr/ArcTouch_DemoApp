using System;
using System.Linq;
using System.Reflection;

namespace ArcTouch.TestApp
{
    public static class GetEnumDescriptionAttribute
    {
        /// <summary>
        /// Gets the type of the attribute of.
        /// </summary>
        /// <returns>The attribute of type.</returns>
        /// <param name="enumVal">Enum value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());

            return v.GetCustomAttribute<T>();
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns>The description.</returns>
        /// <param name="enumVal">Enum value.</param>
        public static string GetDescription(this Enum enumVal)
        {
            var attr = GetAttributeOfType<EnumDescriptionAttribute>(enumVal);

            return attr != null ? attr.Description : string.Empty;
        }
    }
}