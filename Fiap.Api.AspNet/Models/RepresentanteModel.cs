using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fiap.Api.AspNet.Models
{
    [Table("REPRESENTANTE")]
    public class RepresentanteModel
    {
        [Key]
        [Column("REPRESENTANTEID")]
        public int RepresentanteId { get; set; }

        [Column("NOMEREPRESENTANTE")]
        [Required(ErrorMessage = "Nome do representante é obrigatório!")]
        [StringLength(80,
        MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 80 caracteres")]
        [Display(Name = "Nome do Representante")]
        public string? NomeRepresentante { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "CPF é obrigatório!")]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        // Essa anotação é apenas um exemplo de um propriedade não mapeada em uma coluna do banco de dados
        [NotMapped]
        public string? Token { get; set; }


        //Navegation Property
        public IList<ClienteModel> Clientes { get; set; }

        public RepresentanteModel()
        {

        }

        public RepresentanteModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }

        public RepresentanteModel(int representanteId, string cpf, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            Cpf = cpf;
            NomeRepresentante = nomeRepresentante;
        }
    }
}
