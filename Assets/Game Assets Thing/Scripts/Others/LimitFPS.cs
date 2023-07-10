using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    [SerializeField] private int maxfps;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxfps;
    }
}
