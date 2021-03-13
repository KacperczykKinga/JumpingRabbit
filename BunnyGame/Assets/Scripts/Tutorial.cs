using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public Text tutorialText, pressText;
    public GameObject goToTheHoleText;
    private bool right = false;
    private bool left = false;
    private bool jump = false;
    public static bool doubleJump = false;
    

   
    // Start is called before the first frame update
    void Start()
    {

        goToTheHoleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!right && !left && !jump && !doubleJump)
        {
            tutorialText.text = "Go right";
            pressText.text = "(press right arrow)";
            if(Input.GetKeyDown(KeyCode.RightArrow))
            right = true;
   
        }
        if (right && !left && !jump && !doubleJump)
        {
            tutorialText.text = "Go left";
            pressText.text = "(press left arrow)";
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            left = true;
        }
        if (right && left && !jump && !doubleJump)
        {
            tutorialText.text = "Jump";
            pressText.text = "(press up arrow)";
            if(Input.GetKeyDown(KeyCode.UpArrow))
            jump = true;
        }
        if (right && left && jump && !doubleJump)
        {
            tutorialText.text = "Jump double";
            pressText.text = "(press up arrow twice)";
            if(Input.GetKeyDown(KeyCode.UpArrow) && !Player.grounded)
            doubleJump = true;
        }
        if (right && left && jump && doubleJump)
        {
            tutorialText.text = "";
            pressText.text = "";
            goToTheHoleText.SetActive(true);
        }
    }
}
