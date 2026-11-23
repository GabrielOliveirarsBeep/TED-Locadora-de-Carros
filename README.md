Locadora de Carros
Projeto acadêmico desenvolvido em C# para a disciplina de Algoritmos e Estruturas de Dados II, do curso de Sistemas de Informação da UniSapiens.
Resumo do projeto

O programa simula uma locadora de carros por meio de uma aplicação de console. O objetivo é aplicar na prática os conceitos de estruturas de dados lineares, ordenação, busca e seleção, facilitando a consulta de veículos e o cálculo do aluguel.

A frota é armazenada em um vetor de 12 objetos da classe Carro, contendo código, modelo, categoria e valor da diária. Os veículos são divididos em quatro categorias: Compacto, Sedan, SUV e Picape.
Funcionalidades
- Alugar um carro e exibir o resumo da reserva.
- Ordenar a frota por preço da diária ou nome do modelo.
- Buscar veículos pelo modelo ou código.
- Filtrar veículos por categoria.
- Calcular o valor do aluguel, seguro, desconto e parcelamento.

Tecnologias utilizadas
- C# e plataforma .NET.
- Aplicação Console.
- Vetores (arrays), classes e métodos estáticos.
- Estruturas condicionais e laços de repetição.

Algoritmos utilizados

Algoritmo            	             Finalidade	                          Complexidade
Bubble Sort	                Ordenar pelo valor da diária	                O(n²)
Selection Sort	            Ordenar pelo nome do modelo	                  O(n²)
Busca sequencial	            Localizar pelo modelo	                      O(n)
Busca binária	                Localizar pelo código	                     O(log n)
Seleção por categoria	         Filtrar os veículos	                      O(n)


A frota original permanece ordenada por código para permitir a busca binária. As ordenações por preço e modelo são realizadas em cópias do vetor.
Regras de aluguel

- O valor base é calculado pela diária multiplicada pela quantidade de dias.
- Seguro opcional de R$ 150,00.
- Desconto de 10% para reservas de sete diárias ou mais, exceto na categoria Compacto.
- Reservas de longo prazo a partir de 30 diárias.
- Pagamento à vista, Pix ou parcelado em até quatro vezes.

Como executar

1. Instale o SDK do .NET.
2. Abra a pasta que contém o projeto C# no terminal ou no Visual Studio.
3. Caso a pasta contenha o arquivo de projeto .csproj, execute:
4. </> Bash
  dotnet run
5. Escolha uma das opções apresentadas no menu do console.

Resultados e melhorias futuras
Segundo os resultados apresentados no relatório, a busca binária encontrou o veículo de código 12 em quatro passos, enquanto a busca sequencial precisou de 12. O projeto demonstrou a importância da escolha dos algoritmos para organizar e consultar informações.
Como melhorias futuras, pretende-se permitir o cadastro de novos veículos, controlar sua disponibilidade e melhorar a validação das entradas.

Autores

- Gabriel Oliveira Costa
- Isaac Dos Santos Ribeiro
Instituição: UniSapiens
Curso: Sistemas de Informação
Disciplina: Algoritmos e Estruturas de Dados II
Ano: 2026
