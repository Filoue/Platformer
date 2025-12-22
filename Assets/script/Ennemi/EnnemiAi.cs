using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnnemiAi : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform ennemiZones;
    [SerializeField] private EnnemiZone ennemiZone;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance = 1.5f;
    
    [Header("Gizmo settings")]
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    public bool inZone;
    private Rigidbody2D rb;

    private float randomXposition;
    private float randomYposition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inZone = Physics2D.OverlapCircle(transform.position, radius, layerMask);        
        if (inZone)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer > stoppingDistance)
            {
                Vector2 direction = player.position - transform.position;
                direction.Normalize();
                transform.Translate(direction * speed * Time.deltaTime);
            }
        } 
        
        if (!ennemiZone.ennemiInZone)
        {
            Debug.Log("in");
            float distanceToZone = Vector2.Distance(transform.position, ennemiZones.position);
            if (distanceToZone > stoppingDistance)
            {
                Vector2 direction = ennemiZones.position - transform.position;
                direction.Normalize();
                transform.Translate(direction * speed * Time.deltaTime);
            }

        }
        
    }


    private void OnDrawGizmos()
    {
        if (inZone)
        {
            
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
}
