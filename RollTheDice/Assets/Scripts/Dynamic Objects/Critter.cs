using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class Critter : MonoBehaviour
    {
        public int GridPositionX, GridPositionY;

        public int StartHealth;
        private int _maxHealth;
        private int _health;

        public int MaxHealth { get { return _maxHealth; } }
        public int Health { get { return _health; } }

        public int Shield = 0;

        public virtual void Initialize ()
        {
            _maxHealth = StartHealth;
            _health = _maxHealth;
        }

        public void MoveLeft () => GridPositionX--;
        public void MoveRight () => GridPositionX++;
        public void MoveUp () => GridPositionY++;
        public void MoveDown () => GridPositionY--;

        public void IncreaseHealth ()
        {
            if ( _health < _maxHealth ) _health++;
        }

        public void DecreaseHealth ()
        {
            if ( Shield > 0 ) Shield--;
            else if ( _health > 0 ) _health--;
            if (_health < 0)
            {
                
            }
        }

        public void DecreaseHealth (int decrement)
        {
            _health = Mathf.Max ( 0, _health - decrement );
        }

        public void IncreaseMaxHealth ()
        {
            _maxHealth++;
            _health++;
        }

        public bool IsAlive () => _health > 0;

		public void Awake ()
		{
            Initialize ();
		}


    }
}
