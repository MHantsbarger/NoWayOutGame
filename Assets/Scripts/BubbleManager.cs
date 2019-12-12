using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    [HideInInspector] public int trapAmount = 3;
    [HideInInspector] public int flowerAmount = 0;
    private List<Image> prompts = new List<Image>();
    private Image bubble;
    public Image Trap;
    public Image Flower;

    private Vector3 initialPos1 = new Vector3(100, 175, 0);
    private Vector3 initialPos2 = new Vector3(75, 175, 0);
    private Vector3 initialPos3 = new Vector3(50, 175, 0);


    //private float amount = 0;
    //private float currentAmount = 0;

    void Start()
    {
        bubble = GameObject.Find("Bubble").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < trapAmount; i++)
        {
            Image tempTrap = (Image)Instantiate(Trap);
            tempTrap.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), true);
            tempTrap.transform.position = initialPos3 + new Vector3(50, 0, 0);
            //prompts.Add(tempTrap);
        }
    }
}
