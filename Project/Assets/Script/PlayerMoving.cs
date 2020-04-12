using UnityEngine;
using System.Collections;

public class PlayerMoving : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 10;
    [HideInInspector] public bool facingRight = true;
    private Animator anim;

	public float rangeLeft = -14.0f;
	public float rangeRight=14.0f;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool ("WalkCheck", true);

            if (gameObject.transform.position.x > rangeLeft)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("WalkCheck", true);

            if (gameObject.transform.position.x < rangeRight)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
            }
        }

        else
        {
            anim.SetBool("WalkCheck", false);
        }

      
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

    }

}
