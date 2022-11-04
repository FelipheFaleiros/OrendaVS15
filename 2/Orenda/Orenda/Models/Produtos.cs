using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Globalization;

namespace Orenda.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public int CodProd { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public DateTime Validade { get; set; }

        public decimal Preco { get; set; }

        public TimeSpan? Tempo { get; set; }

        private readonly static string _conn =
            @"Data Source=DESKTOP-3NC3AOG;Initial Catalog=Orenda;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection myConnection = new SqlConnection(_conn);
        public bool Cadastrar()
        {
            var sql = " insert into Produtos (prodNome, prodQtd, prodVal, prodPreco, prodTempo) values(" +
                      $" '{this.Nome}' ,{this.Quantidade}, '{this.Validade.ToString("yyyy/MM/dd", new CultureInfo("en-US"))}', '{this.Preco}', '{this.Tempo}')";
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

        public static List<Produtos> RecuperarList()
        {
            var ret = new List<Produtos>();
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format(
                        "select * from Produtos order by cod_prod");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Produtos
                        {
                            CodProd = (int)reader["cod_prod"],
                            Nome = (string)reader["prodNome"],
                            Quantidade = (int)reader["prodQtd"],
                            Validade = (DateTime)reader["prodVal"],
                            Preco = (decimal)reader["prodPreco"],
                            Tempo = (TimeSpan)reader["prodTempo"],
                        });
                    }
                }
            }
            return ret;
            }

        public static bool Deletar(int id)
        {
            var sql = " delete from Produtos Where cod_prod = " + id;
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
        public static Produtos GetProdutos(int id)
        {
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format($"select * from Produtos where cod_prod = {id}");
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Produtos
                        {
                            CodProd = (int)reader["cod_prod"],
                            Nome = (string)reader["prodNome"],
                            Quantidade = (int)reader["prodQtd"],
                            Validade = (DateTime)reader["prodVal"],
                            Preco = (decimal)reader["prodPreco"],
                            Tempo = (TimeSpan)reader["prodTempo"],
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool Put()
        {
            var sql = "UPDATE Produtos " +
                    $"SET prodNome = '{this.Nome}', " +
                    $"prodQtd = {this.Quantidade}, " +
                    $"prodVal = '{this.Validade.ToString("yyyy/MM/dd", new CultureInfo("en-US"))}', " +
                    $"prodPreco = '{this.Preco}', " +
                    $"prodTempo = '{this.Tempo}' " +
                    $"WHERE cod_prod = {this.CodProd}";
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
            catch (Exception ex)
            {
                myConnection.Close();
                return (false);
            }
        }

    }
}