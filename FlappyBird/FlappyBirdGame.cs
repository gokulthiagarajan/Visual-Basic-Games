using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class FlappyBirdGame : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public FlappyBirdGame()
        {
            InitializeComponent();
            gameTimer.Stop();
            scoreText.Text = "Press Enter to Start!";
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            // moving bird evry timer event 20ms altering up or down
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -80)
            {
                pipeTop.Left = 830;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -20)
            {
                endGame();
            }
            if (score !=0 && score %3 == 0)
            {
                pipeSpeed += 1;
            }

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gameTimer.Start();
            }
            if (e.KeyCode == Keys.Space)
            {
                gravity = - 10;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " -  Game Over!";
        }
    }
}
