/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{

    public GameObject spawners;
    public PlayerGameLogic logicScript;
    private bool play = false;

    void Awake()
    {
        initScreen();
        spawners.SetActive(false);
        play = false;
    }

    void OnGUI()
    {
        if (!play)
        {
            // Make a background box
            GUI.Label(
                new Rect(
                    (Screen.width) / 4, 
                    (Screen.height) / 4, 
                    (Screen.width) / 2, 
                    (Screen.height) / 2 + 100
                    ),
                "Survive as long as you can, " + 
                "but be careful of asteroids, they can be hard to see. " + '\n' + '\n' +
                "Collect Power Ups to survive longer: " + '\n' +
                "Green: HP+" + '\n' +
                "Orange: Enhanced Lighting" + '\n' +
                "Blue: Enhanced Weapons" + '\n' + '\n' + 
                "Controls:" + '\n' +
                "WASD, Arrow Keys or tilt device to move ship." + '\n' +
                "Spacebar or Tap screen to shoot."
                );

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height - 40, 80, 20), 
                "Play"))
            {
                spawners.SetActive(true);
                GUI.enabled = false;
                play = true;
            }
        }
        else if (logicScript.isGameOver())
        {
            spawners.SetActive(false);

            GUI.Label(
                new Rect((Screen.width) / 4, (Screen.height) / 4, (Screen.width) / 2, (Screen.height) / 2 + 100), 
                "GAME OVER");

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height - 40, 80, 20), "Play Again?"))
            {
                spawners.SetActive(true);
                GUI.enabled = false;
                play = true;
                logicScript.reset();
            }
        }
        else
        {
            GUI.Label(new Rect(10, Screen.height - 40, 80, 40), "Health: " + logicScript.getHp());
            GUI.Label(new Rect(Screen.width / 2 - 40, Screen.height - 40, 80, 40), "Light Level: " + 
                logicScript.getLights());
            GUI.Label(new Rect(Screen.width - 90, Screen.height - 40, 80, 40), "Weapons Level: " + 
                logicScript.getGun());
            GUI.Label(new Rect(Screen.width / 2 - 40, 10, 80, 40), "Score: " + logicScript.getScore());

        }

        if (GUI.Button(new Rect(Screen.width - 110, 50, 80, 40), "Exit") || 
            Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void initScreen()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.SetResolution(720, 1280, true);
    }
}


