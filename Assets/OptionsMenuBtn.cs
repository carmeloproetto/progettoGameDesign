using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuBtn : MonoBehaviour
{

	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] AudioChangeScript audioChange;
	[SerializeField] LanguageChangeScript langChange;
	[SerializeField] int thisIndex;

	public GameObject mainMenu;
	public GameObject optionsMenu;

	// Start is called before the first frame update
	void Start()
	{
		menuButtonController.index = 0;
	}


	// Update is called once per frame
	void Update()
	{
		if (menuButtonController.index == thisIndex)
		{

			animator.SetBool("selected", true);

			if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{

				if (thisIndex == 0)
				{
					audioChange.ButtonClicked();
				}
				else if (thisIndex == 1)
				{
					langChange.ButtonClicked();
				}
				else if (thisIndex == 2)
				{
					optionsMenu.SetActive(false);
					mainMenu.SetActive(true);
					menuButtonController.index = 0;
				}

				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;

			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
	}
}
