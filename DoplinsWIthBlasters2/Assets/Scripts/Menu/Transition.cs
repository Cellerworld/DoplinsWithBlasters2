using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    
    public Animator transitionAnim;
    //public string SceneName;


    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(LoadScene());
            
        }
    } */

    private void Start()
    {
       // DontDestroyOnLoad(this);
        //transitionAnim = FindObjectOfType<TransitionAnimationControl>();
    }

    private void Awake()
    {
        //transitionAnim.GetComponent<Animator>().SetTrigger("End");
    }



    public void LoadNewScene( string SceneName)
    {
        Debug.Log("this is changing the scene");
        StartCoroutine(LoadScene(SceneName));
    }

    IEnumerator LoadScene(string SceneName){
        transitionAnim.gameObject.SetActive(true);
        transitionAnim.Play("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }
}