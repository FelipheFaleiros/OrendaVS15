using System;
using System.Data.SqlClient;

namespace Orenda.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }


        private readonly static string _conn = @"Data Source=DESKTOP-3NC3AOG;Initial Catalog=new;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection minhaConnection = new SqlConnection(_conn);

        public bool Login()
        {
            var sql = "Select Id, Nome, Senha From Users Where Email = '" + this.Email + "' ";

            try
            {

                using (var minhConnection = new SqlConnection(_conn))
                {
                    minhConnection.Open();
                    using (var cmd = new SqlCommand(sql, minhConnection))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows) //se encontrou alguma linha
                            {
                                if (dr.Read())//vai ler
                                {
                                    if (this.Senha == dr["Senha"].ToString())
                                    {
                                        this.Id = Convert.ToInt32(dr["Id"]);
                                        this.Usuario = dr["Nome"].ToString();
                                        minhaConnection.Close();
                                        return true;
                                    }
                                }
                            }
                            minhaConnection.Close();
                            return false;
                        }
                    }
                }
            }

            catch (Exception)
            {
                //Console.WriteLine(e);
                //return false;
                //throw new InvalidOperationException("Os dados não podem sem lidos", e);
                minhaConnection.Close();
                return false;
            }
        }
    }
}