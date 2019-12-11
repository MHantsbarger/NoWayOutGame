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
    private Count trapCount = new Count(10, 15);
    private Count treeCount = new Count(2, 3);
    public GameObject home;
    public GameObject fogTile;
    public GameObject trapTile;
    public GameObject treeTile;
    public GameObject flowerTile;

    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>(); //A list of possible locations to place tiles.
    private HashSet<int> roadToHome = new HashSet<int>();


    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = 0; x < cols; x++)
        {
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

    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList(Vector3 homePosition)
    {
        gridPositions.Clear();
        roadToHome.Clear();
        
        float homeX = homePosition.x;
        float homeY = homePosition.y;

        int midX = Random.Range(0, (int)homePosition.x + 1);
        int midY = Random.Range(0, (int)homePosition.y + 1);

        int roadDirection = Random.Range(0, 2); // 0 -> up, 1 -> right
        if (roadDirection == 0)
        {
            int startX = Random.Range(0, 3);
            for (int i = 0; i < midY; i++)
            {
                int gridID = 10 * i + startX;
                roadToHome.Add(gridID);
            }

            for (int i = startX; i < midX; i++)
            {
                int gridID = 10 * midY + i;
                roadToHome.Add(gridID);
            }

            for (int i = midY; i < homeY; i++)
            {
                int gridID = 10 * i + midX;
                roadToHome.Add(gridID);
            }

            for (int i = midX; i < homeX; i++)
            {
                int gridID = 10 * (int)homeY + i;
                roadToHome.Add(gridID);
            }
        } 
        else
        {
            int startY = Random.Range(0, 2);
            for (int i = 0; i < midX; i++)
            {
                int gridID = 10 * startY + i;
                roadToHome.Add(gridID);
            }

            for (int i = startY; i < midY; i++)
            {
                int gridID = 10 * i + midX;
                roadToHome.Add(gridID);
            }

            for (int i = midX; i < homeX; i++)
            {
                int gridID = 10 * midY + i;
                roadToHome.Add(gridID);
            }

            for (int i = midY; i < homeY; i++)
            {
                int gridID = 10 * i + (int)homeX;
                roadToHome.Add(gridID);
            }
        }
        roadToHome.Add((int)homeY * 10 + (int)homeX);

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (x >= 0 && x <= 2 && y >= 0 && y <= 1)
                {
                    continue;
                }
                int gridID = 10 * y + x;
                if (roadToHome.Contains(gridID))
                {
                    continue;
                }
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    Vector3 RandomHomePosition()
    {
        int posX = Random.Range(6, 10);
        int posY = Random.Range(6, 10);
        Vector3 randomPosition = new Vector3((float) posX, (float) posY);

        return randomPosition;
    }

    //此函数返回一个随机的位置，用于放置trees
    Vector3 RandomTreePosition()
    {

        int posX = Random.Range(1, 9);
        int posY = Random.Range(1, 9);
        int posID = 10 * posY + posX;

        while ((posX <= 3 && posY <= 2) || 
            roadToHome.Contains(posID) || roadToHome.Contains(posID + 1) || 
            roadToHome.Contains(posID - 1) || roadToHome.Contains(posID + 10) ||
            roadToHome.Contains(posID - 10))
        {
            posX = Random.Range(1, 9);
            posY = Random.Range(1, 9);
            posID = 10 * posY + posX;
        }

        int treeIndex = 0;

        Vector3 randomPosition = new Vector3(posX, posY, 0);

        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == posX && (int)gridPositions[i].y == posY)
            {
                treeIndex = i;
            }

        }
        gridPositions.RemoveAt(treeIndex);


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

            GameObject tileChoice = tile;

            Instantiate(tileChoice, randomPosition, Quaternion.identity);

            LayoutFlowers(randomPosition);

        }
    }

    void LayoutFlowers(Vector3 treePosition)
    {
        float posX = treePosition.x;
        float posY = treePosition.y;

        Vector3 f1 = new Vector3(posX - 1, posY, 0);
        int f1Index = -1;

        Vector3 f2 = new Vector3(posX + 1, posY, 0);
        int f2Index = -1;

        Vector3 f3 = new Vector3(posX, posY - 1, 0);
        int f3Index = -1;

        Vector3 f4 = new Vector3(posX, posY + 1, 0);
        int f4Index = -1;

        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == (int)f1.x && (int)gridPositions[i].y == (int)f1.y)
            {
                f1Index = i;
                GameObject flower = flowerTile;
                Instantiate(flower, f1, Quaternion.identity);
                break;
            }
        }
        if (f1Index != -1)
        {
            gridPositions.RemoveAt(f1Index);
        }

        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == (int)f2.x && (int)gridPositions[i].y == (int)f2.y)
            {
                f2Index = i;
                GameObject flower = flowerTile;
                Instantiate(flower, f2, Quaternion.identity);
                break;
            }
        }
        if (f2Index != -1)
        {
            gridPositions.RemoveAt(f2Index);
        }

        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == (int)f3.x && (int)gridPositions[i].y == (int)f3.y)
            {
                f3Index = i;
                GameObject flower = flowerTile;
                Instantiate(flower, f3, Quaternion.identity);
                break;
            }
        }
        if (f3Index != -1)
        {
            gridPositions.RemoveAt(f3Index);
        }

        for (int i = 0; i < gridPositions.Count; i++)
        {
            if ((int)gridPositions[i].x == (int)f4.x && (int)gridPositions[i].y == (int)f4.y)
            {
                f4Index = i;
                GameObject flower = flowerTile;
                Instantiate(flower, f4, Quaternion.identity);
                break;
            }
        }
        if (f4Index != -1)
        {
            gridPositions.RemoveAt(f4Index);
        }

    }

    void LayoutTrapsAtRandom(GameObject tile, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);


        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomTrapPosition();

            GameObject tileChoice = tile;

            Instantiate(tileChoice, randomPosition, Quaternion.identity);

        }
    }


    //SetupScene用于初始化关卡，并调用上面的函数来布置items的位置
    public void SetupScene()
    {
        //Creates the outer walls and floor.
        BoardSetup();

        SetupLayoutObjects();

    }

    private void SetupLayoutObjects()
    {
        Vector3 homePosition = RandomHomePosition();
        Instantiate(home, homePosition, Quaternion.identity);

        InitialiseList(homePosition);
        if (MenuNavigation.levelDifficulty == "Easy") {
            Debug.Log("Easy Difficulty Confirmed");
            trapCount = new Count(7, 9);
            treeCount = new Count(2, 3);
        }
        else if (MenuNavigation.levelDifficulty == "Hard") {
            Debug.Log("Hard Difficulty Confirmed");
            trapCount = new Count(20, 25);
            treeCount = new Count(5, 6);
        }
        else {
            Debug.Log("Normal Difficulty Confirmed");
            trapCount = new Count(10, 15);
            treeCount = new Count(2, 3);
        }
        LayoutTreesAtRandom(treeTile, treeCount.min, treeCount.max);

        LayoutTrapsAtRandom(trapTile, trapCount.min, trapCount.max);

    }



}
