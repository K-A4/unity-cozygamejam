using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairItem : RoomItem
{
    [SerializeField] private Transform sitPos;
    [SerializeField] private float sitTime;
    private Vector3 StartPos;
    private CozyOfPlayer cozyOfPlayer;
    private bool sitting;
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        var transform = Player.Instance.transform;
        this.cozyOfPlayer = cozyOfPlayer;
        Player.Instance.gameObject.layer = LayerMask.NameToLayer("Grabbed");
        StartPos = transform.position;

        if (!sitting)
        {
            StartCoroutine(Sitt(transform));
        }
    }
  
    private IEnumerator Sitt(Transform transform)
    {
        var startPos = transform.position;
        var startRot = transform.rotation;
        var timeElapsed = 0.0f;
        transform.SetParent(gameObject.transform);
        
        while (true)
        {
            timeElapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, sitPos.position, timeElapsed / sitTime);
            transform.rotation = Quaternion.Lerp(startRot, sitPos.rotation, timeElapsed / sitTime);

            if (timeElapsed > sitTime)
            {
                StartCoroutine(Sitting(transform));
                sitting = true;
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator Sitting(Transform transform)
    {
        var timeElapsed = 0.0f;

        while (true)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed <= 1)
            {
                cozyOfPlayer.ChangeCozy(Time.deltaTime * Info.CozyPerUse);
            }

            if (Player.Instance.PlayerMovement.InputVector != Vector3.zero)
            {
                StartCoroutine(StandUp(transform));
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator StandUp(Transform transform)
    {
        var startPos = transform.position;
        var startRot = transform.rotation;
        var timeElapsed = 0.0f;
        while (true)
        {
            timeElapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, StartPos, timeElapsed / sitTime);
            transform.rotation = Quaternion.Lerp(startRot, Quaternion.Euler(0, startRot.eulerAngles.y, 0), timeElapsed / sitTime);
            if (timeElapsed > sitTime)
            {
                transform.SetParent(null);
                sitting = false;
                Player.Instance.gameObject.layer = LayerMask.NameToLayer("Player");
                Health--;
                yield break;
            }
            yield return null;
        }
    }
}
