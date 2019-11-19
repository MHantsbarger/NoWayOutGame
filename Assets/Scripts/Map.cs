using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const int BoardWidth = 10;
    private const int BoardHeight = 10;

    private string[,] forestMap = new string[BoardWidth,BoardHeight];
    private string[,] fogGrid = new string[BoardWidth,BoardHeight];
    private int[] playerLocation = { 1,9 };
    private int[] ghostLocation = { -1,-1 };
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < BoardWidth; i++) {
            for (int j = 0; j < BoardHeight; j++) {
                forestMap[i,j] = "Empty";
                fogGrid[i,j] = "Fog";
                // Debug.Log("location "+ i + "," + j + " cleared");
        }
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
