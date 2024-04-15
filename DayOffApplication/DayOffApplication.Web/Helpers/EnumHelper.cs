using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace DayOffApplication.Web.Helpers
{
    public static class EnumHelper<T> where T : struct, IConvertible
    {
        public static List<object> GetEnumDataSource()
        {
            var items = new List<object>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var fieldInfo = typeof(T).GetField(item.ToString());

                // Get DisplayAttribute
                var displayAttribute = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
                string text = displayAttribute != null ? displayAttribute.Name : item.ToString();

                items.Add(new { Value = item, Text = text });
            }
            return items;
        }
    }

}
