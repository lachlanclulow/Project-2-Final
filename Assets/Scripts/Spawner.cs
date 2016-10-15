/* Author: Lachlan Clulow
 * Student Number: 695896
 * Login: lclulow
 * Date: 16/10/26
 */

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float startSpawnRate = 3f;
    public float minSpawnRate = 0.5f;
    private float counter = 0;
    public GameObject prefab;
    private float width = 7;
    public bool IncreaseRateOverTime = false;
    [Range(0.1f, 1)]
    public float IncreaseRate = 1;
		
	// Update is called once per frame
	void Update () {
        if (!IncreaseRateOverTime)
            IncreaseRate = 1;

		if (counter >= startSpawnRate)
        {
            float offset = Random.Range(-width, width);
            Instantiate(prefab, transform.position + new Vector3(offset, 0, 0), transform.rotation);
            counter = 0.0f;

            if (startSpawnRate > minSpawnRate) {
                startSpawnRate *= IncreaseRate;
            }
        }
        else
            counter += Time.deltaTime;
	}
}
