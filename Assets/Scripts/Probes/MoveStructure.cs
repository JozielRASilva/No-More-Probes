using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStructure : MonoBehaviour, IMoveStructure
{

    public List<Vector2> positions;

    public void DoReposition()
    {
    }

    public IEnumerator Mover()
    {
        yield return null;
    }

    public IEnumerator Mover(Vector2 position)
    {
        yield return null;
    }

    public IEnumerator Reposition()
    {
        yield return null;
    }

    public void StartMove()
    {
    }

    public void StopMove()
    {
    }

}


public interface IMoveStructure
{
    IEnumerator Mover();

    IEnumerator Mover(Vector2 position);

    void StartMove();

    void StopMove();

    void DoReposition();

    IEnumerator Reposition();

}
