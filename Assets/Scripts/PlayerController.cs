/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 * 
 * Boundary Class and Input application from:
 * https://unity3d.com/earn/tutorials/projects/space-shooter/moving-the-player?playlist=17147
 * Author: Unity Devs
 * Date Accessed: 10/10/2016
 * 
 * Update() contents from:
 * https://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147
 * Author: Unity Devs
 * Date Accessed: 10/10/2016
 */

using UnityEngine;
using System.Collections;

//https://unity3d.com/earn/tutorials/projects/space-shooter/moving-the-player?playlist=17147
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private PlayerGameLogic logicScript;
    private Rigidbody playerRigidbody;
    public float tilt;
    public float maxSpeed = 10f;
    public float accelerometerSensitivity;
    public GameObject player;
    public Boundary boundary;
    public Transform Cannon;

    private float nextFire = 0;

	// Use this for initialization
	void Start () {
        logicScript = player.GetComponent<PlayerGameLogic>();
        playerRigidbody = GetComponent<Rigidbody>();
        nextFire = Time.time;
    }

    //https://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147
    void Update ()
    {
        GunBehaviour gun = logicScript.retGun().GetComponent<GunBehaviour>();

        if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && Time.time > nextFire)
        {
            Instantiate(gun, Cannon.position, Cannon.rotation);
            nextFire = Time.time + gun.fireRate;
        }
    }
		
	void FixedUpdate () {
        // Keyboard Input
        Vector3 moveDir = Vector3.zero;
        moveDir.x += Input.GetAxis("Horizontal");
        moveDir.z += Input.GetAxis("Vertical");

        // Accelerometer Input
        moveDir.x += Input.acceleration.x * accelerometerSensitivity;
        moveDir.z += Input.acceleration.y * accelerometerSensitivity;
        if (moveDir.sqrMagnitude > 1)
            moveDir.Normalize();

        // Apply Input
        //https://unity3d.com/earn/tutorials/projects/space-shooter/moving-the-player?playlist=17147
  
        playerRigidbody.velocity = moveDir * maxSpeed;

        playerRigidbody.position = new Vector3
        (
            Mathf.Clamp(playerRigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(playerRigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        playerRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidbody.velocity.x * -tilt);
    }
}
