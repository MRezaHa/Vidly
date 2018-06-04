using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public Customer Customer { get; set; }

        public List<Movie> Movies { get; set; }
    }
}