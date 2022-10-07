//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Orenda.Models
//{
//    public class Produtos
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace Orenda.Models
{
    public class Produtos
    {
        [Key]
        public int cod_prod { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "date")]
        public DateTime Validade { get; set; }

        public decimal Preco { get; set; }

        public TimeSpan? Tempo { get; set; }

        private readonly static string _conn =
            @"Data Source=DESKTOP-3NC3AOG;Initial Catalog=Orenda;Integrated Security=SSPI;Persist Security Info=False;";
        private static SqlConnection myConnection = new SqlConnection(_conn);
        public bool Cadastrar()
        {
            var sql = " insert into Produtos (prodNome, prodQtd, prodVal, prodPreco, prodTempo) values(" +
                      $" '{this.Nome}' ,{this.Quantidade}, '{this.Validade}', '{this.Preco}', '{this.Tempo}')";
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
    }
}