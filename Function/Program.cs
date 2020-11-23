using System;
using System.Collections.Generic;
using System.Linq;

namespace Function
{
	public class Program
	{
		static void Main(string[] args)
		{
			Task_3();
		}

		static void Task_1()
		{
			Action<string> print = text => { foreach (var s in text.Split(new char[] { ' ' })) { Console.WriteLine(s); } };
			print(Console.ReadLine());
		}

		static void Task_2()
		{
			Action<string> print = text => { foreach (var s in text.Split(new char[] { ' ' })) { Console.WriteLine(s + " (нет в наличии)"); } };
			print(Console.ReadLine());
		}

		static void Task_3()
		{
			string input = Console.ReadLine();

			Func<string, int> min = text =>
			{
				List<int> parser = new List<int>();
				foreach(var item in text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray()) 
				{
					parser.Add(int.Parse(item));
				}
				return parser.Min();
			};

			Console.WriteLine(min(input));
		}

		static void Task_4()
		{
			Func<string, string, bool> data = (text, action)  =>
			{
				string[] num = text.Split(new char[] { ' ' });

				if (num.Length != 2)
					throw new Exception("Введите диапазон значений!");

				for (int i = int.Parse(num[0]); i <= int.Parse(num[1]); i++)
				{
					switch (action)
					{
						case "even":
							if (i % 2 == 0)
								Console.Write(i + " ");
							break;

						default:
							if (i % 2 != 0)
								Console.Write(i + " ");
							break;
					}

				}
				return true;
			};

			data(Console.ReadLine(), Console.ReadLine());
		}
	}
}
