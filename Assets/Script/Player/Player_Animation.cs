using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnimator;

    public void IdleToRun(bool CheckState)
    {
        PlayerAnimator.SetBool("PL_Move", CheckState);
    }

    public void IdleToRunHoldingGun(bool CheckState)
    {
        PlayerAnimator.SetBool("PL_MoveHoldingGun", CheckState);
    }

    public void ChangeState(bool CheckState)
    {
        PlayerAnimator.SetBool("Check_Gun_State", CheckState);
    }  
    
    public void ShotGunArAuto(bool CheckShotGun)
    {
        PlayerAnimator.SetBool("ShotGunARAuto", CheckShotGun);
    } 
    
    public void Reloading()
    {
        PlayerAnimator.SetTrigger("Reloading");
    }    
    public void WalkVercial(float Duration)
    {
        PlayerAnimator.SetFloat("WalkVercial", Duration);
    }

    public void WalkHorizontal(float Duration)
    {
        PlayerAnimator.SetFloat("WalkHorizontal", Duration);
    }

    public void PlayerDie()
    {
        PlayerAnimator.SetBool("PlayerDie", true);
    }    
}
