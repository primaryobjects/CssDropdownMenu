using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CssDropDownMenu.Managers
{
    public static class UIManager
    {
        /// <summary>
        /// Returns a Dictionary list of key/value pairs for an enum, using the string values assigned to each enum value.
        /// The key is the string value of the enum.
        /// The value is the description value of the enum.
        /// Example:
        /// @Html.DropDownListFor(p => p.Category, UIManager.GetDropDownList(() => UIManager.GetEnumStrings[CategoryEnum](), false))
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns>Dictionary of string,string</returns>
        public static Dictionary<string, string> GetEnumStrings<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }
            else
            {
                Dictionary<string, string> list = new Dictionary<string, string>();

                // Enumerate all values for this enum.
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    // Add an entry for each enum using the value and string attribute.
                    list.Add(item.GetHashCode().ToString(), item.GetDescription());
                }

                return list;
            }
        }

        /// <summary>
        /// Returns a list of SelectListItem from a method call (such as a web service call).
        /// Example usage:
        /// @Html.DropDownListFor(e => e.CountryId, UIManager.GetDropDownList(() => UIManager.GetEnumStrings<DateFilterType>(), false))
        /// </summary>
        /// <param name="getList">Anonymous delegate method that returns a list of Dictionary(string, string).</param>
        /// <param name="includeDefault">Include a default option at the top of the list, "Please choose ..".</param>
        /// <returns>List of SelectListItem</returns>
        public static List<SelectListItem> GetDropDownList(Func<Dictionary<string, string>> getList, bool includeDefault = true)
        {
            List<SelectListItem> resultList = new List<SelectListItem>();

            foreach (var item in getList())
            {
                resultList.Add(new SelectListItem { Text = item.Value, Value = item.Key.ToString() });
            }

            if (includeDefault)
            {
                resultList.Insert(0, new SelectListItem { Text = "Please choose ..", Value = "" });
            }

            return resultList;
        }

        /// <summary>
        /// Returns the description value attribute on a field, using the DescriptionAttribute. Useful for enum values. If no DescriptionAttribute is found, the field name is returned as a string.
        /// Example:
        /// public enum Test
        /// {
        ///     [Description("first")]
        ///     Foo = 0,
        ///     [Description("second")]
        ///     Bar = 1
        /// }
        /// </summary>
        /// <param name="value">Enum</param>
        /// <returns>string</returns>
        public static string GetDescription<TEnum>(this TEnum value)
        {
            // Get the type.
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the description attribute.
            DescriptionAttribute[] attribs = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Description : value.ToString();
        }
    }
}