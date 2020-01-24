using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemNull : MonoBehaviour
{
    public EventSystem eventSys;

    [SerializeField] GameObject playAgainButton;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject myEventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSys.currentSelectedGameObject == null)
            eventSys.SetSelectedGameObject(playAgainButton);
    }
}
