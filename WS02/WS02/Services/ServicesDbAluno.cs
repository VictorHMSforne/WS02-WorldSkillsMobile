using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //adicionei
using WS02.Models; //adicionei

namespace WS02.Services
{
    public class ServicesDbAluno
    {
        SQLiteConnection conn;
        
        public string StatusMessage { get; set; }

        public ServicesDbAluno(string dbPath) //aqui acha o caminho do banco
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<ModelAluno>();
        }

        public void Inserir(ModelAluno aluno)
        {
            try
            {
                if (string.IsNullOrEmpty(aluno.Nome))
                    throw new Exception("Nome do Aluno não informado!");
                if (string.IsNullOrEmpty(aluno.Idade))
                    throw new Exception("A idade do Aluno não informada!");
                int result = conn.Insert(aluno);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("Aluno inserido com sucesso!");
                }
                else
                {
                    this.StatusMessage = string.Format("Aluno não foi inserido!");
                }

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public List<ModelAluno> Listar()
        {
            List<ModelAluno> lista = new List<ModelAluno>();
            try
            {
                lista = conn.Table<ModelAluno>().ToList();
                this.StatusMessage = "Listagem de Alunos";
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return lista;
        }

        public void Alterar(ModelAluno aluno)
        {
            try
            {
                if (string.IsNullOrEmpty(aluno.Nome))
                    throw new Exception("Nome do Aluno não informado!");
                if (string.IsNullOrEmpty(aluno.Idade))
                    throw new Exception("A idade do Aluno não informada!");
                if(aluno.Id <= 0)
                    throw new Exception("Id do Aluno não informada!");
                int result = conn.Update(aluno);
                StatusMessage = string.Format("{0}, registro(s) alterados!", result);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelAluno>().Delete(a =>/*sinal de atribuição*/ a.Id == id);
                StatusMessage = string.Format("{0}, registro deletado", result);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public List<ModelAluno> Localizar(string nome)
        {
            List<ModelAluno> lista = new List<ModelAluno>();
            try
            {
                var resp = from p in conn.Table<ModelAluno>() where p.Nome.ToLower().Contains(nome.ToLower()) select p;
                lista = resp.ToList();
                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return lista;
        }

        public ModelAluno GetAluno(int id)
        {
            ModelAluno aluno = new ModelAluno();
            try
            {
                aluno = conn.Table<ModelAluno>().First(a => a.Id == id);
                StatusMessage = "Aluno Encontrado";

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return aluno;
        }
    }
}
