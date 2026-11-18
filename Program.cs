namespace GerenciadorTarefas
{
    class Program
    {
        static List<Tarefa> tarefas = new List<Tarefa>();
        static Stack<int> concluidas = new Stack<int>();
        static int proximoId = 1;

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("===== GERENCIADOR DE TAREFAS =====");
                Console.WriteLine("1 - Cadastrar tarefa");
                Console.WriteLine("2 - Listar tarefas");
                Console.WriteLine("3 - Buscar tarefa");
                Console.WriteLine("4 - Concluir tarefa");
                Console.WriteLine("5 - Desfazer a última conclusão");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarTarefa();
                        break;
                    case 2:
                        ListarTarefas();
                        break;
                    case 3:
                        BuscarTarefa();
                        break;
                    case 4:
                        ConcluirTarefa();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarTarefa()
        {
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("A descrição não pode ficar vazia.");
                return;
            }

            Tarefa tarefa = new Tarefa(proximoId, descricao);
            tarefas.Add(tarefa);
            proximoId++;

            Console.WriteLine("Tarefa cadastrada com o ID " + tarefa.Id + ".");
        }

        static void ListarTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
                return;
            }

            Console.WriteLine();
            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine("ID: " + tarefa.Id + " | " + tarefa.Descricao + " | " + tarefa.Situacao());
            }
        }

        static void BuscarTarefa()
        {
            Console.Write("Digite o ID da tarefa: ");
            int id = int.Parse(Console.ReadLine());

            Tarefa tarefa = ProcurarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine("Nenhuma tarefa encontrada com o ID " + id + ".");
                return;
            }

            Console.WriteLine("ID: " + tarefa.Id);
            Console.WriteLine("Descrição: " + tarefa.Descricao);
            Console.WriteLine("Situação: " + tarefa.Situacao());
        }

        static void ConcluirTarefa()
        {
            Console.Write("Digite o ID da tarefa: ");
            int id = int.Parse(Console.ReadLine());

            Tarefa tarefa = ProcurarPorId(id);

            if (tarefa == null)
            {
                Console.WriteLine("Nenhuma tarefa encontrada com o ID " + id + ".");
                return;
            }

            if (tarefa.Concluida)
            {
                Console.WriteLine("Essa tarefa já está concluída.");
                return;
            }

            tarefa.Concluida = true;
            concluidas.Push(tarefa.Id);

            Console.WriteLine("Tarefa " + tarefa.Id + " concluída!");
        }

        static Tarefa ProcurarPorId(int id)
        {
            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa.Id == id)
                    return tarefa;
            }

            return null;
        }
    }
}
