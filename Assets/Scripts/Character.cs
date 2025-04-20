using UnityEngine;

namespace CombatSystem
{
    public class Character : MonoBehaviour
    {
        public int Health;
        [SerializeField]
        private float _moveSpeed = 2f;
        [SerializeField]
        private float _rotationSpeed = 5f;
        private Weapon _weapon;
        private bool _isAlive;
        [SerializeField]
        private Character currentTarget;

        void Start()
        {
            _isAlive = true;
            // currentTarget = null;
        }

        void Update()
        {
            if (currentTarget != null && currentTarget._isAlive)
            {
                RotateTowardsTarget(currentTarget.transform.position);
                MoveTowardsTarget(currentTarget.transform.position);
            }
        }

        private void RotateTowardsTarget(Vector3 targetPosition)
        {
            Vector3 dir = (targetPosition - transform.position).normalized;
            dir.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
        }

        private void MoveTowardsTarget(Vector3 targetPosition)
        {
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance > 5)// it should be outside weapon range
            {
                transform.position += transform.forward * _moveSpeed * Time.deltaTime;
            }
        }

        public void DamageHealth(int damage)
        {
            Health-=damage;
            if (Health <= 0)
                Die();
        }

        private void Die()
        {
            _isAlive=false;
            gameObject.SetActive(false);
        }
    }
}