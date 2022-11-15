using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float transitionTime = 1f;
    private Animator transitionAnimator;

    private void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }
    public void LoadNextScene(int sceneIndex)
    {
        if (sceneIndex == 0)
        {
            StartCoroutine(FirstLoad(sceneIndex));
        }
        else if (sceneIndex == 1)
        {
            StartCoroutine(StartScene(sceneIndex));
        }
        else if (sceneIndex == 2)
        {
            StartCoroutine(GameOver(sceneIndex));
        }
        /*int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;*/
        //SceneManager.LoadScene(nextSceneIndex);
    }

    public IEnumerator FirstLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator StartScene(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator GameOver(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
