using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Filters
{
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute() : base(typeof(BasicAuthFilter)) { }
    }

}
