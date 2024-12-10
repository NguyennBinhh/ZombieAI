using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float m_Health;
    [SerializeField] private GameObject FloatingTextPrefab;
    private SpawnEnemy _SpawnEnemy;
    private float TextDamePopUp;

    
    public int CountEnemyKilled;

    private void Awake()
    {
        CountEnemyKilled = 0;
        m_Health = 300;
        TextDamePopUp = 0;
        _SpawnEnemy = FindObjectOfType<SpawnEnemy>();
    }
    public void TakeDame(float Dame)
    {
        TextDamePopUp = Dame;
        m_Health -= Dame;
        if(FloatingTextPrefab && m_Health >= 0)
            DamePopUp();
    }

    private void DamePopUp()
    {
        Vector3 vt3 = transform.position + new Vector3(0f, 2f, 0f);
        Quaternion targetRotation = Quaternion.LookRotation(-transform.forward);
        var go = Instantiate(FloatingTextPrefab, vt3, targetRotation, transform);
        go.GetComponent<TextMesh>().text = TextDamePopUp.ToString();
    }    

    private void Update()
    {
        if(m_Health < 0)
        {
            _SpawnEnemy.CountEnemyKilled++;
            Destroy(gameObject);
            if (_SpawnEnemy != null)
                _SpawnEnemy.CountEnemy--;
        }    
    }
}
