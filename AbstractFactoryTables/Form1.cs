using System;
using System.Drawing;
using System.Windows.Forms;
using TablesFactoryLibrary;

namespace AbstractFactoryTables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         Абстрактна фабрика столів
         Кожна фабрика робить набір: 1) обідній стіл, 2) письмовий стіл, 3) журнальний столик
         */

        TableFactory f; // поточна фабрика

        private void ShowSet()
        {
            f.MakeSet();
            listBox1.Items.Clear();
            listBox1.Items.Add(f.dining.Info());
            listBox1.Items.Add(f.desk.Info());
            listBox1.Items.Add(f.coffee.Info());
            label1.Text = "Разом за набір: " + f.TotalPrice() + " грн";
            panel1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // дерев'яні столи
            f = new WoodTableFactory();
            ShowSet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // скляні столи
            f = new GlassTableFactory();
            ShowSet();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (f == null)
            {
                g.DrawString("Оберіть фабрику", Font, Brushes.Gray, 10, 10);
                return;
            }
            int floor = 170;
            // обідній стіл
            using (Brush b = new SolidBrush(f.dining.color))
            {
                g.FillRectangle(b, 20, floor - 90, 180, 14);
                g.FillRectangle(b, 30, floor - 76, 10, 76);
                g.FillRectangle(b, 180, floor - 76, 10, 76);
            }
            g.DrawString("Обідній", Font, Brushes.Black, 80, floor + 5);
            // письмовий стіл
            using (Brush b = new SolidBrush(f.desk.color))
            {
                g.FillRectangle(b, 240, floor - 95, 170, 12);
                g.FillRectangle(b, 250, floor - 83, 10, 83);
                g.FillRectangle(b, 350, floor - 83, 55, 83);
                for (int k = 1; k <= f.desk.drawers; k++)
                    g.DrawLine(Pens.Black, 350, floor - 83 + k * 83 / (f.desk.drawers + 1), 405, floor - 83 + k * 83 / (f.desk.drawers + 1));
            }
            g.DrawString("Письмовий", Font, Brushes.Black, 290, floor + 5);
            // журнальний столик
            using (Brush b = new SolidBrush(f.coffee.color))
            {
                if (f.coffee.shape == "круглий")
                    g.FillEllipse(b, 450, floor - 52, 130, 16);
                else
                    g.FillRectangle(b, 450, floor - 50, 130, 12);
                g.FillRectangle(b, 470, floor - 40, 8, 40);
                g.FillRectangle(b, 552, floor - 40, 8, 40);
            }
            g.DrawString("Журнальний", Font, Brushes.Black, 470, floor + 5);
            g.DrawLine(Pens.Black, 0, floor, panel1.Width, floor);
        }
    }
}
