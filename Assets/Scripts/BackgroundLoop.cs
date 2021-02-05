using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public GameObject fbackground;
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Debug.Log(screenBounds + "screenBounds");
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj, fbackground);
        }
    }

    void loadChildObjects(GameObject obj, GameObject first)
    {
        float firstObjecthalfWidth = first.GetComponent<SpriteRenderer>().bounds.extents.x;
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(objectWidth + "objectWidth");
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        Debug.Log(childsNeeded + "childsNeeded");
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(c.GetComponent<SpriteRenderer>().bounds.extents.x+((first.transform.position.x + first.GetComponent<SpriteRenderer>().bounds.extents.x)+objectWidth *i), obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void RePositionChildObject(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject FirstChild = children[1].gameObject;
            GameObject LastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = LastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if (transform.position.x + screenBounds.x > LastChild.transform.position.x + halfObjectWidth)
            {
                FirstChild.transform.SetAsLastSibling();
                FirstChild.transform.position = new Vector3(LastChild.transform.position.x + halfObjectWidth *2 , LastChild.transform.position.y , LastChild.transform.position.z);
                
            }else if (transform.position.x - screenBounds.x < FirstChild.transform.position.x - halfObjectWidth)
            {
                LastChild.transform.SetAsFirstSibling();
                LastChild.transform.position = new Vector3(FirstChild.transform.position.x - halfObjectWidth * 2, FirstChild.transform.position.y, FirstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            RePositionChildObject(obj);
        }
    }
}