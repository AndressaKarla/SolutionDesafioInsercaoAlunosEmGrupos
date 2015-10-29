using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioInsercaoAlunosEmGrupos
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Lista turma de alunos
            List<Aluno> turma = new List<Aluno>();

            int qtdeAlunos = 0;

            do
            {
                Console.Write("Digite a quantidade de alunos na turma: ");
                qtdeAlunos = int.Parse(Console.ReadLine());
            } while (qtdeAlunos <= 0);

            //Incluir turma de alunos
            AlunoOperation.AddAlunoTurma(qtdeAlunos, turma);

            int qtdeGrupos;
            do
            {
                Console.Write("\n\nDigite a quantidade de grupos a serem formados: ");
                qtdeGrupos = int.Parse(Console.ReadLine());
            } while (qtdeGrupos <= 0);

            //Array de lista de alunos conforme qtde de grupos informado
            List<Aluno>[] grupos = new List<Aluno>[qtdeGrupos];

            for (int i = 0; i < qtdeGrupos; i++)
            {
                grupos[i] = new List<Aluno>();
            }

            //Dividir cada turma de alunos em grupos de forma aleatória 
            AlunoOperation.OrganizarGrupos(turma, grupos, qtdeGrupos);

            //Exibir grupos
            ApresentarGrupos(qtdeGrupos, grupos);

            Console.ReadKey();
        }

        private static void ApresentarGrupos(int qtdeGrupos, List<Aluno>[] grupos)
        {
            for (int i = 0; i < qtdeGrupos; i++)
            {
                Console.WriteLine("\n\tGrupo {0}:\n", i);
                foreach (var aluno in grupos[i])
                {
                    Console.WriteLine("\t\t{0}", aluno.Nome);
                }
            }
        }
    }
}




