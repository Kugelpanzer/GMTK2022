using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK2020
{
    public class Enemy : Critter
    {

		Grid mainGrid;
		public float speed = 10;
		public void SetToGrid()
		{
			transform.position = mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY));
		}
		// Start is called before the first frame update
		void Start() {

			mainGrid = DataController.Instance.mainGrid;
			SetToGrid();
		}

		// Update is called once per frame
		void Update() {
			transform.position = Vector3.MoveTowards(transform.position, mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY)), speed * Time.deltaTime);
			if (Input.GetKeyDown(KeyCode.L))
			{
				MoveOrAttack();
			}
		}
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
			/*BoardController.Instance.FindPath ( this, Player.Instance );
			int directionX = Player.Instance.GridPositionX - GridPositionX;
			int directionY = Player.Instance.GridPositionY - GridPositionY;

			bool canMoveLeft = !BoardController.Instance.isOccupiedTile ( GridPositionX - 1, GridPositionY );
			bool canMoveRight = !BoardController.Instance.isOccupiedTile ( GridPositionX + 1, GridPositionY );
			bool canMoveUp = !BoardController.Instance.isOccupiedTile ( GridPositionX, GridPositionY + 1 );
			bool canMoveDown = !BoardController.Instance.isOccupiedTile ( GridPositionX, GridPositionY - 1 );

			if ( canMoveUp && directionY > Mathf.Abs ( directionX ) ) MoveUp ();
			else if ( canMoveDown && -directionY > Mathf.Abs ( directionX ) ) MoveDown ();
			else if ( canMoveLeft && directionX < 0 ) MoveLeft ();
			else if ( canMoveRight && directionY > 0 ) MoveRight ();*/

			int[,] move = PathfindingScript.GetPath(BoardController.CreateBoard(), new point(GridPositionX, GridPositionY), new point(Player.Instance.GridPositionX, Player.Instance.GridPositionY));
			point movePoint = PathfindingScript.MinPoint(PathfindingScript.NeighbourList(move, GridPositionX, GridPositionY));
			GridPositionY = movePoint.y;
			GridPositionX = movePoint.x;

		}

		public void AttackPlayer ()
		{
			Player.Instance.DecreaseHealth ();
		}


    }
}
