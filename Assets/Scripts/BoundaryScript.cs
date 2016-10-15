/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

    void OnTriggerExit(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
