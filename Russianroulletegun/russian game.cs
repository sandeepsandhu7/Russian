using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russianroulletegun
{
    public partial class Russian_Roullete : Form
    {
        public Russian_Roullete()
        {
            InitializeComponent();
        }
        Roullete Rolleteobj = new Roullete();
        Random Rand = new Random();
        int totalshot = 6;//sets the value for totalshots
        int guntry = 2;//sets the value for gun
        private void loadbutt_Click(object sender, EventArgs e)
        {
            //below coide helps to show the image
            //coding for images//
            Assembly Assem = Assembly.GetExecutingAssembly();
            Stream Str = Assem.GetManifestResourceStream("Russianroulletegun.Resources.load.gif");
            Bitmap bmpObj = new Bitmap(Str);
            gigimg.Image = bmpObj;

            //coding for sounds//
            System.Media.SoundPlayer sndObj = new System.Media.SoundPlayer(Russianroulletegun.Properties.Resources.Loadsound);
            sndObj.Play();

            spinbutt.Enabled = true;
            loadbutt.Enabled = false;//enable button
            Rolleteobj.load = 1;
        }

        private void spinbutt_Click(object sender, EventArgs e)
        {

            //below coide helps to show the image
            //coding for images//
            Assembly Assem = Assembly.GetExecutingAssembly();
            Stream Str = Assem.GetManifestResourceStream("Russianroulletegun.Resources.spin.gif");
            Bitmap bmpObj = new Bitmap(Str);
            gigimg.Image = bmpObj;

            //coding for sounds//
            System.Media.SoundPlayer sndObj = new System.Media.SoundPlayer(Russianroulletegun.Properties.Resources.spinSound);
            sndObj.Play();


            Rolleteobj.bulleteloadspin = Rand.Next(1, 6);

            shootbutt.Enabled = true;
            spinbutt.Enabled = false;
        }

        private void shootbutt_Click(object sender, EventArgs e)
        {
            //below coide helps to show the image
            //coding for images//
            Assembly Assem = Assembly.GetExecutingAssembly();
            Stream Str = Assem.GetManifestResourceStream("Russianroulletegun.Resources.shoot.gif");
            Bitmap bmpObj = new Bitmap(Str);
            gigimg.Image = bmpObj;
           
            //coding for sounds//

           System.Media.SoundPlayer sndObj = new System.Media.SoundPlayer(Russianroulletegun.Properties.Resources.shootSound);
           sndObj.Play();
            if (totalshot > 0 && Rolleteobj.bulleteloadspin == 1)
            {

                MessageBox.Show("Shoot You loose");
                shootawaybutt.Enabled = false;
                shootbutt.Enabled = false;


            }
            else if (totalshot > 0 && Rolleteobj.bulleteloadspin != 1)
            {
                MessageBox.Show("Blank Fire");
                totalshot = totalshot - 1;//minus one from total
                Rolleteobj.bulleteloadspin = Rolleteobj.Bulleteloop(Rolleteobj.bulleteloadspin);

            }
        }
        private void Playagbutt_Click(object sender, EventArgs e)
        {
            (new Russian_Roullete()).Show();
            this.Hide();
        }

        private void shootawaybutt_Click(object sender, EventArgs e)
            {
            Assembly Assem = Assembly.GetExecutingAssembly();
            Stream Str = Assem.GetManifestResourceStream("Russianroulletegun.Resources.shootaway.gif");
            Bitmap bmpObj = new Bitmap(Str);
            gigimg.Image = bmpObj;

            if (totalshot > 0 && Rolleteobj.bulleteloadspin == 1 && guntry == 2)
                {

                    MessageBox.Show("you win you score is 200");
                    shootawaybutt.Enabled = false;
                    shootbutt.Enabled = false;


                }
                if (totalshot > 0 && Rolleteobj.bulleteloadspin == 1 && guntry == 1)
                {

                    MessageBox.Show("you win and your score is 100");//display the meesage
                    shootbutt.Enabled = false;
                    shootawaybutt.Enabled = false;

                }

                else if (totalshot > 0 && Rolleteobj.bulleteloadspin != 1)
                {
                    MessageBox.Show("Blank Fire");
                    totalshot = totalshot - 1;
                    Rolleteobj.bulleteloadspin = Rolleteobj.Bulleteloop(Rolleteobj.bulleteloadspin);

                }
            }

        }
    }

