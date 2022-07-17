using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SettlersEngine;
using System.Drawing;

namespace GMTK2020
{
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance;

        public int GridSizeX, GridSizeY;
        public List <Enemy> Enemies = new List<Enemy>();
        public List <Wall> Walls = new List<Wall>();

        private void Awake ()
        {
            if ( Instance == null ) Instance = this;
            Enemy enemy = gameObject.AddComponent ( typeof ( Enemy ) ) as Enemy;
            enemy.GridPositionX = 7; enemy.GridPositionY = 2;
            Enemies.Add ( enemy );
            enemy.MoveOrAttack ();
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

        #region AStar
        public LinkedList<MyPathNode> FindPath ( Enemy enemy, Player player )
		{
            return FindPath ( enemy.GridPositionX, enemy.GridPositionY, player.GridPositionX, player.GridPositionY );
		}

        private LinkedList<MyPathNode> FindPath ( int startX, int startY, int endX, int endY )
        {
            MyPathNode [,] grid = SetupPathSearchGrid ();
            foreach ( MyPathNode node in grid ) Debug.Log ( node );
            MySolver<MyPathNode, System.Object> aStar = new MySolver<MyPathNode, System.Object> ( grid );
            LinkedList<MyPathNode> path = aStar.Search ( new Point ( startX - 1, startY - 1 ), new Point ( endX - 1, endY - 1 ), null );
            //foreach ( MyPathNode node in path ) Debug.Log ( node );
            return path;
        }

        private MyPathNode [,] SetupPathSearchGrid ()
		{
            MyPathNode [,] grid = new MyPathNode [GridSizeX, GridSizeY];

            for ( int x = 0; x < GridSizeX; x++ )
            {
                for ( int y = 0; y < GridSizeY; y++ )
                {
                    grid [x, y] = new MyPathNode ()
                    {
                        IsWall = false,
                        X = x,
                        Y = y,
                    };
                }
            }

            // Player
            {
                int x = Player.Instance.GridPositionX - 1;
                int y = Player.Instance.GridPositionY - 1;
                grid [x, y] = new MyPathNode () { IsWall = true, X = x, Y = y };
            }

            // Enemies
            foreach ( Enemy enemy in Enemies )
            {
                int x = enemy.GridPositionX - 1;
                int y = enemy.GridPositionY - 1;
                grid [x, y] = new MyPathNode () { IsWall = true, X = x, Y = y };
            }

            // Walls
            foreach ( Wall wall in Walls )
            {
                int x = wall.GridPositionX - 1;
                int y = wall.GridPositionY - 1;
                grid [x, y] = new MyPathNode () { IsWall = true, X = x, Y = y };
            }

            return grid;
        }
		#endregion
	}
}
