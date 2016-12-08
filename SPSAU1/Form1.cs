using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPSAU1
{
    public partial class Form1 : Form
    {
        List<List<TextBox>> table;
        List<Button> buttonTable;


        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateTable(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректную размерность таблицы");
            }
        }

        public void GenerateTable(int x, int y)
        {
            table = new List<List<TextBox>>();
            buttonTable = new List<Button>();
            try
            {
                for (int j = 0; j < y; j++)
                {
                    table.Add(new List<TextBox>());

                    for (int i = 0; i < x; i++)
                    {
                        
                        table[j].Add(new TextBox());
                        table[j][i].Parent = textBox1.Parent;
                        table[j][i].Size = textBox1.Size;
                        table[j][i].Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * j, textBox1.Location.Y + (textBox1.Height + 2) * i);
                        table[j][i].Visible = true;
                        table[j][i].TextAlign = HorizontalAlignment.Center;
                        //label2.Text = table[i][j].Height.ToString() + " " + table[i][j].Width.ToString();
                        //label2.Text = table.Count.ToString();

                        if (i == x - 1)
                        {
                            buttonTable.Add(new Button());
                            buttonTable[j].Parent = button1.Parent;
                            buttonTable[j].Size = button1.Size;
                            buttonTable[j].Text = button1.Text;
                            buttonTable[j].Location = new Point(table[j][i].Location.X, table[j][i].Location.Y + (textBox1.Height + 2));
                            buttonTable[j].Visible = true;
                            //buttonTable[j].TextAlign = HorizontalAlignment.Center;
                            buttonTable[j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            buttonTable[j].Click += new EventHandler(AddRow);
                            //buttonTable[j].Text = j.ToString();
                            //label3.Text = buttonTable[j].Height.ToString() + " " + buttonTable[j].Width.ToString();
                            buttonTable[j].Tag = new Point (i, j);
                        }

                        if (i == 0 && j == y - 1)
                        {
                            button2.Location = new Point(table[j][i].Location.X + (textBox1.Width + 2), table[j][i].Location.Y - 1);
                            button2.Visible = true;
                            button2.Click += new EventHandler(AddColumn);
                            button2.Tag = new Point(i, j);
                        }
                    }
                }
                /*
                for (int j = 0; j < y; j++)
                {
                    buttonTable.Add(new Button());
                    buttonTable[j].Parent = button1.Parent;
                    buttonTable[j].Size = new Size(113, 20);
                    buttonTable[j].Text = button1.Text;
                    buttonTable[j].Location = new Point(button1.Location.X + (button1.Width + 2) * j, button1.Location.Y + ((button1.Height + 2) * (x + 1)));
                    buttonTable[j].Visible = true;
                    //buttonTable[j].TextAlign = HorizontalAlignment.Center;
                    buttonTable[j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    label3.Text = buttonTable[j].Height.ToString() + " " + buttonTable[j].Width.ToString();
                }
                */
            }
            catch (Exception)
            {
                MessageBox.Show("Generation error");
            }
        }
        private void AddRow(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            TextBox extraTextBox = new TextBox();
            Point coord = (Point)temp.Tag;

            //table[coord.Y].Add(new TextBox());

            table[coord.Y].Add(extraTextBox);
            extraTextBox.Parent = textBox1.Parent;
            extraTextBox.Size = textBox1.Size;
            //extraTexBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * coord.Y, textBox1.Location.Y + (textBox1.Height + 2) * (coord.X + 1));
            extraTextBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * coord.Y, textBox1.Location.Y + (textBox1.Height + 2) * (table[coord.Y].Count - 1));
            extraTextBox.Visible = true;
            extraTextBox.TextAlign = HorizontalAlignment.Center;
            //temp.Location = new Point(table[coord.Y][coord.X].Location.X,extraTextBox.Location.Y + (textBox1.Height + 2));
            temp.Location = new Point(table[coord.Y][table[coord.Y].Count - 1].Location.X, extraTextBox.Location.Y + (textBox1.Height + 2));
            //temp.Visible = false;

            //MessageBox.Show(temp.Tag.ToString());            
        }

        private void AddColumn(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            Point coord = (Point)temp.Tag;
            TextBox extraTextBox = new TextBox();
            Button adderRow = new Button();


            table.Add(new List<TextBox>());
            table[table.Count - 1].Add(extraTextBox);
            extraTextBox.Parent = textBox1.Parent;
            extraTextBox.Size = textBox1.Size;
            extraTextBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * (table.Count - 1), textBox1.Location.Y);
            extraTextBox.Visible = true;
            extraTextBox.TextAlign = HorizontalAlignment.Center;
            //temp.Visible = false;
            temp.Location = new Point(table[table.Count - 1][0].Location.X + (button2.Width + 2), button2.Location.Y);
            //button
            buttonTable.Add(adderRow);
            adderRow.Click += new EventHandler(AddRow);
            adderRow.Parent = button1.Parent;
            adderRow.Size = button1.Size;
            adderRow.Text = button1.Text;
            adderRow.Location = new Point(table[table.Count - 2][0].Location.X + (textBox1.Width + 2), textBox1.Location.Y + (textBox1.Height + 2));
            adderRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adderRow.Tag = new Point(1, table.Count - 1);

        }
    }
}
