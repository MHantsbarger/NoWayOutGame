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

    public Text[] options;
    // public Text option1;
    // public Text option2;
    // public Text option3;

    // private int numberOfOptions = 3;

    private int selectedOption;

    // Use this for initialization
    void Start () {
        selectedOption = 0;
        foreach (Text option in options) {
            option.color = unselectedColor;
        }
        options[0].color = selectedColor;
        // option1.color = selectedColor;
        // option2.color = unselectedColor;
        // option3.color = unselectedColor;

        pointer.transform.position = new Vector3(POINTERXPOS, options[0].transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption >= options.Length) //If at end of list go back to top
            {
                selectedOption = 0;
            }

            foreach (Text option in options) {
                option.color = unselectedColor;
            }
            options[selectedOption].color = selectedColor;
            pointer.transform.position = new Vector3(POINTERXPOS, options[selectedOption].transform.position.y);
            // option1.color = unselectedColor;
            // option2.color = unselectedColor;
            // option3.color = unselectedColor;

            // switch (selectedOption) //Set the visual indicator for which option you are on.
            // {
            //     case 1:
            //         option1.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option1.transform.position.y);
            //         break;
            //     case 2:
            //         option2.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option2.transform.position.y);
            //         break;
            //     case 3:
            //         option3.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option3.transform.position.y);
            //         break;
            // }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 0) //If at end of list go back to top
            {
                selectedOption = options.Length-1;
            }

            foreach (Text option in options) {
                option.color = unselectedColor;
            }
            options[selectedOption].color = selectedColor;
            pointer.transform.position = new Vector3(POINTERXPOS, options[selectedOption].transform.position.y);

            // option1.color = unselectedColor;
            // option2.color = unselectedColor;
            // option3.color = unselectedColor;

            // switch (selectedOption) //Set the visual indicator for which option you are on.
            // {
            //     case 1:
            //         option1.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option1.transform.position.y);
            //         break;
            //     case 2:
            //         option2.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option2.transform.position.y);
            //         break;
            //     case 3:
            //         option3.color = selectedColor;
            //         pointer.transform.position = new Vector3(POINTERXPOS, option3.transform.position.y);
            //         break;
            // }
        }

        if (Input.GetKeyDown(KeyCode.Space) ||  Input.GetKeyDown("joystick button 0")){
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.
            if (options[selectedOption].tag == "StartOption") {
                sceneLoader.SceneLoader(6);
            }
            else if (options[selectedOption].tag == "MainMenuOption") {
                sceneLoader.SceneLoader(0);
            }
            else if (options[selectedOption].tag == "PlayerMvmtOption") {
                sceneLoader.SceneLoader(1);
            }
            else if (options[selectedOption].tag == "HomeGoalOption") {
                sceneLoader.SceneLoader(2);
            }
            else if (options[selectedOption].tag == "AvoidHazardsOption") {
                sceneLoader.SceneLoader(3);
            }
            else if (options[selectedOption].tag == "HazardsNearOption") {
                sceneLoader.SceneLoader(4);
            }
            else if (options[selectedOption].tag == "CandleOption") {
                sceneLoader.SceneLoader(5);
            }
            else if (options[selectedOption].tag == "QuitOption") {
                sceneLoader.doExitGame();
            }
            // switch (selectedOption) //Set the visual indicator for which option you are on.
            // {
            //     case 0:
            //         sceneLoader.SceneLoader(5);
            //         break;
            //     case 1:
            //         sceneLoader.SceneLoader(1);
            //         break;
            //     case 2:
            //         sceneLoader.doExitGame();
            //         break;
            // }
        }
    }
}
