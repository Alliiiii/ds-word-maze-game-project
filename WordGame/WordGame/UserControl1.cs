using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
namespace WordGame
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            s.Speak("Welcome..");

        }

        SpeechSynthesizer s = new SpeechSynthesizer();
        LinkedList list = new LinkedList();
        LinkedList master_list = new LinkedList();

        int shfl = 10;
        int score = 0;


        private void UserControl1_Load(object sender, EventArgs e)
        {
            
            s.SelectVoiceByHints(VoiceGender.Female);
            
            
            string all_alpha="abcdefghijklmnopqrstuvwxyz";
           // string all_alpha = "aeiou";
            label2.Text = shfl.ToString();
            label4.Text = score.ToString();


            
      
            //StreamReader myFile = File.OpenText(@"Dic.txt");

            //while ((s = myFile.ReadLine()) != null)
            //{

            //    all_alpha += s;

            //}


            char[] ch = all_alpha.Distinct<char>().ToArray();
            
            Random rnd = new Random();

            flowLayoutPanel1.Controls.Clear();

            

            for (int i = 0; i < 4; i++)
            {
                int btn_width = (flowLayoutPanel1.Width / 4);

                int x = rnd.Next(0, ch.Length);
                string item = ch[x].ToString();



                Button bt = new Button();
                bt.Text = item.ToString().ToUpper();
                bt.Name = item.ToString();

                StreamReader str = File.OpenText(@"Dic.txt");
                string word;
                while ((word= str.ReadLine())!=null)
                {
                    
                    if (word[0]==Convert.ToChar(item))
                    {
                        master_list.insertInBiggning(item.ToLower());
                    }
                }
                str.Close();



                bt.Height = 70;
                bt.Width = btn_width - 7;
                bt.BackColor = Color.Black;
                bt.ForeColor = Color.Wheat;
                bt.Font = new Font("Agency FB", 19, FontStyle.Bold);



                bt.Click += new EventHandler(butn_Click);

                flowLayoutPanel1.Controls.Add(bt);

            }

            
        }

        private void butn_Click(object sender, EventArgs e)
        {
            string temp = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");

            textBox1.Text += temp;
        }

            public void game_over()
            {

                if (score <= 0)
                {
                    s.Speak("Game Over, Well tried");
                    DialogResult dg;
                    dg=MessageBox.Show("Game Over\nDo you want to play again?","Game Over",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dg==DialogResult.Yes)
                    {
                        score = 0;
                        shfl = 10;
                        UserControl1_Load("S",new EventArgs());
                        flowLayoutPanel2.Controls.Clear();
                        
                    }
                    else
                    {
                        Application.Exit();
                    }
                    

                }

            }

            private void button2_Click(object sender, EventArgs e)
            {
                
                if (shfl == 0)
                {

                    score -= 2;
                    game_over();
                    label4.Text = score.ToString();
                    return;
                }

                shfl--;
                label2.Text = shfl.ToString();
                UserControl1_Load(sender, e);
            
            }

            int word_count = 0;

            private void button1_Click(object sender, EventArgs e)
            {
                s.Speak(textBox1.Text.ToString());


                if (list.search(textBox1.Text))
                {
                    s.Speak("You have made this word");
                    MessageBox.Show("Already Exaist");
                }
                else
                {
                    string ss;
                    int count = 0;

                    string temp = textBox1.Text.ToLower();
                    if (master_list.search(temp))
                    {
                        count++;
                    }





                    StreamReader myFile = File.OpenText(@"Dic.txt");



                    while ((ss = myFile.ReadLine()) != null)
                    {
                        ss = ss.ToLower();
                        if (textBox1.Text.ToLower() == ss)
                        {
                            count++;
                        }

                    }

                    if (count == 0)
                    {
                        s.Speak("Word Not Found");
                        MessageBox.Show(" Not Found");

                    }
                    else
                    {
                        s.Speak("Good");
                        score++;
                        label4.Text = score.ToString();

                        list.insertAtEnd(textBox1.Text);

                        Label lb= new Label();
                        word_count++;
                        lb.Text += word_count+"  :  "+ textBox1.Text ;
                        lb.ForeColor = Color.Red;
                        lb.Font = new Font("Agency FB", 19, FontStyle.Bold);
                        lb.Height = 30;

                        flowLayoutPanel2.Controls.Add(lb);

                    }
                   
                }
                textBox1.Text = null;

               
            }


    }
}
