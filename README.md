# Ondoro CLI

Um gerenciador de tarefas via linha de comando, feito em C#/.NET, como projeto de aprendizado.

## Funcionalidades
- Adicionar tarefa (com título e categoria)
- Listar todas as tarefas
- Marcar tarefa como concluída
- Deletar tarefa
- Persistência em arquivo JSON (dados não se perdem ao fechar o programa)

## Como rodar
\`\`\`bash
dotnet run
\`\`\`

## Estrutura do projeto
- `Program.cs` — loop principal e menu
- `TaskItem.cs` — modelo de dados de uma tarefa
- `TaskFunctions.cs` — lógica de cada ação (adicionar, listar, etc.)
- `TaskRepository.cs` — leitura/escrita do arquivo JSON

////////////////////////////////////////////////////////////////////////////////////////////
# Ondoro CLI

A command-line interface (CLI) task manager built with C#/.NET as a learning project.

## Features
- Add tasks (with title and category)
- List all tasks
- Mark tasks as completed
- Delete tasks
- JSON file persistence (data is saved after closing the program)

## How to run
\`\`\`bash
dotnet run
\`\`\`

## Project Structure
- `Program.cs` — principal loop and menu
- `TaskItem.cs` — task data model
- `TaskFunctions.cs` — logic for each action (add, list, etc.)
- `TaskRepository.cs` — reading/writing the JSON file

