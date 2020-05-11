using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toGameOver : MonoBehaviour
{
    [SerializeField] Status playerStatus;

    // Update is called once per frame
    void Update()
    {
        if (playerStatus.Lives <= 0)
        {
            StartCoroutine(aGameOver());
        }
    }

    IEnumerator aGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }
}
