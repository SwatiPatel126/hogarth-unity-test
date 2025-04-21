using System.Collections;
using UnityEngine;

namespace CombatSystem
{
    public class Character : MonoBehaviour
    {
        public bool IsAlive;

        [SerializeField]
        private int _maxHealth = 100;
        private int _health;
        [SerializeField]
        private float _moveSpeed = 2.5f;
        [SerializeField]
        private float _rotationSpeed = 6f;
        [SerializeField]
        private Weapon _weapon;
        [SerializeField]
        private Collider _collider;
        private Character currentTarget;

        void Start()
        {
            IsAlive = true;
            currentTarget = null;
            _health = _maxHealth;
            StartCoroutine(CharacterBattle());
        }

        void Update()
        {
            //When target is assigned, character continuously look at and move target until target comes in weapon range
            if (currentTarget != null && currentTarget.IsAlive)
            {
                RotateTowardsTarget(currentTarget.transform.position);
                MoveTowardsTarget(currentTarget.transform.position);
            }
        }
        //Rotate character towards target
        private void RotateTowardsTarget(Vector3 targetPosition)
        {
            Vector3 dir = (targetPosition - transform.position).normalized;
            dir.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
        }
        //Move character towards target
        private void MoveTowardsTarget(Vector3 targetPosition)
        {
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance > _weapon.Range)
            {
                transform.position += transform.forward * _moveSpeed * Time.deltaTime;
            }
        }
        //Health calculation when damage occured to character
        public void DamageHealth(int damage)
        {
            _health-=damage;
            if (_health <= 0)
                Die();
        }
        //After zero or negative health, character will die
        private void Die()
        {
            IsAlive=false;
            _collider.enabled = false;
            gameObject.SetActive(false);
            BattleManager.Instance.OnCharacterDeath(this);
        }
        //Coroutine which will be executed until character alive. Continously character attacks on target, if target dies, character look for another target
        IEnumerator CharacterBattle()
        {
            yield return new WaitForSeconds(Random.Range(0f, 1.5f));
            while (IsAlive)
            {
                if (currentTarget == null || !currentTarget.IsAlive)
                {
                    currentTarget = BattleManager.Instance.GetRandomTargetFor(this);
                }
                if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.transform.position) <= _weapon.Range)
                {
                    _weapon.Attack();
                }
                yield return new WaitForSeconds(_weapon.AttackSpeed);
            }
        }
    }
}