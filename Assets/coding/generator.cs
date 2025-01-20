using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{   
    public GameObject pipePrefab; // Le prefab des pipes
    public float spawnMinTime = 1.5f; // Temps minimum entre les spawns
    public float spawnMaxTime = 5f; // Temps maximum entre les spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    private System.Collections.IEnumerator SpawnPipes()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnMinTime, spawnMaxTime);
            yield return new WaitForSeconds(waitTime);

            // Spawner le pipe à la position du spawnPoint
            float randomY = Random.Range(-10f, 5f);
            GameObject newPipe =  Instantiate(pipePrefab, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
