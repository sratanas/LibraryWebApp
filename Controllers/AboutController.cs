using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApp.Controllers
{

    //about


    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "123-456-7890";
        }

        [Route("[action]")]
        public string Address()
        {
            return "Northeast Minneapolis";
        }
    }
}
