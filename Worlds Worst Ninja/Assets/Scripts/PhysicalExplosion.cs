using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalExplosion : MonoBehaviour
{

    public float force;

    public float FOI;

    public LayerMask hitLayer;

    public Vector2 ExplosionDirection;

    private Collider2D[] objects;

    private bool _isExploding;

    private PlayerMovement _pm;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.2f);
        _pm = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==11)
        {
            Debug.Log("Hai");
            ExplosionDirection = (collision.gameObject.transform.position - transform.position);
            ExplosionDirection.Normalize();
            _pm._isExplosion = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FOI);
    }
}
