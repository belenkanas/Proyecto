# Notas de Reflexión del Proyecto

Tomando en cuenta todas las reflexiones, aprendizajes y estrategias de trabajo que hemos tenido a lo largo de las distintas instancias del proyecto, a continuación se detallan nuestras principales observaciones.

## Desafíos más difíciles de la entrega
1. Diseño de interfaces y clases de dominio:
   Aunque ahora mirando hacia atrás ya tenemos mucho más claro las clases fundamentales del código, la decisión sobre cuáles serían las clases de dominio y cómo interectuarían entre sí fue uno de los aspectos más complejos del proyecto. Decidir e implementar dichas clases, como las abstractas también, requirió un análisis profundo por parte del equipo.

2. Definición de responsabilidades:
   Junto con el punto anterior, implementar un diseño eficaz, bien organizado y difícil de "romper" fue un reto importante. En otras palabras, asegurar que cada clase y cada método de ella cumpla un rol específico no fue lo único que nos generó trabajo pensar, sino que también la correcta asignación de responsabilidades fue un punto clave para poder mantener un código ordenado y funcional.

3. Introducción al patrón de diseño "Fachada" (Façade)
   Nos enfrentamos a varios conceptos nuevos, entre ellos, el concepto de "Fachada". Entender su propósito y su funcionamiento para simplificar la interacción entre clases nos tomó tiempo, pero resultó ser bastante valioso para la estructura final del proyecto.

4. Implementación de ChatBot
   En un principio, al ser un concepto totalmente nuevo para varios del equipo, no comprendíamos bien cómo hacerlo funcionar o las distintas conecciones que tenía con el código del proyecto, pero luego de un arduo trabajo hemos podido entenderlo mejor.

## Cosas nuevas aprendidas durante el proyecto.
Como mencionado anteriormente, los puntos nuevos principales que hemos aprendido fueron el concepto de la "Fachada" y el uso de los ChatBot de Discord. Dicho patrón de diseño nos facilitó realmente el uso de comandos para poder implementar el chatbot, por lo que comprendimos que una fachada no solo mejor la claridad del código, sino que también facilita su mantenimiento.

Además, aunque ya habíamos trabajado con diseño orientado a objetos en otras instancias del semestre, este proyecto nos permitió poner en práctica conceptos avanzados, tales como Singleton, Excepciones, Debug y Test, Composición y Delegación, entre otros.

## Recursos valiosos para el proyecto
1. Pokemon Showdown:
   Para poder entender mejor la dinámica del proyecto planteado, al inicio de todo jugamos varias partidas en la plataforma [Pokémon Showdown](https://pokemonshowdown.com), con el fin de comprender el funcionamiento de los equipos, las estrategias e interacciones entre los distintos tipos de Pokemon y Ataques.
2. Investigación sobre tipos de personajes:
   Siguiendo con la investigación del juego, para implementarlo tal cual la lógica original, nos basamos en distintos recursos que detallaban cómo interactuaban los distintos tipos entre sí, cuáles eran sus fortalezas y sus debilidades.
• [Pokémaster - Tipos y debilidades](https://pokemaster.es/tipos-de-pokemon-todas-las-debilidades-pokemon-segun-el-tipo-elemental-no-121393/)
• [Vandal - Tabla de Tipos](https://vandal.elespanol.com/reportaje/tabla-de-tipos-de-pokemon-fortalezas-y-debilidades-en-todos-los-juegos)
• [Mundo Deportivo - Fortalezas y debilidades](https://www.mundodeportivo.com/alfabeta/guia/tabla-tipos-pokemon-fortalezas-debilidades)
3. Recursos para implementar el ChatBot:
   Para poder asegurarnos de un buen funcionamiento del Bot de Discord, seguimos los siguientes tutoriales, encontrados en internet como también brindados como material estudiantil.
   [Cómo crear tu Bot de Discord](https://www.youtube.com/watch?v=KsqcoNMXKqA)
   [PII_DiscordBot](https://github.com/ucudal/PII_DiscordBot_Demo.git)
4. Herramientas de organización:
   Como último, pero no menos importante, implementamos una plantilla especial de [Trello](https://trello.com/invite/b/6703de37cf3960b68425477a/ATTI795f0bcf6e0f9f9f73480dac39304e30C5BEDD72/1erentrega-pii). Esto nos permitió visualizar el flujo de trabajo, asignar las responsabilidades y hacer un correcto seguimiento del proceso de manera efectiva.

## Reflexiones finales
Como mensaje final, entendemos que este proyecto no solo representa un desafío técnico, sino que también de organización. La necesidad de delegar claramemente tareas y asegurarnos de que todas las partes del equipo puedan llevar adelante el proyecto es igual de importante que poder aplicar correctamente los conceptos avanzados de diseño orientado a objetos. Esto nos ha permitido adentrarnos más a lo enseñado en clase y a buscar nuevas herramientas y estrategias por nuestra cuenta. 
   
------------------------------------------------------------------------------------------------

# Qué hay configurado en esta plantilla

1. Un proyecto de biblioteca (creado con [`dotnet new classlib --name Library`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22)) en la carpeta `src\Library`
2. Un proyecto de aplicación de consola (creado con [`dotnet new console --name Program`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22)) en la carpeta `src\Program`
3. Un proyecto de prueba en [NUnit](https://nunit.org/) (creado con [`dotnet new nunit --name LibraryTests`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22)) en la carpeta `test\LibraryTests`
4. Un proyecto de [Doxygen](https://www.doxygen.nl/index.html) para generación de sitio web de documentación en la carpeta `docs`
5. Análisis estático con [Roslyn analyzers](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview) en los proyectos de biblioteca y de aplicación
6. Análisis de estilo con [StyleCop](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/README.md) en los proyectos de biblioteca y de aplicación
7. Una solución `ProjectTemplate.sln` que referencia todos los proyectos de C# y facilita la compilación con [`dotnet build`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build).
8. Tareas preconfiguradas para compilar y ejecutar los proyectos, ejecutar las pruebas, y generar documentación desde VSCode en la carpeta `.vscode`
9. Análisis de cobertura de los casos de prueba mediante []() que aparece en los márgenes con el complemento de VS Code [Coverage Gutters](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters).
10. Ejecución automática de compilación y prueba mediante [GitHub Actions](https://docs.github.com/en/actions) configuradas en el repositorio al hacer [push](https://github.com/git-guides/git-push) o [pull request](https://docs.github.com/en/github/collaborating-with-pull-requests).

Vean este 🎥 [video](https://web.microsoftstream.com/video/55c6a06c-07dc-4f95-a96d-768f198c9044) que explica el funcionamiento de la plantilla.

## Convenciones

[Convenciones de código en C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

[Convenciones de nombres en C#](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)

## Dónde encontrar información sobre los errores/avisos al compilar

[C# Compiler Errors (CS*)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/)

[Roslyn Analyzer Warnings (CA*)](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/categories)

[StyleCop Analyzer Warnings (SA*)](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/DOCUMENTATION.md)

# Cómo deshabilitar temporalmente los avisos al compilar

## Roslyn Analyzer

Comentar las siguientes líneas en los archivos de proyecto (`*.csproj`)
```
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisMode>AllEnabledByDefault</AnalysisMode>
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
```

## StyleCop Analyzer

Comentar la línea `<PackageReference Include="StyleCop.Analyzers" Version="1.1.118"/>` en los archivos de proyecto (`*.csproj`)
