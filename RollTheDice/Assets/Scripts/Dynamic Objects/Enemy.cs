using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class Enemy : Critter
    {
		// Move towards Player
		public void Move ()
		{
			int directionX = Player.Instance.GridPositionX - GridPositionX;
			int directionY = Player.Instance.GridPositionY - GridPositionY;

			if ( directionY > Mathf.Abs ( directionX ) ) MoveUp ();
			else if ( - directionY > Mathf.Abs ( directionX ) ) MoveDown ();
			else if (directionX < 0) MoveLeft ();
			else if (directionY > 0) MoveRight ();
		}
	}
}
