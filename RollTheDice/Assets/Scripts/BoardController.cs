using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SettlersEngine;
using System.Drawing;

namespace GMTK2020
{
    public enum CritterType
    {
        enemy,
        player,
        wall,
        empty,
        end,
        upgrade
    }
    public class BoardController : MonoBehaviour
    {
        public static BoardController Instance;

        public int GridSizeX, GridSizeY;
        public List <Enemy> Enemies = new List<Enemy>();
        public List <Wall> Walls = new List<Wall>();
        public List<Upgrade> Upgrades = new List<Upgrade>();
        BoardController():base()
        {
            if (Instance == null) Instance = this;
        }

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
            if ( x <= 0 || y <= 0 || x > GridSizeX || y > GridSizeY ) return true;
            if (Player.Instance.GridPositionX == x && Player.Instance.GridPositionY == y) return true;
            foreach ( Enemy enemy in Enemies ) if ( enemy.GridPositionX == x && enemy.GridPositionY == y ) return true;
            foreach ( Wall wall in Walls ) if ( wall.GridPositionX == x && wall.GridPositionY == y ) return true;
            return false;
		}

        public CritterType isOccupiedTileType(int x, int y)
        {
            if (x <= 0 || y <= 0 || x > GridSizeX || y > GridSizeY) return CritterType.end;
            if (Player.Instance.GridPositionX == x && Player.Instance.GridPositionY == y) return CritterType.player;
            foreach (Enemy enemy in Enemies) if (enemy.GridPositionX == x && enemy.GridPositionY == y) return CritterType.enemy;
            foreach (Wall wall in Walls) if (wall.GridPositionX == x && wall.GridPositionY == y) return CritterType.wall;
            foreach (Upgrade upgrade in Upgrades) if (upgrade.GridPositionX == x && upgrade.GridPositionY == y) return CritterType.upgrade;
            return CritterType.empty;
        }
        public DiceSideType CheckUpgrade(int x,int y)
        {
            foreach (Upgrade upgrade in Upgrades) if (upgrade.GridPositionX == x && upgrade.GridPositionY == y) return upgrade.upgradeType;
            return DiceSideType.Empty;
        }
        public Upgrade GetUpgrade(int x, int y)
        {
            foreach (Upgrade upgrade in Upgrades) if (upgrade.GridPositionX == x && upgrade.GridPositionY == y) return upgrade;
            return null;
        }

        public Enemy GetEnemyIfHere (int x, int y)
		{
            foreach (Enemy enemy in Enemies) {  if (enemy.GridPositionX == x && enemy.GridPositionY == y)  return enemy; }
            return null;
		}


        // Start is called before the first frame update
        void Start () {}

        // Update is called once per frame
        void Update () {}


       public static CritterType[,] CreateBoard()
       {
            CritterType[,] board = new CritterType[Instance.GridSizeY,Instance.GridSizeX];

            for(int i = 0; i< Instance.GridSizeY; i++)
            {
                for(int j = 0; j < Instance.GridSizeX; j++)
                {
                    board[i, j] = CritterType.empty;
                }
            }
            board[Player.Instance.GridPositionY, Player.Instance.GridPositionX] = CritterType.player;
            foreach (Enemy enemy in Instance.Enemies) board[enemy.GridPositionY,enemy.GridPositionX]=CritterType.enemy;

            foreach (Wall wall in Instance.Walls)
            {
                board[wall.GridPositionY, wall.GridPositionX] = CritterType.wall;
            }

            return board;
       }
	}
}
