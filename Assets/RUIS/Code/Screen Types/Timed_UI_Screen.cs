using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RUIS.UI
{
    public class Timed_UI_Screen : UI_Screen
    {
        #region Variables
        [Header("Timed Screen Properties")]
        public float m_ScreenTime = 2f;
        public UnityEvent onTimeCompleted = new UnityEvent();

        public UnityEvent logInScreenSwitch;
        public UnityEvent menuScreenSwitch;

        public UI_Screen logInScreen;
        public UI_Screen menuScreen;

        private float startTime;

        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Helper Methods
        public override void StartScreen()
        {
            base.StartScreen();

            startTime = Time.time;
            StartCoroutine(WaitForTime());
        }

        public void PostWaitScreen()
        {
            if (!GameObject.Find("StartSceneController").GetComponent<GlobalSettingsControl>().loggedInBool)//Load LogIn Screen
            {
                logInScreenSwitch.Invoke();
                //UnityEventTools.RegisterObjectPersistentListener<UI_Screen>(onTimeCompleted, 0, UISystem.GetComponent<UI_System>().SwitchScreens, logInScreen);
                Debug.Log("unregistered PetChoiceScreen");
            }
            else if (GameObject.Find("StartSceneController").GetComponent<GlobalSettingsControl>().loggedInBool)//Load PetChoice Screen
            {
                menuScreenSwitch.Invoke();
                //UnityEventTools.RegisterObjectPersistentListener<UI_Screen>(onTimeCompleted, 0, UISystem.GetComponent<UI_System>().SwitchScreens, petChoiceScreen);
                Debug.Log("unregistered LogInScreen");
            }
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(m_ScreenTime);

            if(onTimeCompleted != null)
            {
                onTimeCompleted.Invoke();
            }
            PostWaitScreen();
        }
        #endregion
    }
}