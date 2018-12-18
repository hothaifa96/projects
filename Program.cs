using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame_project
{
    class Program
    {
        static void Main(string[] args)
        {

            int player1 = 0, player2 = 0, tries =-1, row1=-1, row2 = -1, column1 = -1, column2 = -1;
            int size = MatrixSizeReciver();int Mates= (size * size) / 2;
            bool flag = true;
            Console.WriteLine($"you have chosied a borad with size of {size}" );
            string [,] memorygame = FillArray(size);
            int[,] zeros = new int[size,size];
           
            while (player1+player2 != Mates)
            {
                tries++;
                masterprinter(memorygame, size,-1,-1);
                while (flag)
                {
                    {
                        if (tries % 2 == 0)
                            Console.WriteLine("first player ****1****");
                        else
                            Console.WriteLine("second player ****2****");
                    }//player turn calculater
                    {
                        Console.WriteLine("enter your 1st suggestion row and column:");
                        row1 = inputcheck(size);
                        column1 = inputcheck(size);
                        if (memorygame[row1, column1] == "0")
                        {
                            Console.WriteLine("you have played this card already");
                            continue;
                        }
                        else
                            masterprinter(memorygame, size, row1, column1);
                        Console.WriteLine("enter your 2nd suggestion row and column:");
                        row2 = inputcheck(size);
                        column2 = inputcheck(size);
                        if (memorygame[row2, column2] == "0")
                        {
                            Console.WriteLine("you have played this card already");
                            continue;
                        }
                        else
                            masterprinter(memorygame, size, row2, column2);
                        flag = false;
                        //suggestion check
                        if (row1 == row2 && column1 == column2)
                        {
                            Console.WriteLine(" you choosed the same card twice !!!! try again ");
                            flag = true;
                        }
                        if (memorygame[row1, column1] == "0" || memorygame[row2, column2] == "0")
                        {
                            Console.WriteLine(" this card is already token ");
                            flag = true;
                        }// check thats the matrix cell is nor empty
                    }// check the suggestion 
                }// index's reciver
                if ((memorygame[row1, column1]) == (memorygame[row2, column2]))
                {
                    Console.WriteLine("Nice work ");
                    memorygame[row1, column1] = "0";
                    memorygame[row2, column2] = "0";
                    if (tries % 2 == 0)
                    {
                        tries--;
                        player1++;
                    }
                    else
                    {
                        player2++;
                        tries--;
                    }
                }
                else
                    Console.WriteLine("Ooops");
              
                flag = true;
            }
            if (player1 > player2)
            {
                Console.WriteLine($"the first player is the winner you scored **{player1}**");

            }
            else
                if (player1 == player2)
                Console.WriteLine("draw");
            else
                Console.WriteLine($"the second player is the winner you scored **{player2}**");
           
        }
        static void masterprinter(string [,] arr,int size ,int r , int c)
        {
            char [,] dash = new char [size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (r == i && c == j)
                    {
                        string s = arr[i, j];
                        Console.Write(s);
                    }
                    else if (arr[i, j] == "0")
                        dash[i, j] = 'O';
                    else
                        dash[i, j] = 'X';
                    Console.Write(dash[i, j]+ "  ");
                }
                Console.WriteLine();
            }
        }
        static int inputcheck(int size)
        {
            int input =int.Parse(Console.ReadLine());
            if (((input > -1) && (input < size)))
                return input;
            else
            {
                Console.WriteLine("the number is out of the range pleas select number betwen 0 and " +(size-1));
                input=inputcheck(size);
            }
            return input;
        }
        static string[,] FillArray(int size)
        {
            string[,] a;
            a = new string[size, size];
            int x = a.GetLength(0);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j += 2)
                {
                    Console.WriteLine("please enter a word :");
                    string input = Console.ReadLine();
                    a[i, j] = input;
                    a[i, j + 1] = input;
                }

            }// fill the array with strings 
            int cells = size * size;
            Random r = new Random();
            for (int i = 0; i < cells - 1; i++)
            {
                int j = r.Next(i, cells);
                int row1 = i / size;
                int col1 = i % size;
                int row2 = j / size;
                int col2 = j % size;
                string temp = a[row1, col1];
                a[row1, col1] = a[row2, col2];
                a[row2, col2] = temp;
            }//randomize the matrix 

            return a;



            /*
            Random rand = new Random();
            Random rand1 = new Random();
            int row, column;bool flag = false;
            int[,] arr = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = 0;
                }
            }//to fill thr matrix with zero's
            int MatesNo = (size * size) / 2;
            for (int i = 1; i <= MatesNo; i++)
            {
                flag = true;
                while (flag)
                {
                    row = rand.Next(0, size);
                    column = rand.Next(0, size);
                    if (arr[row, column] == 0)
                    {
                        arr[row, column] = i;
                        flag = false;
                    }
                }//fill the first card into the mmatrix 
                flag = true;
                while (flag)
                {
                    row = rand.Next(0, size);
                    column = rand.Next(0, size);
                    if (arr[row, column] ==0 )
                    {
                        arr[row, column] = i;
                        flag = false;
                    }
                }//fill the second card into the matrix /
            }//this loop run to each cell in the matrix and fill it witha random index 
            return arr;
        }//fill the matrix with a rondom index in the range */
        }
        static int  MatrixSizeReciver ()
        {
            Console.Write("please enter gmae bord size :");
            int input = int.Parse(Console.ReadLine());
            if ((input <= 0) || input % 2 == 1)
            {
                Console.WriteLine("the size doesn't match the requist's ");
                return MatrixSizeReciver();
            }
            else
                return input;
        }//receptor and input check       
    }
}

