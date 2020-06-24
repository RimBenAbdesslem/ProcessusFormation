using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Compétence;

namespace ProcessusFormation.Controllers.Compétence
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetierController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public MetierController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterMetier")]
        public async Task<IActionResult> PostBesoinFormation(MetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var metier = new MetierModel()
            {

                DomaineId = model.DomaineId,
                UserId = model.UserId,
                LabelId = model.LabelId,
                Niveau = model.Niveau,

            };

            var result = await _context.Metiers.AddAsync(metier);
            _context.SaveChanges();
            return Ok(new { });

        }
        //Get Metier selon IDUser
        [HttpGet]
        [Route("GetAllmetieruser/{UserId}")]
        public IEnumerable<Object> GetUserMetier(string UserId) {
            var metier = _context.Metiers.Find(UserId);
            if (metier == null)
            {
                yield return (null);
            };
           yield return (metier);
        }
        //Get all 
        [HttpGet]
        [Route("GetAllmetieruser")]
        public IEnumerable<Object> GetAllDomaine(MetierModel labele)
        {
            var label= new MetierModel() { };
            var movies = _context.Metiers;
            var i=0 ;
              foreach(MetierModel element in movies)
            {
                if (element.UserId == labele.UserId)
                {
                    label=element;
                    var variable = _context.Labels.Find(label.LabelId);
                    yield return (variable);
                }
                
            }
             
            var  mov = from m in movies
                     select m;
                    
              var  labels = from Lab in _context.Labels
                            select Lab;
        



        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Object> GetAll(MetierModel label)
        {
            var blogs = _context.Metiers;
            if (blogs == null)
            {
               yield return (null);
            }
            foreach (var element in blogs)
            {
                if (element.UserId == label.UserId && element.LabelId == label.LabelId)
                {
                    yield return (element);

                };
            }
        }
        }
}
// var applicationUser =  _userManager.FindByIdAsync(labele.UserId);

// var label = _context.Labels;
//  var metier = _context.Metiers;

//  foreach(var element in metier)
// {
//     yield return (element);
//    if ((element.UserId == labele.UserId) && (element.LabelId == labele.LabelId))
//  {
//      yield return (element);
//      foreach (LabelModel lab in label)
//     {

//       if (lab.LabelId == labele.LabelId)
//     {
//         yield return (lab);
//    }

// }

//  }

//   }