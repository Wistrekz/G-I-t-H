using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class script_for_Events : MonoBehaviour
{
    public void NextScene(int scene_num)
    {
        SceneManager.LoadScene(scene_num);
    }
}
