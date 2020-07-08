using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBehaviour : MonoBehaviour
{
    private AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
        StartCoroutine(UpdateState());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(gameObject.activeInHierarchy == true)
        {
            AS.Play();
        }
        */
    }

    IEnumerator UpdateState()
    {
        if(gameObject.activeInHierarchy)
        {
            AS.Play();
        }
        yield return null;
    }
}
