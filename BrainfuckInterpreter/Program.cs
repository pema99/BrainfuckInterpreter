using System;
using System.Collections.Generic;
namespace BrainfuckInterpreter
{
	public class Test
	{
		public static void Main() { new Test().Start();	}

		byte[] Data { get; set; }  
		int Current { get; set; }

		public void Start()
		{
			Data = new byte[30000];
			Current = 0;

			Console.WriteLine("Write program:");
			string Program = Console.ReadLine();

			char[] Feed = Program.ToCharArray();
			for (int i = 0; i < Feed.Length; i++)
			{
				char Op = Feed[i];

				if (Op == ' ')
					continue;

				switch (Op)
				{
					case '>':
						Current++;
						break;

					case '<':
						Current--;
						break;

					case '+':
						Data[Current]++;
						break;

					case '-':
						Data[Current]--;
						break;

					case '.':
						Console.Write(Convert.ToChar(Data[Current]));
						break;

					case ',':
						string Input = Console.ReadLine();
						if (Input != "")
							Data[Current] = Convert.ToByte(Input.ToCharArray()[0]);
						break;

					case '[':
						int Temp1 = 1;
						if (Data[Current] == '\0')
						{
							do 
							{
								i++;
								if      
									(Feed[i] == '[') Temp1++;
								else if 
									(Feed[i] == ']') Temp1--;
							} while (Temp1 != 0);
						}
						break;

					case ']':
						int Temp2 = 0;
						do 
						{
							if      
								(Feed[i] == '[') Temp2++;
							else if 
								(Feed[i] == ']') Temp2--;
							i--;
						} while (Temp2 != 0);
						break;

					default:
						break;
				}
			}
		}
	}
}