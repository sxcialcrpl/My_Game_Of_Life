using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace GOL
{
	public partial class MainForm:Form
	{
		public MainForm(char[] chrs)//char[] chrs
		{
			chars = chrs;
			InitializeComponent();
		}
		private int height;
		private int width;
		private string[] field;
		private readonly string ptf = Directory.GetCurrentDirectory() + @"\rules\field.txt";
		private static char[] chars = new char[2];
		
		private void Form1_Load(object sender, EventArgs e)
		{
			Size resolv = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
			Width = 800;
			Height = 642;
			btn_start.FlatStyle = FlatStyle.Flat;
			btn_start.FlatAppearance.BorderColor = Color.Black;
			DesktopLocation = new Point(resolv.Width / 2 - 400, resolv.Height / 2 - 321);
			save.FlatStyle = FlatStyle.Flat;
			save.FlatAppearance.BorderColor = Color.Black;
			char chr4d = chars[0];
			char chr4l = chars[1];
		}

		private void start_Click(object sender, EventArgs e)
		{	
			char chr4d = chars[0];
			char chr4l = chars[1];
			try{
				height = Convert.ToInt32(txt_height.Text);
				width = Convert.ToInt32(txt_width.Text);
			}catch{
				MessageBox.Show("Введены неверные данные");
				this.Close();
			}
			field = new string[height];
			
			for(int y = 0; y < height; y++){
				int startY = 25;
				int startX = 23;
				for(int x = 0; x < width; x++){
					Button btn = new Button();
					btn.Width = 15;
					btn.Height = 15;
					btn.FlatStyle = FlatStyle.Flat;
					btn.FlatAppearance.BorderColor = Color.Black;
					btn.Click += new EventHandler(this.btnclicked);
					btn.Tag = y.ToString() + '|' + x.ToString();
					btn.Location = new Point(startX + x * btn.Width, startY + y * btn.Height);
					this.Controls.Add(btn);
					field[y] += chr4d;
				}
			}
			
			Height = height * 15 + 125;
			Width =  width * 15 + 75;
			lbl_start.Visible = false;
			txt_height.Visible = false;
			txt_width.Visible = false;
			lbl_width.Visible = false;
			lbl_height.Visible = false;
			btn_start.Visible = false;
			
			
			save.Location = new Point(Width / 2 - 75, Height - 80);
			save.Visible = true;
			
		}
		void btnclicked(object sender, EventArgs e){
			char chr4d = chars[0];
			char chr4l = chars[1];
			Button bttn = (Button)sender;
			string str = bttn.Tag.ToString();
			int[] coord = new int[2];
			for(int i = 0; i < str.Length; i++){
				if(str[i] == '|'){// '|' - разделитель в теге, можно глянуть на btn.Tag
					coord = new int[] { Convert.ToInt32(str.Substring(0, i)), Convert.ToInt32(str.Substring(i + 1))};
					break;
				}
			}
			if (bttn.BackColor == Color.Black ) {
				bttn.BackColor = Color.White;
				field[coord[0]] = field[coord[0]].Remove(coord[1], 1).Insert(coord[1], chr4d.ToString());
			}else{
				bttn.BackColor = Color.Black;
				field[coord[0]] = field[coord[0]].Remove(coord[1], 1).Insert(coord[1], chr4l.ToString());
			}
		}
		void saveclicked(object sender, EventArgs e){
			StreamWriter sw = new StreamWriter(ptf);
			sw.Write('+');
			for (int i = 0; i < field[0].Length; i++)
			{
				sw.Write('-');
			}
			sw.WriteLine('+');
			foreach(var el in field){
				sw.Write('|');
				sw.Write(el);
				sw.WriteLine('|');
			}
			sw.Write('+');
			for (int i = 0; i < field[0].Length; i++)
			{
				sw.Write('-');
			}
			sw.WriteLine('+');
			sw.Close();
		}
		
	}
}
