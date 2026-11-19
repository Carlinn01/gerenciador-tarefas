# Gerenciador de Tarefas

Projeto final da disciplina. Aplicação de console em C# para cadastrar e acompanhar tarefas usando lista e pilha.

## Como rodar

```
dotnet run
```

## Funcionalidades

- Cadastrar tarefa
- Listar tarefas
- Buscar tarefa pelo ID
- Concluir tarefa
- Desfazer a última conclusão
- Sair

## Estruturas usadas

- `List<Tarefa>` guarda todas as tarefas cadastradas.
- `Stack<int>` guarda os IDs das tarefas concluídas. Quando desfaz, o ID do topo sai da pilha e a tarefa volta a ser pendente.
