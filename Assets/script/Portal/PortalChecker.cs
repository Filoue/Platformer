using UnityEngine;

public class PortalChecker : MonoBehaviour
{
    [SerializeField] Vector2 Size;
    [SerializeField] LayerMask PortalMask;
    public bool IsPortal;


    // Update is called once per frame
    void Update()
    {
      IsPortal  = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), Size, 0f, PortalMask);
    }
    public void OnDrawGizmos()
    {
        if (IsPortal)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position, new Vector3(Size.x, Size.y, Size.y));
    }
}
