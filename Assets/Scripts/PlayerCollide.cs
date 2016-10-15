/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

    public PlayerGameLogic logicObj;

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.name == "AsteroidModel(Clone)")
        {
            logicObj.decHp();
            logicObj.decLights();
            logicObj.decGun();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.name == "LightPowerUp(Clone)")
        {
            logicObj.incLights();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.name == "HealthPowerUp(Clone)")
        {
            logicObj.incHp();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.name == "GunPowerUp(Clone)")
        {
            logicObj.incGun();
            Destroy(coll.gameObject);
        }
    }
}
