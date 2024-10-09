using UnityEngine;

public class TelaCreditosGameState : GameBaseState
{
    private GameObject telaCreditosJogo;

    private float tempo_mudança = 1;
    private float timer;
    private int contador;

    public override void enterState(GameStateManager gameState)
    {
        Debug.Log("Entramos na tela de créditos.");
        timer = 0;
        contador = 6;
        gameState.mensagem.text = "";

        // pega o game object com a tela de título, para poder ativar / desativar
        // a sua aparição (via SpriteRenderer) ao entrar / sair estado.
        telaCreditosJogo = GameObject.Find("tela_creditos_Treasure_Hunter_1280_1060");

        // ativa o sprite render do gameObject da tela de título, exibindo-a na tela.
        telaCreditosJogo.GetComponent<SpriteRenderer>().enabled = true;


    }

    public override void updateState(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // muda para o próximo estado.
            gameState.switchState(gameState.introState);
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
                gameState.mensagem.text = "Créditos: " + contador;
            }
            else
            {
                gameState.switchState(gameState.introState);
            }
        }


    }

    public override void leaveState(GameStateManager gameState)
    {
        Debug.Log("Saindo da tela de créditos.");

        // desativa o sprite render do gameObject da tela de título, escondendo-a.
        telaCreditosJogo.GetComponent<SpriteRenderer>().enabled = false;
    }
}


