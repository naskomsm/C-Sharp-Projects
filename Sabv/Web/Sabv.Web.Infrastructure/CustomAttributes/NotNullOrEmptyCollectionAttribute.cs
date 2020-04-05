namespace Sabv.Web.Infrastructure.CustomAttributes
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;

    public class NotNullOrEmptyCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var collection = value as ICollection;
            if (collection != null)
            {
                return collection.Count >= 1 && collection.Count <= 10;
            }

            var enumerable = value as IEnumerable;
            return enumerable != null && enumerable.GetEnumerator().MoveNext();
        }
    }
}
