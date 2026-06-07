# Rumo ao Hexa

Rumo ao Hexa é um jogo de plataforma 2D desenvolvido na Unity, com uma proposta simples inspirada no futebol. O jogador controla uma bola e precisa avançar por três fases, coletando medalhas, desviando de obstáculos e chegando ao gol para concluir cada etapa.

O projeto foi desenvolvido como trabalho da disciplina de Game Development, com o objetivo de aplicar conceitos de jogos 2D, física, movimentação de personagem, design de fases, interface, feedback visual e sonoro, além de programação em C# dentro da Unity.

## Ideia do jogo

A proposta do jogo é representar uma jornada rumo ao “hexa”. A bola percorre diferentes ambientes até chegar ao estádio final. Cada fase aumenta um pouco o desafio, exigindo mais controle do jogador sobre corrida, pulo, tempo de reação e posicionamento.

O jogo possui uma estrutura simples, mas funcional, com início pelo menu, progressão entre fases, sistema de vidas, medalhas, obstáculos, sons e tela final.

## Mecânicas implementadas

As principais mecânicas do jogo são:

* Movimento horizontal da bola;
* Corrida utilizando a tecla Shift;
* Pulo com física 2D;
* Rotação visual da bola enquanto ela se move;
* Sistema de pontuação;
* Coleta de medalhas;
* Sistema de vidas;
* Obstáculos que causam dano;
* Área de morte em buracos;
* Reposicionamento do jogador após sofrer dano;
* Tela de Game Over;
* Tela de fase concluída;
* Progressão entre fases;
* Menu inicial;
* Música de fundo;
* Efeitos sonoros;
* Comando para sair do jogo.

## Fases

O jogo possui três fases principais.

### Fase01_Campinho

Primeira fase do jogo. Apresenta o funcionamento básico da movimentação, coleta de medalhas, obstáculo e chegada ao gol. É uma fase mais simples, pensada para introduzir o jogador às mecânicas principais.

### Fase02_CampoBairro

Segunda fase, com aumento de dificuldade. Ela possui mais elementos no cenário, plataformas, obstáculos e um buraco com área de morte. O objetivo é exigir um pouco mais de controle do jogador sem tornar a fase injusta.

### Fase03_EstadioFinal

Fase final do jogo. Possui mais obstáculos e representa a conclusão da jornada. Ao chegar ao gol, o jogador recebe a mensagem final “Você chegou ao Hexa!”.

## Controles

| Ação                        | Tecla                    |
| --------------------------- | ------------------------ |
| Mover para esquerda/direita | A/D ou setas direcionais |
| Pular                       | Espaço                   |
| Correr                      | Shift                    |
| Reiniciar fase              | R                        |
| Avançar após concluir fase  | N                        |
| Iniciar jogo pelo menu      | Enter                    |
| Sair do jogo                | ESC ou botão Sair        |

## Interface

O jogo possui um HUD simples com as principais informações para o jogador:

* Pontos;
* Medalhas coletadas;
* Vidas restantes.

A interface foi criada com TextMeshPro e aparece durante as fases para acompanhar o progresso do jogador.

## Áudio

Foram adicionados efeitos sonoros para reforçar o feedback das principais ações do jogo, como coleta de medalha, dano, Game Over e conclusão de fase.

Também foi adicionada uma música de fundo em loop durante as fases, para deixar a experiência mais completa e menos silenciosa.

## Tecnologias utilizadas

* Unity 6;
* C#;
* Física 2D da Unity;
* TextMeshPro;
* Sistema de cenas da Unity;
* AudioSource para música e efeitos sonoros.

## Estrutura do projeto

O repositório contém as principais pastas do projeto Unity:

* `Assets`: arquivos do jogo, incluindo cenas, scripts, prefabs, sprites, áudios e elementos de interface;
* `Packages`: dependências utilizadas pelo projeto;
* `ProjectSettings`: configurações do projeto Unity;
* `Prints`: imagens das telas e fases do jogo.

## Scripts principais

Alguns dos scripts usados no projeto:

* `PlayerBallController.cs`: controla a movimentação, corrida, pulo e rotação visual da bola;
* `GameManager.cs`: gerencia pontos, vidas, Game Over, conclusão de fase, reinício e troca de cenas;
* `HUDController.cs`: atualiza os textos de pontos, medalhas e vidas na tela;
* `Collectable.cs`: controla a coleta das medalhas;
* `DamageObject.cs`: aplica dano ao jogador ao colidir com obstáculos;
* `DeathZone.cs`: aplica dano quando o jogador cai em áreas de morte;
* `GoalController.cs`: identifica quando o jogador chega ao gol;
* `CameraFollow.cs`: faz a câmera acompanhar o jogador;
* `MenuController.cs`: controla o menu inicial, início do jogo e saída.

## Assets utilizados

### Sprite da bola

* Fonte: OpenGameArt;
* Asset: Soccer Ball;
* Licença: CC0;
* Uso: sprite visual do jogador.

### Música de fundo

* Fonte: OpenGameArt;
* Asset: Beach Sports Theme Loop;
* Autor indicado na página do asset: Trex0n / Cal McEachern;
* Licença: CC0;
* Uso: música de fundo em loop nas fases.

### Efeitos sonoros

Foram utilizados efeitos sonoros gratuitos para:

* Coleta de medalha;
* Dano;
* Game Over;
* Conclusão de fase.

## Como executar

### Pelo executável

1. Baixe a pasta compactada do build.
2. Extraia o arquivo `.zip`.
3. Abra a pasta extraída.
4. Execute o arquivo `Rumo Ao Hexa.exe`.

Importante: o arquivo `.exe` deve permanecer junto das pastas e arquivos gerados pela Unity, pois ele depende desses arquivos para funcionar corretamente.

### Pelo projeto Unity

1. Abra o projeto na Unity.
2. Verifique se as cenas estão configuradas na Build Scene List nesta ordem:

   * `MenuInicial`
   * `Fase01_Campinho`
   * `Fase02_CampoBairro`
   * `Fase03_EstadioFinal`
3. Abra a cena `MenuInicial`.
4. Execute o projeto pelo botão Play da Unity.

## Objetivo acadêmico

Este projeto foi desenvolvido para aplicar, de forma prática, os conteúdos estudados na disciplina de Game Development. Durante o desenvolvimento foram trabalhados conceitos como controle de personagem, física 2D, organização de cenas, HUD, feedback ao jogador, uso de assets, áudio e programação orientada a componentes na Unity.

## Autor

Desenvolvido por Vinicius Rabelo Barbosa
Curso: Análise e Desenvolvimento de Sistemas
