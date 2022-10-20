using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Dynamic;


namespace Orenda.Models
{
    public class Clientes
    {
        [Key]
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public decimal CPF { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Situacao { get; set; }

        private readonly static string _conn =
            @"Data Source=DESKTOP-3NC3AOG;Initial Catalog=Orenda;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection myConnection = new SqlConnection(_conn);
        public static bool Deletar(int id)
        {
            var sql = " delete from Clientes Where cod_cli = "+ id;
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
            var sql = " insert into Clientes (cliNome, cliCPF, endereco, cidade, estado, ativo) values(" +
                      $" '{this.Nome}' ,{this.CPF}, '{this.Endereco}', '{this.Cidade}', '{this.Estado}', '{this.Situacao}')";
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

        public static List<Clientes> RecuperarList()
        {
            var ret = new List<Clientes>();
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format(
                        "select * from Clientes order by cod_cli");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Clientes
                        {
                            CodCliente = (int)reader["cod_cli"],
                            Nome = (string)reader["cliNome"],
                            CPF = (decimal)reader["cliCPF"],
                            Endereco = (string)reader["endereco"],
                            Cidade = (string)reader["cidade"],
                            Estado = (string)reader["estado"],
                            Situacao = (string)reader["ativo"]
                        });
                    }
                }
            }

            return ret;
        }
        public static Clientes GetClientes(int id)
        {
            using (var minhaConnection = new SqlConnection(_conn))
            {
                minhaConnection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = minhaConnection;
                    cmd.CommandText = string.Format($"select * from Clientes where cod_cli = {id}");
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Clientes
                        {
                            CodCliente = (int)reader["cod_cli"],
                            Nome = (string)reader["cliNome"],
                            CPF = (decimal)reader["cliCPF"],
                            Endereco = (string)reader["endereco"],
                            Cidade = (string)reader["cidade"],
                            Estado = (string)reader["estado"],
                            Situacao = (string)reader["ativo"]
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
            var sql = "UPDATE Clientes " +
                    $"SET cliNome= '{this.Nome}', " +
                    $"cliCPF= {this.CPF}, " +
                    $"endereco = '{this.Endereco}', " +
                    $"cidade = '{this.Cidade}', " +
                    $"estado = '{this.Estado}', " +
                    $"ativo= '{this.Situacao}' " +
                    $"WHERE cod_cli = {this.CodCliente}";
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