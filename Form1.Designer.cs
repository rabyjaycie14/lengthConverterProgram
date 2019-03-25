namespace LengthConverter
{
     partial class Form1
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
               if (disposing && (components != null))
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
               this.comboBox1 = new System.Windows.Forms.ComboBox();
               this.label1 = new System.Windows.Forms.Label();
               this.button1 = new System.Windows.Forms.Button();
               this.textBox1 = new System.Windows.Forms.TextBox();
               this.textBox2 = new System.Windows.Forms.TextBox();
               this.SuspendLayout();
               // 
               // comboBox1
               // 
               this.comboBox1.DropDownHeight = 50;
               this.comboBox1.DropDownWidth = 50;
               this.comboBox1.FormattingEnabled = true;
               this.comboBox1.ItemHeight = 37;
               this.comboBox1.Items.AddRange(new object[] {
            "miles",
            "yards",
            "feet"});
               this.comboBox1.Location = new System.Drawing.Point(537, 243);
               this.comboBox1.Name = "comboBox1";
               this.comboBox1.Size = new System.Drawing.Size(121, 45);
               this.comboBox1.TabIndex = 0;
               this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(530, 131);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(167, 37);
               this.label1.TabIndex = 1;
               this.label1.Text = "Kilometers";
               this.label1.Click += new System.EventHandler(this.label1_Click);
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(73, 375);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(603, 80);
               this.button1.TabIndex = 2;
               this.button1.Text = "Convert";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // textBox1
               // 
               this.textBox1.Location = new System.Drawing.Point(73, 131);
               this.textBox1.Multiline = true;
               this.textBox1.Name = "textBox1";
               this.textBox1.Size = new System.Drawing.Size(366, 66);
               this.textBox1.TabIndex = 3;
               this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
               // 
               // textBox2
               // 
               this.textBox2.Location = new System.Drawing.Point(73, 243);
               this.textBox2.Multiline = true;
               this.textBox2.Name = "textBox2";
               this.textBox2.Size = new System.Drawing.Size(366, 74);
               this.textBox2.TabIndex = 4;
               this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(776, 534);
               this.Controls.Add(this.textBox2);
               this.Controls.Add(this.textBox1);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.comboBox1);
               this.Name = "Form1";
               this.Text = "Length Converter";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.ComboBox comboBox1;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.TextBox textBox1;
          private System.Windows.Forms.TextBox textBox2;
     }
}

