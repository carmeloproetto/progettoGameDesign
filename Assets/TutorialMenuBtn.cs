using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenuBtn : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

	public GameObject mainMenu;
	public GameObject tutorialMenu;

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

			if (Input.GetKeyDown(KeyCode.Space))
			//if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{

				if (thisIndex == 0)
				{
					tutorialMenu.SetActive(false);
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
