using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    
    [SerializeField] Vector2 Size;
    [SerializeField] LayerMask GemsMask;
    public bool playerScored;
    
    [Header("Score")]
    [SerializeField] private SO_intValue playerScorelvl1;
    [SerializeField] private SO_intValue playerScorelvl2;
    [SerializeField] private SO_intValue playerScorelvl3;
    
    [Header("Debug")]
    [SerializeField] private SO_Score levelScore;
    [SerializeField] private PlayerScore playerScore;
    

    // Update is called once per frame
    void Update()
    {
        playerScored = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), Size, 0, GemsMask);
        Debug.Log(levelScore.Scorelvl1);
    }
    
    public int lvl1(int value) => playerScorelvl1.Value += value;
    public int lvl2(int value) => playerScorelvl2.Value += value;
    public int lvl3(int value) => playerScorelvl3.Value += value;
    
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
