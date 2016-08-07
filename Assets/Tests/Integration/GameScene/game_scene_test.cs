using UnityEngine;
using System.Collections;
using TestHelpers;
using Flexo;

namespace SpaceGame.Tests.GameSceneTests
{

    public class game_scene_test : UTestCase
    {

        protected GameObject game_scene_object;
        protected GameScene game_scene;

        public override void SetUp ()
        {
            game_scene_object = GameObject.Find( "GameScene" );
            game_scene = game_scene_object.GetComponent<GameScene>();
        }
    }
}
