using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
    public GameObject[] prefabs;

    private void Start()
    {
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("ParentHere").transform);
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 180), GameObject.FindGameObjectWithTag("ParentHere").transform);
        Destroy(gameObject, 1f);
    }
}