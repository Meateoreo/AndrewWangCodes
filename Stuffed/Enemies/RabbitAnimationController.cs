using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAnimationController : MonoBehaviour
{
    [SerializeField] private Status myStatus; //script from above object
    
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
        vertical = rb.velocity.y;

        //Set Animation Variables
        ani.SetFloat("Vertical", vertical);
        
        ani.SetBool("Jumping", myStatus.Jumping);
        ani.SetBool("Hit", myStatus.Hit);
        ani.SetBool("Dead", myStatus.Dead);

    }
}
