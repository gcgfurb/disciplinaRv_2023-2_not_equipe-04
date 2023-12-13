using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Mareviva.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Canvas))]
    public class UI_Screen : MonoBehaviour
    {
        [Header("Main Properties")]
        public Selectable m_StartSelectable;

        [Header("ScreenEvents")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            if (m_StartSelectable)
            {
                EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
            }
        }

        public virtual void StartScreen()
        {
            if (onScreenStart != null)
            {
                onScreenStart.Invoke();
            }
            HandleAnimatior("show");
        }

        public virtual void CloseScreen()
        {
            if (onScreenClose != null)
            {
                onScreenClose.Invoke();
            }
            HandleAnimatior("hide");

        }

        void HandleAnimatior(string trigger)
        {
            if (animator)
            {
                animator.SetTrigger(trigger);
            }
        }
    }
}
