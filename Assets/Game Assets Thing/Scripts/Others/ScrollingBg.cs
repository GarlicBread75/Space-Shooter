using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public float speed;
    [SerializeField] private Renderer bgRend;

    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
