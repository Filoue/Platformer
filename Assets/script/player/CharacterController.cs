using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("Physics option")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float hitForce;
    [SerializeField] private float WallForce;
    [SerializeField] private Animator anim;
    [SerializeField] private float MaxTime;
    [SerializeField] private float maxVelocity;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private float timeBetweenSteps;
    
    [Header("Checker")]
    [SerializeField] private GroundChecker grdCheck;
    [SerializeField] private GroundChecker leftCheck;
    [SerializeField] private GroundChecker rightCheck;
    private float time;
    private bool canMove;
    private bool isHit;
    private float _jumpInput;
    private float _moveInput;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    void Start()
    {
        if (transform.childCount > 0)
        {
            Transform childTransform = transform.GetChild(0);
            sr = childTransform.GetComponent<SpriteRenderer>();
            audioSource = childTransform.GetComponent<AudioSource>();
        }
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.linearVelocityX = Mathf.Max(10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocityY >= maxVelocity)
        {
            rb.linearVelocityY = maxVelocity;
        }
        
        
        if (canMove)
        {
            rb.linearVelocityX = _moveInput * speed;
            if (Mathf.Abs(rb.linearVelocityX) > 0)
            { 
                StartCoroutine(Footstep_co());
            }
            else
            {
                StopCoroutine(Footstep_co());
            }
        }
        sr.flipX = rb.linearVelocityX < 0;
        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));

        if (time <= 0)
        {
            canMove = true;
        }
        time -= Time.deltaTime;
        
    }
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (grdCheck.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (!grdCheck.isGrounded)
        {
            if (leftCheck.isGrounded)
            {
                rb.AddForce(new Vector2(1,1).normalized * WallForce, ForceMode2D.Impulse);
                canMove = false;
                time = MaxTime;
            }
            if (rightCheck.isGrounded)
            {
                rb.AddForce(new Vector2(-1,1).normalized * WallForce, ForceMode2D.Impulse);
                canMove = false;
                time = MaxTime;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("jumpPad"))
        {
            rb.AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);
        }
    }
    
    private IEnumerator Footstep_co()
    {
        do
        {
            audioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
            yield return new WaitForSeconds(timeBetweenSteps);
        } while (true);
    }
}
