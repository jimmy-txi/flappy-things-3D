using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public GameObject wallLeftFront;
    public GameObject wallRightFront;
    public GameObject wallLeftBack;
    public GameObject wallRightBack;
    public GameObject generator;
    public TextMeshProUGUI TextScore;
    private static bool started = false;
    
     public static GameManager Instance; // Singleton pour accès global
    private int totalPassages = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Empêche les duplications
        }
    }

    // Supprime un pipe détecté
    public void RemovePipe(GameObject pipe)
    {
        Debug.Log($"Pipe supprimé : {pipe.name}");
        Destroy(pipe); // Supprime l'objet pipe
    }


    // Start is called before the first frame update
    void Start()
    {
        generator.SetActive(true);
        started = true;
        TextScore.text = "0";
    }

     public void IncrementPassageCount()
    {
        totalPassages++;
        TextScore.text = "" + totalPassages;
    }

    // Update is called once per frame
    void Update()
    {
        
        wallLeftFront.transform.position = new Vector3(wallLeftFront.transform.position.x - 0.022f, wallLeftFront.transform.position.y, wallLeftFront.transform.position.z);
        wallRightFront.transform.position = new Vector3(wallRightFront.transform.position.x - 0.022f, wallRightFront.transform.position.y, wallRightFront.transform.position.z);
        wallLeftBack.transform.position = new Vector3(wallLeftBack.transform.position.x - 0.014f, wallLeftBack.transform.position.y, wallLeftBack.transform.position.z);
        wallRightBack.transform.position = new Vector3(wallRightBack.transform.position.x - 0.014f, wallRightBack.transform.position.y, wallRightBack.transform.position.z);

        if (wallLeftFront.transform.position.x < -150) wallLeftFront.transform.position = new Vector3(130f, wallLeftFront.transform.position.y, wallLeftFront.transform.position.z);
        if (wallRightFront.transform.position.x < -150) wallRightFront.transform.position = new Vector3(130f, wallRightFront.transform.position.y, wallRightFront.transform.position.z);
        if (wallLeftBack.transform.position.x < -150) wallLeftBack.transform.position = new Vector3(130f, wallLeftBack.transform.position.y, wallLeftBack.transform.position.z);
        if (wallRightBack.transform.position.x < -150) wallRightBack.transform.position = new Vector3(130f, wallRightBack.transform.position.y, wallRightBack.transform.position.z);

    }
    public void KillPlayer()
    {
        Debug.Log("Player has been killed! Changing scene...");
        // Change de scène après un délai ou directement
        SceneManager.LoadScene("Death_screen"); // Remplace "GameOverScene" par le nom de ta scène
    }
    
    
}
