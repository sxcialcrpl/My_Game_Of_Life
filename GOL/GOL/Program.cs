﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace GOL {
	class Program {

		static void Main(string[] args) {
			Console.CursorVisible = false;

			Console.BufferHeight = 5000;
			Console.BufferWidth = 3500; 
			var Settings = new Dictionary<char, double>();

			//1. если рядом с живой клеткой менее 2-ух живых, то она умирает
			//2. если рядом с живой клеткой более 3-ех живых, то она умирает
			//3. если рядом с мертвой клеткой ровно 3 живых, то она рождается

			//точка - мертвая клетка, собака - живая (./@)
			#if DEBUG
			string pathToRules=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\rules\\rules.txt");
			string pathToField=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\rules\\field.txt");
			#endif
			#if !DEBUG
			string pathToRules=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rules\\rules.txt");
			string pathToField=System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rules\\field.txt");
			#endif
			// путь к файлам с полем и правилами
			
			StreamReader sr = new StreamReader(pathToRules);

			string line;
			while((line = sr.ReadLine()) != null){
				int i = line.Length - 1;
				while(line[i] != ' '){
					i--;
				}
				try{
					Settings.Add(line[0], Convert.ToDouble(line.Substring(i).Replace(',', '.')));
				}catch{
					Settings.Add(line[0], Convert.ToDouble(line.Substring(i).Replace('.', ',')));
				}
			}
			int min4l = (int)Settings['1'];
			int max4l = (int)Settings['2'];
			int val4r = (int)Settings['3'];
			double time = Settings['4'];
			var clr4back = (ConsoleColor)(int)Settings['5'];
			var clr4font = (ConsoleColor)(int)Settings['6'];
			
			
			Console.BackgroundColor = clr4back;
			Console.ForegroundColor = clr4font;
			
			
			
			string[] fld = File.ReadAllLines(pathToField);
			Console.SetWindowSize(fld[0].Length + 1, fld.Length);

			
			
			List<string> fld2 = new List<string>(fld);
			foreach(var el in fld2) {
				Console.WriteLine(el);
			}
			Console.SetCursorPosition(0, 0);

			Thread.Sleep((int)(1000 * time));

			while(true){
				for(int i = 1; i < fld.Length - 1; i++) {//с еденичек до n - 1 что бы не было лишней итерации на границы и эксепшенов
					for(int j = 1; j < fld[i].Length - 1; j++){
						int neighbrs = Check(fld, i, j);
						if(fld[i][j] == '@'){
							if(neighbrs <  min4l|| neighbrs > max4l){
								fld2[i] = fld2[i].Remove(j, 1).Insert(j, ".");
							}
						}else if(neighbrs == val4r){
							fld2[i] = fld2[i].Remove(j, 1).Insert(j, "@");
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
		private static int Check(string[] field, int row, int column){
			int counter = 0;
			if(field[row - 1][column] == '@'){
				counter++;
			}
			if(field[row][column - 1] == '@'){
				counter++;
			}
			if(field[row - 1][column - 1] == '@'){
				counter++;
			}
			if(field[row - 1][column + 1] == '@'){
				counter++;
			}
			if(field[row + 1][column] == '@'){
				counter++;
			}
			if(field[row + 1][column - 1] == '@'){
				counter++;
			}
			if(field[row + 1][column + 1] == '@'){
				counter++;
			}
			if(field[row][column + 1] == '@'){
				counter++;
			}
			return counter;
		}
		
	}
}
