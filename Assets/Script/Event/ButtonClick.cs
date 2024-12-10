
using UnityEngine;



public class ButtonClick : MonoBehaviour
{
    [HideInInspector] public bool IsHoldingGun = false;
    [HideInInspector] public bool IsShotGunAR = false;
    [HideInInspector] public bool IsReload = false;

    public void ChangeStateOnClick()
    {
        IsHoldingGun = !IsHoldingGun;
    }  
    
    public void ShotPointerDown()
    {
        IsShotGunAR = true;
    }
    public void ShotPointerUp()
    {
        IsShotGunAR = false;
    }

    public void Reloading()
    {
        IsReload = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }    

    
}
