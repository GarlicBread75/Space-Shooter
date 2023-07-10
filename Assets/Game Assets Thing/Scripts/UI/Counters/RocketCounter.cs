using TMPro;
using UnityEngine;

public class RocketCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    [HideInInspector] public int rocket = 0;

    void FixedUpdate()
    {
        ShowRockets();
    }

    public void ShowRockets()
    {
        counter.text = rocket.ToString();
    }

    public void AddRocket(int rocketNum)
    {
        rocket += rocketNum;
    }
}
