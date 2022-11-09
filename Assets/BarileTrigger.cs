using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging; 

public class BarileTrigger : InteractableObject
{
    public GameObject rightArmPin;
    public GameObject leftArmPin;
    private Transform _player;
    public GameObject rightArmIK;
    public GameObject leftArmIK;
    public GameObject barile;
    public GameObject destinationTrigger; 
    public Rig rig; 
    public bool enableRig = false;
    private float transitionSpeed = 2f; 
     

    public override bool Interact()
    {
        if (!_player.GetComponent<PadreController_RetroAzienda>()._isRightForward) {

            //disabilito lo spostamento all'indietro e salto del player
            _player.GetComponent<PadreController_RetroAzienda>().DisableBackward();
            _player.GetComponent<PadreController_RetroAzienda>().DisableJump();
            _player.GetComponent<PadreController_RetroAzienda>().DisableRun();
            _player.GetComponent<PadreController_RetroAzienda>().maxVelocity = 1f;

            Sequence mySequence = DOTween.Sequence()
                .Append(_player.DOLookAt(barile.transform.position, 0.8f, AxisConstraint.Y, Vector3.up).OnComplete(()=>
                {
                    _player.GetComponent<PadreController_RetroAzienda>().curTarDirection = Vector3.back;
                    _player.GetComponent<PadreController_RetroAzienda>()._isRightForward = true;
                }))
                .Append(_player.DOLookAt(barile.transform.position, 0.8f, AxisConstraint.Y, Vector3.up).OnComplete(() =>
                {
                    //sposto il target IK lungo il bordo del barile
                    rightArmIK.transform.position = rightArmPin.transform.position;
                    leftArmIK.transform.position = leftArmPin.transform.position;
                    barile.transform.parent = _player;

                    //disabilito la rotazione del barile
                    barile.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                    barile.GetComponent<Rigidbody>().isKinematic = true;

                    //abilito animazione di PushStart/Pushing in base alla velocità del player
                    _player.GetComponent<Animator>().SetTrigger("spingiBarile");
                    _player.GetComponent<Animator>().SetBool("isPushing", true);

                    //abilito il peso di IK 
                    enableRig = true;

                    barile.GetComponent<PushingRotation>().isPushing = true;
                    destinationTrigger.GetComponent<BoxCollider>().enabled = true;
                }));
        }
        else
        {
            //sposto il target IK lungo il bordo del barile
            rightArmIK.transform.position = rightArmPin.transform.position;
            leftArmIK.transform.position = leftArmPin.transform.position;
            barile.transform.parent = _player;

            //disabilito lo spostamento all'indietro e salto del player
            _player.GetComponent<PadreController_RetroAzienda>().DisableBackward();
            _player.GetComponent<PadreController_RetroAzienda>().DisableJump();
            _player.GetComponent<PadreController_RetroAzienda>().DisableRun();
            _player.GetComponent<PadreController_RetroAzienda>().maxVelocity = 1f;


            //disabilito la rotazione del barile
            barile.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            barile.GetComponent<Rigidbody>().isKinematic = true;

            //abilito animazione di PushStart/Pushing in base alla velocità del player
            _player.GetComponent<Animator>().SetTrigger("spingiBarile");
            _player.GetComponent<Animator>().SetBool("isPushing", true);

            //abilito il peso di IK 
            enableRig = true;

            barile.GetComponent<PushingRotation>().isPushing = true;
            destinationTrigger.GetComponent<BoxCollider>().enabled = true;
        }

        this.interactable = false;
        return true;
    }

    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        if (enableRig)
        {
            if( rig.weight < 1f )
                rig.weight += transitionSpeed * Time.deltaTime;
            else if( rig.weight >= 1f)
            {
                enableRig = false; 
            }
        }
    }
}
