using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectv1
{
    public partial class frmProject : Form
    {
        public frmProject()
        {
            InitializeComponent();
        }

        int[,] boardStatus = new int[4, 4];
        int optel = 0;
        int rowButton = 0;
        int colButton = 0;
        PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        Image[,] imageList = new Image[4, 4];
        Button[,] buttonList = new Button[4, 4];
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            string input;

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
            int index = 0;
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
            button.Visible = false;

            

            if (optel == 1)
            {
                int lastRow = 0;
                int lastCol = 0;
                GetRow(button, ref lastRow);
                GetCol(button, ref lastCol);
               

            }
            else
            {
                optel = 0;
            }

            GetRow(button, ref rowButton);
            GetCol(button, ref colButton);





        }
        private int GetRow(Button button,  ref int rows)
        {
            

            for (int i = 0; i < buttonList.GetLength(0); i++)
            {
                for (int j = 0; j < buttonList.GetLength(1); j++)
                {
                    if (button == buttonList[i,j])
                    {
                        rows = i;
                    }
                }
            }
            return rows;

        }
        private int GetCol(Button button, ref int col)
        {

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
            optel++;
            return col;
            

        }
    }
}

