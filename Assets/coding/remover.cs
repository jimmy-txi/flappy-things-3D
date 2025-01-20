using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRemover : MonoBehaviour
{
    public GameManager gameManager; // Référence publique au GameManager

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Objet supprimé : {other.name}");
        Destroy(other.gameObject); // Supprime tout objet qui entre dans le trigger
    }
}