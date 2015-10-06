using UnityEngine;
using System;

namespace HattoriGame2.Core.Components
{
    /// <summary>
    /// Event interface for common MonoBehavior messages
    /// </summary>
    [AddComponentMenu("Hattori Game 2/Core/Game Object Lifetime")]
    [DisallowMultipleComponent]
    public class GameObjectLifetimeComponent : MonoBehaviour
    {
        public static event Action<GameObjectLifetimeComponent> OnAnyAwake;
        public static event Action<GameObjectLifetimeComponent> OnAnyStart;
        public static event Action<GameObjectLifetimeComponent> OnAnyEnabled;
        public static event Action<GameObjectLifetimeComponent> OnAnyDisabled;
        public static event Action<GameObjectLifetimeComponent> OnAnyUpdate;
        public static event Action<GameObjectLifetimeComponent> OnAnyLateUpdate;
        public static event Action<GameObjectLifetimeComponent> OnAnyFixedUpdate;
        public static event Action<GameObjectLifetimeComponent> OnAnyDestroyed;

        public event Action<GameObjectLifetimeComponent> OnAwake;
        public event Action<GameObjectLifetimeComponent> OnStart;
        public event Action<GameObjectLifetimeComponent> OnEnabled;
        public event Action<GameObjectLifetimeComponent> OnDisabled;
        public event Action<GameObjectLifetimeComponent> OnUpdate;
        public event Action<GameObjectLifetimeComponent> OnLateUpdate;
        public event Action<GameObjectLifetimeComponent> OnFixedUpdate;
        public event Action<GameObjectLifetimeComponent> OnDestroyed;

        public void Awake ()
        {
            if (enabled)
            {
                if (OnAnyAwake != null)
                {
                    OnAnyAwake (this);
                }

                if (OnAwake != null)
                {
                    OnAwake (this);
                }
            }
        }

        public void Start()
        {
            if (enabled)
            {
                if (OnAnyStart != null)
                {
                    OnAnyStart (this);
                }

                if (OnStart != null)
                {
                    OnStart (this);
                }
            }
        }

        public void OnEnable()
        {
            if (OnAnyEnabled != null)
            {
                OnAnyEnabled (this);
            }

            if (OnEnabled != null)
            {
                OnEnabled (this);
            }
        }

        public void OnDisable()
        {
            if (OnAnyDisabled != null)
            {
                OnAnyDisabled (this);
            }

            if (OnDisabled != null)
            {
                OnDisabled (this);
            }
        }

        public void Update()
        {
            if (OnAnyUpdate != null)
            {
                OnAnyUpdate (this);
            }

            if (OnUpdate != null)
            {
                OnUpdate (this);
            }
        }

        public void LateUpdate ()
        {
            if (OnAnyLateUpdate != null)
            {
                OnAnyLateUpdate (this);
            }

            if (OnLateUpdate != null)
            {
                OnLateUpdate (this);
            }
        }

        public void FixedUpdate ()
        {
            if (OnAnyFixedUpdate != null)
            {
                OnAnyFixedUpdate (this);
            }

            if (OnFixedUpdate != null)
            {
                OnFixedUpdate (this);
            }
        }

        public void OnDestroy()
        {
            if (OnAnyDestroyed != null)
            {
                OnAnyDestroyed (this);
            }

            if (OnDestroyed != null)
            {
                OnDestroyed (this);
            }
        }
    }
}