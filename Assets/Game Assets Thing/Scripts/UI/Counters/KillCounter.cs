using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    int kills = 0;

    void FixedUpdate()
    {
        ShowKills();
    }

    public void ShowKills()
    {
        counter.text = kills.ToString();
    }

    public void AddKill(int killNum)
    {
        kills += killNum;
    }
}
