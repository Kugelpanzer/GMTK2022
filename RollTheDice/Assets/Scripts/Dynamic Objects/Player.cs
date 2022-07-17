using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
	public class Player : Critter
	{
		public DiceLogic dice = new DiceLogic();

		public static Player Instance;

		private new void Awake ()
		{
			if ( Instance == null ) Instance = this;
			base.Awake ();
		}

		public void OnMove ()
		{
			Shield--;
		}

		public new void MoveLeft ()
		{
			base.MoveLeft ();
			dice.Move ( key.a );
		}
		public new void MoveRight ()
		{
			base.MoveRight ();
			dice.Move ( key.d );
		}
		public new void MoveUp ()
		{
			base.MoveUp ();
			dice.Move ( key.w );
		}
		public new void MoveDown ()
		{
			base.MoveDown ();
			dice.Move ( key.s );
		}

		public PlayerDiceSide GetTopSide ()
		{
			// TODO
			return null;
		}
	}
}
