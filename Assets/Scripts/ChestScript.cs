using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    public Animator animator;

    public string TagName;
    public GameObject[] objects;
    public Transform spawnPoint;
    private bool chestOpened = false;
    private bool canOpen = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagName && Input.GetKeyDown(KeyCode.E) && !chestOpened)
        {
            OpenChest();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenChest()
    {
        chestOpened = true;
        animator.SetBool("ChestOpen", true);
    }
}
