using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D heroBody;
    public float MoveForce = 100;
    private float fInput = 0.0f;
    public float maxSpeed = 5;
    private bool bFaceRight = true;
    //private bool bGrounded = false;
    //Transform mGroundCheck;


    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        if (fInput < 0 && bFaceRight)
            flip();
        else if (fInput > 0 && !bFaceRight)
            flip();
       
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < maxSpeed)
            heroBody.AddForce(Vector2.right * fInput * MoveForce);
        if (Mathf.Abs(heroBody.velocity.x) > maxSpeed)
            heroBody.velocity = new Vector2 (Mathf.Sign(heroBody.velocity.x) * maxSpeed, heroBody.velocity.y);
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;

    }
}
