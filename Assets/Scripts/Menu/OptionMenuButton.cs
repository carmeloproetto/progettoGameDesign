using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] AudioChange audioChange;
	[SerializeField] int thisIndex;

	public GameObject optionsMenu;
	public GameObject mainMenu;

	public AudioClip audioClip;

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

				if(thisIndex == 0)
                {
					Debug.Log("INDEX 0 ");
					audioChange.ButtonClicked();
                }

			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
	}
}
