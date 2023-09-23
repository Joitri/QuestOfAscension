using UnityEngine;

namespace IdleGame.Combat {
    public class PlayerStateMachineCheck
    {
        private static float objectSpeed => GameManager.IsNormalSpeed == true ? 1f : 2f;
        public static ActorDefinition player;

        /// <summary>
        /// Used For BackgroundController.cs
        /// </summary>
        /// <param name="gameObject"></param>
        public static void BackgroundProgression(GameObject gameObject)
        {
            player = GameObject.Find("Player").GetComponent<ActorDefinition>();
            var playerState = player.state;
            switch (playerState)
            {
                case ActorDefinition.STATE.WALK:
                    gameObject.transform.Translate(Vector2.left * (objectSpeed * Time.deltaTime), Space.World);
                    break;
                default:
                    break;
            }
        }
    }
}