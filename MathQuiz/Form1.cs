using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // create a random number for the values of problems
        Random randomizer = new Random();

        // create two int to restore the randomizer number
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // these integer store the numbers for the multiplication
        int multi1;
        int multi2;

        // these integer store the numbers for the division
        int div1;
        int div2;

        // mark the time left;
        int timeLeft;
        
        // start the quiz, fill the problems with addend1, adden2
        public void StartThequiz()
        {
            // fill addend1, addend2 with randomizer
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // fill the minus
            minuend = randomizer.Next(1,101);
            subtrahend = randomizer.Next(1,minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // fill the muti
            multi1 = randomizer.Next(11);
            multi2 = randomizer.Next(11);
            timesLeftLabel.Text = multi1.ToString();
            timesRightLabel.Text = multi2.ToString();
            product.Value = 0;

            // fill the div
            div2 = randomizer.Next(11);
            div1 = div2 * randomizer.Next(11);
            dividedLeftLlabel.Text = div1.ToString();
            dividedRightLabel.Text = div2.ToString();
            quotient.Value = 0;

            // start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
         }


        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartThequiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // user get the correct answer
                // stop the timer and show a messagebox
                timer1.Stop();
                MessageBox.Show("You got the correct answer!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // display the time left and update the new time
                timeLeft--;
                timeLabel.Text = timeLeft.ToString() + "Seconds";
                // timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                // if user ran out of time
                // stop the timer, show a messagebox and fill the answer.
                timer1.Stop();
                MessageBox.Show("You didn't finish in time", "sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multi1 * multi2;
                quotient.Value = div1 / div2;
                startButton.Enabled = true;
            }
        }

        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multi1 * multi2 == product.Value)
                && (div1 / div2 == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
