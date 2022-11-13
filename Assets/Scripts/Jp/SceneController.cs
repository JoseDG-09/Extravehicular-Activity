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
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextSceneIndex);
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
