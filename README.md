![Print](https://raw.githubusercontent.com/bittencourtRodrigo/sales-recorder/master/ReadmeImages/Prints/InitialPage.png)
[Veja mais prints clicando aqui](https://github.com/bittencourtRodrigo/sales-recorder/tree/master/ReadmeImages/Prints)
# Registrador de vendas - aplicação web in Visual Studio community 2019

## Criar estados/distritos, subsidiárias para cada estado e registrar vendas. Backend: C#; Frontend: HTML, CSS e Js; Banco de dados: MySql; Adicionais: Entity Framework, .Net core e ASP.NET Core MVC.

Este projeto foi inspirado pelo [curso de C#](https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/) do professor [Nélio alves](https://www.linkedin.com/in/nelio-alves/). Tem a mesma finalidade, mas o caminho até a lá foi razoavelmente tirado de contexto por mim, aventurei para práticar e fui moldando do meu jeito. 

Tópicos que encontrará:
- Segue o padrão Model-View-Controler
- Uma função/método para cada operação 
- Conexão MySql via Entity Framework
- Segmentação forte
- Paginas de erros personalizadas
- Tratamento de erros
- Configuração injeção de dependencia no Startup
- Configurações Dbset do MySql
- Consultas usando LIQN e Lambda
- Pesquisar vendas por data minima e data maxima
- Veja aqui o [UML do projeto](https://github.com/bittencourtRodrigo/sales-recorder/tree/master/ReadmeImages/UML)

## Mapa de navagação
![Diagram](https://raw.githubusercontent.com/bittencourtRodrigo/sales-recorder/master/ReadmeImages/Prints/Diagram.PNG)

## Etapas para instalação (rodar localmente)
- Tenha o VS community 2019 [(Como instalar no Windows)](https://www.youtube.com/watch?v=1uBESL2S8Ik)
- Instale o MySql [(Como instalar no Windows)](https://www.youtube.com/watch?v=2c2fUOgZMmY)
- Clone este repositorio e abra o arquivo *WebAppSalesMVC.sln* com **VS community 2019**
- No **VS community 2019** abra o arquivo *appsettings.json* e altere a string trocando o **userid e password** para os mesmo que você usou na instalação do **MySql**
- Vá em Package Manager Console no rodapé do VS e execute o comando. (Caso não encontre faça: Tools -> NuGet Package Manager -> Package Manager Console)
```bash
Update-Database
```
- Agora compile e rode no **VS community 2019**

## Caso queira contribuir
Ficarei feliz em ser ajudado. Siga o processo de instalação acima e altere como quiser. Claro, antes de implementarmos aqui seu código passará por testes, então, trate de corrigir erros antes. 
Leia o primeiro paragrafo e terá alguma ideia de como eu estava pensando ao digitar o código, siga as mesmas diretrizes, podemos discutir elas, me chame no [Linkedin](https://www.linkedin.com/in/bittencourtrodrigo/).

## Caso encontre algum bug
Fique à vontade para abrir um chamado ou solicitar uma pull request. Será recebido com carinho.

## Problemas conhecidos até o momento e que serão resolvidos (por mim ou por vocês).

- Não responsivo em todos os dispositivos

## Gostei do projeto
Eu agradeço. Você pode demonstrar isso clicando na estrela. Vamos bater um papo no [Linkedin](https://www.linkedin.com/in/bittencourtrodrigo/).
