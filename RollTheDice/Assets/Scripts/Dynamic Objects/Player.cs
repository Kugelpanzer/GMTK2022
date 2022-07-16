using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
	public class Player : Critter
	{
		private enum SideOrientation { Up, Left, Right, Down }

		private List<PlayerDiceSide> _sides = new List<PlayerDiceSide> ( 6 );
		private int _sideUpIndex = 1;
		private SideOrientation _sideOrientation = SideOrientation.Up;

		private static Player instance;
		public static Player Instance
        {
            get
            {
				if(instance = null)
                {
					instance = new Player();
                }

				return instance;
            }
        }

		public PlayerDiceSide GetSideUp ()
		{
			return _sides [_sideUpIndex];
		}
		public PlayerDiceSide GetSideDown ()
		{
			return _sides [5 - _sideUpIndex];
		}
		public PlayerDiceSide GetSideFront ()
		{
			return GetNextSide ( _sideUpIndex, _sideOrientation );
		}
		public PlayerDiceSide GetSideLeft ()
		{
			if ( _sideOrientation == SideOrientation.Up ) return GetNextSide ( _sideUpIndex, SideOrientation.Left );
			if ( _sideOrientation == SideOrientation.Left ) return GetNextSide ( _sideUpIndex, SideOrientation.Down );
			if ( _sideOrientation == SideOrientation.Right ) return GetNextSide ( _sideUpIndex, SideOrientation.Up );
			if ( _sideOrientation == SideOrientation.Down ) return GetNextSide ( _sideUpIndex, SideOrientation.Right );
			return null;
		}
		public PlayerDiceSide GetSideRight ()
		{
			if ( _sideOrientation == SideOrientation.Up ) return GetNextSide ( _sideUpIndex, SideOrientation.Right );
			if ( _sideOrientation == SideOrientation.Left ) return GetNextSide ( _sideUpIndex, SideOrientation.Up );
			if ( _sideOrientation == SideOrientation.Right ) return GetNextSide ( _sideUpIndex, SideOrientation.Down );
			if ( _sideOrientation == SideOrientation.Down ) return GetNextSide ( _sideUpIndex, SideOrientation.Left );
			return null;
		}
		public PlayerDiceSide GetSideBack ()
		{
			return GetNextSide ( _sideUpIndex, 3 - _sideOrientation );
		}

		private static PlayerDiceSide GetNextSide (int side, SideOrientation orientation)
		{
			if ( side == 1 )
			{
				if ( orientation == SideOrientation.Up ) return Instance._sides [3];
				if ( orientation == SideOrientation.Left ) return Instance._sides [5];
				if ( orientation == SideOrientation.Right ) return Instance._sides [2];
				if ( orientation == SideOrientation.Down ) return Instance._sides [4];
			}
			if ( side == 2)
			{
				if ( orientation == SideOrientation.Up) return Instance._sides [3];
				if ( orientation == SideOrientation.Left) return Instance._sides [1];
				if ( orientation == SideOrientation.Right ) return Instance._sides [6];
				if ( orientation == SideOrientation.Down ) return Instance._sides [4];
			}
			if ( side == 3 )
			{
				if ( orientation == SideOrientation.Up ) return Instance._sides [6];
				if ( orientation == SideOrientation.Left ) return Instance._sides [5];
				if ( orientation == SideOrientation.Right ) return Instance._sides [2];
				if ( orientation == SideOrientation.Down ) return Instance._sides [1];
			}
			if ( side == 4 )
			{
				if ( orientation == SideOrientation.Up ) return Instance._sides [1];
				if ( orientation == SideOrientation.Left ) return Instance._sides [5];
				if ( orientation == SideOrientation.Right ) return Instance._sides [2];
				if ( orientation == SideOrientation.Down ) return Instance._sides [6];
			}
			if ( side == 5 )
			{
				if ( orientation == SideOrientation.Up ) return Instance._sides [3];
				if ( orientation == SideOrientation.Left ) return Instance._sides [6];
				if ( orientation == SideOrientation.Right ) return Instance._sides [1];
				if ( orientation == SideOrientation.Down ) return Instance._sides [4];
			}
			if ( side == 6 )
			{
				if ( orientation == SideOrientation.Up ) return Instance._sides [4];
				if ( orientation == SideOrientation.Left ) return Instance._sides [5];
				if ( orientation == SideOrientation.Right ) return Instance._sides [2];
				if ( orientation == SideOrientation.Down ) return Instance._sides [3];
			}
			return null;
		}
	}
}
