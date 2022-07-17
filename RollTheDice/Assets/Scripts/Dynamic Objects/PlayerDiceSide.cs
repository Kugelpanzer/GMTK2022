using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public enum DiceSideType
    {
        Empty,
        Attack,
        Defense
    }

    public class PlayerDiceSide : MonoBehaviour
    {
        public DiceSideType Type = DiceSideType.Empty;
        public int Level = 1;

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

        public void ExecuteEffect (int positionX, int positionY, key direction)
		{
            if ( Type == DiceSideType.Empty ) return;

            if ( Type == DiceSideType.Attack )
            {
                // do graphics
                Enemy enemy = null;
                if ( direction == key.w ) BoardController.Instance.GetEnemyIfHere ( positionX, positionY + 1 );
                else if ( direction == key.s ) BoardController.Instance.GetEnemyIfHere ( positionX, positionY - 1 );
                else if ( direction == key.a ) BoardController.Instance.GetEnemyIfHere ( positionX - 1, positionY );
                else if ( direction == key.d ) BoardController.Instance.GetEnemyIfHere ( positionX + 1, positionY );

                if ( enemy == null ) return;

                enemy.DecreaseHealth ( Level );
            }

            if (Type == DiceSideType.Defense)
			{
                Player.Instance.Shield = Level;
			}                
		}
    }
}
