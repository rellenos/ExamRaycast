using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    private bool isMenuClicked;
    
    public Text Timer;
    public float time = 5.0f;


    void Start()
    {
        isMenuClicked = false;
    }

    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) == true )
        {
            var selection = hit.transform;
            if(selection.CompareTag("Box1") || selection.CompareTag("Box2") || selection.CompareTag("Sphere"))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Debug.Log(hit.transform.gameObject.tag);
                if (selection.CompareTag("Box1"))
                    {
                        time -= Time.deltaTime;
                        if (time <0)
                        {
                            SceneManager.LoadScene ("Scene1");
                        }
                    }
                if (selection.CompareTag("Box2"))
                    {
                        time -= Time.deltaTime;
                        if (time <0)
                        {
                            SceneManager.LoadScene ("Scene2");
                        }
                    }
                if (selection.CompareTag("Sphere"))
                    {
                        time -= Time.deltaTime;
                        if (time <0)
                        {
                            SceneManager.LoadScene ("Scene3");
                        }
                    }
            } 
        }   
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
} 
