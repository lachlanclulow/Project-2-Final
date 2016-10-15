/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class ObjectMotion : MonoBehaviour {

    public bool directionDown = true;
    private Rigidbody objRigidbody;
    private int direction;
    public float maxSpeed = 3;
    public float minSpeed = 0.2f;
    public static float staticMaxSpeed = 1;
    public float maxRotateSpeed = 40;
    private float speed;
    private float rotateSpeed;
    private Quaternion rotation;
    public bool IncreaseSpeed = false;
    public float speedFactor = 1;

    private float nextSpeed;
    public float delay = 300;

    void Start()
    {
        objRigidbody = GetComponent<Rigidbody>();

        // For PowerUps + projectiles
        if (minSpeed == maxSpeed)
        {
            speed = minSpeed;
            rotateSpeed = 0;
        }
        // For Asteroids
        else
        {
            speed = Random.Range(minSpeed, maxSpeed) * staticMaxSpeed;
            rotateSpeed = Random.Range(-maxRotateSpeed, maxRotateSpeed);
        }

        if (directionDown)
            direction = -1;
        else
            direction = 1;

        objRigidbody.velocity = transform.forward * speed * direction;
        objRigidbody.angularVelocity = new Vector3
            (
            Random.Range(-1, 1),
            Random.Range(-1, 1),
            Random.Range(-1, 1)
            ) * rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (IncreaseSpeed && Time.time > nextSpeed)
        {
            nextSpeed = Time.time + delay;
            staticMaxSpeed *= speedFactor;
        }
    }
}
