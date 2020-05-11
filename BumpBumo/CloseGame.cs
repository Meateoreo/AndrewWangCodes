using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Space))
			Application.Quit();
		
    }
}
