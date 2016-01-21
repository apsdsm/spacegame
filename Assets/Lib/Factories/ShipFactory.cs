using UnityEngine;
using SpaceGame.Interfaces;
using SpaceGame.Actors;
using SpaceGame.Agents;
using Fletch;

namespace SpaceGame.Factories
{
    public class ShipFactory : MonoBehaviour, IShipFactory
    {
        /// <summary>
        /// Instantiate and return a Player Ship object.
        /// </summary>
        /// <returns></returns>
        public IPhysical CreatePlayerShip ()
        {
            GameObject gameObject = InstantiateShip( "Prefabs/PlayerShip" );
            PlayerAgent agent = gameObject.GetComponent<PlayerAgent>();
            Player actor = agent.Actor;

            return actor;
        }


        /// <summary>
        /// Instantiate and return an Enemy Ship object.
        /// </summary>
        /// <returns></returns>
        public IPhysical CreateEnemyShip ()
        {
            GameObject gameObject = InstantiateShip( "Prefabs/EnemyShip" );
            EnemyAgent agent = gameObject.GetComponent<EnemyAgent>();
            Enemy actor = agent.Actor;

            return actor;
        }


        /// <summary>
        /// Instantiate the specified ship, with the factory as the parent.
        /// </summary>
        /// <param name="shipType">path to ship to instantiate</param>
        /// <returns>GameObject instantiated ship</returns>
        private GameObject InstantiateShip ( string shipType )
        {
            GameObject ship = Instantiate( Resources.Load( shipType, typeof( GameObject ) ) ) as GameObject;

            ship.transform.parent = transform;

            return ship;
        }
    }
}