using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Графический_редактор
{
    public partial class MainForm : Form
    {
        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;

        public MainForm()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void for_paint()
        {
            Pen p = new Pen(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG; *.PNG; *.GIF; *.BMP) | *.JPG; *.PNG; *.GIF; *.BMP | All files (*.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);

                }
                catch
                {
                    MessageBox.Show("Невозмможно открыть файл","Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnColor_Click_1(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Припинити роботу застосунку?",
             "Припинити роботу", MessageBoxButtons.OKCancel,
              MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }
    }
}
