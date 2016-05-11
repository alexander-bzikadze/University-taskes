using System;

namespace List
{
	public class CL
	{
		public static void Main()
		{
			var list = new List<int>();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			list.Add(4);
			list.Add(5);
			list.Add(6);
			list.Add(7);
			list.Add(8);
			list.Add(9);
			list.Add(10);
			list.Delete(10);
			list.Delete(1);
			list.Delete(5);
			foreach (var element in list)
			{
				Console.WriteLine(element);
			}
			list.Delete(2);
			list.Delete(9);
			list.Delete(4);
			list.Delete(7);
			Console.WriteLine();
			foreach (var element in list)
			{
				Console.WriteLine(element);
			}
		}
	}
}