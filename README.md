Sobre o projeto

Documento.Net � um pacote criado com o objetivo de validar um documento via calculo de DV(d�gito verificador)
Atualmente os documentos suportados s�o: RG, CPF e CNPJ.

O projeto foi desenvolvido em .NET Standard2.0 visando atender quest�es de compatibilidade entre diferentes vers�es do ecossistema .Net

Pacote Nuget: https://www.nuget.org/packages/DocumentoNet.NuGet/


## Como usar

Ap�s instalar o pacote via Gerenciador de pacotes Nuget no VisualStudio, basta fazer a importa��o do NameSpace Documento.Net

<img src="assets/exemplo.jpg" alt="Imagem de exemplo" width="300" />

Como na imagem, basta fazer a instancia��o de um objeto DocumentNet e passar como par�metro o n�mero do documento como string.
N�o existe necessidade de fazer formata��o do campo, do jeito que o documento for inputado, a biblioteca vai saber se virar.



