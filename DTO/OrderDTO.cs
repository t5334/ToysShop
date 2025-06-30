using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO (int Id,int UserId,DateTime OrderDate,double OrderSum, ICollection<OrderItemDTO> OrderItems)
}
