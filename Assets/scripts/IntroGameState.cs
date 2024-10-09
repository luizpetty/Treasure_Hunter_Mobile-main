using UnityEngine;

public class IntroGameState : GameBaseState
{
    private float tempo_mudança = 1;
    private float timer;
    private int contador;

    public override void enterState(GameStateManager gameState)
    {
        Debug.Log("Entramos no modo intro.");
        gameState.mensagem.text = "intro.";
        timer = 0;
        contador = 6;
        gameState.mensagem.text = "";

    }

    public override void updateState(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // muda para o próximo estado.
            gameState.switchState(gameState.telaInicialState);
        }

        if (timer < tempo_mudança)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            contador--;
            timer = 0;
            if (contador >= 0)
            {
                gameState.mensagem.text = "Intro: " + contador;
            }
            else
            {
                gameState.switchState(gameState.telaInicialState);
            }
        }


    }

    public override void leaveState(GameStateManager gameState)
    {
        Debug.Log("Saindo do modo intro.");
    }
}


