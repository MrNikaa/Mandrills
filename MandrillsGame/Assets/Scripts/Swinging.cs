using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{

    [SerializeField] Animator m_Animator;
    CharacterController cc;
    [SerializeField] GameObject jumpArea;
    PlayerController playerController;
    [SerializeField] GameObject gameObject;



    
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
        playerController.enabled = true;
        cc.enabled = true;
    }

    private void Update()
    {

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
        m_Animator.SetTrigger("swing");
        cc.enabled = false;
        yield return new WaitForSeconds(2.3f);
        cc.enabled = true;
        m_Animator.SetBool("afterSwing", true);

        Destroy(jumpArea);
    }

    void MoveWhileSwinging(float amountToAdd){
        transform.Translate(amountToAdd,0,0 * Time.deltaTime);        
    }

}
