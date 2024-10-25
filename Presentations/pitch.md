---
marp: true
backgroundColor: #e1e3e4
# theme: uncover
color: #5a6477
style: |
    h1 {
        font-size: 60px;
    }
    h2 {
        font-size: 45px;
    }
    section {
        font-size: 30px;
    }
    .columns2 {
        display: grid;
        grid-template-columns: repeat(2, minmax(0, 1fr));
        gap: 0.25rem;
    }
    .columns3 {
        display: grid;
        grid-template-columns: repeat(3, minmax(0, 1fr));
        gap: 0.25rem;
    }
    .small-text {
        font-size: 0.85rem;
    }
    .fg-white {
        color: #e1e3e4;
    }
    .grey {
        color: #828a9a;
    }
    .grey-dim {
        color: #5a6477
    }
    .orange {
        color: #f69c5e;
    }
    .green {
        color: #8fcc61;
    }
    .bg-green {
        color: #a5e179;
    }
math: mathjax

---

<style>
@import 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css';
img {
  	    background-color: transparent!important;
    }
video::-webkit-media-controls {
    will-change: transform;
  }
</style>

# <!---fit---> <span class=orange>Groovyle :sunrise_over_mountains:</span>
## <span class=orange>Apresentação do projeto</span>
<span class=small-text>PSI3572 - Computação Visual (2024)
23/10/2024</span>

---
# <span class=green>Equipe</span> :paperclip:
- Vinícius Shimizu
- Diogo Ribeiro
- Jihee Song
- Guilherme Bozi

---
# <span class=orange>Ideia</span> :bulb:

Aplicação para visualização 3D de espectro de áudio.

Um campo pacífico e silencioso irá se transformar conforme o áudio é capturado, dando lugar a uma cidade vibrante e cheia de energia. 

---
# <span class=green>Referências</span> :art:
![w:330](image1.png) ![w:330](image2.png) ![w:330](image3.png)

---
# <span class=green>Conceito</span> :pencil2:
<center>
<a href="https://drive.google.com/file/d/1Jw45lNFYzEIiV1PR4nXOT0wJpELHxM1j/view?usp=sharing">
    <img src="concept.png" width="850" alt="Imagem de referência">
</a>
</center>

---
# <span class=green>Ferramentas</span> :hammer:
- **Unity** <i class="fab fa-unity green"></i> (desenvolvimento da aplicação e programação);
- **Blender** <i class="fa fa-blender green"></i> (tratamento dos modelos 3D);
- **Photoshop** <i class="fa fa-camera green"></i> (manipulação de imagens para texturas e icones);
- **GitHub** <i class="fab fa-github green"></i> (controle de versão e organização do projeto).

---
# <span class=orange>Estrutura do projeto</span> :construction:
- **Modelagem** e **texturização** dos objetos;
- **Montagem** da cena (iluminação, posição da câmera, posição dos objetos, etc);
- **Processamento** do áudio capturado;
- **Programação** da interação entre cena e áudio;
- **Pós-processamento** da cena.

---
# <span class=orange>Cronograma</span> :clipboard:
**Semana 1** <i class="fa-solid fa-list-check orange"></i>
Decisão dos modelos a serem utilizados, assim como a cena a ser apresentada.

**Semana 2** <i class="fas fa-cubes orange"></i>
Modelagem básica dos objetos.

**Semana 3** <i class="fa-solid fa-paintbrush orange"></i>
Detalhamento dos modelos, início da texturização e implementação na Unity.

**Semana 4** <i class="fa-solid fa-laptop-code orange"></i>
Refinamento da texturização e implementação na Unity.

**Semana 5** <i class="fa-solid fa-bug orange"></i>
Correção de bugs.