using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace DayOffApplication.Web.Helpers
{
    /// <summary>
    /// GetEnumDataSource metodu, enum'un tüm değerlerini ve bunların metin temsilini içeren bir liste döndürür.
    /// Value degeri Text kullaının gördüğü alanı
    /// Static Neden =>  bu sınıfın bir yardımcı işlevi gerçekleştirmesi ve bir örneğe ihtiyaç duyulmamasıdır.
    /// İşlevselliğine bakıldığında, EnumHelper sınıfının bir durum tutmadığı ve herhangi bir nesneye özgü davranış içermediği görülebilir.
    /// IConvertible => Çeşitli türlere dönüştürelebilecegini  
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
