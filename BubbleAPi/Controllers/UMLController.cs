using Microsoft.AspNetCore.Mvc; 
using CreateInterfaceWithConnections.Injections; 
 
namespace BubbleAPi 
{ 
    [ApiController]
    [Route("[controller]")] 
    public class UMLController : ControllerBase 
    { 
        private readonly UseLiblary _use; 
 
        public UMLController() 
        { 
            _use = new UseLiblary(); 
        } 
 
        [HttpGet] 
        public void UseILiblary() 
        { 
           _use.UML(); 
        } 
    } 
} 
