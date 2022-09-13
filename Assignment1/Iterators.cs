namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        return (IEnumerable<T>) new List<int>();
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach(var item in items)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}