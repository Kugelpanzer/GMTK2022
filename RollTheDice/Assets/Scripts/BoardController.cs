using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance;

        public int GridSizeX, GridSizeY;
        public List <Enemy> Enemies = new ();
        public List <Wall> Walls = new ();

        private void Awake ()
        {
            if ( Instance == null ) Instance = this;
        }

        public void ExecuteEnemiesTurn ()
		{
            foreach ( Enemy enemy in Enemies ) enemy.MoveOrAttack ();
		}

        public bool isOccupiedTile (int x, int y)
		{
            if ( x <= 0 || y <= 0 || x > GridSizeX || y > GridSizeY ) return false;
            if (Player.Instance.GridPositionX == x && Player.Instance.GridPositionY == y) return true;
            foreach ( Enemy enemy in Enemies ) if ( enemy.GridPositionX == x && enemy.GridPositionY == y ) return true;
            foreach ( Wall wall in Walls ) if ( wall.GridPositionX == x && wall.GridPositionY == y ) return true;
            return false;
		}

        // Start is called before the first frame update
        void Start () {}

        // Update is called once per frame
        void Update () {}
    }
}
