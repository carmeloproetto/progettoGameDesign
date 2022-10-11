using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

	public GameObject optionsMenu;
	public GameObject mainMenu;
	public GameObject tutorialMenu;

	public AudioClip audioClip;

	public GameObject levelLoader;
	public GameObject canvas;

	public GameObject newGameButton;


    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if (Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;

				if(thisIndex == 0)
                {
					//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
					canvas.GetComponent<Canvas>().enabled = false;
					levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
				else if(thisIndex == 1)
                {
					optionsMenu.SetActive(true);
					mainMenu.SetActive(false);
					menuButtonController.index = 0;
                }
				else if (thisIndex == 2)
				{
					tutorialMenu.SetActive(true);
					mainMenu.SetActive(false);
					menuButtonController.index = 0;
				}
				else if (thisIndex == 3)
				{
					Debug.Log("Quit! This works only during buikd ");
					Application.Quit();
				}

			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
