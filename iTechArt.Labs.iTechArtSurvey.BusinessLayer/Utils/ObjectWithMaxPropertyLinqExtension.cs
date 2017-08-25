using System;
using System.Collections.Generic;
using System.Linq;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Utils
{
    internal static class ObjectWithMaxPropertyLinqExtension
    {
        internal static T GetByMax<T>(this IEnumerable<T> collection, Func<T, int> selector)
        {
            return collection.OrderByDescending(selector).FirstOrDefault();
        }
    }
}
