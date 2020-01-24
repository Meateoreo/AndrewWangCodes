using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideStuffs : MonoBehaviour
{
    public GameObject endCanvas;
    public bool pause;
    public Text pauseText;

    [SerializeField] private GameObject thePlayer;
    [SerializeField] private Status playerStatus;
    [SerializeField] private ControllerInputManager contInput;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private AudioListener hearAudio;

    [SerializeField] private Status bossStatus;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.GetComponent<Text>().enabled = false;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (contInput.Start && pause)
            pause = false;
        else if (contInput.Start && !pause)
            pause = true;

        /*
        if (Input.GetKeyDown("escape") && pause)
            pause = false;
        else if (Input.GetKeyDown("escape") && !pause)
            pause = true;
       */

            if (pause)
        {
            Time.timeScale = 0;
            playerMovement.enabled = false;
            hearAudio.enabled = false;
            thePlayer.GetComponent<Animator>().enabled = false;
            pauseText.GetComponent<Text>().enabled = true;
            endCanvas.SetActive(true);
            pauseText.enabled = true;
        }
        else if (bossStatus.HP != 0)
        {
            Time.timeScale = 1;
            playerMovement.enabled = true;
            hearAudio.enabled = true;
            thePlayer.GetComponent<Animator>().enabled = true;
            endCanvas.SetActive(false);
            pauseText.enabled = false;
        }

    }
}
