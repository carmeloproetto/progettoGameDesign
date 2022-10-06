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

	public AudioClip audioClip;

	public GameObject levelLoader;


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
					levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
				else if(thisIndex == 1)
                {
					optionsMenu.SetActive(true);
					mainMenu.SetActive(false);
					menuButtonController.index = 0;
                }
				else if(thisIndex == 2)
                {
					Debug.Log("Quit!");
					Application.Quit();
                }
			
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
