using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Orenda.Models
{
    [Table("Fornecedores")]
    public partial class Fornecedores
    {
        [Key]
        public int CodFornecedor { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public decimal CNPJ { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        public TimeSpan? Tempo { get; set; }
        private readonly static string _conn =
                   @"Data Source=DESKTOP-3NC3AOG;Initial Catalog=Orenda;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection myConnection = new SqlConnection(_conn);

        public bool Deletar()
        {
            var sql = " delete * from Fornecedores where cod_cli = {0}";
            try
            {
                using (var minhaConnection = new SqlConnection(_conn))
                {
                    {
                        minhaConnection.Open();
                        using (var cmd = new SqlCommand(sql, minhaConnection))
                        {
                            using (var dr = cmd.ExecuteReader())
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                myConnection.Close();
                return (false);
            }
        }

        public bool Cadastrar()
        {
            var sql = " insert into Fornecedores (forNome, forCNPJ, forEndereco, forTempo) values(" +
                      $" '{this.Nome}' ,{this.CNPJ}, '{this.Endereco}', '{this.Tempo}')";
            try
            {
                using (var minhaConnection = new SqlConnection(_conn))
                {
                    {
                        minhaConnection.Open();
                        using (var cmd = new SqlCommand(sql, minhaConnection))
                        {
                            using (var dr = cmd.ExecuteReader())
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                myConnection.Close();
                return (false);
            }
        }

        public static List<Fornecedores> RecuperarList()
        {
            var ret = new List<Fornecedores>();
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format(
                        "select * from Fornecedores order by cod_For");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Fornecedores
                        {
                            CodFornecedor = (int)reader["cod_For"],
                            Nome = (string)reader["forNome"],
                            CNPJ = (decimal)reader["forCNPJ"],
                            Endereco = (string)reader["forEndereco"],
                            Tempo =(TimeSpan)reader["forTempo"]
                        });
                    }
                }
            }

            return ret;
        }
    }
}
