
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent;
    private GameObject PlayerPosition;
    [SerializeField] private Animator _Animator;
    [SerializeField] private EnemyCollision _EnemyCollision;
    [SerializeField] private GameObject AttackRange;
    private AudioManager _AudioManager;

    private bool CheckCollision;
    private bool AllowedToMove;


    private void Start()
    {
        AllowedToMove = true;
        PlayerPosition = GameObject.FindWithTag("Player");
        _AudioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        CheckCollision = _EnemyCollision.CheckCollision;
        if (PlayerPosition != null && AllowedToMove)
        {
            Agent.SetDestination(PlayerPosition.transform.position);
        }
        float Speed = Agent.velocity.magnitude;
        _Animator.SetFloat("Move", Speed);
        Attacks();
    
    }
    private bool IsAttack = false;
    private void Attacks()
    {
        if (CheckCollision)
        {
            InvokeRepeating("PlayerDetecsion", 0f, 4f);
            CancelInvoke("ExitAtk");
            if (!IsAttack && _AudioManager != null)
            {
                _AudioManager.PlaySFX(_AudioManager.MonsterGrowlClip);
                IsAttack = true;
            }
        }
        else
        {
            Invoke("ExitAtk", 4f);
            CancelInvoke("PlayerDetecsion");
            IsAttack = false;
        }
    }

    private void PlayerDetecsion()
    {
        AttackRange.SetActive(true);
        _Animator.SetBool("Attack", true);
        AllowedToMove = false;
        
    }  
    
    private void ExitAtk()
    {
        AttackRange.SetActive(false);
        _Animator.SetBool("Attack", false);
        AllowedToMove = true;
    }    

    


}
