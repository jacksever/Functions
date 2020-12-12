using System;
using System.Collections.Generic;
using System.Linq;

namespace Function
{
	public class Program
	{
		static void Main(string[] args)
		{
			Task_8();
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
				foreach (var item in text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray())
				{
					parser.Add(int.Parse(item));
				}
				return parser.Min();
			};

			Console.WriteLine(min(input));
		}

		static void Task_4()
		{
			Func<string, string, bool> data = (text, action) =>
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

		// PART 2

		static void Task_5()
		{
			Func<string, bool> operations = data =>
			{
				var parser = new List<int>();
				foreach (var item in data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray())
				{
					parser.Add(int.Parse(item));
				}

				int[] result = parser.ToArray();

				while (true)
				{
					var command = Console.ReadLine();

					if (command == "end")
						return true;

					switch (command)
					{
						case "add":
							for (int i = 0; i < result.Length; i++)
								result[i]++;
							break;

						case "multiply":
							for (int i = 0; i < result.Length; i++)
								result[i] = result[i] * 2;
							break;

						case "subtract":
							for (int i = 0; i < result.Length; i++)
								result[i] = result[i] - 1;
							break;

						case "print":
							for (int i = 0; i < result.Length; i++)
								Console.Write(result[i] + " ");
							break;
					}
				}
			};

			operations(Console.ReadLine());
		}

		static void Task_6()
		{
			Func<string, int, List<int>> reversList = (data, number) =>
			{
				var parser = new List<int>();
				foreach (var item in data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray())
				{
					parser.Add(int.Parse(item));
				}

				foreach (var item in parser.ToList())
				{
					if (item % number == 0)
						parser.Remove(item);
				}

				parser.Reverse();
				return parser;
			};

			foreach(var item in reversList(Console.ReadLine(), int.Parse(Console.ReadLine())))
			{
				Console.Write(item + " ");
			}
		}

		static void Task_7()
		{
			Func<int, string, List<string>> checkNames = (number, data) =>
			{
				string[] text = data.Split(new char[] { ' ' });
				var result = new List<string>();

				foreach (var item in text)
				{
					if (item.Length <= number)
						result.Add(item);
				}

				return result;
			};

			foreach (var item in checkNames(int.Parse(Console.ReadLine()), Console.ReadLine()))
			{
				Console.Write(item + " ");
			}
		}

		static void Task_8()
		{
			Func<string, int[]> comparator = data =>
			{
				var parser = new List<int>();
				foreach (var item in data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray())
				{
					parser.Add(int.Parse(item));
				}

				var array = parser.ToArray();

				Array.Sort(array, new NumberComparator());

				return array;
			};

			foreach(var item in comparator(Console.ReadLine()))
			{
				Console.Write(item + " ");
			}
		}
	}

	public class NumberComparator : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			if (y % 2 == 0)
				return 1;
			if (x % 2 == 0)
				return -1;
			else
				return 0;
		}
	}
}
