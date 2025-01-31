using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class death_screen : MonoBehaviour
{   

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        // cahnge scene after 5 seconds
        StartCoroutine(ChangeScene());
        StartCoroutine(fadeText());
        text.text = "You died!";
        // set trasnparency of text to 1
        Color c = text.color;
        c.a = 0;
        text.color = c;

    
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    // function for decrease tansparency of text
    private IEnumerator fadeText()
    {
        for (float f = 0.05f; f <= 1; f += 0.04f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
