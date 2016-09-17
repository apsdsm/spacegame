using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.UI.Game {
    public class GameReadyBehaviour : StateMachineBehaviour {

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
