using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{   
    public float spawnMinTime = 4f; // Temps minimum entre les spawns
    public float spawnMaxTime = 6f; // Temps maximum entre les spawns

    public List<GameObject> pipesmeshtypelist = new List<GameObject>();

    private GameObject selectedPipeMeshType;

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
            
            selectedPipeMeshType = pipesmeshtypelist[Random.Range(0, pipesmeshtypelist.Count)];

            // Spawner le pipe à la position du spawnPoint
            float randomY = Random.Range(-10f, 5f);
            GameObject newPipe =  Instantiate(selectedPipeMeshType, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
