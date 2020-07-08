using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PasswordInputFieldToggler : MonoBehaviour
{
    public UnityEngine.UI.InputField passwordInput = null;

    public void ToggleInputType()
    {
        if (this.passwordInput != null)
        {
            if (this.passwordInput.contentType == InputField.ContentType.Password)
            {
                this.passwordInput.contentType = InputField.ContentType.Standard;
            }
            else
            {
                this.passwordInput.contentType = InputField.ContentType.Password;
            }

            this.passwordInput.ForceLabelUpdate();
        }
    }
}
