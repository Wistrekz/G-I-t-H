using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menu_clicker : MonoBehaviour
{
	public Text text;

	public GameObject block;
	public GameObject Set_block;
	public static bool FullscreenStatus;

    public void MouseOn()
	{
		Debug.Log("sdferf");
		text.color = Color.yellow;
	}

	public void MouseOut()
	{
		Debug.Log("111");
		text.color = Color.white;
	}

	public void MouseOnButton(GameObject button)
	{
		Debug.Log(gameObject.name);
		button.GetComponent<Image>().color = Color.yellow;
	}

	public void MouseOutButton(GameObject button)
	{
		Debug.Log("111");
		button.GetComponent<Image>().color = Color.white;
	}


	public void TotheScene(int scene)
    {
		SceneManager.LoadScene(scene);
	}
	public void Exit_game()
    {
		Application.Quit();
	}
	public void Settings()
    {
		block.SetActive(false);
		Set_block.SetActive(true);
    }
	public void Back()
	{
		block.SetActive(true);
		Set_block.SetActive(false);
	}

	public void FullscreenMode()
    {
		if(FullscreenStatus)
        {

        }
		else
        {

        }
    }
}
