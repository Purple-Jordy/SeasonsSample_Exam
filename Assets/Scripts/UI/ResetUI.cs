using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUI : MonoBehaviour
{

    public GameObject askUI;
    private Animator animator;

    private void Start()
    {
        animator = askUI.GetComponent<Animator>();  
    }

    public void OpenAsk()
    {
        AudioManager.Instance.Play("OptionButton");
        askUI.SetActive(true);
    }


    public void NoButton()
    {
        AudioManager.Instance.Play("OptionButton");
        StartCoroutine(AskOff());
    }


    IEnumerator AskOff()
    {
        animator.SetBool("ask", true);

        yield return new WaitForSeconds(0.3f);

        askUI.SetActive(false);
    }
}
