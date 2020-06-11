using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public string Disciplina { get; set; }
        public DateTime Data { get; set; }
    }

    
}