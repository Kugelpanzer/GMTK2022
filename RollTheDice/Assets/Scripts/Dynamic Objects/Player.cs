using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Critter
{
	public override void Initialize (int positionX, int positionY)
	{
		base.Initialize ( positionX, positionY );
		InitializeHealth ( 3 );
	}
}
