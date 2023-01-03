using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterMind
{
    public partial class MainPage : ContentPage
    {
        //GLOBAL VARIABLES
        int GAME_BOARD_COL = 12;
        int GAME_BOARD_ROW = 5;

        //variables
        int styleId = 12;
        int _currRow = 1;

        Color DefaultColor = Color.AliceBlue;
        Color newColor;

        List<Button> LstPegs = new List<Button>();
        public MainPage()
        {
            InitializeComponent();
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            Button peg;
           //BoxView b;

            //tap gesture will go here for the pegs

            //for loop
            for (int i = 0; i  <GAME_BOARD_ROW; i++)
            {
                for (int h = 0; h < GAME_BOARD_COL; h++)
                {
                    if(h < 5)
                    {
                        //Create pegs
                        peg = new Button();
                        peg.CornerRadius = 65;
                        peg.BackgroundColor = DefaultColor;
                        peg.StyleId = styleId.ToString();
                        peg.SetValue(Grid.ColumnProperty, h);
                        peg.SetValue(Grid.RowProperty, i);
                        peg.IsEnabled = false;
                        GrdBoard.Children.Add(peg);
                        LstPegs.Add(peg);
                        
                        //this will disable the buttons to avoid cheating 
                        if(i==0)
                        {
                            peg = new Button();
                            peg.CornerRadius = 65;
                            peg.BackgroundColor = DefaultColor;
                            peg.SetValue(Grid.ColumnProperty, h);
                            peg.SetValue(Grid.RowProperty, i);
                            peg.IsEnabled = false;
                            peg.Text = "[]";
                            GrdBoard.Children.Add(peg);
                        }
                    }
                    //this is for creating the grid for the clue pegs
                    else if(i > 0 && h == 5)
                    {

                    }

                }
            }

        }
        private void BtnLoad_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnStart_Clicked(object sender, EventArgs e) //when the button is clicked all the pegs go to default color
        {
            _currRow = 1;
            foreach(var btn in LstPegs)
            {
                btn.IsEnabled = false;
                btn.BackgroundColor = DefaultColor;
                
            }
            newColor = DefaultColor;
            GrdBoard.IsVisible = true;
        }
       
        private async void BtnCheck_Clicked(object sender, EventArgs e) //using async
        {
            _currRow++; //incremented value

            //this foreach only allows user to click on one row in order
            foreach(var btn in GrdBoard.Children)
            {
                if(btn.StyleId==_currRow.ToString())
                {
                    btn.IsEnabled = true; // allows button to be pressed
                }
            }
            if(_currRow==12)
            {
                Sequence();
            }
            await SequenceCheck();
        }

        private async Task SequenceCheck()
        {

        }
        private void Sequence()
        {

        }
        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }
    }
}
