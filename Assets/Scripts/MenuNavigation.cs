using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public LoadScene sceneLoader;

    private Color32 selectedColor = new Color32(0, 180, 0, 255);
    private Color32 unselectedColor = new Color32(255, 255, 255, 255);

    public const int POINTERXPOS = 400;
    public Image pointer;

    public Text option1;
    public Text option2;
    public Text option3;

    private int numberOfOptions = 3;

    private int selectedOption;

    // Use this for initialization
    void Start () {
        selectedOption = 1;
        option1.color = selectedColor;
        option2.color = unselectedColor;
        option3.color = unselectedColor;

        pointer.transform.position = new Vector3(POINTERXPOS, option1.transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) //If at end of list go back to top
            {
                selectedOption = 1;
            }

            option1.color = unselectedColor;
            option2.color = unselectedColor;
            option3.color = unselectedColor;

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option1.transform.position.y);
                    break;
                case 2:
                    option2.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option2.transform.position.y);
                    break;
                case 3:
                    option3.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option3.transform.position.y);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = numberOfOptions;
            }

            option1.color = unselectedColor;
            option2.color = unselectedColor;
            option3.color = unselectedColor;

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option1.transform.position.y);
                    break;
                case 2:
                    option2.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option2.transform.position.y);
                    break;
                case 3:
                    option3.color = selectedColor;
                    pointer.transform.position = new Vector3(POINTERXPOS, option3.transform.position.y);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) ||  Input.GetKeyDown("joystick button 0")){
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    sceneLoader.SceneLoader(5);
                    break;
                case 2:
                    sceneLoader.SceneLoader(1);
                    break;
                case 3:
                    sceneLoader.doExitGame();
                    break;
            }
        }
    }
}
