using UnityEngine;

public class PlayingGameState : GameBaseState
{

    private GameObject telaFundoJogo;

    public override void enterState(GameStateManager gameState)
    {
        Debug.Log("Entramos no modo playing.");
        gameState.mensagem.text = "";
        gameState.AtivarElementosJogo(true);

        // pega o game object com a tela de título, para poder ativar / desativar
        // a sua aparição (via SpriteRenderer) ao entrar / sair estado.
        telaFundoJogo = GameObject.Find("fundo-espaco_1080x1920");

        // ativa o sprite render do gameObject da tela de título, exibindo-a na tela.
        telaFundoJogo.GetComponent<SpriteRenderer>().enabled = true;
    }

   

    public override void updateState(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // muda para o próximo estado.
            gameState.switchState(gameState.telaCreditosState);
        }
        

    }

    public override void leaveState(GameStateManager gameState)
    {
        Debug.Log("Saindo do modo playing.");
        // gameState.player.SetActive(false);
        gameState.player.GetComponent<player>().setAtivo(false);
        gameState.player.GetComponent<SpriteRenderer>().enabled = false;
        gameState.AtivarElementosJogo(false);
        telaFundoJogo.GetComponent<SpriteRenderer>().enabled = false;
    }
}


