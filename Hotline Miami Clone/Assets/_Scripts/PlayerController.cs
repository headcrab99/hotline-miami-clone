using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayersStats stats;

    float hor;
    float ver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ReadInput();
        KillForce();
        //Debug.Log($"magnitude = {rb.linearVelocity} to the {stats.maxVelocity}");
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector2 move = new Vector2(hor, ver);
        rb.AddForce(move.normalized * stats.speed);
        //rb.linearVelocity = move.normalized * stats.speed;
    }
    void ReadInput()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
    }
    void KillForce()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > stats.maxVelocity.x)
        {
            float diffrence = Mathf.Abs(rb.linearVelocityX - stats.maxVelocity.x);
            Vector2 compensate = new Vector2(-rb.linearVelocityX * diffrence, 0);
            Debug.Log($"OVERVELOCITY\n{rb.linearVelocity}\n{stats.maxVelocity}\nDiff = {diffrence}");
            rb.AddForce(compensate);
        }
        if(Mathf.Abs(rb.linearVelocity.y) > stats.maxVelocity.y)
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rb.linearVelocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -rb.linearVelocity * (rb.linearVelocityX - stats.maxVelocity.x));
        Gizmos.color = Color.green;
    }
}
