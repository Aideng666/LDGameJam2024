using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyTransition
{
    public class SceneTransitions : MonoBehaviour
    {
        public TransitionSettings transition;
        public float startDelay;

        public void LoadScene(string sceneName)
        {
            TransitionManager.Instance().Transition(sceneName, transition, startDelay);
        }
    }
}