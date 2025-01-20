using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject pipeTop;
    public GameObject pipeBottom;

    void Start()
    {
        // Vérifie que les objets ont des colliders
        if (!pipeTop.GetComponent<Collider>())
        {
            Debug.LogError("pipeTop needs a Collider!");
        }

        if (!pipeBottom.GetComponent<Collider>())
        {
            Debug.LogError("pipeBottom needs a Collider!");
        }

        // Ajoute des tags si nécessaires
        pipeTop.tag = "PipeTop";
        pipeBottom.tag = "PipeBottom";
    }

    void Update()
    {
        // Déplacement des pipes
        transform.position += Vector3.left * 0.022f;
    }
}
