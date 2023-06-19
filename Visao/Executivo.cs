using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna
{
    public partial class Executivo : Form
    {


        public Executivo()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DesenharRetanguloPreto(e.Graphics);
            DesenharRetanguloBranco(e.Graphics);
            DesenharRetanguloBrancos(e.Graphics);
        }

        private void DesenharRetanguloPreto(Graphics g)
        {
            int squareSize = 350;
            int squareX = (ClientSize.Width - squareSize) - 20;
            int squareY = (ClientSize.Height - squareSize) * 2 / 3;

            g.FillRectangle(Brushes.Black, squareX, squareY, squareSize, squareSize);
        }

        private void DesenharRetanguloBranco(Graphics g)
        {
            int rectangleWidth = 350;
            int rectangleHeight = 50;

            int rectangleX = ClientSize.Width - rectangleWidth - 20;
            int rectangleY = 20;

            g.FillRectangle(Brushes.White, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
        }

        private void DesenharRetanguloBrancos(Graphics g)
        {
            int rectangleWidth = ClientSize.Width / 2;
            int rectangleHeight = ClientSize.Height - 120;

            int rectangleX = (ClientSize.Width - rectangleWidth) / 8;
            int rectangleY = (ClientSize.Height - rectangleHeight) / 2;

            g.FillRectangle(Brushes.White, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
        }




        private void Executivo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BorderStyle = BorderStyle.None;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void buttonBranco_Click(object sender, EventArgs e)
        {

        }

        private void buttonCorrige_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirma_Click(object sender, EventArgs e)
        {

        }
    }
}
