using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace GMTK2020
{
    public enum DiceSideType
    {
        Empty,
        Attack,
        Defense,
        Cleave,
        Charge
    }

    public class PlayerDiceSide : MonoBehaviour
    {
        public DiceSideType Type = DiceSideType.Empty;
        public int Level = 1;
        public bool IsCursed = false;

		// Start is called before the first frame update
		void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        public void LevelUp ()
		{
            Level++;
		}

        public void SetCurse () => IsCursed = true;
        public void RemoveCurse () => IsCursed = false;

        public void ExecuteEffect (int positionX, int positionY, key direction)
		{
            if (IsCursed)
			{
                // do graphics
                Player.Instance.DecreaseHealth ();
                return;
			}

            //Debug.Log(BoardController.Instance.isOccupiedTileType(positionX, positionY));
            if ( Type == DiceSideType.Empty ) return;

            else if ( Type == DiceSideType.Attack )
            {
                // do graphics
                Enemy enemy = null;
                if ( direction == key.w ) enemy= BoardController.Instance.GetEnemyIfHere ( positionX, positionY + 1 );
                else if ( direction == key.s) enemy = BoardController.Instance.GetEnemyIfHere ( positionX, positionY - 1 );
                else if ( direction == key.a) enemy = BoardController.Instance.GetEnemyIfHere ( positionX - 1, positionY );
                else if ( direction == key.d) enemy = BoardController.Instance.GetEnemyIfHere ( positionX + 1, positionY );

                if (enemy == null) { return; }

                enemy.DecreaseHealth ( Level );
            }

            else if ( Type == DiceSideType.Defense)
			{
                // do graphics
                Player.Instance.Shield = Level;
			}

            else if ( Type == DiceSideType.Cleave )
            {
                // do graphics
                List<Point> fieldsEffected = new List<Point> ();
                if ( Level == 1 )
                {
                    if ( direction == key.w ) fieldsEffected.Add ( new Point ( positionX, positionY + 1 ) );
                    if ( direction == key.w || direction == key.d ) fieldsEffected.Add ( new Point ( positionX + 1, positionY + 1 ) );
                    if ( direction == key.d ) fieldsEffected.Add ( new Point ( positionX + 1, positionY ) );
                    if ( direction == key.d || direction == key.s ) fieldsEffected.Add ( new Point ( positionX + 1, positionY - 1 ) );
                    if ( direction == key.s ) fieldsEffected.Add ( new Point ( positionX, positionY - 1 ) );
                    if ( direction == key.s || direction == key.a ) fieldsEffected.Add ( new Point ( positionX - 1, positionY - 1 ) );
                    if ( direction == key.a ) fieldsEffected.Add ( new Point ( positionX - 1, positionY ) );
                    if ( direction == key.a || direction == key.w ) fieldsEffected.Add ( new Point ( positionX - 1, positionY + 1 ) );
                }
                else
                {
                    fieldsEffected.Add ( new Point ( positionX, positionY + 1 ) );
                    fieldsEffected.Add ( new Point ( positionX + 1, positionY + 1 ) );
                    fieldsEffected.Add ( new Point ( positionX + 1, positionY ) );
                    fieldsEffected.Add ( new Point ( positionX + 1, positionY - 1 ) );
                    fieldsEffected.Add ( new Point ( positionX, positionY - 1 ) );
                    fieldsEffected.Add ( new Point ( positionX - 1, positionY - 1 ) );
                    fieldsEffected.Add ( new Point ( positionX - 1, positionY ) );
                    fieldsEffected.Add ( new Point ( positionX - 1, positionY + 1 ) );
                }
                foreach (Point fieldEffected in fieldsEffected )
                {
                    Enemy enemy = BoardController.Instance.GetEnemyIfHere ( fieldEffected.X, fieldEffected.Y );
                    if ( enemy == null ) continue;
                    enemy.DecreaseHealth ();
                }
            }

            else if (Type == DiceSideType.Charge)
			{
                Point currentTile = new Point ( positionX, positionY );
                Point nextTile = new Point ( positionX, positionY );

                if ( direction == key.w ) nextTile.Y++;
                else if ( direction == key.s ) nextTile.Y--;
                else if ( direction == key.a ) nextTile.X--;
                else if ( direction == key.d ) nextTile.X++;
                while (!BoardController.Instance.isOccupiedTile(nextTile.X, nextTile.Y))
				{
                    // do charging through here graphic
                    if ( direction == key.w )
                    {
                        Player.Instance.MoveUp ();
                        currentTile.Y++;
                        nextTile.Y++;
                    }
                    else if ( direction == key.s )
                    {
                        Player.Instance.MoveDown ();
                        currentTile.Y--;
                        nextTile.Y--;
                    }
                    else if ( direction == key.a )
                    {
                        Player.Instance.MoveLeft ();
                        currentTile.X--;
                        nextTile.X--;
                    }
                    else if ( direction == key.d )
                    {
                        Player.Instance.MoveRight ();
                        currentTile.X++;
                        nextTile.X++;
                    }
                }

                Enemy enemy = BoardController.Instance.GetEnemyIfHere ( nextTile.X, nextTile.Y );
                if (enemy != null)
				{
                    enemy.DecreaseHealth ( 2 );
                    Player.Instance.DecreaseHealth ();
				}

                PlayerDiceSide newSideUp = Player.Instance.GetTopSide ();
                if ( newSideUp != null && newSideUp.Type != DiceSideType.Charge )
                    newSideUp.ExecuteEffect (currentTile.X, currentTile.Y, direction);
            }
        }
    }
}
