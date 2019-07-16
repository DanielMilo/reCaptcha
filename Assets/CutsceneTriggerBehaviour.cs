using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTriggerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject CutsceneUI;

    [SerializeField] bool isSelectionCutscene;

    private bool alreadyHit = false;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!alreadyHit || isSelectionCutscene) && collision.gameObject.Equals(player) && CutsceneUI != null)
        {
            Debug.Log("DeathTriggerBehaviour::OnTriggerEnter2D Player Entered");

            player.GetComponent<CharacterBehaviour>().isCutscene = true;
            alreadyHit = true;
            CutsceneUI.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseUI()
    {
        player.GetComponent<CharacterBehaviour>().isCutscene = false;
        CutsceneUI.SetActive(false);
    }
}
