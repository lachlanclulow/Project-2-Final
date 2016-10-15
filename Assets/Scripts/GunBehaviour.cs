/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour {

    public float fireRate;

    void onTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
