using System;
using System.Data;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;

namespace PhoneDataBase
{
	public class CL
	{
		/// Interacts with user, providing abilities to use database.
		public static void Main()
		{
			string mongoClientName = "mongodb://localhost";
			string dataBaseName = "PhoneDataBase";
			var client = new MongoClient(mongoClientName);
			var database = client.GetDatabase(dataBaseName);
			var collection = database.GetCollection<Human>(dataBaseName);
			showReferences();
			ushort command = Convert.ToUInt16(Console.ReadLine());
			while (command != 0)
			{
				switch (command)
				{
					case 1:
					{
						Console.WriteLine("Adding new Human being to the data base.");
						Console.WriteLine("Please, enter one's name and phone number in different lines.");
						var newOne = new Human(Console.ReadLine(), Console.ReadLine());
						var list = collection.Find(new BsonDocument()).ToList();
						foreach (var el in list)
						{
							if (el.PhoneNumber == newOne.PhoneNumber)
							{
								Console.WriteLine("{0} is the only true owner of {1} number", el.Name, el.PhoneNumber);
								goto default; //That's just an experiment, no need to be punished with Dijkstra.
							}
						}
						collection.InsertOne(newOne);
						Console.WriteLine("Addition successed.");
						break;
					}
					case 2:
					{
						Console.WriteLine("Trying to find one by name.");
						Console.WriteLine("Enter some name.");
						var needed = Console.ReadLine();
						Console.WriteLine("The numbers of {0}:", needed);

						int length = 0;
						var list = collection.Find(new BsonDocument()).ToList().Where(x => x.Name == needed);
						foreach (var el in list)
						{
							length++;
							Console.WriteLine("{0} - {1}", el.Name, el.PhoneNumber);
						}
						if (length != 0)
						{
							Console.WriteLine("That is all for now.");
						}
						else
						{
							Console.WriteLine("The list of phones is empty.");
						}
						break;
					}
					case 3:
					{
						Console.WriteLine("Trying to find one by number.");
						Console.WriteLine("Enter some number.");
						var needed = Console.ReadLine();

						int length = 0;
						Console.WriteLine("The man who ones the number {0}:", needed);
						var list = collection.Find(new BsonDocument()).ToList().Where(x => x.PhoneNumber == needed);
						foreach (var el in list)
						{
							length++;
							Console.WriteLine("{0} - {1}", el.Name, el.PhoneNumber);
						}
						if (length != 0)
						{
							Console.WriteLine("The man is found.");
						}
						else
						{
							Console.WriteLine("The man is not found.");
						}
						break;
					}
					case 4:
					{
						var list = collection.Find(new BsonDocument())	.ToList();
						Console.WriteLine("Here comes the list:");

						int length = 0;
						foreach (var el in list)
						{
							length++;
							Console.WriteLine("{0} - {1};", el.Name, el.PhoneNumber);
						}
						if (length != 0)
						{
							Console.WriteLine("The list is over.");
						}
						else
						{
							Console.WriteLine("The list is empty.");
						}
						break;
					}
					case 5:
					{
						showReferences();
					}
					default:
					{
						break;
					}
				}
				Console.WriteLine("Enter new command.");
				command = Convert.ToUInt16(Console.ReadLine());
			}
			Console.WriteLine("Successfully exiting. Farewell!");





			// Note l = new Note();
			// l.L = 1;
			// collection.InsertOne(l);
			// var list = collection.Find(new BsonDocument())	.ToList();
			// foreach (var el in list)
			// {
			// 	Console.WriteLine(el.L);
			// }
			
		}

		private static void showReferences()
		{
			Console.WriteLine("Use one of the following commands:");
			Console.WriteLine("0 - exit;");
			Console.WriteLine("1 - enter new contact;");
			Console.WriteLine("2 - find phone number by name;");
			Console.WriteLine("3 - find name by phone number;");
			Console.WriteLine("4 - show current contacts.");
		}

		/// The class describes single note in the database.
		private class Human
		{
			public Human(string name, string phoneNumber)
			{
				Name = name;
				PhoneNumber = phoneNumber;
			}

			public ObjectId Id {get; set;}
			public string Name {get; set;}
			public string PhoneNumber {get; set;}
		}
	}
}