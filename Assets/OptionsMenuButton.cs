using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] AudioChange audioChange;
	[SerializeField] LanguageChange langChange;
	[SerializeField] int thisIndex;

	public GameObject mainMenu;
	public GameObject optionsMenu;


	// Update is called once per frame
	void Update()
	{
		if (menuButtonController.index == thisIndex)
		{
			Debug.Log(" INDEX " + thisIndex);
			animator.SetBool("selected", true);
			if (Input.GetAxis("Submit") == 1)
			{
				Debug.Log("SUBMIT");
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{
				Debug.Log("PRESSED");
				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;

				if (thisIndex == 0)
				{
					audioChange.ButtonClicked();
				}
				else if(thisIndex == 1)
                {
					langChange.ButtonClicked();
                }
				else if(thisIndex == 2)
                {
					optionsMenu.SetActive(false);
					mainMenu.SetActive(true);
                }

			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
	}
}
