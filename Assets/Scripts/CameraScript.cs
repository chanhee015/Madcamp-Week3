using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    public Button Back_button;

    
    // Start is called before the first frame update
    void Start()
    {
        Back_button.onClick.AddListener(TaskOnClick);
        cam1.enabled = true;
        cam2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (DevCraftingSystem.IsChanging)
        {

            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;  
            DevCraftingSystem.IsChanging = false;

        }

    }

    void TaskOnClick()
    {   
        cam2.enabled = false; 
        cam1.enabled = true;
    }
}
