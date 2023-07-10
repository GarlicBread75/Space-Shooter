using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;
    int moveHere;

    public Transform[] moveSpots = new Transform[2];

    private void Start()
    {
        moveSpots[0] = GameObject.Find("Boss Spot (1)").transform;
        moveSpots[1] = GameObject.Find("Boss Spot (2)").transform;
        waitTime = startWaitTime;
        StartCoroutine(MoveToPos(new Vector3(moveSpots[0].position.x, moveSpots[0].position.y)));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[moveHere].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[0].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                moveHere = 1;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        if (Vector2.Distance(transform.position, moveSpots[1].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                moveHere = 0;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public IEnumerator MoveToPos(Vector3 endPos)
    {
        Vector3 startPos = transform.position;
        float t = 0f;
        while (t < 1f)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
