using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ta_blyat_ {
	class Program {

		static void Main(string[] args) {
			Console.BufferHeight = 8900;
			Console.BufferWidth = 4999;
			
			Console.CursorVisible = false;

			//1. если рядом с живой клеткой менее 2-ух живых, то она умирает
			//2. если рядом с живой клеткой более 3-ех живых, то она умирает
			//3. если рядом с мертвой клеткой ровно 3 живых, то она рождается

			//точка - мертвая клетка, собака - живая (./@)
			
			string[] fld = File.ReadAllLines("C:\\Users\\Dima\\Desktop\\projects\\My_Game_Of_Life\\ta_blyat'\\ta_blyat'\\fields\\field.txt");
			Console.SetWindowSize(fld[0].Length, fld.Length);
			//var sr = new StreamReader("C:\\Users\\Dima\\Desktop\\projects\\ta_blyat'\\ta_blyat'\\field.txt");
			/*foreach(var ln in fld){
				Console.WriteLine(ln);
			}*/
			
			
			List<string> fld2 = new List<string>(fld);
			foreach(var el in fld2) {
				Console.WriteLine(el);
			}
			Console.SetCursorPosition(0, 0);
			
			//теперь создаем основную логику игры
			//тут мы в вечном цикле будем заводить цикл фор
			//в котором будем пробегать по каждой точке что у нас есть на поле (в переменной)
			//если это не точка то скипаем
			//если точка или собака то проверяем на правила игры и меняем файл (field.txt)
			//в конце хода мы переносим изменения из файла в поле (string[] fld)

			while(true){
				for(int i = 1; i < fld.Length - 1; i++) {//с еденичек до n - 1 что бы не было лишней итерации на границы и эксепшенов
					for(int j = 1; j < fld[i].Length - 1; j++){
						int neighbrs = Check(fld, i, j);
						if(fld[i][j] == '@'){
							if(neighbrs > 3 || neighbrs < 2){
								fld2[i] = fld2[i].Remove(j, 1).Insert(j, ".");
							}
						}else if(neighbrs == 3){
							fld2[i] = fld2[i].Remove(j, 1).Insert(j, "@");
						}
					}
				}
				fld = fld2.ToArray();
				foreach(var ln in fld){
					Console.WriteLine(ln);
				}
				
				Console.SetCursorPosition(0, 0);
				Thread.Sleep(1000);
				
				
				//Console.SetCursorPosition(0, 0);
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
