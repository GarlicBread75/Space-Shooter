using UnityEngine;

public class CheatsEnable : MonoBehaviour
{
    public bool canCheat;
    public GameObject indicators;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.BackQuote))
        {
            canCheat = !canCheat;
            indicators.SetActive(canCheat);
        }    
    }
}
