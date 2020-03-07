namespace Andreys.ViewModels.Home
{
    using System.Collections.Generic;

    public class LoggedInHomeViewModel
    {
        public IEnumerable<ProductHomeViewModel> Products { get; set; }
    }
}
