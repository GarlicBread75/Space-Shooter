using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator animator;
    public float delay;

    public void LoadOtherScene(int sceneNum)
    {
        StartCoroutine(ILevelTransition(sceneNum));
    }

    IEnumerator ILevelTransition(int index)
    {
        animator.SetTrigger("trigger");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index); 
    }
}
