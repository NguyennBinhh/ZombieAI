
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Player_ShotGunAR _Player_ShotGunAR;
    [SerializeField] private HeathBar _HeathBar;
    [SerializeField] private AudioManager _AudioManager;
    [SerializeField] private string ItemName;


    private Vector3 StartPosition;

    private void Update()
    {

        transform.Rotate(0, 100f * Time.deltaTime, 0);

    }
    private void Start()
    {
        StartPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (ItemName == "Health")
                _HeathBar.HeathItem();
            else if(ItemName == "Bullet")
                _Player_ShotGunAR.ItemBullet();
            StartCoroutine(HideItem());
            _AudioManager.PlaySFX(_AudioManager.ItemClip);
        }
           
    }

    IEnumerator  HideItem()
    {
        transform.position = new Vector3(100f, 100f, 100f);
        yield return new WaitForSeconds(60f);
        transform.position = StartPosition;

    }    
}
