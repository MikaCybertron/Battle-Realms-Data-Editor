using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DictionaryExtensions
{
    public static bool IsKeyExists<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
    {
        if (dictionary.Count > 0)
        {
            var comparer = EqualityComparer<TKey>.Default;
            foreach (var pair in dictionary)
            {
                if (comparer.Equals(pair.Key, key))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static void Items<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.IsKeyExists(key))
        {
            dictionary[key] = value;
        }
        else
        {
            dictionary.Add(key, value);
        }
    }

    public static void XAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.IsKeyExists(key))
        {
            dictionary[key] = value;
        }
        else
        {
            dictionary.Add(key, value);
        }
    }
}
