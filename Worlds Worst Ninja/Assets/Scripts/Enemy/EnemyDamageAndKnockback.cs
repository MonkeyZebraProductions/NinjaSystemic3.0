using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageAndKnockback : MonoBehaviour
{
    public float Health=10f;
    public bool IsFront, IsBack,IsAlert;
    private Rigidbody2D _rb;
    private Arrow arrow;
    private WeaponStat _WS;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        arrow = FindObjectOfType<Arrow>();
       
    }

    private void Update()
    {
        _WS = FindObjectOfType<WeaponStat>();
        if(Health<=0)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    public void HitEnemy()
    {
        if(arrow._hitFront)
        {
            _rb.AddForceAtPosition(arrow.dir * 20f * _WS.WeaponForce, arrow.hitEnemy.point);
        }
        else
        {
            _rb.AddForceAtPosition(arrow.dir * 100f * _WS.WeaponForce, arrow.hitEnemy.point);
        }
        Health -= _WS.WeaponDamage;

        Debug.Log("Hi");
    }
}
