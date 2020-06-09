using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using ATM.Models;
using System.Web.Mvc;

namespace ATM
{
    // Esta classe permite que seus objetos executem pesquisas no banco de dados.
    // O único método da classe retorna um SQLteDataReader a partir da execução 
    // de uma cláusula SQL.
    public class DAL
    {
        public SQLiteDataReader LerSQLite(string query)
        {
            //Instancia-se um objeto SQLiteDataReader 
            SQLiteDataReader dr;

            //Cria-se uma nova conexão
            SQLiteConnection conn = new SQLiteConnection();

            //Define-se o endereço do banco SQLite
            string ConectaBanco =
                "Data Source = C:\\code\\app\\database\\Tarefas.db";
            conn.ConnectionString = ConectaBanco;

            // Abre-se a conexão
            conn.Open();

            // instancia um objeto comando SQLiteql (SQLiteCommand) e se passa
            // a ela uma cláusula sql para ser executada na conexão conn

            SQLiteCommand command = new SQLiteCommand(query, conn);

            // Armazena o resultado do comando.
            dr = command.ExecuteReader();

            // Retorna o resultado do comando.
            return dr;

        }

        // Esse método insere dados no SQLite

        

        [HttpPost]
        public void InserirSQLite(string query)
        {
            try
            {
                
                 //Cria-se uma nova conexão
                SQLiteConnection conn = new SQLiteConnection();

            //Define-se o endereço do banco SQLite
                string ConectaBanco =
                    "Data Source = C:\\code\\app\\database\\Tarefas.db";
                conn.ConnectionString = ConectaBanco;

            // Abre-se a conexão
                conn.Open();


            // instancia um objeto comando SQLiteql (SQLiteCommand) e se passa
            // a ela uma cláusula sql para ser executada na conexão conn

                SQLiteCommand command = new SQLiteCommand(query, conn);

                // Executa o comando
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarSQLite(string query)
        {
            try
            {
                //Cria-se uma nova conexão
                SQLiteConnection conn = new SQLiteConnection();

                //Define-se o endereço do banco SQLite
                string ConectaBanco =
                    "Data Source = C:\\code\\app\\database\\Tarefas.db";
                conn.ConnectionString = ConectaBanco;

                // Abre-se a conexão
                conn.Open();


                
                 // instancia um objeto comando SQLiteql (SQLiteCommand) e se passa
            // a ela uma cláusula sql para ser executada na conexão conn

                SQLiteCommand command = new SQLiteCommand(query, conn);

                // Executa o comando
                command.ExecuteNonQuery();
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ApagarSQLite(string query)
        {
            try
            {
                //Cria-se uma nova conexão
                SQLiteConnection conn = new SQLiteConnection();

                //Define-se o endereço do banco SQLite
                string ConectaBanco =
                    "Data Source = C:\\code\\app\\database\\Tarefas.db";
                conn.ConnectionString = ConectaBanco;

                // Abre-se a conexão
                conn.Open();

                // instancia um objeto comando SQLite3 (SQLiteCommand) e se passa
                // a ela uma cláusula sql para ser executada na conexão conn

                SQLiteCommand command = new SQLiteCommand(query, conn);

                // Executa o comando
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}