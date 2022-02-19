using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{

    [SerializeField]Animator m_Animator;
    CharacterController cc;
    [SerializeField]GameObject jumpArea;
    PlayerController playerController;
    private Vector3 direction;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
        playerController.enabled = true;
        cc.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            StartCoroutine(StartSwinging());
        }
    }

    IEnumerator StartSwinging()
    {
        direction = m_Animator.deltaPosition;
        cc.Move(direction * Time.deltaTime);

        m_Animator.SetTrigger("swing");
        cc.enabled = false;
        yield return new WaitForSeconds(2.3f);
        cc.enabled = true;
        m_Animator.SetBool("afterSwing", true);
        Destroy(jumpArea);
    }

}
