using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SQLite;
using ATM.Models;




namespace ATM.Controllers
{
    public class TarefaController : Controller
    {
        // GET: Tarefa
        public ActionResult Index()
        {
            // define o comando de pesquisa
            string query = "SELECT * FROM Tarefa";

            // cria um novo objeto de acesso a dados
            DAL dal = new DAL();

            // Executa o comando dado na query
            SQLiteDataReader dr = dal.LerSQLite(query);

            // cria uma lista de tarefas para armazenar em memória os dados
            // do banco
            List<Tarefa> tarefas = new List<Tarefa>();

            // Manda o datareader continuar a ler o banco, avançando
            //para o próximo registro.
            dr.Read();

            // Carrega na memória (na lista tarefas) a relação de 
            // todas as tarefas armazenadas
            // no banco de dados
            while (dr.Read())
            {
                Tarefa tarefa = new Tarefa
                {
                    TarefaID = Convert.ToInt32(dr["TarefaID"]),
                    NomeTarefa = Convert.ToString(dr["NomeTarefa"]),
                    Descricao = Convert.ToString(dr["Descricao"]),
                    Disciplina = Convert.ToString(dr["Disciplina"]),
                    Data = Convert.ToDateTime(dr["Data"])
                };
                tarefas.Add(tarefa);
            }

            return View(tarefas);

        }

        // GET: Tarefa/Details/5
        public ActionResult Details(int id)
        {
            //Criação da pesquisa desejada
            string query = String.Format("SELECT * FROM Tarefa WHERE TarefaID = {0}", id);

            // Criação do objeto de consulta no banco de dados
            DAL dal = new DAL();

            // Criação do objeto que armazena em memória o resultado 
            // da pesquisa
            SQLiteDataReader dr = dal.LerSQLite(query);

            dr.Read();
            Tarefa tarefa = new Tarefa
            {
                TarefaID = Convert.ToInt32(dr["TarefaID"]),
                NomeTarefa = Convert.ToString(dr["NomeTarefa"]),
                Descricao = Convert.ToString(dr["Descricao"]),
                Disciplina = Convert.ToString(dr["Disciplina"]),
                Data = Convert.ToDateTime(dr["Data"])
            };

            return View(tarefa);
        }

        // GET: Tarefa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefa/Create
        [HttpPost]
        public ActionResult Create(string NomeTarefa, string Descricao, string Disciplina, DateTime Data)
        {
            try
            {
                DAL dal = new DAL();
                Tarefa tarefa = new Tarefa();
                tarefa.NomeTarefa = NomeTarefa;
                tarefa.Descricao = Descricao;
                tarefa.Disciplina = Disciplina;
                tarefa.Data = Data;

                string query = String.Format("INSERT INTO Tarefa(TarefaID, NomeTarefa, Descricao, Disciplina, Data) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", null, tarefa.NomeTarefa, tarefa.Descricao, tarefa.Disciplina, tarefa.Data.ToShortDateString());
                dal.InserirSQLite(query);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int id)
        {
            string query = String.Format("SELECT * FROM Tarefa WHERE TarefaID = {0}", id);

            DAL dal = new DAL();
            SQLiteDataReader dr = dal.LerSQLite(query);

            dr.Read();
            Tarefa tarefa = new Tarefa
            {
                TarefaID = Convert.ToInt32(dr["TarefaID"]),
                NomeTarefa = Convert.ToString(dr["NomeTarefa"]),
                Descricao = Convert.ToString(dr["Descricao"]),
                Disciplina = Convert.ToString(dr["Disciplina"]),
                Data = Convert.ToDateTime(dr["Data"])
            };
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string NomeTarefa, string Descricao, string Disciplina, DateTime Data)
        {
            try
            {
                DAL dal = new DAL();
                Tarefa tarefa = new Tarefa();
                tarefa.NomeTarefa = NomeTarefa;
                tarefa.Descricao = Descricao;
                tarefa.Disciplina = Disciplina;
                tarefa.Data = Data;

                string query = String.Format("UPDATE Tarefa SET NomeTarefa = '{0}', Descricao = '{1}', Disciplina = '{2}', Data = '{3}' WHERE TarefaID = {4} ", tarefa.NomeTarefa, tarefa.Descricao, tarefa.Disciplina, tarefa.Data.ToShortDateString(), id);

                dal.AtualizarSQLite(query);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int id)
        {
            string query = String.Format("SELECT * FROM Tarefa WHERE TarefaID = {0}", id);

            DAL dal = new DAL();
            SQLiteDataReader dr = dal.LerSQLite(query);

            dr.Read();
            Tarefa tarefa = new Tarefa
            {
                TarefaID = Convert.ToInt32(dr["TarefaID"]),
                NomeTarefa = Convert.ToString(dr["NomeTarefa"]),
                Descricao = Convert.ToString(dr["Descricao"]),
                Disciplina = Convert.ToString(dr["Disciplina"]),
                Data = Convert.ToDateTime(dr["Data"])
            };

            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DAL dal = new DAL();
                string query = String.Format("DELETE FROM Tarefa WHERE TarefaID = {0}", id);
                
                dal.ApagarSQLite(query);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET
        public ActionResult Limite()
        {
            // define o comando de pesquisa
            string query = "SELECT * FROM Tarefa";

            // cria um novo objeto de acesso a dados
            DAL dal = new DAL();

            // Executa o comando dado na query
            SQLiteDataReader dr = dal.LerSQLite(query);

            // cria uma lista de tarefas para armazenar em memória os dados
            // do banco
            List<Tarefa> tarefas = new List<Tarefa>();

            // Manda o datareader continuar a ler o banco, avançando
            //para o próximo registro.
            dr.Read();

            // Carrega na memória (na lista tarefas) a relação de 
            // todas as tarefas armazenadas
            // no banco de dados
            while (dr.Read())
            {
                Tarefa tarefa = new Tarefa
                {
                    TarefaID = Convert.ToInt32(dr["TarefaID"]),
                    NomeTarefa = Convert.ToString(dr["NomeTarefa"]),
                    Descricao = Convert.ToString(dr["Descricao"]),
                    Disciplina = Convert.ToString(dr["Disciplina"]),
                    Data = Convert.ToDateTime(dr["Data"])
                };
                tarefas.Add(tarefa);
            }

            //Checando se há tarefa vencida e informando ao usuário

            List<Tarefa> tarefaLimite = new List<Tarefa>();

            List<string> HorasCheias = new List<string>();
            for(int i = 0; i< 25; i++)
            {
                HorasCheias.Add(i.ToString());
            }

            //O sistema checará a hora e a cada hora cheia executará
            // o procedimento de informar buscar no banco de dados se
            //há tarefa vencida.
            if (HorasCheias.Contains(DateTime.Now.ToString()))
            {
                //Procura as tarefas na lista de tarefas cuja data é a de hoje e
                // adiciona tais tarefas na lista tarefaLimite.
                foreach (Tarefa v in tarefas)
                {
                    if (v.Data.ToShortDateString() == DateTime.Today.ToString())
                    {

                        tarefaLimite.Add(v);
                        
                    }
                    
                }
                return View(tarefaLimite);
            }
            return RedirectToAction("Index");
        }

    }
}
