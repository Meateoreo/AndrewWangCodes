using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControlScript : MonoBehaviour
{
    [SerializeField] private Status playerStatus; //script from above object
    [SerializeField] private aAttacks attacks; //script from above object
    [SerializeField] private ControllerInputManager contInput; //script from above object

    //hitboxes
    [SerializeField] private GameObject NA;
    [SerializeField] private GameObject FT;
    [SerializeField] private GameObject UT;
    [SerializeField] private GameObject DT;
    [SerializeField] private GameObject NAir;
    [SerializeField] private GameObject FAir;
    [SerializeField] private GameObject BAir;
    [SerializeField] private GameObject UAir;
    [SerializeField] private GameObject DAir;
    
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;


    public Animator ani;
    

    // Update is called once per frame
    void Update()
    {
        //update Controller Input Stuffs
        horizontal = contInput.controllerMovement.x;
        vertical = contInput.controllerMovement.y;
        
        //Set Animation Variables
        ani.SetFloat("Horizontal", Mathf.Abs(horizontal));
        ani.SetFloat("Vertical", vertical);
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            ani.SetFloat("Horizontal", 1);



        ani.SetBool("Fighting", playerStatus.Fighting);
        ani.SetBool("Ducking", playerStatus.Ducking);
        ani.SetBool("Jumping", playerStatus.Jumping);
        ani.SetBool("Hit", playerStatus.Hit);
        ani.SetBool("DoubleJump", playerStatus.DoubleJump);
        ani.SetBool("Dead", playerStatus.Dead);

        #region Attacks
        //GroundAttacks
        if (attacks.CurrentHitbox == NA)
            ani.SetTrigger("NA");
        else
            ani.ResetTrigger("NA");

        if (attacks.CurrentHitbox == FT)
            ani.SetTrigger("FT");
        else
            ani.ResetTrigger("FT");

        if (attacks.CurrentHitbox == DT)
            ani.SetTrigger("DT");
        else
            ani.ResetTrigger("DT");

        if (attacks.CurrentHitbox == UT)
            ani.SetTrigger("UT");
        else
            ani.ResetTrigger("UT");

        //AirAttacks
        if (attacks.CurrentHitbox == NAir)
            ani.SetTrigger("NAir");
        else
            ani.ResetTrigger("NAir");

        if (attacks.CurrentHitbox == FAir)
            ani.SetTrigger("FAir");
        else
            ani.ResetTrigger("FAir");

        if (attacks.CurrentHitbox == BAir)
            ani.SetTrigger("BAir");
        else
            ani.ResetTrigger("BAir");

        if (attacks.CurrentHitbox == DAir)
            ani.SetTrigger("DAir");
        else
            ani.ResetTrigger("DAir");

        if (attacks.CurrentHitbox == UAir)
            ani.SetTrigger("UAir");
        else
            ani.ResetTrigger("UAir");

        #endregion
    }
}
