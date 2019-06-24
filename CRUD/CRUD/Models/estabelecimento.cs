using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class estabelecimento
    {
        [Key]
        public int estabelecimentoId { get; set; }
        [Column(TypeName ="varchar(250)")]

        [DisplayName("Razao Social")]
        [Required]
        public string razaoSocial { get; set; }
        [Column(TypeName = "varchar(250)")]

        [DisplayName("Nome")]
        public string nome { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string cnpj { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string email { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string endereco { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string cidade { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string estado { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string telefone { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string dataCadastro { get; set; }
        [Column(TypeName = "varchar(250)")]
        [DisplayName("Categoria")]
        public string categoria { get; set; }
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Status")]
        public string status { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string agencia { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string conta { get; set; }


    }
}
