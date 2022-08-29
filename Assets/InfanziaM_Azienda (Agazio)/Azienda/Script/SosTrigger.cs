using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SosTrigger : MonoBehaviour
{
    private GameObject _player;
    public GameObject cassettiera;
    public GameObject bloccoPassaggio;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            PlayerController_Agazio _pController = _player.GetComponent<PlayerController_Agazio>();

            //stacco la cassettira dalla bambina
            cassettiera.transform.parent = null;
            _pController.EnableBackward();
            _pController.EnableJump();

            //non è più dietro la cassettiera
            _pController._isBehindChest = false;

            //aggiorno la direzione forward della bambina (parallela al muro)
            _pController.SetTargetDirection(this.transform.right);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if( other.gameObject.name == "PlayerArmature")
        {
            GameObject.Destroy(this.gameObject);
            bloccoPassaggio.SetActive(true);
        }
    }
}
