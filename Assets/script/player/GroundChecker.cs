using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] Vector2 Size;
    [SerializeField] LayerMask GroundMask;
    public bool isGrounded;
    

    public void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), Size, 0f, GroundMask);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Size.x, Size.y, Size.y));
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        
    }
}
