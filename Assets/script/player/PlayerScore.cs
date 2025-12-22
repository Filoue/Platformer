using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    
    [SerializeField] Vector2 Size;
    [SerializeField] LayerMask GemsMask;
    public bool playerScored;

    // Update is called once per frame
    void Update()
    {
        playerScored = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), Size, 0, GemsMask);
    }
    
    public void OnDrawGizmos()
    {
        if (playerScored)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position, new Vector3(Size.x, Size.y, Size.y));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gems"))
        {
            Destroy(collision.gameObject);
        }
            
    }
}
