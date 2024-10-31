using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOL
{
	internal static class start_wf
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			List<char> chars = new List<char>(2);
			string pts = Directory.GetCurrentDirectory() + @"\rules\settings.txt";
			var sr = new StreamReader(pts);
			string s = sr.ReadLine();
			while(s != null){
				if(s[0] == '8' || s[0] =='9'){
					chars.Add(s[s.Length - 1]);
				}
				s = sr.ReadLine();
			}
			sr.Close();
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(chars.ToArray()));//
		}
	}
}
