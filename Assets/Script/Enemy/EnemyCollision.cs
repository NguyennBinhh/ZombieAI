using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [HideInInspector] public bool CheckCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            CheckCollision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            CheckCollision = false;
    }
    
}
