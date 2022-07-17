using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class Enemy : Critter
    {
		public void MoveOrAttack ()
		{
			int directionX = Player.Instance.GridPositionX - GridPositionX;
			int directionY = Player.Instance.GridPositionY - GridPositionY;
			bool nextToPlayer = Mathf.Abs ( directionX ) + Mathf.Abs ( directionY ) <= 1;

			if ( nextToPlayer ) AttackPlayer ();
			else Move ();
		}

		// Move towards Player
		public void Move ()
		{
			int directionX = Player.Instance.GridPositionX - GridPositionX;
			int directionY = Player.Instance.GridPositionY - GridPositionY;

			bool canMoveLeft = !BoardController.Instance.isOccupiedTile ( GridPositionX - 1, GridPositionY );
			bool canMoveRight = !BoardController.Instance.isOccupiedTile ( GridPositionX + 1, GridPositionY );
			bool canMoveUp = !BoardController.Instance.isOccupiedTile ( GridPositionX, GridPositionY + 1 );
			bool canMoveDown = !BoardController.Instance.isOccupiedTile ( GridPositionX, GridPositionY - 1 );

			if ( canMoveUp && directionY > Mathf.Abs ( directionX ) ) MoveUp ();
			else if ( canMoveDown && -directionY > Mathf.Abs ( directionX ) ) MoveDown ();
			else if ( canMoveLeft && directionX < 0 ) MoveLeft ();
			else if ( canMoveRight && directionY > 0 ) MoveRight ();
		}

		public void AttackPlayer ()
		{
			Player.Instance.DecreaseHealth ();
		}
	}
}
