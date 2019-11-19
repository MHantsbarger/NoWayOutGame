using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // need specify, because Random is contained in both System and UnityEngine

public class BoardManager : MonoBehaviour
{

    [Serializable]
    public class Count
    {
        public int min;
        public int max;

        public Count(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public int cols = 10;
    public int rows = 10;
    public Count trapCount = new Count(4, 8);
    public Count treeCount = new Count(1, 2);
    public GameObject home;

    public GameObject fogTile;
    public GameObject trapTile;
    public GameObject treeTile;

    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>(); //A list of possible locations to place tiles.

    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();

        //Loop through x axis (columns).
        for (int x = 0; x < cols; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 0; y < rows; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                if (x >= 0 && x <= 2 && y >= 0 && y <= 1)
                {
                    continue;
                }
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < cols; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < rows; y++)
            {

                if (x <= 2 && y <= 1)
                {
                    continue;
                }

                GameObject toInstantiate = fogTile;

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);

                instance.transform.SetParent(boardHolder);

            }
        }
    }

    //此函数返回一个随机的位置，用于放置trees
    Vector3 RandomTreePosition()
    {

        int posX = Random.Range(1, 9);
        int posY = Random.Range(1, 9);

        while (posX <= 3 && posY <= 2)
        {
            posY = Random.Range(3, 9);
        }

        int treeIndex = 0;

        Vector3 randomPosition = new Vector3(posX, posY, 0);

        Vector3 f1 = new Vector3(posX - 1, posY, 0);
        int f1Index = 0;

        Vector3 f2 = new Vector3(posX + 1, posY, 0);
        int f2Index = 0;

        Vector3 f3 = new Vector3(posX, posY - 1, 0);
        int f3Index = 0;

        Vector3 f4 = new Vector3(posX, posY + 1, 0);
        int f4Index = 0;


        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == posX && (int)gridPositions[i].y == posY)
            {
                treeIndex = i;
            }
            else if((int)gridPositions[i].x == (int)f1.x && (int)gridPositions[i].y == (int)f1.y)
            {
                f1Index = i;
            }
            else if ((int)gridPositions[i].x == (int)f2.x && (int)gridPositions[i].y == (int)f2.y)
            {
                f2Index = i;
            }
            else if ((int)gridPositions[i].x == (int)f3.x && (int)gridPositions[i].y == (int)f3.y)
            {
                f3Index = i;
            }
            else if ((int)gridPositions[i].x == (int)f4.x && (int)gridPositions[i].y == (int)f4.y)
            {
                f4Index = i;
            }


        }

        gridPositions.RemoveAt(treeIndex); 
        gridPositions.RemoveAt(f1Index);
        gridPositions.RemoveAt(f2Index);
        gridPositions.RemoveAt(f3Index);
        gridPositions.RemoveAt(f4Index);


        //Return the randomly selected Vector3 position.
        return randomPosition;
    }

    //此函数返回一个随机的位置，用于放置traps
    Vector3 RandomTrapPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }


    void LayoutTreesAtRandom(GameObject tile, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomTreePosition();

            GameObject tileChoice = treeTile;

            Instantiate(tileChoice, randomPosition, Quaternion.identity);

        }
    }

    void LayoutTrapsAtRandom(GameObject tile, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomTrapPosition();

            GameObject tileChoice = trapTile;

            Instantiate(tileChoice, randomPosition, Quaternion.identity);

        }
    }


    //SetupScene用于初始化关卡，并调用上面的函数来布置items的位置
    public void SetupScene()
    {
        //Creates the outer walls and floor.
        BoardSetup();

        //Reset our list of gridpositions.
        InitialiseList();

        LayoutTreesAtRandom(treeTile, treeCount.min, treeCount.max);

        LayoutTrapsAtRandom(trapTile, trapCount.min, trapCount.max);

        //Instantiate the exit tile in the upper right hand corner of our game board
        Instantiate(home, new Vector3(cols - 1, rows - 1, 0f), Quaternion.identity);
    }


}
