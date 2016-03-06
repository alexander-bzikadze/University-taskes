using System;

namespace UniqueList
{
    public class UniqueList : ArrayList
    {
        override public void Add(int value)
        {
            if (Search(value))
            {
                throw new ListNullException("Trying to add exinsting value.");
            }
            else
            {
                list.Add(value);
            }
        }

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
                throw new ListNullException("Trying to delete strange element.");
            }
        }
    }
}