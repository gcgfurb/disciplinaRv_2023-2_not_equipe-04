using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Mareviva.UI
{
    public class UI_System : MonoBehaviour
    {
        [Header("Main Properties")]
        public UI_Screen m_StartScreen;

        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();


        [Header("Fader Properties")]
        public Image m_Fader;
        public float fadeDuration = 1f;


        //region variables
        [Header("Screens")]
        private Component[] screens = new Component[0];
        
        public UI_Screen currentScreen;
        public UI_Screen previousScreen;
        //public UI_Screen CurrentScreen { get { return currentScreen; } }
        //public UI_Screen PreviousScreen { get { return previousScreen; } }

        //endregion


        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UI_Screen>(true);
            InitializeScreens();

            if (m_StartScreen)
            {
                SwitchScreen(m_StartScreen);
            }

            if (m_Fader)
            {
                m_Fader.gameObject.SetActive(true);
            }
            FadeIn();

        }

        public void FadeIn()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, fadeDuration, false);
            }
        }

        public void FadeOut()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(1f, fadeDuration, false);
            }
        }

        public void SwitchScreen(UI_Screen screen)
        {
            Debug.Log("new "+screen.name);
            if (screen)
            {
                if (currentScreen)
                {
                    Debug.Log("current "+currentScreen.name);
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }
                currentScreen = screen;
                Debug.Log("newcur "+currentScreen.name);
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();
                if (onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }
            }
        }

        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreen(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        void InitializeScreens()
        {
            foreach(var screen in screens)
            {
                screen.gameObject.SetActive(true);
            }
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Example-Scene-01");
            //SceneManager.LoadScene(1);
        }

    }

}
