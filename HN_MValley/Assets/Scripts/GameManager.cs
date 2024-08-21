using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player;
    public List<PathCondition> pathConditions = new List<PathCondition>();
    public List<Transform> pivots;

    public Transform[] objectsToHide;
    public float towerTurnSpeed = .6f;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check and update path conditions
        foreach (PathCondition pc in pathConditions)
        {
            int count = 0;
            for (int i = 0; i < pc.conditions.Count; i++)
            {
                if (pc.conditions[i].conditionObject.eulerAngles == pc.conditions[i].eulerAngle)
                {
                    count++;
                }
            }
            foreach(SinglePath sp in pc.paths)
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);
        }

        if (player.walking)
            return;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            SoundManager.Instance.TowerTurn();
            int multiplier = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
            pivots[0].DOComplete();
            pivots[0].DORotate(new Vector3(0, 90 * multiplier, 0), towerTurnSpeed, RotateMode.WorldAxisAdd)
           .SetEase(Ease.OutBack)
           .OnComplete(() =>
           {
           //play end sound here
           SoundManager.Instance.TowerTurnComplete();
               
           });
        }

        foreach(Transform t in objectsToHide)
        {
            t.gameObject.SetActive(pivots[0].eulerAngles.y > 45 && pivots[0].eulerAngles.y < 90 + 45);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

    }

    public void RotateRightPivot()
    {
        SoundManager.Instance.PuzzleBlock();
        StartCoroutine(RotateRightPivotCoroutine());   
    }
    //added coroutine so the "solve puzzle" block sound has time to play
    private IEnumerator RotateRightPivotCoroutine()
    {
        // Wait for 1.5 second before rotating
        yield return new WaitForSeconds(1.5f);

        // Perform the rotation after the delay
        SoundManager.Instance.TowerFell();
        pivots[1].DOComplete();
        pivots[1].DORotate(new Vector3(0, 0, 90), 0.6f).SetEase(Ease.OutBack);

    }
}

[System.Serializable]
public class PathCondition
{
    public string pathConditionName;
    public List<Condition> conditions;
    public List<SinglePath> paths;
}
[System.Serializable]
public class Condition
{
    public Transform conditionObject;
    public Vector3 eulerAngle;

}
[System.Serializable]
public class SinglePath
{
    public Walkable block;
    public int index;
}
