using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBearAnimationController : MonoBehaviour
{
    [SerializeField] private Status myStatus;
    [SerializeField] private miniBearMovement miniBearMovement;

    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    

    [SerializeField] private Rigidbody2D rb;

    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Mathf.Abs(rb.velocity.x);
        vertical = rb.velocity.y;

        //Set Animation Variables
        ani.SetFloat("Horizontal", horizontal);
        ani.SetFloat("Vertical", vertical);

        ani.SetBool("Target", miniBearMovement.Target);
        ani.SetBool("Resting", miniBearMovement.Resting);
        ani.SetBool("Fighting", myStatus.Fighting);
        ani.SetBool("Jumping", myStatus.Jumping);
        ani.SetBool("Hit", myStatus.Hit);
        ani.SetBool("Dead", myStatus.Dead);
    }
}
