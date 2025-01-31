using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject pipeTop;
    public GameObject pipeBottom;
    public float pipeSpeed = 0.022f;
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

    void FixedUpdate()
    {
        // Déplacement des pipes
        transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
        
    }
}
