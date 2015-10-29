using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioInsercaoAlunosEmGrupos
{
    /// <summary>
    /// Operações realizadas em Aluno 
    /// </summary>
    public class AlunoOperation
    {
        /// <summary>
        /// Em AddAluno são incluídos os nomes dos alunos
        /// </summary>
        /// <param name="aluno">Instância de Aluno recebida como parâmetro</param>
        /// <param name="i">Indice de acordo com a qtde de alunos informada</param>
        public static void AddAluno(Aluno aluno, int i)
        {
            do
            {
                Console.Write("\nDigite o nome do aluno {0}: ", i);
                aluno.Nome = Console.ReadLine();
            } while (aluno.Nome == string.Empty);
        }

        /// <summary>
        /// Em OrganizarGrupos são agrupados os alunos de forma aleatória
        /// </summary>
        /// <param name="turma">Lista de alunos</param>
        /// <param name="grupos">Array de Lista de alunos</param>
        /// <param name="qtdeGrupos">Qtde de grupos informada</param>
        public static void OrganizarGrupos(List<Aluno> turma, List<Aluno>[] grupos, int qtdeGrupos)
        {
            Random rand = new Random();
            int codGrupo = 0;
            Stack<int> pilha = new Stack<int>();
            foreach (var item in turma)
            {
                do
                {
                    codGrupo = rand.Next(qtdeGrupos);
                } while (!GerarAleatoriosSemRepeticao(codGrupo, pilha, qtdeGrupos));

                grupos[codGrupo].Add(item);
            }
        }

        /// <summary>
        /// Em AddAlunoTurma são adicionados os alunos na lista de turma
        /// </summary>
        /// <param name="qtdeAlunos">Qtde de alunos informada</param>
        /// <param name="turma">Lista de alunos</param>

        public static void AddAlunoTurma(int qtdeAlunos, List<Aluno> turma)
        {
            for (int i = 0; i < qtdeAlunos; i++)
            {
                Aluno aluno = new Aluno();
                aluno.Nome = string.Empty;
                AlunoOperation.AddAluno(aluno, i);
                turma.Add(aluno);
            }
        }

        /// <summary>
        /// Em GerarAleatoriosSemRepeticao são gerados indices dos grupos de forma aleatória sem repetição
        /// </summary>
        /// <param name="i">Código do grupo</param>
        /// <param name="pilha">Pilha onde serão empilhados os códigos dos grupos</param>
        /// <param name="qtdeGrupos">Qtde de grupos informadas</param>
        /// <returns>Retorna true em caso de ter gerado códigos não repetidos</returns>
        public static bool GerarAleatoriosSemRepeticao(int i, Stack<int> pilha, int qtdeGrupos)
        {
            if (pilha.Count == qtdeGrupos)
            {
                pilha.Clear();
            }

            if (pilha.Contains(i))
            {
                return false;
            }

            else
            {
                pilha.Push(i);
            }

            return true;
        }
    }
}
