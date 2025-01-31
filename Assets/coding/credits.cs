using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class credits : MonoBehaviour
{   
    private List<string> creditsList = new List<string>(){
        "Game dev by: ",
        "Jimmy",
        " ",
        "Arts by: ",
        "Jimmy",
        " ",
        "Sound by: ",
        "someone",
        " ",
        "Special thanks to: ",
        "Jimmy"
    };
    public TextMeshProUGUI text;

    // add text to the text and move up him
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowCredits());
        foreach (string credit in creditsList)
        {
            text.text += credit + "\n";
        }
    }

    private void LoadMenu()
    {
        Debug.Log("🔄 Chargement de la scène Menu...");
        SceneManager.LoadScene("Menu");
    }
    private IEnumerator ShowCredits()
    {
        for (float f = 0.05f; f <= 175; f += 0.1f)
        {
            text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + 2f, text.transform.position.z);
            if (text.transform.position.y > 2000)
            {
                Debug.Log("✅ Condition atteinte ! Position actuelle : " + text.transform.position.y);
                Invoke("LoadMenu", 2f);
                yield break;
            }
            yield return new WaitForSeconds(0.025f);
        }
        Invoke("LoadMenu", 2f);
        yield break;
    }
}