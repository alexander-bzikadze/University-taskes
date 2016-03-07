using System;

namespace UniqueList
{
    ///Contains unique integer values, adds them,
    ///deletes, searches by value and prints with O(n).
    public class UniqueList : ArrayList
    {
        ///Serches for value and throws exception if found.
        ///Otherwise, adds it.
        ///Throws exception if there are more than 100 values.
        override public void Add(int value)
        {
            if (Search(value))
            {
                throw new UniqueListAddExisting("Trying to add exinsting value.");
            }
            else
            {
                list.Add(value);
            }
        }

        ///Searches for value and deletes it if found.
        ///Otherwise, throws exception.
        override public void DeleteElement(int value)
        {
            list.SetIteratorFirst();
            while (!list.IsIteratorNull() && list.GetIteratorValue() != value)
            {
                list.MoveIteratorForward();
            }
            if (!list.IsIteratorNull())
            {
                list.DeleteElement();
            }
            else
            {
                throw new UniqueListDeleteStrange("Trying to delete strange element.");
            }
        }
    }
}