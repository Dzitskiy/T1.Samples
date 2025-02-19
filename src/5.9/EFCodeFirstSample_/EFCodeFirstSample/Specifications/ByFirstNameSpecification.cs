using EFCodeFirstSample.Domain.Entities;
using System.Linq.Expressions;

namespace EFCodeFirstSample.Specifications
{
    public class ByFirstNameSpecification : Specification<Employee>
    {
        private readonly string _firstName;

        public ByFirstNameSpecification(string firstName)
        {
            _firstName = firstName;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return emp => emp.FirstName == _firstName;
        }
    }
}
