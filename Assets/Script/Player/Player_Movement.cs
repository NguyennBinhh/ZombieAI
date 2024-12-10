using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private FixedJoystick Joystick;
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private Player_Animation PlayerAnimation;
    [SerializeField] private ButtonClick ButtonClick;
    [SerializeField] private Player_ShotGunAR _PlayerShotGunAR;
    [SerializeField] private AudioManager _AudioManager;
    private bool CheckMove;

    void Update()
    {
        MoveManagement();
        PlayerAnimation.ChangeState(ButtonClick.IsHoldingGun);
        
    }

    private void MoveManagement()
    {

        if(ButtonClick.IsHoldingGun)
        {
            Movement(3.5f);
            PlayerAnimation.IdleToRunHoldingGun(CheckMove);
            
        }
        else
        {
            Movement(5f);
            PlayerAnimation.IdleToRun(CheckMove);
            
        }    
    }   
    
    private void Movement(float MoveSpeed)
    {
        Vector3 moveDirection = new Vector3(Joystick.Horizontal, 0f, Joystick.Vertical);

        if (moveDirection.magnitude >= 0.1f && !_PlayerShotGunAR.IsShotting)
        {
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();
            Vector3 desiredMoveDirection = forward * moveDirection.z + right * moveDirection.x;
            transform.rotation = Quaternion.LookRotation(desiredMoveDirection);
            CharacterController.Move(desiredMoveDirection * MoveSpeed * Time.deltaTime);
            CheckMove = true;
        }
        else if(moveDirection.magnitude >= 0.1f && _PlayerShotGunAR.IsShotting)
        {
            Vector3 Vt3_Move = transform.right * Joystick.Horizontal + transform.forward * Joystick.Vertical;
            CharacterController.Move(Vt3_Move * 2f * Time.deltaTime);
            
        }
        else
            CheckMove = false;
        PlayerAnimation.WalkVercial(Joystick.Vertical);
        PlayerAnimation.WalkHorizontal(Joystick.Horizontal);
    }
    private int DurationWalkShot()
    {
        int Duration = 0;
        if (Joystick.Vertical > 0.5 && Joystick.Horizontal < 0.5)
            Duration = 1;
        else if (Joystick.Vertical < 0.5 && Joystick.Horizontal < 0.5)
            Duration = 2;
        return Duration;
    }    

}
