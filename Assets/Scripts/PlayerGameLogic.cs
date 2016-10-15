using UnityEngine;
using System.Collections;

public class PlayerGameLogic : MonoBehaviour {

    public int startingHp = 5;
    private int hp;
    private int lights = 0;
    private int gun = 0;
    private int score = 0;

    private bool gameOver = false;

    public GameObject gun1;
    public GameObject gun2;
    public Light headLight;
    public Light pointLight;

    // Use this for initialization
    void Start () {
        hp = startingHp;
	}

    public void reset ()
    {
        hp = startingHp;
        lights = gun = score = 0;
        gameOver = false;
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void incHp()
    {
        hp++;
    }

    public void decHp()
    {
        hp--;
        if (hp <= 0)
            gameOver = true;
    }


    public void incLights()
    {
        lights++;
        UpdateLightLevel();
    }

    public void decLights()
    {
        if (lights > 0)
        {
            lights--;
            UpdateLightLevel();
        }
    }

    private void UpdateLightLevel ()
    {
        if (lights == 0)
        {
            headLight.range = 4;
            headLight.color = new Color(1.0f, 1.0f, 1.0f);
            headLight.intensity = 4;
            pointLight.range = 3;
            pointLight.color = new Color(1.0f, 1.0f, 1.0f);
            pointLight.intensity = 1;
        }
        else if (lights == 1)
        {
            headLight.range = 7;
            headLight.color = new Color(1.0f, 0, 0);
            headLight.intensity = 7;
            pointLight.range = 5;
            pointLight.color = new Color(1.0f, 0, 0);
            pointLight.intensity = 3;
        }
        else if (lights == 2)
        {
            headLight.range = 10;
            headLight.color = new Color(0, 0, 1.0f);
            headLight.intensity = 10;
            pointLight.range = 7;
            pointLight.color = new Color(0, 0, 1.0f);
            pointLight.intensity = 5;
        }
        else if (lights == 3)
        {
            headLight.range = 15;
            headLight.color = new Color(0, 1.0f, 0);
            headLight.intensity = 13;
            pointLight.range = 10;
            pointLight.color = new Color(0, 1.0f, 0);
            pointLight.intensity = 8;
        }
    }


    public void incGun()
    {
        gun++;
    }

    public void decGun()
    {
        if (gun > 0)
            gun--;
    }

    public GameObject retGun ()
    {
        if (gun >= 1)
        {
            return gun2;
        }
        else
            return gun1;
    }

    public int getHp()
    {
        return hp;
    }

    public int getLights()
    {
        return lights;
    }

    public int getGun()
    {
        return gun;
    }

    public void incScore()
    {
        score++;
    }

    public int getScore()
    {
        return score;
    }
}
