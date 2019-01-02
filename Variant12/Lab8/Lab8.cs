using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Set<T> : ISet<T>
{
    T[] array;
    public Set()
    {
        array = new T[0];
    }

    bool ISet<T>.Add(T item)
    {
        return Add(item);
    }

    void ICollection<T>.Add(T item)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = item;
    }

    public bool Add(T item)
    {
        if (Contains(item))
            return false;
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = item;
        return true;
    }

    public void Clear()
    {
        array = new T[0];
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < array.Length; i++)
            if (array[i].Equals(item))
                return true;
        return false;
    }

    public void CopyTo(T[] _array, int arrayIndex)
    {
        for (int i = 0; i < array.Length; i++)
            _array[i + arrayIndex] = array[i];
    }
    public void ExceptWith(IEnumerable<T> other)
    {
        foreach (T item in other)
        {
            if (Contains(item))
            {
                int index = 0;
                while (!array[index].Equals(item))
                    index++;
                for (int i = index; i < array.Length - 1; i++)
                    array[i] = array[i + 1];
                Array.Resize(ref array, array.Length - 1);
            }
        }
    }
    IEnumerable<T> for_each()
    {
        for (int i = 0; i < array.Length; i++)
            yield return array[i];
    }
    void erase(int index)
    {
        for (int i = index; i < array.Length - 1; i++)
            array[i] = array[i + 1];
        Array.Resize(ref array, array.Length - 1);
    }
    public IEnumerator<T> GetEnumerator()
    {
        return for_each().GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        for (int i = array.Length - 1; i >= 0; i--)
            if (!other.Contains(array[i]))
                erase(i);
    }
    /// <summary>
    /// Подмножество
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        if (array.Length == 0 || other.ToArray().Length == 0)
            return true;
        for (int i = 0; i < array.Length; i++)
            if (other.Contains(array[i]))
                continue;
            else
                return false;
        T[] a = other.ToArray();
        for (int i = 0; i < a.Length; i++)
            if (Contains(a[i]))
                continue;
            else
                return true;
        return false;
    }
    /// <summary>
    /// Надмножество
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        int otherLength = other.ToArray().Length;
        if (array.Length == 0 || otherLength == 0)
            return true;
        if (array.Length <= otherLength)
            return false;
        int exist = 0, notExist = 0;
        for (int i = 0; i < array.Length; i++)
            if (other.Contains(array[i]))
                exist++;
            else
                notExist++;

        return exist != 0 && notExist != 0;
    }
    public bool IsSubsetOf(IEnumerable<T> other)
    {
        if (array.Length == 0)
            return true;
        for (int i = 0; i < array.Length; i++)
            if (!other.Contains(array[i]))
                return false;
        return true;
    }
    public bool IsSupersetOf(IEnumerable<T> other)
    {
        if (array.Length < other.ToArray().Length)
            return false;
        T[] a = other.ToArray();
        for (int i = 0; i < a.Length; i++)
            if (!Contains(a[i]))
                return false;
        return true;
    }
    /// <summary>
    /// Истина если хотя бы один элемент общий
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Overlaps(IEnumerable<T> other)
    {
        T[] a = other.ToArray();
        if (a.Length > array.Length)
        {
            for (int i = 0; i < a.Length; i++)
                if (Contains(a[i]))
                    return true;
            return false;
        }
        else
            for (int i = 0; i < array.Length; i++)
                if (other.Contains(array[i]))
                    return true;
        return false;
    }
    public bool Remove(T item)
    {
        if (Contains(item))
        {
            int index = 0;
            while (!array[index].Equals(item))
                index++;
            erase(index);
            return true;
        }
        else
            return false;
    }
    void erase(ref T[] a, int index)
    {
        for (int i = index; i < a.Length - 1; i++)
            a[i] = a[i + 1];
        Array.Resize(ref a, a.Length - 1);
    }
    /// <summary>
    /// Истина если во обоих множествах одинаковые элементы. Дубли и порядок не важен
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool SetEquals(IEnumerable<T> other)
    {
        T[] a = other.ToArray();
        for (int i = 0; i < a.Length; i++)
            if (!Contains(a[i]))
                return false;
        for (int i = 0; i < array.Length; i++)
            if (!other.Contains(array[i]))
                return false;
        return true;
    }
    /// <summary>
    /// Изменяет текущий набор, чтобы он содержал только элементы, 
    /// которые имеются либо в текущем наборе или в указанной 
    /// коллекции, но не одновременно.
    /// </summary>
    /// <param name="other"></param>
    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        Set<T> newSet = new Set<T>();
        for (int i = 0; i < array.Length; i++)
            if (!other.Contains(array[i]))
                newSet.Add(array[i]);
        T[] a = other.ToArray();
        for (int i = 0; i < a.Length; i++)
            if (!Contains(a[i]))
                newSet.Add(a[i]);
        array = newSet.array;
    }
    public void UnionWith(IEnumerable<T> other)
    {
        Set<T> set = new Set<T>();
        for (int i = 0; i < array.Length; i++)
            set.Add(array[i]);
        foreach (T item in other)
            set.Add(item);
        array = set.array;
    }
    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }
    public int Count
    {
        get
        {
            return array.Length;
        }
    }
}

namespace Lab8
{
    class Lab8
    {
        static void Main(string[] args)
        {
            Set<int> set = new Set<int> { 1, 2, 3 };
            Console.Write(set.Contains(1) + " ");
            HashSet<int> hash = new HashSet<int> { 1, 2, 3 };
            Console.WriteLine(hash.Contains(1));
            Console.WriteLine(set.Count + " " + hash.Count);
            set.Add(5);
            hash.Add(5);
            set.ExceptWith(new int[] { 2, 3 });
            hash.ExceptWith(new int[] { 2, 3 });
            Console.Write(string.Join(" ", set.ToArray()) + " | " + string.Join(" ", hash.ToArray()));
            set.IntersectWith(new int[] { 1, 2 });
            hash.IntersectWith(new int[] { 1, 2 });
            Console.WriteLine();
            Console.Write(string.Join(" ", set.ToArray()) + " | " + string.Join(" ", hash.ToArray()));
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int val = rnd.Next(0, 10);
                set.Add(val);
                hash.Add(val);
            }
            Console.WriteLine();
            Console.WriteLine(new Set<int>().IsProperSubsetOf(new int[] { 1 }) + " " +
                new HashSet<int>().IsProperSubsetOf(new int[] { 1 }));
            Console.WriteLine(new Set<int> { 1 }.IsProperSubsetOf(new int[] { 1 }) + " " +
                new HashSet<int> { 1 }.IsProperSubsetOf(new int[] { 1 }));
            Console.WriteLine(new Set<int> { 1 }.IsProperSubsetOf(new int[] { 1, 2 }) + " " +
                new HashSet<int> { 1 }.IsProperSubsetOf(new int[] { 1, 2 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 3, 4, 5 }) + " " +
                new HashSet<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 4, 5 }) + " " +
                new HashSet<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSupersetOf(new int[] { 1, 2, 3, 4, 5 }) + " " +
                 new HashSet<int> { 1, 2, 3 }.IsProperSupersetOf(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsProperSupersetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsProperSupersetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3, 8, 9 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3, 8, 9 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3, 8, 9 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3, 8, 9 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.Overlaps(new int[] { 1, 2, 3 }) + " " +
                 new HashSet<int> { 1, 2, 3, 8 }.Overlaps(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 0 }.Overlaps(new int[] { 1, 2, 3 }) + " " +
                 new HashSet<int> { 0 }.Overlaps(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.SetEquals(new int[] { 2, 1, 3, 1 }) + " " +
                 new HashSet<int> { 1, 2, 3 }.SetEquals(new int[] { 2, 1, 3, 1 }));
            set.SymmetricExceptWith(new int[] { 1, 3 });
            hash.SymmetricExceptWith(new int[] { 1, 3 });
            Console.WriteLine(string.Join(" ", set) + " | " + string.Join(" ", hash));
            set.UnionWith(new int[] { 1, 2, 3, 4 });
            hash.UnionWith(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(string.Join(" ", set) + " | " + string.Join(" ", hash));
            Console.ReadKey(true);
        }
    }
}
