using UnityEngine;
using System.Collections.Generic;

namespace CombatSystem
{
    public class BattleManager : MonoBehaviour
    {
        //Reference to all characters inside scene
        [SerializeField]
        private List<Character> characterList;

        //Singleton
        private static BattleManager _instance;
        public static BattleManager Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(_instance);
        }
        //Returns random alive target 
        public Character GetRandomTargetFor(Character player)
        {
            List<Character> aliveCharacters = characterList.FindAll(c => c.IsAlive && c != player);
            if(aliveCharacters.Count<=0)
                return null;
            Character target = aliveCharacters[Random.Range(0, aliveCharacters.Count)];
            return target;
        }
    }

}