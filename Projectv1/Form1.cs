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
            //hierin zorg ik ervoor dat ik de images op willekeurige plaatsen te zetten in de array zodat ik het erna kan uitschrijven in de picture boxes
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
            //neemt de button zijn sender en stuurt het naar de functie
            Button button = (Button)sender;
            KnopChecken(button);
        }

        private void KnopChecken(Button button)
        {
            button.Visible = false;


            //controleer of dit de eerste of de tweede gekozen knop is
            if (firstButton == 1)
            {
                buttonLast = button;

                lastRow = GetRow(button);
                lastCol = GetCol(button);

                //steekt alles in deze functie om dan te checken of de fotos gelijk zijn
                CheckImages(buttonLast, buttonFirst, rowButton, colButton, lastRow, lastCol);

            }
            else
            {
                //zorgt ervoor dat je het weer opnieuw kunt doen met de volgende buttons
                firstButton = 0;
                buttonFirst = button;
            }
            //haalt de positie van de buttons op in de matrix
            rowButton = GetRow(button);
            colButton = GetCol(button);

        }
        private void CheckImages(Button buttonLast, Button buttonFirst, int rowButton, int colButton, int lastRow, int lastCol)
        {
            //haalt op de twee images die gekozen waren
            image1 = pictureBoxes[lastRow, lastCol].Image;
            image2 = pictureBoxes[rowButton, colButton].Image;
            aantalTries++;
            //controleerd of de fotos gelijk zijn
            if (AreImagesEqual(image1, image2))
            {
                einde++;
                //controleert of alle kaarten zijn gevonden
                if (einde == 8)
                {
                    DialogResult result = MessageBox.Show("Je hebt het spel voltooid! Totaal aantal pogingen: " + aantalTries + ". Wil je opnieuw spelen?", "Spel voltooid", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Opnieuw starten als de speler op "Ja" klikt
                        restartGame();
                    }
                    else
                    {
                        // Afsluiten als de speler op "Nee" klikt
                        Application.Exit();
                    }
                }
            }
            else
            {
                //start de timer om de kaarten niet ondmiddelijk te sluiten
                tmrKaart.Start();
            }
            //voegt de aantal keren dat je probeerde aan de label
            lblText.Text = "amount tries: " + aantalTries;
        }
        private void VisibilityKaart()
        {
            //verbergd de eerste en laatste knop 
            buttonFirst.Visible = false;
            buttonLast.Visible = false;
            //reset de eerste knop indicator
            firstButton = 0;

            //stopt de timer
            tmrKaart.Stop();
            //checked of het door de timer is voorbij gegaan
            if (tmrKaart.Enabled == false)
            {

                clockStop = 0;
                
                //maakt de eerste en tweede knop weer zichtbaar
                buttonLast.Visible = true;
                buttonFirst.Visible = true;

                kaartZichtbaar = 0;

            }
        }
        private bool AreImagesEqual(Image image1, Image image2)
        {
            //converteert de fotos naar byte
            using (MemoryStream stream1 = new MemoryStream())
            using (MemoryStream stream2 = new MemoryStream())
            {
                image1.Save(stream1, ImageFormat.Png);
                image2.Save(stream2, ImageFormat.Png);

                byte[] byteArray1 = stream1.ToArray();
                byte[] byteArray2 = stream2.ToArray();

                //vergelijked de byte arrays of ze gelijk zijn
                return byteArray1.SequenceEqual(byteArray2);
            }
        }
        private int GetRow(Button button)
        {
            //haalt op de kolom positie
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
            //haalt op de rij positie
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
            //gaat een second of twee de kaarten open houden
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
            //herstart het hele spel
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

