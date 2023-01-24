using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fiap.Api.AspNet.Models
{
    [Table("CLIENTE")]
    public class ClienteModel
    {
        [HiddenInput]
        [Key]
        [Column("CLIENTEID")]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 70 caracteres.")]
        [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
        [Column("NOME")]
        public string? Nome { get; set; }


        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento incorreta")]
        [Column("DATANASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [Column("OBSERVACAO")]
        public string? Observacao { get; set; }


        //Campo de chave Estrangeira - Foreign Key (FK)
        [Display(Name = "Representante")]
        [Column("REPRESENTANTEID")]
        public int RepresentanteId { get; set; }

        //Objeto - Navigation Object
        public RepresentanteModel? Representante { get; set; }

    }
}
