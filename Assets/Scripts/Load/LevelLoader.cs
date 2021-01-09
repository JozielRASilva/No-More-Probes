using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator animator;

    public float transitionTime = 2;

    public string nextLevel;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(string levelName)
    {

        animator.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }

}
