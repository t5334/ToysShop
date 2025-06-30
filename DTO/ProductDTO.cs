using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record ProductDTO(int Id,string ProductName,string CategoryName,string Description, int? Price, string PathImage);
}
