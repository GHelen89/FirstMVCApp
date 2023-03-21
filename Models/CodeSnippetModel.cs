using System.ComponentModel.DataAnnotations;


namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid IDCodeSnippet { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="Titlul poate sa contina max 100 caractere")]
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IDMember { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="revision number trebuie sa fie pozitiv!")]
        public int Revision { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public Boolean IsPublished { get; set; }
    }
}
