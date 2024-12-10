using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook CineCamera;
    [SerializeField] private FixedTouchField _FixedTouchField;
    [SerializeField] private FixedTouchField _FixedTouchFieldBtnShot;
    [SerializeField] private Player_ShotGunAR _PlayerShotGunAR;
    [Header("Camera sensitivity")]
    [SerializeField] private float CamX;
    [SerializeField] private float CamY;
    
    private void Update()
    {
        CineCamera.m_XAxis.Value += _FixedTouchField.TouchDist.x * 0.5f * CamX * Time.deltaTime;
        CineCamera.m_YAxis.Value += _FixedTouchField.TouchDist.y * 0.3f * CamY * Time.deltaTime;
        if(_PlayerShotGunAR.IsShotting)
        {
            CineCamera.m_XAxis.Value += _FixedTouchFieldBtnShot.TouchDist.x * 5f * Time.deltaTime;
            CineCamera.m_YAxis.Value += _FixedTouchFieldBtnShot.TouchDist.y * -0.1f * Time.deltaTime;
            
        }    
    }
}
