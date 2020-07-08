using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disclaimer : MonoBehaviour
{
    private static bool disclaimerBool = false;
    public GameObject disclaimerWindow;
    // Start is called before the first frame update
    void Start()
    {
        //disclaimerBool = true;
        if ((disclaimerBool))
        {
            disclaimerWindow.SetActive(false);
        }
    }

    public void SetDisclaimerBool(bool setB)
    {
        disclaimerBool = setB;
    }

    public void GotIt()
    {
        disclaimerWindow.SetActive(false);
    }

}
