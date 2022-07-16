using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class Critter : MonoBehaviour
    {
        protected int _gridPositionX, _gridPositionY;

        protected int _startHealth;
        protected int _maxHealth;
        protected int _health;

        public int GridPositionX { get => _gridPositionX; set => _gridPositionX = value; }
        public int GridPositionY { get => _gridPositionY; set => _gridPositionY = value; }
        public int StartHealth { get => _startHealth; set => _startHealth = value; }
        public int MaxHealth { get => _maxHealth; }
        public int Health { get => _health; }

        public virtual void Initialize ()
        {
            _maxHealth = _startHealth;
            _health = _maxHealth;
        }

        public void MoveLeft () => _gridPositionX--;
        public void MoveRight () => _gridPositionX++;
        public void MoveUp () => _gridPositionY++;
        public void MoveDown () => _gridPositionY--;

        public void IncreaseHealth ()
        {
            if ( _health < _maxHealth ) _health++;
        }

        public void DecreaseHealth ()
        {
            if ( _health > 0 ) _health--;
        }

        public void IncreaseMaxHealth ()
        {
            _maxHealth++;
            _health++;
        }

        // Start is called before the first frame update
        void Start ()
        {
            Initialize ();
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}
