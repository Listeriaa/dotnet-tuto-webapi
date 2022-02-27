using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    //equivalent du serializer
    public class CommandUpdateDto : AbstractDto
    {
    //     //no need for Id because created by db

    //     //if you put the annotation on DTO, if one is not fulfilled, it will send a 400 error.
    //     //if you just have annotations on Model, it will send a 500 error and we don't want that because it is not really a ser
    //     [Required]
    //     [MaxLength(250)]
    //     public string HowTo { get; set; }

    //     [Required]
    //     public string Line { get; set; }
        
    //     [Required]
    //     public string Platform { get; set; }
    // }
    }
}