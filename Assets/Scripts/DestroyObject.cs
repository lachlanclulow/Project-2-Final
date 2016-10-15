/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public PlayerGameLogic logicScript;

    void Start ()
    {
        logicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGameLogic>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Boundary" || 
            coll.gameObject.name == "Player" ||
            coll.gameObject.name == gameObject.name ||
            coll.gameObject.name == "HealthPowerUp(Clone)" ||
            coll.gameObject.name == "LightPowerUp(Clone)" ||
            coll.gameObject.name == "GunPowerUp(Clone)")
        {
            return;
        }
        logicScript.incScore();
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }

}
