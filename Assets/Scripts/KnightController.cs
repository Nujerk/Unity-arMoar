using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour {

    public float knightSpeed = 5;
    private Animator animator;
    private bool flipped = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float xaxis = Input.GetAxis("Horizontal");
        float h = Mathf.Abs(xaxis);
        bool fire = Input.GetButtonDown("Fire1");

        animator.SetFloat("Forward", h);
        animator.SetBool("Fire", fire);

        if(h > 0.1)
        {
            var vector = Vector3.right * Mathf.Sign(xaxis) * Time.deltaTime * knightSpeed;
            transform.position += vector;

            if(xaxis < 0 && !flipped)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                flipped = true;
            }
            else if( xaxis > 0 && flipped)
            {
                transform.localScale = new Vector3(1, 1, 1);
                flipped = false;
            }
        }

        if(fire)
        {
            animator.Play("knight_attack");
        }
    }
}
