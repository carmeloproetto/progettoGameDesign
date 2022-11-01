using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public GameObject newGameButton;
	private Scene thisScene;

	// Start is called before the first frame update
	void Start()
	{
		menuButtonController.index = 0;
		thisScene = SceneManager.GetActiveScene();
	}


	// Update is called once per frame
	void Update()
	{
		thisScene = SceneManager.GetActiveScene();

		if (menuButtonController.index == thisIndex)
		{

			animator.SetBool("selected", true);

			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
			//if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{
				if (thisScene.name == "Menu_scene")
				{

					if (thisIndex == 0)
					{
						audioChange.ButtonClicked();
					}
					else if (thisIndex == 1 && SceneManager.GetActiveScene().name == "Menu_scene")
					{
						langChange.ButtonClicked();
					}
					else if (thisIndex == 2)
					{
						optionsMenu.SetActive(false);
						mainMenu.SetActive(true);
						menuButtonController.index = 0;
					}
				}
				else
                {
					if (thisIndex == 0)
					{
						audioChange.ButtonClicked();
					}
					else if (thisIndex == 1)
					{
						optionsMenu.SetActive(false);
						mainMenu.SetActive(true);
						menuButtonController.index = 0;
					}
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
