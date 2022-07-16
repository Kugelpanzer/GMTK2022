using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour
{
    protected int _positionX, _positionY;

    protected int _health;
    protected int _maxHealth;

	public int PositionX { get => _positionX; }
	public int PositionY { get => _positionY; }
	public int Health { get => _health; }
	public int MaxHealth { get => _maxHealth; }

	public virtual void Initialize (int positionX, int positionY)
	{
        _positionX = positionX;
        _positionY = positionY;

        InitializeHealth ( 1 );
	}
    protected void InitializeHealth (int health)
	{
        _maxHealth = health;
        _health = health;
	}

    public void MoveLeft () => _positionX--;
    public void MoveRight () => _positionX++;
    public void MoveUp () => _positionY++;
    public void MoveDown () => _positionY--;

    public void IncreaseHealth ()
    {
        if ( _health < _maxHealth ) _health++;
    }

    public void DecreaseHealth ()
	{
        if (_health > 0 ) _health--;
	}

    public void IncreaseMaxHealth ()
	{
        _maxHealth++;
        _health++;
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
