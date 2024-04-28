using System;
using Listas;
namespace Game
{
    public enum Direction {North, East, South, West};

    public struct Item
    { 
        public int value;
        public int row;
        public int col;
    }

    public class Board
    {


        /// <summary>
        /// Matrix of chars that represent the board:
        /// - 0: Empty space
        /// - w: Wall
        /// - i: Item
        /// - g: Goal
        /// </summary>
        char[,] map;
        public char[,] Map => map;

        /// <summary>
        /// Number of rows and cols of the map
        /// </summary>
        int ROWS, COLS;

        /// <summary>
        /// Array with the items contained in this board
        /// </summary>
        Item[] itemsInBoard;

        /// <summary>
        /// The number items in this board.
        /// </summary>
        int numItemsInBoard;

        /// <summary>
        /// Creates a new board. 
        /// </summary>
        /// <param name="r">Number of rows</param>
        /// <param name="c">Number of columns</param>
        /// <param name="textMap">String of size r*c that represents the map (walls, goals and empty spaces)</param>
        /// <param name="maxItems">Max number of items contained in the board.</param>
        public Board(int r, int c, string textMap, int maxItems)
        {
            ROWS = r;
            COLS = c;

            map = new char[r, c];

            string[] rows = textMap.Split(' ');

            for(int i = 0; i < r; i++)
            {
                char[] column = rows[i].ToCharArray();
                for(int j = 0; j < c; j++)
                {
                    map[i,j] = column[j];
                }
            }

            itemsInBoard = new Item[maxItems];

            for(int a = 0; a < map.GetLength(0); a++)
            {
                for(int b = 0; b < map.GetLength(1); b++)
                {
                    if(map[a,b] == 'i')
                    {
                        int value = new Random().Next(1, 5);
                        AddItem(a,b, value);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if there is a wall in a position. If the position is out of bounds it returns the same 
        /// result as if a wall was there.
        /// </summary>
        /// <returns>True if there  is a wall in position (r,c); false, otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool IsWallAt(int r, int c) => !(r > ROWS || c > COLS || map[r,c] == 'w');

        /// <summary>
        /// Checks if there is an item in a position. If the position is out of bounds it returns false
        /// </summary>
        /// <returns><c>true</c> if there  is an item in position (r,c); <c>false</c> otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool ContainsItem(int r, int c) => !(r > ROWS || c > COLS || map[r, c] != 'i');

        /// <summary>
        /// Adds an item with a value in a position The position must be inside board bounds and it must be empty.
        /// The map should be updated with the new edded item.
        /// It throws an exception if the maximum number of items was exceeded.
        /// </summary>
        /// <returns><c>true</c>, if the item was added; <c>false</c> otherwise.</returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <param name="value">Item value</param>
        public bool AddItem(int r, int c, int value)
        {
            if(r > ROWS || c > COLS || map[r,c] != '0') return false;

            if(numItemsInBoard < itemsInBoard.Length)
            {
                itemsInBoard[numItemsInBoard].row = r;
                itemsInBoard[numItemsInBoard].col = c;
                itemsInBoard[numItemsInBoard].value = value;
                numItemsInBoard++;
            }
            else
            {
                throw new Exception("Se ha superado la cantidad máxima de objetos posibles en el tablero de juego");
            }

            return numItemsInBoard < itemsInBoard.Length;

        }


        /// <summary>
        /// Picks an item in a position, if it exists
        /// </summary>
        /// <returns>
        /// The position of the item in the itemsInBoard array, 
        /// or -1 if there is not any item in that position
        /// </returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        public int PickItem(int r, int c)
        {
            int i = 0;
            bool encontrado = false;
            while(i < itemsInBoard.Length && !encontrado)
            {
                encontrado = itemsInBoard[i].row == r && itemsInBoard[i].col == c;
                map[r, c] = '0';
                i++;
            }

            return i - 1;
        }


        /// <summary>
        /// Checks if a position is a goal
        /// </summary>
        /// <returns><c>true</c> if the position is a goal, <c>false</c> otherwise</returns>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        public bool IsGoalAt(int row, int col) => map[row, col] == 'g';

        /// <summary>
        /// Gets the i-th item in the itemsInBoard array. It throws an exception if the item does not exist.
        /// </summary>
        /// <returns>The item</returns>
        /// <param name="i">The index in the itemsInBoard array</param>
        public Item GetItem(int i)
        {
            if(i != -1)
            {
                return itemsInBoard[i];
            }
            else
            {
                throw new Exception("En esa posición no hay un item, espabila chaval");
            }
        }

    }
}
