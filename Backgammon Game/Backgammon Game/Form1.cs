using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon_Game
{
    public partial class Form1 : Form
    {
        const string pbN = "pb";
        string name = "pbG", name2 ="pbG", move, moveDel;
        int counter, redPieceCount = 10, blackPieceCount = 10, redEndCount = 0, blackEndCount = 0, doubleTurnCnt = 0, midCount = 0, endCount = 0, redFCount = 0, blackFCount = 0;
        bool move1 = true, move2 = true, rDice = true, Double = false, midMove = true, redEndmove = false, blackEndMove = false, redFirstMove = true, blackFirstMove = true;

        PictureBox pb, pbDel;
        Image empty;
        Image red_Piece;
        Image black_Piece;
        Image dice1;
        Image dice2;
        Image dice3;
        Image dice4;
        Image dice5;
        Image dice6;
        Image red_Button;
        Image black_Button;

        private void pbG2_Click(object sender, EventArgs e)
        {

        }

        Image moves;

        Random rand1 = new Random();
        int diceRand1 = -1;
        int diceRand2 = -1;

        public Form1()
        {
            InitializeComponent();

            empty = Properties.Resources.empty;
            red_Piece = Properties.Resources.Red_Piece1;
            black_Piece = Properties.Resources.Black_Piece;
            dice1 = Properties.Resources.Dice1;
            dice2 = Properties.Resources.Dice2;
            dice3 = Properties.Resources.Dice3;
            dice4 = Properties.Resources.Dice4;
            dice5 = Properties.Resources.Dice5;
            dice6 = Properties.Resources.Dice6;
            red_Button = Properties.Resources.RedButton1;
            black_Button = Properties.Resources.Black_Button;
            moves = Properties.Resources.Moves;

            

        }



        private void CheckRedBoard(int col, int row)
        {

            move = "pbG";
            moveDel = "pbG2";


            if (col >= 6)
                col -= 1;

            int col2 = col, checkR = 0;
            

            if (row < 5)
                checkR = row + 1;
            if (row > 5)
                checkR = row - 1;

            string checkN = pbN;

            if (col < 10 && row < 10 && row != 6)
            {
                checkN = checkN + col.ToString() + checkR.ToString();
            }
            else
            {
                checkN = "pbG";
            }

            if (col > 9 || row > 9 && row != 6)
            {
                checkN = "pb";
                checkN = checkN + col.ToString() + "_" + checkR.ToString();
                if (checkN.Length == 5)
                    checkN = checkN.Remove(3, 1);
                if (checkN.Length == 7)
                    checkN = checkN.Remove(4, 1);

            }
            string[] checkNum = new string[1];
            for(int count = 0; count < checkN.Length; count++)
            {
                checkNum[0] = checkN[count].ToString();
            }
            if (checkNum[0] == "5")
                checkN = "pbG";

            if (diceRand1 != -1 && diceRand2 != -1)
            {
                if (Double)
                    move1 = true;
                if (row > 5)
                {
                    col += diceRand1 + 1;
                    col2 += diceRand2 + 1;
                }
                else
                {
                    col -= diceRand1 + 1;
                    col2 -= diceRand2 + 1;
                }

                if (col < 12 && row < 5 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && col >= 0)
                {
                    row = 0;
                    while (row < 5)
                    {
                        name = pbN;

                        if (col < 10 && row < 10)
                            name = name + col.ToString() + row.ToString();
                        if (col > 9 || row > 9)
                            name = name + col.ToString() + "_" + row.ToString();

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Black")
                            break;

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                        {

                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = moves;
                            pb.Tag = "Green";

                            break;
                        }
                        row++;
                    }
                    row = 0;
                }


                    if (col2 < 12 && row < 5 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && !Double && col2 >= 0)
                    {
                        a1:
                        row = 0;
                        while (row < 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Black")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row++;
                        }
                        row = 0;
                    }
                
                


                if (col < 12 && row > 5 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && col >= 0)
                {
                    row = 10;
                    while (row > 5)
                    {
                        name = pbN;

                        if (col < 10 && row < 10)
                            name = name + col.ToString() + row.ToString();
                        if (col > 9 || row > 9)
                            name = name + col.ToString() + "_" + row.ToString();

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Black")
                            break;

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                        {

                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = moves;
                            pb.Tag = "Green";

                            break;
                        }
                        row--;
                    }
                    row = 10;
                }


                    if (col2 < 12 && row > 5 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && !Double && col2 >= 0)
                    {
                        row = 10;
                        while (row > 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Black")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row--;
                        }
                        row = 10;
                    }
                

                if (col > 11 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red")
                {
                    switch (col)
                    {
                        case 12:
                            col = 11;
                            break;
                        case 13:
                            col = 10;
                            break;
                        case 14:
                            col = 9;
                            break;
                        case 15:
                            col = 8;
                            break;
                        case 16:
                            col = 7;
                            break;
                        case 17:
                            col = 6;
                            break;
                    }
                    row = 0;
                    while (row < 5)
                    {
                        name = pbN;

                        if (col < 10 && row < 10)
                            name = name + col.ToString() + row.ToString();
                        if (col > 9 || row > 9)
                            name = name + col.ToString() + "_" + row.ToString();

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Black")
                            break;

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                        {

                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = moves;
                            pb.Tag = "Green";

                            break;
                        }
                        row++;
                    }
                }


                    if (col2 > 11 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && !Double)
                    {
                        switch (col2)
                        {
                            case 12:
                                col2 = 11;
                                break;
                            case 13:
                                col2 = 10;
                                break;
                            case 14:
                                col2 = 9;
                                break;
                            case 15:
                                col2 = 8;
                                break;
                            case 16:
                                col2 = 7;
                                break;
                            case 17:
                                col2 = 6;
                                break;
                        }

                        row = 0;
                        while (row < 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Black")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row++;
                        }

                    }
                

                if (col < 0 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && move1)
                {
                    col = 0;
                    row = 0;
                    name = pbN;
                    name = name + col.ToString() + row.ToString();

                    while (this.boardPanel.Controls[name].Tag.ToString() != "Red")
                    {
                        col++;
                        row = 0;
                        name = pbN;
                        name = name + col.ToString() + row.ToString();
                    }

                

                while (this.boardPanel.Controls[name].Tag.ToString() == "Red")
                    {
                        endCount++;
                        row++;
                        name = pbN;
                        name = name + col.ToString() + row.ToString();

                        if(row == 5)
                        {
                            col++;
                            row = 0;

                            name = pbN;
                            name = name + col.ToString() + row.ToString();
                        }

                        while (this.boardPanel.Controls[name].Tag.ToString() != "Red" && col < 6)
                    {
                        col++;
                        row = 0;
                            name = pbN;
                            name = name + col.ToString() + row.ToString();
                        }

                    }

                    if (endCount != 0 && endCount != 15)
                        endCount = 0;

                    if (endCount == 15 || redEndmove)
                    {
                        redEndPB.Image = moves;
                        redEndPB.Tag = "Green";
                        

                        redEndmove = true;
                        endCount = 0;

                        move = redEndPB.Name;
                    }

                    

                }


                if (col2 < 0 && this.boardPanel.Controls[checkN].Tag.ToString() != "Red" && move2)
                {
                    col2 = 0;
                    row = 0;
                    name2 = pbN;
                    name2 = name2 + col2.ToString() + row.ToString();

                    while (this.boardPanel.Controls[name2].Tag.ToString() != "Red")
                    {
                        col2++;
                        row = 0;
                        name2 = pbN;
                        name2 = name2 + col2.ToString() + row.ToString();
                    }



                    while (this.boardPanel.Controls[name2].Tag.ToString() == "Red")
                    {
                        endCount++;
                        row++;
                        name2 = pbN;
                        name2 = name2 + col2.ToString() + row.ToString();

                        if (row == 5)
                        {
                            col2++;
                            row = 0;

                            name2 = pbN;
                            name2 = name2 + col2.ToString() + row.ToString();
                        }

                        while (this.boardPanel.Controls[name2].Tag.ToString() != "Red" && col2 < 6)
                        {
                            col2++;
                            row = 0;
                            name2 = pbN;
                            name2 = name2 + col2.ToString() + row.ToString();
                        }

                    }

                    if (endCount != 0 && endCount != 15)
                        endCount = 0;

                    if (endCount == 15 || redEndmove)
                    {
                        redEndPB.Image = moves;
                        redEndPB.Tag = "Green";

                        redEndmove = true;
                        endCount = 0;

                        moveDel = redEndPB.Name;
                    }

                    
                }


            }
            else
            {
                MessageBox.Show("Roll the dice to begin your turn.");
            }

            
        }



        private void CheckBlackBoard(int col, int row)
        {

            move = "pbG";
            moveDel = "pbG2";


            if (col >= 6)
                col -= 1;

            int col2 = col, checkR = 0;


            if (row < 5)
                checkR = row + 1;
            if (row > 5)
                checkR = row - 1;

            string checkN = pbN;

            if (col < 10 && row < 10 && row != 6)
            {
                checkN = checkN + col.ToString() + checkR.ToString();
            }
            else
            {
                checkN = "pbG";
            }

            if (col > 9 || row > 9 && row != 6)
            {
                checkN = "pb";
                checkN = checkN + col.ToString() + "_" + checkR.ToString();
                if (checkN.Length == 5)
                    checkN = checkN.Remove(3, 1);
                if (checkN.Length == 7)
                    checkN = checkN.Remove(4, 1);

            }
            string[] checkNum = new string[1];
            for (int count = 0; count < checkN.Length; count++)
            {
                checkNum[0] = checkN[count].ToString();
            }
            if (checkNum[0] == "5")
                checkN = "pbG";

            if (diceRand1 != -1 && diceRand2 != -1)
            {
                if (Double)
                    move1 = true;

                if (row > 5)
                {
                    col -= diceRand1 + 1;
                    col2 -= diceRand2 + 1;
                }
                else
                {
                    col += diceRand1 + 1;
                    col2 += diceRand2 + 1;
                }

               


                if (col < 12 && row > 5 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && col >= 0)
                {
                    row = 10;
                    while (row > 5)
                    {
                        name = pbN;

                        if (col < 10 && row < 10)
                            name = name + col.ToString() + row.ToString();
                        if (col > 9 || row > 9)
                            name = name + col.ToString() + "_" + row.ToString();

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Red")
                            break;

                            if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                        {

                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = moves;
                            pb.Tag = "Green";

                            break;
                        }
                        row--;
                    }
                    row = 10;
                }


                    if (col2 < 12 && row > 5 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && !Double && col2 >= 0)
                    {
                        row = 10;
                        while (row > 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Red")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row--;
                        }
                        row = 10;
                    }
                

                    if (col < 12 && row < 5 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && col >= 0)
                {
                    row = 0;
                    while (row < 5)
                    {
                        name = pbN;

                        if (col < 10 && row < 10)
                            name = name + col.ToString() + row.ToString();
                        if (col > 9 || row > 9)
                            name = name + col.ToString() + "_" + row.ToString();

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Red")
                            break;

                        if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                        {

                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = moves;
                            pb.Tag = "Green";

                            break;
                        }
                        row++;
                    }
                    row = 0;
                }


                    if (col2 < 12 && row < 5 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && !Double && col2 >= 0)
                    {
                        row = 0;
                        while (row < 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Red")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row++;
                        }
                        row = 0;
                    }
                
                
                    if (col > 11 && move1 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black")
                    {
                        switch (col)
                        {
                            case 12:
                                col = 11;
                                break;
                            case 13:
                                col = 10;
                                break;
                            case 14:
                                col = 9;
                                break;
                            case 15:
                                col = 8;
                                break;
                            case 16:
                                col = 7;
                                break;
                            case 17:
                                col = 6;
                                break;
                        }
                        row = 10;
                        while (row > 5)
                        {
                            name = pbN;

                            if (col < 10 && row < 10)
                                name = name + col.ToString() + row.ToString();
                            if (col > 9 || row > 9)
                                name = name + col.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name].Tag.ToString() == "Red")
                                break;

                            if (this.boardPanel.Controls[name].Tag.ToString() == "Empty")
                            {

                                pb = (PictureBox)this.boardPanel.Controls[name];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                break;
                            }
                            row--;
                        }
                    }



                    if (col2 > 11 && move2 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && !Double)
                    {
                        switch (col2)
                        {
                            case 12:
                                col2 = 11;
                                break;
                            case 13:
                                col2 = 10;
                                break;
                            case 14:
                                col2 = 9;
                                break;
                            case 15:
                                col2 = 8;
                                break;
                            case 16:
                                col2 = 7;
                                break;
                            case 17:
                                col2 = 6;
                                break;
                        }

                        row = 10;
                        while (row > 5)
                        {
                            name2 = pbN;

                            if (col2 < 10 && row < 10)
                                name2 = name2 + col2.ToString() + row.ToString();
                            if (col2 > 9 || row > 9)
                                name2 = name2 + col2.ToString() + "_" + row.ToString();

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Red")
                                break;

                            if (this.boardPanel.Controls[name2].Tag.ToString() == "Empty")
                            {
                                pb = (PictureBox)this.boardPanel.Controls[name2];
                                pb.Image = moves;
                                pb.Tag = "Green";

                                moveDel = name;
                                move = name2;

                                break;
                            }
                            row--;
                        }

                    }
                

                if (col < 0 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && move1)
                {
                    col = 0;
                    row = 10;
                    name = pbN;
                    name = name + col.ToString() + "_" + row.ToString();

                    while (this.boardPanel.Controls[name].Tag.ToString() != "Black")
                    {
                        col++;
                        row = 10;
                        name = pbN;
                        name = name + col.ToString() + "_" + row.ToString();
                    }



                    while (this.boardPanel.Controls[name].Tag.ToString() == "Black")
                    {
                        endCount++;
                        row--;
                        name = pbN;
                        name = name + col.ToString() + row.ToString();

                        if (row == 5)
                        {
                            col++;
                            row = 10;

                            name = pbN;
                            name = name + col.ToString() + "_" + row.ToString();
                        }

                        while (this.boardPanel.Controls[name].Tag.ToString() != "Black" && col < 6)
                        {
                            col++;
                            row = 10;
                            name = pbN;
                            name = name + col.ToString() + "_" + row.ToString();
                        }

                    }

                    if (endCount != 0 && endCount != 15)
                        endCount = 0;

                    if (endCount == 15 || blackEndMove)
                    {
                        blackEndPB.Image = moves;
                        blackEndPB.Tag = "Green";


                        blackEndMove = true;
                        endCount = 0;

                        move = blackEndPB.Name;
                    }

                    

                }


                if (col2 < 0 && this.boardPanel.Controls[checkN].Tag.ToString() != "Black" && move2)
                {
                    col2 = 0;
                    row = 10;
                    name2 = pbN;
                    name2 = name2 + col2.ToString() + "_" + row.ToString();

                    while (this.boardPanel.Controls[name2].Tag.ToString() != "Black")
                    {
                        col2++;
                        row = 10;
                        name2 = pbN;
                        name2 = name2 + col2.ToString() + "_" + row.ToString();
                    }



                    while (this.boardPanel.Controls[name2].Tag.ToString() == "Black")
                    {
                        endCount++;
                        row--;
                        name2 = pbN;
                        name2 = name2 + col2.ToString() + row.ToString();

                        if (row == 5)
                        {
                            col2++;
                            row = 10;

                            name2 = pbN;
                            name2 = name2 + col2.ToString() + "_" + row.ToString();
                        }

                        while (this.boardPanel.Controls[name2].Tag.ToString() != "Black" && col2 < 6)
                        {
                            col2++;
                            row = 10;
                            name2 = pbN;
                            name2 = name2 + col2.ToString() + "_" + row.ToString();
                        }

                    }

                    if (endCount != 0 && endCount != 15)
                        endCount = 0;

                    if (endCount == 15 || blackEndMove)
                    {
                        blackEndPB.Image = moves;
                        blackEndPB.Tag = "Green";

                        blackEndMove = true;
                        endCount = 0;
                        moveDel = blackEndPB.Name;
                    }

                    

                }
            }
            else
            {
                MessageBox.Show("Roll the dice to begin your turn.");
            }
        }




        public void cells(object sender, EventArgs e)
        {
            try
            {
                bool redWins = false, blackWins = false;



                pb = (PictureBox)sender;


                string[] takeNum = new string[1];

                int col = (int)boardPanel.GetColumn(pb);
                int row = (int)boardPanel.GetRow(pb);

                if (pb.Tag == "Red" && turnLabel.Text == "Reds Turn" && !redWins && !blackWins)
                {

                    pbDel = pb;
                    if (name[2] == '-')
                        name = "pbG";

                    if (name2[2] == '-')
                        name2 = "pbG";

                    if (this.boardPanel.Controls[name].Tag == "Green" && this.boardPanel.Controls[name].Tag != "Black")
                    {
                        pb = (PictureBox)this.boardPanel.Controls[name];
                        pb.Image = empty;
                        pb.Tag = "Empty";
                    }
                    if (this.boardPanel.Controls[name2].Tag == "Green" && this.boardPanel.Controls[name2].Tag != "Black")
                    {
                        pb = (PictureBox)this.boardPanel.Controls[name2];
                        pb.Image = empty;
                        pb.Tag = "Empty";
                    }
                    if (redEndPB.Tag == "Green")
                    {
                        redEndPB.Image = empty;
                        redEndPB.Tag = "Empty";
                    }

                    if (midMove || pbDel.Name != pb0_10.Name && pbDel.Name != pb09.Name && pbDel.Name != pb08.Name && pbDel.Name != pb07.Name && pbDel.Name != pb06.Name)
                    {
                        CheckRedBoard(col, row);
                    }
                }
                else
                {


                    if (pb.Tag == "Green" && turnLabel.Text == "Reds Turn")
                    {


                        pb.Image = red_Piece;
                        pb.Tag = "Red";



                        pbDel.Image = empty;
                        pbDel.Tag = "Empty";

                        if (countLabel1.Text != "0" && pbDel.Name == "pb06")
                        {
                            pb06.Image = red_Piece;
                            pb06.Tag = "Red";

                            redPieceCount--;
                            countLabel1.Text = redPieceCount.ToString();
                        }

                        if (diceRand1 != diceRand2)
                        {

                            if (pbDel.Name == pb06.Name || pbDel.Name == pb07.Name || pbDel.Name == pb08.Name || pbDel.Name == pb09.Name || pbDel.Name == pb0_10.Name)
                            {
                                if (redFirstMove)
                                {
                                    redFCount++;
                                    if (redFCount == 2)
                                    {
                                        midMove = false;
                                        redFirstMove = false;
                                    }
                                }
                                else
                                {
                                    midMove = false;
                                }
                            }

                            if (pb.Name == redEndPB.Name)
                            {
                                redEndCount++;

                                pb.Image = empty;
                                pb.Tag = "empty";

                                countLabel2.BackColor = Color.Sienna;
                                countLabel2.Text = redEndCount.ToString();

                                if (pb.Name == move)
                                {
                                    move1 = false;

                                    if (this.boardPanel.Controls[name2].Tag != "Red" && this.boardPanel.Controls[name2].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                    {
                                        pb = (PictureBox)this.boardPanel.Controls[name2];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";
                                    }
                                }
                                else
                                {
                                    move2 = false;

                                    if (this.boardPanel.Controls[name].Tag != "Red" && this.boardPanel.Controls[name].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                    {
                                        pb = (PictureBox)this.boardPanel.Controls[name];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";
                                    }

                                    
                                }
                                goto Here;
                            }

                            if (pb.Name == move)
                            {
                                if (this.boardPanel.Controls[moveDel].Tag == "Red" && this.boardPanel.Controls[name].Tag != "Red" && this.boardPanel.Controls[name].Tag != "Black")
                                {

                                    pb = (PictureBox)this.boardPanel.Controls[name];
                                    pb.Image = empty;
                                    pb.Tag = "Empty";

                                }
                                if (this.boardPanel.Controls[name].Tag != "Red" && this.boardPanel.Controls[name].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                {
                                    pb = (PictureBox)this.boardPanel.Controls[name];
                                    pb.Image = empty;
                                    pb.Tag = "Empty";
                                }
                                move2 = false;
                            }
                            else
                            {
                                if (this.boardPanel.Controls[move].Tag == "Red" && this.boardPanel.Controls[name2].Tag != "Red" && this.boardPanel.Controls[name2].Tag != "Black")
                                {
                                    pb = (PictureBox)this.boardPanel.Controls[name2];
                                    pb.Image = empty;
                                    pb.Tag = "Empty";
                                }
                                if (this.boardPanel.Controls[name2].Tag != "Red" && this.boardPanel.Controls[name2].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                {
                                    pb = (PictureBox)this.boardPanel.Controls[name2];
                                    pb.Image = empty;
                                    pb.Tag = "Empty";
                                }

                                move1 = false;
                            }
                            Here:
                            if (!move1 && !move2)
                            {
                                move1 = true;
                                move2 = true;

                                turnLabel.Text = "Blacks Turn";
                                diceButtonPB.Image = black_Button;

                                diceRand1 = -1;
                                diceRand2 = -1;
                                rDice = true;
                            }
                        }
                        else
                        {
                            if (pbDel.Name == pb06.Name || pbDel.Name == pb07.Name || pbDel.Name == pb08.Name || pbDel.Name == pb09.Name || pbDel.Name == pb0_10.Name)
                            {
                                midCount++;

                                if (midCount == 2)
                                {
                                    midCount = 0;
                                    midMove = false;
                                    redFirstMove = false;
                                }
                            }


                            if (pb.Name == redEndPB.Name)
                            {
                                redEndCount++;

                                pb.Image = empty;
                                pb.Tag = "empty";

                                countLabel2.BackColor = Color.Sienna;
                                countLabel2.Text = redEndCount.ToString();


                            }

                            doubleTurnCnt++;

                            if (doubleTurnCnt == 4)
                            {
                                doubleTurnCnt = 0;

                                turnLabel.Text = "Blacks Turn";
                                diceButtonPB.Image = black_Button;

                                diceRand1 = -1;
                                diceRand2 = -1;
                                rDice = true;
                            }
                        }

                    }


                    if (pb.Tag == "Black" && turnLabel.Text == "Blacks Turn" && !redWins && !blackWins)
                    {

                        pbDel = pb;
                        if (name[2] == '-')
                            name = "pbG";

                        if (name2[2] == '-')
                            name2 = "pbG";

                        if (this.boardPanel.Controls[name].Tag == "Green" && this.boardPanel.Controls[name].Tag != "Red")
                        {
                            pb = (PictureBox)this.boardPanel.Controls[name];
                            pb.Image = empty;
                            pb.Tag = "Empty";
                        }
                        if (this.boardPanel.Controls[name2].Tag == "Green" && this.boardPanel.Controls[name2].Tag != "Red")
                        {
                            pb = (PictureBox)this.boardPanel.Controls[name2];
                            pb.Image = empty;
                            pb.Tag = "Empty";
                        }
                        if (blackEndPB.Tag == "Green")
                        {
                            blackEndPB.Image = empty;
                            blackEndPB.Tag = "Empty";
                        }


                        if (midMove || pbDel.Name != pb04.Name && pbDel.Name != pb03.Name && pbDel.Name != pb02.Name && pbDel.Name != pb01.Name && pbDel.Name != pb00.Name)
                        {
                            CheckBlackBoard(col, row);
                        }

                    }
                    else
                    {
                        if (pb.Tag == "Green" && turnLabel.Text == "Blacks Turn")
                        {
                            pb.Image = black_Piece;
                            pb.Tag = "Black";



                            pbDel.Image = empty;
                            pbDel.Tag = "Empty";

                            if (countLabel2.Text != "0" && pbDel.Name == "pb04")
                            {
                                pb04.Image = black_Piece;
                                pb04.Tag = "Black";

                                blackPieceCount--;
                                countLabel2.Text = blackPieceCount.ToString();
                            }

                            if (diceRand1 != diceRand2)
                            {

                                if (pbDel.Name == pb00.Name || pbDel.Name == pb01.Name || pbDel.Name == pb02.Name || pbDel.Name == pb03.Name || pbDel.Name == pb04.Name)
                                {
                                    if (blackFirstMove)
                                    {
                                        blackFCount++;
                                        if (blackFCount == 2)
                                        {
                                            midMove = false;
                                            blackFirstMove = false;
                                        }

                                    }
                                    else
                                    {
                                        midMove = false;
                                    }
                                }



                                if (pb.Name == blackEndPB.Name)
                                {
                                    blackEndCount++;

                                    pb.Image = empty;
                                    pb.Tag = "empty";

                                    countLabel1.BackColor = Color.DimGray;
                                    countLabel1.Text = blackEndCount.ToString();

                                    if (pb.Name == move)
                                    {
                                        move1 = false;

                                        if (this.boardPanel.Controls[name2].Tag != "Red" && this.boardPanel.Controls[name2].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                        {
                                            pb = (PictureBox)this.boardPanel.Controls[name2];
                                            pb.Image = empty;
                                            pb.Tag = "Empty";
                                        }
                                    }
                                    else
                                    {
                                        move2 = false;

                                        if (this.boardPanel.Controls[name].Tag != "Red" && this.boardPanel.Controls[name].Tag != "Black" || pbDel.Name == redEndPB.Name)
                                        {
                                            pb = (PictureBox)this.boardPanel.Controls[name];
                                            pb.Image = empty;
                                            pb.Tag = "Empty";
                                        }
                                    }

                                    goto Here1;
                                }


                                if (pb.Name == move)
                                {
                                    if (this.boardPanel.Controls[moveDel].Tag == "Black" && this.boardPanel.Controls[name].Tag != "Black" && this.boardPanel.Controls[name].Tag != "Red")
                                    {

                                        pb = (PictureBox)this.boardPanel.Controls[name];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";

                                    }
                                    if (this.boardPanel.Controls[name].Tag != "Black" && this.boardPanel.Controls[name].Tag != "Red" || pbDel.Name == blackEndPB.Name)
                                    {
                                        pb = (PictureBox)this.boardPanel.Controls[name];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";
                                    }
                                    move2 = false;
                                }
                                else
                                {
                                    if (this.boardPanel.Controls[move].Tag == "Black" && this.boardPanel.Controls[name2].Tag != "Black" && this.boardPanel.Controls[name2].Tag != "Red")
                                    {
                                        pb = (PictureBox)this.boardPanel.Controls[name2];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";
                                    }
                                    if (this.boardPanel.Controls[name2].Tag != "Black" && this.boardPanel.Controls[name2].Tag != "Red" || pbDel.Name == blackEndPB.Name)
                                    {
                                        pb = (PictureBox)this.boardPanel.Controls[name2];
                                        pb.Image = empty;
                                        pb.Tag = "Empty";
                                    }

                                    move1 = false;
                                }
                                Here1:
                                if (!move1 && !move2)
                                {
                                    move1 = true;
                                    move2 = true;

                                    turnLabel.Text = "Reds Turn";
                                    diceButtonPB.Image = red_Button;

                                    diceRand1 = -1;
                                    diceRand2 = -1;
                                    rDice = true;
                                }
                            }
                            else
                            {
                                if (pbDel.Name == pb00.Name || pbDel.Name == pb01.Name || pbDel.Name == pb02.Name || pbDel.Name == pb03.Name || pbDel.Name == pb04.Name)
                                {
                                    midCount++;

                                    if (midCount == 2)
                                    {
                                        midCount = 0;
                                        midMove = false;
                                        blackFirstMove = false;
                                    }
                                }

                                if (pb.Name == blackEndPB.Name)
                                {
                                    blackEndCount++;

                                    pb.Image = empty;
                                    pb.Tag = "empty";

                                    countLabel1.BackColor = Color.DimGray;
                                    countLabel1.Text = blackEndCount.ToString();

                                }

                                doubleTurnCnt++;

                                if (doubleTurnCnt == 4)
                                {
                                    doubleTurnCnt = 0;

                                    turnLabel.Text = "Reds Turn";
                                    diceButtonPB.Image = red_Button;

                                    diceRand1 = -1;
                                    diceRand2 = -1;
                                    rDice = true;
                                }
                            }

                        }


                    }
                    if (redEndCount == 15)
                    {
                        turnLabel.Text = "Red Wins";
                        MessageBox.Show("Red Has Won The Game!");

                    }
                    if (blackEndCount == 15)
                    {
                        turnLabel.Text = "Black Wins";
                        MessageBox.Show("Black Has Won The Game!");

                    }

                }
            
            }
            catch (Exception ex)
            {

            }
        }

        private void diceButtonPB_Click(object sender, EventArgs e)
        {

            
            if (rDice)
            {
                counter = 0;
                diceTimer.Start();
                rDice = false;
                midMove = true;
            }
            else
            {
                NoMovesForm NoMoves = new NoMovesForm();
                NoMoves.ShowDialog();

                if(turnLabel.Text == "Reds Turn" && NoMoves.SwitchTurn)
                {
                    rDice = true;
                    turnLabel.Text = "Blacks Turn";
                    diceButtonPB.Image = black_Button;
                    move1 = true;
                    move2 = true;
                    diceRand1 = -1;
                    diceRand2 = -1;
                    NoMoves.SwitchTurn = false;
                    doubleTurnCnt = 0;
                }

                if (turnLabel.Text == "Blacks Turn" && NoMoves.SwitchTurn)
                {
                    rDice = true;
                    turnLabel.Text = "Reds Turn";
                    diceButtonPB.Image = red_Button;
                    move1 = true;
                    move2 = true;
                    diceRand1 = -1;
                    diceRand2 = -1;
                    NoMoves.SwitchTurn = false;
                    doubleTurnCnt = 0;
                }
            }

            
        }

        private void diceTimer_Tick(object sender, EventArgs e)
        {
            diceRand1 = rand1.Next(6);
            diceRand2 = rand1.Next(6);

            switch (diceRand1)
            {
                case 0:
                    dice1PB.Image = dice1;
                    break;
                case 1:
                    dice1PB.Image = dice2;
                    break;
                case 2:
                    dice1PB.Image = dice3;
                    break;
                case 3:
                    dice1PB.Image = dice4;
                    break;
                case 4:
                    dice1PB.Image = dice5;
                    break;
                case 5:
                    dice1PB.Image = dice6;
                    break;
            }

            switch (diceRand2)
            {
                case 0:
                    dice2PB.Image = dice1;
                    break;
                case 1:
                    dice2PB.Image = dice2;
                    break;
                case 2:
                    dice2PB.Image = dice3;
                    break;
                case 3:
                    dice2PB.Image = dice4;
                    break;
                case 4:
                    dice2PB.Image = dice5;
                    break;
                case 5:
                    dice2PB.Image = dice6;
                    break;
            }

            counter++;

            if (diceRand1 == diceRand2)
            {
                Double = true;
            }
            else
            {
                Double = false;
            }

            if (counter == 5 && turnLabel.Text == "Roll Dice")
            {
                rDice = true;

                if (diceRand1 > diceRand2)
                {
                    turnLabel.Text = "Blacks Turn";
                    diceButtonPB.Image = black_Button;
                }
                else
                {
                    turnLabel.Text = "Reds Turn";
                    diceButtonPB.Image = red_Button;
                }

                if (diceRand1 == diceRand2)
                    turnLabel.Text = "Roll Dice";

                diceRand1 = -1;
                diceRand2 = -1;
            }
            

            if (counter == 5)
                diceTimer.Stop();
        }



    }
}
