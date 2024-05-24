using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //adicionado

namespace WS02.Models
{
    [Table("Aluno")]
    public class ModelAluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nome { get; set; }

        [NotNull]
        public string Idade { get; set;}

        public ModelAluno() //já passa os valores para inicar
        {
            this.Id = 0;
            this.Nome = "";
            this.Idade = "";
        }

    }
}
