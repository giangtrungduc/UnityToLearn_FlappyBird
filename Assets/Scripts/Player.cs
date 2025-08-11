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
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
            anim.SetTrigger("Flap");
        }

        Vector3 rotate = transform.eulerAngles;
        rotate.z = rb.linearVelocity.y * speedRotate;
        transform.eulerAngles = rotate;
    }
}
