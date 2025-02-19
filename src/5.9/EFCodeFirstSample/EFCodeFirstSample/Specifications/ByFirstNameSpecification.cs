using EFCodeFirstSample.Domain.Entities;
using System.Linq.Expressions;

namespace EFCodeFirstSample.Specifications
{
    public class ByNameSpecification : Specification<Employee>
    {
        private readonly string _name;

        public ByNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return user => user.FirstName == _name;
        }
    }
}
