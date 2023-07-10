using System.Collections;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    float speed;
    public float waitTime;
    public float startWaitTime;
    int moveHere;

    public Transform[] moveSpots = new Transform[2];

    private void Start()
    {
        moveSpots[0] = GameObject.Find("Spot (1)").transform;
        moveSpots[1] = GameObject.Find("Spot (2)").transform;
        waitTime = startWaitTime;
        StartCoroutine(MoveToPos(new Vector3(moveSpots[0].position.x, moveSpots[0].position.y)));
        speed = Random.Range(0.5f, 1f);
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
                moveSpots[0].position = new Vector2(moveSpots[0].position.x, moveSpots[0].position.y - 0.2f);
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
                moveSpots[1].position = new Vector2(moveSpots[1].position.x, moveSpots[1].position.y - 0.2f);
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
