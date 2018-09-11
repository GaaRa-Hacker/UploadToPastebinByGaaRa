using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Upload_To_Pastebin_By_GaaRa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            System.Collections.Specialized.NameValueCollection Data = new System.Collections.Specialized.NameValueCollection();
            Data["api_paste_expire_date"] = "N";
            Data["api_paste_code"] = richTextBox1.Text;
            Data["api_dev_key"] = "4dd29af09faf6e39abcae2c910ad8f2e";
            Data["api_option"] = "paste";
            WebClient wb = new WebClient();
            byte[] bytes = wb.UploadValues("http://pastebin.com/api/api_post.php", Data);
            string response;
            using (MemoryStream ms = new MemoryStream(bytes))
            using (StreamReader reader = new StreamReader(ms))
                response = reader.ReadToEnd();
            if (response.StartsWith("Bad API request"))
            {
                MessageBox.Show("Failed to upload!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                response = "http://pastebin.com/raw" + response.Substring(20);
                textBox1.Text = response;
                textBox1.Enabled = true;
                MessageBox.Show("Succesfully uploaded!", "Success!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox1.Copy();
            MessageBox.Show("Copied", "Success!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
             dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/1115513381936322");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Concat(new string[]
	{
		"[+] Coded By : GaaRa-Hacker",
		Environment.NewLine,
        "[+] Thank For : CaTmAn",
        Environment.NewLine,
		"[+] Thank For : Ahmed Atef",
        Environment.NewLine,
		"[+] Thank For : Mr CrOcoDiLe (Djawed)",
		Environment.NewLine,
		"[+] Language : C#",
		Environment.NewLine,
		"[+] Project : Upload To Pastebin By GaaRa",
		Environment.NewLine,
		"[+] Made In : Egypt",
		Environment.NewLine
	}), "About Project", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        

        
    }
}
