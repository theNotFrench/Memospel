using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Projectv1
{
    public partial class frmProject : Form
    {
        public frmProject()
        {
            InitializeComponent();
        }

        int firstButton = 0;
        int clockStop = 1;
        int kaartZichtbaar = 0;
        Button buttonFirst;
        Button buttonLast;
        int rowButton = 0;
        int colButton = 0;
        int lastRow = 0;
        int lastCol = 0;
        PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        Image[,] imageList = new Image[4, 4];
        Button[,] buttonList = new Button[4, 4];
        Label[] labelList = new Label[8];
        int aantalTries = 0;
        int einde = 0;
        Image image1;
        Image image2;

        private void frmProject_Load(object sender, EventArgs e)
        {
            kaartenPlaatsen();


            buttonList[0, 0] = btn1;
            buttonList[0, 1] = btn2;
            buttonList[0, 2] = btn3;
            buttonList[0, 3] = btn4;
            buttonList[1, 0] = btn5;
            buttonList[1, 1] = btn6;
            buttonList[1, 2] = btn7;
            buttonList[1, 3] = btn8;
            buttonList[2, 0] = btn9;
            buttonList[2, 1] = btn10;
            buttonList[2, 2] = btn11;
            buttonList[2, 3] = btn12;
            buttonList[3, 0] = btn13;
            buttonList[3, 1] = btn14;
            buttonList[3, 2] = btn15;
            buttonList[3, 3] = btn16;


        }

        private void kaartenKiezenInput()
        {

        }
        private void kaartenPlaatsen()
        {
            Random random = new Random();
            Random g2 = new Random();

            //ik heb  ontdekt dat je images en pictureboxes ook in een array kunt steken wat zeer handig is in deze situatie
            //door de images en de picture boxesin een array te steken kan ik zo een random getal door laten gaan via de index
            //hiermee kan ik zonder het compleet manueel uit te schrijven het verkorteren in een whiel of een for 



            imageList[0, 0] = Properties.Resources.A;
            imageList[0, 1] = Properties.Resources.A;
            imageList[0, 2] = Properties.Resources.B;
            imageList[0, 3] = Properties.Resources.B;
            imageList[1, 0] = Properties.Resources.C;
            imageList[1, 1] = Properties.Resources.C;
            imageList[1, 2] = Properties.Resources.D;
            imageList[1, 3] = Properties.Resources.D;
            imageList[2, 0] = Properties.Resources.E;
            imageList[2, 1] = Properties.Resources.E;
            imageList[2, 2] = Properties.Resources.F;
            imageList[2, 3] = Properties.Resources.F;
            imageList[3, 0] = Properties.Resources.G;
            imageList[3, 1] = Properties.Resources.G;
            imageList[3, 2] = Properties.Resources.H;
            imageList[3, 3] = Properties.Resources.H;

            //ik steek ze allemaal hier in twee keer zodat ze twee keer in de pictureBoxes verschijnen



            pictureBoxes[0, 0] = pictureBox1;
            pictureBoxes[0, 1] = pictureBox2;
            pictureBoxes[0, 2] = pictureBox3;
            pictureBoxes[0, 3] = pictureBox4;
            pictureBoxes[1, 0] = pictureBox5;
            pictureBoxes[1, 1] = pictureBox6;
            pictureBoxes[1, 2] = pictureBox7;
            pictureBoxes[1, 3] = pictureBox8;
            pictureBoxes[2, 0] = pictureBox9;
            pictureBoxes[2, 1] = pictureBox10;
            pictureBoxes[2, 2] = pictureBox11;
            pictureBoxes[2, 3] = pictureBox12;
            pictureBoxes[3, 0] = pictureBox13;
            pictureBoxes[3, 1] = pictureBox14;
            pictureBoxes[3, 2] = pictureBox15;
            pictureBoxes[3, 3] = pictureBox16;


            int Row = imageList.GetLength(0);
            int Cols = imageList.GetLength(1);

            int rowRandom;
            int colRandom;
            Image temp;
            //hierin zorg ik ervoor dat ik de images op willekeurige plaatsen te zetten in de array zoda tik het erna kan uitschrijven in de picture boxes
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    rowRandom = random.Next(0, Row); // kiest een random plaats in de rows
                    colRandom = random.Next(0, Cols); //kiest een random plaats in de col

                    //ik swap de images door elkaar
                    temp = imageList[i, j];
                    imageList[i, j] = imageList[rowRandom, colRandom];
                    imageList[rowRandom, colRandom] = temp;
                }
            }

            for (int a = 0; a < Row; a++)
            {
                for (int b = 0; b < Cols; b++)
                {
                    pictureBoxes[a, b].Image = imageList[a, b];
                }
            }

        }

        private void btnCheck(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            KnopChecken(button);
        }

        private void KnopChecken(Button button)
        {
            button.Visible = false;



            if (firstButton == 1)
            {
                buttonLast = button;

                lastRow = GetRow(button);
                lastCol = GetCol(button);


                CheckImages(buttonLast, buttonFirst, rowButton, colButton, lastRow, lastCol);

            }
            else
            {
                firstButton = 0;
                buttonFirst = button;
            }

            rowButton = GetRow(button);
            colButton = GetCol(button);

        }
        private void CheckImages(Button buttonLast, Button buttonFirst, int rowButton, int colButton, int lastRow, int lastCol)
        {
            image1 = pictureBoxes[lastRow, lastCol].Image;
            image2 = pictureBoxes[rowButton, colButton].Image;
            aantalTries++;
            if (AreImagesEqual(image1, image2))
            {
                einde++;
                if (einde == 8)
                {
                    MessageBox.Show("je bent klaar met de game! totaal aantal tries: " + aantalTries);
                }
            }
            else
            {

                tmrKaart.Start();
            }

            lblText.Text = "amount tries: " + aantalTries;
        }
        private void VisibilityKaart()
        {
            buttonFirst.Visible = false;
            buttonLast.Visible = false;
            firstButton = 0;
            for (int i = 0; i < buttonList.GetLength(0); i++)
            {
                for (int j = 0; j < buttonList.GetLength(1); j++)
                {
                    buttonList[i, j].Enabled = true;
                }
            }
            tmrKaart.Stop();
            if (kaartZichtbaar == 1)
            {
                clockStop = 0;
                buttonLast.Visible = true;
                buttonFirst.Visible = true;

                kaartZichtbaar = 0;

            }
        }
        private bool AreImagesEqual(Image image1, Image image2)
        {
            // Convert the images to byte arrays for comparison
            using (MemoryStream stream1 = new MemoryStream())
            using (MemoryStream stream2 = new MemoryStream())
            {
                image1.Save(stream1, ImageFormat.Png);
                image2.Save(stream2, ImageFormat.Png);

                byte[] byteArray1 = stream1.ToArray();
                byte[] byteArray2 = stream2.ToArray();

                // Compare the byte arrays for equality
                return byteArray1.SequenceEqual(byteArray2);
            }
        }
        private int GetRow(Button button)
        {

            int rows = 0;
            for (int i = 0; i < buttonList.GetLength(0); i++)
            {
                for (int j = 0; j < buttonList.GetLength(1); j++)
                {
                    if (button == buttonList[i, j])
                    {
                        rows = i;
                    }
                }
            }
            return rows;

        }
        private int GetCol(Button button)
        {
            int col = 0;
            for (int i = 0; i < buttonList.GetLength(0); i++)
            {
                for (int j = 0; j < buttonList.GetLength(1); j++)
                {
                    if (button == buttonList[i, j])
                    {
                        col = j;


                    }
                }
            }
            firstButton++;
            return col;


        }

        private void tmrKaart_Tick(object sender, EventArgs e)
        {
            clockStop++;
            if (clockStop == 3)
            {
                kaartZichtbaar++;
                VisibilityKaart();
                tmrKaart.Stop();
            }
        }
        private void restartGame()
        {
            aantalTries = 0;
            lblText.Text = "amount tries: " + aantalTries;
            einde = 0;
            firstButton = 0;
            kaartenPlaatsen();
            for (int i = 0; i < buttonList.GetLength(0); i++)
            {
                for (int j = 0; j < buttonList.GetLength(1); j++)
                {
                    buttonList[i, j].Visible = true;
                }
            }

        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartGame();
        }





    }
}

