using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private Status myStatus;
 
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject leftHurtBox;
    [SerializeField] private GameObject rightHurtBox;

    [SerializeField] private GameObject leftPow;
    [SerializeField] private GameObject rightPow;

    [SerializeField] private GameObject HealBlock;
    [SerializeField] private int dropped;

    [SerializeField] private float summonCounting;

    [SerializeField] int stage;
    [SerializeField] bool running;
    [SerializeField] bool lasering;
    [SerializeField] bool dizzy;

    public bool Lasering { get => lasering; }
    public bool Dizzy { get => dizzy; }

    [SerializeField] private GameObject currentHitbox;

    [SerializeField] private GameObject[] minions;
    [SerializeField] private GameObject[] summonPortals;
    
    public Animator leftArmAni;
    public Animator rightArmAni;
    public Animator bodyAni;
    public Animator headAni;

    [SerializeField] private AudioClip powSound;
    [SerializeField] private AudioClip laserSound;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        running = false;
        lasering = false;
        currentHitbox = null;
        summonCounting = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (myStatus.HP > 0)
        {
            if (myStatus.HP < 250)
                summonCounting -= Time.deltaTime;

            if (summonCounting <= 0)
            {
                if (myStatus.HP > 100)
                    summonCounting = Random.Range(15, 30);
                else
                    summonCounting = Random.Range(10, 15);
                Summon();
            }
        }

        if(myStatus.HP == 0)
        {
            if(currentHitbox != null)
                currentHitbox.SetActive(false);
            stage = 9;

            dizzy = true;
        }

        if (!running)
        {
            switch (stage)
            {
                case 0:
                    StartCoroutine(phase0());
                    break;
                case 1:
                    StartCoroutine(phase1());
                    break;
                case 2:
                    StartCoroutine(phase2());
                    break;
                case 3:
                    StartCoroutine(phase3());
                    break;
                case 4:
                    StartCoroutine(phase4());
                    break;
                case 5:
                    StartCoroutine(phase5());
                    break;
                case 6:
                    StartCoroutine(phase6());
                    break;
                case 7:
                    StartCoroutine(phase7());
                    break;
                case 8:
                    StartCoroutine(phase8());
                    break;
                case 9:
                    lasering = false;
                    myStatus.Fighting = false;
                    break;
            }
        }

        headAni.SetBool("Fighting", myStatus.Fighting);
        headAni.SetBool("Laser", lasering);
        headAni.SetBool("Dizzy", dizzy);

        leftArmAni.SetBool("Fighting", myStatus.Fighting);
        leftArmAni.SetBool("Hit", myStatus.Hit);
        rightArmAni.SetBool("Fighting", myStatus.Fighting);
        rightArmAni.SetBool("Hit", myStatus.Hit);
    }

    private void Summon()
    {
        GameObject minion1 = minions[Random.Range(0, 3)];
        Instantiate(minion1, new Vector3(summonPortals[0].transform.position.x, summonPortals[0].transform.position.y), minion1.transform.rotation);
        GameObject minion2 = minions[Random.Range(0, 3)];
        Instantiate(minion2, new Vector3(summonPortals[1].transform.position.x, summonPortals[0].transform.position.y), minion2.transform.rotation);
    }

    IEnumerator HealDrop()
    {
        yield return new WaitForSeconds(1f);
        GameObject block;
        block = Instantiate(HealBlock, transform.position, transform.rotation);

        block.GetComponent<Rigidbody2D>().velocity = Vector3.up;
    }

    IEnumerator phase0()
    {
        running = true;
        yield return new WaitForSeconds(3f);
        running = false;
        stage = Random.Range(1, 2);
    }

    IEnumerator phase1()
    {
        running = true;
        myStatus.Fighting = true;
        leftArm.SetActive(true);
        currentHitbox = leftArm;
        leftArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
            source.PlayOneShot(powSound);
        leftArm.GetComponent<BoxCollider2D>().enabled = true;
        leftPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        leftPow.SetActive(false);
        leftArm.GetComponent<BoxCollider2D>().enabled = false;
        leftHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        leftHurtBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        leftArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        myStatus.Hit = false;
        stage = 2;
    }

    IEnumerator phase2()
    {
        running = true;
        myStatus.Fighting = true;
        rightArm.SetActive(true);
        currentHitbox = leftArm;
        rightArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
        rightArm.GetComponent<BoxCollider2D>().enabled = true;
            source.PlayOneShot(powSound);
        rightPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        rightPow.SetActive(false);
        rightArm.GetComponent<BoxCollider2D>().enabled = false;
        rightHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        rightHurtBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        rightArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        myStatus.Hit = false;
        stage = 3;
    }

    IEnumerator phase3()
    {
        running = true;
        lasering = true;
        currentHitbox = laser;
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
        source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        laser.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        stage = 9;
        yield return new WaitForSeconds(1f);
        stage = 4;
    }

    IEnumerator phase4()
    {
        running = true;
        myStatus.Fighting = true;
        leftArm.SetActive(true);
        rightArm.SetActive(true);
        currentHitbox = leftArm;
        leftArmAni.SetBool("Attack", true);
        rightArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
            source.PlayOneShot(powSound);
        leftArm.GetComponent<BoxCollider2D>().enabled = true;
        leftPow.SetActive(true);
        rightArm.GetComponent<BoxCollider2D>().enabled = true;
        rightPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        leftPow.SetActive(false);
        leftArm.GetComponent<BoxCollider2D>().enabled = false;
        leftHurtBox.SetActive(true);
        rightPow.SetActive(false);
        rightArm.GetComponent<BoxCollider2D>().enabled = false;
        rightHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        lasering = true;
        currentHitbox = laser;
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        laser.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        dizzy = true;
        StartCoroutine(HealDrop());
        StartCoroutine(HealDrop());
        yield return new WaitForSeconds(5f);
        dizzy = false;
        running = false;
        myStatus.Fighting = false;
        leftHurtBox.SetActive(false);
        rightHurtBox.SetActive(false);
        leftArm.SetActive(false);
        rightArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        stage = 5;
    }

    //Randomized here
    //left punch
    IEnumerator phase5()
    {
        running = true;
        myStatus.Fighting = true;
        leftArm.SetActive(true);
        currentHitbox = leftArm;
        leftArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
            source.PlayOneShot(powSound);
        leftArm.GetComponent<BoxCollider2D>().enabled = true;
        leftPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        leftPow.SetActive(false);
        leftArm.GetComponent<BoxCollider2D>().enabled = false;
        leftHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        leftHurtBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        leftArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        myStatus.Hit = false;
        stage = Random.Range(5,9);
    }

    //right punch
    IEnumerator phase6()
    {
        running = true;
        myStatus.Fighting = true;
        rightArm.SetActive(true);
        currentHitbox = leftArm;
        rightArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
            source.PlayOneShot(powSound);
        rightArm.GetComponent<BoxCollider2D>().enabled = true;
        rightPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        rightPow.SetActive(false);
        rightArm.GetComponent<BoxCollider2D>().enabled = false;
        rightHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        rightHurtBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        rightArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        myStatus.Hit = false;
        stage = Random.Range(5, 9);
    }

    //multihit
    IEnumerator phase7()
    {
        running = true;
        myStatus.Fighting = true;
        leftArm.SetActive(true);
        rightArm.SetActive(true);
        currentHitbox = leftArm;
        leftArmAni.SetBool("Attack", true);
        rightArmAni.SetBool("Attack", true);
        yield return new WaitForSeconds(1.3f);
            source.PlayOneShot(powSound);
        leftArm.GetComponent<BoxCollider2D>().enabled = true;
        leftPow.SetActive(true);
        rightArm.GetComponent<BoxCollider2D>().enabled = true;
        rightPow.SetActive(true);
        yield return new WaitForSeconds(1f);
        leftPow.SetActive(false);
        leftArm.GetComponent<BoxCollider2D>().enabled = false;
        leftHurtBox.SetActive(true);
        rightPow.SetActive(false);
        rightArm.GetComponent<BoxCollider2D>().enabled = false;
        rightHurtBox.SetActive(true);
        yield return new WaitForSeconds(5f);
        lasering = true;
        currentHitbox = laser;
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        laser.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        dizzy = true;
        StartCoroutine(HealDrop());
        StartCoroutine(HealDrop());
        yield return new WaitForSeconds(5f);
        dizzy = false;
        running = false;
        myStatus.Fighting = false;
        leftHurtBox.SetActive(false);
        rightHurtBox.SetActive(false);
        leftArm.SetActive(false);
        rightArm.SetActive(false);
        stage = 9;
        yield return new WaitForSeconds(1f);
        stage = Random.Range(5, 9);
    }

    //laser at end so cant laser twice
    IEnumerator phase8()
    {
        running = true;
        lasering = true;
        currentHitbox = laser;
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        yield return new WaitForSeconds(1f);
            source.PlayOneShot(laserSound);
        laser.SetActive(true);
        leftEye.SetActive(true);
        rightEye.SetActive(true);
        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(5f);
            source.Stop();
        laser.SetActive(false);
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        laser.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        running = false;
        myStatus.Fighting = false;
        stage = 9;
        yield return new WaitForSeconds(1f);
        stage = Random.Range(5, 8);
    }
}
