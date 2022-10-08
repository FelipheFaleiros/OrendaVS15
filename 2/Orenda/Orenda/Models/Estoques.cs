using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //tirar
using System.Globalization;

namespace Orenda.Models
{
    [Table("Estoque")] //se der pau tinhar isso 
    public partial class Estoques
    {
        [Key]
        public int CodEst { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeMateriaPrima { get; set; }

        public int Quantidade { get; set; }

        public DateTime Validade { get; set; }

        private readonly static string _conn =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Orenda;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection myConnection = new SqlConnection(_conn);

        public bool Cadastrar()
        {
            var sql = " insert into  Estoque (mp, mpQtd, mpVal) values(" +
                      $" '{this.NomeMateriaPrima}' ,{this.Quantidade}, '{this.Validade}')";
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

        public static List<Estoques> RecuperarList()
        {
            var ret = new List<Estoques>();
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format(
                        "select * from Estoque order by cod_est");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Estoques
                        {
                            CodEst = (int)reader["cod_est"],
                            NomeMateriaPrima = (string)reader["mp"],
                            Quantidade = (int)reader["mpQtd"],
                            Validade = (DateTime)reader["mpVal"]
                            
                        });
                    }
                }
            }

            return ret;
        }

        public static Estoques GetProdutos(int id)
        {
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format($"select * from Estoque where cod_est = {id}");
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Estoques
                        {
                            CodEst = (int)reader["cod_est"],
                            NomeMateriaPrima = (string)reader["mp"],
                            Quantidade = (int)reader["mpQtd"],
                            Validade = (DateTime)reader["mpVal"]
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
            var sql = "UPDATE Estoque " +
                    $"SET mp = '{this.NomeMateriaPrima}', " +
                    $"mpQtd = {this.Quantidade}, " +
                    $"mpVal = '{this.Validade.ToString("yyyy/MM/dd", new CultureInfo("en-US"))}' " +
                    $"WHERE cod_est = {this.CodEst}";
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
