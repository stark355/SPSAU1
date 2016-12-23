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
        public List<List<TextBox>> table;
        List<Button> buttonTable;
        List<TextBox> tableHeader;


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
            tableHeader = new List<TextBox>();
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
                            buttonTable[j].TabIndex = 0;
                        }

                        if (i == 0 && j == y - 1)
                        {
                            button2.Location = new Point(table[j][i].Location.X + (textBox1.Width + 2), table[j][i].Location.Y - 1);
                            button2.Visible = true;
                            button2.Click += new EventHandler(AddColumn);
                            button2.Tag = new Point(i, j);
                            button2.TabIndex = 0;
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

                //header
                for (int j = 0; j < y; j++)
                {
                    tableHeader.Add(new TextBox());
                    tableHeader[j].Parent = textBox1.Parent;
                    tableHeader[j].Size = textBox1.Size;
                    tableHeader[j].Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * j, textBox1.Location.Y - (textBox1.Height + 2));
                    tableHeader[j].Visible = true;
                    tableHeader[j].TextAlign = HorizontalAlignment.Center;
                    tableHeader[j].BackColor = SystemColors.Info;
                    tableHeader[j].TabIndex = 0;
                }

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
            int textboxWidth = textBox1.Width;
            int textboxHeight = textBox1.Height;
            int textboxX = table[coord.Y][table[coord.Y].Count - 1].Location.X;
            int textboxY = table[coord.Y][table[coord.Y].Count - 1].Location.Y;

            //table[coord.Y].Add(new TextBox());

            table[coord.Y].Add(extraTextBox);
            extraTextBox.Parent = textBox1.Parent;
            extraTextBox.Size = textBox1.Size;
            //extraTexBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * coord.Y, textBox1.Location.Y + (textBox1.Height + 2) * (coord.X + 1));
            //extraTextBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * coord.Y, textBox1.Location.Y + (textBox1.Height + 2) * (table[coord.Y].Count - 1));
            extraTextBox.Location = new Point(textboxX, textboxY + textboxHeight + 2);
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
            TextBox headerBox = new TextBox();
            int textboxWidth = textBox1.Width;
            int textboxHeight = textBox1.Height;
            int textboxX = table[table.Count - 1][0].Location.X;
            int textboxY = table[table.Count - 1][0].Location.Y;


            table.Add(new List<TextBox>());
            table[table.Count - 1].Add(extraTextBox);
            extraTextBox.Parent = textBox1.Parent;
            extraTextBox.Size = textBox1.Size;
            //extraTextBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * (table.Count - 1), textBox1.Location.Y);
            extraTextBox.Location = new Point(textboxX + (textBox1.Width + 2), textboxY);
            extraTextBox.Visible = true;
            extraTextBox.TextAlign = HorizontalAlignment.Center;
            //temp.Visible = false;
            temp.Location = new Point(table[table.Count - 1][0].Location.X + (button2.Width + 2), button2.Location.Y);
            //tabIndex
            /*
            for (int j = 0; j < table.Count; j++)
            {
                for (int i = 0; i < table[j].Count; i++)
                {
                }
            }*/

            //button
            adderRow.Click += new EventHandler(AddRow);
            adderRow.Parent = button1.Parent;
            adderRow.Size = button1.Size;
            adderRow.Text = button1.Text;
            adderRow.Location = new Point(table[table.Count - 2][0].Location.X + (textBox1.Width + 2), textBox1.Location.Y + (textBox1.Height + 2));
            adderRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adderRow.Tag = new Point(1, table.Count - 1);
            adderRow.TabIndex = 0;
            //header
            textboxX = table[table.Count - 2][0].Location.X;
            textboxY = table[table.Count - 2][0].Location.Y;
            headerBox.Parent = textBox1.Parent;
            headerBox.Size = textBox1.Size;
            //headerBox.Location = new Point(textBox1.Location.X + (textBox1.Width + 2) * (tableHeader.Count - 1), textBox1.Location.Y - (textBox1.Height + 2));
            headerBox.Location = new Point(textboxX + (textboxWidth + 2), textboxY - (textboxHeight + 2));
            headerBox.Visible = true;
            headerBox.TextAlign = HorizontalAlignment.Center;
            headerBox.BackColor = SystemColors.Info;
            headerBox.TabIndex = 0;
            buttonTable.Add(adderRow);
            tableHeader.Add(headerBox);
        }

        private void Evaluator()
        {
            Form2 f2 = new Form2();
            f2.Show();
            int[] maxIndexes = new int[table.Count];
            int[] currentIndexes = new int[table.Count];
            int currentBorder = table.Count - 1;
            string outText ="";
            //int iter = 0;
            for (int i = 0; i < maxIndexes.Length; i++)
            {
                maxIndexes[i] = table[i].Count - 1;
                //label2.Text += maxIndexes[i].ToString();
            }

            //output
            try
            {
                while (true)
                //while (currentIndexes[0] != maxIndexes[0])
                {
                    outText = "";
                    for (int i = 0; i < table.Count; i++)
                    {
                        outText += table[i][currentIndexes[i]].Text;
                        //f2.textBox1.Text += outText;
                        if (i == table.Count - 1)
                            /*f2.textBox1.Text += @"
";*/
                            outText += @"
";
                        else
                            //f2.textBox1.Text += " ";
                            outText += " ";
                    }
                    f2.textBox1.Text += outText;

                    if (currentIndexes[currentBorder] != maxIndexes[currentBorder])
                    {
                        currentIndexes[currentBorder]++;
                    }
                    else
                    {
                        currentBorder--;
                        for (int j = 0; j < table.Count; j++)
                        {
                            if (j > currentBorder)
                                currentIndexes[j] = 0;
                        }
                        currentIndexes[currentBorder]++;
                        //rec
                        //for (int k = 0; k < table.Count; k++)
                        for (int k = table.Count - 1; k >= 0; k--)
                        {
                            if (currentIndexes[k] > maxIndexes[k])
                            {
                                currentIndexes[k] = 0;
                                currentIndexes[k - 1]++;
                            }
                        }
                        currentBorder = table.Count - 1;
                    }

                    //iter++;
                    //if (iter == 200)
                    //    break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Evaluator();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int j = 0; j < table.Count; j++)
                {
                    for (int i = 0; i < table[j].Count; i++)
                    {
                        table[j][i].Text = "";
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
