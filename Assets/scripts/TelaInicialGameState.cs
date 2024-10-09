using UnityEngine;

public class TelaInicialGameState : GameBaseState
{
    private GameObject telaInicialJogo;
    private GameObject musicaTelaTituloJogo;

    private float tempo_mudan�a = 1;
    private float timer;
    private int contador;

    public override void enterState(GameStateManager gameState)
    {
        Debug.Log("Entramos na Tela inicial.");
        timer = 0;
        contador = 30;
        gameState.mensagem.text = "";

        // pega o game object com a tela de t�tulo, para poder ativar / desativar
        // a sua apari��o (via SpriteRenderer) ao entrar / sair estado.
        telaInicialJogo = GameObject.Find("Tela_treasure_hunter_1280_x_1060");

        // ativa o sprite render do gameObject da tela de t�tulo, exibindo-a na tela.
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = true;

        musicaTelaTituloJogo = GameObject.Find("aleste_title_theme");
        musicaTelaTituloJogo.GetComponentInParent<AudioSource>().Play();
    }

    public override void updateState(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // muda para o pr�ximo estado.
            gameState.switchState(gameState.playingState);
        }

        if (timer < tempo_mudan�a)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            contador--;
            timer = 0;
            if (contador >= 0)
            {
                gameState.mensagem.text = "TELA INICIAL: " + contador;
            }
            else
            {
                gameState.switchState(gameState.playingState);
            }
        }

    }

    public override void leaveState(GameStateManager gameState)
    {
        Debug.Log("Saindo da Tela inicial.");
        // desativa o sprite render do gameObject da tela de t�tulo, escondendo-a.
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = false;
        // Encerra a execu��o da m�sica 
        //musicaTelaTituloJogo.GetComponentInParent<AudioSource>().Stop();
    }
}


