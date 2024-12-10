
using System.Collections;
using TMPro;
using UnityEngine;

public class Player_ShotGunAR : MonoBehaviour
{
    [SerializeField] private Player_Animation _PlayerAnimation;
    [SerializeField] private ButtonClick _ButtonClick;
    [SerializeField] private ParticleSystem VFXMuzzleFlash;
    [SerializeField] private Transform VFXHitGreen;
    [SerializeField] private TextMeshProUGUI Txt_UpdateBullet;
    [SerializeField] private LayerMask LayerEnemy;
    [SerializeField] private LayerMask LayerMap;
    [SerializeField] private AudioManager _AudioManager;
    [SerializeField] private BulletPool _BulletPool;

    public bool IsShotting;

    private int Bullet; // Số đạn
    private int TotalGun; // Tổng đạn còn lại
    
    private Transform HitTranform = null;
    private bool CanShot;
    private bool IsReload;

    private bool ButtonReloadOneClick;


    private void Awake()
    {
        IsShotting = false;
        CanShot = true;
        Bullet = 120;
        TotalGun = 240;
        IsReload = false;
        ButtonReloadOneClick = true;

    }
    private void Update()
    {
        ShotGunAuto();
        UpdateBullet();
        if (_ButtonClick.IsReload)
        {
            if(ButtonReloadOneClick && Bullet < 120 && TotalGun > 0) 
                StartCoroutine(Change_Bullet());
            _ButtonClick.IsReload = false;
        }
        if (Bullet == 0 && TotalGun > 0 && !IsReload )
        {
            CanShot = false;
            StartCoroutine(Change_Bullet());
        }
           
  
    }

      

    public void ItemBullet()
    {
        Bullet = 120;
        TotalGun = 240;
        UpdateBullet();
    }   
    
    private void UpdateBullet()
    {
        Txt_UpdateBullet.text = Bullet + "/" + TotalGun;    
    }
    
    private void ShotGunAuto()
    {
        if (_ButtonClick.IsShotGunAR && !IsReload && Bullet > 0)
        {
            Vector3 targetDirection = Camera.main.transform.forward;
            targetDirection.y = 0f;
            transform.rotation = Quaternion.LookRotation(targetDirection);
            Invoke("PlayVFXShotGun", 0.3f);
            IsShotting = true;
            _PlayerAnimation.ShotGunArAuto(_ButtonClick.IsShotGunAR);
        }
        else if(_ButtonClick.IsShotGunAR && !IsReload && Bullet <= 0 && TotalGun == 0)
        {
            _PlayerAnimation.ShotGunArAuto(false);
        }

        else
        {
            IsShotting = false;
            CancelInvoke("PlayVFXShotGun");
            _PlayerAnimation.ShotGunArAuto(_ButtonClick.IsShotGunAR);
        }
    }

       

    private void PlayVFXShotGun()
    {
        VFXMuzzleFlash.Play();
        if (CanShot)
            StartCoroutine(Speed_Shot());
    }

    private void ReLoading()
    {
        int i = 0;
        
        i = 120 - Bullet;
        if (i >= TotalGun)
        {
           Bullet += TotalGun;
           TotalGun = 0;
        }

        else
        {
           Bullet = Bullet + i;
           TotalGun = TotalGun - i;
        }
    }
    
    private IEnumerator Speed_Shot()
    {
        if (Bullet >= 1)
        {
            CanShot = false;
            BulletDirection();
            _AudioManager.PlaySFX(_AudioManager.ShotClip);
            Bullet--;
        }   
        yield return new WaitForSeconds(0.1f);
        CanShot = true;
    }    

    private IEnumerator Change_Bullet()
    {
        IsReload = true;
        ButtonReloadOneClick = false;
        _PlayerAnimation.Reloading();
        _AudioManager.PlaySFX(_AudioManager.ReLoadClip);
        yield return new WaitForSeconds(2.15f);
        IsReload = false;
        ReLoading();
        CanShot = true;
        ButtonReloadOneClick = true;

    }    
    private void BulletDirection()
    {
        Vector2 GunPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(GunPoint);
        Ray raymap = Camera.main.ScreenPointToRay(GunPoint);
        RaycastHit Hit;
        bool IsShotting = Physics.Raycast(ray, out Hit, 100f, LayerEnemy);
        bool IsShottingToMap = Physics.Raycast(raymap, out RaycastHit Hitmap, 100f, LayerMap);
        
        if (IsShotting)
        {
            HitTranform = Hit.transform;
            if (HitTranform != null)
            {
                if(HitTranform.CompareTag("Enemy"))
                {
                    GameObject BulletPrefab = _BulletPool.GetBullet();
                    StartCoroutine(BulletCollison(BulletPrefab, Hit.point));
                    EnemyHealth enemyHealth = HitTranform.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDame(Random.Range(40, 60));
                }            
            }
        }
        if (IsShottingToMap)
        {
            GameObject BulletPrefab = _BulletPool.GetBullet();
            StartCoroutine(BulletCollison(BulletPrefab, Hitmap.point));
        }
        
    }
    IEnumerator BulletCollison(GameObject obj, Vector3 Vt3Col)
    {
        obj.transform.position = Vt3Col;
        yield return new WaitForSeconds(1f);
        _BulletPool.ReturnBullet(obj);
        
    }    
}
