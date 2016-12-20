using System;

namespace Set
{
	public static class CL
	{
		static public void Main()
		{
			var set1 = new Set<int>();
			var set2 = new Set<int>();
			set1.Add(1);
			set1.Add(3);
			set1.Add(5);
			set2.Add(2);
			set2.Add(3);
			set2.Add(4);
			set1.Print();
			set2.Print();
			(set1 + set2).Print();
			(set1 * set2).Print();
		}
	}
}