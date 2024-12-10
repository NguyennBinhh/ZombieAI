
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDame : MonoBehaviour
{
    private HeathBar HeathPlayer;
    private GameObject Player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player = GameObject.FindWithTag("Player");
            if (Player != null)
            {
                HeathPlayer = Player.GetComponent<HeathBar>();
                HeathPlayer.TakeDame(Random.Range(20, 30));
               
            }
        }
    }
}
