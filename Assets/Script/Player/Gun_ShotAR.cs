using UnityEngine;

public class Gun_ShotAR : MonoBehaviour
{
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Transform ShootingPosition;
    private void BulletDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        bool IsShotting = Physics.Raycast(ray, out Hit, 100f);
        if (IsShotting)
            Debug.DrawRay(ray.origin, ray.direction * Hit.distance, Color.red);
    }    
}
