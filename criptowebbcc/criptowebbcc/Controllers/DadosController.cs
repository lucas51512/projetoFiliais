using criptowebbcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace criptowebbcc.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;

        }

        public IActionResult Cliente()
        {
            contexto.Database.ExecuteSqlRaw("delete from clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('clientes', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vCidade = { "Assis", "Candido Mota", "Taruma", "Paraguaçu", "Palmital", "Pedrinhas", "Maracai", "Cruzalia" };
            for (int i = 0; i < 100; i++)
            {
                Cliente cliente = new Cliente();

                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.cidade = vCidade[randNum.Next() % 8];
                cliente.estado = (Estado)randNum.Next(20);
                cliente.idade = randNum.Next(18, 95);
                contexto.clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.clientes.OrderBy(o => o.nome).ToList());
        }

        public IActionResult Filial()
        {
            contexto.Database.ExecuteSqlRaw("delete from filiais");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('filiais', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeFilial1 = { "FL 1", "FL 2", "FL 3", "FL 4", "FL 5", "FL 6", "FL 7", "FL 8", "FL 9", "FL 11", "FL 12", "FL 13", "FL 14", "FL 15", "FL 16", "FL 17", "FL 19", "FL 20", "FL 21", "FL 22", "FL 23", "FL 24", "FL 25", "FL 26", "FL 27", "FL 28", "FL 29", "FL 30", "FL 31", "FL 32", "FL 33", "FL 34", "FL 35", "FL 36", "FL 37", "FL 38", "FL 39", "FL 40", "FL 41", "FL 42", "FL 43", "FL 44", "FL 45", "FL 46", "FL 47", "FL 48", "FL 49", "FL 50",};
            string[] vNomeFilial2 = { "FL 51", "FL 52", "FL 53", "FL 54", "FL 55", "FL 56", "FL 57", "FL 58", "FL 59", "FL 511", "FL 312", "FL 313", "FL 314", "FL 315", "FL 316", "FL 317", "FL 319", "FL 220", "FL 221", "FL 222", "FL 223", "FL 224", "FL 225", "FL 256", "FL 527", "FL 228", "FL 529", "FL 630", "FL 331", "FL 332", "FL 333", "FL 334", "FL 335", "FL 336", "FL 373", "FL 538", "FL 439", "FL 440", "FL 412", "FL 242", "FL 543", "FL 494", "FL 945", "FL 646", "FL 476", "FL 648", "FL 469", "FL 590", };
            string[] vCidade = { "Assis", "Candido Mota", "Taruma", "Paraguaçu", "Palmital", "Pedrinhas", "Maracai", "Cruzalia" };
            for (int i = 0; i < 100; i++)
            {
                Filial filial = new Filial();

                filial.nomeFilial = (i % 2 == 0) ? vNomeFilial1[i / 2] : vNomeFilial2[i / 2];
                filial.cidadeFilial = vCidade[randNum.Next() % 8];
                filial.estadoFilial = (Estado)randNum.Next(20);
            }
            contexto.SaveChanges();

            return View(contexto.clientes.OrderBy(o => o.nome).ToList());
        }
    }
}
