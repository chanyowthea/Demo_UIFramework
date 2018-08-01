using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.Open<StartUI>(); 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            {
            UIManager.Instance.Close<StartUI>();
        }
    }
}
