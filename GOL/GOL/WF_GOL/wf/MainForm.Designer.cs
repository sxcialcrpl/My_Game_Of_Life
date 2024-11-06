namespace GOL
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_start = new System.Windows.Forms.Button();
			this.txt_width = new System.Windows.Forms.TextBox();
			this.lbl_start = new System.Windows.Forms.Label();
			this.lbl_width = new System.Windows.Forms.Label();
			this.lbl_height = new System.Windows.Forms.Label();
			this.txt_height = new System.Windows.Forms.TextBox();
			this.save = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_start
			// 
			this.btn_start.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold);
			this.btn_start.ForeColor = System.Drawing.SystemColors.InfoText;
			this.btn_start.Location = new System.Drawing.Point(315, 400);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(116, 50);
			this.btn_start.TabIndex = 1;
			this.btn_start.Text = "start";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.start_Click);
			// 
			// txt_width
			// 
			this.txt_width.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
			this.txt_width.Location = new System.Drawing.Point(186, 277);
			this.txt_width.Name = "txt_width";
			this.txt_width.Size = new System.Drawing.Size(112, 27);
			this.txt_width.TabIndex = 2;
			this.txt_width.Text = "25";
			// 
			// lbl_start
			// 
			this.lbl_start.AutoSize = true;
			this.lbl_start.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold);
			this.lbl_start.Location = new System.Drawing.Point(244, 80);
			this.lbl_start.Name = "lbl_start";
			this.lbl_start.Size = new System.Drawing.Size(273, 46);
			this.lbl_start.TabIndex = 3;
			this.lbl_start.Text = "Генерация поля";
			// 
			// lbl_width
			// 
			this.lbl_width.AutoSize = true;
			this.lbl_width.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
			this.lbl_width.Location = new System.Drawing.Point(203, 236);
			this.lbl_width.Name = "lbl_width";
			this.lbl_width.Size = new System.Drawing.Size(95, 28);
			this.lbl_width.TabIndex = 4;
			this.lbl_width.Text = "Ширина:";
			// 
			// lbl_height
			// 
			this.lbl_height.AutoSize = true;
			this.lbl_height.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
			this.lbl_height.Location = new System.Drawing.Point(460, 236);
			this.lbl_height.Name = "lbl_height";
			this.lbl_height.Size = new System.Drawing.Size(84, 28);
			this.lbl_height.TabIndex = 5;
			this.lbl_height.Text = "Высота:";
			// 
			// txt_height
			// 
			this.txt_height.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
			this.txt_height.Location = new System.Drawing.Point(465, 277);
			this.txt_height.Name = "txt_height";
			this.txt_height.Size = new System.Drawing.Size(112, 27);
			this.txt_height.TabIndex = 6;
			this.txt_height.Text = "25";
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(22, 566);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(100, 25);
			this.save.TabIndex = 7;
			this.save.Text = "Сохранить";
			this.save.UseVisualStyleBackColor = true;
			this.save.Visible = false;
			this.save.Click += new System.EventHandler(this.saveclicked);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 603);
			this.Controls.Add(this.save);
			this.Controls.Add(this.txt_height);
			this.Controls.Add(this.lbl_height);
			this.Controls.Add(this.lbl_width);
			this.Controls.Add(this.lbl_start);
			this.Controls.Add(this.txt_width);
			this.Controls.Add(this.btn_start);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.TextBox txt_width;
		private System.Windows.Forms.Label lbl_start;
		private System.Windows.Forms.Label lbl_width;
		private System.Windows.Forms.Label lbl_height;
		private System.Windows.Forms.TextBox txt_height;
		private System.Windows.Forms.Button save;
	}
}