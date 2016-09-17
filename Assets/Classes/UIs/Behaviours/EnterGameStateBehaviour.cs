using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Fletch;
using SpaceGame.Interfaces;
using SpaceGame.UI;
using SpaceGame.Events;

namespace SpaceGame.UI.Behaviours {
    public class EnterGameStateBehaviour : StateMachineBehaviour {

        // will call this gameUI
        public IGameUI gameUI;

        /// <summary>
        /// When entering this state, tell the GameUI to call the OnGameReady event.
        /// </summary>
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            gameUI.CallOnGameReady();
        }
    }
}
