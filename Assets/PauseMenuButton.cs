using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] PauseMenu pauseMenuScript;
	[SerializeField] int thisIndex;

	public GameObject optionsMenu;
	public GameObject pauseMenu;
	public GameObject tutorialMenu;


	public AudioClip audioClip;

	// Update is called once per frame
	void Update()
	{
		if (menuButtonController.index == thisIndex)
		{
			//Debug.Log("INDEX " + thisIndex);

			animator.SetBool("selected", true);
			if(Input.GetKeyDown(KeyCode.Space))
			//if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{
				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;

				if (thisIndex == 0)
				{
					Debug.Log("RESUME!");
					tutorialMenu.SetActive(false);
					optionsMenu.SetActive(false);
					pauseMenuScript.Resume();
				}
				else if (thisIndex == 1)
				{
					optionsMenu.SetActive(true);
					pauseMenu.SetActive(false);
					menuButtonController.index = 0;
				}
				else if(thisIndex == 2)
                {
					tutorialMenu.SetActive(true);
					pauseMenu.SetActive(false);
					menuButtonController.index = 0;
				}
				else if (thisIndex == 3)
				{
					Debug.Log("QUIT!");
					Application.Quit();
				}

			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
	}
}
