using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GY___FlappyBird
{
    public partial class Form1 : Form
    {
        int yerCekimi = 5;
        int hiz = 10;
        int score = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && tmrGame.Enabled)
            {
                if (pbBird.Top > 0)
                {
                    pbBird.Top -= yerCekimi * 10;
                    pbBird.Top = pbBird.Top < 0 ? 0 : pbBird.Top; // EKRANDAN TAŞMAMASI İÇİN.
                }
            }
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Skorunuz: " + score;
            pbBird.Top += yerCekimi;
            pbPipe1.Left -= hiz;
            pbPipe2.Left -= hiz;
            pbPipe3.Left -= hiz;
            pbPipe4.Left -= hiz;
            if (pbPipe1.Right <= 0)
            {
                pbPipe1.Left = ClientSize.Width + rnd.Next(200); // EKRANIN DIŞINDA RASTGELE BİR YERDE KONUMUNU GÜNCELLEDİM.
                // TO DO HEIGHT RANDOM GELSİN.
                pbPipe1.Height = rnd.Next(95, 140);
                pbPipe1.Top = pbGround.Top - pbPipe1.Height;
                score++;
            }
            if (pbPipe2.Right <= 0)
            {
                pbPipe2.Left = ClientSize.Width + rnd.Next(200);
                pbPipe2.Height = rnd.Next(95,140);
                score++;
            }
            if (pbPipe3.Right <= 0)
            {
                pbPipe3.Left = pbPipe1.Left + pbPipe1.Width + rnd.Next(20,200);
                pbPipe3.Height = rnd.Next(95, 140);
                pbPipe3.Top = pbGround.Top - pbPipe3.Height;
                score++;
            }
            if (pbPipe4.Right <= 0)
            {
                pbPipe4.Left = pbPipe2.Left + pbPipe2.Width + rnd.Next(20,200);
                pbPipe4.Height = rnd.Next(95, 140);
                score++;
            }
            if(pbPipe1.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe2.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe3.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe4.Bounds.IntersectsWith(pbBird.Bounds) || pbGround.Bounds.IntersectsWith(pbBird.Bounds)) // 4 BORU VE ZEMİN İÇİN
            {
                tmrGame.Stop();
                DialogResult dr = MessageBox.Show("Game Over! Do you want to play again?","Flappy Bird",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    tmrGame.Start();
                    score = 0;
                    pbBird.Left = 0;
                    pbBird.Top = 90;
                    pbPipe1.Left = ClientSize.Width;
                    pbPipe2.Left = ClientSize.Width;
                    pbPipe3.Left = pbPipe1.Left + pbPipe1.Width + rnd.Next(200);
                    pbPipe4.Left = pbPipe2.Left + pbPipe2.Width + rnd.Next(200);
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
