using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject wallLeftFront;
    public GameObject wallRightFront;
    public GameObject wallLeftBack;
    public GameObject wallRightBack;
    public GameObject floorLeft;
    public GameObject floorRight;
    public GameObject generator;
    public TextMeshProUGUI TextScore;
    private static bool started = false;

    private string scoreFilePath;
    public int totalPassages = 0;
    
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
        scoreFilePath = Application.persistentDataPath + "/highscore.json";
    }

     public void IncrementPassageCount()
    {
        totalPassages++;
        TextScore.text = "" + totalPassages;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // walls
        wallLeftFront.transform.position = new Vector3(wallLeftFront.transform.position.x - 0.044f, wallLeftFront.transform.position.y, wallLeftFront.transform.position.z);
        wallRightFront.transform.position = new Vector3(wallRightFront.transform.position.x - 0.044f, wallRightFront.transform.position.y, wallRightFront.transform.position.z);
        wallRightFront.transform.position = new Vector3(wallRightFront.transform.position.x - 0.044f, wallRightFront.transform.position.y, wallRightFront.transform.position.z);
        wallLeftBack.transform.position = new Vector3(wallLeftBack.transform.position.x - 0.028f, wallLeftBack.transform.position.y, wallLeftBack.transform.position.z);
        wallRightBack.transform.position = new Vector3(wallRightBack.transform.position.x - 0.028f, wallRightBack.transform.position.y, wallRightBack.transform.position.z);

        if (wallLeftFront.transform.position.x < -150) wallLeftFront.transform.position = new Vector3(130f, wallLeftFront.transform.position.y, wallLeftFront.transform.position.z);
        if (wallRightFront.transform.position.x < -150) wallRightFront.transform.position = new Vector3(130f, wallRightFront.transform.position.y, wallRightFront.transform.position.z);
        if (wallLeftBack.transform.position.x < -150) wallLeftBack.transform.position = new Vector3(130f, wallLeftBack.transform.position.y, wallLeftBack.transform.position.z);
        if (wallRightBack.transform.position.x < -150) wallRightBack.transform.position = new Vector3(130f, wallRightBack.transform.position.y, wallRightBack.transform.position.z);

        // floors
        floorLeft.transform.position = new Vector3(floorLeft.transform.position.x -0.15f, floorLeft.transform.position.y, floorLeft.transform.position.z);
        floorRight.transform.position = new Vector3(floorRight.transform.position.x -0.15f, floorRight.transform.position.y, floorRight.transform.position.z);

        if (floorLeft.transform.position.x < -100) floorLeft.transform.position = new Vector3(36f, floorLeft.transform.position.y, floorLeft.transform.position.z);
        if (floorRight.transform.position.x < -100) floorRight.transform.position = new Vector3(36f, floorRight.transform.position.y, floorRight.transform.position.z);

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void KillPlayer()
    {
        Debug.Log("Player has been killed! Changing scene...");
        // Change de scène après un délai ou directement
        SceneManager.LoadScene("Death_screen"); // Remplace "GameOverScene" par le nom de ta scène

    }
    
    public void setHighScore(int score)
    {
        string json = JsonUtility.ToJson(totalPassages);
        System.IO.File.WriteAllText(scoreFilePath, json);
    }

    public int getHighScore()
    {
        if (System.IO.File.Exists(scoreFilePath))
        {
            string json = System.IO.File.ReadAllText(scoreFilePath);
            int highScore = JsonUtility.FromJson<int>(json);
            return highScore;
        }
        return 0;
    }
    
}
