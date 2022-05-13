using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace X_O_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int x = 1;
        private bool check = false;
        private char[,] matHelp = new char[3, 3];
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            int row = (int)b.GetValue(Grid.RowProperty);
            int col = (int)b.GetValue(Grid.ColumnProperty);

            if (b.Content.ToString() == "?")
            {
                if (x % 2 == 0)
                {
                    b.Content = "O";
                    matHelp[row, col] = 'O';
                }

                else
                {
                    b.Content = "X";
                    matHelp[row, col] = 'X';
                }
                x++;
            }
            if(x>=5)
            {
                check = CheckWin(row, col);
                if (check == true)
                    MessageBox.Show(b.Content + " " + "WINNER");
            }
             
                if(x>9 && check==false)
                MessageBox.Show("no winner, play again...");

        }

        private bool CheckWin(int row, int col)
        {
            if (row == 0 && col == 0)
            {
                if (matHelp[row, col] == matHelp[row, 1] && matHelp[row, col] == matHelp[row, 2]
                    || matHelp[row, col]==matHelp[1,col] && matHelp[row, col]==matHelp[2,col]
                    || matHelp[row,col]==matHelp[row+1,col+1] && matHelp[row+2, col+2] == matHelp[row, col])
                    return true;
            }
            if (row == 0 && col == 2)
            {
                if (matHelp[row, col] == matHelp[row, 1] && matHelp[row, col] == matHelp[row, 0]
                    || matHelp[row, col] == matHelp[1, col] && matHelp[row, col] == matHelp[0, col]
                    || matHelp[row, col] == matHelp[1,1] && matHelp[2,0] == matHelp[row, col])
                    return true;
            }
            if (row == 2 && col == 0)
            {
                if (matHelp[row, col] == matHelp[row, 1] && matHelp[row, col] == matHelp[row, 2]
                    || matHelp[row, col] == matHelp[1,col] && matHelp[row, col] == matHelp[0, col]
                    || matHelp[row, col] == matHelp[1, 1] && matHelp[0,2] == matHelp[row, col])
                    return true;
            }
            if (row == 2 && col == 2)
            {
                if (matHelp[row, col] == matHelp[row, 1] && matHelp[row, col] == matHelp[row, 0]
                    || matHelp[row, col] == matHelp[1, col] && matHelp[row, col] == matHelp[0, col]
                    || matHelp[row, col] == matHelp[1, 1] && matHelp[0, 0] == matHelp[row, col])
                    return true;
            }
            if (row == 1 && col == 1)
            {
                if (matHelp[row, col] == matHelp[row, 0] && matHelp[row, col] == matHelp[row, 2]
                    || matHelp[row, col] == matHelp[0,col] && matHelp[row, col] == matHelp[2,col]
                    || matHelp[row, col] == matHelp[2,2] && matHelp[0, 0] == matHelp[row, col]
                    || matHelp[row, col] == matHelp[2, 0] && matHelp[0, 2] == matHelp[row, col])
                    return true;
            }
            if (matHelp[row, 0] == matHelp[row, 1] && matHelp[row, 0] == matHelp[row, 2] || matHelp[0, col] == matHelp[1, col] && matHelp[0, col] == matHelp[2, col])
                return true;



            return false;
        }
    }
}
