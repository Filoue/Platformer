using UnityEngine;

public class EnnemiZone : MonoBehaviour
{
    [SerializeField] public Vector2 ennemiZones;
    [SerializeField] private LayerMask Mask;
    public bool ennemiInZone;
    
    private EnnemiAi ennemi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ennemiInZone = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), ennemiZones, 0f, Mask);
    }
    

    private void OnDrawGizmos()
    {
        if (ennemiInZone)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position, ennemiZones);
    }
}
