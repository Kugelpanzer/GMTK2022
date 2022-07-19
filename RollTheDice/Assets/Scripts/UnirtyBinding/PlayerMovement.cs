using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;
public class PlayerMovement : BaseMovement
{
    private float timeLerped = 0f;
    public float timeToLerp = 2f;
    Rotation r;
    PlayerDiceSide ps;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        r = GetComponent<Rotation>();
        Player.Instance.GridPositionX = gridX;
        Player.Instance.GridPositionY = gridY;
        ps = GetComponent<PlayerDiceSide>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!BoardController.Instance.isOccupiedTile(gridX -1, gridY) && r.CanMove())
            {
                gridX--;
                r.Rotate(key.a);
                
                Player.Instance.MoveLeft();
                CheckUpgrade();

                ps.Type = GetComponent<GenerateSides>().sides[Player.Instance.dice.front - 1];
                ps.ExecuteEffect(gridX, gridY, key.a);
                Player.Instance.OnMove();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!BoardController.Instance.isOccupiedTile(gridX, gridY + 1) && r.CanMove())
            {
                gridY++;
                r.Rotate(key.w);
                
                Player.Instance.MoveUp();
                CheckUpgrade();
                ps.Type = GetComponent<GenerateSides>().sides[Player.Instance.dice.front - 1];
                ps.ExecuteEffect(gridX, gridY, key.w);

                Player.Instance.OnMove();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!BoardController.Instance.isOccupiedTile(gridX+1, gridY) && r.CanMove())
            {
                gridX++;
                r.Rotate(key.d);
                
                Player.Instance.MoveRight();
                CheckUpgrade();

                ps.Type = GetComponent<GenerateSides>().sides[Player.Instance.dice.front - 1];
                ps.ExecuteEffect(gridX, gridY, key.d);

                Player.Instance.OnMove();

            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!BoardController.Instance.isOccupiedTile(gridX, gridY - 1) && r.CanMove() )
            {
                gridY--;
                r.Rotate(key.s);
                
                Player.Instance.MoveDown();
                
                CheckUpgrade();

                ps.Type = GetComponent<GenerateSides>().sides[Player.Instance.dice.front-1];
                ps.ExecuteEffect(gridX, gridY,key.s);
                //Player.Instance.OnMove();
            }
        }

        base.Update();

        //if (!Player.Instance.IsAlive())  LevelController.levelController.GoToScene(2);
    }

    private void CheckUpgrade()
    {
        if (BoardController.Instance.CheckUpgrade(gridX, gridY) != DiceSideType.Empty)
        {
            GetComponent<GenerateSides>().ChangeSide(Player.Instance.dice.bottom2, BoardController.Instance.CheckUpgrade(gridX, gridY));
            Destroy(BoardController.Instance.GetUpgrade(gridX, gridY).gameObject);
        }

        foreach(Enemy e in BoardController.Instance.Enemies)
        {
            e.MoveOrAttack();
        }
    }

}
