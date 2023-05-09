using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Metallum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Hide();
            label4.Hide();
            numericUpDown2.Hide();
            
        }

        string name;
        string rok_zalozenia;
        string rok_rozpadu;
        string data_albumu;
        string gatunek;
        string album;
        int ac = 0;
        bool saved;
        string fname = "Untitled";

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
            saved = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = true;
            richTextBox2.Text = "";
            richTextBox2.Text += "Zespół " + name + "został założony w " + rok_zalozenia + " roku";
            if (checkBox1.Checked == true)
            {
                richTextBox2.Text += " i zakończył działalność w " + rok_rozpadu;
            }
            richTextBox2.Text += ".";
            richTextBox2.Text += "Grupa wykonuje przede wszystkim utwory z gatunku " + gatunek + ".";

            if (richTextBox1.Text != "" && richTextBox1.Text != "\n")
            {
                richTextBox2.Text += "Wydali następujące albumy:\n";
                richTextBox2.Text += richTextBox1.Text;
            }

            if (fname == "Untitled")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                richTextBox1.SaveFile(fname);
            }
            //richTextBox2.SaveFile(fname);
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            saved = false;
            rok_zalozenia = Convert.ToString(numericUpDown1.Value);
            numericUpDown2.Minimum = numericUpDown1.Value;
            label5.Text = rok_zalozenia + " -";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
            if (checkBox1.Checked) {
                label4.Show();
                numericUpDown2.Minimum = numericUpDown1.Value;
                numericUpDown2.Show();
                label6.Text = Convert.ToString(numericUpDown2.Value);
                label6.Show();
            }
            else
            {
                label4.Hide();
                //numericUpDown2.Minimum = numericUpDown1.Value;
                numericUpDown2.Hide();
                //label6.Text = Convert.ToString(numericUpDown2.Value);
                label6.Hide();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            saved = false;
            rok_rozpadu = Convert.ToString(numericUpDown2.Value);
            label6.Text = rok_rozpadu;
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                if (MessageBox.Show("Czy na pewno chcesz utracić wszystkie zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generator krótkich notatek o zespołach metalowych. \n (C) A.S. 2023", "O programie");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saved = true;
            richTextBox2.Hide();
            label9.Text = "";
            data_albumu = "01.01.1900";
            album = "Album";
            ac = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gatunek = comboBox1.Text;
            saved = false;

            label8.Text = Convert.ToString(comboBox1.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data_albumu = Convert.ToString(dateTimePicker1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            album = textBox2.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           richTextBox1.Text += "\n" + data_albumu + " " + album;
            ac++;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.Lines = "i";
            ac--;
            richTextBox1.Lines = richTextBox1.Lines.Take(richTextBox1.Lines.Length - 1).ToArray();
            //richTextBox1.Lines = Convert.ToString(richTextBox1.Lines.Take(richTextBox1.Lines.Length - 1));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = true;
            richTextBox2.Text = "";
            richTextBox2.Text += "Zespół " + name + "został założony w " + rok_zalozenia + " roku";
            if (checkBox1.Checked == true)
            {
                richTextBox2.Text += " i zakończył działalność w " + rok_rozpadu;
            }
            richTextBox2.Text += ". ";
            richTextBox2.Text += "Grupa wykonuje przede wszystkim utwory z gatunku " + gatunek + ". ";

            if (richTextBox1.Text != "" && richTextBox1.Text != "\n")
            {
                richTextBox2.Text += "Wydali następujące albumy:\n";
                richTextBox2.Text += richTextBox1.Text;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //saveFileDialog1.ShowDialog();
                richTextBox2.SaveFile(saveFileDialog1.FileName);
                saveFileDialog1.DefaultExt = ".rtx";
                fname = saveFileDialog1.FileName;
                //label1.Text = name;
                saved = true;
                //label1.Text = "saved";
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == true)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                label5.Text = "1900 -";
                label2.Text = "Untitled";
                label8.Text = "";
                label6.Hide();
                label4.Hide();
                numericUpDown2.Hide();
                checkBox1.Checked = false;
            }
            else
            {
                var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                    if (saved == true)
                    {
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        label5.Text = "1900 -";
                        label2.Text = "Untitled";
                        label8.Text = "";
                        label6.Hide();
                        label4.Hide();
                        numericUpDown2.Hide();
                        checkBox1.Checked = false;
                        saved = true;
                        
                    }

                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                    label5.Text = "1900 -";
                    label2.Text = "Untitled";
                    label8.Text = "";
                    label6.Hide();
                    label4.Hide();
                    numericUpDown2.Hide();
                    checkBox1.Checked = false;
                    saved = true;
                    
                }

            }
            
        }
    }
}
