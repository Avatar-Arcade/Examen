using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Examen_t.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Examen_t.Controllers
{
    public class Api_tController : ApiController
    {
        [HttpGet][Route("api/{query}")] public IHttpActionResult filtro(String query)
        {
            if (query.Contains('*') == true)
            { query.Remove('*'); }
            List<Persona> temporal = listpersonas().Where(c => c.persona.StartsWith(query,StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Ok(temporal);
        }
    
     
        private List<Persona>  listpersonas()
        {

            List<Persona> temporal = new List<Persona>();
            StreamReader file =new  StreamReader(@"C:\trabajo xd\palabras.txt");
            String line ;
            int i = 1;
            while ((line = file.ReadLine()) != null)
            {
                    Persona reg = new Persona()
                    {
                        cod = i,
                        persona = line,
                    };
                    i++;
                    temporal.Add(reg);
            }
            file.Close();
            return temporal;
        }

    }
}
