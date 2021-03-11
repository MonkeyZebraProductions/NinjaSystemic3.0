using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Controls inputs;

    public Transform LookTarget;

    private float maxDirX, maxDirY, maxRadius;

    public float angle;

    public LayerMask WhatIsGround, WhatIsEnemy,WhatIsFront,WhatIsBack;

    public Vector2 dir, point;

    public bool _hitFront,_hitBack;

    private bool _hitground, _hitenemy;

    public GameObject Debris, Sound, Particles, BurstPart;

    public RaycastHit2D hitGround,hitEnemy;


    private PlayerMovement _pm;

    private WeaponStat _WS;

    private EnemyDamageAndKnockback _EDK;

    private GameObject _currentEnemy;

    private void Awake()
    {
        inputs = new Controls();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _pm = FindObjectOfType<PlayerMovement>();
        

    }

 


    // Update is called once per frame
    void FixedUpdate()
    {
        _WS = FindObjectOfType<WeaponStat>();
        if(_hitenemy)
        {
            maxRadius=Vector2.Distance(transform.position,hitEnemy.point);
        }
        else
        {
            maxRadius = _WS.WeaponRange;
        }
       
        Sound = _WS.Sound;
        Particles = _WS.Particles;
        BurstPart = _WS.BurstPart;
        Vector2 mousePosition = inputs.Player.Look.ReadValue<Vector2>();


        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        dir = (mousePosition - pos);
        dir.Normalize();



        angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _hitBack = Physics2D.Raycast(transform.position, dir, maxRadius, WhatIsBack);

        _hitFront = Physics2D.Raycast(transform.position, dir, maxRadius, WhatIsFront);

        _hitground = hitGround = Physics2D.Raycast(transform.position, dir, maxRadius, WhatIsGround);
       
        _hitenemy= hitEnemy=Physics2D.Raycast(transform.position, dir, maxRadius, WhatIsEnemy);
        Debug.DrawRay(transform.position, dir * maxRadius, Color.green);
    }

    public void HitEnemy()
    {
        if(_hitenemy)
        {
            _EDK = FindObjectOfType<EnemyDamageAndKnockback>();
            _EDK.HitEnemy();
           
        }
    }

    public void CreateDebris()
    {

        Instantiate(Sound, transform.position, Quaternion.identity);
        Instantiate(BurstPart, transform.position, Quaternion.identity);
        if (_hitground == true)
        {
            Instantiate(Debris, hitGround.point, Quaternion.identity);
            Instantiate(Sound, hitGround.point, Quaternion.identity);
            Instantiate(Particles, hitGround.point, Quaternion.identity);
        }

        if (_WS.IsExplosive)
        {
            Instantiate(_WS.Rocket, transform.position, Quaternion.identity);
        }

    }

    

    

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
