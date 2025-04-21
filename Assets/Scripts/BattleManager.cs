using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CombatSystem
{
    public class BattleManager : MonoBehaviour
    {
        //Reference to all characters inside scene
        [SerializeField]
        private List<Character> characterList;
        private int _totalAliveCharacters;
        private bool _isBattleOver;
        [SerializeField]
        private BattleUIController _battleUIController;

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
        private void Start()
        {
            //if list is not empty, initially all characters in list are alive 
            _totalAliveCharacters = characterList!=null? characterList.Count : 0;
            _isBattleOver = false;
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
        //On any character death, check battle over condition 
        public void OnCharacterDeath(Character character)
        {
            if (!character.IsAlive)
                _totalAliveCharacters--;
            if(_totalAliveCharacters<=1 && !_isBattleOver)
            {
                DeclareWinner();
            }
        }
        //Search the last alive character and declare it winner 
        private void DeclareWinner()
        {
            _isBattleOver = true;
            string battleWinMessage = "Opps..! No one win the battle.";
            Character winner = characterList.Find(c => c.IsAlive);
            if (winner != null)
            {
                battleWinMessage = "Congratulations " + winner.name + "! \n\nYou won the battle.";                
            }
            Debug.Log(battleWinMessage);
            _battleUIController.ShowBattleOverPopup(battleWinMessage);
        }
    }

}