using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataScript : MonoBehaviour
{
    public string Color="null";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
    	  // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(Color);
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
