using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> puzzles = new List<GameObject>();

    private GameObject activePuzzle;

    public GameObject handTmp;
    public GameObject wallTmp;

    private GameObject tmp;

    public Transform sPos;
    public Transform cPos;

    int puzzleIndex = 0;
    int listLength = 0;

    public bool handText = false;
    bool congratsActive = false;
    bool gameStart = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (gameStart)
        {
            if (!congratsActive)
                tmp.GetComponent<TextMeshProUGUI>().text = "Progress: " + PuzzleChecker.pieceCount + "/7";

            if (PuzzleChecker.pieceCount == 7)
            {
                StartCoroutine(StartCongrats());
            }

            if(PuzzleChecker.pieceCount > 7)
            {
                ResetPuzzle();
            }
        }
        
    }

    public void startGame()
    {
        if (handText)
        {
            tmp = handTmp;
            wallTmp.SetActive(false);
        }
        else
        {
            tmp = wallTmp;
            handTmp.SetActive(false);
            wallTmp.transform.position = sPos.position;
        }
        PuzzleChecker.pieceCount = 0;
        listLength = puzzles.Count;
        SpawnPuzzle(0);
        gameStart = true;
    }

    public void setHandText(int index)
    {
        if(index == 0)
        {
            handText = false;
            tmp = wallTmp;
            handTmp.SetActive(false);
            wallTmp.SetActive(true);
            wallTmp.transform.position = sPos.position;

        } else if(index == 1)
        {
            handText = true;
            tmp = handTmp;
            handTmp.SetActive(true);
            wallTmp.SetActive(false);
        }
    }

    void SpawnPuzzle(int index)
    {
        GameObject spawn = Instantiate(puzzles[index], GetComponentInParent<Transform>());
        activePuzzle = spawn;
    }

    void DeletePuzzle()
    {
        Destroy(activePuzzle);
    }

    public void ResetPuzzle()
    {
        if (!congratsActive){
            GameObject replace = Instantiate(puzzles[puzzleIndex], GetComponentInParent<Transform>());
            Destroy(activePuzzle);
            activePuzzle = replace;
            PuzzleChecker.pieceCount = 0;
        }
    }

    IEnumerator StartCongrats()
    {
        congratsActive = true;
        PuzzleChecker.pieceCount = 0;
        DeletePuzzle();

        if (handText)
        {
            wallTmp.SetActive(true);
        }
        wallTmp.transform.position = cPos.position;
        wallTmp.GetComponent<TextMeshProUGUI>().text = "CONGRATS!!!";

        yield return new WaitForSeconds(3f);

        puzzles.RemoveAt(puzzleIndex);

        if (puzzles.Count <= 0){
            wallTmp.transform.position = cPos.position;
            wallTmp.GetComponent<TextMeshProUGUI>().text = "FINISHED!!!!!";
        }
        else
        {
            wallTmp.transform.position = cPos.position;
            wallTmp.GetComponent<TextMeshProUGUI>().text = "NEXT PUZZLE!";

            yield return new WaitForSeconds(3f);
            listLength = puzzles.Count;
            puzzleIndex = Random.Range(0, listLength);
            SpawnPuzzle(puzzleIndex);


            if (handText)
            {
                wallTmp.SetActive(false);
            }
            wallTmp.transform.position = sPos.position;
            wallTmp.GetComponent<TextMeshProUGUI>().text = "Progress: " + PuzzleChecker.pieceCount + "/7";
            congratsActive = false;
        }
    }
}