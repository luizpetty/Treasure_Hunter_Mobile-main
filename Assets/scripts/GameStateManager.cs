using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UI;


public class GameStateManager : MonoBehaviour
{
    public Text mensagem;
 
    GameBaseState currentState;
    // instancias de cada um dos estados do jogo
    public TelaInicialGameState telaInicialState = new TelaInicialGameState();
    public TelaCreditosGameState telaCreditosState = new TelaCreditosGameState();
    public PlayingGameState playingState = new PlayingGameState();
    public IntroGameState introState = new IntroGameState();

    public GameObject player;
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject danger1;
    public GameObject danger2;


    void Start()
    {
        // seta o estado inicial
        currentState = telaInicialState;
        // inicia o estado.
        currentState.enterState(this);

    }

    public void AtivarElementosJogo(bool interruptor)
    {
        player.GetComponent<SpriteRenderer>().enabled = interruptor;
        player.GetComponent<player>().setAtivo(interruptor);
        food1.GetComponent<SpriteRenderer>().enabled = interruptor;
        food2.GetComponent<SpriteRenderer>().enabled = interruptor;
        food3.GetComponent<SpriteRenderer>().enabled = interruptor;
        food4.GetComponent<SpriteRenderer>().enabled = interruptor;
        danger1.GetComponent<SpriteRenderer>().enabled = interruptor;
        danger2.GetComponent<SpriteRenderer>().enabled = interruptor;



    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);

    }

    public void switchState(GameBaseState state)
    {
        // sai do estado anterior
        currentState.leaveState(this);

        // muda o estado atual
        currentState = state;

        // entra no novo estado
        currentState.enterState(this);
    }

}
