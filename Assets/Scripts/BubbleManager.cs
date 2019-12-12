using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{

    public static BubbleManager instance = null;
    public Image trap;
    public Image flower;
    private float initialPosition = -33f;

    [HideInInspector] public int flowerAmount = 0;
    [HideInInspector] public int trapAmount = 0;
    private Image temp;
    private Image bubble;
    private int tempCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bubble = GameObject.Find("Bubble").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble.enabled)
        {
            for (int i = 0; i < trapAmount; i++)
            {
                temp = Instantiate(trap);
                temp.GetComponent<Transform>().SetParent(GameObject.Find("Bubble").GetComponent<Transform>(), true);
                temp.transform.position = GameObject.Find("Bubble").GetComponent<Transform>().position +
                    new Vector3(initialPosition, 25, 0);
                initialPosition += 35;
            }
            trapAmount = 0;

            for (int i = 0; i < flowerAmount; i++)
            {
                temp = Instantiate(flower);
                temp.GetComponent<Transform>().SetParent(GameObject.Find("Bubble").GetComponent<Transform>(), true);
                temp.transform.position = GameObject.Find("Bubble").GetComponent<Transform>().position +
                    new Vector3(initialPosition, 25, 0);
                initialPosition += 35;
            }
            flowerAmount = 0;
        }
        else
        {
            initialPosition = -33f;
            List<GameObject> trapIcon = iconList("Sinkhole(Clone)"); 
            foreach (GameObject go in trapIcon)
            {
                Destroy(go);
                Debug.Log(1);
            }

            List<GameObject> flowerIcon = iconList("CannibalFlowerImage(Clone)");

            foreach (GameObject go in flowerIcon)
            {
                Destroy(go);
                Debug.Log(2);
            }

            //Destroy(temp);
        }



    }

    private List<GameObject> iconList(string iconName)
    {
        List<GameObject> obj = new List<GameObject>();
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
        {

            if (go.name.Equals(iconName))
            {
                obj.Add(go);
            }
        }
        return obj;
    }
}
