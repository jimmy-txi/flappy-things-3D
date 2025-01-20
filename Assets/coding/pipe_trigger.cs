using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_trigger : MonoBehaviour
{
    public int passageCount = 0; // Compteur pour le nombre de passages

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncrementPassageCount();
            Debug.Log("Le joueur est passé dans le tuyau !");
        }
    }
}
