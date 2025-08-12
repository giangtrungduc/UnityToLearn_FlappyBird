using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float force = 5f;
    [SerializeField] float speedRotate = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (GameManager.Instance.isDie) return;

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
            anim.SetTrigger("Flap");
        }

        Vector3 rotate = transform.eulerAngles;
        rotate.z = rb.linearVelocity.y * speedRotate;
        transform.eulerAngles = rotate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe") || collision.CompareTag("Ground"))
        {
            GameManager.Instance.SetGameOver();
            Destroy(gameObject, 2f);
        }
        if(collision.CompareTag("Point"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}
