using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death_screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // cahnge scene after 5 seconds
        StartCoroutine(ChangeScene());
    
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
