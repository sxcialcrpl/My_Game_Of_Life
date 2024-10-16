using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;

namespace GOL {
	class Program {
		

		static void Main(string[] args) {
			Console.CursorVisible = false;

			Console.BufferHeight = 5000;
			Console.BufferWidth = 3500; 
			var Settings = new Hashtable();

			#if DEBUG
			string pathToRules=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\rules\\rules.txt");
			string pathToField=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\rules\\field.txt");
			#endif
			#if !DEBUG
			string pathToRules=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rules\\rules.txt");
			string pathToField=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rules\\field.txt");
			#endif
			
			
			StreamReader sr = new StreamReader(pathToRules);

			string line;
			while((line = sr.ReadLine()) != null){
				int i = line.Length - 1;
				while(line[i] != ' '){
					i--;
				}
				Settings.Add(line[0], line.Substring(i));
			}
			
			double time;
			int min4l; 
			int max4l;
			int val4r;
			ConsoleColor clr4back;
			ConsoleColor clr4font;
			int theme;
			char chr4d;
			char chr4l;
			//инициализация параметров

			min4l = Convert.ToInt32(Settings['1']);
			max4l = Convert.ToInt32(Settings['2']);
			val4r = Convert.ToInt32(Settings['3']);
			try{
				time = Convert.ToDouble(Settings['4'].ToString().Replace(',', '.'));
			}catch{
				time = Convert.ToDouble(Settings['4'].ToString().Replace('.', ','));
			}
			clr4back = (ConsoleColor)Convert.ToInt32(Settings['5']);
			clr4font = (ConsoleColor)Convert.ToInt32(Settings['6']);
			theme = Convert.ToInt32(Settings['7']);
			chr4d = Settings['8'].ToString().Trim().Length == 0 ? ' ' : Convert.ToChar(Settings['8'].ToString().Trim());
			chr4l = Settings['9'].ToString().Trim().Length == 0 ? ' ' : Convert.ToChar(Settings['9'].ToString().Trim());
			

			switch(theme){
			case 0:
				Console.BackgroundColor = clr4back;
				Console.ForegroundColor = clr4font;
				break;

			case 1:
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				break;
			case 2:
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				break;

			case 3:
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				break;
			case 4:
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.ForegroundColor = ConsoleColor.Black;
				break;
			}
			
			
			
			string[] fld = File.ReadAllLines(pathToField);
			Console.SetWindowSize(fld[0].Length + 1, fld.Length);

			
			
			List<string> fld2 = new List<string>(fld);
			foreach(var el in fld2) {
				Console.WriteLine(el);
			}
			Console.SetCursorPosition(0, 0);

			Thread.Sleep((int)(1000 * time));

			while(true){
				for(int i = 1; i < fld.Length - 1; i++) {
					for(int j = 1; j < fld[i].Length - 1; j++){
						int neighbrs = Check(fld, i, j, chr4l);
						if(fld[i][j] == chr4l){
							if(neighbrs <  min4l|| neighbrs > max4l){
								fld2[i] = fld2[i].Remove(j, 1).Insert(j, chr4d.ToString());
							}
						}else if(neighbrs == val4r){
							fld2[i] = fld2[i].Remove(j, 1).Insert(j, chr4l.ToString());
						}
					}
				}
				fld = fld2.ToArray();
				foreach(var ln in fld){
					Console.WriteLine(ln);
				}
				
				Console.SetCursorPosition(0, 0);
				Thread.Sleep((int)(1000 * time));
				
			}

		}

		private static int Check(string[] field, int row, int column, char chr){
			int counter = 0;
			if(field[row - 1][column] == chr){
				counter++;
			}
			if(field[row][column - 1] == chr){
				counter++;
			}
			if(field[row - 1][column - 1] == chr){
				counter++;
			}
			if(field[row - 1][column + 1] == chr){
				counter++;
			}
			if(field[row + 1][column] == chr){
				counter++;
			}
			if(field[row + 1][column - 1] == chr){
				counter++;
			}
			if(field[row + 1][column + 1] == chr){
				counter++;
			}
			if(field[row][column + 1] == chr){
				counter++;
			}
			return counter;
		}
		
	}
}
