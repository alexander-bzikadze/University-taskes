using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Reads data from file "input.txt". Realization of IReader.
	public class Reader : IReader
	{
		/// Read net from file.
		public ReadResult ReadFromFile()
		{
			using (var file = new System.IO.StreamReader("input.txt"))
			{
				var firstLine = file.ReadLine().Split(' ');
				long computerNumber = Convert.ToInt64(firstLine[0]);
				long osNumber = Convert.ToInt64(firstLine[1]);
				long virusNumber = Convert.ToInt64(firstLine[2]);
				var res = new Tuple<bool[,], Computer[], Os[], Virus[]>(new bool[computerNumber, computerNumber], 
						new Computer[computerNumber], new Os[osNumber], new Virus[virusNumber]);

				for (int i = 0; i < computerNumber; ++i)
				{
					var line = file.ReadLine().Split(' ');
					int j = 0;
					foreach (var elem in line)
					{
						res.Item1[i, j] = Convert.ToBoolean(Convert.ToInt16(elem));
						j++;
					}
				}

				for (int i = 0; i < osNumber; ++i)
				{
					var line = file.ReadLine().Split(' ');
					res.Item3[i] = new Os(Convert.ToString(line[0]));
					for (int j = 1; j < line.Length; ++j)
					{
						res.Item2[Convert.ToInt64(line[j])] = new Computer(res.Item3[i]);
					}
				}

				for (int i = 0; i < virusNumber; ++i)
				{
					var line = file.ReadLine().Split(' ');
					var PoisonChances = new Tuple<String, Double>[osNumber];
					for (int j = 1; j < osNumber + 1; ++j)
					{
						PoisonChances[j - 1] = new Tuple<String, Double>(res.Item3[j - 1].Name, Convert.ToDouble(line[j]));
					}
					res.Item4[i] = new Virus(Convert.ToString(line[0]), PoisonChances);
					res.Item2[Convert.ToInt64(line[line.Length - 1])].Virus = res.Item4[i];
				}
				return new ReadResult(res);
			}
		}
	}
}