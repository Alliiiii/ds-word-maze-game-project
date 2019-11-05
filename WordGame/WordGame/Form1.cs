using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordGame
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer sp = new SpeechSynthesizer();


        bool mute=false;
        public Form1()
        {
            sp.Speak("I am Ali");
            InitializeComponent();
            sp.SelectVoiceByHints(VoiceGender.Female);
        }

        
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();

            axWindowsMediaPlayer1.URL = "BG.mp4";
            axWindowsMediaPlayer1.settings.setMode("loop", true);

            
        }

        int mute_count=0;

        private void btn_Mute_Click(object sender, EventArgs e)
        {
            if (mute_count == 0)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
                mute_count++;
                btn_Mute.ForeColor = Color.Red;
                mute = true;
            }
            else
            {

                axWindowsMediaPlayer1.settings.volume = 50;
                mute_count--; 
                btn_Mute.ForeColor = Color.White;
                mute = false;

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            string temp = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");

            speak(temp);

        }

        private void button3_Click(object sender, EventArgs e)
        {
             


        }


        int new_game_btn_count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            speak("Game Started");

            if (new_game_btn_count == 0)
            {


                int x = 28;

                panel1.Show();

                for (int i = 0; i < x; i++)
                {
                    button1.Left -= i;
                    button2.Left -= i;
                    button3.Left -= i;
                    panel1.Left -= i + 10;
                    panel1.Width += i + i;

                    if (i<=20)
                    {
                        button1.Top += i;
                        button2.Top += i;
                        button3.Top += i;
                    }
                    


                    System.Threading.Thread.Sleep(20);
                }


                for (int i = 0; i < 21; i++)
                {
                  




                    System.Threading.Thread.Sleep(20);
                }

                System.Threading.Thread.Sleep(100);
                UserControl1 uc = new UserControl1();
                panel1.Controls.Add(uc);
                new_game_btn_count++;

                
            }


        }


        void speak(string s)
        {
            axWindowsMediaPlayer1.settings.volume = 0;

            System.Threading.Thread.Sleep(100);

            sp.Speak(s);

            System.Threading.Thread.Sleep(100);
            if (mute==false)
            {
                axWindowsMediaPlayer1.settings.volume = 50;    
            }
            


        }
    }
}
