using Company.Services.Infrasctructure.Models;
using Company.Services.Model.Utils;

namespace Company.Services.Model.User
{
    public class UsersOrdersTotalDTQ : QueryDTO
    {
        public string SortBy { get; set; }
        public OrderByType OrderBy { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }

        public UsersOrdersTotalDTQ()
        {
            SortBy = "name";
            OrderBy = OrderByType.ASC;
            Limit = 10;
            Offset = 0;
        }
    }
}